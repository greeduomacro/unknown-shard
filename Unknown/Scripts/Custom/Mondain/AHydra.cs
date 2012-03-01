//Has a fire attack on an area of players(?), lessens in intensity as he is damaged
//Dragon Slayer Group to kill
using System;
using Server;
using Server.Items;
using System.Collections;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a hydra's corpse" )]
	public class AHydra : BaseCreature
	{
		public static int AbilityRange { get { return 10; } }

		private static int m_MinTime = 10;
		private static int m_MaxTime = 30;

		private DateTime m_NextAbilityTime;
		
		[Constructable]
		public AHydra() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Hydra";
			Body = 265;
			BaseSoundID = 362;//dragon is 362, checking for new sound

			SetStr( 803, 813 );//used stratics posted stats as the high end on all listed below
			SetDex( 98, 108 );
			SetInt( 104, 114 );

			SetHits( 1472, 1492 );

			SetDamage( 16, 22 );// dragon damage
			
			SetDamageType( ResistanceType.Cold, 60 );
			SetDamageType( ResistanceType.Fire, 10 );
			SetDamageType( ResistanceType.Cold, 10 );
			SetDamageType( ResistanceType.Poison, 10 );
			SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, 68, 73 );
			SetResistance( ResistanceType.Fire, 73, 78 );
			SetResistance( ResistanceType.Cold, 23, 28 );
			SetResistance( ResistanceType.Poison, 38, 43 );
			SetResistance( ResistanceType.Energy, 33, 38 );

			SetSkill( SkillName.Anatomy, 71.7, 76.0 );
			SetSkill( SkillName.MagicResist, 84.7, 89.0 );
			SetSkill( SkillName.Tactics, 104.1, 109.0 );
			SetSkill( SkillName.Wrestling, 105.1, 110.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 62;//dragon has 60 armor
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		//public override bool HasBreath { get { return true; } } // fire breath enabled
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 4; } }

		public AHydra( Serial serial ) : base( serial )
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
