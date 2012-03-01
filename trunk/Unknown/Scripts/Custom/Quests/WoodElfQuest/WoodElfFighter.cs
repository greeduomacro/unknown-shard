using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an elf corpse" )] 
	public class WoodElfFighter : BaseCreature 
	{ 
		public override bool AlwaysMurderer{ get{ return true; } }
		
		[Constructable] 
		public WoodElfFighter() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )  // TODO apellweaving AI
		{ 			
			Hue = 1941;

			if ( Female = Utility.RandomBool() )
			{
				Body = 606;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 605;
				Name = NameList.RandomName( "male" );
			}
				
			Title = "the fighter";
			
			SetStr( 86, 100 );
			SetDex( 81, 95 );
			SetInt( 61, 75 );
			SetHits( 2500, 3600 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Fire, 10, 15 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 25.0, 47.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 15.0, 37.5 );	
			
			// outfit
			AddItem( new Shirt( Utility.RandomNeutralHue() ) );
			
			switch( Utility.Random( 4 ) )
			{
				case 0: AddItem( new Sandals() ); break;
				case 1: AddItem( new Shoes() ); break;
				case 2: AddItem( new Boots() ); break;
				case 3: AddItem( new ThighBoots() ); break;
			}
			
			if ( Female )
			{
				if ( Utility.RandomBool() )
					AddItem( new Skirt( Utility.RandomNeutralHue() ) );
				else
					AddItem( new Kilt( Utility.RandomNeutralHue() ) );
			}
			else
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) );				
			
			// hair, facial hair			
			HairItemID = Race.Elf.RandomHair( Female );
			HairHue = Race.Elf.RandomHairHue();
			
			// weapon, shield
			AddItem( Loot.RandomWeapon() );
			
			if ( Utility.RandomBool() )
				AddItem( Loot.RandomShield() );
								
			PackGold( 50, 150 );
		}

		public WoodElfFighter( Serial serial ) : base( serial )
		{
		}
		
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );	
/*
			if ( Utility.RandomDouble() < 0.75 )
				c.DropItem( new SeveredElfEars() );
*/
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
		}
	}
}