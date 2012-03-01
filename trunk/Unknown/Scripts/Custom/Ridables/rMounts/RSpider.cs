using System; 
using Server; 
using Server.Items; 

namespace Server.Mobiles 
{ 
        [CorpseName( "a huge spider corpse" )] 
        public class RSpider : BaseMount 
        { 
                [Constructable] 
                public RSpider() : this( "a huge spider" ) 
                { 
                } 

                [Constructable] 
                public RSpider ( string name ) : base( name, 0xAD, 0x3f11, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
                { 
                        Name = "a huge spider";
                        Body = Utility.RandomList( 173 ); 
                        BaseSoundID = 0x183; 
          

         		SetStr( 421, 460 ); 
         		SetDex( 133, 152 ); 
         		SetInt( 101, 140 );

			SetHits( 278, 299 );

			SetDamage( 14, 21 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.Wrestling, 70.1, 85.0 );

			Fame = 5500;
			Karma = -5500;

			VirtualArmor = 46;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 94.3;

			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override int TreasureMapLevel{ get{ return 2; } }
		public override int Meat{ get{ return 10; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }

		public RSpider( Serial serial ) : base( serial )
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