/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 5/30/2006
 * Time: 5:44 AM
 * 
 * Thrasher - Blighted Grove
 */
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an thrasher corpse" )]
	public class AThrasher : BaseCreature
	{
		[Constructable]
		public AThrasher() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Thrasher";
			Body = 0xCA;
			Hue = 32;//looks really dark red?
			BaseSoundID = 660;

			SetStr( 76, 100 );//guessing this is same as aligator, stratics has 94 str
			SetDex( 215, 235 );
			SetInt( 11, 20 );//guessing same as aligator, stratics has 20

			SetHits( 664, 684 );
			SetStam( 215, 235 );
			SetMana( 20 );

			SetDamage( 10, 20 );//aligator is 5, 15

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 21, 26 );
			SetResistance( ResistanceType.Poison, 25, 30 );

			SetSkill( SkillName.MagicResist, 113.8, 118.8 );
			SetSkill( SkillName.Tactics, 98.3, 103.3 );
			SetSkill( SkillName.Wrestling, 94.1, 99.0 );

			Fame = 6000;
			Karma = -6000;

			VirtualArmor = 40;//aligator is 30
		
		}
		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 6 );
		}

		public override int Meat { get { return 1; } }
		public override int Hides { get { return 12; } }
		public override HideType HideType { get { return HideType.Spined; } }
	
	public override void OnDeath( Container c )
{
	if ( Utility.Random( 4 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 1 ))
		{
                        default:
			case 1: item = new ThrashersTail(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
}

		public AThrasher( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 0x5A )
			{
				BaseSoundID = 660;
			}
		}
	}
}
