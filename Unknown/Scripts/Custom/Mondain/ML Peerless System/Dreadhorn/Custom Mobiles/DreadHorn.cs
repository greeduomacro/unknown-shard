using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Engines.CannedEvil;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class DreadHorn : BaseCreature
	{
       private Timer m_Timer;
		[Constructable]
		public DreadHorn() : base( AIType.AI_Mage, FightMode.Closest, 18, 1, 0.2, 0.4 )
		{	

			Name = "a Dread Horn";
			Body = 257;
			BaseSoundID = 0xA8;

			SetStr( 1281, 1305 );
			SetDex( 591, 815 );
			SetInt( 1226, 1250 );

			SetHits( 12000, 13000 );
			SetStam( 636, 945 );

			SetDamage( 15, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 40 );
			SetResistance( ResistanceType.Fire, 40, 40 );
			SetResistance( ResistanceType.Cold, 40, 40 );
			SetResistance( ResistanceType.Poison, 40, 40 );
			SetResistance( ResistanceType.Energy, 40, 40 );

			SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Poisoning, 102.6, 102.6 );
			SetSkill( SkillName.Magery, 120.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 155.1, 200.0 );
			SetSkill( SkillName.Wrestling, 155.1, 200.0 );

			Fame = 11500;
			Karma = -11500;

			VirtualArmor = 75;
		switch ( Utility.Random( 10 ))
            {                                   
            	case 0: AddItem( new CrimsonCinture() ); break;
            	case 1: AddItem( new PristineDreadHorn() ); break;
				case 2: AddItem( new HornOfDreadhorn () ); break;
            	case 3: AddItem( new HornOfDreadhorn2 () ); break;       
				case 4: AddItem( new DreadRevenge () ); break;		
							}

				switch ( Utility.Random( 4 ))
            {                                   
            	case 0: AddItem( new DreadMushroom() ); break;
            	case 1: AddItem( new DreadMushroom2() ); break;
				case 2: AddItem( new DreadMushroom3 () ); break;
            	case 3: AddItem( new DreadMushroom4 () ); break;       	
							}
							switch ( Utility.Random( 64 ))
            {                                   
            	case 0: AddItem( new PlateOfHonorArms() ); break;
            	case 1: AddItem( new PlateOfHonorChest() ); break;
				case 2: AddItem( new PlateOfHonorGloves () ); break;
            	case 3: AddItem( new PlateOfHonorGorget () ); break;       
				case 4: AddItem( new PlateOfHonorHelm () ); break;		
				case 5: AddItem( new PlateOfHonorLegs () ); break;		
				case 6: AddItem( new AcolyteArms() ); break;
            	case 7: AddItem( new AcolyteChest() ); break;
				case 8: AddItem( new AcolyteGloves () ); break;	
				case 9: AddItem( new AcolyteLegs () ); break;	
				case 10: AddItem( new EvocaricusSword() ); break;
            	case 11: AddItem( new MalekisHonor() ); break;
				case 12: AddItem( new GrizzleArms() ); break;
            	case 13: AddItem( new GrizzleChest() ); break;
				case 14: AddItem( new GrizzleGloves () ); break;       
				case 15: AddItem( new GrizzleHelm () ); break;		
				case 16: AddItem( new PlateOfHonorLegs () ); break;
				case 17: AddItem( new MageArmorArms() ); break;
            	case 18: AddItem( new MageArmorChest() ); break;
				case 19: AddItem( new MageArmorGloves () ); break;	
				case 20: AddItem( new MageArmorLegs () ); break;                    
				case 21: AddItem( new MyrmidonArms() ); break;
            	case 22: AddItem( new MyrmidonChest() ); break;
				case 23: AddItem( new MyrmidonGloves () ); break;
            	case 24: AddItem( new MyrmidonGorget () ); break;       
				case 25: AddItem( new MyrmidonHelm () ); break;		
				case 26: AddItem( new MyrmidonLegs () ); break;		
				case 27: AddItem( new DeathEssenceArms() ); break;
            	case 28: AddItem( new DeathEssenceChest() ); break;
				case 29: AddItem( new DeathEssenceGloves () ); break;      
				case 30: AddItem( new DeathEssenceHelm () ); break;		
				case 31: AddItem( new DeathEssenceLegs () ); break;		
 }


			m_Timer = new TeleportTimer( this );
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich );
			AddLoot( LootPack.AosSuperBoss );
			PackItem( new Taint(2) );
			PackItem( new Muculent (2) );
			PackItem( new Corruption(2) );
			PackItem( new Blight (2) );
			PackItem( new Scourge(2) );
			PackItem( new Putrefication  (2) );

		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		private static readonly double[] m_Offsets = new double[]
			{
				Math.Cos( 000.0 / 180.0 * Math.PI ), Math.Sin( 000.0 / 180.0 * Math.PI ),
				Math.Cos( 040.0 / 180.0 * Math.PI ), Math.Sin( 040.0 / 180.0 * Math.PI ),
				Math.Cos( 080.0 / 180.0 * Math.PI ), Math.Sin( 080.0 / 180.0 * Math.PI ),
				Math.Cos( 120.0 / 180.0 * Math.PI ), Math.Sin( 120.0 / 180.0 * Math.PI ),
				Math.Cos( 160.0 / 180.0 * Math.PI ), Math.Sin( 160.0 / 180.0 * Math.PI ),
				Math.Cos( 200.0 / 180.0 * Math.PI ), Math.Sin( 200.0 / 180.0 * Math.PI ),
				Math.Cos( 240.0 / 180.0 * Math.PI ), Math.Sin( 240.0 / 180.0 * Math.PI ),
				Math.Cos( 280.0 / 180.0 * Math.PI ), Math.Sin( 280.0 / 180.0 * Math.PI ),
				Math.Cos( 320.0 / 180.0 * Math.PI ), Math.Sin( 320.0 / 180.0 * Math.PI ),
			};

public override void OnDeath( Container c )
		{
			c.DropItem( new DreadHornMane() );
			c.DropItem( new MangledDreadHorn() );
			c.DropItem( new MangledDreadHorn() );

			base.OnDeath( c );
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public override int ManaMax{ get{ return 5000; } }

		public DreadHorn( Serial serial ) : base( serial )
		{
			//m_Instances.Add( this );
		}

		public override void OnAfterDelete()
		{
			//m_Instances.Remove( this );

			base.OnAfterDelete();
		}

		//public override bool DisallowAllMoves{ get{ return m_TrueForm; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			//writer.Write( m_TrueForm );
			//writer.Write( m_GateItem );
			//writer.WriteMobileList( m_Tentacles );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					//m_TrueForm = reader.ReadBool();
					//m_GateItem = reader.ReadItem();
					//m_Tentacles = reader.ReadMobileList();

					m_Timer = new TeleportTimer( this );
					m_Timer.Start();

					break;
				}
			}
		}
		
		private class TeleportTimer : Timer
		{
			private Mobile m_Owner;

			private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

			public TeleportTimer( Mobile owner ) : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 5.0 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( m_Owner.Deleted )
				{
					Stop();
					return;
				}

				Map map = m_Owner.Map;

				if ( map == null )
					return;

				if ( 0.25 < Utility.RandomDouble() )
					return;

				Mobile toTeleport = null;

				foreach ( Mobile m in m_Owner.GetMobilesInRange( 16 ) )
				{
					if ( m != m_Owner && m.Player && m_Owner.CanBeHarmful( m ) && m_Owner.CanSee( m ) )
					{
						toTeleport = m;
						break;
					}
				}

				if ( toTeleport != null )
				{
					int offset = Utility.Random( 8 ) * 2;

					Point3D to = m_Owner.Location;

					for ( int i = 0; i < m_Offsets.Length; i += 2 )
					{
						int x = m_Owner.X + m_Offsets[(offset + i) % m_Offsets.Length];
						int y = m_Owner.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

						if ( map.CanSpawnMobile( x, y, m_Owner.Z ) )
						{
							to = new Point3D( x, y, m_Owner.Z );
							break;
						}
						else
						{
							int z = map.GetAverageZ( x, y );

							if ( map.CanSpawnMobile( x, y, z ) )
							{
								to = new Point3D( x, y, z );
								break;
							}
						}
					}

					Mobile m = toTeleport;

					Point3D from = m.Location;

					m.Location = to;

					Server.Spells.SpellHelper.Turn( m_Owner, toTeleport );
					Server.Spells.SpellHelper.Turn( toTeleport, m_Owner );

					m.ProcessDelta();

					Effects.SendLocationParticles( EffectItem.Create( from, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
					Effects.SendLocationParticles( EffectItem.Create(   to, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

					m.PlaySound( 0x1FE );

					m_Owner.Combatant = toTeleport;
				}
			}
		}

		private class GoodiesTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public GoodiesTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 10.0 ) )
			{
				m_Map = map;
				m_X = x;
				m_Y = y;
			}

			protected override void OnTick()
			{
				int z = m_Map.GetAverageZ( m_X, m_Y );
				bool canFit = m_Map.CanFit( m_X, m_Y, z, 6, false, false );

				for ( int i = -3; !canFit && i <= 3; ++i )
				{
					canFit = m_Map.CanFit( m_X, m_Y, z + i, 6, false, false );

					if ( canFit )
						z += i;
				}

				if ( !canFit )
					return;

				Gold g = new Gold( 750, 1250 );
				
				g.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.5 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 3 ) )
					{
						case 0: // Fire column
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );
							Effects.PlaySound( g, g.Map, 0x208 );

							break;
						}
						case 1: // Explosion
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 20, 10, 5044 );
							Effects.PlaySound( g, g.Map, 0x307 );

							break;
						}
						case 2: // Ball of fire
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 10, 5052 );

							break;
						}
					}
				}
			}
		}
	}
}
