using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Corpse of Pythie")]
    public class Pythie : BaseCreature
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Pythie()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Pythie";
            Title = "Handmaid of the Gods";
            Body = 401;
            CantWalk = true;
            Hue = 33770;
            CantWalk = true;

            int hairHue = 0;
            Blessed = true;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }
            

            AddItem(new Server.Items.Cloak(1153));
            AddItem(new Server.Items.Sandals(1153));
            AddItem(new Server.Items.Robe(1153));
            AddItem(new Server.Items.Bandana(1153));

            GoldNecklace goldnecklace = new GoldNecklace();
            goldnecklace.Hue = 0;
            goldnecklace.Movable = false;
            AddItem(goldnecklace);

            GoldRing goldring = new GoldRing();
            goldring.Hue = 0;
            goldring.Movable = false;
            AddItem(goldring);

            Backpack backpack = new Backpack();
            backpack.Hue = 1530;
            backpack.Movable = false;
            AddItem(backpack);

        }

        public Pythie(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry>list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new PythieEntry(from, this));
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

        public class PythieEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public PythieEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }
        }

        public override bool HandlesOnSpeech(Mobile from)
        {
            base.HandlesOnSpeech(from);
            return true;
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        { 
                   Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

            if (mobile != null)
            {
                
                 
                  if (dropped is eParchment3)

                {
                        dropped.Delete();
                        mobile.SendGump(new ElementQuestGump10(from));
                        mobile.AddToBackpack(new BraceletElements());
                        return true;
                    }
                    else
                    {
                        from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Have we met before ?", from.NetState);
                        return false;
                    }
                }
                else
                {
                    from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "What am I to do with this ?", from.NetState);
                    return false;
                }

            }

        }
    }

                    
                   
