using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Server.Gumps;
using Server.Network;

// -- TMSS 4.0.1r2 --
namespace Server.TMSS
{
	#region List Test Gump
	public class ListTestGump :Gump
	{
		public ListTestGump() : base(0,0)
		{
			SkillSettings.DoTell("Setting up new ListTestGump.");
			BaseSkin skin = SkinHelper.getSkin( SkillSettings.ControlSkinName );
			this.AddBackground( 0, 0, 500, 500, 9270 );
			GumpList list = new GumpList(this, "details", skin );
			SkillSettings.DoTell("List Created.");
			GumpListEntry e1 = new GumpListEntry(0, 0, list, skin.EntryDefaultWidth, skin.EntryDefaultHeight);
			e1.AddColumn("This is a column.");
			e1.AddColumn("This is a 2nd column.");
			e1.AddColumn("This is the 3rd column.");
			SkillSettings.DoTell("Entry 1 Created.");
			GumpListEntry e2 = new GumpListEntry(0, 0, list, skin.EntryDefaultWidth, skin.EntryDefaultHeight);
			e2.AddColumn("This is r2 c1.");
			e2.AddColumn("this is r2 c2.");
			e2.AddColumn("this is r2 c3.");
			SkillSettings.DoTell("Entry 2 Created.");
			list.Add( e1 );
			list.Add( e2 );
			SkillSettings.DoTell("Entries added to list.");
			list.AddColumn( "1st column." );
			list.AddColumn( "2nd column." );
			list.AddColumn( "3rd column." );
			SkillSettings.DoTell("List columns added.");
			list.columns = 3;
			list.CommitList();
		}
	}
	#endregion

	#region TMAlertGump
	public class TMAlertGump : Gump 
	{
		public TMAlertGump(string alert) : base(50,25)
		{
			this.AddBackground( 0, 0, 300, 100, 9270 );
			this.AddImageTiled( 0, 0, 300, 20, 9304 );
			this.AddLabel( 10, 0, 32, "Attention: " );
			this.AddHtml( 12, 22, 280, 78, "<basefont size=5 face = 2 color= #f6f6f6>"+alert+"</basefont>", false, false );
			//<basefont size=5 face=1 color=#CC0000><Center>TMSS - //4// -</center></basefont>
			//this.AddImageTiledButton( 130, 80,3004, 3004, 0, GumpButtonType.Reply,0,0,0,35,25 );
			this.AddButton( 130, 73, 2141,2142,1,GumpButtonType.Reply,0);
		}
		public void OnResponse(RelayInfo info, NetState sender)
		{
		}
	}
	#endregion

	#region TMMaster
	//This is the secondary start point if the argument to TMMaster is "seq_start"
	public class TMMaster : Gump, TMPlugin 
	{
        private static int internalvalue = -1;
        private TMSkillSession Session = null;
       	private SuperSkillProfile prof = null;
		private TMQueryPage Page = null;

        public static void Initialize() { internalvalue = QueryPageHelper.RegisterSection("TMMaster", "TMSS Session Master Gump"); }
        
        public TMMaster():base(0,0){}		
		public void GetGumpCode( TMQueryPage page )
		{
			object o = page.GetValueSet();
			Page = page;
			this.Dragable = false;
			if (o is TMSkillSession)
			{
				Session = (TMSkillSession)o;
				prof = Session.Profile;
			}
			Page.BaseSkinByType(this);
			if (prof == null)
			{ SkillSettings.DoTell("Invalid profile to set up Master."); return; }
			TMSS4Skin sk = Session.Skin;
			Page.AddSuperButton(sk.FinishButtonX, sk.FinishButtonY, sk.FinishButtonH, sk.FinishButtonW, sk.ButtonOverlay, sk.ButtonUnderID, sk.ButtonUnderID, sk.FinishLabel, GumpButtonType.Reply, 101, 0, this);
			AddLabel(sk.PointsLabelX, sk.PointsLabelY, sk.Red, sk.PointsLabel+" "+Session.totalSelectedPoints+" / "+Session.totalAllowedPoints);
			AddPage( 1 );

			IEnumerator ie = prof.getProfileList();
			int count = prof.subProfiles.Count;
			int i = 0;
			int pageid = 1;
			int pagesubcount = 0;
			//Add button for stats.
			Page.AddSuperButton(sk.ProfileX, sk.ProfileY + ((i % 6) * (sk.ProfileSpacer + sk.ProfileButtonH)), sk.ProfileButtonH, sk.ProfileButtonW, sk.ProfileNormalID, sk.SelectUnderlay, sk.SelectUnderlay, "Stats", GumpButtonType.Reply, i + 1, 0, this);
			i++;
			pagesubcount++;
			while (ie.MoveNext() )
			{				
				string blah = ((SkillProfile)((KeyValuePair<string,SkillProfile>)ie.Current).Value).ProfileName;
				SkillSettings.DoTell2("Master gump debug: "+blah);
				Page.AddSuperButton(sk.ProfileX, sk.ProfileY + ((i % 6) * (sk.ProfileSpacer + sk.ProfileButtonH)), sk.ProfileButtonH, sk.ProfileButtonW, sk.ProfileNormalID, sk.SelectUnderlay, sk.SelectUnderlay, "" + blah, GumpButtonType.Reply, i + 1, 0, this);
				i++;
				pagesubcount++;
				if( pagesubcount == 5 )
					pagesubcount = 0;
				if( pagesubcount == 1 )
					Page.AddSuperButton(sk.FinishButtonX, sk.FinishButtonY, sk.FinishButtonH, sk.FinishButtonW, sk.ProfileNormalID, sk.SelectUnderlay, sk.SelectUnderlay, "" + sk.FinishLabel, GumpButtonType.Reply, 101, 0, this);
				if (pagesubcount == 0)
				{
					pageid++;
					AddPage(pageid);
					Page.AddSuperButton(sk.NextButtonMX, sk.NextButtonMY, sk.NextButtonMH, sk.NextButtonMW, sk.ProfileNormalID, sk.SelectUnderlay, sk.SelectUnderlay, "" + sk.NextTextM, GumpButtonType.Page, 0, pageid + 1,this);
					if (pageid != 1)
						Page.AddSuperButton(sk.PrevButtonMX, sk.PrevButtonMY, sk.PrevButtonMH, sk.PrevButtonMW, sk.ProfileNormalID, sk.SelectUnderlay, sk.SelectUnderlay, "" + sk.PrevTextM, GumpButtonType.Page, 0, pageid - 1, this);
				}
			}	
			Session.Mobile.SendGump(this);
		}
		public override void OnResponse(NetState sender, RelayInfo info)
		{
            Mobile from = sender.Mobile;
		    //has 0, 101, and profile cases.
			//0: cancel, right-click.
			//101: Finish.
			//profile: gives 1-base index of profile to load in master profile.
			SkillSettings.DoTell("Button ID: "+info.ButtonID);
			
			if (info.ButtonID == 0 && sender.Mobile.AccessLevel >= SkillSettings.GumpControlLevel)
			{ this.Session.Close(); return; }
			else if( sender.Mobile.AccessLevel <= SkillSettings.GumpControlLevel && info.ButtonID == 0 ) { Page.Clone(); return;}

			if (info.ButtonID == 101)
			{
				if (Session.VerifyFinal())
				{ ClearGumps(sender); sender.Mobile.SendGump(new TMAlertGump("Congratulations, you are now ready to play the shard.")); }
				else
				{ sender.Mobile.SendGump(Page.Clone()); sender.Mobile.SendGump(new TMAlertGump(Session.CurrentErrorMessage) ); }				
				return;
			}
			
			int has = hasControlGump(sender);
			if (has != -1)
			{
				if( has == 1 )
					sender.Mobile.CloseGump( typeof( TMSkill ) );
				else if( has == 2 )
					sender.Mobile.CloseGump( typeof( TMStat ) );
			}
			
			if (info.ButtonID == 1 && Session.Profile.StatEnable)
			{				
				TMQueryPage p = new TMQueryPage("TMSS Stat Gump", Session);
				Page.Clone();
			}
			else
			{
				/*if (hasControlGump(sender))
				{
					sender.Mobile.SendGump(Page.Clone());
					sender.Mobile.SendGump(new TMAlertGump("You cannot open more than one selection page at a time."));					
					return;
				}*/
				int pro = info.ButtonID - 1;
				Dictionary<string, object> arg = new Dictionary<string, object>();
				arg.Add("Profile", prof.getProfile(pro));
				arg.Add("Session", Session);
				arg.Add("Skin", Session.Skin);
				arg.Add("Mobile", sender.Mobile);
				SkillSettings.DoTell("Master Gump skill gump send: Profile:"+prof.getProfile(pro)+" Session: "+Session+" Skin: "+Session.Skin+" Mobile: "+sender.Mobile);
				SkillSettings.DoTell("MG Session: TSP: "+Session.totalSelectedPoints+" TAP: "+Session.totalAllowedPoints);
				TMQueryPage p = new TMQueryPage("TMSS Skill Gump", arg);
				Page.Clone();
			}
		}

		private void ClearGumps(NetState sender)
		{
			try
			{
				IEnumerator ie = sender.Gumps.GetEnumerator();
				while (ie.MoveNext())
				{
					Gump g = (Gump)ie.Current;
					if (g is TMSkill)
						sender.Mobile.CloseGump(typeof(TMSkill));
					else if (g is TMStat)
						sender.Mobile.CloseGump(typeof(TMStat));
					else if (g is TMHelp)
						sender.Mobile.CloseGump(typeof(TMHelp));
				}
			}
			catch{ }
		}

		private int hasControlGump(NetState sender)
		{			
			IEnumerator ie = sender.Gumps.GetEnumerator();
			while (ie.MoveNext())
			{
				if( ie.Current.GetType() == typeof(TMSkill) )
					return 1;
				if( ie.Current.GetType() == typeof(TMStat) )
					return 2;
			}
			return -1;
		}
		public string getHelpText()
		{
			return "This gump is the interface for your skill session.";
		}
		public string getGumpType()
		{
			return "Master";
		}
	}
	#endregion

	#region TMStat
	public class TMStat : Gump, TMPlugin
	{
        private static int internalvalue = -1;		
		private TMSkillSession Session = null;
		private TMQueryPage Page = null;

        public static void Initialize() { internalvalue = QueryPageHelper.RegisterSection("TMStat", "TMSS Stat Gump"); }
		public TMStat() :base(0,0){ }
		#region TMPlugin Members
		public void GetGumpCode(TMQueryPage page)
		{			
			Page = page;
			this.Dragable =false;
			object o = page.GetValueSet();
			if (o is TMSkillSession)
				Session = (TMSkillSession)o;
			else
			{ SkillSettings.SystemWrite("Error. No valid Session."); return; }
			if( !Session.Profile.StatEnable )
				return;
			Page.BaseSkinByType(this);
			Page.AddTitle("Stats: ", "Control",this);
			if( !Session.Profile.StatForce )
				this.AddLabel(50, 70, Session.Skin.HighlightText, "Overall Max: "+Session.Profile.StatSum+" pts");
			else
				this.AddLabel(50, 70, Session.Skin.HighlightText, "Overall Requirement: " + Session.Profile.StatSum + " pts");
			ButtonInfo inf2 = Session.Skin.ButtonInfo["StatAddButton"];
			Page.AddSuperButton(inf2.X, Page.Y + inf2.Y, inf2.H, inf2.W, inf2.bgID, Session.Skin.ListUnderButtonN, Session.Skin.ListUnderButtonP, Session.Skin.AddLabel, GumpButtonType.Reply, 1, 0,this);
			Dictionary<string,int> statvals = Session.Stats;
			GumpList g = new GumpList(this, "details", Session.Skin );
			g.SetColumnCount( 3 );
			g.AddColumn( "Stat:" );
			g.AddColumn( "Max Value: ");
			g.AddColumn( "Enter Value: ");
			GumpListEntry str = new GumpListEntry( 0, 0, g, Session.Skin.EntryDefaultWidth, Session.Skin.EntryDefaultHeight );
			str.AddColumn( "Strength" );
			str.AddColumn( "Max: "+Session.Profile.StrVal );
			str.AddColumn( new GumpTextEntry( 0, 0, 25, Session.Skin.EntryDefaultHeight, Session.Skin.NormalText, 1000, statvals.ContainsKey("Strength") ? ""+statvals["Strength"]:"" ) );
			GumpListEntry dex = new GumpListEntry( 0, 0, g, Session.Skin.EntryDefaultWidth, Session.Skin.EntryDefaultHeight );
			dex.AddColumn("Dexterity");
			dex.AddColumn("Max: " + Session.Profile.DexVal);
			dex.AddColumn(new GumpTextEntry(0, 0, 25, Session.Skin.EntryDefaultHeight, Session.Skin.NormalText, 2000, statvals.ContainsKey("Dexterity") ? "" + statvals["Dexterity"] : ""));
			GumpListEntry intel = new GumpListEntry(0, 0, g, Session.Skin.EntryDefaultWidth, Session.Skin.EntryDefaultHeight);
			intel.AddColumn("Intelligence");
			intel.AddColumn("Max: " + Session.Profile.IntVal);
			intel.AddColumn(new GumpTextEntry(0, 0, 25, Session.Skin.EntryDefaultHeight, Session.Skin.NormalText, 3000, statvals.ContainsKey("Intelligence") ? "" + statvals["Intelligence"] : ""));
			g.Add(str);
			g.Add(dex);
			g.Add(intel);
			g.ShowDividers = true;
			g.X = Session.Skin.SelectStartX;
			g.Y = Session.Skin.SelectStartY;
			g.CommitList();
			Session.Mobile.SendGump(this);
		}
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if( info.ButtonID == 0 && sender.Mobile.AccessLevel >= SkillSettings.GumpControlLevel )
				return;
			Dictionary<string, int> dict = new Dictionary<string,int>();
			try
			{
				dict.Add("Strength", Int32.Parse(info.GetTextEntry(1000).Text));
				dict.Add("Dexterity", Int32.Parse(info.GetTextEntry(2000).Text));
				dict.Add("Intelligence", Int32.Parse(info.GetTextEntry(3000).Text));
				if (Session != null)
				{
					bool resend = Session.addStat( dict );
					if (resend)
					{
						sender.Mobile.SendGump( Page.Clone() );
						sender.Mobile.SendGump( new TMAlertGump( Session.CurrentErrorMessage ) );
					}
				}
				else
				{ SkillSettings.SystemWrite("Invalid Session. Cannot continue."); sender.Mobile.SendGump( new TMAlertGump("You do not appear to be in a Session. Cannot continue." ) ); return; }
			}
			catch (Exception e)
			{
				sender.Mobile.SendGump( Page.Clone() );
				sender.Mobile.SendGump( new TMAlertGump("Could not get Stat values. Please reenter.") );
				SkillSettings.SystemWrite("Error when acquiring stats data: " +e );
			}
		}
		public string getHelpText()
		{
			return "This is the Stat gump for TMSS 4. It will assist you in setting your stats.";
		}
		public string getGumpType()
		{
			return "Control";
		}
		#endregion
	}
	#endregion

	#region TMSkill
	//Takes session and mobile. Grabs QueryPage and arranges itself.
	public class TMSkill : Gump, TMPlugin
	{
		private static int internalvalue = -1;
        private SkillProfile Profile = null;
        private TMSS4Skin Skin = null;
		private TMSkillSession Session = null;
		private TMQueryPage Page = null;
        public static void Initialize()
        {
            internalvalue = QueryPageHelper.RegisterSection("TMSkill", "TMSS Skill Gump");
        }
		public TMSkill() :base(0,0){ }
		
		public void GetGumpCode(TMQueryPage page)
		{
			Page = page;
			SkillSettings.DoTell("GetGumpCode, Skill Gump.");
			if (Profile == null)
			{
				try
				{
					Dictionary<string, object> h = (Dictionary<string, object>)Page.GetValueSet();
					Profile = (SkillProfile)h["Profile"];
					Skin = (TMSS4Skin)h["Skin"];
					Session = (TMSkillSession)h["Session"];
				}
				catch (Exception e)
				{
					SkillSettings.DoTell("Error when generating skill gump: " + e);
					return;
				}
			}
			if (Profile == null)
			{ SkillSettings.DoTell("Profile is still null. Cannot continue."); return; }
			if( !Profile.SkillEnable )
			{
				SkillSettings.DoTell("Skills not enabled on this profile.");
				return;
			}
			this.Dragable = false;
			Page.BaseSkinByType(this);
			Page.AddTitle( "Skill Gump for "+Profile.ProfileName+": ", "Control",this);
			if (Profile.IconID > 0)
			{ 
				SkillSettings.DoTell("Adding Icon: "+Profile.IconID);
				Page.AddIcon(Profile.IconID, "Control", this); 
			}
			this.AddLabel(35, Skin.GetCoord("Control", "H") - 40, Skin.HighlightText, "Profile Maximum: " + Profile.SkillPoints + " pts");
			ButtonInfo inf2 = Skin.ButtonInfo["SessionAddButton"];
			SkillSettings.DoTell("Inf2: X: "+inf2.X+" Y: "+inf2.Y+" W: "+inf2.W+" H: " +inf2.H+" BG: "+inf2.bgID+ " TX: "+inf2.text);
			Page.AddSuperButton(inf2.X, Page.Y+inf2.Y, inf2.H, inf2.W, inf2.bgID, Skin.ListUnderButtonN, Skin.ListUnderButtonP, Skin.AddLabel, GumpButtonType.Reply, 1, 0,this);
			IEnumerator ie = Profile.MasterHash.GetEnumerator();
			GumpList l = new GumpList(this, "details", this.Skin);
			l.numperpage=8;
			l.AddColumn("Skill Name");
			l.AddColumn("Skill Value");
			l.AddColumn("Weight");
			l.AddColumn("Select");
			l.SetColumnCount(4);
			l.ChangeColumnWidth(0, 200);
			l.X = Skin.SelectStartX;
			l.Y = Skin.SelectStartY;
			l.ShowDividers = true;
			int colcount = 3; // at least columns for title, value, and checkbox.
			if (Profile.CapEnable)
				colcount++;
			if (Profile.WeightEnable)
				colcount++;
			l.SetColumnCount(colcount);
			int checkID = 0;
			if (!Profile.Manual)
				checkID = 1000;
			else
				checkID = 3000;
			Dictionary<string,TMUsedInfo> selitem = Session.HasSelectedItems( Profile.ProfileName );
			SkillSettings.DoTell(" Selitem debug: "+selitem.Count+" Profile: "+Profile.ProfileName+" TSP: "+Session.totalSelectedPoints);
			IEnumerator selitemie = selitem.GetEnumerator();
			while (selitemie.MoveNext())
			{
				SkillSettings.DoTell(" - " + ((KeyValuePair<string, TMUsedInfo>)selitemie.Current).Value.SkillName + " Value: " + ((KeyValuePair<string, TMUsedInfo>)selitemie.Current).Value.SkillValue);
			}
			while (ie.MoveNext())
			{
				TMSkillInfo inf = (TMSkillInfo)((KeyValuePair<string,TMSkillInfo>)ie.Current).Value;
				/*
				if (y % sk.NumPerPage == 0)
				{Page.SetupPage(thisProfile.ProfileName, y == 0, thisProfile.MasterHash.Count - y < sk.NumPerPage ? true : false, page); page++;}
				Page.AddEntryCheck( 0, y%sk.NumPerPage, sk.SelectUp, sk.SelectDn, false, (1000 * page) + (y % sk.NumPerPage), ""+inf.SkillName, ""+inf.SkillWeight, ""+inf.SkillValue );
				y++;*/
				GumpListEntry e = new GumpListEntry(0, 0, l, Skin.EntryDefaultWidth, Skin.EntryDefaultHeight);

				e.AddColumn(inf.SkillName);
				e.AddColumn("" + inf.SkillValue);
				if (Profile.CapEnable)
					e.AddColumn("" + inf.SkillCap);
				if (Profile.WeightEnable)
					e.AddColumn("" + inf.SkillWeight);
				if (!Profile.Manual)
					e.AddColumn(new GumpCheck(-2, 0, Skin.EntryDefaultCheckUp, Skin.EntryDefaultCheckDn, selitem.ContainsKey(inf.SkillName), checkID));
				else
					e.AddColumn(new GumpTextEntry(0, 0, 30, Skin.EntryDefaultHeight, Skin.NormalText, checkID, ""));

				checkID++;
				l.Add(e);
			}
			l.CommitList();	
			Session.Mobile.SendGump(this);
		}
		public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
			Dictionary<string, TMUsedInfo> selected = new Dictionary<string, TMUsedInfo>();
            if (info.ButtonID == 1)
            {
                bool man = Profile.Manual;
				int page = 1;
				int count = 0;
				int csid = (1000 * page) + (count % (Skin.NumPerPage-1));
				if (man)
				{
					while ( count != Profile.MasterHash.Count )
					{
						string relaytext = "";
						try
						{
							TextRelay relay = info.GetTextEntry(csid);
							relaytext = relay.Text;
						}
						catch (Exception ex)
						{
							SkillSettings.DoTell2("Manual gathering problems: " + ex);
						}
						if( relaytext != "" )
						{
							int value = -1;
							try { value = Int32.Parse(relaytext); }
							catch (Exception ex) { SkillSettings.DoTell2("Error on parse manual: " + ex); }
							TMSkillInfo skinf = Profile.getAtRank(count);
							if (skinf.SkillEnable)
							{
								TMUsedInfo inf = new TMUsedInfo(skinf.SkillName, value*skinf.SkillWeight, skinf.SkillWeight, skinf.SkillCap, skinf.SkillID);
								selected.Add(skinf.SkillName, inf);
							}
						}
						if (count % Skin.NumPerPage == 0 && count != 0)
							page++;
						count++;
						csid = 3000 + count;
					}
				}
				else
				{
					while (count != Profile.MasterHash.Count)  //Make sure all text entries have a 0 in them.
					{
						if (info.IsSwitched(csid))
						{
							TMSkillInfo skinf = Profile.getAtRank( count );
							TMUsedInfo inf = new TMUsedInfo( skinf.SkillName, skinf.SkillWeight*skinf.SkillValue, skinf.SkillWeight, skinf.SkillCap, skinf.SkillID );
							selected.Add(skinf.SkillName, inf);
						}
						if ((count + 1) % Skin.NumPerPage == 0)
							page++;
						count++;
						csid = 1000 + count;
					}
				}
            }
			else
				return;
			bool resend = Session.addSkill( ""+Profile.ProfileName, selected );
			if (resend)
			{
				from.SendGump(Page.Clone());
				from.SendGump(new TMAlertGump(Session.CurrentErrorMessage));
			}
        }

		#region TMPlugin Members
		
		public string getHelpText()
		{
			return "This gump is here to assist you in setting your skills. Select the skills you would like to have, or enter them into the boxes.";
		}
		public string getGumpType()
		{
			return "Control";
		}
		#endregion
	}
	#endregion

	#region TMHelp
	//Takes argument and skin.
	public class TMHelp : Gump,TMPlugin
	{
		private static int internalvalue = -1;
		public static void Initialize() { internalvalue = QueryPageHelper.RegisterSection("TMHelp", "TMSS Session Help Gump"); }
		public TMHelp():base(0,0) { }
		#region TMPlugin Members
		public override void OnResponse(NetState sender, RelayInfo info) { }
		public void GetGumpCode(TMQueryPage page)
		{
			Dictionary<string, object> args = (Dictionary<string, object>)page.GetValueSet();
			attemptHelpClose( page );
			page.BaseSkinByType(this);
			if (!args.ContainsKey("Get"))
				return;
			TMSS4Skin sk = (TMSS4Skin)args["Skin"];
			TMPlugin plugin = (TMPlugin)args["Get"];
			string text = plugin.getHelpText();
			if (sk.IconHOn)
				this.AddImage( sk.IconHX, sk.IconHY, sk.IconHID);
			this.AddHtml( sk.HelpLabelX, sk.HelpLabelY, sk.HelpLabelW, sk.HelpLabelH, "<basefont size=4 face=2 color=#ffffff>" + text + "</basefont>", false, false);
			page.Mobile.SendGump(this);
		}
		internal void attemptHelpClose( TMQueryPage page )
		{
			try { page.Mobile.CloseGump(typeof(TMHelp)); }
			catch{}
		}
		public string getHelpText()
		{
			return "How the heck are you seeing THIS?";
		}
		public string getGumpType()
		{
			return "Underbar";
		}
		#endregion
	}
	#endregion

	#region TMSelector
	//This is called if the argument to TMMaster is anything BUT "seq_start"
	/*public class TMSelector : TMPlugin
	{		
		private TMSkillSession m_Session = null;
		private SkillProfile profile = null;
		private Mobile referTo = null;
		
		//This constructor is meant to take a single profile from
		public TMSelector( SkillProfile prof, TMSkillSession session )
		{ 
			m_Session = session;
			profile = prof;
			generateGump( "session" );
		}		

		public TMSelector(Mobile m, string arg, SkillProfile prof)
		{
			profile = prof;
			referTo = m;
			generateGump( arg );
		}

		private void generateGump(string p)
		{
			
		}

		#region TMPlugin Members

		public void GetGumpCode(TMQueryPage page)
		{
			
		}

		public void OnResponse(Server.Network.NetState sender, RelayInfo info)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public string getHelpText()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}*/
#endregion

	#region TMProfile
	public class TMProfile : Gump,TMPlugin
	{
		#region Profile Target
		private class ProfileTarget : Server.Targeting.Target
		{
			private bool Super = false;
			private string Which = "";
			public ProfileTarget( bool s, string w ) : base( 100, false, Server.Targeting.TargetFlags.None )
			{Super = s; Which = w;}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (Which == "" || !SkillProfileHelper.Profiles.ContainsKey(Which))
				{ 
					SkillSettings.DoTell("SPH does not contain, or key is blank. Key: " + Which); 
					IEnumerator ie = SkillProfileHelper.Profiles.GetEnumerator();
					while (ie.MoveNext())
					{ SkillSettings.DoTell("Value: " + ((KeyValuePair<string, SkillProfile>)ie.Current).Key); }
					return; 
				}
				
				if (targeted is BaseTMSkillItem)
				{
					BaseTMSkillItem item = (BaseTMSkillItem)targeted;

					if (Super)
					{ SkillSettings.DoTell("Profile being set."); item.Profile = SkillProfileHelper.Supers[Which]; SkillSettings.DoTell("Profile set."); }
					else
						from.SendMessage("Non-Super Profile profiles are not yet implemented.");					
				}
				else
					from.SendMessage("Profile cannot be set on that item.");
			}
		}
		#endregion

		private static int internalvalue = -1;
		public static void Initialize() 
		{ internalvalue = QueryPageHelper.RegisterSection("TMProfile", "TMSS Profile Selector"); }
		private List< string > profilenames = null;
		public TMProfile() : base(0, 0) {
			profilenames = new List<string>();

			IEnumerator ie = SkillProfileHelper.Supers.GetEnumerator();

			while (ie.MoveNext())
			{ 
				KeyValuePair< string, SuperSkillProfile> current = (KeyValuePair< string, SuperSkillProfile>)ie.Current;
				profilenames.Add( current.Key );
			}
		}
		
		#region TMPlugin Members

		public void GetGumpCode(TMQueryPage page)
		{
			page.BaseSkinByType( this );
			int i = 0;
			GumpList gl = new GumpList( this, "details", page.Skin );
			gl.X = page.Skin.SelectStartX;
			gl.Y = page.Skin.SelectStartY;
			gl.AddColumn( "Super Profiles Available" );
			gl.AddColumn( "Item Profile Setter" );
			gl.AddColumn( "Set As Default" );
			gl.columns = 3;

			while (i < profilenames.Count)
			{ 
				GumpListEntry gle = new GumpListEntry( 0, 0, gl, 250, 20 );
				gle.AddColumn( "Set " + profilenames[i] + " on an item" );
				gle.AddColumn( new GumpButton( 0, 0, page.Skin.SelectDn, page.Skin.SelectUp, i+1, GumpButtonType.Reply, 0 ) );
				//gle.AddColumn(new GumpButton(0, 0, page.Skin.SelectDn, page.Skin.SelectUp, (i + 1)*-1, GumpButtonType.Reply, 0));
				GumpListEntry gl2 = new GumpListEntry(0, 0, gl, 250, 20);
				gl2.AddColumn("Set " + profilenames[i] + " as default");
				gl2.AddColumn(new GumpButton(0, 0, page.Skin.SelectDn, page.Skin.SelectUp, (i + 1) * -1, GumpButtonType.Reply, 0));
				gl.Add(gle);
				gl.Add(gl2);
				i++;
			}
			gl.CommitList();

			
			page.Mobile.SendGump( this );
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if( info.ButtonID == 0 )
				return;
			if (info.ButtonID > 0)
				sender.Mobile.Target = new ProfileTarget(true, profilenames[info.ButtonID - 1]);
			else
			{ 
				int val = (info.ButtonID-1) * (-1);
				if( profilenames.Count >= val )
				{
					SkillSettings.CCProfileName = profilenames[(val)]; 
					SkillSettings.DoTell("CCProfileName: "+SkillSettings.CCProfileName);
				}
				else
					SkillSettings.DoTell("profilenames does not have such a value.");
				
			}
		}

		public string getHelpText()
		{
			return "This gump is here to assist you in setting the profiles on TMSS 4 items.";
		}

		public string getGumpType()
		{
			return "Control";
		}

		#endregion
	}
	#endregion

	#region TMSkinPage
	public class TMSkinPage : Gump, TMPlugin
	{
		#region Profile Target
		private class ProfileTarget : Server.Targeting.Target
		{
			private string Which = "";
			public ProfileTarget(string w)
				: base(100, false, Server.Targeting.TargetFlags.None)
			{ Which = w; }

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (Which == "" || !SkinHelper.skList.ContainsKey(Which))
				{
					SkillSettings.DoTell("SH does not contain, or key is blank. Key: " + Which);
					IEnumerator ie = SkinHelper.skList.GetEnumerator();
					while (ie.MoveNext())
					{ SkillSettings.DoTell("Value: " + ((KeyValuePair<string, BaseSkin>)ie.Current).Key); }
					return;
				}

				if (targeted is BaseTMSkillItem)
				{
					BaseTMSkillItem item = (BaseTMSkillItem)targeted;
					SkillSettings.DoTell("Skin being set."); item.Skin = Which; SkillSettings.DoTell("Skin set.");
				}
				else
					from.SendMessage("Skin cannot be set on that item via this method. If the item uses skins, please use the method provided by the author of that item.");
			}
		}
		#endregion

		private static int internalvalue = -1;
		public static void Initialize()
		{ internalvalue = QueryPageHelper.RegisterSection("TMSkinPage", "TMSS Skin Selector"); }
		private List<string> skinnames = null;
		public TMSkinPage()
			: base(0, 0)
		{
			skinnames = new List<string>();

			IEnumerator ie = SkinHelper.skList.GetEnumerator();

			while (ie.MoveNext())
			{
				KeyValuePair<string, BaseSkin> current = (KeyValuePair<string, BaseSkin>)ie.Current;
				skinnames.Add(current.Key);
			}
		}

		#region TMPlugin Members

		public void GetGumpCode(TMQueryPage page)
		{
			page.BaseSkinByType(this);
			int i = 0;
			GumpList gl = new GumpList(this, "details", page.Skin);
			gl.X = page.Skin.SelectStartX;
			gl.Y = page.Skin.SelectStartY;
			gl.AddColumn("Skins Available");
						
			gl.SetColumnCount( 2 );
			gl.columnWidths[0] = page.Skin.ListWidth-100;
			gl.columnWidths[1] = 100;

			while (i < skinnames.Count)
			{
				if (SkinHelper.skList[skinnames[i]] is TMSS4Skin)
				{
					GumpListEntry gle = new GumpListEntry(0, 0, gl, 250, 20);
					gle.AddColumn("Set " + skinnames[i] + " on item");
					gle.AddColumn(new GumpButton(0, 0, page.Skin.SelectDn, page.Skin.SelectUp, i + 1, GumpButtonType.Reply, 0));
					GumpListEntry gl2 = new GumpListEntry(0, 0, gl, 250, 20);
					gl2.AddColumn("Set " + skinnames[i] + " as default");
					gl2.AddColumn(new GumpButton(0, 0, page.Skin.SelectDn, page.Skin.SelectUp, (i + 1) * -1, GumpButtonType.Reply, 0));
					gl.Add(gle);
					gl.Add(gl2);
				}
				i++;
			}
			gl.CommitList();

			page.Mobile.SendGump(this);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 0)
				return;
			if (info.ButtonID > 0)
				sender.Mobile.Target = new ProfileTarget(skinnames[info.ButtonID - 1]);
			else
			{
				if (info.ButtonID > 0)
					sender.Mobile.Target = new ProfileTarget(skinnames[info.ButtonID - 1]);
				else
				{
					int val = (info.ButtonID - 1) * (-1);
					if (skinnames.Count >= val)
					{
						SkillSettings.CCSkinName = skinnames[(val)];
						SkillSettings.DoTell("CCSkinName: " + SkillSettings.CCSkinName);
					}
					else
						SkillSettings.DoTell("skinnames does not have such a value.");

				}
			}
		}

		public string getHelpText()
		{
			return "This gump is here to assist you in setting the skins on TMSS 4 items.";
		}

		public string getGumpType()
		{
			return "Control";
		}

		#endregion
	}
	#endregion

	#region AlphaCompare
	//Thanks to Knives for giving me reference for this.
	public class AlphaCompare : IComparer
	{
		public AlphaCompare() { }

		public int Compare(object a, object b)
		{
			if (a == null && b == null)
				return 0;
			if (a == null)
				return -1;
			if (b == null)
				return 1;

			try
			{
				return Insensitive.Compare((string)a, (string)b);
			}
			catch
			{
				return 1;
			}
		}
	}
	#endregion
}