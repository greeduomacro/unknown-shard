
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a swoop corpse" )]
	public class Swoop : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}
		[Constructable]
		public Swoop() : base( AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4 )
		{
			Name = "Swoop";
			Body = 5;
			Hue = 23; 
			BaseSoundID = 0x8F;

			SetStr( 134, 139 );
			SetDex( 423, 428 );
			SetInt( 79, 84 );

			SetHits( 566, 576 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 65, 70 );
			SetResistance( ResistanceType.Fire, 30, 35 );
			SetResistance( ResistanceType.Cold, 38, 43 );
			SetResistance( ResistanceType.Poison, 21, 26 );
			SetResistance( ResistanceType.Energy, 20, 25 );

			SetSkill( SkillName.MagicResist, 89.1, 99.1 );
			SetSkill( SkillName.Tactics, 87.1, 97.8 );
			SetSkill( SkillName.Wrestling, 80.1, 90.2 );

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 65;

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
			AddLoot( LootPack.UltraRich, 2 );
			AddLoot( LootPack.FilthyRich );
		}

		public override int Meat { get { return 1; } }
		public override MeatType MeatType { get { return MeatType.Bird; } }
		public override int Feathers { get { return 36; } }

		public Swoop( Serial serial ) : base( serial )
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
