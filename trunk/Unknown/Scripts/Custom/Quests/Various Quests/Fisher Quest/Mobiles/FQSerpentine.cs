using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "A Serpentine Corpse" )]
	public class FQSerpentine : BaseCreature
	{
		[Constructable]
		public FQSerpentine() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Theiving Serpentine";
			Body = 103;
			BaseSoundID = 362;

			Hue = Utility.RandomSlimeHue();

			SetStr( 500 );
			SetDex( 500 );
			SetInt( 500 );

			SetHits( 2500 );

			SetDamage( 1, 50 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 100.0 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 1;
			Karma = -1;

			VirtualArmor = 50;

			PackItem( new FQGoldenFish() );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss );
		}

		public FQSerpentine( Serial serial ) : base( serial )
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
