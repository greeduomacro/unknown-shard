using System;
using Server;
using Server.Misc;
using Server.Items;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a changeling corpse" )]
	public class Changeling : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Wisp; } }

		[Constructable]
		public Changeling() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Changeling";
			Body = 264;
			BaseSoundID = 0x451;

			SetStr( 125, 125 );
			SetDex( 156, 275 );
			SetInt( 181, 205 );

			SetHits( 275, 275 );

			SetDamage( 28, 39 );

			SetResistance( ResistanceType.Physical, 60, 75 );
			SetResistance( ResistanceType.Fire, 50, 65 );
			SetResistance( ResistanceType.Cold, 50, 65 );
			SetResistance( ResistanceType.Poison, 50, 65 );
			SetResistance( ResistanceType.Energy, 60, 75 );

			SetSkill( SkillName.MagicResist, 135.1, 165.0 );
			SetSkill( SkillName.Tactics, 120.1, 150.0 );
			SetSkill( SkillName.Wrestling, 120.1, 150.0 );

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 75;

			AddItem( new DarkSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
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


		public Changeling( Serial serial ) : base( serial )
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