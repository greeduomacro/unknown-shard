using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a glowing orc corpse" )]
	public class OrcishNecromancer : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public OrcishNecromancer () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an orcish necromancer";
			Body = 140;
			BaseSoundID = 0x45A;

			SetStr( 116, 150 );
			SetDex( 91, 115 );
			SetInt( 161, 185 );

			SetHits( 70, 90 );

			SetDamage( 4, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.EvalInt, 60.1, 72.5 );
			SetSkill( SkillName.Magery, 60.1, 72.5 );
			SetSkill( SkillName.MagicResist, 60.1, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 65.0 );
			SetSkill( SkillName.Wrestling, 40.1, 50.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 30;


			PackReg( 6 );

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new OrcishKinMask() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is OrcishKinMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}




///////////////////////
		public void SpawnSkeleton( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int skeletons = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 30 ) )
			{
				if ( m is Skeleton )
					++skeletons;
			}

			if ( skeletons < 3 )
			{
				PlaySound( 0x3D );

				int newSkeletons = Utility.RandomMinMax( 1, 2 );

				for ( int i = 0; i < newSkeletons; ++i )
				{
					BaseCreature skeleton;

					switch ( Utility.Random( 5 ) )
					{
						default:
						case 0: case 1:	skeleton = new Skeleton(); break;
						case 2: case 3:	skeleton = new Skeleton(); break;
						case 4:			skeleton = new Skeleton(); break;
					}

					skeleton.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					skeleton.MoveToWorld( loc, map );
					skeleton.Combatant = target;
				}
			}
		}

public void DoSpecialAbility( Mobile target )
		{


			if ( 0.3 >= Utility.RandomDouble() ) // 30% chance to more skeltons
				SpawnSkeleton( target );

		}

public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}


//////////

		public OrcishNecromancer( Serial serial ) : base( serial )
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
