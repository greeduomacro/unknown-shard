/////////////////
///LostSinner///
///////////////
using System;
using Server;
using Server.Misc;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("an Evil corpse")]
    public class Mordrid : BaseCreature
    {

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }


        [Constructable]
        public Mordrid()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = ("Mordrid");
            Body = 184;
            Hue = 0;

            SetStr(800, 950);
            SetDex(91, 115);
            SetInt(300, 320);

            SetHits(2820, 3225);

            SetDamage(20, 22);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 1);
            SetResistance(ResistanceType.Fire, 0, 1);
            SetResistance(ResistanceType.Poison, 0, 1);
            SetResistance(ResistanceType.Energy, 0, 1);
            SetResistance(ResistanceType.Cold, 0, 1);

            SetSkill(SkillName.EvalInt, 135.0, 100.0);
            SetSkill(SkillName.Tactics, 125.0, 130.0);
            SetSkill(SkillName.MagicResist, 75.0, 97.5);
            SetSkill(SkillName.Wrestling, 120.0, 135.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Focus, 120.0);
            SetSkill(SkillName.Magery, 160.0, 180);

            Fame = 2500;
            Karma = -2500;

            VirtualArmor = 70;

            int hairHue = 0;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }

            AddItem(new Server.Items.HoodedShroudOfShadows(1109));
            AddItem(new Server.Items.Sandals(1157));
            AddItem(new Server.Items.FurCape(1109));

            GoldNecklace goldnecklace = new GoldNecklace();
            goldnecklace.Hue = 1157;
            goldnecklace.Movable = false;
            AddItem(goldnecklace);

            GoldRing goldring = new GoldRing();
            goldring.Hue = 1157;
            goldring.Movable = false;
            AddItem(goldring);

            Backpack backpack = new Backpack();
            backpack.Hue = 1109;
            backpack.Movable = false;
            AddItem(backpack);

            ME me = new ME();
            me.Hue = 1154;
            me.Movable = false;
            AddItem(me);

        }

        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override bool AlwaysMurderer { get { return true; } }

        public override void GenerateLoot()
        {
            if (1 > Utility.RandomDouble()) // 1 = 100% = chance to drop 
                switch (Utility.Random(1))
                {
                    case 0: PackItem( new MerlinsBook() ); break;
                }
            PackGold(7700);
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.MedScrolls, 2);
            AddLoot(LootPack.Gems, 5);
        }

        public Mordrid(Serial serial)
            : base(serial)
        {
        }

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
        public override void OnDeath(Container c)
        {
            Mobile m = this.FindMostRecentDamager(false);

            if (m is PlayerMobile)
            {
                PlayerMobile pm = m as PlayerMobile;

                pm.SendGump(new MerlinsQuestGump2(pm));

            }
            else if (m is BaseCreature)
            {
                BaseCreature bc = m as BaseCreature;

                if (bc.Controlled == true)
                {
                    bc.ControlMaster.SendGump(new MerlinsQuestGump2(bc.ControlMaster));


                }
            }
            base.OnDeath(c);
        }
    }
}