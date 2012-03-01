using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a Spider corpse" )]
	public class DrowVenger : BaseCreature
	{
		[Constructable]
		public DrowVenger() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a Drow Venger";
            Body = 11;
            BaseSoundID = 1170;

			SetStr( 80, 100 );
			SetDex( 26, 45 );
			SetInt( 23, 47 );

			SetHits( 4600, 6000 );
			SetMana( 0 );

			SetDamage( 6, 12 );

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 15, 20);
            SetResistance(ResistanceType.Poison, 25, 35);

            SetSkill(SkillName.Poisoning, 60.1, 80.0);
            SetSkill(SkillName.MagicResist, 25.1, 40.0);
            SetSkill(SkillName.Tactics, 35.1, 50.0);
            SetSkill(SkillName.Wrestling, 50.1, 65.0);

			Fame = 450;
			Karma = 0;

			VirtualArmor = 24;

			Tamable = false;
			ControlSlots = 1;
			MinTameSkill = 41.1;
		}
        public void DoSpecialAbility(Mobile target)
        {
            if (1.00 >= Utility.RandomDouble()) // 100% chance to Teleport attacker to new location
                target.Location = new Point3D( 6003,175,80 );
                target.Map = Map.Trammel;
            }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            DoSpecialAbility(attacker);
        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            DoSpecialAbility(defender);
        }

        
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public DrowVenger( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}