using System;
using System.IO;
using Server;
using Server.Gumps;
using Server.Items;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Misc;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

// -- TMSS 4.0 -- CORE FILES --
//Computer meus nefandus est.
//Version 3.0
namespace Server.TMSS
{
	//Skill Profiles are classes that hold values. And some minor "thinking".
	//They are used in gumps, buyable skills, tickets, stones, etc. in order to simplify which goes where, and what can be set, and to what value.
	//version: 2.1a

	#region TMSkillInfo
	internal class TMSkillInfo
	{
		private string m_SkillName = "";
		private int m_SkillValue = 0;
		private bool m_SkillEnable = true;
		private double m_SkillWeight = 1.0;
		private int m_SkillCap = 10;
		private int m_SkillID = -1;

		internal int SkillValue { get { return m_SkillValue; } }
		internal string SkillName { get { return m_SkillName; } }
		internal bool SkillEnable { get { return m_SkillEnable; } }
		internal double SkillWeight { get { return m_SkillWeight; } }
		internal int SkillCap { get { return m_SkillCap; } }
		internal int SkillID { get { return m_SkillID; } }

		internal TMSkillInfo(string name, bool enable, int value, double weight, int cap, int id )
		{
			m_SkillName = name;
			m_SkillEnable = enable;
			m_SkillValue = value;
			m_SkillWeight = weight;
			m_SkillCap = cap;
			m_SkillID = id;
		}
		internal TMSkillInfo(XmlReader read)
		{ Deserialize( read ); }
		public void Reset(bool enable, int value, double weight, int cap)
		{
			m_SkillEnable = enable;
			m_SkillValue = value;
			m_SkillWeight = weight;
			m_SkillCap = cap;
		}
		public void Serialize(XmlWriter write)
		{
			write.WriteStartElement("SkillInfo");
			write.WriteAttributeString("skn", "" + m_SkillName);
			write.WriteAttributeString("skv", "" + m_SkillValue);
			write.WriteAttributeString("ske", "" + m_SkillEnable);
			write.WriteAttributeString("skw", "" + m_SkillWeight);
			write.WriteAttributeString("skc", "" + m_SkillCap);
			write.WriteAttributeString("ski", "" + m_SkillID);
			write.WriteEndElement();
		}
		public void Deserialize(XmlReader read)
		{			
			m_SkillName=read.LocalName;
			m_SkillName = read.GetAttribute(0);
			m_SkillValue = Int32.Parse(read.GetAttribute(1));
			m_SkillEnable = read.GetAttribute(2) == "True"? true:false;
			m_SkillWeight = Double.Parse(read.GetAttribute(3));
			m_SkillCap = Int32.Parse(read.GetAttribute(4));
			m_SkillID = Int32.Parse(read.GetAttribute(5));
			read.Read();
		}
	}
	#endregion

	#region Skill Profile Class
	/// <summary>
	/// New for TMSS 3.0. Skill m_profiles are used to hold data for gumps, stones, gates, tickets, etc. They utilize two major arrays and a number of values to do this.
	/// </summary>
	public class SkillProfile
	{
		#region Dictionaries

		internal Dictionary<string, TMSkillInfo> MasterHash
		{
			get { return m_MasterHash; }
			set { m_MasterHash = value; }
		}

		public void addCompleteEntry(bool ena, int value, double weight, int cap, int index)
		{
			string name = SkillInfo.Table[index].Name;

			if (MasterHash.ContainsKey(name))
			{ MasterHash.Remove(name); }
			MasterHash.Add(name, new TMSkillInfo(name, ena, value, weight, cap, index));
		}

		private Dictionary<string, TMSkillInfo> m_MasterHash = new Dictionary<string, TMSkillInfo>();
		
		#endregion

		#region Standalone Variables

		public int ID = -1;
		public int defaultValue = 100;
		public int IconID = 1234;
		private string m_ProfileName = "";

		public bool Manual = false;
		public int SkillPoints = 1400;

		public int StatSum = 9000;
		public int StrVal = 3000;
		public int DexVal = 3000;
		public int IntVal = 3000;

		public bool StatForce = true;
		public bool StatEnable = true;
		public bool SkillForce = true;
		public bool IsGumped = true;
		public bool IsKeyed = true;
		public bool SkillEnable = true;
		public bool StandTicket = false;
		public bool CapEnable = false;
		public bool WeightEnable = true;
		public int CapSum = 20;

		public string ProfileName
		{
			get { return m_ProfileName; }
		}

		#endregion
		
		public SkillProfile(string name)
		{
			m_ProfileName = name;
		}
				
		public override string ToString()
		{
			return "TMSS/4 Profile named: " + ProfileName;
		}

		internal TMSkillInfo getAtRank(int count)
		{
			if( count < 0 )
				return null;

			IEnumerator ie = MasterHash.GetEnumerator();
			TMSkillInfo inf = null;
			while (count > -1)
			{
				ie.MoveNext();
				inf = (TMSkillInfo)((KeyValuePair<string,TMSkillInfo>)ie.Current).Value;
				if( inf.SkillEnable )
					count--;
			}
			return inf;
		}
	}
	#endregion

	#region SuperProfileHelper
	public class SuperProfileHelper
	{
		public static void SaveSelf(SuperSkillProfile profile)
		{
			if (!Directory.Exists("TMSS/SkillProfiles"))
				Directory.CreateDirectory("TMSS/SkillProfiles");
			
			string FileName = profile.ProfileName + ".spr";

			string path = @"TMSS/SkillProfiles/[SUPER]" + FileName;
			if( File.Exists( path ) )
				File.Delete( path );
			DateTime start = DateTime.Now;
			bool G = !File.Exists(path);
			Console.Write(" - Saving TMSS Super Skill Profile " + profile.ProfileName + "...");
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.IndentChars = "	";

			XmlWriter write = XmlWriter.Create(path, settings);
			//Writing
			write.WriteStartElement("TMSuperProfile");
			IEnumerator val = profile.getProfileList();

			write.WriteStartElement("ProfileName");
			write.WriteValue(profile.ProfileName);
			write.WriteEndElement();

			write.WriteStartElement("Count");
			write.WriteValue(profile.subProfiles.Count);
			write.WriteEndElement();

			while (val.MoveNext())
			{
				write.WriteStartElement("SubProfile");
				write.WriteValue(((KeyValuePair<string, SkillProfile>)val.Current).Value.ProfileName);
				write.WriteEndElement();
			}
			write.WriteEndElement();
			write.Close();
			SkillProfileHelper.SkillProfileSaver( profile );
			Console.WriteLine("done");
		}

		public static void LoadSelf(FileInfo fileName)
		{
			string path = fileName.FullName;

			if (!File.Exists(path))
			{ Console.WriteLine("ERROR: Super Profile Not Found "); return; }
			
			XmlReaderSettings settings = new XmlReaderSettings();
			XmlReader read = XmlReader.Create(path, settings);

			read.ReadStartElement("TMSuperProfile");

			read.ReadStartElement("ProfileName");
			string name = read.ReadContentAsString();
			read.ReadEndElement();
			SkillSettings.SystemWrite("Loading SuperProfile " + name);
			SuperSkillProfile profile = new SuperSkillProfile(name);

			read.ReadStartElement("Count");
			int count = read.ReadContentAsInt();
			read.ReadEndElement();
			int curr = 0;
			while (curr < count)
			{
				read.ReadStartElement("SubProfile");
				profile.addProfile((string)read.ReadContentAsString());//.ReadContentAsString());
				read.ReadEndElement();
				curr++;
			}
			read.ReadEndElement();
			read.Close();
			SkillProfileHelper.SkillProfileLoader(profile.ProfileName, false);
			RegisterSuperProfile(profile);
		}

		internal static void RegisterSuperProfile(SuperSkillProfile sprofile)
		{
			//SuperProfileHelper.SaveSelf(sprofile);
			SkillProfileHelper.AddNewProfile(sprofile, true);
		}
	}
	#endregion

	#region Super Profile Class

	public class SuperSkillProfile : SkillProfile
	{
		public Dictionary<string, SkillProfile> subProfiles = new Dictionary<string, SkillProfile>();

		public SuperSkillProfile(string name)
			: base(name)
		{ }

		public void addProfile(SkillProfile p)
		{
			if( subProfiles.ContainsKey( p.ProfileName ) )
				subProfiles.Remove( p.ProfileName );

			subProfiles.Add(p.ProfileName, p);
		}
		public void addProfile(string name)
		{
			if( subProfiles.ContainsKey( name ) )
				subProfiles.Remove( name );

			subProfiles.Add(name, SkillProfileHelper.getProfile(name));
		}

		public void remProfile(string name)
		{
			if (subProfiles.ContainsKey(name))
				subProfiles.Remove(name);
			else
				SkillSettings.DoTell("SuperProfile does not contain profile " + name);
		}

		public SkillProfile getProfile(string name)
		{
			if (subProfiles.ContainsKey(name))
				return (SkillProfile)subProfiles[name];
			else
			{ SkillSettings.DoTell("No such profile: " + name); return null; }
		}
		public SkillProfile getProfile(int index)
		{			
			IEnumerator ie = subProfiles.GetEnumerator();
			//SkillProfile ret = null;
			if (index < 0)
			{ SkillSettings.DoTell("Invalid profile iteration ID. " + index); return null; }

			while (index > -1 && ie.MoveNext())
			{
				try
				{					
					index--;
					if( index == 0 )
						return ((KeyValuePair<string, SkillProfile>)ie.Current).Value;
				}
				catch (Exception e)
				{ SkillSettings.DoTell("Unable to move enumerator where expected able. " + e); return null; }
			}
			return null;
		}
		public IEnumerator getProfileList()
		{
			return subProfiles.GetEnumerator();
		}
	}
	#endregion

	//This class is the guts behind the SkillProfile.
	//In here, all the dynamic stuff is done.
	/*
	A. Making a new profile.
	B. Editing old profiles.
	C. Saving profiles to files.
	D. Loading in profile names at startup.
	E. Loading in profiles when needed.
	F. Verifying that a profile exists.
	*/
	//version: 2.5
	#region Skill Profile Helper
	public class SkillProfileHelper
	{		
		public static string Something = "Vxc1fO80YMFblD5W1sAvDQ==";
		private static Dictionary<string, SkillProfile> m_profiles = new Dictionary<string, SkillProfile>();
		private static Dictionary<string, SuperSkillProfile> m_supers = new Dictionary<string, SuperSkillProfile>();

		public static Dictionary<string, SkillProfile> Profiles
		{ get { return m_profiles; } }
		public static Dictionary<string,SuperSkillProfile> Supers
		{ get { return m_supers; } }
		
		#region ProfileSave
		//This saves a new skill profile to disk.
		/* Structure of a SkillProfile .skp:
		A. SkillProfile Name
		B. Number of Skills on server of origin.
		C. Sum of Stats allowed for profile.
		D. Stat max values (Str, Dex, Int)
		E. Array of bools for enabled/disabled values.
		F. Array of ints for max skill values.		
		*/

		//input is a profile. This comes from the edit or creation gump.
		public static void SkillProfileSaver(SkillProfile profile)
		{
			if (!Directory.Exists("TMSS/SkillProfiles"))
				Directory.CreateDirectory("TMSS/SkillProfiles");

			string FileName = profile.ProfileName + ".skx";

			string path = @"TMSS/SkillProfiles/" + FileName;

			DateTime start = DateTime.Now;
			bool G = !File.Exists(path);
			Console.Write(" - //4// - Saving TMSS Skill Profile " + profile.ProfileName + "...");

			SkillSettings.DoTell2("Outside try");
			try
			{
				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Indent = true;
				settings.IndentChars = "	";

				XmlWriter writer = XmlWriter.Create(path, settings);
				//Must I tell you not to mess with this?

				//Name of the Profile
				writer.WriteStartElement("TMSkillProfile");
				writer.WriteAttributeString("Name", profile.ProfileName);
				SkillSettings.DoTell2("" + profile.ProfileName);

				//Stats Element:
				writer.WriteStartElement("Stats");
				writer.WriteAttributeString("Ena", "" + profile.StatEnable);
				writer.WriteAttributeString("Frc", "" + profile.StatForce);
				writer.WriteAttributeString("Sum", "" + profile.StatSum);
				writer.WriteAttributeString("Str", "" + profile.StrVal);
				writer.WriteAttributeString("Dex", "" + profile.DexVal);
				writer.WriteAttributeString("Int", "" + profile.IntVal);
				writer.WriteEndElement();
				writer.WriteStartElement("Gumps");
				writer.WriteAttributeString("Man", "" + profile.Manual);
				writer.WriteAttributeString("Use", "" + profile.IsGumped);
				writer.WriteAttributeString("Icn", "" + profile.IconID);
				writer.WriteEndElement();
				writer.WriteStartElement("Skills");
				writer.WriteAttributeString("Ena", "" + profile.SkillEnable);
				writer.WriteAttributeString("Pts", "" + profile.SkillPoints);
				writer.WriteAttributeString("Frc", "" + profile.SkillForce);
				writer.WriteAttributeString("Key", "" + profile.IsKeyed);
				writer.WriteAttributeString("CEn", "" + profile.CapEnable);
				writer.WriteAttributeString("CSm", "" + profile.CapSum);
				writer.WriteAttributeString("WEn", "" + profile.WeightEnable);
				writer.WriteAttributeString("Cnt", "" + profile.MasterHash.Count);
				writer.WriteEndElement();
				
				IEnumerator ie = profile.MasterHash.GetEnumerator();
				while (ie.MoveNext())
				{
					//writer.Write(((TMSkillInfo)((DictionaryEntry)ie.Current).Value).SkillName);
					((KeyValuePair<string,TMSkillInfo>)ie.Current).Value.Serialize(writer);
				}
				writer.WriteEndElement(); writer.Close(); Console.WriteLine("done."); writeFile(profile, G);
			}
			catch (Exception e)
			{ SkillSettings.DoTell("Exception when writing SkillProfile: " + e); }
		}

		#endregion

		#region ProfileLoad
		//This is used when a new profile is selected for an item, in order to load up the profile.
		//It is only used if the profile is not already loaded into the SkillProfiles array above.
		public static int SkillProfileLoader(string name, bool which)
		{			
			if (Profiles.ContainsKey(name))
				return ((SkillProfile)Profiles[name]).ID;
			try
			{
				SkillProfile profile;
				string path = "";
				if (which == false)
					path = "TMSS/SkillProfiles/" + name + ".skx";
				else
					path = "TMSS/SkillProfiles/" + name;
				if (!File.Exists(path))
				{ SkillSettings.DoTell("File Does Not Exist: " + path);	return 0; }				
				
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.IgnoreWhitespace = true;
				XmlReader reader = XmlReader.Create(path, settings);
				reader.ReadToFollowing("TMSkillProfile");
				int count = 0;
				string realname = reader.GetAttribute(0);
				//reader.ReadStartElement("TMSkillProfile");				
				profile = new SkillProfile(realname);
				
				reader.ReadToFollowing("Stats");
				profile.StatEnable = reader.GetAttribute(0) == "True" ? true : false;
				profile.StatForce = reader.GetAttribute(1) == "True" ? true : false;
				profile.StatSum = Int32.Parse(reader.GetAttribute(2));
				profile.StrVal = Int32.Parse(reader.GetAttribute(3) );
				profile.DexVal = Int32.Parse(reader.GetAttribute(4) );
				profile.DexVal = Int32.Parse(reader.GetAttribute(5) );

				reader.ReadToFollowing("Gumps");				
				profile.Manual = reader.GetAttribute(0) == "True" ? true : false;
				profile.IsGumped = reader.GetAttribute(1) == "True" ? true : false;
				profile.IconID = Int32.Parse(reader.GetAttribute(2) );

				reader.ReadToFollowing("Skills");
				profile.SkillEnable = reader.GetAttribute(0) == "True" ? true : false;
				profile.SkillPoints = Int32.Parse(reader.GetAttribute(1));
				SkillSettings.DoTell("Profile - "+profile.ProfileName+" has points at "+profile.SkillPoints );
				profile.SkillForce = reader.GetAttribute(2) == "True" ? true : false;
				profile.IsKeyed = reader.GetAttribute(3) == "True" ? true : false;
				profile.CapEnable = reader.GetAttribute(4) == "True" ? true : false;
				profile.CapSum = Int32.Parse(reader.GetAttribute(5));
				profile.WeightEnable = reader.GetAttribute(6) == "True" ? true : false;
				count = Int32.Parse(reader.GetAttribute(7) );
				reader.ReadToFollowing("SkillInfo");		
				while (count > 0)
				{
					TMSkillInfo inf = new TMSkillInfo( reader );
					profile.MasterHash.Add( inf.SkillName, inf );
					count--;
				}
				reader.Close();								
				int ret = AddNewProfile(profile);
				writeFile(profile, false);
				return ret;
			}
			catch (Exception e)
			{ SkillSettings.DoTell("Error while loading Skill Profile. This is a Level 1 I/O error. Please report." + e); return -1; }
		}

		#region WriteFile
		public static void writeFile(SkillProfile profile, bool naming)
		{

			string middle;
			if (naming)
				middle = "" + profile.ProfileName + " [Original]";
			else
				middle = "" + profile.ProfileName;

			if (!Directory.Exists("TMSS/SkillProfiles/Information"))
				Directory.CreateDirectory("TMSS/SkillProfiles/Information/");

			string path = "TMSS/SkillProfiles/Information/" + profile.ProfileName + ".txt";
			try
			{
				using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
				{
					StreamWriter sw = new StreamWriter(stream);

					sw.WriteLine("This is the output for " + profile.ProfileName + " on " + DateTime.Now);

					if (naming)
						sw.WriteLine("This was generated at the creation of the profile.");

					sw.WriteLine("\n\nGeneral: ");
					sw.WriteLine("\t-Manual: " + profile.Manual);
					sw.WriteLine("\t-Stat Force: " + profile.StatForce);
					sw.WriteLine("\t-Stats Enabled: " + profile.StatEnable);
					sw.WriteLine("\t-Stat Sum: " + profile.StatSum);
					sw.WriteLine("\t-Strength: " + profile.StrVal);
					sw.WriteLine("\t-Dexterity: " + profile.DexVal);
					sw.WriteLine("\t-Intelligence: " + profile.IntVal);
					sw.WriteLine("\t-Skill Force: " + profile.SkillForce);
					sw.WriteLine("\t-Name: " + profile.ProfileName);
					sw.WriteLine("\t-Num Allowed Skills: " + profile.SkillPoints);
					sw.WriteLine("\t-Skill Sum: " + profile.SkillPoints);
					sw.WriteLine("\t-Skill Sum: " + profile.IsKeyed);
					sw.WriteLine("\t-Skill Sum: " + profile.IsGumped);
					sw.WriteLine("\n\nEnabled Skills & Skill Values: ");
					sw.WriteLine("\n\n");
					//sw.WriteLine("Index: " +  " Name: " + SkillInfo.Table[0].Name + " Is: " +   " And its Max Value is: " );
					IEnumerator ie = profile.MasterHash.GetEnumerator();
					int i = 0;
					while (ie.MoveNext())
					{
						TMSkillInfo info = ((KeyValuePair<string,TMSkillInfo>)ie.Current).Value;
						sw.WriteLine("\tIndex: "+i+" Name: "+info.SkillName+" is "+info.SkillEnable+", with Max of: "+info.SkillValue+", Cap of "+info.SkillCap+", and Weight of "+info.SkillWeight);
						i++;
					}

					sw.Close();
					stream.Close();
				}

			}
			catch (Exception e)
			{
				SkillSettings.DoTell("Error while attempting to write out profile information: " + e);
			}
		}
		#endregion

		#endregion

		#region ProfileStartup

		public static SuperSkillProfile GenInitialProfile()
		{
			Console.WriteLine(" - TMSS|4 Default Profile Generation In Progress...");
			//SkillProfile profile = new SkillProfile("Default Profile");
			
			SuperSkillProfile defprof = new SuperSkillProfile( "Default Profile" );

			SkillProfile miscProf = new SkillProfile ("Miscellaneous");
						
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 0);//0
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 7);//7
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 8);//8
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 11);//11
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 13);//13
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 17);//17
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 18);//18
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 20);//20
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 24);//24
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 25);//25
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 26);//26
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 28);//28
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 29);//29
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 33);//33
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 34);//34
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 37);//37
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 39);//39
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 45);//45
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 46);//46
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 47);//47
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 48);//48
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 49);//49
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 50);//50
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 51);//51
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 52);//52
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 53);//53
			miscProf.addCompleteEntry(true, 100, 1.0, 10, 54);//54
			miscProf.IconID = 2287;
			RegisterProfile( miscProf );
			defprof.addProfile( miscProf );

			SkillProfile comRate = new SkillProfile( "Combat Ratings" );

			comRate.addCompleteEntry(true, 100, 1.0, 10, 31);//31
			comRate.addCompleteEntry(true, 100, 1.0, 10, 42);//42
			comRate.addCompleteEntry(true, 100, 1.0, 10, 41);//41
			comRate.addCompleteEntry(true, 100, 1.0, 10, 5);//5
			comRate.addCompleteEntry(true, 100, 1.0, 10, 40);//40
			comRate.addCompleteEntry(true, 100, 1.0, 10, 27);//27
			comRate.addCompleteEntry(true, 100, 1.0, 10, 43);//43
			comRate.IconID = 5585;
			RegisterProfile( comRate );
			defprof.addProfile( comRate );

			SkillProfile actions = new SkillProfile( "Actions" );

			actions.addCompleteEntry(true, 100, 1.0, 10, 35);//35
			actions.addCompleteEntry(true, 100, 1.0, 10, 6);//6
			actions.addCompleteEntry(true, 100, 1.0, 10, 10);//10
			actions.addCompleteEntry(true, 100, 1.0, 10, 12);//12
			actions.addCompleteEntry(true, 100, 1.0, 10, 14);//14
			actions.addCompleteEntry(true, 100, 1.0, 10, 15);//15
			actions.addCompleteEntry(true, 100, 1.0, 10, 21);//21
			actions.addCompleteEntry(true, 100, 1.0, 10, 23);//23
			actions.addCompleteEntry(true, 100, 1.0, 10, 9);//9
			actions.addCompleteEntry(true, 100, 1.0, 10, 30);//30
			actions.addCompleteEntry(true, 100, 1.0, 10, 22);//22
			actions.addCompleteEntry(true, 100, 1.0, 10, 32);//32
			actions.addCompleteEntry(true, 100, 1.0, 10, 38);//38
			actions.IconID = 20998;
			RegisterProfile( actions );
			defprof.addProfile( actions );

			SkillProfile loreKnow = new SkillProfile( "Lore & Knowledge" );

			loreKnow.addCompleteEntry(true, 100, 1.0, 10, 1);//1
			loreKnow.addCompleteEntry(true, 100, 1.0, 10, 2);//2
			loreKnow.addCompleteEntry(true, 100, 1.0, 10, 4);//4
			loreKnow.addCompleteEntry(true, 100, 1.0, 10, 16);//16
			loreKnow.addCompleteEntry(true, 100, 1.0, 10, 19);//19
			loreKnow.addCompleteEntry(true, 100, 1.0, 10, 3);//3
			loreKnow.addCompleteEntry(true, 100, 1.0, 10, 36);//36
			loreKnow.IconID = 23014;
			RegisterProfile( loreKnow );
			defprof.addProfile( loreKnow );

			SuperProfileHelper.RegisterSuperProfile(defprof);
			SuperProfileHelper.SaveSelf(defprof);
			Console.WriteLine("done");
			//writeFile(profile, true);
			return defprof;
		}

		public static void Configure()
		{
			SkillProfileInitializer();
		}

		public static void SkillProfileInitializer()
		{
			if (Directory.Exists("TMSS/SkillProfiles"))
			{
				DirectoryInfo info = new DirectoryInfo("TMSS/SkillProfiles");

				FileInfo[] fileInfo = info.GetFiles();
				int numprof = 0;
				foreach (FileInfo fileName in fileInfo)
				{
					if (fileName.Extension == ".skx")
					{
						SkillProfileLoader(fileName.Name, true);
						numprof++;
					}
					if (fileName.Extension == ".spr")
						SuperProfileHelper.LoadSelf(fileName);
				}
				if (numprof == 0)
				{
					GenInitialProfile();
				}
			}
		}

		#endregion

		#region ProfileUtil
		private static void RegisterProfile(SkillProfile profile)
		{
			SkillProfileSaver(profile);
			AddNewProfile(profile);
		}

		public static bool ProfileExists(string name)
		{
			return Profiles.ContainsKey(name);
		}
		
		public static int getProfileID(string name)
		{
			if (Profiles[name] != null)
			{
				return ((SkillProfile)Profiles[name]).ID;
			}
			return -1;
		}
		public static SkillProfile getProfile(string name)
		{
			if( Supers.ContainsKey( name ) )
				return (SkillProfile)Supers[name];
			else if ( name == "defaultInternal" && Supers.ContainsKey(SkillSettings.CCProfileName) )
				return (SkillProfile)Supers[SkillSettings.CCProfileName];
			try
			{
				if (name == "defaultInternal")
					name = SkillSettings.CCProfileName;
				return (SkillProfile)Profiles[name];
			}
			catch (Exception e)
			{
				SkillSettings.DoTell(" Profile in slot " + name + " does not exist. Exception: " + e);
				return (SkillProfile)Profiles["Default Profile"];
			}
		}

		public static void DoBroadcast()
		{
			World.Broadcast(2118, true, SkillSettings.SkillPhrase);
		}
		//This method does the actual adding of a profile to the SkillProfiles array.
		//Input is a profile, which is the freshly-loaded profile. Called from the SkillProfileLoader method.	
		public static int AddNewProfile(SkillProfile profile)
		{
			return AddNewProfile( profile, false );
		}
		//This method does the actual adding of a profile to the SkillProfiles array.
		//Input is a profile, which is the freshly-loaded profile. Called from the SkillProfileLoader method.	
		public static int AddNewProfile(SkillProfile profile, bool super )
		{
			if (super)
			{
				if (Supers != null)
				{
					if( Supers.ContainsKey( profile.ProfileName ) )
						Supers.Remove( profile.ProfileName);
					Supers.Add( profile.ProfileName, (SuperSkillProfile)profile );
					//SkillSettings.doTell( "New SuperProfile " +profile.ProfileName+" has been added.");
					return Supers.Count;
				}
				else
				{ SkillSettings.DoTell("Invalid hashtable to add to."); return -1; }
			}
			else if (Profiles != null)
			{
				if( Profiles.ContainsKey( profile.ProfileName ))
					Profiles.Remove( profile.ProfileName );
				Profiles.Add(profile.ProfileName, profile);
			
				//ProfileNames.Add(m_profiles.Count, profile.NumAllowed );
				SkillSettings.DoTell2("New profile " + profile.ProfileName + " has been added with point value: "+profile.SkillPoints);
				return Profiles.Count;
			}
			else
			{
				SkillSettings.DoTell("Invalid hashtable");
				return -1;
			}
		}
		#endregion
	}
	#endregion
}