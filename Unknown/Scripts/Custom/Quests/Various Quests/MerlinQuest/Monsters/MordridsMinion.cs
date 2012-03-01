/////////////////
///LostSinner///
///////////////
using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an hideous corpse" )] 
	public class MordridsMinion : BaseCreature 
	{ 
		[Constructable] 
		public MordridsMinion() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Title = "Slave of mordrid";
			Name = NameList.RandomName( "male" );
			Body = 14;
			Hue = 1530;  

			SetStr( 400, 500 );
			SetDex( 91, 115 );
			SetInt( 600, 720 );

			SetHits( 620, 725 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 0, 1 );
			SetResistance( ResistanceType.Fire, 0, 1 );
			SetResistance( ResistanceType.Poison, 0, 1 );
			SetResistance( ResistanceType.Energy, 0, 1 );

			SetSkill( SkillName.EvalInt, 85.0, 100.0 );
			SetSkill( SkillName.Tactics, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.0, 97.5 );
			SetSkill( SkillName.Wrestling, 20.2, 60.0 );
			SetSkill( SkillName.Meditation, 120.0);
			SetSkill( SkillName.Focus, 120.0);
			SetSkill( SkillName.Magery, 140.0, 150.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 50;

		}

		public override void GenerateLoot()
		{
			PackGold(7700);
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.Gems, 5 );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

        public MordridsMinion(Serial serial)
            : base(serial)
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
