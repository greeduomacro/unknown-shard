using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a swamp dragon corpse" )]
	public class ProxySwampy : BaseMount
	{
		[Constructable]
		public ProxySwampy() : this( "Proxymous Swamp Dragon" )
		{
		}

		[Constructable]
		public ProxySwampy( string name ) : base( name, 0x31F, 0x3EBE, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
		    Hue = 0x851;
SetStr( 200, 250 );
			SetDex( 100,125 );
			SetInt( 25, 35 );

			SetHits( 250, 350 );
			SetStam( 200, 250 );
			SetMana( 20, 25 );

			SetDamage( 25, 30 );
			
					SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 100, 100 );
			SetResistance( ResistanceType.Fire, 50, 50 );
			SetResistance( ResistanceType.Cold, 50, 50 );
			SetResistance( ResistanceType.Poison, 50, 50 );
			SetResistance( ResistanceType.Energy, 50, 50 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0, 100.0 );

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

		public ProxySwampy( Serial serial ) : base( serial )
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