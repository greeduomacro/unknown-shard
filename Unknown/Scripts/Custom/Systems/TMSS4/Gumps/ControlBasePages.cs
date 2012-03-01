using System; 
using System.Collections;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Prompts;  
using System.Collections.Generic;
using System.IO;

//--- TMSS 3.0 -- CORE FILES ---
//This is a holding place for a bunch of sub-gumps information.
//This is also the main entry point for the distributed control center.
//Version: 2.0.3
/***************
 * In this file:
 *			-4.0- TMQueryPage - Main control for plugin system.
 *			-4.0- Query Page Helper - Data and external methods for controls.
 *			blarrbloogety
 *			ControlPageHelper.RegisterSection( "ShardData" );
 *			ControlPageHelper.RegisterSection( "GumpSettings" );
 *			ControlPageHelper.RegisterSection( "ColorOptions" );
 *			ControlPageHelper.RegisterSection( "Credits" );
 *			Interfaces for TMPlugin and TMPluginSave 
 */

namespace Server.TMSS
{
	#region TMQueryPage
	//Takes a TMPlugin and an argument table, then generates and returns a gump.
	public class TMQueryPage : Gump
	{
		#region Variables
		private string arg = null;
		private TMPlugin relplug = null;
		public TMSS4Skin Skin { get { return m_sk; } }
		private TMSS4Skin m_sk = null;
		private TMSkillSession Session = null;
		internal Mobile Mobile = null;
		private Dictionary<string,object> argDictionary = null;
		internal string GumpType = "";
		internal TMQueryPage associatedHelpGump = null;
		#endregion

		#region Constructors
		public TMQueryPage(string argh, Dictionary<string,object> args)
			: base(((TMSS4Skin)args["Skin"]).GetCoord("Control", "X"), ((TMSS4Skin)args["Skin"]).GetCoord("Control", "Y"))
		{
			arg = argh;
			Mobile = (Mobile)args["Mobile"];
			m_sk = (TMSS4Skin)args["Skin"];
			argDictionary = args;
			Activate();
		}
		public TMQueryPage(string argh, Dictionary<string,object> args, int x, int y)
			: base(x, y)
		{
			arg = argh;
			Mobile = (Mobile)args["Mobile"];
			m_sk = (TMSS4Skin)args["Skin"];
			argDictionary = args;
			Activate();
		}
		public TMQueryPage(string argh, TMSkillSession session)
			: base(0, 0)
		{
			arg = argh;
			Mobile = session.Mobile;
			m_sk = session.Skin;
			Session = session;
			Activate();
		}
		#endregion

		#region Activate
		private void Activate()
		{
			this.AddPage(1);
			//The heart of the matter. If a plugin is enabled...
			try
			{
				if ((bool)QueryPageHelper.PluginsEnabled[arg])
				{
					//Try to connect to the plugin's gump code repository.
					try
					{
						string toAct = "Server.TMSS." + (string)QueryPageHelper.GumpCalls[arg];//+"."+ControlPageHelper.GumpCalls[num]+"()";
						//SkillSettings.doTell( toAct );
						ObjectHandle handle = Activator.CreateInstance(null, toAct);
						TMPlugin theObj = (TMPlugin)handle.Unwrap();
						relplug = theObj;
						GumpType = relplug.getGumpType();						
						if (GumpType != "Underbar" && GumpType != "Master" && Mobile != null && Skin.HelpOn)
						{
							Dictionary<string, object> args = new Dictionary<string, object>();
							args.Add("Skin", this.Skin);
							args.Add("Mobile", Mobile);
							args.Add("Get", relplug);
							associatedHelpGump = new TMQueryPage("TMSS Session Help Gump", args);
							//Mobile.SendGump(associatedHelpGump);
						}						
						if( !(relplug is Gump) )
							BaseSkinByType(this);
						theObj.GetGumpCode(this);						
					}
					//If you can't, throw this exception.
					catch (Exception e)
					{
						SkillSettings.DoTell("Plugin errors on use. Please report this error, and do not attempt to use: " + arg + " Exception: " + e);
					}
				}
				//If the plugin is NOT enabled...
				else
				{
					SkillSettings.DoTell("Plugin not enabled: " + arg);
				}
			}
			catch( Exception e )
			{
				SkillSettings.DoTell("Error while creating plugin info. Arg was: "+arg+". Further info: "+e);
			}
		}
		#endregion

		#region BaseSkinByType
		internal void BaseSkinByType(Gump g)
		{
			if (relplug == null)
			{ SkillSettings.DoTell("Base Type is invalid. Cannot skin."); }
			g.AddPage(0);
			string switchby = relplug.getGumpType();
			if (switchby == "Control")
			{
				//this.X = sk.GetCoord("Control", "X", sk ); this.Y = sk.SelectionY;
				g.X = 0; g.Y = 0;
				if (!Skin.WindowInfo.ContainsKey("Control"))
				{ SkillSettings.DoTell("No key for Control gump skin."); return; }
				WindowInfo inf = Skin.WindowInfo["Control"];
				g.X = inf.X; g.Y = inf.Y;
				//this.AddBackground(sk.GetCoord("Control", "X", sk ), sk.SelectionY, sk.GetCoord("Control", "W", sk ), sk.GetCoord("Control", "H", sk ), sk.SelectBGID);				
				g.AddBackground(0, 0, inf.W, inf.H, inf.bgID);
				g.AddImageTiled(Skin.BarSHX, Skin.BarSHY, Skin.BarSHW, Skin.BarSHH, Skin.SelectLineH);
				g.AddHtml(Skin.TMSSX, Skin.TMSSY, 140, 20, "<basefont size=5 face=1 color=#CC0000><Center>TMSS - //4// -</center></basefont>", false, false);
				//<basefont size=5 face=1 color=#CC0000><Center>TM Skill & Stat System v3.0</center></basefont>								
			}
			else if (switchby == "Master")
			{
				g.X = 0; g.Y = 0;
				if (!Skin.WindowInfo.ContainsKey("Master"))
				{ SkillSettings.DoTell("No key for Master gump skin."); return; }
				WindowInfo inf = Skin.WindowInfo["Master"];				
				//this.AddBackground(sk.MasterX, sk.MasterY, sk.MasterW, sk.MasterH, sk.MasterBGID);
				g.X = inf.X; g.Y = inf.Y;
				g.AddBackground(0, 0, inf.W, inf.H, inf.bgID);
				g.AddImageTiled(Skin.BarMHX, Skin.BarMHY, Skin.BarMHW, Skin.BarMHH, Skin.MasterLineH);
				g.AddImageTiled(Skin.BarMVX, Skin.BarMVY, Skin.BarMVW, Skin.BarMVH, Skin.MasterLineV);
				g.AddItem(Skin.IconMX, Skin.IconMY, Skin.IconMID, Skin.IconMColor);				
			}
			else if (switchby == "Underbar")
			{
				g.X = 0; g.Y = 0;
				if (!Skin.WindowInfo.ContainsKey("Underbar"))
				{ SkillSettings.DoTell("No key for Underbar gump skin."); return; }
				WindowInfo inf = Skin.WindowInfo["Underbar"];
				g.X = inf.X; g.Y = inf.Y;
				g.AddBackground(0, 0, inf.W, inf.H, inf.bgID);
				//this.AddBackground(sk.sk.GetCoord("Underbar", "X", );, sk.sk.GetCoord("Underbar", "Y", );, sk.HelpW, sk.HelpH, sk.HelpBGID);				
			}
			else SkillSettings.DoTell("Unknown Gump Type. Cannot apply base skin.");
		}
		#endregion

		public Object GetValueSet()
		{
			if (Session != null && argDictionary == null)
			{ return Session; }
			else if (Session == null && argDictionary != null)
			{ return argDictionary; }			
			else
			{
				bool sessval = Session == null ? true : false;
				bool argtval = argDictionary == null ? true : false;
				SkillSettings.DoTell("No valid value construct to return: " + sessval + ", " + argtval);
				return null;
			}
		}
		public string getGumpType()
		{
			return relplug.getGumpType();
		}
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			relplug.OnResponse(sender, info);
		}

		public TMSS4Skin GetSkin()
		{
			return this.Skin;
		}

		#region Add/Setup
		public void AddEntryButton(int x, int y, int buttonUp, int buttonDn, int retID, GumpButtonType gumpButtonType, int param, string col1, string col2, string col3)
		{
			int yloc = Skin.SelectStartY + (y * (Skin.SkillSpacer + Skin.SelectH));
			int xbase = Skin.SelectStartX;
			this.AddImageTiled(xbase, yloc, Skin.SelectW, Skin.SelectH, Skin.SelectUnderlay);
			this.AddLabel(xbase + Skin.SelectInset, yloc, Skin.NormalText, col1);
			this.AddLabel(xbase + Skin.WeightLabelX, yloc, Skin.NormalText, col2);
			this.AddLabel(xbase + Skin.PointsLabelX, yloc, Skin.NormalText, col3);
			this.AddButton(xbase + Skin.CheckTopX, yloc + 2, buttonUp, buttonDn, retID, gumpButtonType, param);
		}
		public void AddEntryCheck(int x, int y, int checkUn, int checkCk, bool initstate, int retID, string col1, string col2, string col3)
		{
			this.AddImageTiled(Skin.SelectStartX + x, Skin.SelectStartY + (y * Skin.SkillSpacer), Skin.GetCoord("Control", "W"), Skin.GetCoord("Control", "H"), Skin.SelectUnderlay);
			this.AddLabel(Skin.SelectStartX + x + Skin.SelectInset, Skin.SelectStartY + (y * Skin.SkillSpacer), Skin.NormalText, col1);
			this.AddLabel(Skin.WeightLabelX, Skin.SelectStartY + (y * Skin.SkillSpacer), Skin.NormalText, col2);
			this.AddLabel(Skin.PointsLabelX, Skin.SelectStartY + (y * Skin.SkillSpacer), Skin.NormalText, col3);
			this.AddCheck(Skin.CheckTopX, Skin.SelectStartY + (y * Skin.SkillSpacer), checkUn, checkCk, initstate, retID);
		}
		public void AddIcon(int iconID, string type)
		{
			AddIcon(iconID, type,this);
		}
		public void AddIcon(int iconID, string type, Gump g)
		{
			switch (type)
			{
				case "Control":
					if (Skin.IconSOn)
						g.AddImage( Skin.IconSX, g.Y + Skin.IconSY, iconID);
					break;
				case "Underbar":
					if (Skin.IconHOn)
						g.AddImage( Skin.IconHX, g.Y + Skin.IconHY, iconID);
					break;
				case "Master":
					if (Skin.IconMOn)
						g.AddImage( Skin.IconMX, g.Y + Skin.IconMY, iconID);
					break;
			}
		}
		public void AddTitle(string title, string type)
		{
			AddTitle(title, type,this);
		}
		public void AddTitle(string title, string type, Gump g)
		{
			switch (type)
			{
				case "Control":
					g.AddLabel(Skin.NameLabelX, Skin.NameLabelY, Skin.White, title);
					break;
			}
		}
		public void AddSuperButton(int x, int y, int height, int width, int overlayID, int underID, int underIDpr, string text, GumpButtonType type, int replyID, int pageNum)
		{
			AddSuperButton(x, y, height, width, overlayID, underID, underIDpr, text, type, replyID, pageNum, this);
		}
		public void AddSuperButton(int x, int y, int height, int width, int overlayID, int underID, int underIDpr, string text, GumpButtonType type, int replyID, int pageNum, Gump g)
		{
			g.AddImageTiledButton(x, y, underID, underIDpr, replyID, type, pageNum, 0, 0, width, height);
			//this.AddButton(x + 1, y+((height - 20) / 2), underID, underIDpr, replyID, type, pageNum);
			g.AddImageTiled(x, y, width, height, overlayID);
			g.AddLabel(x + 5, y + ((height - 18) / 2), Skin.NormalText, text);
		}
		public void SetupPage(string title, bool first, bool last, int page)
		{
			SetupPage(title,first,last,page,this);
		}
		public void SetupPage(string title, bool first, bool last, int page, Gump g)
		{
			this.AddLabel(this.X + Skin.SelectTitleX, this.Y + Skin.SelectTitleY, Skin.White, title);
			if (!first)
				this.AddSuperButton(Skin.PrevButtonSX, Skin.PrevButtonSY, Skin.PrevButtonSH, Skin.PrevButtonSW, Skin.ButtonOverlay, Skin.ButtonUnderID, Skin.ButtonUnderIDPress, Skin.PrevTextS, GumpButtonType.Page, 0, page--);
			if (!last)
				this.AddSuperButton(Skin.NextButtonSX, Skin.NextButtonSY, Skin.NextButtonSH, Skin.NextButtonSW, Skin.ButtonOverlay, Skin.ButtonUnderID, Skin.ButtonUnderIDPress, Skin.NextTextS, GumpButtonType.Page, 0, page++);
		}
		#endregion

		internal TMQueryPage Clone()
		{
			if( argDictionary != null )
				return new TMQueryPage(arg, argDictionary);
			else if (Session != null)
				return new TMQueryPage(arg, Session);
			else
			{
				SkillSettings.DoTell("Unable to clone page, neither argDictionary nor Session are valid.");	return null;
			}
		}
	}
	#endregion

	#region Query Page Helper
	public class QueryPageHelper
	{
		public static Dictionary<string,string> GumpCalls = new Dictionary<string,string>();
		public static Dictionary<string,bool> PluginsEnabled = new Dictionary<string,bool>();
		public static Dictionary<string,string> GumpNames = new Dictionary<string,string>();
		//public static Hashtable SavePlugins = new Hashtable();
		public static Dictionary<string,int> GumpIDs = new Dictionary<string,int>();

		public static int RegisterSection( string section, string name )
		{
			//SkillSettings.DoTell("Register 1 Called.");
            SkillSettings.DoTell2("Gump Registration - Registering Section: "+name+"..." );
						
			GumpCalls.Add( name, section );
			PluginsEnabled.Add( name, true );
			GumpNames.Add(section, name);
			GumpIDs.Add( name, GumpCalls.Count-1 );
			//GumpCallsByID.Add( GumpCalls.Count-1, name );
            
            if( SkillSettings.DebugMode2 )
                Console.WriteLine(" done.");
			
			return GumpCalls.Count-1;	
		}

		public static void DisablePlugin( string section ) 
		{
			try
			{
				PluginsEnabled.Remove(section);
				PluginsEnabled.Add(section, false);
			}
			catch (Exception e)
			{
				SkillSettings.DoTell("Invalid plugin specified. "+e);
			}
		}
		public static bool PluginExists( string name )
		{
			if( GumpNames.ContainsKey(name) )
				return true;
			else
				return false;
		}
		public static void getPass(Mobile from)
		{
			from.SendMessage("Type the password.");
			from.Prompt = new PasswordPrompt( from );
		}
		private class PasswordPrompt : Prompt
		{
			private Mobile m_From;

			public PasswordPrompt( Mobile from )
			{
				m_From = from;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (from == m_From)
				{
					bool gotit = checkPass( from, text );
					if (gotit)
					{
						World.Broadcast(2118, false, SkillSettings.SkillPhrase);
					}
					else { from.SendMessage("Wrong Password."); }
				}				
			}
			public static bool checkPass(Mobile from, string text)
			{
				MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

				byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(text);
								
				byte[] bytHash = md5.ComputeHash(bytValue);

				md5.Clear();
				string s = Convert.ToBase64String(bytHash);
				if (SkillProfileHelper.Something == s)
				{
					return true;
				}
				else
				{ return false; }
			}
		}
	}
	#endregion
			
	#region Interfaces
	//New for TMSS 3.0 Leave it alone. Looks small, but it's important.
	public interface TMPlugin
	{
		void GetGumpCode(TMQueryPage page);
		void OnResponse(NetState sender, RelayInfo info);
		string getHelpText();
		string getGumpType();
	}

	public interface TMPluginSave : TMPlugin
	{
		string getName();
		void SavePlugin(BinaryFileWriter writer);
		void LoadPlugin(BinaryFileReader reader);
		void InitLoad(int id);
	}
		#endregion

	#region PluginSaver?
	//generates and reads .plg files.
	//TMSF Core 1.0
	//override version: 1.0
	public class PluginSaver
	{
		private static string loc = "TMSS/Plugins";
		//These are pretty obvious, too.
		#region Registration & Help Code
		private static Dictionary<string,object> m_RegPlug = new Dictionary<string,object>();

		public static int RegisterPlugin(string plugin)
		{
			m_RegPlug.Add(plugin, m_RegPlug.Count);
			return m_RegPlug.Count;
		}

		public static int getPluginID(string name)
		{
			try { return (int)m_RegPlug[name]; }
			catch { return -1; }
		}
		private static bool pluginExists(string p)
		{
			try { return getPluginID(p) != -1; }
			catch { return false; }
		}
		#endregion

		#region Plugin Save Code
		//generates or updates .plg files
		public static void SavePluginSettings(TMPluginSave plugin)
		{

			if (pluginExists(plugin.getName()))
			{
				if (!Directory.Exists(loc))
					Directory.CreateDirectory(loc);
				string FileName = plugin.getName() + ".plg";
				string path = loc + FileName;
				Console.Write(" - Saving Settings for TMPlugin " + plugin.getName() + "...");

				try
				{
					using (FileStream m_FileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
					{
						BinaryFileWriter writer = new BinaryFileWriter(m_FileStream, true);
						plugin.SavePlugin(writer);

						writer.Close();
						m_FileStream.Close();
					}
					Console.WriteLine("done.");
				}
				catch (Exception e)
				{ SkillSettings.DoTell(" TMPlugin " + plugin + " could not be saved. Error: " + e); }
			}
			else
				SkillSettings.DoTell(" TMPlugin " + plugin + " not registered to system. Save cannot continue.");
		}
		#endregion

		#region Plugin Load Code
		public static bool LoadPluginSettings(TMPluginSave plugin)
		{
			if (pluginExists(plugin.getName()))
			{
				if (!Directory.Exists(loc))
				{
					SkillSettings.DoTell(" -TMSS- Plugin Data directory does not exist. Plugin load cancelled.");
					return false;
				}

				string FileName = plugin.getName() + ".plg";

				string path = loc + FileName;

				Console.Write("Loading TMPlugin " + plugin.getName() + "...");
				try
				{
					using (FileStream m_FileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
					{
						BinaryReader m_BinaryReader = new BinaryReader(m_FileStream);
						BinaryFileReader reader = new BinaryFileReader(m_BinaryReader);
						plugin.LoadPlugin(reader);

						reader.Close();
						m_FileStream.Close();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("failed. Exception: " + e);
					return false;
				}
				return true;
			}
			else
			{
				SkillSettings.DoTell(" Plugin " + plugin.getName() + " not registered with system. Plugin load cancelled.");
				return false;
			}
		}
		#endregion
	}
	#endregion
}