using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a abscess's corpse" )]
	public class abscess : BaseCreature
	{
		[Constructable]
		public abscess() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an abscess";
			Body = 265;
			BaseSoundID = 0x388;

			SetStr( 437, 529 );
			SetDex( 180, 203 );
			SetInt( 123, 131 );

			SetHits( 1240, 1480 );

			SetDamage( 21, 30 );
			
			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Fire, 10 );
			SetDamageType( ResistanceType.Cold, 10 );
			SetDamageType( ResistanceType.Poison, 10 );
			SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, 69 );
			SetResistance( ResistanceType.Fire, 79 );
			SetResistance( ResistanceType.Cold, 34 );
			SetResistance( ResistanceType.Poison, 43 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.Anatomy, 91.4 );
			SetSkill( SkillName.MagicResist, 103.0 );
			SetSkill( SkillName.Tactics, 129.4 );
			SetSkill( SkillName.Wrestling, 131.4 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 70;

			PackItem( new GnarledStaff() );
			PackNecroReg( 50, 80 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 4; } }

		public abscess( Serial serial ) : base( serial )
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