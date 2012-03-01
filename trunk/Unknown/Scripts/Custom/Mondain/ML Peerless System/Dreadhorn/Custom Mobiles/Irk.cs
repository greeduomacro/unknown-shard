//Written By Milkman Dan 2006
//Property of DemonicRidez.com
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Irk's corpse" )]
	public class Irk : BaseCreature
	{

		[Constructable]
		public Irk() : base( AIType.AI_Melee, FightMode.Closest, 18, 1, 0.2, 0.4  )
		{
			Name = "Irk";
			Body = 264;
			Hue = 1161;
			BaseSoundID = 0x451;
           
			SetStr( 165, 165 );
			SetDex( 346, 346 );
			SetInt( 555, 555 );

			SetHits( 1022, 1022 );

			SetDamage( 28, 39 );

			SetResistance( ResistanceType.Physical, 80, 84 );
			SetResistance( ResistanceType.Fire, 50, 55 );
			SetResistance( ResistanceType.Cold, 50, 55 );
			SetResistance( ResistanceType.Poison, 50, 55 );
			SetResistance( ResistanceType.Energy, 45, 50 );

			SetSkill( SkillName.MagicResist, 150.1, 165.0 );
			SetSkill( SkillName.Tactics, 120.1, 150.0 );
			SetSkill( SkillName.Wrestling, 120.1, 150.0 );

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 75;
            AddItem( new DarkSource() );
			
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
			AddLoot( LootPack.FilthyRich );
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if (from.Combatant == null)
			return;

			Mobile m = from.Combatant;						

			if (m.Body == 58)
				m.Say( "I now own your soul!!!" ); 

			if (m.Body != from.Body)
                    	{
				m.BoltEffect( 0 );

				m.Body = from.Body; 
				m.Hue = from.Hue; 
				m.Name = from.Name;

      				m.Fame = from.Fame;
      				m.Karma = (0-from.Karma);
      				m.Title = from.Title;
      	 			
      				m.Str = from.Str;
      				m.Int = from.Int;
				m.Dex = from.Dex;

      				m.Hits =from.Hits + 2000;

      				m.Dex = from.Dex;
      				m.Mana = from.Mana;
      				m.Stam = from.Stam;

				m.Female = from.Female;
      	
      				m.VirtualArmor = (from.VirtualArmor +95);
      	
				Item hair = new Item( Utility.RandomList( 8265 ) );
				hair.Hue = 1167;
				hair.Layer = Layer.Hair;
				hair.Movable = false;
				m.AddItem( hair );

				Kasa hat = new Kasa();				
				hat.Hue = 1167;
				hat.Movable = false;
				m.AddItem( hat );

				DeathRobe robe = new DeathRobe();
				robe.Name = "Death Robe";
				robe.Hue = 1167;
				robe.Movable = false;
				m.AddItem( robe );
		
				Sandals sandals = new Sandals();				
				sandals.Hue = 1167;
				sandals.Movable = false;
				m.AddItem( sandals );				

				BagOfAllReagents bag = new BagOfAllReagents();
				m.AddToBackpack( bag );
			
				m.BoltEffect( 0 );
			}
			switch ( Utility.Random( 5 ) )
			{
				
				case 0: m.Say( "We are now one with each other!!" ); break;
				case 1: m.Say( "Your weak spells have no effect on me, muahahaha!!" ); break;
				case 2: m.Say( "Your end is near young adventurer!!" ); break;
				case 3: m.Say( "Thou shalt not pass my post!!" ); break;
				case 4: m.Say( "I now own your soul!!!" ); break;
			}
			from.BoltEffect( 0 );
			from.Damage( Utility.Random( 1, 50 ) );
			m.Hits += ( Utility.Random( 1, 50 ) );
		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

public override void OnDeath( Container c )
{
	if ( Utility.Random( 2 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 1 ))
		{
                        default:
			case 1: item = new IrkBrain(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
}

		public Irk( Serial serial ) : base( serial )
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