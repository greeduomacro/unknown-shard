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
	public class KeyHolder : BaseCreature 
	{

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

		[Constructable] 
		public KeyHolder() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Title = "the Key Holder";
			Name = ( "Lilith" );
			Body = 40;
			Hue = 1530;  

			SetStr( 900, 1100 );
			SetDex( 291, 315 );
			SetInt( 600, 720 );

			SetHits( 3520, 4725 );

			SetDamage( 7, 8 );

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

            ME me = new ME();
            me.Hue = 1154;
            me.Movable = false;
            AddItem(me);

		}

        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override bool AlwaysMurderer { get { return true; } }

		public override void GenerateLoot()
		{
            if (1 > Utility.RandomDouble()) // 1 = 100% = chance to drop 
                switch (Utility.Random(1))
                {
                    case 0: AddToBackpack(new SphereOfProtection()); break;
                }
            PackGold(6700);
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.Gems, 5 );
		}

        public KeyHolder(Serial serial)
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
