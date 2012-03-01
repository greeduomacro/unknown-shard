
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
    [CorpseName("Corpse Of Peraniese")]
    public class Peraniese : BaseCreature
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Peraniese()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Peraniese";
            Title = "a Scholar extrodinair";
            Body = 400;
            CantWalk = true;
            Hue = 33770;
            CantWalk = true;

            int hairHue = 0;
            Blessed = true;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }
            switch (Utility.Random(1))
            {
                case 0: AddItem(new Vandyke(hairHue)); break;
            }

            AddItem(new Server.Items.FurCape(1150));
            AddItem(new Server.Items.Sandals(1530));
            AddItem(new Server.Items.FurSarong(1530));

            Doublet doublet = new Doublet();
            doublet.Hue = 1530;
            doublet.Movable = false;
            AddItem(doublet);

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

        public Peraniese(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new PeranieseEntry(from, this));
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

        public class PeranieseEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public PeranieseEntry(Mobile from, Mobile giver)
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

        public override void OnSpeech(SpeechEventArgs e)
        {

            bool isMatch = false;

            Mobile from = e.Mobile;

            string keyword = this.Name + " hail";
            string keyword2 = this.Name + " translate";


            if (keyword != null && e.Speech.ToLower().IndexOf(keyword.ToLower()) >= 0)
            {
                isMatch = true;

                if (!isMatch)
                    return;

                from.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I need your help.", from.NetState );
                e.Handled = true;
            }
            if (keyword2 != null && e.Speech.ToLower().IndexOf(keyword2.ToLower()) >= 0)
            {
                isMatch = true;

                if (!isMatch)
                return;

                    from.SendGump(new MerlinsQuestGump7(from));
                e.Handled = true;
            }
            base.OnSpeech(e);
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        { 
                   Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

            if (mobile != null)
            {
                if (dropped is AncientScroll3)
                {
                    Item p = from.Backpack.FindItemByType(typeof(Marker2));
                    if (p != null)
                    {
                        dropped.Delete();
                        mobile.SendGump(new MerlinsQuestGump8(from));
                        return true;
                    }
                    else
                    {
                        from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Have we met before?", from.NetState);
                        return false;
                    }
                }
                else
                {
                    from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "What am I to do with this?", from.NetState);
                    return false;
                }
            }
            return false;
        }
    }
}

                    
                   
