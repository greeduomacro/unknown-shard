/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 5/23/2006
 * Time: 6:16 PM
 * 
 * 
 */

using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class ALadyJennifyr : BaseCreature
	{
		[Constructable]
		public ALadyJennifyr() : base( AIType.AI_Necro, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Lady Jennifyr";
			Body = 147;
			Hue = 961;
			BaseSoundID = 451;

			SetStr( 303, 313 );
			SetDex( 125, 135 );
			SetInt( 92, 102 );

			SetHits( 1400, 1416 );

			SetDamage( 20, 20 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 58, 65 );
			SetResistance( ResistanceType.Fire, 42, 49 );
			SetResistance( ResistanceType.Cold, 71, 80 );
			SetResistance( ResistanceType.Poison, 41, 50 );
			SetResistance( ResistanceType.Energy, 50, 59 );

			SetSkill( SkillName.EvalInt, 120.1, 130.0 );
			SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.Necromancy, 120.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.Wrestling, 105.1, 105.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 40;

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

		public override bool BleedImmune { get { return true; } }
        public override bool AutoDispel{ get{ return true; } }
		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich );
			AddLoot( LootPack.AosSuperBoss );
		}

		public ALadyJennifyr( Serial serial ) : base( serial )
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
