using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an insane dryad corpse" )]
	public class InsaneDryad : BaseCreature
	{
		[Constructable]
		public InsaneDryad() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "an insane Dryad";
			Body = 266;
			BaseSoundID = 0x467;

			SetStr( 41, 50 );
			SetDex( 401, 500 );
			SetInt( 237, 278 );

			SetHits( 13, 18 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 90 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 120.5, 150.0 );
			SetSkill( SkillName.Tactics, 10.1, 20.0 );
			SetSkill( SkillName.Wrestling, 100.1, 120.5 );
			SetSkill( SkillName.Peacemaking, 120.1, 140.5 );
			SetSkill( SkillName.Discordance, 120.1, 140.5 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 100;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Gems, 2 );
			// TODO: statue
		}

		public override HideType HideType{ get{ return HideType.Spined; } }
		public override int Hides{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public InsaneDryad( Serial serial ) : base( serial )
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