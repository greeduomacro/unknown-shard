using System;
using System.Reflection;
using System.Globalization;
using Server;
using Server.Gumps;
using Server.TMSS;
using Server.Commands;
using Server.Targeting;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.IO;
using Server.Network;
// -- // 4 // --
//Written for TMSS 4.0
//Author: TMSTKSBK
//Version: 2.0
//Title: Parallel Skills.

namespace Server.TMSS
{
	#region Parallel Skills
	public class ParallelSkills : TMPlugin
	{
		private static int internalvalue = -1;
		public static string SkillSkin = "Skill Skin";
		public static List<SkillInfo> infos = new List<SkillInfo>();
		public static Dictionary<string, int> NameLocs = new Dictionary<string, int>();
		
		public static void Configure()
		{			
			EventSink.Login += new LoginEventHandler( skillCheck );
			Server.Commands.CommandSystem.Register( "SetSkillP", AccessLevel.GameMaster, new CommandEventHandler( SetSkillP_OnCommand ) );
			Server.Commands.CommandSystem.Register("SetAllSkillsP", AccessLevel.GameMaster, new CommandEventHandler(SetAllSkillsP_OnCommand));
			Server.Commands.CommandSystem.Register("gsw", AccessLevel.GameMaster, new CommandEventHandler(GSW_OnCommand));
			ReadSkills();
			resetTable( );
		}
		
		private static void ReadSkills()
		{
			//string path = Environment.CurrentDirectory+"\\TMSS\\Data\\ParallelSkills\\skills.psi";
			string path = "C:\\ruo2\\TMSS\\Data\\ParallelSkills\\skills.psi";

			if (!File.Exists(path))
			{ SkillSettings.DoTell("CS Warning - No Custom Skills file exists on path: "+path);}

			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			XmlReader reader;
			try
			{
				reader = XmlReader.Create(path, settings);
			}
			catch (Exception e)
			{
				if( Core.Debug )
					SkillSettings.SystemWrite(" -//P//- Could not create reader: "+e);
				else
					SkillSettings.SystemWrite(" -//P//- File not found, or invalid.");
				return;
			}
			try
			{
				reader.ReadToFollowing("ParallelSkills");
				reader.ReadToFollowing("settings");

				int count = Int32.Parse(reader.GetAttribute(0));

				for (int i = 0; i < count; i++)
				{
					reader.ReadToFollowing("skill");
					//int id = Int32.Parse(reader.GetAttribute(0));
					string name = reader.GetAttribute(0);
					string BLARR = reader.GetAttribute(1);
					double sscale = Double.Parse(BLARR);
					double dscale = Double.Parse(reader.GetAttribute(2));
					double iscale = Double.Parse(reader.GetAttribute(3));
					string title = reader.GetAttribute(4);
					double sgain = Double.Parse(reader.GetAttribute(5));
					double dgain = Double.Parse(reader.GetAttribute(6));
					double igain = Double.Parse(reader.GetAttribute(7));
					double gainf = Double.Parse(reader.GetAttribute(8));
					SkillInfo info = new SkillInfo(0, name, sscale, dscale, iscale, title, null, sgain, dgain, igain, gainf);
					if (infos.Contains(info))
						infos.Remove(info);

					infos.Add(info);
				}
				reader.Close();
			}
			catch (Exception e){ SkillSettings.DoTell("Gar."+e);}
		}

		public static void resetTable( )
		{
			if( infos.Count > 0 )
			{
				Console.WriteLine(" -//P//- Setting "+infos.Count+" Custom Skills.");
			}
			else
			{
				Console.WriteLine(" -//P//- No Custom Skills Found.");
			}
			SkillInfo[] info = new SkillInfo[infos.Count + SkillInfo.Table.Length];
			SkillSettings.DoTell("info Length: " + info.Length + " infos Length: " + infos.Count + " Table Length: " + SkillInfo.Table.Length);

			try
			{
				for (int i = 0; i < info.Length; i++)
				{
					if (i < SkillInfo.Table.Length)
					{
						info[i] = SkillInfo.Table[i];
						NameLocs.Add(SkillInfo.Table[i].Name, i);
					}
					else
					{
						SkillInfo thisinfo = infos[i - SkillInfo.Table.Length];
						info[i] = new SkillInfo(i, thisinfo.Name, thisinfo.StrScale, thisinfo.DexScale, thisinfo.IntScale, thisinfo.Title, thisinfo.Callback, thisinfo.StrGain, thisinfo.DexGain, thisinfo.IntGain, thisinfo.GainFactor);
						NameLocs.Add(infos[i - SkillInfo.Table.Length].Name, i);
						SkillSettings.DoTell(" -//P//-Adding Custom Skill: " + info[i].Name);
					}
				}
			}
			catch (Exception e)
			{
				SkillSettings.DoTell("Exception when loading new skills. " + e);
			}
			SkillInfo.Table = info;
			SkillSettings.DoTell("Custom Skills load completed. Table Length: "+SkillInfo.Table.Length);
		}

		public static void skillCheck( LoginEventArgs e )
		{
			Mobile from = e.Mobile;
			
			if( from.Skills.Length < SkillInfo.Table.Length )
			{
				SkillSettings.DoTell("Mobile: "+from.Name+" has fewer than the correct number of skills.");
				double[] skillValsOld = new double[ from.Skills.Length ];
				SkillSettings.DoTell("Saving Old Skill Values.");
				for( int i = 0; i < from.Skills.Length; i++ )
				{
					skillValsOld[i] = from.Skills[i].Base;
				}
				
				try
				{
					Type t2 = typeof( Mobile );
					
					FieldInfo inf = null;
					if( t2 != null )
					{
						SkillSettings.DoTell(" t is null, t2 is not."+t2.ToString());
						inf = t2.GetField( "m_Skills", BindingFlags.NonPublic | BindingFlags.Instance );
					}
					else
						SkillSettings.DoTell("t & t2 are null");
						
					Skills s = new Skills( from );
					
					if( inf != null && from != null && s != null )
					{
						inf.SetValue( from, s );
						SkillSettings.DoTell("Changeover for: "+from.Name+" is completed. ");
					}
					else if( inf == null )
						SkillSettings.DoTell("Inf is null");
					else if( from == null )
						SkillSettings.DoTell("from is null");
					else if( s == null )
						SkillSettings.DoTell("s is null");
				}
				catch( Exception exc )
				{
					SkillSettings.DoTell("Exception generated when setting new skills: "+exc);
				}
				
				SkillSettings.DoTell("Resetting Old Skills in new Skills - "+from.Skills.Length);
				for( int i = 0; i < skillValsOld.Length; i++ )
				{
					from.Skills[i].Base = skillValsOld[i];
				}
			}
			else if( from.Skills.Length > SkillInfo.Table.Length )
			{
				SkillSettings.DoTell("Mobile: "+from.Name+" has more than the correct number of skills.");
				double[] temp = new double[SkillInfo.Table.Length];
				for( int i = 0; i < temp.Length; i++ )
				{
					temp[i] = from.Skills[i].Base;
				}
				from.Skills = new Skills(from);
				for( int i = 0; i < temp.Length; i++ )
				{
					from.Skills[i].Base = temp[i];
				}
			}
			else
			{
				SkillSettings.DoTell("Mobile: "+from.Name+" has the correct number of skills.");
			}
		}

		public static void RegisterSkill ( SkillInfo si )
		{
			SkillSettings.DoTell("-Registering new CustomSkill: "+si.Name);
			infos.Add( si );
		}

		public static int FindSkillID( string name )
		{
			for( int i = 0; i < SkillInfo.Table.Length; i++ )
			{
				if( SkillInfo.Table[i].Name == name )
				{
					return i;
				}
			}
			return 0;
		}

		#region Commands
		[Usage( "SetAllSkillsP <name> <value>" )]
		[Description( "Sets all skill values of a targeted mobile." )]
		public static void SetAllSkillsP_OnCommand( CommandEventArgs arg )
		{
			if ( arg.Length != 1 )
			{
				arg.Mobile.SendMessage( "SetAllSkillsP <value>" );
			}
			else
			{
				arg.Mobile.Target = new AllSkillsTargetP( arg.GetDouble( 0 ) );
			}
		}
		
		[Usage("gsw")]
		[Description("Writes the default Skill Skin to disk.")]
		public static void GSW_OnCommand(CommandEventArgs arg)
		{
			SkillSkin skin = new SkillSkin( "Skill Skin" );
			SkinHelper.WriteSkin( skin );
		}
		
		[Usage( "SetSkillP <name> <value>" )]
		[Description( "Sets a skill value by name of a targeted mobile." )]
		public static void SetSkillP_OnCommand( CommandEventArgs arg )
		{
			if ( arg.Length != 2 )
			{
				arg.Mobile.SendMessage( "SetSkillP <skill name> <value>" );
			}
			else
			{
				string skill;
				int which = 0;
				try
				{
					skill =  arg.GetString( 0 );
					for( int i = 0; i < SkillInfo.Table.Length; i++ )
					{
						if( skill == SkillInfo.Table[i].Name )
						{
							which = i;
						}
					}
				}
				catch
				{
					arg.Mobile.SendLocalizedMessage( 1005631 ); // You have specified an invalid skill to set.
					return;
				}
				arg.Mobile.Target = new SkillTargetP( which, arg.GetDouble( 1 ) );
			}
		}
		#endregion

		#region TMPlugin Members
		internal static List<string> miscsearch = new List<string>();
		internal static List<string> combsearch = new List<string>();
		internal static List<string> actisearch = new List<string>();
		internal static List<string> loresearch = new List<string>();
		internal static List<string> custsearch = new List<string>();

		public static void Initialize()
		{
			internalvalue = QueryPageHelper.RegisterSection("TMCustomSkills", "Custom Skills");
			foreach (string s in MiscSkillNames)
			{ miscsearch.Add( s ); }
			foreach (string s in CombatSkillNames)
			{ combsearch.Add(s); }
			foreach (string s in ActionSkillNames)
			{ actisearch.Add(s); }
			foreach (string s in LoreSkillNames)
			{ loresearch.Add(s); }
			foreach (SkillInfo si in SkillInfo.Table)
			{
				if (!miscsearch.Contains(si.Name) && !combsearch.Contains(si.Name) && !actisearch.Contains(si.Name) && !loresearch.Contains(si.Name))
					custsearch.Add( si.Name );
			}
			SkinHelper.LoadSkin("Skill Skin", typeof(TMSS.SkillSkin), true );
		}
		
		#region lists
		public static string[] MiscSkillNames = new string[] { 
			"Alchemy",
			"Blacksmithy",
			"Bowcraft/Fletching",
			"Bushido",
			"Carpentry",
			"Chivalry",
			"Cooking",
			"Fishing",
			"Focus",
			"Healing",
			"Herding",
			"Lockpicking",
			"Lumberjacking",
			"Magery",
			"Meditation",
			"Mining",
			"Musicianship",
			"Necromancy",
			"Ninjitsu",
			"Remove Trap",
			"Resisting Spells",
			"Snooping",
			"Spellweaving",
			"Stealing",
			"Stealth",
			"Tailoring",
			"Tinkering",
			"Veterinary"
		};

		public static string[] CombatSkillNames = new string[] {
			"Archery",
			"Fencing",
			"Mace Fighting",
			"Parrying",
			"Swordsmanship",
			"Tactics",
			"Wrestling"
		};

		public static string[] ActionSkillNames = new string[] {
			"Animal Taming",
			"Begging",
			"Camping",
			"Cartography",
			"Detecting Hidden",
			"Discordance",
			"Hiding",
			"Inscription",
			"Peacemaking",
			"Poisoning",
			"Provocation",
			"Spirit Speak",
			"Tracking"
		};

		public static string[] LoreSkillNames = new string[] {
			"Anatomy",
			"Animal Lore",
			"Arms Lore",
			"Evaluating Intelligence",
			"Forensic Identification",
			"Item Identification",
			"Taste Identification"
		};
		#endregion
		

		public void GetGumpCode(TMQueryPage page)
		{
			return;
		}

		public void OnResponse(Server.Network.NetState sender, RelayInfo info)
		{
			return;
		}

		public string getHelpText()
		{
			return "Custom Skills are available to customize your shard's skill set.";
		}

		public string getGumpType()
		{
			return "Control";
		}

		#endregion
	}
	#endregion

	#region Parallel Skills Gump
	public class ParallelSkillsGump : Gump
	{
		private List<int> showing = new List<int>();
		private List<Skill> miscinfos = new List<Skill>();
		private List<Skill> combinfos = new List<Skill>();
		private List<Skill> actiinfos = new List<Skill>();
		private List<Skill> loreinfos = new List<Skill>();
		private List<Skill> custom = new List<Skill>();
		private Mobile Mobile = null;
		private SkillSkin skin = (SkillSkin)SkinHelper.getSkin("Skill Skin");
		
		private class ParallelSmallSkillsGump : Gump
		{ 
			private List<int> showing = null;
			public ParallelSmallSkillsGump( List<int> sh ) : base( 10, 25 )
			{
				showing = sh;
				this.AddButton( 0, 0, 2105, 2105, 1, GumpButtonType.Reply, 0 );
			}
			public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
			{
				if( info.ButtonID == 1 )
					sender.Mobile.SendGump( new ParallelSkillsGump( showing, sender.Mobile ) );
			}
		}

		public ParallelSkillsGump( List<int> section, Mobile m ) : base( 0, 0 )
		{ 
			showing = section;
			Mobile = m;
			GetGumpCode( );
		}

		public ParallelSkillsGump(Mobile m)
			: base(0, 0)
		{ 
			Mobile = m;
			GetGumpCode();
		}

		public void RSS_OnCommand(CommandEventArgs e)
		{ 
			SkinHelper.LoadSkin("Skill Skin", typeof(Server.TMSS.SkillSkin), true );
		}

		#region TMPlugin Members
		private static int CompareSkillNames(Skill a, Skill b)
		{
			if (a == null && b == null)
				return 0;
			if (a == null)
				return -1;
			if (b == null)
				return 1;
			try
			{
				return Insensitive.Compare((string)a.Name, (string)b.Name);
			}
			catch
			{
				return 1;
			}
		}
		private bool checkdouble(double db)
		{
			if (db % 1 == 0.0)
				return true;
			else
				return false;
		}
		public void GetGumpCode(  ) 
		{
			WindowInfo info = new WindowInfo();
			try
			{
				info = skin.WindowInfo["SkillWindow"];
			}
			catch { return; }

			this.X = info.X;
			this.Y = info.Y;
			this.AddButton( 170, 0, 2093, 2093, -100, GumpButtonType.Reply, 0 );
			
			this.AddBackground(0, 15, info.W, info.H, info.bgID);
			this.AddImage( 145, 30, 2100 );
			this.AddImage( 22, 355, 2102 );
			this.AddImage(60, 54, 2091);
			this.AddImage(60, 333, 2091);
			Mobile m = Mobile;
			Skills s = m.Skills;

			this.AddLabel(270, 354, skin.BlueTextHue, "" + (checkdouble(s.Total / 10) ? " " + (s.Total / 10) + ".0" : " " + (s.Total / 10)));

			GumpList l = new GumpList(this, "details", skin);
			l.columns = 5;
			l.ShowDividers = false;
			l.ShowBackground = false;
			l.columnWidths[0] = 15;
			l.columnWidths[1] = 200;
			l.numperpage = 14;

			l.X = 20;
			l.Y = 51;
			
			ButtonInfo ecg = skin.ButtonInfo["ExpandContractGroup"];
			GumpListEntry miscentry = new GumpListEntry(0, 0, l, info.W - 10, 20);
			miscentry.AddColumn(new GumpButton(0, 0, !showing.Contains(1) ? ecg.up : ecg.down, !showing.Contains(1) ? ecg.up : ecg.down, 1, GumpButtonType.Reply, 0));
			miscentry.AddColumn("<basefont size=5 face = 1 color= #330066> Miscellaneous</basefont>");

			GumpListEntry combentry = new GumpListEntry(0, 0, l, info.W - 10, 20);
			combentry.AddColumn(new GumpButton(0, 0, !showing.Contains(2) ? ecg.up : ecg.down, !showing.Contains(2) ? ecg.up : ecg.down, 2, GumpButtonType.Reply, 0));
			combentry.AddColumn("<basefont size=5 face = 1 color= #330066> Combat Ratings</basefont>");

			GumpListEntry actientry = new GumpListEntry(0, 0, l, info.W - 10, 20);
			actientry.AddColumn(new GumpButton(0, 0, !showing.Contains(3) ? ecg.up : ecg.down, !showing.Contains(3) ? ecg.up : ecg.down, 3, GumpButtonType.Reply, 0));
			actientry.AddColumn("<basefont size=5 face = 1 color= #330066> Actions</basefont>");

			GumpListEntry loreentry = new GumpListEntry(0, 0, l, info.W - 10, 20);
			loreentry.AddColumn(new GumpButton(0, 0, !showing.Contains(4) ? ecg.up : ecg.down, !showing.Contains(4) ? ecg.up : ecg.down, 4, GumpButtonType.Reply, 0));
			loreentry.AddColumn("<basefont size=5 face = 1 color= #330066> Lore & Knowledge</basefont>");

			GumpListEntry customentry = new GumpListEntry(0, 0, l, info.W - 10, 20);
			customentry.AddColumn(new GumpButton(0, 0, !showing.Contains(5) ? ecg.up : ecg.down, !showing.Contains(5) ? ecg.up : ecg.down, 5, GumpButtonType.Reply, 0));
			customentry.AddColumn("<basefont size=5 face = 1 color= #330066> Custom Skills</basefont>");
			
			ButtonInfo select = skin.ButtonInfo["UseButton"];
			IEnumerator ie = null;
			int i = 1;

			for ( int k = 0; k < s.Length; k++ )
			{
				if (ParallelSkills.actisearch.Contains(s[k].Name))
					actiinfos.Add(s[k]);
				else if (ParallelSkills.combsearch.Contains(s[k].Name))
					combinfos.Add(s[k]);
				else if (ParallelSkills.miscsearch.Contains(s[k].Name))
					miscinfos.Add(s[k]);
				else if (ParallelSkills.loresearch.Contains(s[k].Name))
					loreinfos.Add(s[k]);
				else
					custom.Add(s[k]);
			}
			actiinfos.Sort(CompareSkillNames);
			combinfos.Sort(CompareSkillNames);
			miscinfos.Sort(CompareSkillNames);
			loreinfos.Sort(CompareSkillNames);
			custom.Sort(CompareSkillNames);

			l.Add(miscentry);
			if (showing.Contains(1))
			{
				ie = miscinfos.GetEnumerator();
				while (ie.MoveNext())
				{
					SkillSettings.DoTell2("Misc i: " + i + " Skill: " + ((Skill)ie.Current).ToString());
					addEntry(l, (Skill)ie.Current, i, 1);
					i++;
				}
			}
			else
				i += miscinfos.Count;

			l.Add( combentry );
			if (showing.Contains(2))
			{
				//i = 1;
				ie = combinfos.GetEnumerator();
				while (ie.MoveNext())
				{
					SkillSettings.DoTell2("Co i: " + i + " Skill: " + ((Skill)ie.Current).ToString());
					addEntry(l, (Skill)ie.Current, i, 2);
					i++;
				}

			}
			else
				i += combinfos.Count;

			l.Add(actientry);
			if (showing.Contains(3))
			{				
				//i = 1;
				ie = actiinfos.GetEnumerator();
				while (ie.MoveNext())
				{
					SkillSettings.DoTell2("A i: " + i + " Skill: " + ((Skill)ie.Current).ToString());
					addEntry(l, (Skill)ie.Current, i, 3);
					i++;
				}
			}
			else
				i += actiinfos.Count;

			l.Add(loreentry);
			if (showing.Contains(4))
			{
				//i = 1;
				ie = loreinfos.GetEnumerator();
				while (ie.MoveNext())
				{
					SkillSettings.DoTell2("L i: " + i + " Skill: " + ((Skill)ie.Current).ToString());
					addEntry(l, (Skill)ie.Current, i, 4);
					i++;
				}
			}
			else
				i += loreinfos.Count;

			l.Add(customentry);
			if (showing.Contains(5))
			{
				//i = 1;
				ie = custom.GetEnumerator();
				while (ie.MoveNext())
				{
					SkillSettings.DoTell2("Cu i: " + i + " Skill: " + ((Skill)ie.Current).ToString());
					addEntry(l, (Skill)ie.Current, i, 5);
					i++;
				}
			}

			l.CommitList();
		}

		private void addEntry( GumpList l, Skill sk, int i, int j )
		{
			WindowInfo info = skin.WindowInfo["SkillWindow"];
			GumpListEntry gle = new GumpListEntry(0, 0, l, info.W - 12, 18);
			int lockbuttonup = 0;
			int lockbuttondn = 0;

			switch (sk.Lock)
			{
				case SkillLock.Down:
				lockbuttonup = skin.ButtonInfo["DownButton"].up;
					lockbuttondn = skin.ButtonInfo["DownButton"].down;
					break;
				case SkillLock.Locked:
					lockbuttonup = skin.ButtonInfo["LockButton"].up;
					lockbuttondn = skin.ButtonInfo["LockButton"].down;
					break;
				case SkillLock.Up:
					lockbuttonup = skin.ButtonInfo["UpButton"].up;
					lockbuttondn = skin.ButtonInfo["UpButton"].down;
					break;
			}
			ButtonInfo select = skin.ButtonInfo["UseButton"];
			SkillSettings.DoTell2("AE i: " + i + " lock button: " +(1000+(100*j)+i));
			if( sk.Info.Callback != null )
				gle.AddColumn(new GumpButton(0, 3, select.up, select.down, 1000 + i, GumpButtonType.Reply, 0));
			else
				gle.AddColumn("");
			gle.AddColumn("   "+ sk.Name);
			gle.AddColumn(" " + (checkdouble(sk.Value) ? " " + sk.Value + ".0" : " " + sk.Value) );
			gle.AddColumn(new GumpButton(0, 3, lockbuttonup, lockbuttondn, 10000 + i, GumpButtonType.Reply, 0));
			l.Add( gle );
		}
		
		private int TranslateInt(int which)
		{
			try
			{
				if (which < miscinfos.Count)
					return ParallelSkills.NameLocs[miscinfos[which - 1].Name];
				else
					which -= miscinfos.Count;

				if (which < combinfos.Count)
					return ParallelSkills.NameLocs[combinfos[which - 1].Name];
				else
					which -= combinfos.Count;

				if (which < actiinfos.Count)
					return ParallelSkills.NameLocs[actiinfos[which - 1].Name];
				else
					which -= actiinfos.Count;

				if (which < loreinfos.Count)
					return ParallelSkills.NameLocs[loreinfos[which - 1].Name];
				else
					which -= loreinfos.Count;

				if (which < custom.Count)
					return ParallelSkills.NameLocs[custom[which - 1].Name];
				else
					which -= custom.Count;
			}
			catch (Exception e)
			{ SkillSettings.DoTell("Error when translating the location: " + e); }
			return 0;
		}
		
		public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
		{
			if( info.ButtonID == -100 )
				sender.Mobile.SendGump( new ParallelSmallSkillsGump( showing ) );
			else if ( info.ButtonID > 0 && info.ButtonID < 100 )
			{ 
				SkillSettings.DoTell("Parallel Skills Button ID is in the Section Display Section: "+info.ButtonID );
				if( !showing.Contains( info.ButtonID ) )
					showing.Add( info.ButtonID );
				else
					showing.Remove( info.ButtonID );
				sender.Mobile.SendGump( new ParallelSkillsGump( showing, Mobile ) );
			}
			else if (info.ButtonID > 1000 && info.ButtonID < 10000)
			{
				SkillSettings.DoTell("Parallel Skills Button ID is in the SkillUse Section: "+info.ButtonID );
				int which = info.ButtonID%1000;
				int trans = TranslateInt( which );
				SkillSettings.DoTell("This translates to: "+trans+" which is: "+sender.Mobile.Skills[trans].Name );
				try
				{
					Skills sk = sender.Mobile.Skills;

					Skills.UseSkill(sender.Mobile, trans );
				}
				catch (Exception e)
				{ 
					SkillSettings.DoTell( "Unable to use skill on Custom Skills Gump - Exception: "+e);
				}
				sender.Mobile.SendGump(new ParallelSkillsGump(showing, Mobile));
			}
			else if (info.ButtonID > 10000)
			{
				SkillSettings.DoTell("Parallel Skills Button ID is in the SkillLock Section: " + info.ButtonID);
				int which = info.ButtonID%10000;
				int trans = TranslateInt(which);
				SkillSettings.DoTell("This translates to: " + trans + " which is: " + sender.Mobile.Skills[trans].Name);
				try
				{
					switch (sender.Mobile.Skills[trans].Lock)
					{
						case SkillLock.Down:
							sender.Mobile.Skills[trans].SetLockNoRelay ( SkillLock.Locked );
							break;
						case SkillLock.Locked:
							sender.Mobile.Skills[trans].SetLockNoRelay(SkillLock.Up);
							break;
						case SkillLock.Up:
							sender.Mobile.Skills[trans].SetLockNoRelay(SkillLock.Down);
							break;
					}
				}
				catch (Exception e)
				{ SkillSettings.DoTell("Lock does not work. " + e); }
				
				sender.Mobile.SendGump(new ParallelSkillsGump(showing, Mobile));
			}
			else
				SkillSettings.DoTell("Unusual ButtonID: "+info.ButtonID );
		}

		public string getHelpText()
		{
			return "This gump is here to assist you with your skills.";
		}

		public string getGumpType()
		{
			return "Other";
		}

		#endregion
	}
	#endregion

	#region SkillTarget
	public class SkillTargetP : Target
	{
		private bool m_Set;
		private int m_Which;
		private double m_Value;

		public SkillTargetP( int which, double value ) : base( -1, false, TargetFlags.None )
		{
			m_Set = true;
			m_Value = value;
			m_Which = which;				
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
			if ( targeted is Mobile )
			{
				Mobile targ = (Mobile)targeted;
					
				try
				{
					targ.Skills[m_Which].Base = m_Value;
				}
				catch( Exception e )
				{
					SkillSettings.DoTell("Mobile does not have the selected skill: "+SkillInfo.Table[m_Which].Name+" Exception: "+e);
					return;
				}
				
				if ( m_Set )
				{
					//CommandLogging.LogChangeProperty( from, targ, "Skill change.", m_Value.ToString() );
				}

				from.SendMessage( "{0} : {1}", SkillInfo.Table[m_Which].Name, from.Skills[m_Which].Base );
			}
			else
			{
				from.SendMessage( "That does not have skills!" );
			}
		}
	}
#endregion

	#region AllSkills
	public class AllSkillsTargetP : Target
	{
		private double m_Value;

		public AllSkillsTargetP(double value)
			: base(-1, false, TargetFlags.None)
		{
			m_Value = value;
		}

		protected override void OnTarget(Mobile from, object targeted)
		{
			if (targeted is Mobile)
			{
				Mobile targ = (Mobile)targeted;
				Server.Skills skills = targ.Skills;

				for (int i = 0; i < skills.Length; ++i)
					skills[i].Base = m_Value;

				//CommandLogging.LogChangeProperty(from, targ, "EverySkill.Base", m_Value.ToString());
			}
			else
			{
				from.SendMessage("That does not have skills!");
			}
		}
	}
	#endregion
}