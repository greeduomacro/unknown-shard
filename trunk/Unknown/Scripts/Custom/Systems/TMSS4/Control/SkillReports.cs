using System;
using System.Text;
using Server.Gumps;
using System.Collections.Generic;

namespace Server.TMSS
{
	public class SkillReports : TMPluginSave
	{
		public static int internalvalue = -1;
		public static TMSS4Skin sk;
		public static string name = "SkillReports";
		
		#region TMPluginSave Members

		public string getName()
		{
			return name;
		}

		public void SavePlugin(BinaryFileWriter writer)
		{
			writer.Write(SkillReportsHelper.EnableProfileReport);
			writer.Write(SkillReportsHelper.EnableSelectionReport);
		}

		public void LoadPlugin(BinaryFileReader reader)
		{
			SkillReportsHelper.EnableProfileReport = reader.ReadBool();
			SkillReportsHelper.EnableSelectionReport = reader.ReadBool();
		}

		public void InitLoad(int id)
		{
			SkillSettings.DoTell("InitLoad called: "+name);
		}

		#endregion

		#region TMPlugin Members

		public void GetGumpCode(TMQueryPage page)
		{
			sk = page.Skin;
			page.AddLabel(75, 90, 192, @"Report Settings:");
			page.AddLabel(140, 120, 0, @"Enable Profile Reports: ");
			//page.AddCheck(240, 120, sk.CheckboxUn, sk.CheckboxCk, SkillReportsHelper.EnableProfileReport, 1000);
			page.AddLabel(140, 150, 0, @"Enable Selection Reports: ");
			//page.AddCheck(240, 150, sk.CheckboxUn, sk.CheckboxCk, SkillReportsHelper.EnableSelectionReport, 2000);
			page.AddButton(450, 380, 238, 239, 1, GumpButtonType.Reply, 1);
			page.AddLabel(335, 380, 0, @"Apply Settings");
		}

		public void OnResponse(Server.Network.NetState sender, Server.Gumps.RelayInfo info)
		{
			Mobile from = sender.Mobile;
			TMSS4Skin skin = sk;
			SkillReportsHelper.EnableSelectionReport = info.IsSwitched(2000);
			SkillReportsHelper.EnableProfileReport = info.IsSwitched(1000);
			//PluginSaver.SavePluginSettings(this);
			Dictionary<string, object> args = new Dictionary<string, object>();
			if( skin != null )
				args.Add("Skin", skin);
			else
				SkillSettings.DoTell("Reports: Skin is null.");
			if( from != null )
				args.Add("Mobile", from);
			else
				SkillSettings.DoTell("Reports: From is null.");
			from.SendGump(new TMQueryPage("Main Menu", args));
		}

		public static void Initialize()
		{
			internalvalue = QueryPageHelper.RegisterSection(name, "Reports");
		}
		public string getHelpText()
		{
			return "This section deals with the reports TMSS is able to generate.";
		}

		#endregion

		public void SelectionReport()
		{ 
			if( !SkillReportsHelper.EnableSelectionReport )
				return;

		}
		public void ProfileReport()
		{ 
			if( !SkillReportsHelper.EnableProfileReport )
				return;
		}

		#region TMPlugin Members


		public string getGumpType()
		{
			return "Control";
		}

		#endregion
	}
	public class SkillReportsHelper
	{
		public static bool EnableSelectionReport = true;
		public static bool EnableProfileReport = true;
	}
}
