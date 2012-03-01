
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
    [CorpseName("Corpse Of Merlin")]
    public class Merlin2 : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Merlin2()
        {
            Name = "Merlin";
            Title = "Master Magician and Philosopher";
            Body = 400;
            CantWalk = false;
            Hue = 33770;

            int hairHue = 0;
            Blessed = true;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }
            switch (Utility.Random(1))
            {
                case 0: AddItem(new MediumLongBeard(hairHue)); break;
            }

            AddItem(new Server.Items.HoodedShroudOfShadows(1150));
            AddItem(new Server.Items.Sandals(0));
            AddItem(new Server.Items.FurCape(0));

            GoldNecklace goldnecklace = new GoldNecklace();
            goldnecklace.Hue = 1154;
            goldnecklace.Movable = false;
            AddItem(goldnecklace);

            GoldRing goldring = new GoldRing();
            goldring.Hue = 1154;
            goldring.Movable = false;
            AddItem(goldring);

            Backpack backpack = new Backpack();
            backpack.Hue = 1154;
            backpack.Movable = false;
            AddItem(backpack);
        }

        public Merlin2(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new MerlinEntry(from, this));
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

        public class MerlinEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public MerlinEntry(Mobile from, Mobile giver)
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
                    Item x = mobile.Backpack.FindItemByType(typeof(MerlinsBook2));
                    if (x != null)
                    {
                        Item b = mobile.Backpack.FindItemByType(typeof(MerlinsStaff2));
                        if (b != null)
                        {
                            mobile.AddToBackpack(new BladeofTorment());
                            mobile.SendGump(new MerlinsQuestGump9(mobile));
                            b.Delete();
                            x.Delete();
                        }
                        else
                        {
                            mobile.PrivateOverheadMessage(MessageType.Regular, 1153, false, "You put the Staff in your pack", mobile.NetState);
                        }
                    }
                    else
                    {
                        mobile.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Do I know you?", mobile.NetState);
                    }
                }
            }
        }
    }
}
                    
                   
