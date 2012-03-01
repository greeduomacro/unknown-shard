/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 5/24/2006
 * Time: 4:15 PM
 * 
 * 
 */

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a putrefier corpse" )]
	public class APutrefier : BaseCreature
	{
		[Constructable]
		public APutrefier() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Putrefier";
			Body = 40;
			Hue = 1372;
			BaseSoundID = 357;

			SetStr( 1035 , 1244 );
			SetDex( 212 , 306 );
			SetInt( 181 , 300 );

			SetHits( 3009, 3614 );

			SetDamage( 22, 29 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 80 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 30.1, 60.0 );
			SetSkill( SkillName.EvalInt, 108.1, 120.0 );
			SetSkill( SkillName.Magery, 114.6, 120.0 );
			SetSkill( SkillName.Meditation, 30.1, 60.0 );
			SetSkill( SkillName.MagicResist, 120.6, 180.0 );
			SetSkill( SkillName.Tactics, 108.1, 120.0 );
			SetSkill( SkillName.Wrestling, 108.1, 120.0 );

			Fame = 32000;
			Karma = -32000;

			VirtualArmor = 90;

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
			AddLoot( LootPack.UltraRich, 4 );
			AddLoot( LootPack.HighScrolls, 2 );
		}

		public override bool CanRummageCorpses { get { return true; } }
		public override Poison PoisonImmune { get { return Poison.Deadly; } }
		public override int TreasureMapLevel { get { return 5; } }
		public override int Meat { get { return 1; } }

public override void OnDeath( Container c )
{
	if ( Utility.Random( 4 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 1 ))
		{
                        default:
			case 1: item = new PutrifierSpleen(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
}

		public APutrefier( Serial serial ) : base( serial )
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
