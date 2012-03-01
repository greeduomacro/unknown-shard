//Written by Lord Dalamar
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a golden goat corpse" )]
	public class KhalkistGoat : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 125.0; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public KhalkistGoat () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Golden Goat of the Khalkists";
			Body = 209;
			BaseSoundID = 357;

			SetStr( 676, 705 );
			SetDex( 106, 125 );
			SetInt( 401, 425 );

			SetHits( 700, 900 );

			SetDamage( 25, 28 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 80 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Poison, 60, 80 );
			SetResistance( ResistanceType.Energy, 60, 80 );

			SetSkill( SkillName.EvalInt, 120.0, 140.0 );
			SetSkill( SkillName.Magery, 120.0, 140.0 );
			SetSkill( SkillName.MagicResist, 200.0, 350.0 );
			SetSkill( SkillName.Tactics, 120.0, 140.0 );
			SetSkill( SkillName.Wrestling, 120.0, 140.0 );

			Fame = 15000;
			Karma = -15000;
                        Hue = 2213;

			VirtualArmor = 90;
			ControlSlots = 5;
			
			PackItem( new GoldenWool() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return false; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 200; } }

		public KhalkistGoat( Serial serial ) : base( serial )
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
