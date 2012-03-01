//the allure waves are 1476, 1477 for success and failure
//does not have the special abilities of removing armor or peacing and unable to fight(magic or melee)
using System;
using Server;
using Server.Items;
using Server.Gumps;

namespace Server.Mobiles 
{ 
	[CorpseName( "an dryad corpse" )] 
	public class ADryad : BaseCreature 
	{ 
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable] 
		public ADryad() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 ) 
		{ 
			Name =  "a dryad" ;
			Body = 266;

			SetStr( 132, 147 );
			SetDex( 152, 168 );
			SetInt( 251, 272 );

			SetHits( 304, 316 );

			SetDamage( 9, 15 );// no info on the damage amount or something to compare to, this is a pixie value

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 41, 50 );
			SetResistance( ResistanceType.Fire, 17, 25 );
			SetResistance( ResistanceType.Cold, 40, 44 );
			SetResistance( ResistanceType.Poison, 34, 40 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.EvalInt, 70.7, 78.7 );
			SetSkill( SkillName.Magery, 70.7, 75.2 );
			SetSkill( SkillName.Meditation, 82.9, 89.9 );
			SetSkill( SkillName.MagicResist, 112.7, 117.1 );
			SetSkill( SkillName.Tactics, 71.7, 76.8 );
			SetSkill( SkillName.Wrestling, 72.5, 77.1 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 100;//no idea here, this is a Pixie
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Gems );
		}

		public override int GetAngerSound()
		{
			return 1405;
		}

		public override int GetIdleSound()
		{
			return 1404;
		}

		public override int GetAttackSound()
		{
			return  1403;
		}

		public override int GetHurtSound()
		{
			return 1406;
		}

		public override int GetDeathSound()
		{
			return 1402;
		}

		private DateTime m_NextResurrect;
		private static TimeSpan ResurrectDelay = TimeSpan.FromSeconds( 2.0 );

		public virtual bool CheckResurrect( Mobile m )
		{
			if ( m.Criminal )
			{
				Say( 501222 ); // Thou art a criminal.  I shall not resurrect thee.
				return false;
			}
			else if ( m.Kills >= 5 )
			{
				Say( 501223 ); // Thou'rt not a decent and good person. I shall not resurrect thee.
				return false;
			}
			else if ( m.Karma <= 0 )
			{
				Say( 501223 ); // Thou'rt not a decent and good person. I shall not resurrect thee.
				return false;
			}

			return true;
		}
		
		public virtual void OfferResurrection( Mobile m )
		{
			Direction = GetDirectionTo( m );

			m.PlaySound( 0x214 );
			m.FixedEffect( 0x376A, 10, 16 );

			m.CloseGump( typeof( ResurrectGump ) );
			m.SendGump( new ResurrectGump( m, ResurrectMessage.Healer ) );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( !m.Frozen && DateTime.Now >= m_NextResurrect && InRange( m, 4 ) && !InRange( oldLocation, 4 ) && InLOS( m ) )
			{
				if ( !m.Alive )
				{
					m_NextResurrect = DateTime.Now + ResurrectDelay;

					if ( m.Map == null || !m.Map.CanFit( m.Location, 16, false, false ) )
					{
						m.SendLocalizedMessage( 502391 ); // Thou can not be resurrected there!
					}
					else if ( CheckResurrect( m ) )
					{
						OfferResurrection( m );
					}
				}
			}
		}

		public ADryad( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		} 
	}
}
