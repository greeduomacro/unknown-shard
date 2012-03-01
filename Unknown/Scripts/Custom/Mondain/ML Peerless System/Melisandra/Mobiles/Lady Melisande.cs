using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a lady's corpse" )]
	public class LadyMelisande : BaseCreature
	{
		[Constructable]
		public LadyMelisande() : base( AIType.AI_Necro, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Lady Melisande";
			Body = 258;
			BaseSoundID = 451;
			
		
			SetStr( 416, 505 );
			SetDex( 246, 365 );
			SetInt( 566, 655 );

			SetHits( 11000, 12000 );

			SetDamage( 28, 40 );
			
			SetDamageType( ResistanceType.Cold, 60 );
			SetDamageType( ResistanceType.Physical, 40 );

			SetResistance( ResistanceType.Physical, 60, 70 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 50, 60 );

		    SetSkill( SkillName.EvalInt, 105.0, 110.0 );
			SetSkill( SkillName.Magery, 120.0, 120.0 );
			SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.Necromancy, 120.0 );
			SetSkill( SkillName.MagicResist, 120.0, 120.0);
			SetSkill( SkillName.Tactics, 110.1, 120.0 );
			SetSkill( SkillName.Wrestling, 120.1, 150.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;
            switch ( Utility.Random( 3 ))
            {                                   
            	case 0: AddItem( new SquirrelSummoner() ); break;
					
							}
			switch ( Utility.Random( 3 ))
            {                                   
            	case 0: AddItem( new MelisandraHairDye() ); break;
            	case 1: AddItem( new MelisandesCorrodedHatchet() ); break;
				case 2: AddItem( new CrimsonCinture() ); break;
					
							}

             switch ( Utility.Random( 11 ))
            {                                  
            	case 0: AddItem( new YamandonIdol() ); break;
            	case 1: AddItem( new WandererIdol() ); break;
				case 2: AddItem( new AbyssmalIdol () ); break;
            	case 3: AddItem( new AncientWyrmIdol () ); break;
				case 4: AddItem( new BoneDemonIdol () ); break;
            	case 5: AddItem( new GamanIdol () ); break;
				case 6: AddItem( new DeathwatchBeetleIdol () ); break;
            	case 7: AddItem( new HiryuIdol () ); break;
				case 8: AddItem( new LadyOfTheSnowIdol() ); break;
            	case 9: AddItem( new RuneBeetleIdol() ); break;
				case 10: AddItem( new ShadowKnightIdol () ); break;      	
							}
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
			PackNecroReg( 50, 80 );
		}

				public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich );
			AddLoot( LootPack.AosSuperBoss );
			PackItem( new Taint(2) );
			PackItem( new Muculent (2) );
			PackItem( new Corruption(2) );
			PackItem( new Blight (2) );
			PackItem( new Scourge(2) );
			PackItem( new Putrefication  (2) );
			 
            
			 
		}
        public override bool AutoDispel{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 4; } }

		public override void OnDeath( Container c )
		{
			c.DropItem( new CorruptedTree() );
			c.DropItem( new CorruptedTree() );
			c.DropItem( new DiseasedBark() );

			base.OnDeath( c );
		}
		
		public LadyMelisande( Serial serial ) : base( serial )
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