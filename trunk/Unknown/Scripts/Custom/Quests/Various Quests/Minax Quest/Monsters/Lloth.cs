//Written by Lord Dalamar
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a spider goddess corpse" )]
	public class Lloth : BaseCreature
	{
		[Constructable]
		public Lloth () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Lloth";
			Title = "Goddess of the Underworld";
			Body = 173;
			BaseSoundID = 357;
			Hue = 1161;

			SetStr( 800, 1100 );
			SetDex( 135, 150 );
			SetInt( 15000, 15000 );

			SetHits( 800, 1100 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 80 );
			SetDamageType( ResistanceType.Energy, 80 );

			SetResistance( ResistanceType.Physical, 60, 85 );
			SetResistance( ResistanceType.Fire, 60, 85 );
			SetResistance( ResistanceType.Cold, 60, 85 );
			SetResistance( ResistanceType.Poison, 60, 85 );
			SetResistance( ResistanceType.Energy, 60, 85 );

			SetSkill( SkillName.Anatomy, 125.1, 150.0 );
			SetSkill( SkillName.EvalInt, 125.0, 130.0 );
			SetSkill( SkillName.Magery, 295.5, 300.0 );
			SetSkill( SkillName.Meditation, 225.1, 250.0 );
			SetSkill( SkillName.MagicResist, 200.0, 300.0 );
			SetSkill( SkillName.Tactics, 130.0, 150.0 );
			SetSkill( SkillName.Wrestling, 130.0, 150.0 );

			Fame = 24000;
			Karma = -24000;

			VirtualArmor = 90;

			PackItem( new FireSilk() );
			PackItem( new FireSilk() );
			PackItem( new Longsword() );
			PackGold( 9000, 10000 );
			PackScroll( 4, 12 );
			PackArmor( 8, 12 );
			PackWeapon( 7, 9 );
			PackWeapon( 5, 5 );
			PackSlayer();
			
		}
		
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return false; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public Lloth( Serial serial ) : base( serial )
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

