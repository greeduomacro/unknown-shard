using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "Ooshkis corpse" )]
	public class Ooshki : BaseCreature
	{
		[Constructable]
		public Ooshki () : base( AIType.AI_Mage, FightMode.Strongest, 10, 1, 0.2, 0.3 )
		{
			Name = "Ooshki";
			Body = 173;
			BaseSoundID = 387;
			Hue = 1157;

			SetStr( 250, 400 );
			SetDex( 126, 145 );
			SetInt( 28860, 30100 );

			SetHits( 15000, 25000 );

			SetDamage( 19, 35 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 300 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 190, 200 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.EvalInt, 90.1, 200.0 );
			SetSkill( SkillName.Magery, 85.1, 100.0 );
			SetSkill( SkillName.Meditation, 95.1, 120.0 );
			SetSkill( SkillName.MagicResist, 55.1, 85.0 );
			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.Wrestling, 70.1, 110.0 );

			Fame = 8000;
			Karma = -8000;

			VirtualArmor = 50;

			PackItem( new SpidersSilk( 150 ) );
						
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
		}
	
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BardImmune{ get{ return true; } }

		public static void PlaceItemIn( Container parent, int x, int y, Item item )
		{
			parent.AddItem( item );
			item.Location = new Point3D( x, y, 0 );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			PlaceItemIn( c, 20, 86, new Gold(1000, 2000) );
			PlaceItemIn( c, 40, 70, new Gold(1000, 2000) );
			PlaceItemIn( c, 80, 90, new Gold(1000, 2000) );
			PlaceItemIn( c, 77, 130, new Gold(1000, 2000) );
			PlaceItemIn( c, 44, 99, new Gold(1000, 2000) );
			PlaceItemIn( c, 80, 164, new Gold(1000, 2000) );

			PlaceItemIn( c, 25, 166, new Gold(1000, 2000) );
			PlaceItemIn( c, 34, 20, new Gold(1000, 2000) );
			PlaceItemIn( c, 90, 100, new Gold(1000, 2000) );
			PlaceItemIn( c, 14, 20, new Gold(1000, 2000) );
			PlaceItemIn( c, 66, 99, new Gold(1000, 2000) );
			PlaceItemIn( c, 30, 164, new Gold(1000, 2000) );

			PlaceItemIn( c, 20, 46, new Gold(1000, 2000) );
			PlaceItemIn( c, 40, 90, new Gold(1000, 2000) );
			PlaceItemIn( c, 30, 115, new Gold(1000, 2000) );
			PlaceItemIn( c, 77, 110, new Gold(1000, 2000) );
			PlaceItemIn( c, 44, 80, new Gold(1000, 2000) );
			PlaceItemIn( c, 80, 124, new Gold(1000, 2000) );

			PlaceItemIn( c, 20, 86, new Gold(1000, 2000) );
			PlaceItemIn( c, 40, 70, new Gold(1000, 2000) );
			PlaceItemIn( c, 80, 90, new Gold(1000, 2000) );
			PlaceItemIn( c, 77, 130, new Gold(1000, 2000) );
			PlaceItemIn( c, 44, 99, new Gold(1000, 2000) );
			PlaceItemIn( c, 40, 164, new Gold(1000, 2000) );

			PlaceItemIn( c, 25, 106, new Gold(1000, 2000) );
			PlaceItemIn( c, 34, 20, new Gold(1000, 2000) );
			PlaceItemIn( c, 90, 100, new Gold(1000, 2000) );
			PlaceItemIn( c, 44, 120, new Gold(1000, 2000) );
			PlaceItemIn( c, 66, 99, new Gold(1000, 2000) );
			PlaceItemIn( c, 80, 164, new Gold(1000, 2000) );

			PlaceItemIn( c, 20, 46, new Gold(1000, 2000) );
			PlaceItemIn( c, 40, 90, new Gold(1000, 2000) );
			PlaceItemIn( c, 80, 30, new Gold(1000, 2000) );
			PlaceItemIn( c, 77, 110, new Gold(1000, 2000) );
			PlaceItemIn( c, 47, 124, new Gold(1000, 2000) );
			PlaceItemIn( c, 80, 124, new Gold(1000, 2000) );
 
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			BaseCreature c = defender as BaseCreature;

			if ( c is BaseCreature && c.Controlled )
			{
				if ( 0.1 >= Utility.RandomDouble() )
					DoSpecial( defender );
			}
			else
			{
				DebugSay( "Not a pet, just attack I shall!" );
			}
		}

		public void DoSpecial( Mobile target )
		{
			AddWebCase( target );
		}

		public void AddWebCase( Mobile m )
		{
			new WebCase().MoveToWorld( m.Location, m.Map );
			PublicOverheadMessage( MessageType.Emote, 0x47E, true, "*Fangs Sink Deep, And Webbing Surrounds The Beast*" );
			m.PlaySound( 922 );
			m.Kill();
		}

		public Ooshki( Serial serial ) : base( serial )
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