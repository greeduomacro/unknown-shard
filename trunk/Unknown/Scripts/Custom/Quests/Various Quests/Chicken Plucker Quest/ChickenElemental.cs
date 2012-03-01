using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a chicken elemental corpse" )]
	public class ChickenElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public ChickenElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a chicken elemental";
			Body = 0xD0;
			BaseSoundID = 0x6E;
            Hue = 1154;
            
			SetStr( 2126, 3155 );
			SetDex( 866, 985 );
			SetInt( 1171, 2192 );

			SetHits( 3176, 3593 );

			SetDamage( 12, 16 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Fire, 50, 70 );
			SetDamageType( ResistanceType.Poison, 50, 70 );
			SetDamageType( ResistanceType.Cold, 50, 70 );
			SetDamageType( ResistanceType.Energy, 50, 70 ); 

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );

			SetSkill( SkillName.MagicResist, 90, 120 );
			SetSkill( SkillName.Tactics, 90, 120 );
			SetSkill( SkillName.Wrestling, 90, 120 );
			SetSkill( SkillName.Healing, 90, 120 );
			SetSkill( SkillName.SpiritSpeak, 90, 120 );
			SetSkill( SkillName.Anatomy, 90, 120 );
			SetSkill( SkillName.Magery, 90, 120 );

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 34;

			PackItem( new FertileDirt() );
			PackGold( 1000, 2500 );
			PackItem( new OrderList() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
			AddLoot( LootPack.Gems );
		}

		public override int Meat{ get{ return 1; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

		public override int Feathers{ get{ return 25; } }
		public override int TreasureMapLevel{ get{ return 1; } }

		public ChickenElemental( Serial serial ) : base( serial )
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
