using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Server.Gumps;

namespace Server.TMSS
{
	public struct TMUsedInfo
	{
		public string SkillName;
		public double SkillValue;
		public double SkillWeight;
		public int SkillCap;
		public int SkillID;
		public TMUsedInfo(string name, double value, double weight, int cap, int id)
		{
			if (name == "")
			{ SkillSettings.SystemWrite("Invalid name.");}
			SkillName = name;
			
			SkillValue = value;
			if (weight <= 0)
			{ SkillSettings.SystemWrite("Invalid weight.");}
			SkillWeight = weight;
			
			SkillCap = cap;
			SkillID = id;
		}
	}
	public class TMSkillSession
	{
		private Dictionary<string, Dictionary<string, TMUsedInfo>> SelectedSkills = new Dictionary<string, Dictionary<string, TMUsedInfo>>();
		private Dictionary<string, TMUsedInfo> SelectedCaps = new Dictionary<string,TMUsedInfo>();
		private Dictionary<string, int> m_Stats = new Dictionary<string, int >();
		public Dictionary<string, int> Stats { get { return m_Stats; } }
		public string CurrentErrorMessage = "";
		private Mobile m_Mobile = null;
		public Mobile Mobile { get { return m_Mobile; } }
		private BaseTMSkillItem m_Item = null;
		public BaseTMSkillItem Item { get { return m_Item; } }
		public SuperSkillProfile Profile = null;
		public TMSS4Skin Skin = null;
		private TMQueryPage m_activeControl = null;
		public double totalSelectedPoints = 0.0;
		public int totalAllowedPoints = 0;
		private bool invalidated = false;
		public bool NoReset = false;
		public TMQueryPage activeControl
		{
			get { return m_activeControl; }
			set { m_activeControl = value; }
		}

		private TMQueryPage subMaster = null;

		public TMSkillSession(Mobile m, BaseTMSkillItem item)
		{
			int points = 0;
			try
			{
				string name = item.Profile.ProfileName;				
				if (SkillProfileHelper.Profiles.ContainsKey(name))
				{
					points = SkillProfileHelper.Profiles[name].SkillPoints;
					SkillSettings.DoTell("Profile Direct Query - Points: "+points+" for " +name );
				}
				else
					SkillSettings.DoTell("Name "+name+" not present in Profiles.");
			}
			catch (Exception e ){ 
				SkillSettings.DoTell("Exception while getting profile by item's profile name. "+e);
			}
			if (item.Profile == null)
			{ SkillSettings.DoTell("Invalid Profile value. It will be reset to the default."); }
			if (item.Skin == null)
			{ SkillSettings.DoTell("Invalid Skin value. It will be reset to the default."); }

			m_Item = item;
			m_Mobile = m;

			if (item.Profile == null && SkillProfileHelper.Supers[SkillSettings.CCProfileName] != null)
				Profile = SkillProfileHelper.Supers[SkillSettings.CCProfileName];
			else if (SkillProfileHelper.Supers[SkillSettings.CCProfileName] == null)
			{ SkillSettings.DoTell("Invalid Profile cannot be remedied." ); invalidated = true; return; }
			else
				Profile = (SuperSkillProfile)item.Profile;

			if (m_Item.Points > 0)
				totalAllowedPoints = m_Item.Points;
			else
			{
				SkillSettings.DoTell("Item's points are <= 0, Profile " + Profile.ProfileName + "'s SkillPoints value: " + points + " will be used."); 
				totalAllowedPoints = points; }
			if (totalAllowedPoints <= 0)
			{ SkillSettings.DoTell("Invalid Points value. Cannot continue session."); invalidated = true; }

			if (item.Skin == "" || item.Skin == null)
				Skin = (TMSS4Skin)SkinHelper.getSkin(SkillSettings.CCSkinName);
			else
			{
				try
				{
					Skin = (TMSS4Skin)SkinHelper.getSkin(item.Skin);
				}
				catch
				{
					Skin = (TMSS4Skin)SkinHelper.getSkin(SkillSettings.CCSkinName);
				}
			}

		}

		public void Start()
		{
			if( invalidated )
				return;
			if (m_Mobile == null || m_Item == null || Profile == null || Skin == null )
			{ SkillSettings.DoTell("One or more necessary items are null, the session cannot continue."); return; }
			if (Profile.IsGumped)
			{
				WindowInfo masterinf = Skin.WindowInfo["Master"];
				subMaster = new TMQueryPage("TMSS Session Master Gump", this);
				//m_Mobile.SendGump( subMaster );
				//Mobile.SendGump( new TMQueryPage("TMSS Stat Gump", this ) );
				TMQueryPage tqp = new TMQueryPage("TMSS Stat Gump", this);
			}
			else if( Profile.StandTicket )
			{
				QuickMethod();
			}
			else
				SkillSettings.DoTell("Unable to continue. Invalid session configuration.");
		}

		private void QuickMethod()
		{
			Mobile m = Mobile;
			
			IEnumerator<KeyValuePair<string,SkillProfile>> ie = Profile.subProfiles.GetEnumerator();
			while (ie.MoveNext())
			{ 
				IEnumerator<KeyValuePair<string,TMSkillInfo>> ie2 = ie.Current.Value.MasterHash.GetEnumerator();
				while (ie2.MoveNext())
				{ 					
					TMSkillInfo tsi = ie2.Current.Value;
					if (m.Skills.Total + (tsi.SkillValue * tsi.SkillWeight) <= totalAllowedPoints)
						m.Skills[tsi.SkillID].Base = tsi.SkillValue;
				}
			}
			m.Str = Profile.StrVal;
			m.Dex = Profile.DexVal;
			m.Int = Profile.IntVal;
		}

		//The three adds return a bool signifying acceptance.
		public bool addStat( Dictionary<string,int> values )
		{ 
			m_Stats = values;
			return !verifyEntries( "stats" );
		}

		internal bool addSkill( string name, Dictionary<string, TMUsedInfo> values)
		{
			SkillSettings.DoTell("Key (name): "+name);
			IEnumerator ie = values.GetEnumerator();
			while (ie.MoveNext())
			{
				TMUsedInfo ui = ((KeyValuePair<string, TMUsedInfo>)ie.Current).Value;
				SkillSettings.DoTell(" - values: " + ui.SkillName + " val: " + ui.SkillValue);
			}
			if (SelectedSkills.ContainsKey(name))
			{
				SkillSettings.DoTell("Key in dictionary. "+name+" Current sum: "+getCurrentSum(name));
				totalSelectedPoints = revaluePoints( name ); 
				SelectedSkills.Remove(name);
			}
			SkillSettings.DoTell("Pre count: "+SelectedSkills.Count);
			SelectedSkills.Add( name, values );
			SkillSettings.DoTell("Current count: "+SelectedSkills.Count);
			Dictionary<string,TMUsedInfo> info = SelectedSkills[name];
			ie = info.GetEnumerator();
			while (ie.MoveNext())
			{
				TMUsedInfo ui = ((KeyValuePair<string,TMUsedInfo>)ie.Current).Value;
				SkillSettings.DoTell(" - info: "+ ui.SkillName+" val: "+ui.SkillValue);
			}
			return !verifyEntries( name );
		}

		private double revaluePoints(string name)
		{
			double Points = 0;
			foreach (string s in SelectedSkills.Keys)
			{
				if( s != name )
					Points+= getCurrentSum( s );
			}
			return Points;
		}

		public bool addCap(Dictionary<string,TMUsedInfo> values)
		{
			SelectedCaps= values ;
			return !verifyEntries( "caps" );
		}

		private bool verifyEntries(string p)
		{
			//TODO: Add verification info for:
			//Skills - get profile, and compare values to caps, minimums.
			//Stats - take main profile, compare stat vals to caps, minimums.
			//Skillcaps - take main profile, compare caps to caps caps, minimums.
			SkillSettings.DoTell("verify: "+p);
			if (p == "stats")
			{
				return checkStats();				
			}
			if (p == "caps")
			{
				return false;
			}
			else //For skill profiles.
			{
				try
				{
					Dictionary<string, TMUsedInfo> vals = (Dictionary<string, TMUsedInfo>)SelectedSkills[p];
					SkillProfile rules = (SkillProfile)Profile.subProfiles[p];
					IEnumerator ie = vals.GetEnumerator();
					double sum = 0.0;
					while (ie.MoveNext())
					{						
						TMUsedInfo inf = (TMUsedInfo)((KeyValuePair<string,TMUsedInfo>)ie.Current).Value;
						SkillSettings.DoTell("Skill debug: "+inf.SkillName+ " "+inf.SkillValue+" "+(inf.SkillValue*inf.SkillWeight));
						sum+= (inf.SkillValue*inf.SkillWeight);
					}
					if ((double)rules.SkillPoints >= sum && totalSelectedPoints + sum <= totalAllowedPoints)
					{
						totalSelectedPoints += sum;
						SkillSettings.DoTell("Points are valid, and will be added. Sum: "+sum+" TSP: "+totalSelectedPoints+" TAP: "+totalAllowedPoints);						
						TMAlertGump g = new TMAlertGump("The points you selected were added successfully.");
						Mobile.SendGump( g );										
						return true; 
					}
					else
					{
						if ((double)totalAllowedPoints < (sum + totalSelectedPoints))
							CurrentErrorMessage = "The points you entered are too high for the overall setting. Please adjust your points downward by " + (totalAllowedPoints - (sum + totalSelectedPoints));
						if( (double)rules.SkillPoints < sum )
							CurrentErrorMessage = "The points you entered are too high for this profile. Please adjust this profile down by "+(rules.SkillPoints-sum);
						else if (!((double)totalAllowedPoints < (sum + totalSelectedPoints)))
						{
							CurrentErrorMessage = "Another error was encountered.";
							SkillSettings.DoTell("rules.SkillPoints: " + rules.SkillPoints + " sum: " + sum + " totalSelectedPoints: " + totalSelectedPoints + " totalAllowedPoints: " + totalAllowedPoints + " (double)rules.SkillPoints >= sum: " + ((double)rules.SkillPoints >= sum) + " totalSelectedPoints + sum <= totalAllowedPoints: " + ((totalSelectedPoints + sum) <= totalAllowedPoints));
						}
						return false;
					}
				}
				catch (Exception e)
				{
					SkillSettings.DoTell("Invalid name to attempt verification on. Exception: "+e);
				}
			}
			return false;
		}

		private double getCurrentSum(string p)
		{
			if( !SelectedSkills.ContainsKey(p) )
				return 0.0;
			double sum = 0.0;
			Dictionary<string,TMUsedInfo> inf = SelectedSkills[p];
			IEnumerator ie = inf.GetEnumerator();
			while (ie.MoveNext())
			{
				TMUsedInfo uif = (TMUsedInfo)((KeyValuePair<string,TMUsedInfo>)ie.Current).Value;
				sum+=(uif.SkillValue*uif.SkillWeight);
			}
			return sum;
		}
		
		internal bool VerifyFinal()
		{
			if (!checkStats())
			{
				return false;
			}
			else if (!checkSkills())
			{
				return false;
			}
			else if (!checkCaps())
			{ return false;	}
			CommitSession();
			RemoveTicket();
			return true;
		}

		private void RemoveTicket()
		{
			if(Mobile.Backpack == null )
				return;
			IEnumerator ie = Mobile.Backpack.Items.GetEnumerator();
			while( ie.MoveNext() )
			{
				Item i = (Item)ie.Current;
				if (i is BaseTMSkillTicket)
				{
					BaseTMSkillTicket bt = (BaseTMSkillTicket)i;
					bt.SessionCount--;
					if( bt.SessionCount == 0 )
						bt.Delete();
					return;
				}
			}
		}
				
		private bool checkStats()
		{
			if( !Profile.StatEnable )
				return true;
			Dictionary<string,int> st = Stats;
			if( !st.ContainsKey("Strength") || !st.ContainsKey("Dexterity") || !st.ContainsKey("Intelligence") )
			{ CurrentErrorMessage="One or more of your stats are not set."; return false;}

			if (st["Strength"] > this.Profile.StrVal)
			{ CurrentErrorMessage = "Strength is too high. Max: " + this.Profile.StrVal; return false; }
			else if (st["Dexterity"] > this.Profile.DexVal)
			{ CurrentErrorMessage = "Dexterity is too high. Max: " + this.Profile.DexVal; return false; }
			else if (st["Intelligence"] > this.Profile.IntVal)
			{ CurrentErrorMessage = "Intelligence is too high. Max: "+this.Profile.IntVal; return false; }
			else if ( st["Intelligence"]+st["Dexterity"]+st["Strength"] > Profile.StatSum )
			{ CurrentErrorMessage = "Stats are collectively too high. Max value is "+Profile.StatSum+". Value of all stats is "+(st["Intelligence"]+st["Dexterity"]+st["Strength"])+". Please revise downwards."; return false; }
			else if (st["Intelligence"] + st["Dexterity"] + st["Strength"] < Profile.StatSum && Profile.StatForce)
			{ CurrentErrorMessage = "Stats are too LOW. Please revise selections up to " + Profile.StatSum + " points. Current: " + (st["Intelligence"] + st["Dexterity"] + st["Strength"]); return false; }
			else
				return true;
		}
		private bool checkSkills()
		{
			Dictionary<string, Dictionary<string, TMUsedInfo>> sk = SelectedSkills;
			IEnumerator ie = Profile.subProfiles.GetEnumerator();
			if( !Profile.SkillEnable )
				return true;
			int masterSum = 0;
			while (ie.MoveNext())
			{
				double profSum = 0.0;
				string name = ((KeyValuePair<string,SkillProfile>)ie.Current).Key;
				SkillProfile prof = ((KeyValuePair<string,SkillProfile>)ie.Current).Value;
				Dictionary<string,TMUsedInfo> profInfo = null;
				if (sk.ContainsKey(name))
				{
					profInfo = sk[name];
					IEnumerator en = profInfo.GetEnumerator();
					while (en.MoveNext())
					{
						TMUsedInfo inf = ((KeyValuePair<string, TMUsedInfo>)en.Current).Value;
						profSum+=inf.SkillValue;
					}
					if (Math.Ceiling(profSum) > prof.SkillPoints)
					{
						CurrentErrorMessage = "Skill Points for " + prof.ProfileName + " are higher than allowed, at "+profSum+". Please revise down to " + prof.SkillPoints + " after weighting.";
						return false;
					}
				}
				masterSum+=(int)Math.Ceiling(profSum);
			}
			if (masterSum > totalAllowedPoints)
			{
				CurrentErrorMessage = "Skill Points are higher than maximum allowed value. Please revise downward by "+ (masterSum - totalAllowedPoints) +". The maximum is: "+totalAllowedPoints;
				return false;
			}
			if (Profile.SkillForce && masterSum < totalAllowedPoints)
			{
				CurrentErrorMessage = "Skill Points are lower than the required value. Please revise upward by " + (totalAllowedPoints - masterSum) + ".";
				return false;
			}
			return true;
		}

		private bool checkCaps()
		{
			if( !Profile.CapEnable )
				return true;
			IEnumerator ie = SelectedCaps.GetEnumerator();
			int capsum = 0;
			while (ie.MoveNext())
			{
				string name = ((KeyValuePair<string,TMUsedInfo>)ie.Current).Key;
				TMUsedInfo inf = ((KeyValuePair<string,TMUsedInfo>)ie.Current).Value;
				if (Profile.MasterHash[name].SkillCap < inf.SkillValue)
				{ capsum += inf.SkillCap; }
				else
				{ CurrentErrorMessage = "Cap for " + name + " is too high. Please revise down to " + Profile.MasterHash[name].SkillCap; return false; }
			}
			if (capsum > Profile.CapSum)
			{ CurrentErrorMessage = "Caps are too high. Please revise total caps down to "+Profile.CapSum; return false; }
			return true;
		}
		private void CommitSession()
		{
			Mobile m = Mobile;
			if (Profile.StatEnable)
			{
				m.Str = m_Stats["Strength"];
				m.Dex = m_Stats["Dexterity"];
				m.Int = m_Stats["Intelligence"];
			}
			if (Profile.SkillEnable)
			{
				if( !NoReset )
					ResetZero();
				IEnumerator ie = SelectedSkills.GetEnumerator();
				while (ie.MoveNext())
				{
					Dictionary<string, TMUsedInfo> inf = ((KeyValuePair<string,Dictionary<string,TMUsedInfo>>)ie.Current).Value;
					IEnumerator subie = inf.GetEnumerator();
					while (subie.MoveNext())
					{
						TMUsedInfo inf2 = ((KeyValuePair<string,TMUsedInfo>)subie.Current).Value;
						SkillSettings.DoTell("Mobile: " + m + " Skills: " + m.Skills + " SkillID: " + inf2.SkillID + " SkillValue: " + inf2.SkillValue + " Skills[inf2.SkillID] " + m.Skills[inf2.SkillID]);
						if (m != null && inf2.SkillValue != 0.0 && inf2.SkillID>=0 && inf2.SkillID < m.Skills.Length)
						{
							
							m.Skills[inf2.SkillID].Base = inf2.SkillValue; 
							SkillSettings.DoTell("BLAH! "+inf2.SkillName);
						}
					}
				}
			}
			if (Profile.CapEnable)
			{
				IEnumerator ie = SelectedSkills.GetEnumerator();
				while (ie.MoveNext())
				{
					Dictionary<string, TMUsedInfo> inf = ((KeyValuePair<string, Dictionary<string, TMUsedInfo>>)ie.Current).Value;
					IEnumerator subie = inf.GetEnumerator();
					while (subie.MoveNext())
					{
						TMUsedInfo inf2 = ((KeyValuePair<string, TMUsedInfo>)subie.Current).Value;
						SkillSettings.DoTell("Mobile: " + m + " Skills: " + m.Skills + " SkillID: " + inf2.SkillID + " SkillValue: " + inf2.SkillValue + " Skills[inf2.SkillID] " + m.Skills[inf2.SkillID]);
						if (m != null && inf2.SkillCap >= 0.0 && inf2.SkillID >= 0 && inf2.SkillID < m.Skills.Length)
						{

							m.Skills[inf2.SkillID].Cap = inf2.SkillCap;
							SkillSettings.DoTell("BLAH! " + inf2.SkillName + "capped at: "+inf2.SkillCap);
						}
					}
				}
			}
		}

		private void ResetZero()
		{
			int i = 0;
			while (i < Mobile.Skills.Length)
			{
				Mobile.Skills[i].Base = 0;
				i++;
			}
		}

		public void SendGump(Gump g)
		{
			m_Mobile.SendGump(g);
		}

		internal void Close()
		{
			SelectedSkills.Clear();			
		}

		internal Dictionary<string, TMUsedInfo> HasSelectedItems(string p)
		{
			if (SelectedSkills.ContainsKey(p))
			{
				SkillSettings.DoTell("[G2G] SelectedSkills count: " + SelectedSkills.Count + " name: "+p);
				return SelectedSkills[p];
			}
			else
			{
				SkillSettings.DoTell("[NG] SelectedSkills count: " + SelectedSkills.Count + " name: " + p);
				return new Dictionary<string, TMUsedInfo>();
			}
		}
	}
}