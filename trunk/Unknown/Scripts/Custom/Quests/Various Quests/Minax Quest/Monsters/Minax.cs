//Written by Lord Dalamar
using System; 
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an evil corpse" )] 
	public class Minax1 : BaseCreature 
	{ 
		[Constructable] 
		public Minax1() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 

			SpeechHue = Utility.RandomDyedHue();
			Name = "Minax";
			Title = "the Sorceress of Evil";
			Body = 401;  
			Female = true; 
			BaseSoundID = 1154;
			Hue = 1150; 


			this.Body = 0x191;
			AddItem( new ChestMinax() );
			AddItem( new GlovesMinax() );
			AddItem( new LegsMinax() );
			AddItem( new GorgetMinax() );
			AddItem( new Sandals( 1172 ) );

			AddItem( new StaffMinax() );

			new EtherealHorse().Rider = this;


			SetStr( 900, 1100 );
			SetDex( 100, 200 );
			SetInt( 500, 1500 );

			SetHits( 400, 700 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 80 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Poison, 60, 80 );
			SetResistance( ResistanceType.Energy, 60, 80 );

			SetSkill( SkillName.EvalInt, 120.0, 150.0 );
			SetSkill( SkillName.Magery, 120.0, 150.0 );
			SetSkill( SkillName.Meditation, 120.0, 150.0 );
			SetSkill( SkillName.MagicResist, 120.0, 180.0 );
			SetSkill( SkillName.Tactics, 120.0, 150.0 );
			SetSkill( SkillName.Macing, 120.0, 150.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 75;

			PackItem( new SigilofMinax() );
			PackItem( new MessageToKnolan() );

			PackReg( 57 );
			PackGold( 10000, 15000 );
			PackScroll( 2, 7 );
			PackScroll( 2, 7 );


			PackNecroScroll( 6 ); // Lich Form

                	Item hair = new Item( Utility.RandomList( 0x203C ) );
			hair.Layer = Layer.Hair; 
			hair.Movable = false; 
			AddItem( hair ); 
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public Minax1( Serial serial ) : base( serial ) 
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