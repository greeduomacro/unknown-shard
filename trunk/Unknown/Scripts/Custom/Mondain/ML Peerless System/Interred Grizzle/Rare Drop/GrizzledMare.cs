using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a undead corpse" )]
	public class GrizzledMare : BaseMount
	{
		[Constructable]
		public GrizzledMare() : this( "Grizzled Mare" )
		{
		}

		[Constructable]
		public GrizzledMare( string name ) : base( name, 793, 0x3EBB, AIType.AI_Necro, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
		    Body = 793;
			Hue = 0;
            SetStr( 300, 300 );
			SetDex( 200,225 );
			SetInt( 500, 500 );

			SetHits( 1000, 1000 );
			SetStam( 200, 250 );
			SetMana( 500, 500 );

			SetDamage( 25, 30 );
			
					SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 100, 100 );
			SetResistance( ResistanceType.Fire, 50, 50 );
			SetResistance( ResistanceType.Cold, 50, 50 );
			SetResistance( ResistanceType.Poison, 50, 50 );
			SetResistance( ResistanceType.Energy, 50, 50 );

			SetSkill( SkillName.EvalInt, 120.1, 130.0 );
			SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.Necromancy, 120.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.Wrestling, 105.1, 105.0 );

			Fame = 2000;
			Karma = -2000;

			Tamable = true;
			ControlSlots = 2;
		}

		public override double GetControlChance( Mobile m )
		{
			return 1.0;
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public GrizzledMare( Serial serial ) : base( serial )
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