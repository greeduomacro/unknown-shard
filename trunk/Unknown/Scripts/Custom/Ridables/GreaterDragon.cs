using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a greater dragon corpse" )]
	public class GreaterDragon : BaseCreature
	{
		[Constructable]
		public GreaterDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a greater dragon";
			Body = Utility.RandomList( 12, 59 );
			
            BaseSoundID = 362;
                
			SetStr( 1000, 1300 );
			SetDex( 118, 150 );
			SetInt( 588, 700 );

			SetHits( 1238, 1920 );

			SetDamage( 24, 33 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 70, 88 );
			SetResistance( ResistanceType.Fire, 70, 90 );
			SetResistance( ResistanceType.Cold, 43, 55 );
			SetResistance( ResistanceType.Poison, 55, 66 );
			SetResistance( ResistanceType.Energy, 55, 75 );

			SetSkill( SkillName.EvalInt, 48.1, 80.0 );
			SetSkill( SkillName.Magery, 120.0, 130.0 );
			SetSkill( SkillName.MagicResist, 113.2, 130.0 );
			SetSkill( SkillName.Tactics, 115.0, 130.0 );
			SetSkill( SkillName.Wrestling, 115.0, 145.0 );
            SetSkill( SkillName.Meditation, 65.8, 90.0 );
			SetSkill( SkillName.Anatomy, 25.0, 75.0 );

            Fame = 15000;
			Karma = -15000;

			VirtualArmor = 70;

			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 104.7;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.Gems, 12 );
		}
            
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 30; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 15; } }
		public override ScaleType ScaleType{ get{ return ( Body == 12 ? ScaleType.Yellow : ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }
        public override bool StatLossAfterTame{ get{ return true; } }

        public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public GreaterDragon( Serial serial ) : base( serial )
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