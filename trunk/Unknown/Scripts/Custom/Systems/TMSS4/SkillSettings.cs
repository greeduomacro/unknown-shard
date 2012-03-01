using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Commands;
using System.Collections;
using System.Collections.Generic;
using Server.Gumps;
using System.IO;

/*
 *THE
 *		//\\       //\\
 *      || \\	  //  ||
 *      ||  \\   //   ||
 *		||	  \ /     ||
 *		||			  ||
 *		||			  ||
 *		||			  ||
 *
 *Computer meus nefandus est. ("My Computer is the Devil.")*/

// -- TMSS 4.0 -- CORE FILES --
//author TMSTKSBK--developed for Ageless Dawn 2

namespace Server.TMSS
{
	/// <version>
	/// 4.0.0 final
	/// </version>
	/// <author>
	/// TMSTKSBK
	/// </author>
	/// <summary>
	/// General settings and some major methods for debug.
	/// </summary>	
	public class SkillSettings
	{
		#region VariableDeclarations		
//access levels
		public static AccessLevel GumpControlLevel = AccessLevel.GameMaster;
		public static AccessLevel AdminAccessLevel = AccessLevel.Administrator;		
//hues
		public static int SkillHue;
		public static int StatHue; //Necessary under new paradigm?
		public static int CenterHue;

        public static string CCProfileName;
		public static string CCSkinName;
		public static string ControlSkinName;
//Messages		
		public static string ShardName;
		public static bool IsSharded;
		public static string NotYoursMessage;
		public static string HowToUseMessage;
		public static string NoTicketMessage;
		public static string Shard;
		public static string NoShard;
		#endregion

		#region Startup Stuff
		public static void Initialize()
		{
			CommandSystem.Register("TMSS", SkillSettings.GumpControlLevel, new CommandEventHandler(TMSS_OnCommand));
			CommandSystem.Register("SessionTest", SkillSettings.GumpControlLevel, new CommandEventHandler( SkillSession_OnCommand));
			CommandSystem.Register("ListTest", SkillSettings.AdminAccessLevel, new CommandEventHandler( ListTest_OnCommand ) );
			CommandSystem.Register("SkillTest", SkillSettings.GumpControlLevel, new CommandEventHandler(SkillTest_OnCommand));
			CommandSystem.Register("MasterTest", SkillSettings.GumpControlLevel, new CommandEventHandler(MasterTest_OnCommand));
			CommandSystem.Register("tminfo", SkillSettings.AdminAccessLevel, new CommandEventHandler(Debug_OnCommand));
			CommandSystem.Register("tminfo2", SkillSettings.AdminAccessLevel, new CommandEventHandler(FullOutput_OnCommand));			
			CommandSystem.Register( "ps", SkillSettings.GumpControlLevel, new CommandEventHandler( ProfileSelect_OnCommand ) );
			CommandSystem.Register("pr", SkillSettings.GumpControlLevel, new CommandEventHandler(ProfileReload_OnCommand));
			CommandSystem.Register("ss", SkillSettings.AdminAccessLevel, new CommandEventHandler(SkinSelect_OnCommand));
			CommandSystem.Register("sr", AccessLevel.Administrator, new CommandEventHandler(LMS_OnCommand));
			CommandSystem.Register("rlskin", AccessLevel.Administrator, new CommandEventHandler(LMS_OnCommand));
			CommandSystem.Register("ssg", AccessLevel.Administrator, new CommandEventHandler(SSG_OnCommand));
			CommandSystem.Register("gds", AccessLevel.Administrator, new CommandEventHandler(GDS_OnCommand));
			EventSink_WorldLoad();
		}
		public static BaseSkin GenerateDefaultSkin(string name)
		{
			TMSS4Skin sk = new TMSS4Skin();
			sk.SkinName = name;
			SkinHelper.WriteSkin(sk);
			SkillSkin skin = new SkillSkin( "Skill Skin" );
			SkinHelper.WriteSkin( skin );
			return sk;
		}

		#region Commands
		[Usage("[TMSS")]
		[Description("Opens the control center for TMSS from anywhere.")]
		public static void TMSS_OnCommand( CommandEventArgs e )
		{
			Dictionary<string, object> args = new Dictionary<string, object>();
			args.Add("Skin", SkinHelper.getSkin(SkillSettings.ControlSkinName));
			args.Add("Mobile", e.Mobile);
			e.Mobile.SendGump(new TMQueryPage("Main Menu", args ));
		}
		[Usage("[sgump")]
		[Description("Opens the special skill gump.")]
		public static void SSG_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump( new ParallelSkillsGump( e.Mobile ) );
		}
		[Usage("[pr")]
		[Description("Reloads TMSS 4 Skill Profiles.")]
		public static void ProfileReload_OnCommand(CommandEventArgs e)
		{ 
			SkillProfileHelper.SkillProfileInitializer();
		}
		[Usage("[SkillSession")]
		[Description("Creates a new Skill Session.")]
		public static void SkillSession_OnCommand(CommandEventArgs e)
		{
			BaseTMSkillItem item = new BaseTMSkillItem( 0xedd );
			item.Profile = (SuperSkillProfile)SkillProfileHelper.getProfile("defaultInternal");
			item.Skin = CCSkinName;
			TMSkillSession session = new TMSkillSession( e.Mobile, item );
			session.Start();
		}
		[Usage("[ps")]
		[Description("Opens the TMSS 4 Profile Selection gump.")]
		public static void ProfileSelect_OnCommand(CommandEventArgs e)
		{
			if (QueryPageHelper.PluginExists("TMProfile"))
			{ 
				SkillSettings.DoTell("Inside existing section.");
				Dictionary< string, object > args = new Dictionary<string,object>();
				args.Add( "Skin", SkinHelper.getSkin( SkillSettings.CCSkinName ) );
				args.Add( "Mobile", e.Mobile );
				TMQueryPage page = new TMQueryPage("TMSS Profile Selector", args);
				//e.Mobile.SendGump( page );
				SkillSettings.DoTell("Gump sent.");
			}
			else
				SkillSettings.DoTell("Plugin does not exist.");
		}
		[Usage("[ps")]
		[Description("Opens the TMSS 4 Profile Selection gump.")]
		public static void SkinSelect_OnCommand(CommandEventArgs e)
		{
			if (QueryPageHelper.PluginExists("TMSkinPage"))
			{
				SkillSettings.DoTell("Inside existing section.");
				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("Skin", SkinHelper.getSkin(SkillSettings.CCSkinName));
				args.Add("Mobile", e.Mobile);
				TMQueryPage page = new TMQueryPage("TMSS Skin Selector", args);
				//e.Mobile.SendGump( page );
				SkillSettings.DoTell("Gump sent.");
			}
			else
				SkillSettings.DoTell("Plugin does not exist.");
		}
		[Usage("[tminfo")]
		[Description("Toggles Debug Mode on and off.")]
		public static void FullOutput_OnCommand(CommandEventArgs e)
		{
			DebugMode = !DebugMode;
		}
		[Usage("[tminfo2")]
		[Description("Toggles Debug Mode 2 on and off.")]
		public static void Debug_OnCommand(CommandEventArgs e)
		{
			DebugMode2 = !DebugMode2;
		}
		[Usage("[ListTest")]
		[Description("Shows the list test gump.")]
		public static void ListTest_OnCommand(CommandEventArgs e)
		{
			ListTestGump g = new ListTestGump();
			e.Mobile.SendGump(g);
		}
		[Usage("[SessionTest")]
		[Description("Shows the master gump with a default profile.")]
		public static void SessionTest_OnCommand(CommandEventArgs e)
		{
			if (QueryPageHelper.PluginExists("TMMaster"))
			{
				BaseTMSkillItem item = new BaseTMSkillItem( 1001 );
				item.Profile = (SuperSkillProfile)SkillProfileHelper.getProfile(SkillSettings.CCProfileName);
				item.Skin = CCSkinName;
				TMSkillSession Session = new TMSkillSession( e.Mobile, item );
			}
		}
		internal static TMSkillSession SessionGenerate(CommandEventArgs e)
		{
			BaseTMSkillItem item = new BaseTMSkillItem(1001);
			item.Profile = (SuperSkillProfile)SkillProfileHelper.getProfile(SkillSettings.CCProfileName);
			item.Skin = CCSkinName;
			TMSkillSession Session = new TMSkillSession(e.Mobile, item);
			return Session;
		}
		[Usage("[MasterTest")]
		[Description("Shows the master gump with a default profile.")]
		public static void MasterTest_OnCommand(CommandEventArgs e)
		{
			if (QueryPageHelper.PluginExists("TMMaster"))
			{
				TMSkillSession s = SessionGenerate(e);
				TMQueryPage page = new TMQueryPage("TMSS Session Master Gump", s); 
				//e.Mobile.SendGump( page );
			}
		}
		[Usage("[SkillTest")]
		[Description("Shows the TMSkill gump.")]
		public static void SkillTest_OnCommand(CommandEventArgs e)
		{
			//ListTestGump g = new ListTestGump();
			if (QueryPageHelper.PluginExists("TMSkill"))
			{
				Dictionary<string, object> t = new Dictionary<string, object>();
				t.Add("Skin", SkinHelper.getSkin(SkillSettings.ControlSkinName));
				t.Add("Mobile", e.Mobile);
				SuperSkillProfile p = (SuperSkillProfile)SkillProfileHelper.getProfile("Default Profile");
				SkillProfile sp = p.getProfile(0);
				t.Add("Profile", sp);
				TMQueryPage pg = new TMQueryPage("TMSS Skill Gump", t);
				//e.Mobile.SendGump(pg);
			}
			else
			{
				DoTell("Error when creating Skill Gump. Plugin does not exist.");
				return;
			}
			
		}
		[Usage("[rlskin or [rlskin *name*")]
		[Description("Reloads all skins.")]
		public static void LMS_OnCommand(CommandEventArgs e)
		{
			string which = "";
			if (e.Arguments.Length > 0)
			{
				try { which = e.Arguments[0]; }
				catch (Exception ex)
				{ Console.WriteLine("Invalid arguments. " + ex); }
			}
			if (which != "")
			{
				try { SkinHelper.LoadSkin(which, typeof(TMSS4Skin), true); }
				catch (Exception ex) { Console.WriteLine("Invalid skin name argument: " + ex); }
			}
			else
			{
				try
				{
					DirectoryInfo di = new DirectoryInfo("TMSS/Data/Skins");
					foreach (FileInfo f in di.GetFiles())
					{
						if (f.Extension == ".tskn")
						{
							string skname = f.Name.Remove(f.Name.IndexOf(".tskn"), 5);
							try
							{
								BaseSkin sk = SkinHelper.skList[ skname ];
								try
								{
									TMSS4Skin skfour = (TMSS4Skin)sk;
									SkinHelper.LoadSkin(skname, typeof(TMSS4Skin), true);
								}
								catch
								{
									SkillSkin skskill = (SkillSkin)sk;
									SkinHelper.LoadSkin(skname, typeof(SkillSkin), true);
								}
								finally 
								{
									DoTell("Attempted reload of skin. Filename: "+f.FullName );
								}
							}
							catch 
							{ DoTell("Unable to load skin: "+skname+". Please use the function provided by the creating class to load it." ); }							
						}
					}
				}
				catch (Exception ex)
				{
					SystemWrite("Error when reloading a skin. "+ex);
				}
			}
			//LoadSkin(SkillSettings.CCSkinName, true);
		}
		[Usage("[gds")]
		[Description("Saves default skins to disk.")]
		public static void GDS_OnCommand(CommandEventArgs e)
		{
			TMSS4Skin sk = new TMSS4Skin();
			SkinHelper.WriteSkin( sk );
		}
		#endregion

		#region World Load Stuff
		public static bool HasRun;
		private static void EventSink_WorldLoad( )
		{
			HasRun = false;
			bool didLoad = SaveSettings.LoadSkillSettings();
			if( !HasRun )
			{
				RunOnce();
				ConsoleColor col = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(" - //|4|// - TMSS|4 Ran for the first time successfully!");
				Console.WriteLine(" - |\\Thank you for choosing TMSTKSBK's Skill/Stat System Version 4.0!/| -");
				Console.WriteLine( "" );
				Console.ForegroundColor = col;
				//SkinHelper.LoadSkin(CCSkinName);
				//SkillSaver.SaveSkillSettings();
			}
			else if( didLoad )
			{
				ConsoleColor col = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				SkinHelper.LoadSkin(CCSkinName, typeof(TMSS4Skin), true);
				Console.WriteLine(" - //4// - Skill Settings loaded successfully.");
				Console.ForegroundColor = col;
				Console.WriteLine("");
			}
			else if( !didLoad )
			{
				ConsoleColor col = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(" - //4// - Skill Settings load failed. Executing RunOnce Crash Protection.");
				Console.WriteLine(" - //4// - This is a Level 1 error. Please report it, along with the settings that were in place.");
				HasRun = false;
				RunOnce();
				Console.WriteLine( "" );				
				Console.WriteLine( " - //4// - Emergency Re-Run methods called.");
				Console.ForegroundColor = col;

				SaveSettings.SaveSkillSettings();
				//SkinHelper.LoadSkin(CCSkinName,typeof(TMSS4Skin), true);
			}
		}
		#endregion

		#endregion
		
		#region RunOnce
		//This is a major method that runs *gasp!* once, during the first compile of TMSS 4.0
		public static void RunOnce()
		{
			Console.WriteLine(" - //4// - Beginning Setup.");
			if( !HasRun )
			{
				#region Gumps
				GumpControlLevel = AccessLevel.GameMaster;
				AdminAccessLevel = AccessLevel.Administrator;
				#endregion

				#region Hues
			
				//*************************************
				//Hue Settings:------------------------
				//*************************************

				//This sets the color for all basic TM Skill System items.
				//Default: 0x60 (light blue)
				SkillHue = 0x60;
	
				//This sets the color for all Stat-related special TM SkillSystem items
				//default: 0x483 (green tailor BOD color)
				StatHue = 0x483;
			
				//This sets the color for the CenterStone item.
				//Default: 1153 (white)
				CenterHue = 1153;
			
				//END hue settings *******************
		
				#endregion

				#region CC
				
				//******************************************
                //Don't change this. This is the "safe" name.
                CCProfileName = "Default Profile";
				CCSkinName = "Unnamed Skin";
				ControlSkinName = "Unnamed Skin";
				//******End Central Control Settings****************//		
				#endregion
		
				#region Messages
		
				//***********************************
				//Message Settings===================
				//***********************************
				//This is your shard's name
				//default: ????
				//******************************************************
				//IF YOU SET THIS, YOU MUST ALSO SET ITS BOOL TO TRUE!!!
				//******************************************************
				try
				{
					ShardName = Server.Misc.ServerList.ServerName;
				}
				catch (Exception e)
				{
					ShardName = "TMSS //4// Enabled Shard!";
					SkillSettings.DoTell(" Problem getting Shard Name: "+e );
				}
				//The bool that prints your shard.
				//default: false
				IsSharded = false;
		
		
				//This message is sent to a user that attempts to use a skillticket that is not theirs.
				//default: "This is not your ticket. Shame on you! You have to use your ticket."
				NotYoursMessage = "This is not your ticket. Shame on you! You have to use your ticket.";
		
				//This message is sent to an owner that double-clicks their ticket.
				//default: "This is a Skill Ticket. Use a Skill Stone to get your skills."
				HowToUseMessage = "This is a Skill Ticket. Use a Skill Stone to get your skills.";

				//This message is sent to a user that doesn't have a skillticket on a skillstone use attempt.
				//default: "You need a Skill Ticket to use that."
				NoTicketMessage = "You need a Skill or Cap Ticket to use that.";
				//These are the messages for Shard and NoShard above.
				Shard = "Welcome to " + ShardName + ". This will help you set your skills.";
				NoShard = "Welcome. This ticket will help you set your skills.";

				//END newbie message settings *********
		
				#endregion		

				#region Finalization
				SkillProfileHelper.GenInitialProfile();
				GenerateDefaultSkin(CCSkinName);
				SkinHelper.LoadSkin(CCSkinName, typeof(TMSS4Skin), true);
				SkinHelper.LoadSkin("Skill Skin", typeof( SkillSkin ), true );
				HasRun = true;
				SaveSettings.SaveSkillSettings();
				#endregion
			}
			else 
				return;		
		}
		
		#endregion

		#region Debug
		//******************************
		//Debug Settings================
		//******************************
		
		//Leave false unless system is undergoing testing by shard admins.
		public static bool DebugMode = false;

		//don't mess with these. It gives some really specific error info that you need to fully understand the system to "get"
		public static bool DebugMode1 = false;
		public static bool DebugMode2 = false;

		//This is a function to help with debug code. It's not here, you don't see it.
		/// <summary>
		/// DoTell provides print debugging for TMSS 4. 
		/// It runs when the TMSS 4 "SkillSettings.DebugMode" variable is true, and when the "Server.Core.DebugMode" variable is true.
		/// All text passed through this function is prefixed with " - //4// - " to identify it as from TMSS 4.
		/// </summary>
		/// <param name="tell">The string to print without prefix.</param>
		public static void DoTell( string tell )
		{
			if( SkillSettings.DebugMode || Server.Core.Debug )
			{
				SystemWrite( " - //4// - "+tell );
				//Console.WriteLine(" - //4// - " + tell);				
			}
		}

		//This is a low-level debug function.
		/// <summary>
		/// Performs the same duty as DoTell, but is used when DebugMode2 is true.
		/// Typically, the output piped here is detailed information about gump layouts and such.
		/// Text piped to this method is prefixed with " - //4// - LEVEL 2 - " to identify it as being low-level debug.
		/// </summary>
		/// <param name="tell">The string to write.</param>
		public static void DoTell2(string tell)
		{
			if (SkillSettings.DebugMode2 && (DebugMode || Server.Core.Debug) )
			{
				SystemWrite(" - //4// - LEVEL 2 - " + tell);
			}			
		}

		//If you REALLY don't want to see stuff from TMSS 4, comment out the write here.
		/// <summary>
		/// This function is called when either of the DoTells are called, or when something needs to be written directly to the console.
		/// </summary>
		/// <param name="p">The string to be written to the console.</param>
		public static void SystemWrite(string p)
		{
			Console.WriteLine(p);
		}

		public static string SkillPhrase = "Do you not know who I AM? I'm the Juggernaut!";
		#endregion
	}	
	#region credits & contact
/* * Credits:
 *    CCCC  RRRR	EEEEEE	DDDDD	IIIII	TTTTTTTTTTT	 SSSSSS
 *  C	  C	R	R	E		D	 D	  I		  	 T		S	   S
 * C		R    R	E		D	  D	  I			 T		S
 * C		RR	R	EEEE	D	  D	  I			 T		 SSSSSS
 * C		R  R	E		D	  D	  I			 T			   S 	
 *  C	 C	R	R	E		D	 D	  I			 T		S	   S
 *	 CCCC	R	 R	EEEEEE	DDDDD	IIIII		 T		 SSSSSS		
 * stfu...my first ASCII art attempt...
 * Official Website: www.csquarenet.net/tmss
 * Official Shard: none, atm...
 *
 * I would like to thank the following people:
 * 
 * 
 * For help and support on v3.0 (in chronological order of help):
 * 
 * orpheus -- suggesting an improvement to the SkillGumps.
 * Erica -- finding several bugs in my implementations.
 * Phantom -- bounce-idea-off-er.
 * TheOutkastDev -- helping me with my compiler get-around.
 * A_Li_N -- Helping me with my SkillProfiles.
 * Elentari Onodrim -- The key to the easter egg.
 * 
 * 
 * For help and support on v2.1:
 * 
 * Fainne Roisin -- Letting me use her power adapter. ;-) 
 * A_Li_N -- Helping me figure out arrays :P (I feel stupid).
 * Phantom -- Letting me cannibalize the GSMain.cs from Giga Spawner for the save system.
 *
 * 
 * For help and support on v2.0:
 * 
 * daat99 -- input and technical stuff.
 * ArteGordon -- technical stuff.
 * Khaz -- for input and support.
 * M. King -- input & inspiration for some of the options.
 *
 * 
 * For help and support on v1.0:
 * 
 * sirensong -- technical stuff.
 * jjarmis -- technical stuff.
 *
 * 
 * v's 1, 2 & 3: 
 * Kokushibyou -- input, critiquing, mental support.
 * 
 * Contact Info for bugs:
 * MANY options:
 * PM me on RunUO.com/forums (preferred)
 * PM me on CSquareNet.net/forum 
 * or
 * Post in the TMSS 4.0 Thread on RunUO
 * Post in the TMSS 4.0 Thread on CSquareNet
 * or
 * e-mail me at:
 * tmstksbk@gmail.com or tmstksbk@tmstksbk.com
 */

#endregion
}
