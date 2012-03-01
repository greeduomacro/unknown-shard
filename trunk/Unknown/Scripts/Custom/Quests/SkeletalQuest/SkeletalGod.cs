using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "SkeletalGod" )]
    public class SkeletalGod : BaseCreature
    {
        [Constructable]
        public SkeletalGod() : base( AIType.AI_Mage, FightMode.Closest, 3, 1, 0.2, 0.4 )
        {
            this.Name = "God of the Skeletals";
            this.Hue = 1950;
            this.Body = 400;
            this.BaseSoundID = 4453;

            SetStr(120, 240);
            SetDex(120, 240);
            SetInt(100, 200);

            SetHits(8000, 10000);

            SetDamage(40, 80);
            this.SetDamageType( ResistanceType.Physical, 100 );
            this.SetResistance( ResistanceType.Physical, 30 );
            this.SetResistance( ResistanceType.Cold, 30 );
            this.SetResistance( ResistanceType.Fire, 30 );
            this.SetResistance( ResistanceType.Energy, 30 );
            this.SetResistance( ResistanceType.Poison, 30 );
            this.VirtualArmor = 25;
	    Fame = 500;
	    Karma = -3500;

            SetSkill(SkillName.EvalInt, 85.0, 100.0);
            SetSkill(SkillName.Tactics, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 75.0, 97.5);
            SetSkill(SkillName.Wrestling, 100.2, 105.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Focus, 120.0);
            SetSkill(SkillName.Swords, 110.0, 120.0);


            SkeletalChest Chest = new SkeletalChest();
            Chest.Movable = false;
            AddItem(Chest);

            SkeletalArms Arms = new SkeletalArms();
            Arms.Movable = false;
            AddItem(Arms);

            SkeletalLegs Legs = new SkeletalLegs();
            Legs.Movable = false;
            AddItem(Legs);

            SkeletalGloves Gloves = new SkeletalGloves();
            Gloves.Movable = false;
            AddItem(Gloves);

            SkeletalSkull Helm = new SkeletalSkull();
            Helm.Movable = false;
            AddItem(Helm);

            SkeletalShield Shield = new SkeletalShield();
            Shield.Movable = false;
            AddItem(Shield);

            SkeletalBlade Weapon = new SkeletalBlade();
            Weapon.Movable = false;
            AddItem(Weapon);

	    //Horse SkeletalHorse = new SkeletalHorse();
            //horse.Hue = 1950;
	    //horse.Body = 0x319
            //horse.Hits = 200;
            //horse.Karma = 500;
            //SkeletalHorse.Rider = this;
            new SkeletalHorse().Rider = this;
        }

        public override void GenerateLoot()
        {

            switch (Utility.Random(48))
            {
                case 0: PackItem(new SkeletalBlade()); break;
                case 1: PackItem(new SkeletalShield()); break;
                case 2: PackItem(new SkeletalSkull()); break;
                case 3: PackItem(new SkeletalLegs()); break;
                case 4: PackItem(new SkeletalGloves()); break;
                case 5: PackItem(new SkeletalArms()); break;
                case 6: PackItem(new SkeletalChest()); break;
		case 7: PackItem(new Gold(5000)); break;
		case 8: PackItem(new Bandage(40)); break;
		case 9: PackItem(new SkeletalBone(20)); break;
		case 10: PackItem(new SkeletalBow()); break;
                    {

                    }
		}
	}

	public override bool AlwaysMurderer { get { return true; } }
        public override bool CanRummageCorpses{ get{ return true; } }
        public override Poison HitPoison{ get{ return Poison.Lethal; } }


		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random(3 ) )
			{
				default:
                case 0: return WeaponAbility.BleedAttack;
            }
        }

        public SkeletalGod( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
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