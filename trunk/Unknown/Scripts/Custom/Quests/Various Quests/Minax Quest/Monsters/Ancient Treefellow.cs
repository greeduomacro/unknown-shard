//Written by Lord Dalamar
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ancient treefellow corpse" )]
	public class AncientTreefellow : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		[Constructable]
		public AncientTreefellow() : base( AIType.AI_Melee, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "an Ancient Treefellow";
			Body = 301;
			Hue = 2213;

			SetStr( 500, 800 );
			SetDex( 130, 190 );
			SetInt( 800, 1000 );

			SetHits( 800, 1200 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 100 );
			SetResistance( ResistanceType.Cold, 60, 100 );
			SetResistance( ResistanceType.Poison, 60, 100 );
			SetResistance( ResistanceType.Energy, 60, 100 );
			SetResistance( ResistanceType.Fire, 60, 100 );

			SetSkill( SkillName.MagicResist, 200.0, 500.0 );
			SetSkill( SkillName.Tactics, 120.0, 150.0 );
			SetSkill( SkillName.Wrestling, 120.0, 150.0 );

			Fame = 15000;
			Karma = 15000;

			VirtualArmor = 90;

			PackItem( new GoldenMandrakeRoot() );
			PackItem( new GoldenMandrakeRoot() );

			PackItem( new Log( Utility.RandomMinMax( 23, 34 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
		}

		public override int GetIdleSound()
		{
			return 443;
		}

		public override int GetDeathSound()
		{
			return 31;
		}

		public override int GetAttackSound()
		{
			return 672;
		}

		public AncientTreefellow( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 442 )
				BaseSoundID = -1;
		}
	}
}