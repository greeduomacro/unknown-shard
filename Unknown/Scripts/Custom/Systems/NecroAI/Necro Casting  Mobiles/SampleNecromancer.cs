// Sample Necromancer AI Npc
// Complement to Custom Necromancer AI, by Final Realms
// Npc coded by: Skymoney
// Necro Regs code included.
// Necromancer full spellbook included.
// Necromancer spell book code included, courtesy of Sidsid & GoldDraco13
// Kudos to all of you guys from RunUO Forums.


using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class Necromancer : BaseCreature 
	{ 
		[Constructable] 
		public Necromancer() : base( AIType.AI_Necro, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
			SpeechHue = Utility.RandomDyedHue(); 
			Title = "the Necromancer"; 
			Hue = 0x3C6; 

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" ); 
				AddItem( new Skirt( Utility.RandomRedHue() ) ); 
			} 
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" ); 
				AddItem( new ShortPants( Utility.RandomRedHue() ) ); 
			} 

			SetStr( 386, 400 );
			SetDex( 151, 165 );
			SetInt( 161, 175 );

			SetDamage( 8, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 30 );
			SetResistance( ResistanceType.Cold, 25, 30 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.SpiritSpeak, 100.0 ); 
			SetSkill( SkillName.Necromancy, 100.0 );
			SetSkill( SkillName.Poisoning, 100.0 );
			SetSkill( SkillName.MagicResist, 80.0, 100.0 );


			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 40;

			AddItem( new Shoes( 0x151 ) );
			AddItem( new Robe( 0x455 ) );
			AddItem( new FancyShirt( 0x455 ) );
			PackNecroReg( 50, 100 ); // Creates 10 to 20 of each necro reagent.
			AddItem( new NecromancerSpellbook( (UInt64)0xFFFF ) ); //Code info provided by Sidsid & GoldDraco13

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Meager );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public Necromancer( Serial serial ) : base( serial ) 
		{ 
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