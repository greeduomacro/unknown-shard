using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.TMSS
{
	#region Main Menu
	public class MainTMSSMenu : TMPlugin
	{
		public static int internalvalue = -1;
		public static TMSS4Skin sk;
		public static void Initialize()
		{
			internalvalue = QueryPageHelper.RegisterSection("MainTMSSMenu", "Main Menu");
		}
		public MainTMSSMenu() { sk = (TMSS4Skin)SkinHelper.getSkin(SkillSettings.CCSkinName); }
		public void GetGumpCode(TMQueryPage page)
		{
			//page.AddTitle(@"Main Menu:", "Control");
			page.AddIcon(2245, "Control");
			IEnumerator enu = QueryPageHelper.GumpNames.GetEnumerator();//list.GetEnumerator();
			//IEnumerator enu = enu1.GetEnumerator();
			ArrayList sortList = new ArrayList();
			while (enu.MoveNext())
			{
				string current = (string)((KeyValuePair<string, string>)enu.Current).Value;
				sortList.Add(current);
			}
			sortList.Sort(new AlphaCompare());
			enu = sortList.GetEnumerator();
			int pageNum = 0;
			int i = 0;
			while (enu.MoveNext())
			{
				SkillSettings.DoTell2("" + enu.Current);
				string current = (string)enu.Current;
				if (current != "Main Menu" && !current.Contains("TMSS"))//Removes the Main Menu and the SkillStat gumps from the list.
				{
					if (i % 8 == 0) //if it's at 10, stop. Counts 1-10. (Same as 0-9)
					{
						pageNum++;
						page.AddPage(pageNum);
						page.SetupPage(@"Main Menu: ", (i == 0), (sortList.Count - (pageNum * 10)) <= 8 ? true : false, pageNum);
					}
					//string pluginName = (string)QueryPageHelper.GumpCalls[current];
					int pluginID = -1;
					try
					{
						pluginID = (int)QueryPageHelper.GumpIDs[current] + 1;
					}
					catch (Exception e) { SkillSettings.DoTell("BLAH! " + e); }
					SkillSettings.DoTell2("Current Plugin: " + current);
					page.AddEntryButton(0, i, sk.genericSelectUp, sk.genericSelectDn, pluginID, GumpButtonType.Reply, 0, current, "", "");
					i++;
				}
			}
		}

		public void OnResponse(NetState sender, RelayInfo info)
		{
			#region AccessLevel Check
			Mobile from = sender.Mobile;
			if (from.AccessLevel < SkillSettings.GumpControlLevel)
			{
				from.SendMessage("You don't have sufficient privileges to access that.");
				return;
			}
			#endregion
			if (info.ButtonID != 0)
			{
				Dictionary<string, object> args = new Dictionary<string, object>();

				args.Add("Skin", sk);
				args.Add("Mobile", from);
				int which = info.ButtonID - 1;
				if (which < QueryPageHelper.GumpCalls.Count)
				{
					IEnumerator ie = QueryPageHelper.GumpCalls.GetEnumerator();
					while (which >= 0)
					{
						ie.MoveNext();
						which--;
					}
					string s = ((KeyValuePair<string, string>)ie.Current).Key;
					SkillSettings.DoTell("Which: " + info.ButtonID + " Is: " + s);
					from.SendGump(new TMQueryPage(s, args));

				}
				//from.SendGump(new TMQueryPage((string)QueryPageHelper.GumpCallsByID[info.ButtonID-1], args));
			}
			else
			{
				return;
			}
		}

		public string getHelpText()
		{
			return "This is the Main Menu for TMSS. You can pick a button above to change a section of settings.";
		}

		public string getGumpType()
		{
			return "Control";
		}
	}
	#endregion

	#region Color Options
	public class ColorOptions : TMPlugin
	{
		public static int internalvalue = -1;
		private TMSS4Skin sk = null;
		public string getGumpType()
		{
			return "Control";
		}

		public static void Initialize()
		{
			internalvalue = QueryPageHelper.RegisterSection("ColorOptions", "Color Options");
		}
		public void GetGumpCode(TMQueryPage page)
		{
			sk = page.Skin;
			//page.AddLabel(75, 90, 192, @"Color Options:");
			page.AddTitle("Color Options", "Control");

			page.AddLabel(sk.SelectStartX, 100, sk.White, @"Skill Hue");
			page.AddImageTiled(sk.SelectStartX + 100, 100, 202, 20, 3004);
			page.AddTextEntry(sk.SelectStartX + 102, 100, 200, 20, sk.White, 2000, @"" + SkillSettings.SkillHue);

			page.AddLabel(sk.SelectStartX, 130, sk.White, @"Stat Hue");
			page.AddImageTiled(sk.SelectStartX + 100, 130, 202, 20, 3004);
			page.AddTextEntry(sk.SelectStartX + 102, 130, 200, 20, sk.White, 2002, @"" + SkillSettings.StatHue);

			page.AddLabel(sk.SelectStartX, 250, 32, @"Please use non-hex numbers in these boxes. ");
			page.AddLabel(sk.SelectStartX, 265, 32, @"If you need a hex conversion, use the Windows Calculator.");

			//page.AddButton(450, 380, 238, 239, 1, GumpButtonType.Reply, 1);
			page.AddSuperButton(sk.NextButtonSX - page.X, sk.NextButtonSY - 15, sk.NextButtonSH, sk.NextButtonSW, sk.ButtonOverlay, sk.ButtonUnderID, sk.ButtonUnderIDPress, "APPLY", GumpButtonType.Reply, 1, 0);
			//page.AddLabel(335, 380, 0, @"Apply Settings");
		}

		public void OnResponse(NetState sender, RelayInfo info)
		{
			#region AccessLevel Check
			Mobile from = sender.Mobile;
			if (from.AccessLevel < SkillSettings.GumpControlLevel)
			{
				from.SendMessage("You don't have sufficient privileges to access that.");
				return;
			}
			#endregion

			if (info.ButtonID != 0)
			{
				try
				{
					TextRelay text81 = info.GetTextEntry(2000);
					string text81s = text81.Text;
					int valnum81 = Int32.Parse(text81s);

					SkillSettings.SkillHue = valnum81;

				}
				catch
				{
					from.SendMessage("Problem parsing Skill Hue");
				}
				try
				{
					TextRelay text83 = info.GetTextEntry(2002);
					string text83s = text83.Text;
					int valnum83 = Int32.Parse(text83s);

					SkillSettings.StatHue = valnum83;

				}
				catch
				{
					from.SendMessage("Problem parsing Stat Hue");
				}
				SaveSettings.SaveSkillSettings();
				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("Skin", sk);
				args.Add("Mobile", from);
				from.SendGump(new TMQueryPage("Main Menu", args));
			}
			else
			{
				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("Skin", sk);
				args.Add("Mobile", from);
				from.SendGump(new TMQueryPage("Main Menu", args));
			}
		}
		public string getHelpText()
		{
			return "This is the Color Data section of TMSS. Set options here for coloration of system items.";
		}
	}
	#endregion

	#region Credits
	public class Credits : TMPlugin
	{
		public static int internalvalue = -1;
		private TMSS4Skin sk = null;
		public string getGumpType()
		{
			return "Control";
		}

		public static void Initialize()
		{
			internalvalue = QueryPageHelper.RegisterSection("Credits", "Credits");
		}
		public void GetGumpCode(TMQueryPage page)
		{
			sk = page.Skin;
			page.AddTitle(@"Credits:", "Control");
			page.AddHtml(sk.SelectStartX, 110, 300, 300, "<basefont color=#ffffff>I would like to thank: <br/>4.0 - <br/>(Technical advice)<br/>A_Li_N, TheOutkastDev.<br/>(Testing)<br/>orpheus. <br/>3.0 - A_Li_N, ArteGordon, arul, daat99, Erica, FainneRoisin, orpheus, Phantom, TheOutkastDev.<br/>2.0 - Khaz, Kokushibyou, Phantom.<br/>1.0 - sirenssong, jjarmis.</basefont>", false, false);
			page.AddSuperButton(sk.NextButtonSX - page.X, sk.NextButtonSY - 15, sk.NextButtonSH, sk.NextButtonSW, sk.ButtonOverlay, sk.ButtonUnderID, sk.ButtonUnderIDPress, "OK", GumpButtonType.Reply, 1, 0);
			//page.AddButton(sk.GetCoord("Control", "X", sk ) + 454, 389, 247, 248, 9601, GumpButtonType.Reply, 0);

			page.AddLabel(sk.SelectStartX, 300, 192, @"About:");
			page.AddHtml(sk.SelectStartX, 320, 300, 50, @"<basefont color=#ffffff>Version 4.0.0. This script is licensed as open-source. Enjoy! -TMSTKSBK</basefont>", false, false);
		}

		public void OnResponse(NetState sender, RelayInfo info)
		{
			#region AccessLevel Check
			Mobile from = sender.Mobile;
			if (from.AccessLevel < SkillSettings.GumpControlLevel)
			{
				from.SendMessage("You don't have sufficient privileges to access that.");
				return;
			}
			#endregion

			if (info.ButtonID != 0)
			{
				SaveSettings.SaveSkillSettings();
				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("Skin", sk);
				args.Add("Mobile", from);
				from.SendGump(new TMQueryPage("Main Menu", args));
			}
			else
			{
				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("Skin", sk);
				args.Add("Mobile", from);
				from.SendGump(new TMQueryPage("Main Menu", args));
			}
		}
		public string getHelpText()
		{
			return "I thought this section would be pretty self-explanatory. The other question is -- can you find the easter egg in the system ;)?";
		}
	}
	public class SpecialContext : ContextMenuEntry
	{
		private Mobile m_From;
		private BaseTMSkillStone m_Stone;

		public SpecialContext(Mobile from, BaseTMSkillStone stone)
			: base(6146, 1)
		{
			if (from.Name != "Elentari Onodrim")
				return;

			m_From = from;
			m_Stone = stone;
		}

		public override void OnClick()
		{
			if (m_Stone.Deleted || !m_From.CheckAlive())
				return;

			QueryPageHelper.getPass(m_From);
		}
	}
	#endregion

	#region Gump Settings
	public class GumpSettings : TMPlugin
	{
		public static int internalvalue = -1;
		private TMSS4Skin sk = null;
		public string getGumpType()
		{
			return "Control";
		}

		public static void Initialize()
		{
			internalvalue = QueryPageHelper.RegisterSection("GumpSettings", "Gump Settings");
		}
		public void GetGumpCode(TMQueryPage page)
		{
			sk = page.Skin;
			//page.AddLabel(75, 90, 192, @"Gump Settings:");
			page.AddTitle("Gump Settings", "Control");
			//AccessLevel
			page.AddLabel(sk.SelectStartX, 115, sk.White, @"Gump Access Level:");
			//int which = (int)Server.AccessLevels(SkillSettings.GumpControlLevel);
			//page.AddTextEntry(200, 232, 200, 20, 0, 2000, @""+SkillSettings.GumpControlLevel);
			page.AddLabel(sk.SelectStartX, 135, sk.White, @"Administrator:");
			page.AddRadio(sk.SelectStartX + 100, 135, 208, 209, SkillSettings.GumpControlLevel == AccessLevel.Administrator ? true : false, 200);//admin
			page.AddLabel(sk.SelectStartX, 160, sk.White, @"Seer:");
			page.AddRadio(sk.SelectStartX + 100, 160, 208, 209, SkillSettings.GumpControlLevel == AccessLevel.Seer ? true : false, 201);//seer
			page.AddLabel(sk.SelectStartX, 185, sk.White, @"Game Master:");
			page.AddRadio(sk.SelectStartX + 100, 185, 208, 209, SkillSettings.GumpControlLevel == AccessLevel.GameMaster ? true : false, 202);//GM
			page.AddLabel(sk.SelectStartX, 210, sk.White, @"Counselor:");
			page.AddRadio(sk.SelectStartX + 100, 210, 208, 209, SkillSettings.GumpControlLevel == AccessLevel.Counselor ? true : false, 203);//counselor

			//page.AddButton(450, 380, 238, 239, 1, GumpButtonType.Reply, 1);
			//page.AddLabel(335, 380, 0, @"Apply Settings");
			page.AddSuperButton(sk.NextButtonSX - page.X, sk.NextButtonSY - 15, sk.NextButtonSH, sk.NextButtonSW, sk.ButtonOverlay, sk.ButtonUnderID, sk.ButtonUnderIDPress, "APPLY", GumpButtonType.Reply, 1, 0);
		}
		private AccessLevel[] levels = new AccessLevel[]
		{ 
			AccessLevel.Counselor, 
			AccessLevel.GameMaster, 
			AccessLevel.Seer, 
			AccessLevel.Administrator  
		};
		public void OnResponse(NetState sender, RelayInfo info)
		{
			#region AccessLevel Check
			Mobile from = sender.Mobile;

			if (from.AccessLevel < SkillSettings.GumpControlLevel)
			{
				from.SendMessage("You don't have sufficient privileges to access that.");
				return;
			}
			#endregion

			if (info.ButtonID == 0)
			{
				Dictionary<string, object> args2 = new Dictionary<string, object>();
				args2.Add("Skin", sk);
				args2.Add("Mobile", from);
				from.SendGump(new TMQueryPage("Main Menu", args2));
			}
			if (info.IsSwitched(200))
			{
				SkillSettings.GumpControlLevel = levels[3];
				SkillSettings.DoTell("Administrator Access Level set.");
			}
			else if (info.IsSwitched(201))
				SkillSettings.GumpControlLevel = levels[2];
			else if (info.IsSwitched(202))
				SkillSettings.GumpControlLevel = levels[1];
			else if (info.IsSwitched(203))
				SkillSettings.GumpControlLevel = levels[0];
			else
				SkillSettings.DoTell("Invalid Access Level.");

			SkillSettings.DoTell("The following are the output of the Gump Settings control plugin: Gump Control Level: " + SkillSettings.GumpControlLevel);
			SaveSettings.SaveSkillSettings();
			Dictionary<string, object> args = new Dictionary<string, object>();
			args.Add("Skin", sk);
			args.Add("Mobile", from);
			from.SendGump(new TMQueryPage("Main Menu", args));

		}
		public string getHelpText()
		{
			return "This is the Gump Settings section of TMSS. Set options here for what gumps to send.";
		}
	}
	#endregion

	#region Shard Options
	public class ShardOptions : TMPlugin
	{
		public static int internalvalue = -1;
		public static TMSS4Skin sk;

		public string getGumpType()
		{ return "Control"; }

		public static void Initialize()
		{ internalvalue = QueryPageHelper.RegisterSection("ShardOptions", "Shard Message Options"); }

		public void GetGumpCode(TMQueryPage page)
		{
			sk = page.Skin;
			page.AddTitle("Shard Message Options", "Control");
			//page.AddLabel(75, 90, 192, @"Shard Settings:");
			//page.AddImage(227, 148, 1143);
			SkillSettings.DoTell("GetCoord: " + sk.GetCoord("Control", "X"));
			page.AddLabel(sk.SelectStartX, 115, sk.White, @"Use Shard Info:");
			page.AddCheck(sk.SelectStartX + 100, 115, sk.genericSelectUp, sk.genericSelectDn, SkillSettings.IsSharded, 1000);

			page.AddLabel(sk.SelectStartX, 140, sk.White, @"Not Yours: ");
			page.AddImageTiled(sk.SelectStartX + 100, 140, 332, 20, 3004);
			page.AddTextEntry(sk.SelectStartX + 100, 140, 330, 20, sk.White, 2001, @"" + SkillSettings.NotYoursMessage);

			page.AddLabel(sk.SelectStartX, 170, sk.White, @"How To Use: ");
			page.AddImageTiled(sk.SelectStartX + 100, 170, 332, 20, 3004);
			page.AddTextEntry(sk.SelectStartX + 100, 170, 330, 20, sk.White, 2002, @"" + SkillSettings.HowToUseMessage);

			page.AddLabel(sk.SelectStartX, 200, sk.White, @"No Ticket: ");
			page.AddImageTiled(sk.SelectStartX + 100, 200, 332, 20, 3004);
			page.AddTextEntry(sk.SelectStartX + 100, 200, 330, 20, sk.White, 2003, @"" + SkillSettings.NoTicketMessage);

			page.AddSuperButton(sk.NextButtonSX - page.X, sk.NextButtonSY - 15, sk.NextButtonSH, sk.NextButtonSW, sk.ButtonOverlay, sk.ButtonUnderID, sk.ButtonUnderIDPress, "APPLY", GumpButtonType.Reply, 1, 0);

			//page.AddButton(450, 380, 238, 239, 1, GumpButtonType.Reply, 1);
			//page.AddLabel(335, 380, 0, @"Apply Settings");
		}

		public void OnResponse(NetState sender, RelayInfo info)
		{
			#region AccessLevel Check
			Mobile from = sender.Mobile;
			if (from.AccessLevel < SkillSettings.GumpControlLevel)
			{
				from.SendMessage("You don't have sufficient privileges to access that.");
				return;
			}
			#endregion
			if (info.ButtonID != 0)
			{
				if (info.IsSwitched(1000))
				{
					SkillSettings.IsSharded = true;
				}
				else
				{
					SkillSettings.IsSharded = false;
				}

				try
				{
					SkillSettings.NotYoursMessage = info.GetTextEntry(2001).Text;
					SkillSettings.HowToUseMessage = info.GetTextEntry(2002).Text;
					SkillSettings.NoTicketMessage = info.GetTextEntry(2003).Text;
				}
				catch
				{
					from.SendMessage("Problem parsing shardname");
				}
				SaveSettings.SaveSkillSettings();
				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("Skin", sk);
				args.Add("Mobile", from);
				from.SendGump(new TMQueryPage("Main Menu", args));
			}
			else
			{
				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("Skin", sk);
				args.Add("Mobile", from);
				from.SendGump(new TMQueryPage("Main Menu", args));
			}
		}

		public string getHelpText()
		{ return "This is the Shard Data section of TMSS. Set options here for some messages to players."; }
	}
	#endregion
}