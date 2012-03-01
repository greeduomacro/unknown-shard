// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an Boogie Woogie Wu corpse")]
    public class BoogieWoogieWu : BaseCreature
    {
        [Constructable]
        public BoogieWoogieWu()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {

            Name = "Boogie Woogie Wu";
            Body = 400;
            Hue = 0;

            SetStr(600, 650);
            SetDex(150, 200);
            SetInt(350, 400);

            SetHits(20000, 25000);

            SetDamage(10, 15);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 1);
            SetResistance(ResistanceType.Fire, 0, 1);
            SetResistance(ResistanceType.Poison, 0, 1);
            SetResistance(ResistanceType.Energy, 0, 1);

            SetSkill(SkillName.EvalInt, 85.0, 100.0);
            SetSkill(SkillName.Tactics, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 75.0, 97.5);
            SetSkill(SkillName.Wrestling, 100.2, 105.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Focus, 120.0);
            SetSkill(SkillName.Swords, 110.0, 120.0);

            Fame = 250;
            Karma = -25000;

            VirtualArmor = 50;


            Item hair = new Item(Utility.RandomList(0x203B, 0x2049, 0x2048, 0x204A));

            hair.Hue = 1150;
            hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem(hair);

            BoogieWoogieWuChest Chest = new BoogieWoogieWuChest();
            Chest.Movable = false;
            AddItem(Chest);

            BoogieWoogieWuArms Arms = new BoogieWoogieWuArms();
            Arms.Movable = false;
            AddItem(Arms);

            BoogieWoogieWuLegs Legs = new BoogieWoogieWuLegs();
            Legs.Movable = false;
            AddItem(Legs);

            BoogieWoogieWuGloves Gloves = new BoogieWoogieWuGloves();
            Gloves.Movable = false;
            AddItem(Gloves);

            BoogieWoogieWuGorget Gorget = new BoogieWoogieWuGorget();
            Gorget.Movable = false;
            AddItem(Gorget);

            BoogieWoogieWuSkull Helm = new BoogieWoogieWuSkull();
            Helm.Movable = false;
            AddItem(Helm);


            BoogieWoogieWuShield Shield = new BoogieWoogieWuShield();
            Shield.Movable = false;
            AddItem(Shield);

            BoogieWoogieWuSword Weapon = new BoogieWoogieWuSword();
            Weapon.Movable = false;
            AddItem(Weapon);

            BoogieWoogieWusRobe Robe = new BoogieWoogieWusRobe();
            Robe.Movable = false;
            AddItem(Robe);

            //Horse BoogieWoogieWusWarHorse = new BoogieWoogieWusWarHorse();
            //horse.Hue = 1;
            //horse.Hits = 200;
            //horse.Karma = 500;
            //BoogieWoogieWusWarHorse.Rider = this;
            new BoogieWoogieWusWarHorse().Rider = this;

        }

        public override void GenerateLoot()
        {

            switch (Utility.Random(48))
            {
                case 0: PackItem(new BoogieWoogieWusRobe()); break;
                case 1: PackItem(new BoogieWoogieWuSword()); break;
                case 2: PackItem(new BoogieWoogieWuShield()); break;
                case 3: PackItem(new BoogieWoogieWuSash()); break;
                case 4: PackItem(new BoogieWoogieWuApron()); break;
                case 5: PackItem(new BoogieWoogieWuSkull()); break;
                case 6: PackItem(new BoogieWoogieWuGorget()); break;
                case 7: PackItem(new BoogieWoogieWuLegs()); break;
                case 8: PackItem(new BoogieWoogieWuGloves()); break;
                case 9: PackItem(new BoogieWoogieWuArms()); break;
                case 10: PackItem(new BoogieWoogieWuChest()); break;
                case 11: PackItem(new EarringsOfBoogieWoogieWu()); break;
                case 12: PackItem(new BoogieWoogieWuCloak()); break;
                case 13: PackItem(new RingOfBoogieWoogieWu()); break;
                case 14: PackItem(new BraceletOfBoogieWoogieWu()); break;
                case 15: PackItem(new BoogieWoogieWuSandals()); break;
                    {

                    }
            }
        }

        public BoogieWoogieWu(Serial serial)
            : base(serial)
        {
        }
        public override bool AlwaysMurderer { get { return true; } }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
