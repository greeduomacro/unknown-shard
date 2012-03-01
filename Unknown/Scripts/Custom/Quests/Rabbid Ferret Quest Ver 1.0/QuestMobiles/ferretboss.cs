// A Ferret Boss * these are mean lil shits adjust stats*
// scripted by evilfreak
// Ver 1.0
// look for edits throughout script 





using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName( "a rabbid ferret corpse" )]
	public class RabbidFerret : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.BleedAttack : WeaponAbility.ParalyzingBlow;
		}
		
		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission
		[Constructable]
		public RabbidFerret() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a rabbid ferret";
			Body = 279;
			
			SetStr( 1000 );
			SetDex( 1000 );
			SetInt( 1000 );

			SetHits( 4500, 8000 );
			SetStam( 800, 1000 );
			SetMana( 500, 750 );

			SetDamage( 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.MagicResist, 200.0 );
			SetSkill( SkillName.Tactics, 75.0 );
			SetSkill( SkillName.Wrestling, 95.0 );

			Fame = 1000;
			Karma = -2500;

			VirtualArmor = 70;

			
			PackItem( new GrandmasBrace());
			DelayBeginTunnel();
		}
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich, 2 );
			
		}

	
//begin tunnel
		public class FerretTunnel : Item
		{
			public FerretTunnel() : base( 0x913 )
			{
				Movable = false;
				Hue = 1;
				Name = "a ferret tunnel";

				Timer.DelayCall( TimeSpan.FromSeconds( 40.0 ), new TimerCallback( Delete ) );
			

			}


		
			public FerretTunnel( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize(writer);

				writer.Write( (int) 0 );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				Delete();
			}
		}

		public virtual void DelayBeginTunnel()
		{
//here is the line to edit the time before it tunnels off  TimeSpan.FromMinutes( minutes here)
			Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerCallback( BeginTunnel ) );
		}

		public virtual void BeginTunnel()
		{
			if ( Deleted )
				return;

			new FerretTunnel().MoveToWorld( Location, Map );

			Frozen = true;
			Say( "* The ferret kicks dirt everywhere!! *" );
			PlaySound( 0x247 );
			PlaySound( 0x247 );
			

			Timer.DelayCall( TimeSpan.FromSeconds( 3.0 ), new TimerCallback( Delete ) );
		}
//end of tunnel

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 1; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }

		public RabbidFerret( Serial serial ) : base( serial )
		{
		}

		public override int GetAttackSound()
		{
			return 0xC9;
		}

		public override int GetHurtSound()
		{
			return 0xCA;
		}

		public override int GetDeathSound()
		{
			return 0xCB;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish; } }
		

		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			PackAnimal.CombineBackpacks( this );

			return true;
		}

		public override DeathMoveResult GetInventoryMoveResultFor( Item item )
		{
			return DeathMoveResult.MoveToCorpse;
		}

		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			DelayBeginTunnel();
		}
	}
}