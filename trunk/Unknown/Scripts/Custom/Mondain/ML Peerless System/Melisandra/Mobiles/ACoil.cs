/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 5/29/2006
 * Time: 10:48 AM
 * 
 * Coil - Blighted Grove
 */
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a serpent corpse" )]
	public class ACoil : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.MortalStrike;
		}
	
		[Constructable]
		public ACoil() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 92;
			Hue = 1271;
			Name = "Coil";
			BaseSoundID = 219;

			SetStr( 317, 337 );
			SetDex( 344, 364 );
			SetInt( 106, 126 );

			SetHits( 1160, 1166 );

			SetDamage( 8, 21 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 52, 59 );
			SetResistance( ResistanceType.Fire, 22, 29 );
			SetResistance( ResistanceType.Cold, 19, 26 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 21, 28 );

			SetSkill( SkillName.Poisoning, 107.8, 117.8 );
			SetSkill( SkillName.Anatomy, 121.2,  131.2 );
			SetSkill( SkillName.MagicResist, 103.7, 113.7 );
			SetSkill( SkillName.Tactics, 127.6, 137.6 );
			SetSkill( SkillName.Wrestling, 121.8, 131.8 );

			Fame = 12000;
			Karma = -12000;

			VirtualArmor = 40;
		}

		public override void GenerateLoot()
		{
		    AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 6 );
		}

		public override int Meat { get { return 1; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override Poison HitPoison { get { return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }
		
public override void OnDeath( Container c )
{
	if ( Utility.Random( 4 ) == 0 )
	{
		Item item;

		switch ( Utility.Random( 1 ))
		{
                        default:
			case 1: item = new CoilsFang(); break;
					}

		c.DropItem( item );
	}

	base.OnDeath( c );
}
			public ACoil( Serial serial ) : base( serial )
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

			if ( BaseSoundID == -1 )
			{
				BaseSoundID = 219;
			}
		}
	}
}
