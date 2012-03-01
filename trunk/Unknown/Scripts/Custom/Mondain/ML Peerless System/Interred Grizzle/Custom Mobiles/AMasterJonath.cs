using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class AMasterJonath : BaseCreature
	{
		[Constructable]
		public AMasterJonath() : base( AIType.AI_Necro, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Master Jonath";
			Body = 148;
			Hue = 961;
			BaseSoundID = 451;

			SetStr( 120, 130 );
			SetDex( 120, 120 );
			SetInt( 249, 259 );

			SetHits( 950, 970 );

			SetDamage( 20, 20 );//was 7,15

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 60 );
			SetResistance( ResistanceType.Fire, 41, 49 );
			SetResistance( ResistanceType.Cold, 74, 79 );
			SetResistance( ResistanceType.Poison, 43, 50 );
			SetResistance( ResistanceType.Energy, 51, 57 );

			SetSkill( SkillName.EvalInt, 120.1, 130.0 );
			SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.Necromancy, 120.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.Wrestling, 105.1, 105.0 );

			Fame = 12000;
			Karma = -12000;

			VirtualArmor = 38;

			PackReg( 3 );
			PackNecroReg( 3, 10 );
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
			AddLoot( LootPack.HighScrolls );
			AddLoot( LootPack.Potions );
		}

		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune { get { return Poison.Greater; } }
		public override bool BleedImmune { get { return true; } }

		public AMasterJonath( Serial serial ) : base( serial )
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
