/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 5/30/2006
 * Time: 5:27 AM
 * 
 * Tangle -  Blighted Grove
 */
using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a plant corpse" )]
	public class ATangle : BaseCreature
	{
		[Constructable]
		public ATangle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.6, 1.2 )
		{
			Name = "Tangle";
			Body = 780;
			Hue = 33;

			SetStr( 833, 843 );
			SetDex( 56, 66 );
			SetInt( 47, 57 );

			SetHits( 2500, 2505 );
			SetMana( 9 );

			SetDamage( 15, 25 );// Bog thing 10-23

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 50, 52 );
			SetResistance( ResistanceType.Fire, 38, 40 );
			SetResistance( ResistanceType.Cold, 28, 30 );
			SetResistance( ResistanceType.Poison, 67, 69 );
			SetResistance( ResistanceType.Energy, 40, 42 );

			SetSkill( SkillName.MagicResist, 104.6, 109.6 );
			SetSkill( SkillName.Tactics, 91.7, 96.7 );
			SetSkill( SkillName.Wrestling, 80.2, 85.2 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 32;//Bog Thing is 28

			if ( 0.25 > Utility.RandomDouble() )
			{
				PackItem( new Board( 10 ) );
			}
			else
			{
				PackItem( new Log( 10 ) );
			}

			PackReg( 3 );
			PackItem( new Engines.Plants.Seed() );
			PackItem( new Engines.Plants.Seed() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 6 );
		}

		public override bool BardImmune { get { return !Core.AOS; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public override void OnDeath( Container c )
{
	if ( Utility.Random( 4 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 1 ))
		{
                        default:
			case 1: item = new TaintedSeeds(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
}
		public ATangle( Serial serial ) : base( serial )
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

		public void SpawnBogling( Mobile m )
		{
			Map map = this.Map;

			if ( map == null )
			{
				return;
			}

			Bogling spawned = new Bogling();

			spawned.Team = this.Team;

			bool validLocation = false;
			Point3D loc = this.Location;

			for ( int j = 0; !validLocation && j < 10; ++j )
			{
				int x = X + Utility.Random( 3 ) - 1;
				int y = Y + Utility.Random( 3 ) - 1;
				int z = map.GetAverageZ( x, y );

				if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
				{
					loc = new Point3D( x, y, Z );
				}
				else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
				{
					loc = new Point3D( x, y, z );
				}
			}

			spawned.MoveToWorld( loc, map );
			spawned.Combatant = m;
		}

		public void EatBoglings()
		{
			ArrayList toEat = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m is Bogling )
				{
					toEat.Add( m );
				}
			}

			if ( toEat.Count > 0 )
			{
				PlaySound( Utility.Random( 0x3B, 2 ) ); // Eat sound

				foreach ( Mobile m in toEat )
				{
					Hits += (m.Hits/2);
					m.Delete();
				}
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( this.Hits > (this.HitsMax/4) )
			{
				if ( 0.25 >= Utility.RandomDouble() )
				{
					SpawnBogling( attacker );
				}
			}
			else if ( 0.25 >= Utility.RandomDouble() )
			{
				EatBoglings();
			}
		}
	}
}
