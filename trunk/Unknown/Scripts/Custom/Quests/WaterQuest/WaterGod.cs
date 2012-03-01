using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "The Corpse of Water God" )]
    public class WaterGod : BaseCreature
    {
        [Constructable]
        public WaterGod() : base( AIType.AI_Melee, FightMode.Aggressor, 3, 1, 0.2, 0.4 )
        {
            this.Name = "God Of Water";
            this.Hue = 2999;
            this.Body = 400;
            this.BaseSoundID = 4453;

            SetStr(60, 120);
            SetDex(60, 120);
            SetInt(50, 100);

            SetHits(7500, 15000);

            SetDamage(60, 100);
            this.SetDamageType( ResistanceType.Physical, 100 );
            this.SetResistance( ResistanceType.Physical, 40 );
            this.SetResistance( ResistanceType.Cold, 20 );
            this.SetResistance( ResistanceType.Fire, 20 );
            this.SetResistance( ResistanceType.Energy, 20 );
            this.SetResistance( ResistanceType.Poison, 20 );
            this.VirtualArmor = 25;
	    Fame = 250;
	    Karma = -2500;

            SetSkill(SkillName.EvalInt, 85.0, 100.0);
            SetSkill(SkillName.Tactics, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 75.0, 97.5);
            SetSkill(SkillName.Wrestling, 100.2, 105.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Focus, 120.0);
            SetSkill(SkillName.Swords, 110.0, 120.0);


            WaterChest Chest = new WaterChest();
            Chest.Movable = false;
            AddItem(Chest);

            WaterArms Arms = new WaterArms();
            Arms.Movable = false;
            AddItem(Arms);

            WaterLegs Legs = new WaterLegs();
            Legs.Movable = false;
            AddItem(Legs);

            WaterGloves Gloves = new WaterGloves();
            Gloves.Movable = false;
            AddItem(Gloves);

            WaterHelm Helm = new WaterHelm();
            Helm.Movable = false;
            AddItem(Helm);

            WaterShield Shield = new WaterShield();
            Shield.Movable = false;
            AddItem(Shield);

            WaterBlade Weapon = new WaterBlade();
            Weapon.Movable = false;
            AddItem(Weapon);

            new WaterFair().Rider = this;
        }

        public override void GenerateLoot()
        {

            switch (Utility.Random(50))
            {
                case 0: PackItem(new WaterShard(6)); break;
                case 1: PackItem(new WaterShard(8)); break;
		case 2: PackItem(new Gold(1500)); break;
		case 3: PackItem(new WaterVial(6)); break;
		case 4: PackItem(new WaterVial(8)); break;
		case 5: PackItem(new Gold(2000)); break;
		case 6: PackItem(new Gold(5000)); break;
		case 7: PackItem(new WaterBlade()); break;
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

        public WaterGod( Serial serial ) : base( serial )
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