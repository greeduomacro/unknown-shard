///////////////////////////
//       By Nerun        //
//    Engine v5.0.6      //
///////////////////////////

using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class PremiumSpawner : Item
	{
		private int m_Team;
		private int m_HomeRange;
		private int m_SpawnRange;
		private int m_SpawnID;
		private int m_DeSpawn;
		private int m_PlayerRangeSensitive;
		private int m_Count;
		private int m_SubCountA;
		private int m_SubCountB;
		private int m_SubCountC;
		private int m_SubCountD;
		private int m_SubCountE;
		private TimeSpan m_MinDelay;
		private TimeSpan m_MaxDelay;
		private ArrayList m_Creatures;
		private ArrayList m_CreaturesName;
		private ArrayList m_SubSpawnerA;
		private ArrayList m_SubCreaturesA;
		private ArrayList m_SubSpawnerB;
		private ArrayList m_SubCreaturesB;
		private ArrayList m_SubSpawnerC;
		private ArrayList m_SubCreaturesC;
		private ArrayList m_SubSpawnerD;
		private ArrayList m_SubCreaturesD;
		private ArrayList m_SubSpawnerE;
		private ArrayList m_SubCreaturesE;
		private DateTime m_End;
		private InternalTimer m_Timer;
		private bool m_Running;
		private bool m_Group;
		private WayPoint m_WayPoint;

		public bool IsFull{ get{ return ( m_Creatures != null && m_Creatures.Count >= m_Count ); } }
		public bool IsFulla{ get{ return ( m_SubCreaturesA != null && m_SubCreaturesA.Count >= m_SubCountA ); } }
		public bool IsFullb{ get{ return ( m_SubCreaturesB != null && m_SubCreaturesB.Count >= m_SubCountB ); } }
		public bool IsFullc{ get{ return ( m_SubCreaturesC != null && m_SubCreaturesC.Count >= m_SubCountC ); } }
		public bool IsFulld{ get{ return ( m_SubCreaturesD != null && m_SubCreaturesD.Count >= m_SubCountD ); } }
		public bool IsFulle{ get{ return ( m_SubCreaturesE != null && m_SubCreaturesE.Count >= m_SubCountE ); } }

		public ArrayList SubSpawnerA
		{
			get { return m_SubSpawnerA; }
			set
			{
				m_SubSpawnerA = value;
				if ( m_SubSpawnerA.Count < 1 )
					Stop();

				InvalidateProperties();
			}
		}

		public ArrayList SubSpawnerB
		{
			get { return m_SubSpawnerB; }
			set
			{
				m_SubSpawnerB = value;
				if ( m_SubSpawnerB.Count < 1 )
					Stop();

				InvalidateProperties();
			}
		}

		public ArrayList SubSpawnerC
		{
			get { return m_SubSpawnerC; }
			set
			{
				m_SubSpawnerC = value;
				if ( m_SubSpawnerC.Count < 1 )
					Stop();

				InvalidateProperties();
			}
		}

		public ArrayList SubSpawnerD
		{
			get { return m_SubSpawnerD; }
			set
			{
				m_SubSpawnerD = value;
				if ( m_SubSpawnerD.Count < 1 )
					Stop();

				InvalidateProperties();
			}
		}

		public ArrayList SubSpawnerE
		{
			get { return m_SubSpawnerE; }
			set
			{
				m_SubSpawnerE = value;
				if ( m_SubSpawnerE.Count < 1 )
					Stop();

				InvalidateProperties();
			}
		}

		public ArrayList CreaturesName
		{
			get { return m_CreaturesName; }
			set
			{
				m_CreaturesName = value;
				if ( m_CreaturesName.Count < 1 )
					Stop();

				InvalidateProperties();
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Count
		{
			get { return m_Count; }
			set { m_Count = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SubCountA
		{
			get { return m_SubCountA; }
			set { m_SubCountA = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SubCountB
		{
			get { return m_SubCountB; }
			set { m_SubCountB = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SubCountC
		{
			get { return m_SubCountC; }
			set { m_SubCountC = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SubCountD
		{
			get { return m_SubCountD; }
			set { m_SubCountD = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SubCountE
		{
			get { return m_SubCountE; }
			set { m_SubCountE = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint WayPoint
		{
			get
			{
				return m_WayPoint;
			}
			set
			{
				m_WayPoint = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Running
		{
			get { return m_Running; }
			set
			{
				if ( value )
					Start();

				else
					Stop();

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int HomeRange
		{
			get { return m_HomeRange; }
			set { m_HomeRange = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SpawnRange
		{
			get { return m_SpawnRange; }
			set { m_SpawnRange = ((value > m_HomeRange)? m_HomeRange : value); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SpawnID
		{
			get { return m_SpawnID; }
			set { m_SpawnID = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int DeSpawned
		{
			get { return m_DeSpawn; }
			set { m_DeSpawn = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SmartPRS
		{
			get { return m_PlayerRangeSensitive; }
			set { m_PlayerRangeSensitive = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Team
		{
			get { return m_Team; }
			set { m_Team = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan MinDelay
		{
			get { return m_MinDelay; }
			set { m_MinDelay = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan MaxDelay
		{
			get { return m_MaxDelay; }
			set { m_MaxDelay = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextSpawn
		{
			get
			{
				if ( m_Running )
					return m_End - DateTime.Now;
				else
					return TimeSpan.FromSeconds( 0 );
			}
			set
			{
				Start();
				DoTimer( value );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Group
		{
			get { return m_Group; }
			set { m_Group = value; InvalidateProperties(); }
		}

		[Constructable]
		public PremiumSpawner( int amount, int minDelay, int maxDelay, int team, int homeRange, string creatureName, string subSpawnerA, string subSpawnerB, string subSpawnerC, string subSpawnerD, string subSpawnerE, int subamountA, int subamountB, int subamountC, int subamountD, int subamountE ) : base( 0x1f13 )
		{
			ArrayList creaturesName = new ArrayList();
			creaturesName.Add( creatureName.ToLower() );

			ArrayList subSpawnerAA = new ArrayList();
			subSpawnerAA.Add( subSpawnerA.ToLower() );

			ArrayList subSpawnerBB = new ArrayList();
			subSpawnerBB.Add( subSpawnerB.ToLower() );

			ArrayList subSpawnerCC = new ArrayList();
			subSpawnerCC.Add( subSpawnerC.ToLower() );

			ArrayList subSpawnerDD = new ArrayList();
			subSpawnerDD.Add( subSpawnerD.ToLower() );

			ArrayList subSpawnerEE = new ArrayList();
			subSpawnerEE.Add( subSpawnerE.ToLower() );

			InitSpawn( amount, TimeSpan.FromMinutes( minDelay ), TimeSpan.FromMinutes( maxDelay ), team, homeRange, homeRange, homeRange, creaturesName, subSpawnerAA, subSpawnerBB, subSpawnerCC, subSpawnerDD, subSpawnerEE, subamountA, subamountB, subamountC, subamountD, subamountE );
		}

		[Constructable]
		public PremiumSpawner( string creatureName ) : base( 0x1f13 )
		{
			ArrayList creaturesName = new ArrayList();
			creaturesName.Add( creatureName.ToLower() );

			ArrayList subSpawnerAA = new ArrayList();
			ArrayList subSpawnerBB = new ArrayList();
			ArrayList subSpawnerCC = new ArrayList();
			ArrayList subSpawnerDD = new ArrayList();
			ArrayList subSpawnerEE = new ArrayList();

			InitSpawn( 1, TimeSpan.FromMinutes( 5 ), TimeSpan.FromMinutes( 10 ), 0, 4, 4, 1, creaturesName, subSpawnerAA, subSpawnerBB, subSpawnerCC, subSpawnerDD, subSpawnerEE, 0, 0, 0, 0, 0 );
		}

		[Constructable]
		public PremiumSpawner() : base( 0x1f13 )
		{
			ArrayList creaturesName = new ArrayList();
			ArrayList subSpawnerAA = new ArrayList();
			ArrayList subSpawnerBB = new ArrayList();
			ArrayList subSpawnerCC = new ArrayList();
			ArrayList subSpawnerDD = new ArrayList();
			ArrayList subSpawnerEE = new ArrayList();

			InitSpawn( 1, TimeSpan.FromMinutes( 5 ), TimeSpan.FromMinutes( 10 ), 0, 4, 4, 1, creaturesName, subSpawnerAA, subSpawnerBB, subSpawnerCC, subSpawnerDD, subSpawnerEE, 0, 0, 0, 0, 0 );
		}

		public PremiumSpawner( int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, int spawnRange, int spawnID, ArrayList creaturesName, ArrayList subSpawnerAA, ArrayList subSpawnerBB, ArrayList subSpawnerCC, ArrayList subSpawnerDD, ArrayList subSpawnerEE, int subamountA, int subamountB, int subamountC, int subamountD, int subamountE ) : base( 0x1f13 )
		{
			InitSpawn( amount, minDelay, maxDelay, team, homeRange, spawnRange, spawnID, creaturesName, subSpawnerAA, subSpawnerBB, subSpawnerCC, subSpawnerDD, subSpawnerEE, subamountA, subamountB, subamountC, subamountD, subamountE );
		}

		public void InitSpawn( int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, int spawnRange, int spawnID, ArrayList creaturesName, ArrayList subSpawnerAA, ArrayList subSpawnerBB, ArrayList subSpawnerCC, ArrayList subSpawnerDD, ArrayList subSpawnerEE, int subamountA, int subamountB, int subamountC, int subamountD, int subamountE )
		{
			Visible = false;
			Movable = false;
			m_Running = true;
			m_Group = false;
			Name = "PremiumSpawner";
			m_MinDelay = minDelay;
			m_MaxDelay = maxDelay;
			m_Count = amount;
			m_SubCountA = subamountA;
			m_SubCountB = subamountB;
			m_SubCountC = subamountC;
			m_SubCountD = subamountD;
			m_SubCountE = subamountE;
			m_Team = team;
			m_HomeRange = homeRange;
			m_SpawnRange = ((spawnRange > homeRange)? homeRange : spawnRange);
			m_SpawnID = spawnID;
			m_PlayerRangeSensitive = 1;
			m_CreaturesName = creaturesName;
			m_SubSpawnerA = subSpawnerAA;
			m_SubSpawnerB = subSpawnerBB;
			m_SubSpawnerC = subSpawnerCC;
			m_SubSpawnerD = subSpawnerDD;
			m_SubSpawnerE = subSpawnerEE;
			m_Creatures = new ArrayList();
			m_SubCreaturesA = new ArrayList();
			m_SubCreaturesB = new ArrayList();
			m_SubCreaturesC = new ArrayList();
			m_SubCreaturesD = new ArrayList();
			m_SubCreaturesE = new ArrayList();
			DoTimer( TimeSpan.FromSeconds( 1 ) );
		}
			
		public PremiumSpawner( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.AccessLevel < AccessLevel.GameMaster )
				return;

			PremiumSpawnerGump g = new PremiumSpawnerGump( this );
			from.SendGump( g );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_Running )
			{
				list.Add( 1060742 ); // active

				list.Add( 1060656, m_Count.ToString() );
				list.Add( 1061169, m_HomeRange.ToString() );

				list.Add( 1060662, "SpawnRange\t{0}", m_SpawnRange.ToString() );
				list.Add( 1060663, "SpawnID\t{0}", m_SpawnID.ToString() );

				list.Add( 1060658, "group\t{0}", m_Group );
				list.Add( 1060659, "team\t{0}", m_Team );
				list.Add( 1060660, "speed\t{0} to {1}", m_MinDelay, m_MaxDelay );

				for ( int i = 0; i < 3 && i < m_CreaturesName.Count; ++i )
					list.Add( 1060661 + i, "{0}\t{1}", m_CreaturesName[i], CountCreatures( (string)m_CreaturesName[i] ) );
			}
			else
			{
				list.Add( 1060743 ); // inactive
			}
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if ( m_Running )
				LabelTo( from, "[Running]" );
			else
				LabelTo( from, "[Off]" );
		}

		public void Start()
		{
			if ( !m_Running )
			{
				if ( m_CreaturesName.Count > 0 || m_SubSpawnerA.Count > 0 || m_SubSpawnerB.Count > 0 || m_SubSpawnerC.Count > 0 || m_SubSpawnerD.Count > 0 || m_SubSpawnerE.Count > 0 )
				{
					m_Running = true;
					DoTimer();
				}
			}
		}

		public void Stop()
		{
			if ( m_Running )
			{
				m_Timer.Stop();
				m_Running = false;
			}
		}

		public void Defrag()
		{
			bool removed = false;

			for ( int i = 0; i < m_Creatures.Count; ++i )
			{
				object o = m_Creatures[i];

				if ( o is Item )
				{
					Item item = (Item)o;

					if ( item.Deleted || item.Parent != null )
					{
						m_Creatures.RemoveAt( i );
						--i;
						removed = true;
					}
				}
				else if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					if ( m.Deleted )
					{
						m_Creatures.RemoveAt( i );
						--i;
						removed = true;
					}
					else if ( m is BaseCreature )
					{
						if ( ((BaseCreature)m).Controlled || ((BaseCreature)m).IsStabled )
						{
							m_Creatures.RemoveAt( i );
							--i;
							removed = true;
						}
					}
				}
				else
				{
					m_Creatures.RemoveAt( i );
					--i;
					removed = true;
				}
			}

			for ( int i = 0; i < m_SubCreaturesA.Count; ++i )
			{
				object o = m_SubCreaturesA[i];

				if ( o is Item )
				{
					Item item = (Item)o;

					if ( item.Deleted || item.Parent != null )
					{
						m_SubCreaturesA.RemoveAt( i );
						--i;
						removed = true;
					}
				}
				else if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					if ( m.Deleted )
					{
						m_SubCreaturesA.RemoveAt( i );
						--i;
						removed = true;
					}
					else if ( m is BaseCreature )
					{
						if ( ((BaseCreature)m).Controlled || ((BaseCreature)m).IsStabled )
						{
							m_SubCreaturesA.RemoveAt( i );
							--i;
							removed = true;
						}
					}
				}
				else
				{
					m_SubCreaturesA.RemoveAt( i );
					--i;
					removed = true;
				}
			}

			for ( int i = 0; i < m_SubCreaturesB.Count; ++i )
			{
				object o = m_SubCreaturesB[i];

				if ( o is Item )
				{
					Item item = (Item)o;

					if ( item.Deleted || item.Parent != null )
					{
						m_SubCreaturesB.RemoveAt( i );
						--i;
						removed = true;
					}
				}
				else if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					if ( m.Deleted )
					{
						m_SubCreaturesB.RemoveAt( i );
						--i;
						removed = true;
					}
					else if ( m is BaseCreature )
					{
						if ( ((BaseCreature)m).Controlled || ((BaseCreature)m).IsStabled )
						{
							m_SubCreaturesB.RemoveAt( i );
							--i;
							removed = true;
						}
					}
				}
				else
				{
					m_SubCreaturesB.RemoveAt( i );
					--i;
					removed = true;
				}
			}

			for ( int i = 0; i < m_SubCreaturesC.Count; ++i )
			{
				object o = m_SubCreaturesC[i];

				if ( o is Item )
				{
					Item item = (Item)o;

					if ( item.Deleted || item.Parent != null )
					{
						m_SubCreaturesC.RemoveAt( i );
						--i;
						removed = true;
					}
				}
				else if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					if ( m.Deleted )
					{
						m_SubCreaturesC.RemoveAt( i );
						--i;
						removed = true;
					}
					else if ( m is BaseCreature )
					{
						if ( ((BaseCreature)m).Controlled || ((BaseCreature)m).IsStabled )
						{
							m_SubCreaturesC.RemoveAt( i );
							--i;
							removed = true;
						}
					}
				}
				else
				{
					m_SubCreaturesC.RemoveAt( i );
					--i;
					removed = true;
				}
			}

			for ( int i = 0; i < m_SubCreaturesD.Count; ++i )
			{
				object o = m_SubCreaturesD[i];

				if ( o is Item )
				{
					Item item = (Item)o;

					if ( item.Deleted || item.Parent != null )
					{
						m_SubCreaturesD.RemoveAt( i );
						--i;
						removed = true;
					}
				}
				else if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					if ( m.Deleted )
					{
						m_SubCreaturesD.RemoveAt( i );
						--i;
						removed = true;
					}
					else if ( m is BaseCreature )
					{
						if ( ((BaseCreature)m).Controlled || ((BaseCreature)m).IsStabled )
						{
							m_SubCreaturesD.RemoveAt( i );
							--i;
							removed = true;
						}
					}
				}
				else
				{
					m_SubCreaturesD.RemoveAt( i );
					--i;
					removed = true;
				}
			}

			for ( int i = 0; i < m_SubCreaturesE.Count; ++i )
			{
				object o = m_SubCreaturesE[i];

				if ( o is Item )
				{
					Item item = (Item)o;

					if ( item.Deleted || item.Parent != null )
					{
						m_SubCreaturesE.RemoveAt( i );
						--i;
						removed = true;
					}
				}
				else if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					if ( m.Deleted )
					{
						m_SubCreaturesE.RemoveAt( i );
						--i;
						removed = true;
					}
					else if ( m is BaseCreature )
					{
						if ( ((BaseCreature)m).Controlled || ((BaseCreature)m).IsStabled )
						{
							m_SubCreaturesE.RemoveAt( i );
							--i;
							removed = true;
						}
					}
				}
				else
				{
					m_SubCreaturesE.RemoveAt( i );
					--i;
					removed = true;
				}
			}

			if ( removed )
				InvalidateProperties();
		}

		public void OnTick()
		{
			DoTimer();

			if ( m_Group )
			{
				Defrag();

				if  ( m_Creatures.Count == 0 || m_SubCreaturesA.Count == 0 || m_SubCreaturesB.Count == 0 || m_SubCreaturesC.Count == 0 || m_SubCreaturesD.Count == 0 || m_SubCreaturesE.Count == 0 )
				{
					Respawn();
				}
				else
				{
					return;
				}
			}
			else
			{
				Spawn();
			}
		}
		
		public void Respawn()
		{
			RemoveCreatures();
			RemoveCreaturesA();
			RemoveCreaturesB();
			RemoveCreaturesC();
			RemoveCreaturesD();
			RemoveCreaturesE();

			for ( int i = 0; i < m_Count; i++ )
				Spawn();
			for ( int i = 0; i < m_SubCountA; i++ )
				Spawn();
			for ( int i = 0; i < m_SubCountB; i++ )
				Spawn();
			for ( int i = 0; i < m_SubCountC; i++ )
				Spawn();
			for ( int i = 0; i < m_SubCountD; i++ )
				Spawn();
			for ( int i = 0; i < m_SubCountE; i++ )
				Spawn();
		}

//------------------------------------------
// SMART PLAYER RANGE SENSITIVE
		public void Spawn()
		{
			if ( this.SmartPRS != 0 )
			{
				ArrayList mobs = new ArrayList();
				ArrayList mobsdel = new ArrayList();
				ArrayList itemsdel = new ArrayList();

				int SpawnerAppear = this.SpawnRange + 60; //60 = squares traveled to horse in 5 seconds

				// Disable/Uncomment: Vendors (125, 225, 312, 405, 504), TownsPeople (123, 223)

				if ( this.SpawnID != 125 && this.SpawnID != 225 && this.SpawnID != 312 && this.SpawnID != 405 && this.SpawnID != 504 && this.SpawnID != 123 && this.SpawnID != 223 )
				{ 
					foreach ( Mobile m in this.GetMobilesInRange( SpawnerAppear ) )
					{
						if( m is PlayerMobile && m.AccessLevel == AccessLevel.Player || m is PlayerMobile && m.AccessLevel > AccessLevel.Player && m.Hidden == false ) //if player or not hidden GM
						{
							mobs.Add( m );
						}
					}

					if ( mobs.Count > 0 ) //there is somebody in the SpawnerAppear range
					{
						if( this.DeSpawned == 1 ) // there isn't creature spawned, spawn all
						{
							this.DeSpawned = 0;

							for ( int i = 0; i <= this.Count; ++i ) // while i <= number of creatures to spawn, do what has in the brackets
							{
								if ( m_CreaturesName.Count > 0 )
									Spawn( Utility.Random( m_CreaturesName.Count ) );
								if ( m_SubSpawnerA.Count > 0 )
									SpawnA( Utility.Random( m_SubSpawnerA.Count ) );
								if ( m_SubSpawnerB.Count > 0 )
									SpawnB( Utility.Random( m_SubSpawnerB.Count ) );
								if ( m_SubSpawnerC.Count > 0 )
									SpawnC( Utility.Random( m_SubSpawnerC.Count ) );
								if ( m_SubSpawnerD.Count > 0 )
									SpawnD( Utility.Random( m_SubSpawnerD.Count ) );
								if ( m_SubSpawnerE.Count > 0 )
									SpawnE( Utility.Random( m_SubSpawnerE.Count ) );
							}
						}
						else // there is creature spawned, spawn one
						{
							if ( m_CreaturesName.Count > 0 )
								Spawn( Utility.Random( m_CreaturesName.Count ) );
							if ( m_SubSpawnerA.Count > 0 )
								SpawnA( Utility.Random( m_SubSpawnerA.Count ) );
							if ( m_SubSpawnerB.Count > 0 )
								SpawnB( Utility.Random( m_SubSpawnerB.Count ) );
							if ( m_SubSpawnerC.Count > 0 )
								SpawnC( Utility.Random( m_SubSpawnerC.Count ) );
							if ( m_SubSpawnerD.Count > 0 )
								SpawnD( Utility.Random( m_SubSpawnerD.Count ) );
							if ( m_SubSpawnerE.Count > 0 )
								SpawnE( Utility.Random( m_SubSpawnerE.Count ) );
						}
					}

					else
					{
						this.NextSpawn = TimeSpan.FromSeconds( 5 );

						if ( this.DeSpawned != 1 ) // there is creature spawned
						{
							this.DeSpawned = 1; // seted to "no one"

							foreach ( Mobile m in this.GetMobilesInRange( SpawnerAppear ) )
							{
								if( m is BaseCreature || m is TownCrier )
								{
									mobsdel.Add( m );
								}
							}

							foreach ( Mobile mDelA in mobsdel ) // creatures despawn
							{
								for ( int i = 0; i < m_Creatures.Count; i++ )
								{
									if ( mDelA == (object)m_Creatures[i] )
										mDelA.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesA.Count; i++ )
								{
									if ( mDelA == (object)m_SubCreaturesA[i] )
										mDelA.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesB.Count; i++ )
								{
									if ( mDelA == (object)m_SubCreaturesB[i] )
										mDelA.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesC.Count; i++ )
								{
									if ( mDelA == (object)m_SubCreaturesC[i] )
										mDelA.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesD.Count; i++ )
								{
									if ( mDelA == (object)m_SubCreaturesD[i] )
										mDelA.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesE.Count; i++ )
								{
									if ( mDelA == (object)m_SubCreaturesE[i] )
										mDelA.Delete();
								}
							}

							foreach ( Item item in this.GetItemsInRange( this.HomeRange ) )
							{
								itemsdel.Add( item );
							}

							foreach ( Item itemDel in itemsdel ) // items despawn
							{
								for ( int i = 0; i < m_Creatures.Count; i++ )
								{
									if ( itemDel == (object)m_Creatures[i] )
										itemDel.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesA.Count; i++ )
								{
									if ( itemDel == (object)m_SubCreaturesA[i] )
										itemDel.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesB.Count; i++ )
								{
									if ( itemDel == (object)m_SubCreaturesB[i] )
										itemDel.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesC.Count; i++ )
								{
									if ( itemDel == (object)m_SubCreaturesC[i] )
										itemDel.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesD.Count; i++ )
								{
									if ( itemDel == (object)m_SubCreaturesD[i] )
										itemDel.Delete();
								}
								for ( int i = 0; i < m_SubCreaturesE.Count; i++ )
								{
									if ( itemDel == (object)m_SubCreaturesE[i] )
										itemDel.Delete();
								}
							}
						}
					}
				}

				else
				{
					if ( m_CreaturesName.Count > 0)
						Spawn( Utility.Random( m_CreaturesName.Count ) );
					if ( m_SubSpawnerA.Count > 0)
						SpawnA( Utility.Random( m_SubSpawnerA.Count ) );
					if ( m_SubSpawnerB.Count > 0)
						SpawnB( Utility.Random( m_SubSpawnerB.Count ) );
					if ( m_SubSpawnerC.Count > 0)
						SpawnC( Utility.Random( m_SubSpawnerC.Count ) );
					if ( m_SubSpawnerD.Count > 0)
						SpawnD( Utility.Random( m_SubSpawnerD.Count ) );
					if ( m_SubSpawnerE.Count > 0)
						SpawnE( Utility.Random( m_SubSpawnerE.Count ) );
				}
			}

			else
			{
				this.SmartPRS = 0;

				if ( m_CreaturesName.Count > 0 )
					Spawn( Utility.Random( m_CreaturesName.Count ) );
				if ( m_SubSpawnerA.Count > 0)
					SpawnA( Utility.Random( m_SubSpawnerA.Count ) );
				if ( m_SubSpawnerB.Count > 0)
					SpawnB( Utility.Random( m_SubSpawnerB.Count ) );
				if ( m_SubSpawnerC.Count > 0)
					SpawnC( Utility.Random( m_SubSpawnerC.Count ) );
				if ( m_SubSpawnerD.Count > 0)
					SpawnD( Utility.Random( m_SubSpawnerD.Count ) );
				if ( m_SubSpawnerE.Count > 0)
					SpawnE( Utility.Random( m_SubSpawnerE.Count ) );
			}
		}
//end: Smart P.R.S.
//------------------------------------------

		public void Spawn( string creatureName )
		{
			for ( int i = 0; i < m_CreaturesName.Count; i++ )
			{
				if ( (string)m_CreaturesName[i] == creatureName )
				{
					Spawn( i );
					break;
				}
			}
		}

		public void SpawnA( string subSpawnerA )
		{
			for ( int i = 0; i < m_SubSpawnerA.Count; i++ )
			{
				if ( (string)m_SubSpawnerA[i] == subSpawnerA )
				{
					SpawnA( i );
					break;
				}
			}
		}

		public void SpawnB( string subSpawnerB )
		{
			for ( int i = 0; i < m_SubSpawnerB.Count; i++ )
			{
				if ( (string)m_SubSpawnerB[i] == subSpawnerB )
				{
					SpawnB( i );
					break;
				}
			}
		}

		public void SpawnC( string subSpawnerC )
		{
			for ( int i = 0; i < m_SubSpawnerC.Count; i++ )
			{
				if ( (string)m_SubSpawnerC[i] == subSpawnerC )
				{
					SpawnC( i );
					break;
				}
			}
		}

		public void SpawnD( string subSpawnerD )
		{
			for ( int i = 0; i < m_SubSpawnerD.Count; i++ )
			{
				if ( (string)m_SubSpawnerD[i] == subSpawnerD )
				{
					SpawnD( i );
					break;
				}
			}
		}

		public void SpawnE( string subSpawnerE )
		{
			for ( int i = 0; i < m_SubSpawnerE.Count; i++ )
			{
				if ( (string)m_SubSpawnerE[i] == subSpawnerE )
				{
					SpawnE( i );
					break;
				}
			}
		}

		public void Spawn( int index )
		{
			Map map = Map;

			if ( map == null || map == Map.Internal || m_CreaturesName.Count == 0 || index >= m_CreaturesName.Count || Parent != null )
				return;

			Defrag();

			if ( m_Creatures.Count >= m_Count )
				return;

			Type type = SpawnerType.GetType( (string)m_CreaturesName[index] );

			if ( type != null )
			{
				try
				{
					object o = Activator.CreateInstance( type );

					if ( o is Mobile )
					{
						Mobile m = (Mobile)o;

						m_Creatures.Add( m );
						
						Point3D loc = ( /*m is BaseVendor ? this.Location :*/ GetSpawnPosition() );

						m.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						m.MoveToWorld( loc, map );

						if ( m is BaseCreature )
						{
							BaseCreature c = (BaseCreature)m;

							c.RangeHome = m_HomeRange;

							c.CurrentWayPoint = m_WayPoint;

							if ( m_Team > 0 )
								c.Team = m_Team;

							c.Home = this.Location;
						}

						m.OnAfterSpawn();
					}
					else if ( o is Item )
					{
						Item item = (Item)o;

						m_Creatures.Add( item );

						Point3D loc = GetSpawnPosition();

						item.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						item.MoveToWorld( loc, map );

						item.OnAfterSpawn();
					}
				}
				catch
				{
				}
			}
		}

		public void SpawnA( int index )
		{
			Map map = Map;

			if ( map == null || map == Map.Internal || m_SubSpawnerA.Count == 0 || index >= m_SubSpawnerA.Count || Parent != null )
				return;

			Defrag();

			if ( m_SubCreaturesA.Count >= m_SubCountA )
				return;

			Type type = SpawnerType.GetType( (string)m_SubSpawnerA[index] );

			if ( type != null )
			{
				try
				{
					object o = Activator.CreateInstance( type );

					if ( o is Mobile )
					{
						Mobile m = (Mobile)o;

						m_SubCreaturesA.Add( m );
						
						Point3D loc = ( /*m is BaseVendor ? this.Location :*/ GetSpawnPosition() );

						m.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						m.MoveToWorld( loc, map );

						if ( m is BaseCreature )
						{
							BaseCreature c = (BaseCreature)m;

							c.RangeHome = m_HomeRange;

							c.CurrentWayPoint = m_WayPoint;

							if ( m_Team > 0 )
								c.Team = m_Team;

							c.Home = this.Location;
						}

						m.OnAfterSpawn();
					}
					else if ( o is Item )
					{
						Item item = (Item)o;

						m_SubCreaturesA.Add( item );

						Point3D loc = GetSpawnPosition();

						item.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						item.MoveToWorld( loc, map );

						item.OnAfterSpawn();
					}
				}
				catch
				{
				}
			}
		}

		public void SpawnB( int index )
		{
			Map map = Map;

			if ( map == null || map == Map.Internal || m_SubSpawnerB.Count == 0 || index >= m_SubSpawnerB.Count || Parent != null )
				return;

			Defrag();

			if ( m_SubCreaturesB.Count >= m_SubCountB )
				return;

			Type type = SpawnerType.GetType( (string)m_SubSpawnerB[index] );

			if ( type != null )
			{
				try
				{
					object o = Activator.CreateInstance( type );

					if ( o is Mobile )
					{
						Mobile m = (Mobile)o;

						m_SubCreaturesB.Add( m );
						
						Point3D loc = ( /*m is BaseVendor ? this.Location :*/ GetSpawnPosition() );

						m.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						m.MoveToWorld( loc, map );

						if ( m is BaseCreature )
						{
							BaseCreature c = (BaseCreature)m;

							c.RangeHome = m_HomeRange;

							c.CurrentWayPoint = m_WayPoint;

							if ( m_Team > 0 )
								c.Team = m_Team;

							c.Home = this.Location;
						}

						m.OnAfterSpawn();
					}
					else if ( o is Item )
					{
						Item item = (Item)o;

						m_SubCreaturesB.Add( item );

						Point3D loc = GetSpawnPosition();

						item.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						item.MoveToWorld( loc, map );

						item.OnAfterSpawn();
					}
				}
				catch
				{
				}
			}
		}

		public void SpawnC( int index )
		{
			Map map = Map;

			if ( map == null || map == Map.Internal || m_SubSpawnerC.Count == 0 || index >= m_SubSpawnerC.Count || Parent != null )
				return;

			Defrag();

			if ( m_SubCreaturesC.Count >= m_SubCountC )
				return;

			Type type = SpawnerType.GetType( (string)m_SubSpawnerC[index] );

			if ( type != null )
			{
				try
				{
					object o = Activator.CreateInstance( type );

					if ( o is Mobile )
					{
						Mobile m = (Mobile)o;

						m_SubCreaturesC.Add( m );
						
						Point3D loc = ( /*m is BaseVendor ? this.Location :*/ GetSpawnPosition() );

						m.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						m.MoveToWorld( loc, map );

						if ( m is BaseCreature )
						{
							BaseCreature c = (BaseCreature)m;

							c.RangeHome = m_HomeRange;

							c.CurrentWayPoint = m_WayPoint;

							if ( m_Team > 0 )
								c.Team = m_Team;

							c.Home = this.Location;
						}

						m.OnAfterSpawn();
					}
					else if ( o is Item )
					{
						Item item = (Item)o;

						m_SubCreaturesC.Add( item );

						Point3D loc = GetSpawnPosition();

						item.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						item.MoveToWorld( loc, map );

						item.OnAfterSpawn();
					}
				}
				catch
				{
				}
			}
		}

		public void SpawnD( int index )
		{
			Map map = Map;

			if ( map == null || map == Map.Internal || m_SubSpawnerD.Count == 0 || index >= m_SubSpawnerD.Count || Parent != null )
				return;

			Defrag();

			if ( m_SubCreaturesD.Count >= m_SubCountD )
				return;

			Type type = SpawnerType.GetType( (string)m_SubSpawnerD[index] );

			if ( type != null )
			{
				try
				{
					object o = Activator.CreateInstance( type );

					if ( o is Mobile )
					{
						Mobile m = (Mobile)o;

						m_SubCreaturesD.Add( m );
						
						Point3D loc = ( /*m is BaseVendor ? this.Location :*/ GetSpawnPosition() );

						m.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						m.MoveToWorld( loc, map );

						if ( m is BaseCreature )
						{
							BaseCreature c = (BaseCreature)m;

							c.RangeHome = m_HomeRange;

							c.CurrentWayPoint = m_WayPoint;

							if ( m_Team > 0 )
								c.Team = m_Team;

							c.Home = this.Location;
						}

						m.OnAfterSpawn();
					}
					else if ( o is Item )
					{
						Item item = (Item)o;

						m_SubCreaturesD.Add( item );

						Point3D loc = GetSpawnPosition();

						item.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						item.MoveToWorld( loc, map );

						item.OnAfterSpawn();
					}
				}
				catch
				{
				}
			}
		}

		public void SpawnE( int index )
		{
			Map map = Map;

			if ( map == null || map == Map.Internal || m_SubSpawnerE.Count == 0 || index >= m_SubSpawnerE.Count || Parent != null )
				return;

			Defrag();

			if ( m_SubCreaturesE.Count >= m_SubCountE )
				return;

			Type type = SpawnerType.GetType( (string)m_SubSpawnerE[index] );

			if ( type != null )
			{
				try
				{
					object o = Activator.CreateInstance( type );

					if ( o is Mobile )
					{
						Mobile m = (Mobile)o;

						m_SubCreaturesE.Add( m );
						
						Point3D loc = ( /*m is BaseVendor ? this.Location :*/ GetSpawnPosition() );

						m.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						m.MoveToWorld( loc, map );

						if ( m is BaseCreature )
						{
							BaseCreature c = (BaseCreature)m;

							c.RangeHome = m_HomeRange;

							c.CurrentWayPoint = m_WayPoint;

							if ( m_Team > 0 )
								c.Team = m_Team;

							c.Home = this.Location;
						}

						m.OnAfterSpawn();
					}
					else if ( o is Item )
					{
						Item item = (Item)o;

						m_SubCreaturesE.Add( item );

						Point3D loc = GetSpawnPosition();

						item.OnBeforeSpawn( loc, map );
						InvalidateProperties();

						item.MoveToWorld( loc, map );

						item.OnAfterSpawn();
					}
				}
				catch
				{
				}
			}
		}

		public Point3D GetSpawnPosition()
		{
			Map map = Map;

			if ( map == null )
				return Location;

			// Try 10 times to find a Spawnable location.
			for ( int i = 0; i < 10; i++ )
			{
				int x = Location.X + (Utility.Random( (m_SpawnRange * 2) + 1 ) - m_SpawnRange);
				int y = Location.Y + (Utility.Random( (m_SpawnRange * 2) + 1 ) - m_SpawnRange);
				int z = Map.GetAverageZ( x, y );

				if ( this.SpawnID == 118 || this.SpawnID == 218 ) // Sea Creatures
				{
					if ( Map.CanFit( x, y, this.Z, 5, true, false, false ) )
						return new Point3D( x, y, this.Z );
					else if ( Map.CanFit( x, y, z, 5, true, false, false ) )
						return new Point3D( x, y, z );
				}

				else // Land Creatures
				{
					if ( Map.CanSpawnMobile( new Point2D( x, y ), this.Z ) )
						return new Point3D( x, y, this.Z );
					else if ( Map.CanSpawnMobile( new Point2D( x, y ), z ) )
						return new Point3D( x, y, z );
				}
			}

			return this.Location;
		}

		public void DoTimer()
		{
			if ( !m_Running )
				return;

			int minSeconds = (int)m_MinDelay.TotalSeconds;
			int maxSeconds = (int)m_MaxDelay.TotalSeconds;

			TimeSpan delay = TimeSpan.FromSeconds( Utility.RandomMinMax( minSeconds, maxSeconds ) );
			DoTimer( delay );
		}

		public void DoTimer( TimeSpan delay )
		{
			if ( !m_Running )
				return;

			m_End = DateTime.Now + delay;

			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = new InternalTimer( this, delay );
			m_Timer.Start();
		}

		private class InternalTimer : Timer
		{
			private PremiumSpawner m_PremiumSpawner;

			public InternalTimer( PremiumSpawner spawner, TimeSpan delay ) : base( delay )
			{
				if ( spawner.IsFull || spawner.IsFulla || spawner.IsFullb || spawner.IsFullc || spawner.IsFulld || spawner.IsFulle)
					Priority = TimerPriority.FiveSeconds;
				else
					Priority = TimerPriority.OneSecond;

				m_PremiumSpawner = spawner;
			}

			protected override void OnTick()
			{
				if ( m_PremiumSpawner != null )
					if ( !m_PremiumSpawner.Deleted )
						m_PremiumSpawner.OnTick();
			}
		}

		public int CountCreatures( string creatureName )
		{
			Defrag();

			int count = 0;

			for ( int i = 0; i < m_Creatures.Count; ++i )
				if ( Insensitive.Equals( creatureName, m_Creatures[i].GetType().Name ) )
					++count;

			return count;
		}

		public int CountCreaturesA( string subSpawnerA )
		{
			Defrag();

			int count = 0;

			for ( int i = 0; i < m_SubCreaturesA.Count; ++i )
				if ( Insensitive.Equals( subSpawnerA, m_SubCreaturesA[i].GetType().Name ) )
					++count;

			return count;
		}

		public int CountCreaturesB( string subSpawnerB )
		{
			Defrag();

			int count = 0;

			for ( int i = 0; i < m_SubCreaturesB.Count; ++i )
				if ( Insensitive.Equals( subSpawnerB, m_SubCreaturesB[i].GetType().Name ) )
					++count;

			return count;
		}

		public int CountCreaturesC( string subSpawnerC )
		{
			Defrag();

			int count = 0;

			for ( int i = 0; i < m_SubCreaturesC.Count; ++i )
				if ( Insensitive.Equals( subSpawnerC, m_SubCreaturesC[i].GetType().Name ) )
					++count;

			return count;
		}

		public int CountCreaturesD( string subSpawnerD )
		{
			Defrag();

			int count = 0;

			for ( int i = 0; i < m_SubCreaturesD.Count; ++i )
				if ( Insensitive.Equals( subSpawnerD, m_SubCreaturesD[i].GetType().Name ) )
					++count;

			return count;
		}

		public int CountCreaturesE( string subSpawnerE )
		{
			Defrag();

			int count = 0;

			for ( int i = 0; i < m_SubCreaturesE.Count; ++i )
				if ( Insensitive.Equals( subSpawnerE, m_SubCreaturesE[i].GetType().Name ) )
					++count;

			return count;
		}

		public void RemoveCreatures( string creatureName )
		{
			Defrag();

			creatureName = creatureName.ToLower();

			for ( int i = 0; i < m_Creatures.Count; ++i )
			{
				object o = m_Creatures[i];

				if ( Insensitive.Equals( creatureName, o.GetType().Name ) )
				{
					if ( o is Item )
						((Item)o).Delete();
					else if ( o is Mobile )
						((Mobile)o).Delete();
				}
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesA( string subSpawnerA )
		{
			Defrag();

			subSpawnerA = subSpawnerA.ToLower();

			for ( int i = 0; i < m_SubCreaturesA.Count; ++i )
			{
				object o = m_SubCreaturesA[i];

				if ( Insensitive.Equals( subSpawnerA, o.GetType().Name ) )
				{
					if ( o is Item )
						((Item)o).Delete();
					else if ( o is Mobile )
						((Mobile)o).Delete();
				}
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesB( string subSpawnerB )
		{
			Defrag();

			subSpawnerB = subSpawnerB.ToLower();

			for ( int i = 0; i < m_SubCreaturesB.Count; ++i )
			{
				object o = m_SubCreaturesB[i];

				if ( Insensitive.Equals( subSpawnerB, o.GetType().Name ) )
				{
					if ( o is Item )
						((Item)o).Delete();
					else if ( o is Mobile )
						((Mobile)o).Delete();
				}
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesC( string subSpawnerC )
		{
			Defrag();

			subSpawnerC = subSpawnerC.ToLower();

			for ( int i = 0; i < m_SubCreaturesC.Count; ++i )
			{
				object o = m_SubCreaturesC[i];

				if ( Insensitive.Equals( subSpawnerC, o.GetType().Name ) )
				{
					if ( o is Item )
						((Item)o).Delete();
					else if ( o is Mobile )
						((Mobile)o).Delete();
				}
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesD( string subSpawnerD )
		{
			Defrag();

			subSpawnerD = subSpawnerD.ToLower();

			for ( int i = 0; i < m_SubCreaturesD.Count; ++i )
			{
				object o = m_SubCreaturesD[i];

				if ( Insensitive.Equals( subSpawnerD, o.GetType().Name ) )
				{
					if ( o is Item )
						((Item)o).Delete();
					else if ( o is Mobile )
						((Mobile)o).Delete();
				}
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesE( string subSpawnerE )
		{
			Defrag();

			subSpawnerE = subSpawnerE.ToLower();

			for ( int i = 0; i < m_SubCreaturesE.Count; ++i )
			{
				object o = m_SubCreaturesE[i];

				if ( Insensitive.Equals( subSpawnerE, o.GetType().Name ) )
				{
					if ( o is Item )
						((Item)o).Delete();
					else if ( o is Mobile )
						((Mobile)o).Delete();
				}
			}

			InvalidateProperties();
		}
		
		public void RemoveCreatures()
		{
			Defrag();

			for ( int i = 0; i < m_Creatures.Count; ++i )
			{
				object o = m_Creatures[i];

				if ( o is Item )
					((Item)o).Delete();
				else if ( o is Mobile )
					((Mobile)o).Delete();
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesA()
		{
			Defrag();

			for ( int i = 0; i < m_SubCreaturesA.Count; ++i )
			{
				object o = m_SubCreaturesA[i];

				if ( o is Item )
					((Item)o).Delete();
				else if ( o is Mobile )
					((Mobile)o).Delete();
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesB()
		{
			Defrag();

			for ( int i = 0; i < m_SubCreaturesB.Count; ++i )
			{
				object o = m_SubCreaturesB[i];

				if ( o is Item )
					((Item)o).Delete();
				else if ( o is Mobile )
					((Mobile)o).Delete();
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesC()
		{
			Defrag();

			for ( int i = 0; i < m_SubCreaturesC.Count; ++i )
			{
				object o = m_SubCreaturesC[i];

				if ( o is Item )
					((Item)o).Delete();
				else if ( o is Mobile )
					((Mobile)o).Delete();
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesD()
		{
			Defrag();

			for ( int i = 0; i < m_SubCreaturesD.Count; ++i )
			{
				object o = m_SubCreaturesD[i];

				if ( o is Item )
					((Item)o).Delete();
				else if ( o is Mobile )
					((Mobile)o).Delete();
			}

			InvalidateProperties();
		}

		public void RemoveCreaturesE()
		{
			Defrag();

			for ( int i = 0; i < m_SubCreaturesE.Count; ++i )
			{
				object o = m_SubCreaturesE[i];

				if ( o is Item )
					((Item)o).Delete();
				else if ( o is Mobile )
					((Mobile)o).Delete();
			}

			InvalidateProperties();
		}

		public void BringToHome()
		{
			Defrag();

			for ( int i = 0; i < m_Creatures.Count; ++i )
			{
				object o = m_Creatures[i];

				if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					m.MoveToWorld( Location, Map );
				}
				else if ( o is Item )
				{
					Item item = (Item)o;

					item.MoveToWorld( Location, Map );
				}
			}

			for ( int i = 0; i < m_SubCreaturesA.Count; ++i )
			{
				object o = m_SubCreaturesA[i];

				if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					m.MoveToWorld( Location, Map );
				}
				else if ( o is Item )
				{
					Item item = (Item)o;

					item.MoveToWorld( Location, Map );
				}
			}

			for ( int i = 0; i < m_SubCreaturesB.Count; ++i )
			{
				object o = m_SubCreaturesB[i];

				if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					m.MoveToWorld( Location, Map );
				}
				else if ( o is Item )
				{
					Item item = (Item)o;

					item.MoveToWorld( Location, Map );
				}
			}

			for ( int i = 0; i < m_SubCreaturesC.Count; ++i )
			{
				object o = m_SubCreaturesC[i];

				if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					m.MoveToWorld( Location, Map );
				}
				else if ( o is Item )
				{
					Item item = (Item)o;

					item.MoveToWorld( Location, Map );
				}
			}

			for ( int i = 0; i < m_SubCreaturesD.Count; ++i )
			{
				object o = m_SubCreaturesD[i];

				if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					m.MoveToWorld( Location, Map );
				}
				else if ( o is Item )
				{
					Item item = (Item)o;

					item.MoveToWorld( Location, Map );
				}
			}

			for ( int i = 0; i < m_SubCreaturesE.Count; ++i )
			{
				object o = m_SubCreaturesE[i];

				if ( o is Mobile )
				{
					Mobile m = (Mobile)o;

					m.MoveToWorld( Location, Map );
				}
				else if ( o is Item )
				{
					Item item = (Item)o;

					item.MoveToWorld( Location, Map );
				}
			}
		}

		public override void OnDelete()
		{
			base.OnDelete();

			RemoveCreatures();
			RemoveCreaturesA();
			RemoveCreaturesB();
			RemoveCreaturesC();
			RemoveCreaturesD();
			RemoveCreaturesE();
			if ( m_Timer != null )
				m_Timer.Stop();
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 ); // version

			writer.Write( m_SpawnRange );
			writer.Write( m_SpawnID );
			writer.Write( m_DeSpawn );
			writer.Write( m_PlayerRangeSensitive );
			writer.Write( m_SubCountA );
			writer.Write( m_SubCountB );
			writer.Write( m_SubCountC );
			writer.Write( m_SubCountD );
			writer.Write( m_SubCountE );

			writer.Write( m_WayPoint );

			writer.Write( m_Group );

			writer.Write( m_MinDelay );
			writer.Write( m_MaxDelay );
			writer.Write( m_Count );
			writer.Write( m_Team );
			writer.Write( m_HomeRange );
			writer.Write( m_Running );
			
			if ( m_Running )
				writer.WriteDeltaTime( m_End );

			writer.Write( m_CreaturesName.Count );

			for ( int i = 0; i < m_CreaturesName.Count; ++i )
				writer.Write( (string)m_CreaturesName[i] );

			writer.Write( m_SubSpawnerA.Count );

			for ( int i = 0; i < m_SubSpawnerA.Count; ++i )
				writer.Write( (string)m_SubSpawnerA[i] );

			writer.Write( m_SubSpawnerB.Count );

			for ( int i = 0; i < m_SubSpawnerB.Count; ++i )
				writer.Write( (string)m_SubSpawnerB[i] );

			writer.Write( m_SubSpawnerC.Count );

			for ( int i = 0; i < m_SubSpawnerC.Count; ++i )
				writer.Write( (string)m_SubSpawnerC[i] );

			writer.Write( m_SubSpawnerD.Count );

			for ( int i = 0; i < m_SubSpawnerD.Count; ++i )
				writer.Write( (string)m_SubSpawnerD[i] );

			writer.Write( m_SubSpawnerE.Count );

			for ( int i = 0; i < m_SubSpawnerE.Count; ++i )
				writer.Write( (string)m_SubSpawnerE[i] );

			writer.Write( m_Creatures.Count );

			for ( int i = 0; i < m_Creatures.Count; ++i )
			{
				object o = m_Creatures[i];

				if ( o is Item )
					writer.Write( (Item)o );
				else if ( o is Mobile )
					writer.Write( (Mobile)o );
				else
					writer.Write( Serial.MinusOne );
			}

			writer.Write( m_SubCreaturesA.Count );

			for ( int i = 0; i < m_SubCreaturesA.Count; ++i )
			{
				object oA = m_SubCreaturesA[i];

				if ( oA is Item )
					writer.Write( (Item)oA );
				else if ( oA is Mobile )
					writer.Write( (Mobile)oA );
				else
					writer.Write( Serial.MinusOne );
			}

			writer.Write( m_SubCreaturesB.Count );

			for ( int i = 0; i < m_SubCreaturesB.Count; ++i )
			{
				object oB = m_SubCreaturesB[i];

				if ( oB is Item )
					writer.Write( (Item)oB );
				else if ( oB is Mobile )
					writer.Write( (Mobile)oB );
				else
					writer.Write( Serial.MinusOne );
			}

			writer.Write( m_SubCreaturesC.Count );

			for ( int i = 0; i < m_SubCreaturesC.Count; ++i )
			{
				object oC = m_SubCreaturesC[i];

				if ( oC is Item )
					writer.Write( (Item)oC );
				else if ( oC is Mobile )
					writer.Write( (Mobile)oC );
				else
					writer.Write( Serial.MinusOne );
			}

			writer.Write( m_SubCreaturesD.Count );

			for ( int i = 0; i < m_SubCreaturesD.Count; ++i )
			{
				object oD = m_SubCreaturesD[i];

				if ( oD is Item )
					writer.Write( (Item)oD );
				else if ( oD is Mobile )
					writer.Write( (Mobile)oD );
				else
					writer.Write( Serial.MinusOne );
			}

			writer.Write( m_SubCreaturesE.Count );

			for ( int i = 0; i < m_SubCreaturesE.Count; ++i )
			{
				object oE = m_SubCreaturesE[i];

				if ( oE is Item )
					writer.Write( (Item)oE );
				else if ( oE is Mobile )
					writer.Write( (Mobile)oE );
				else
					writer.Write( Serial.MinusOne );
			}
		}

		private static WarnTimer m_WarnTimer;

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				{
					m_SpawnRange = reader.ReadInt();
					m_SpawnID = reader.ReadInt();
					m_DeSpawn = reader.ReadInt();
					m_PlayerRangeSensitive = reader.ReadInt();
					m_SubCountA = reader.ReadInt();
					m_SubCountB = reader.ReadInt();
					m_SubCountC = reader.ReadInt();
					m_SubCountD = reader.ReadInt();
					m_SubCountE = reader.ReadInt();

					goto case 2;
				}
				case 2:
				{
					m_WayPoint = reader.ReadItem() as WayPoint;

					goto case 1;
				}
				case 1:
				{
					m_Group = reader.ReadBool();

					goto case 0;
				}
				case 0:
				{
					m_MinDelay = reader.ReadTimeSpan();
					m_MaxDelay = reader.ReadTimeSpan();
					m_Count = reader.ReadInt();
					m_Team = reader.ReadInt();
					m_HomeRange = reader.ReadInt();
					m_Running = reader.ReadBool();
					TimeSpan ts = TimeSpan.Zero;
					if ( m_Running )
						ts = reader.ReadDeltaTime() - DateTime.Now;
 
					int size = reader.ReadInt();
					m_CreaturesName = new ArrayList( size );
					for ( int i = 0; i < size; ++i )
					{
						string typeName = reader.ReadString();
						m_CreaturesName.Add( typeName );
						if ( SpawnerType.GetType( typeName ) == null )
						{
							if ( m_WarnTimer == null )
								m_WarnTimer = new WarnTimer();
							m_WarnTimer.Add( Location, Map, typeName );
						}
					}

					int sizeA = reader.ReadInt();
					m_SubSpawnerA = new ArrayList( sizeA );
					for ( int i = 0; i < sizeA; ++i )
					{
						string typeNameA = reader.ReadString();
						m_SubSpawnerA.Add( typeNameA );
						if ( SpawnerType.GetType( typeNameA ) == null )
						{
							if ( m_WarnTimer == null )
								m_WarnTimer = new WarnTimer();
							m_WarnTimer.Add( Location, Map, typeNameA );
						}
					}

					int sizeB = reader.ReadInt();
					m_SubSpawnerB = new ArrayList( sizeB );
					for ( int i = 0; i < sizeB; ++i )
					{
						string typeNameB = reader.ReadString();
						m_SubSpawnerB.Add( typeNameB );
						if ( SpawnerType.GetType( typeNameB ) == null )
						{
							if ( m_WarnTimer == null )
								m_WarnTimer = new WarnTimer();
							m_WarnTimer.Add( Location, Map, typeNameB );
						}
					}

					int sizeC = reader.ReadInt();
					m_SubSpawnerC = new ArrayList( sizeC );
					for ( int i = 0; i < sizeC; ++i )
					{
						string typeNameC = reader.ReadString();
						m_SubSpawnerC.Add( typeNameC );
						if ( SpawnerType.GetType( typeNameC ) == null )
						{
							if ( m_WarnTimer == null )
								m_WarnTimer = new WarnTimer();
							m_WarnTimer.Add( Location, Map, typeNameC );
						}
					}

					int sizeD = reader.ReadInt();
					m_SubSpawnerD = new ArrayList( sizeD );
					for ( int i = 0; i < sizeD; ++i )
					{
						string typeNameD = reader.ReadString();
						m_SubSpawnerD.Add( typeNameD );
						if ( SpawnerType.GetType( typeNameD ) == null )
						{
							if ( m_WarnTimer == null )
								m_WarnTimer = new WarnTimer();
							m_WarnTimer.Add( Location, Map, typeNameD );
						}
					}

					int sizeE = reader.ReadInt();
					m_SubSpawnerE = new ArrayList( sizeE );
					for ( int i = 0; i < sizeE; ++i )
					{
						string typeNameE = reader.ReadString();
						m_SubSpawnerE.Add( typeNameE );
						if ( SpawnerType.GetType( typeNameE ) == null )
						{
							if ( m_WarnTimer == null )
								m_WarnTimer = new WarnTimer();
							m_WarnTimer.Add( Location, Map, typeNameE );
						}
					}

					int count = reader.ReadInt();
					m_Creatures = new ArrayList( count );
					for ( int i = 0; i < count; ++i )
					{
						IEntity e = World.FindEntity( reader.ReadInt() );
						if ( e != null )
							m_Creatures.Add( e );
					}

					int countA = reader.ReadInt();
					m_SubCreaturesA = new ArrayList( countA );
					for ( int i = 0; i < countA; ++i )
					{
						IEntity eA = World.FindEntity( reader.ReadInt() );
						if ( eA != null )
							m_SubCreaturesA.Add( eA );
					}

					int countB = reader.ReadInt();
					m_SubCreaturesB = new ArrayList( countB );
					for ( int i = 0; i < countB; ++i )
					{
						IEntity eB = World.FindEntity( reader.ReadInt() );
						if ( eB != null )
							m_SubCreaturesB.Add( eB );
					}

					int countC = reader.ReadInt();
					m_SubCreaturesC = new ArrayList( countC );
					for ( int i = 0; i < countC; ++i )
					{
						IEntity eC = World.FindEntity( reader.ReadInt() );
						if ( eC != null )
							m_SubCreaturesC.Add( eC );
					}

					int countD = reader.ReadInt();
					m_SubCreaturesD = new ArrayList( countD );
					for ( int i = 0; i < countD; ++i )
					{
						IEntity eD = World.FindEntity( reader.ReadInt() );
						if ( eD != null )
						m_SubCreaturesD.Add( eD );
					}

					int countE = reader.ReadInt();
					m_SubCreaturesE = new ArrayList( countE );
					for ( int i = 0; i < countE; ++i )
					{
						IEntity eE = World.FindEntity( reader.ReadInt() );
						if ( eE != null )
						m_SubCreaturesE.Add( eE );
					}

					if ( m_Running )
						DoTimer( ts );

					break;
				}
			}

			m_SpawnRange = ( version <= 2 ? m_HomeRange : m_SpawnRange );
		}

		private class WarnTimer : Timer
		{
			private ArrayList m_List;

			private class WarnEntry
			{
				public Point3D m_Point;
				public Map m_Map;
				public string m_Name;

				public WarnEntry( Point3D p, Map map, string name )
				{
					m_Point = p;
					m_Map = map;
					m_Name = name;
				}
			}

			public WarnTimer() : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_List = new ArrayList();
				Start();
			}

			public void Add( Point3D p, Map map, string name )
			{
				m_List.Add( new WarnEntry( p, map, name ) );
			}

			protected override void OnTick()
			{
				try
				{
					Console.WriteLine( "Warning: {0} bad spawns detected, logged: 'badspawn.log'", m_List.Count );

					using ( StreamWriter op = new StreamWriter( "badspawn.log", true ) )
					{
						op.WriteLine( "# Bad spawns : {0}", DateTime.Now );
						op.WriteLine( "# Format: X Y Z F Name" );
						op.WriteLine();

						foreach ( WarnEntry e in m_List )
							op.WriteLine( "{0}\t{1}\t{2}\t{3}\t{4}", e.m_Point.X, e.m_Point.Y, e.m_Point.Z, e.m_Map, e.m_Name );

						op.WriteLine();
						op.WriteLine();
					}
				}
				catch
				{
				}
			}
		}
	}
}