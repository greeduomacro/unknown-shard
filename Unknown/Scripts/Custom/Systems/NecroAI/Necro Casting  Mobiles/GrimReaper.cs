//Script Version: 0.1a
//Coder: Final Realms
//Script created for: RunUO Forums
//Necromancer Custom AI used.
//You must download this AI for the script to work from:
//http://www.runuo.com/forum/showthread.php?t=36528
//Do not remove this header, Ty.


using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a grim reaper's  corpse" )]
	public class GrimReaper : BaseCreature
	{
		[Constructable]
		public GrimReaper() : base( AIType.AI_Necro, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Grim Reaper";
			Body = 400;
			Hue = 01;
			BaseSoundID = 451;

			SetStr( 150 );
			SetDex( 150 );
			SetInt( 150 );

			SetHits( 5000 );
			SetMana( 5000 );

			SetDamage( 10, 25 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 30 );
			SetDamageType( ResistanceType.Poison, 30 );
			
			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 90 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.Necromancy, 120.0 );
			SetSkill( SkillName.Poisoning, 120.0 );
			SetSkill( SkillName.Meditation, 120.0 );
			SetSkill( SkillName.Anatomy, 120.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Healing, 120.0 );
			SetSkill( SkillName.Swords, 120.0 );
			
			Fame = 8000;
			Karma = -24000;

			VirtualArmor = 60;
			
			new SkeletalMount().Rider = this;
			
			Item arms = new DaemonArms();
			
			arms.Hue = 0x455;
			arms.Movable = false;
			
			Item legs = new DaemonLegs();
			
			legs.Hue = 0x455;
			legs.Movable = false;
			
			Item gloves = new DaemonGloves();
			
			gloves.Hue = 0x455;
			gloves.Movable = false;
			
			Item chest = new DaemonChest();
			
			chest.Hue = 0x455;
			chest.Movable = false;
			
			Item shroud = new HoodedShroudOfShadows();
			
			shroud.Hue = 0x455;
			shroud.Movable = false;
			
			Item shoes = new Sandals();
			
			shoes.Hue = 0x455;
			shoes.Movable = false;

			Scythe weapon = new Scythe();

			weapon.DamageLevel = (WeaponDamageLevel)Utility.Random( 5, 6 );
			weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random( 5, 6 );
			weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random( 5, 6 );
			weapon.Skill = SkillName.Swords;
			weapon.Speed = 46;
			weapon.Hue = 0x151;
			weapon.Weight = 1.0;
			weapon.Movable = false;
			weapon.Attributes.SpellChanneling = 1;

			AddItem( weapon );
			AddItem( gloves );
			AddItem( arms );
			AddItem( chest );
			AddItem( legs );
			AddItem( shoes );
			AddItem( shroud );

			PackGold( 5000, 7500 );
			PackNecroReg( 50, 100 );
			PackItem( new NecromancerSpellbook( (UInt64)0xFFFF ) ); 
		}

		public override bool BardImmune{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override bool Uncalmable{get{return true;} }
		public override bool ClickTitle{ get{ return false; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int TreasureMapLevel{ get{ return 5; } }

		public GrimReaper( Serial serial ) : base( serial )
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