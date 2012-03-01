using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an undead horse corpse" )]
	public class ARedDeath : BaseMount
	{
		public static int AbilityRange { get { return 10; } }

		private static int m_MinTime = 10;
		private static int m_MaxTime = 30;

		private DateTime m_NextAbilityTime;
		
		[Constructable] 
		public ARedDeath() : this( "Red Death" )
		{
		}

		[Constructable]
		public ARedDeath( string name ) : base( name, 793, 0x3EBB, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Hue = 0;
            BaseSoundID = 0x488;

			SetStr( 317, 325 );
			SetDex( 242, 252 );
			SetInt( 245, 255 );

			SetHits( 1605, 1615 );

			SetDamage( 25, 25 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 65, 70 );
			SetResistance( ResistanceType.Fire, 90, 95 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.MagicResist, 133.1, 143.0 );
			SetSkill( SkillName.Tactics, 131.8, 141.8 );
			SetSkill( SkillName.Wrestling, 133.6, 143.6 );
			SetSkill( SkillName.Anatomy, 132.9, 142.9 );
			
			Fame = 12000;
			Karma = -12000;
			
			Tamable = false;
			MinTameSkill = 0.0;
			ControlSlots = 0;
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
			PackItem( new ResolveBridle() );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BleedImmune { get { return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled

		public ARedDeath( Serial serial ) : base( serial )
		{
		}
		
public override void OnDeath( Container c )
{
	if ( Utility.Random( 2 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 1 ))
		{
                        default:
			case 1: item = new JonahDeath(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
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
