/*
 
 d88b        888b    888b    d88888b    d88b  88888888b
 8888        8888    8888   d8888888b   8888  888888888b
 8888        8888    8888  888Y   888b  8888  888Y   888b
 8888        8888    8888  8888         8888  8888    8888
 8888        8888    8888  8888         8888  8888    8888
 8888        8888    8888  8888         8888  8888    8888
 8888        8888    8888  8888         8888  8888    8888
 8888        8888    8888  Y888   888P  8888  8888   888P
 888888888b  Y8888888888P   Y8888888P   8888  888888888P
 Y888888888   Y88888888P     Y88888P    Y88P  88888888P  ...:||[ 2007 ]||:..
 
    _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2007 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \    lucidnagual@charter.net    \
    \_     ===================      \
     \   -Owner of "The Conjuring"-  \
      \_     ===================     ~\
       )      Lucid's Mega Pack        )
      /~    The Mother Load v1.1     _/
    _/_______________________________/
 -=(_)_______________________________)=-

 */
using System;
using Server;
using System.Collections;
using Server.Targeting;
using Server.Commands;
using Server.Mobiles;
using Server.Gumps;
using Server.Enums;


namespace Server.ACC.CM
{
	[Flags]
	public enum MyPlayerFlag // First 16 bits are reserved for default-distro use, start custom flags at 0x00010000
	{
		None				= 0x00000000,
		UseMyOwnFilter		= 0x00000001
	}
	
	public class PlayerModule : Module
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GetInfo", AccessLevel.GameMaster, new CommandEventHandler( GetInfo_OnCommand ) );
			CommandSystem.Register( "MyInfo", AccessLevel.Player, new CommandEventHandler( MyInfo_OnCommand ) );
			CommandSystem.Register( "BODInfo", AccessLevel.Player, new CommandEventHandler( BODInfo_OnCommand ) );
		}
		
		public override string Name(){ return "Player Module"; }
		
		//--<<Hallucination>>---------------------[Start 1/1]
		public bool Hallucinating;
		//--<<Hallucination>>---------------------[End 1/1]
		
		//--<<UO Wedding>>------------------------[Start 1/1]
		private bool IsMarried, m_AllowGayMarriages, m_AllowCelestialMarriages;
		
		private DateTime m_MarriageTime;
		private Point3D m_WifeLoc;
		private Point3D m_HusbandLoc;
		private MaritalStatus m_MaritalStatus;
		private TypeOfMarriage m_TypeOfMarriage;
		
		private string m_FirstName, m_LastName, m_MaidenName;
		
		public static ArrayList m_Spouses = new ArrayList();
		public static ArrayList m_Wives = new ArrayList();
		public static ArrayList m_Husbands = new ArrayList();
		//--<<UO Wedding>>------------------------[End 1/1]
		
		
		//--<<Characterization>>------------------[Start 1/1]
		public PlayerClasses m_Class;
		public PlayerRaces m_Race;
		public PlayerTribes m_Tribe;
		public PlayerRanks m_Rank;
		//--<<Characterization>>------------------[End 1/1]
		
		//--<<Experience>>------------------------[Start 1/1]
		private int m_RankPoints, m_RewardsClaimed, m_SkillPts;
		private int m_Age, m_NextLevelUp, m_Experience, m_Level;
		private bool m_Updated;
		//--<<Experience>>------------------------[End 1/1]
		
		//--<<Custom BODs>>-----------------------[Start 1/1]
		private bool m_Bioenginer;
		private DateTime m_NextSmithBulkOrder;
		private DateTime m_NextTailorBulkOrder;
		//private DateTime m_NextFletcherBulkOrder;
		//private DateTime m_NextCarpenterBulkOrder;
		//private DateTime m_NextTinkerBulkOrder;
		//private DateTime m_NextTamingBulkOrder;
		private MyPlayerFlag m_Flags;
		//--<<Custom BODs>>-----------------------[End 1/1]
		
		//--<<Hunting>>---------------------------[Start 1/1]
		private HuntMode m_HuntMode = HuntMode.None;
		private HuntRank m_HuntRank = HuntRank.None;
		private HuntReward m_HuntReward = HuntReward.None;
		private bool m_Hunting = false;
		private int m_EasyKills, m_HardKills, m_ExtremeKills, m_GodKills;
		//--<<Hunting>>---------------------------[End 1/1]
		
		//--<<UO Wedding>>------------------------[Start 1/1]
		[CommandProperty( AccessLevel.GameMaster ) ]
		public bool AllowGayMarriages { get{ return m_AllowGayMarriages; } set{ m_AllowGayMarriages = value; }	}
		
		[CommandProperty( AccessLevel.GameMaster ) ]
		public bool AllowCelestialMarriages { get{ return m_AllowCelestialMarriages; } set{ m_AllowCelestialMarriages = value; }	}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime MarriageTime { get{ return m_MarriageTime; } set{ m_MarriageTime = value; } }
		
		[CommandProperty( AccessLevel.GameMaster ) ]
		public string FirstName { get{ return m_FirstName; } set{ m_FirstName = value; } }
		
		[CommandProperty( AccessLevel.GameMaster ) ]
		public string LastName { get{ return m_LastName; } set{ m_LastName = value; } }
		
		[CommandProperty( AccessLevel.GameMaster ) ]
		public string MaidenName { get{ return m_MaidenName; } set{ m_MaidenName = value; }	}
		
		[CommandProperty( AccessLevel.GameMaster ) ]
		public MaritalStatus MaritalStatus { get { return m_MaritalStatus; } set { m_MaritalStatus = value; } }
		
		[CommandProperty( AccessLevel.GameMaster ) ]
		public TypeOfMarriage TypeOfMarriage { get { return m_TypeOfMarriage; } set { m_TypeOfMarriage = value; } }
		//--<<UO Wedding>>------------------------[End 1/1]
		
		//--<<Characterization>>------------------[Start 1/1]
		[CommandProperty( AccessLevel.GameMaster)]
		public PlayerClasses PlayerClasses { get{ return m_Class; }	set{ m_Class = value; }	}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public PlayerRaces PlayerRaces { get{ return m_Race; } set{ m_Race = value; } }
		
		[CommandProperty( AccessLevel.GameMaster)]
		public PlayerTribes PlayerTribes { get{ return m_Tribe; } set{ m_Tribe = value; }	}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public PlayerRanks PlayerRanks { get{ return m_Rank; } set{ m_Rank = value; } }
		//--<<Characterization>>------------------[End 1/1]
		
		//--<<Experience>>------------------------[Start 1/1]
		[CommandProperty( AccessLevel.GameMaster )]
		public int RankPoints{ get{ return m_RankPoints; } set{ m_RankPoints = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RewardsClaimed{ get{ return m_RewardsClaimed; } set{ m_RewardsClaimed = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Level{ get{ return m_Level; } set{ m_Level = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int SkillPts{ get{ return m_SkillPts; } set{ m_SkillPts = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Experience{ get{ return m_Experience; } set { m_Experience = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Age{ get{ return m_Age; } set { m_Age = value; } }
		
		[CommandProperty( AccessLevel.GameMaster)]
		public int NextLevelUp
		{
			get{ return m_NextLevelUp; }
			set
			{
				if ( m_Level == 0 )
					m_NextLevelUp = 500;
				if ( m_Level == 1 )
					m_NextLevelUp = 1000;
				if ( m_Level == 2 )
					m_NextLevelUp = 2500;
				if ( m_Level == 3 )
					m_NextLevelUp = 5000;
				if ( m_Level == 4 )
					m_NextLevelUp = 10000;
				if ( m_Level == 5 )
					m_NextLevelUp = 25000;
				if ( m_Level == 6 )
					m_NextLevelUp = 50000;
				if ( m_Level == 7 )
					m_NextLevelUp = 100000;
				if ( m_Level == 8 )
					m_NextLevelUp = 200000;
				if ( m_Level == 9 )
					m_NextLevelUp = 300000;
				if ( m_Level == 10 )
					m_NextLevelUp = 400000;
				if ( m_Level == 11 )
					m_NextLevelUp = 500000;
				if ( m_Level == 12 )
					m_NextLevelUp = 600000;
				if ( m_Level == 13 )
					m_NextLevelUp = 700000;
				if ( m_Level == 14 )
					m_NextLevelUp = 800000;
				if ( m_Level == 15 )
					m_NextLevelUp = 900000;
				if ( m_Level == 16 )
					m_NextLevelUp = 1000000;
			}
		}
		
		[CommandProperty( AccessLevel.Administrator )]
		public bool Updated{ get{ return m_Updated; } set{ m_Updated = value; } }
		//--<<Experience>>------------------------[End 1/1]

		//--<<Custom BODs>>-----------------------[Start 1/1]
		[CommandProperty( AccessLevel.GameMaster )]
		public bool UseMyOwnFilter
		{
			get{ return GetMyFlag( MyPlayerFlag.UseMyOwnFilter ); }
			set{ SetMyFlag( MyPlayerFlag.UseMyOwnFilter, value ); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Bioenginer
		{
			get{ return m_Bioenginer; }
			set{ m_Bioenginer = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextSmithBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextSmithBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextSmithBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextTailorBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextTailorBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextTailorBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}
		
/*		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextFletcherBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextFletcherBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextFletcherBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextCarpenterBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextCarpenterBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextCarpenterBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextTinkerBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextTinkerBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextTinkerBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextTamingBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextTamingBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextTamingBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}*/
		//--<<Custom BODs>>-----------------------[End 1/1]

		//--<<Hunting>>---------------------------[Start 1/1]
		[CommandProperty( AccessLevel.Administrator )]
		public HuntMode HuntingMode { get { return m_HuntMode; } set { m_HuntMode = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public HuntRank HuntingRank { get { return m_HuntRank; } set { m_HuntRank = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public HuntReward HuntingReward { get { return m_HuntReward; } set { m_HuntReward = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public bool Hunting { get{ return m_Hunting; } set{ m_Hunting = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public int EasyKills { get { return m_EasyKills; } set { m_EasyKills = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public int HardKills { get { return m_HardKills; } set { m_HardKills = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public int ExtremeKills { get { return m_ExtremeKills; } set { m_ExtremeKills = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public int GodKills
		{
			get { return m_GodKills; }
			set { m_GodKills = value; }
		}
		//--<<Hunting>>---------------------------[End 1/1]
		
		//--<<Custom BODs>>-----------------------[Start 1/1]
		public bool GetMyFlag( MyPlayerFlag flag )
		{
			return ( ( m_Flags & flag ) != 0 );
		}
		
		public void SetMyFlag( MyPlayerFlag flag, bool value )
		{
			if ( value )
				m_Flags |= flag;
			else
				m_Flags &= ~flag;
		}
		//--<<Custom BODs>>-----------------------[End 1/1]
		
		public PlayerModule( Serial serial ): base( serial )
		{
		//--<<Custom BODs>>-----------------------[Start 1/1]
			m_BOBFilter = new Engines.BulkOrders.BOBFilter();
			//m_TamingBOBFilter = new Engines.BulkOrders.TamingBOBFilter();
			//m_TinkBOBFilter = new Engines.BulkOrders.TinkBOBFilter();
		//--<<Custom BODs>>-----------------------[End 1/1]
		}
		
		//--<<Custom BODs>>-----------------------[Start 1/1]
		private Engines.BulkOrders.BOBFilter m_BOBFilter;
		//private Engines.BulkOrders.TinkBOBFilter m_TinkBOBFilter;
		//private Engines.BulkOrders.TamingBOBFilter m_TamingBOBFilter;
		
		public Engines.BulkOrders.BOBFilter BOBFilter
		{
			get{ return m_BOBFilter; }
		}
		
/*		public Engines.BulkOrders.TinkBOBFilter TinkBOBFilter
		{
			get{ return m_TinkBOBFilter; }
		}
		
		public Engines.BulkOrders.TamingBOBFilter TamingBOBFilter
		{
			get{ return m_TamingBOBFilter; }
		}*/
		//--<<Custom BODs>>-----------------------[End 1/1]
		
		//--<<Characterization>>------------------[Start 1/1]
		private static void GetInfo_OnCommand( CommandEventArgs e )
		{
			PlayerModule module = ( PlayerModule )CentralMemory.GetModule( e.Mobile.Serial, typeof( PlayerModule ) );
			
			e.Mobile.Target = new InternalTarget( module );
		}
		
		private static void MyInfo_OnCommand( CommandEventArgs e )
		{
			PlayerModule module = ( PlayerModule )CentralMemory.GetModule( e.Mobile.Serial, typeof( PlayerModule ) );
			
			if( module == null )
			{
				CentralMemory.AppendModule( e.Mobile.Serial, new PlayerModule( e.Mobile.Serial ), true );
				e.Mobile.SendMessage( "A module has been created for you, please try again." );
			}
			else
			{
				e.Mobile.SendMessage( "My Info:" );
				e.Mobile.SendMessage( "-------------------------------" );
				e.Mobile.SendMessage( "My class is: {0}", module.m_Class );
				e.Mobile.SendMessage( "My race is: {0}", module.m_Race );
				e.Mobile.SendMessage( "My tribe is: {0}", module.m_Tribe );
				e.Mobile.SendMessage( "My experience is: {0}", module.m_Experience );
				e.Mobile.SendMessage( "-------------------------------" );
			}
		}
		//--<<Characterization>>------------------[End 1/1]
		
		//--<<Custom BODs>>-----------------------[Start 1/1]
		private static void BODInfo_OnCommand( CommandEventArgs e )
		{
			PlayerModule module = ( PlayerModule )CentralMemory.GetModule( e.Mobile.Serial, typeof( PlayerModule ) );
			
			if( module == null )
			{
				CentralMemory.AppendModule( e.Mobile.Serial, new PlayerModule( e.Mobile.Serial ), true );
				e.Mobile.SendMessage( "A module has been created for you, please try again." );
			}
			else
			{
				e.Mobile.SendMessage( "Next BOD Releases:" );
				e.Mobile.SendMessage( "-------------------------------" );
				e.Mobile.SendMessage( "Blacksmith BOD: {0}", module.m_NextSmithBulkOrder );
				//e.Mobile.SendMessage( "Tailor BOD: {0}", module.m_NextTailorBulkOrder );
				//e.Mobile.SendMessage( "Taming BOD: {0}", module.m_NextTamingBulkOrder );
				//e.Mobile.SendMessage( "Fletcher BOD: {0}", module.m_NextFletcherBulkOrder );
				//e.Mobile.SendMessage( "Carpenter BOD: {0}", module.m_NextCarpenterBulkOrder );
				//e.Mobile.SendMessage( "Tinker BOD: {0}", module.m_NextTinkerBulkOrder );
				e.Mobile.SendMessage( "-------------------------------" );
			}
		}
		//--<<Custom BODs>>-----------------------[End 1/1]
		
		//--<<UO Wedding>>------------------------[Start 1/1]
		public void AddSpouse( Mobile from, Mobile spouse )
		{
			if ( m_Spouses == null )
				m_Spouses = new ArrayList();
			
			if ( m_Spouses.Contains( spouse ) )
			{
				from.SendMessage( "That player is already married." );
			}
			else
			{
				m_Spouses.Add( spouse );
			}
		}
		
		public void AddWives( Mobile from, Mobile spouse )
		{
			if ( m_Wives == null )
				m_Wives = new ArrayList();
			
			if ( m_Wives.Contains( spouse ) )
			{
				from.SendMessage( "That player is already married." );
			}
			else
			{
				m_Wives.Add( spouse );
			}
		}
		
		public void AddHusbands( Mobile from, Mobile spouse )
		{
			if ( m_Husbands == null )
				m_Husbands = new ArrayList();
			
			if ( m_Husbands.Contains( spouse ) )
			{
				from.SendMessage( "That player is already married." );
			}
			else
			{
				m_Husbands.Add( spouse );
			}
		}
		
		public bool RemoveSpouse( Mobile from )
		{
			if ( !m_Spouses.Contains( from ) )
			{
				from.SendMessage( "You have to be married to get a divorce." );
				return false;
			}
			else
			{
				m_Spouses.Remove( from );
				from.SendMessage( "Your divorce has now been finalized." );
				
				if ( m_Wives.Contains( from ) )
				{
					m_Wives.Remove( from );
					return true;
				}
				
				if ( m_Husbands.Contains( from ) )
				{
					m_Husbands.Remove( from );
					return true;
				}
				
				return true;
			}
		}
		
		public void StartWedding( Mobile from )
		{
			if ( from.Female )
			{
				m_Wives.Add( from );
			}
			else
			{
				m_Husbands.Add(from);
			}
			
			//from.SendGump( new WeddingGump( this, from ) );
			m_MarriageTime = DateTime.Now;
			
			return;
		}
		//--<<UO Wedding>>------------------------[End 1/1]

		
		/*		public virtual void OnDamage( int amount, Mobile from, bool willKill )
		{
			BaseCreature bc = from as BaseCreature;
			
			if ( bc == null )
				return;
			
			if ( HuntingMode == HuntMode.Easy && ( bc.IsHard || bc.IsExtreme || bc.IsGod ) )
				Combatant = null;
			if ( HuntingMode == HuntMode.Hard && ( bc.IsEasy || bc.IsExtreme || bc.IsGod ) )
				Combatant = null;
			if ( HuntingMode == HuntMode.Extreme && ( bc.IsEasy || bc.IsHard || bc.IsGod ) )
				Combatant = null;
			if ( HuntingMode == HuntMode.God && ( bc.IsEasy || bc.IsHard || bc.IsExtreme ) )
				Combatant = null;
			
			if ( bc != null && Hunting == true && !( bc.IsEasy || bc.IsHard || bc.IsExtreme || bc.IsGod ) && bc.Karma <= -200 )
			{
				if ( HuntingMode == HuntMode.Easy && Easy.CheckConvert( bc ))
				{
					bc.IsEasy = true;
					bc.Hits = 2000;
				}
				else if ( HuntingMode == HuntMode.Hard && Hard.CheckConvert( bc ))
				{
					bc.IsHard = true;
					bc.Hits = 4000;
				}
				else if ( HuntingMode == HuntMode.Extreme && Extreme.CheckConvert( bc ))
				{
					bc.IsExtreme = true;
					bc.Hits = 6000;
				}
				else if ( HuntingMode == HuntMode.God && God.CheckConvert( bc ))
				{
					bc.IsGod = true;
					bc.Hits = 8000;
				}
				else
					return;
			}
		}*/
		
		/*		public virtual void Damage( int amount, Mobile from )
		{
			BaseCreature bc = from as BaseCreature;
			
			if ( this == null )
				return;
			
			if ( bc == null )
				return;
			
			if (( bc.IsEasy || bc.IsHard || bc.IsExtreme || bc.IsGod ) && bc.Combatant != this )
			{
				amount = (int)( amount -= amount );
				bc.Damage( amount, bc );
			}
		}*/
		
		public override void Append( Module mod, bool negatively )
		{
		}
		
		
		private class InternalTarget : Target
		{
			private PlayerModule player_mod;
			
			public InternalTarget( PlayerModule module ) : base( 1, false, TargetFlags.None )
			{
				player_mod = module;
			}
			
			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is PlayerMobile )
				{
					PlayerMobile pm = ( PlayerMobile )targeted;
					PlayerModule module = ( PlayerModule )CentralMemory.GetModule( from.Serial, typeof( PlayerModule ) );
					
					if ( module != null )
						from.SendGump( new PropertiesGump( from, module ) );
					
					else
						from.SendMessage( "This player does not have a playermodule." );
				}
				else
					from.SendMessage("Can Only Target PLAYERS!");
			}
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int )1 );  //--<< Version Number >>--------------<<
	
			//Version 2
			//writer.Write( ( bool )Hallucinating );			//Hallucinating
			//Version 2
			
			//Version 1
			writer.Write( ( bool )IsMarried );					//UO Wedding
			writer.Write( ( bool )m_AllowGayMarriages );		//UO Wedding
			writer.Write( ( bool )m_AllowCelestialMarriages );	//UO Wedding
			writer.Write( ( DateTime )m_MarriageTime );			//UO Wedding
			writer.Write( ( Point3D )m_WifeLoc );				//UO Wedding
			writer.Write( ( Point3D )m_HusbandLoc );			//UO Wedding
			writer.Write( ( int )m_MaritalStatus );				//UO Wedding
			writer.Write( ( int )m_TypeOfMarriage );			//UO Wedding
			writer.Write( ( string )m_FirstName );				//UO Wedding
			writer.Write( ( string )m_LastName );				//UO Wedding
			writer.Write( ( string )m_MaidenName );				//UO Wedding
			writer.Write( ( int )m_RankPoints);					//Level System
			
			/*GD13_HS_Start_6*/
			writer.Write( ( int )m_HuntMode );					//Hunting System
			writer.Write( ( int )m_HuntRank );					//Hunting System
			writer.Write( ( int )m_HuntReward );				//Hunting System
			writer.Write( ( bool )m_Hunting );					//Hunting System
			writer.Write( ( int )m_EasyKills );					//Hunting System
			writer.Write( ( int )m_HardKills );					//Hunting System
			writer.Write( ( int )m_ExtremeKills );				//Hunting System
			writer.Write( ( int )m_GodKills );					//Hunting System
			/*GD13_HS_End_6*/
			//Version 1
			
			//Version 0
			writer.Write( ( int )m_Class );						//Characterization System
			writer.Write( ( int )m_Race );						//Characterization System
			writer.Write( ( int )m_Tribe );						//Characterization System
			writer.Write( ( int )m_Rank );						//Characterization System
			writer.Write( ( int ) m_RewardsClaimed);			//Level System
			writer.Write( ( int ) m_Level);						//Level System
			writer.Write( ( int ) m_SkillPts);					//Level System
			writer.Write( ( int ) m_Experience);				//Level System
			writer.Write( ( int ) m_Age);						//Level System
			writer.Write( ( int ) m_NextLevelUp);				//Level System
			writer.Write( m_Updated );							//Level System
			writer.Write( m_Bioenginer );						//Custom BOD System
			writer.Write( NextSmithBulkOrder );					//Custom BOD System
			writer.Write( NextTailorBulkOrder );				//Custom BOD System
			//writer.Write( NextFletcherBulkOrder );				//Custom BOD System
			//writer.Write( NextCarpenterBulkOrder );				//Custom BOD System
			//writer.Write( NextTinkerBulkOrder );				//Custom BOD System
			//writer.Write( NextTamingBulkOrder );				//Custom BOD System
			m_BOBFilter.Serialize( writer );					//Custom BOD System
			//m_TinkBOBFilter.Serialize( writer );				//Custom BOD System
			//m_TamingBOBFilter.Serialize( writer );				//Custom BOD System
			writer.Write( ( int ) m_Flags );					//Custom BOD System
			//Version 0
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch( version )
			{
/*				case 2:
					{
						Hallucinating = ( bool )reader.ReadBool();
						goto case 1;
					}*/
				case 1:
					{
						IsMarried = ( bool )reader.ReadBool();
						m_AllowGayMarriages = ( bool )reader.ReadBool();
						m_AllowCelestialMarriages = ( bool )reader.ReadBool();
						m_MarriageTime = reader.ReadDateTime();
						m_WifeLoc = reader.ReadPoint3D();
						m_HusbandLoc = reader.ReadPoint3D();
						m_MaritalStatus = ( MaritalStatus )reader.ReadInt();
						m_TypeOfMarriage = ( TypeOfMarriage )reader.ReadInt();
						m_FirstName = ( string )reader.ReadString();
						m_LastName = ( string )reader.ReadString();
						m_MaidenName = ( string )reader.ReadString();
						m_RankPoints = reader.ReadInt();
						
						/*GD13_HS_Start_5*/
						m_HuntMode = ( HuntMode )reader.ReadInt();
						m_HuntRank = ( HuntRank )reader.ReadInt();
						m_HuntReward = ( HuntReward )reader.ReadInt();
						m_Hunting = ( bool )reader.ReadBool();
						m_EasyKills = reader.ReadInt();
						m_HardKills = reader.ReadInt();
						m_ExtremeKills = reader.ReadInt();
						m_GodKills = reader.ReadInt();
						/*GD13_HS_End_5*/
						goto case 0;
					}
					
				case 0:
					{
						m_Class = ( PlayerClasses )reader.ReadInt();
						m_Race = ( PlayerRaces )reader.ReadInt();
						m_Tribe = ( PlayerTribes )reader.ReadInt();
						m_Rank = ( PlayerRanks )reader.ReadInt();
						m_RewardsClaimed = reader.ReadInt();
						m_Level = reader.ReadInt();
						m_SkillPts = reader.ReadInt();
						m_Experience = reader.ReadInt();
						m_Age = reader.ReadInt();
						m_NextLevelUp = reader.ReadInt();
						m_Updated = reader.ReadBool();
						m_Bioenginer = reader.ReadBool();
						NextSmithBulkOrder = reader.ReadTimeSpan();
						NextTailorBulkOrder = reader.ReadTimeSpan();
						//NextFletcherBulkOrder = reader.ReadTimeSpan();
						//NextCarpenterBulkOrder = reader.ReadTimeSpan();
						//NextTinkerBulkOrder = reader.ReadTimeSpan();
						//NextTamingBulkOrder = reader.ReadTimeSpan();
						m_BOBFilter = new Engines.BulkOrders.BOBFilter( reader );
						//m_TinkBOBFilter = new Engines.BulkOrders.TinkBOBFilter( reader );
						//m_TamingBOBFilter = new Engines.BulkOrders.TamingBOBFilter( reader );
						m_Flags = (MyPlayerFlag)reader.ReadInt();
						break;
					}
			}
			
			if ( m_BOBFilter == null )
				m_BOBFilter = new Engines.BulkOrders.BOBFilter();
			
/*			if ( m_TinkBOBFilter == null )
				m_TinkBOBFilter = new Engines.BulkOrders.TinkBOBFilter();
			
			if ( m_TamingBOBFilter == null )
				m_TamingBOBFilter = new Engines.BulkOrders.TamingBOBFilter();*/
		}
	}
}
