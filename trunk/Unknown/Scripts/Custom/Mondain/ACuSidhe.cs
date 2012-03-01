//Took infor from Stratics, used missing sections from the hiryu
//Colors are ore plus a white, blaze and darkness( wasnt sure on this one and didnt know what Pink they used:/)
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
[CorpseName( "a Cu Sidhe corpse" )]
	public class ACuSidhe : BaseMount
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}
		
		[Constructable]
		public ACuSidhe() : this( "a Cu Sidhe" )
		{
		}
		[Constructable]
		public ACuSidhe( string name ) : base( name, 277, 0x3e91, AIType.AI_Animal, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{			
			BaseSoundID = 0xE5;
			Hue = Utility.RandomList( 0x0, 0x973, 0x966, 0x96D, 0x972, 0x8A5, 0x979, 0x89F, 0x8AB, 0x489, 1151, 1175 );

			SetStr( 1200, 1225 );
			SetDex( 170, 270 );// stratics has 150,170 but this is amount after taming so setting this to Hiryu Dex
			SetInt( 250, 285 );

			SetHits( 1010, 1170 );
			SetMana( 60, 65 );//from Hiryu
			SetStam( 170, 270 );//from hiryu

			SetDamage( 22, 28 );//hiryu damage

			SetDamageType( ResistanceType.Cold, 50 );
			SetDamageType( ResistanceType.Energy, 50 );			

			SetResistance( ResistanceType.Physical, 45, 55 );//used 5 over and 5 under what stratics posted
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 65, 75 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 65, 75 );

            SetSkill( SkillName.Healing, 77.7, 99.9 );
			SetSkill( SkillName.Anatomy, 77.7, 99.9 );
			SetSkill( SkillName.MagicResist, 76.0, 89.7 );
			SetSkill( SkillName.Tactics, 94.0, 97.6 );
			SetSkill( SkillName.Wrestling, 93.9, 99.9 );

			SetFameLevel( 5 );
			SetKarmaLevel( 5 );

			VirtualArmor = 75;

			Tamable = true;
			ControlSlots = 4;//assuming these take same ammount of slots as a Hiryu
			MinTameSkill = 101.1;
			
			PackGold( 750, 950 );//1500 1900 is the gold amount found on these
			PackMagicItems( 1, 5 );
			PackItem( new Bandage( 20 ) );// a total guess on the amount
			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );// to add a couple more magic items and the additional gold to make the 1500 mark			
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}
		
		public override double GetControlChance( Mobile m )
		{
		  			if ( m.Skills[SkillName.AnimalTaming].Base < 93.0 )
		     			{
		     			m.SendMessage( "You would not be able to control this creature." );
		     			return 0;
		     			}
					else
					{
					 return 1.0;
			}
				
		}	

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 10; } }
		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
		public override int TreasureMapLevel { get { return 5; } }
		
		public ACuSidhe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}
