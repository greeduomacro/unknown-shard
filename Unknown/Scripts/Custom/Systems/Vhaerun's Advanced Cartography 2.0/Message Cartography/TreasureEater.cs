/*
created by:
Lord Greywolf
*/
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{

	[CorpseName( "a treasure Eater corpse" )]
	public class TreasureEaters : BaseCreature
	{
		[Constructable]
		public TreasureEaters() : this( 0 ){}

		[Constructable]
		public TreasureEaters(int powerl, int powerh) : this( Utility.RandomMinMax( powerl, powerh ) ){}

		[Constructable]
		public TreasureEaters(int power) : base ( AIType.AI_Mage, FightMode.Weakest, 10, 1, 0.2, 0.4 )
		{
			if (power == 0) power = Utility.RandomMinMax( 1, 25 );
			if (power >= 25) power = 25;
			if (power <= 1) power = 1;

			Body = Utility.RandomList( 12, 59, 46, 265, 103, 104, 62, 60, 61  );
			Hue = Utility.RandomList( 2986, 2999, 2998, 2997, 2995, 2990, 2989, 2980, 2978, 2976, 2975, 2972, 2967, 2957, 2940, 2931, 2862,
				Utility.RandomRedHue(), Utility.RandomYellowHue(),Utility.RandomBlueHue(),Utility.RandomGreenHue(), Utility.RandomAnimalHue(),
				Utility.RandomBirdHue(), Utility.RandomDyedHue(), Utility.RandomHairHue(), Utility.RandomMetalHue(), Utility.RandomNeutralHue(),
				Utility.RandomOrangeHue(), Utility.RandomPinkHue(), Utility.RandomSkinHue(), Utility.RandomSlimeHue(), Utility.RandomSnakeHue() );

			BaseSoundID = 362;

			Name = NameList.RandomName( "daemon" ) + "the Treasure Eater, level " + Convert.ToString(power);

			SetStr( 100 + (power*20), 300 + (power*20) );
			SetDex( 100 + (power*5), 150 + (power*5) );
			SetInt( 100 + (power*20), 300 + (power*20) );

			SetHits( 300 + (power*20), 700 + (power*20) );

			SetDamage( 5 + (power), 10 + (power) );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 20 );
			SetDamageType( ResistanceType.Fire, 20 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 50 + power, 60 + power );
			SetResistance( ResistanceType.Fire, 70 + power, 80 + power );
			SetResistance( ResistanceType.Cold, 50 + power, 60 + power );
			SetResistance( ResistanceType.Poison, 40 + power, 50 + power );
			SetResistance( ResistanceType.Energy, 40 + power, 50 + power );

			SetSkill( SkillName.EvalInt, 80.0 + (power*2), 100.0 + (power*2) );
			SetSkill( SkillName.Magery, 80.0 + (power*2), 100.0 + (power*2) );
			SetSkill( SkillName.MagicResist, 280.0 + (power*2), 400.0 + (power*2) );
			SetSkill( SkillName.Tactics, 80.0 + (power*2), 100.0 + (power*2) );
			SetSkill( SkillName.Wrestling, 80.0 + (power*2), 100.0 + (power*2) );

			Fame = 1000 + (power * 250);
			Karma = -1000 - (power * 250);

			VirtualArmor = (50 + (power));

			int loota = (int)((power/5) + 1);
			AddLoot( LootPack.FilthyRich, (loota) );
			PackItem( new Gold ((power*10), (power*25)));
		}

		public override bool HasBreath{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override int Scales{ get{ return 10; } }
		public override bool BardImmune{ get{ return true; } }

		public TreasureEaters( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
}