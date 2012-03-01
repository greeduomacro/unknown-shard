using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Reflection;
using Server.Commands;
using Server.Gumps;
using System.Collections.Generic;
//Computer meus nefandus est.
namespace Server.TMSS
{
	#region TMSS4 Skin Class
	public class TMSS4Skin : BaseSkin
	{
		//This is almost the entire class.
		//All "operations" are done in the SkinHelper
		#region Variables		
		//Backgrounds
		public int ProfileButtonW = 140;
		public int ProfileButtonH = 42;
		public int FinishButtonW = 65;
		public int FinishButtonH = 25;
		public int PrevButtonMW = 80;
		public int PrevButtonMH = 25;
		public int NextButtonMW = 80;
		public int NextButtonMH = 25;
		public int PrevButtonSW = 80;
		public int PrevButtonSH = 25;
		public int NextButtonSW = 80;
		public int NextButtonSH = 25;
		public int SelectW = 425;
		public int SelectH = 20;
		//Lists:
		public int ProfileX = 38;
		public int ProfileY = 38;
		public int RemoveX = 15;
		public int RemoveY = 90;
		public int AddX = 25;
		public int AddY = 365;
		public int UsedMaxX = 45;
		public int UsedMaxY = 360;
		public int FinishButtonX = 38;
		public int FinishButtonY = 263;
		public int BarMHX = 35;
		public int BarMHY = 35;
		public int BarMVX = 35;
		public int BarMVY = 35;
		public int BarSHX = 65;
		public int BarSHY = 95;
		public int BarSVX = 470;
		public int BarSVY = 95;
		public int BarMHW = 136;
		public int BarMHH = 3;
		public int BarMVH = 208;
		public int BarMVW = 3;
		public int BarSHW = 405;
		public int BarSHH = 2;
		public int PrevButtonMX = 120;
		public int PrevButtonMY = 330;
		public int PrevButtonSX = 522;
		public int PrevButtonSY = 330;
		public int NextButtonMX = 120;
		public int NextButtonMY = 358;
		public int NextButtonSX = 605;
		public int NextButtonSY = 330;
		public int SelectStartX = 45;
		public int SelectStartY = 100;
		public int CheckTopX = 405;
		public int CheckTopY = 52;
		public int NameLabelX = 80;
		public int NameLabelY = 50;
		public int WeightLabelX = 215;
		public int WeightLabelY = 65;
		public int PointsLabelX = 65;
		public int PointsLabelY = 320;
		public int Divider1X = 190;
		public int Divider1Y = 60;
		public int Divider2X = 290;
		public int Divider2Y = 60;
		public int Divider3X = 390;
		public int Divider3Y = 60;
		public int SelectTitleX = 80;
		public int SelectTitleY = 45;
		public int TMSSX = 345;
		public int TMSSY = 345;
		public int HelpLabelX = 35;
		public int HelpLabelY = 10;
		public int HelpLabelW = 450;
		public int HelpLabelH = 45;
		public int TMSSHue = 1152;
		
		//Deltas:
		public int ProfileDelta = 25;
		public int SpaceMainSele = 5;
		public int SpaceSeleHelp = 5;
		public int SpacerBase = 15;
		public int SkillSpacer = 5;
		public int ProfileSpacer = 3;
		public int RemoveSpacer = 15;
		public int SelectInset = 20;		

		//Icons/Buttons
		//IconM is an item. Default is the TMSS skillstone.
		public int IconMColor = 96;
		public int IconMID = 3805;
		public int IconMX = 0;
		public int IconMY = 0;
		public bool IconMOn = true;
		//IconS is an image, not an item.
		public int IconSID = 2245;
		public int IconSX = 15;
		public int IconSY = 15;
		public bool IconSOn = true;
		//IconH is also an image.
		public int IconHID = 22153;
		public int IconHX = 14;
		public int IconHY = 12;
		public bool IconHOn = true;
		//Generic button:
		public int genericID = 2488;
		//Add/removes
		public int removeID = 2510;
		public int addID = 2511;
		//Button overlay
		public int ProfileNormalID = 3004;
		public int ProfileUsedID = 2604;
		//Normal Button:
		public int ButtonOverlay = 3004;
		public int ButtonUnderID = 247;
		public int ButtonUnderIDPress = 248;
		//Arrows for profiles
		public int ArrowSide = 2087;
		public int ArrowDown = 2086;
		//Checkbox IDs:
		public int SelectUp = 2474;
		public int SelectDn = 9730;
		//Select bar
		public int SelectUnderlay = 9385;

		//Labels:
		public string MasterLabel = "Select a Category:";
		public string PrevTextM = "PREV";
		public string PrevTextS = "PREV";
		public string NextTextM = "NEXT";
		public string NextTextS = "NEXT";
		public string ProfileSuffix = "";
		public string ProfilePrefix = " - ";
		public string NameLabel = "Name:";
		public string WeightLabel = "Weight:";
		public string PointsLabel = "Points:";
		public string MaxLabel = "Max: ";
		public string HelpLabel = "Help: ";
		public string FinishLabel = "Finish";
		public string AddLabel = "ADD";

		//Hues
		public int ProfileHue = 1152;
		public int ProfileUseText = 1358;		

		//IDs:
		public int DividerID = 2700;
		public int MasterLineV = 2700;
		public int MasterLineH = 2701;
		public int SelectLineV = 2700;
		public int SelectLineH = 2701;
		public int genericSelectUp = 2474;
		public int genericSelectDn = 2118;
		public bool HelpOn = true;
		#endregion

		public TMSS4Skin() : base() 
		{
			this.WindowInfo.Add( "Master", new WindowInfo( 15, 25, 200, 380, 9270 ) );
			this.WindowInfo.Add("Underbar", new WindowInfo(215, 405, 500, 70, 9270));
			this.WindowInfo.Add("Control", new WindowInfo(215, 25, 500, 380, 9270));
			this.ButtonInfo.Add("SessionAddButton", new ButtonInfo( 203,252,80,25,ListButtonOverlay,"ADD"));
			this.ButtonInfo.Add("StatAddButton", new ButtonInfo(366, 188, 80, 25, ListButtonOverlay, "ADD"));
		}
		public TMSS4Skin(string name) : base( name ){}

		internal int GetCoord(string gumptype, string coord)
		{
			WindowInfo inf = WindowInfo[gumptype];
			switch (coord)
			{ 
				case "X":
					return inf.X;
				case "Y":
					return inf.Y;
				case "W":
					return inf.W;
				case "H":
					return inf.H;
				default:
					return -1;
			}
		}
	}
	#endregion	

	#region Skill Skin Class
	
	public class SkillSkin : BaseSkin
	{
		//This is almost the entire class.
		//All "operations" are done in the SkinHelper
		#region Variables
				
		//Icons/Buttons
		//IconM is an item. Default is the TMSS skillstone.
		public int IconMColor = 96;
		public int IconMID = 3805;
		public int IconMX = 0;
		public int IconMY = 0;
		public bool IconMOn = true;
		//Generic button:
		public int genericID = 2488;
		//Add/removes
		public int removeID = 2510;
		public int addID = 2511;
		//Button overlay
		public int ProfileNormalID = 3004;
		public int ProfileUsedID = 2604;
		//Normal Button:
		public int ButtonOverlay = 3004;
		public int ButtonUnderID = 247;
		public int ButtonUnderIDPress = 248;
		//Arrows for profiles
		public int ArrowSide = 2087;
		public int ArrowDown = 2086;
		//Checkbox IDs:
		public int SelectUp = 2474;
		public int SelectDn = 9730;
		//Select bar
		public int SelectUnderlay = 9385;

		//Hues
		public int ProfileHue = 1152;
		public int ProfileUseText = 1358;
		public int BlueTextHue = 2223;
				
		#endregion

		public SkillSkin()
			: this( "Skill Skin" )
		{		
			
			
		}
		public SkillSkin(string name)
			: base(name)
		{
			this.WindowInfo.Add("SkillWindow", new WindowInfo(215, 28, 337, 400, 2520));

			this.ButtonInfo.Add("LockButton", new ButtonInfo(0, 0, 0, 0, 2092, 2092));
			this.ButtonInfo.Add("UpButton", new ButtonInfo(0, 0, 0, 0, 2435, 2436));
			this.ButtonInfo.Add("DownButton", new ButtonInfo(0, 0, 0, 0, 2437, 2438));
			this.ButtonInfo.Add("UseButton", new ButtonInfo(0, 0, 0, 0, 2103, 2104));
			this.ButtonInfo.Add("NewGroup", new ButtonInfo(36, 188, 80, 25, 0, 0));
			this.ButtonInfo.Add("ExpandContractGroup", new ButtonInfo(0, 0, 0, 0, 2087, 2086));

			this.EntryButtonUnderlay = 0;
			this.NormalText = 1736;
			ButtonInfo prevbtn = new ButtonInfo(285, 390, 0, 0, 2223, 2223);
			ButtonInfo nextbtn = new ButtonInfo(305, 390, 0, 0, 2224, 2224);
			ButtonInfo.Remove("ListPrevButton");
			ButtonInfo.Add("ListPrevButton", prevbtn);
			ButtonInfo.Remove("ListNextButton");
			ButtonInfo.Add("ListNextButton", nextbtn);
		}

		internal int GetCoord(string gumptype, string coord)
		{
			WindowInfo inf = WindowInfo[gumptype];
			switch (coord)
			{
				case "X":
					return inf.X;
				case "Y":
					return inf.Y;
				case "W":
					return inf.W;
				case "H":
					return inf.H;
				default:
					return -1;
			}
		}
	}
	#endregion	
}