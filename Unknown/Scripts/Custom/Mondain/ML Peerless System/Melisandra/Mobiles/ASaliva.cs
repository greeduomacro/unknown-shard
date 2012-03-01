/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 5/29/2006
 * Time: 6:14 PM
 * 
 * Saliva - Blighted Grove
 */
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a saliva corpse" )]
	public class ASaliva : BaseCreature
	{
		[Constructable]
		public ASaliva() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Saliva";
			Body = 30;
			Hue = 387;
			BaseSoundID = 402;

			SetStr( 141, 151 );
			SetDex( 144, 154 );
			SetInt( 84, 94 );

			SetHits( 467, 487 );

			SetDamage( 15, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 48 );
			SetResistance( ResistanceType.Fire, 30, 36 );
			SetResistance( ResistanceType.Cold, 30, 36 );
			SetResistance( ResistanceType.Poison, 35, 40 );
			SetResistance( ResistanceType.Energy, 25, 30 );

			SetSkill( SkillName.MagicResist, 91.1, 96.0 );
			SetSkill( SkillName.Tactics, 137.1, 143.0 );
			SetSkill( SkillName.Wrestling, 118.1, 122.0 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 32;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 6 );
			
		}
public override void OnDeath( Container c )
{
	if ( Utility.Random( 4 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 1 ))
		{
                        default:
			case 1: item = new SalivasFeather(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
}
		public override int GetAttackSound()
		{
			return 916;
		}

		public override int GetAngerSound()
		{
			return 916;
		}

		public override int GetDeathSound()
		{
			return 917;
		}

		public override int GetHurtSound()
		{
			return 919;
		}

		public override int GetIdleSound()
		{
			return 918;
		}

		public override bool CanRummageCorpses { get { return true; } }
		public override int Meat { get { return 4; } }
		public override MeatType MeatType { get { return MeatType.Bird; } }
		public override int Feathers { get { return 50; } }

		public ASaliva( Serial serial ) : base( serial )
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
