using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class SirPatrick : BaseCreature
	{
		[Constructable]
		public SirPatrick() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Sir Patrick";
			Hue = 1150;
			Body = 57;
			BaseSoundID = 451;

			SetStr( 315, 313 );
			SetDex( 200, 200 );
			SetInt( 75, 75 );

			SetHits( 800, 800 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 65, 65 );
			SetResistance( ResistanceType.Fire, 65, 65 );
			SetResistance( ResistanceType.Cold, 65, 65 );
			SetResistance( ResistanceType.Poison, 65, 65 );
			SetResistance( ResistanceType.Energy, 65, 65 );

			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 120.0, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0, 120.0 );
			SetSkill( SkillName.Anatomy, 120.0, 120.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;
			
			switch ( Utility.Random( 6 ) )
			{
				case 0: PackItem( new PlateArms() ); break;
				case 1: PackItem( new PlateChest() ); break;
				case 2: PackItem( new PlateGloves() ); break;
				case 3: PackItem( new PlateGorget() ); break;
				case 4: PackItem( new PlateLegs() ); break;
				case 5: PackItem( new PlateHelm() ); break;
			}

			PackSlayer();
			PackItem( new Scimitar() );
			PackItem( new WoodenShield() );
		 
		 switch ( Utility.Random( 64 ))
            {                                   
            	case 0: AddItem( new PlateOfHonorArms() ); break;
            	case 1: AddItem( new PlateOfHonorChest() ); break;
				case 2: AddItem( new PlateOfHonorGloves () ); break;
            	case 3: AddItem( new PlateOfHonorGorget () ); break;       
				case 4: AddItem( new PlateOfHonorHelm () ); break;		
				case 5: AddItem( new PlateOfHonorLegs () ); break;		
				case 6: AddItem( new AcolyteArms() ); break;
            	case 7: AddItem( new AcolyteChest() ); break;
				case 8: AddItem( new AcolyteGloves () ); break;	
				case 9: AddItem( new AcolyteLegs () ); break;	
				case 10: AddItem( new EvocaricusSword() ); break;
            	case 11: AddItem( new MalekisHonor() ); break;
				case 12: AddItem( new GrizzleArms() ); break;
            	case 13: AddItem( new GrizzleChest() ); break;
				case 14: AddItem( new GrizzleGloves () ); break;       
				case 15: AddItem( new GrizzleHelm () ); break;		
				case 16: AddItem( new PlateOfHonorLegs () ); break;
				case 17: AddItem( new MageArmorArms() ); break;
            	case 18: AddItem( new MageArmorChest() ); break;
				case 19: AddItem( new MageArmorGloves () ); break;	
				case 20: AddItem( new MageArmorLegs () ); break;                    
				case 21: AddItem( new MyrmidonArms() ); break;
            	case 22: AddItem( new MyrmidonChest() ); break;
				case 23: AddItem( new MyrmidonGloves () ); break;
            	case 24: AddItem( new MyrmidonGorget () ); break;       
				case 25: AddItem( new MyrmidonHelm () ); break;		
				case 26: AddItem( new MyrmidonLegs () ); break;		
				case 27: AddItem( new DeathEssenceArms() ); break;
            	case 28: AddItem( new DeathEssenceChest() ); break;
				case 29: AddItem( new DeathEssenceGloves () ); break;      
				case 30: AddItem( new DeathEssenceHelm () ); break;		
				case 31: AddItem( new DeathEssenceLegs () ); break;		
 }
 }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich );
			AddLoot( LootPack.AosSuperBoss );
		}

		public override bool BleedImmune{ get{ return true; } }
        public override bool AutoDispel{ get{ return true; } }
		
		public SirPatrick( Serial serial ) : base( serial )
		{
		}

		public override void OnDeath( Container c )
{
	if ( Utility.Random( 10 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 3 ))
		{
                        default:
			case 1: item = new JonahNote1(); break;
			case 2: item = new JonahNote2(); break;
			case 3: item = new JonahNote3(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
}

		
		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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