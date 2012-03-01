
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Engines.Quests;

namespace Server.Mobiles
{
    [CorpseName("Corpse Of Talon")]
    public class Talon : BaseCreature
    {

        public virtual bool IsInvulnerable { get { return true; } }
        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

        [Constructable]
        public Talon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Title = "Student of the arts";
            Name = "Talon";
            Body = 400;
            Hue = 33770;

            Blessed = true;

            SetStr(900, 1100);
            SetDex(291, 315);
            SetInt(600, 720);

            SetHits(1520, 1725);

            SetDamage(10, 15);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 1);
            SetResistance(ResistanceType.Fire, 0, 1);
            SetResistance(ResistanceType.Poison, 0, 1);
            SetResistance(ResistanceType.Energy, 0, 1);

            SetSkill(SkillName.EvalInt, 85.0, 100.0);
            SetSkill(SkillName.Tactics, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 75.0, 97.5);
            SetSkill(SkillName.Wrestling, 20.2, 60.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Focus, 120.0);
            SetSkill(SkillName.Magery, 140.0, 150.0);

            Fame = 2500;
            Karma = -2500;

            VirtualArmor = 50;

            int hairHue = 0;
            Blessed = true;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }
            switch (Utility.Random(1))
            {
                case 0: AddItem(new ShortBeard(hairHue)); break;
            }

            AddItem(new Server.Items.HoodedShroudOfShadows(0));
            AddItem(new Server.Items.Sandals(0));

            GoldNecklace goldnecklace = new GoldNecklace();
            goldnecklace.Hue = 0;
            goldnecklace.Movable = false;
            AddItem(goldnecklace);

            GoldRing goldring = new GoldRing();
            goldring.Hue = 0;
            goldring.Movable = false;
            AddItem(goldring);

            Backpack backpack = new Backpack();
            backpack.Hue = 1150;
            backpack.Movable = false;
            AddItem(backpack);

        }

        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override bool AlwaysMurderer { get { return true; } }

        public override void GenerateLoot()
        {
            PackGold(9575);
            AddLoot(LootPack.MedScrolls, 2);
            AddLoot(LootPack.Gems, 5);
        }

        public Talon(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new TalonEntry(from, this));
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

        public class TalonEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public TalonEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                if (!(m_Mobile is PlayerMobile))
                    return;

                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    if (m_Giver is Talon)
                    {
                        Item a = mobile.Backpack.FindItemByType(typeof(Marker1));
                        if (a != null)
                        {
                            mobile.SendGump(new MerlinsQuestGump3(mobile));
                            m_Giver.Blessed = false;
                        }
                        else
                        {
                            if (!mobile.HasGump(typeof(MerlinsQuestGump)))
                            {
                                mobile.SendGump(new MerlinsQuestGump(mobile));
                            }
                        }
                    }
                }
            }
        }

        public override void OnDeath(Container c)
        {
            Mobile m = this.FindMostRecentDamager(false);

            if (m is PlayerMobile)
            {
                PlayerMobile pm = m as PlayerMobile;


                Item a = pm.Backpack.FindItemByType(typeof(MerlinsBook));
                if (a != null)
                {

                    Item item = new MerlinsGate();
                    item.Location = m.Location;
                    item.Map = m.Map;
                    pm.SendGump(new MerlinsQuestGump5(m));
                    pm.AddToBackpack(new BraceletOfTalon());
                    a.Delete();
                }
                else
                {
                    pm.SendMessage("Where is the book?!?!?!");
                }
            }
            else if (m is BaseCreature)
            {
                BaseCreature bc = m as BaseCreature;

                if (bc.Controlled == true)
                {
                    Item a = bc.ControlMaster.Backpack.FindItemByType(typeof(MerlinsBook));
                    if (a != null)
                    {
                        Item item = new MerlinsGate();
                        item.Location = this.Location;
                        item.Map = this.Map;
                        bc.ControlMaster.SendGump(new MerlinsQuestGump5(m));
                        bc.ControlMaster.AddToBackpack(new BraceletOfTalon());
                        a.Delete();

                    }
                    else
                    {
                        bc.ControlMaster.SendMessage("You are to late in retrieving the items");
                    }
                }

            }
            base.OnDeath(c);
        }
    }
}
