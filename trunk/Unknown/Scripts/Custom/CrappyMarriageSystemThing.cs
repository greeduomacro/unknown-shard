/*
 *  Kevin's Wedding System
 *  Version 2 x 10 ^ -5
 *  This script sucks lol.
 *  Made by Kevin Evans
 *  With help from Rockstar
 *  Thanks Rock! <3 Lubb you!
 *  I also lubb Snobo <3
 *  Lots and lots of lubb.
 *  Hehehehe.
 *  Oh, thanks to FingersMcSteal for helping me understand TextEntries ;D
 *  
 *  >                         <
 *  >> Combiboland.Sytes.Net <<
 *  >                         <
 *  
 *  PS: TY DFI :P I got the idea from you guys lawl lawls.
 */
using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Gumps;
using System.Collections;
using Server.Items;
using Server.Prompts;
using System.Text;

namespace Server.Items
{
    public class MarriageDeed : Item
    {

        [Constructable]
        public MarriageDeed()
            : base(8792)
        {
            Name = "a marriage deed";
            Hue = 0;
            Weight = 0.0;
            LootType = LootType.Blessed;
        }


        public MarriageDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 0)
            {
                Weight = 0.0;
                LootType = LootType.Blessed;
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                Item deed = (Item)this; // not needed
                from.SendGump(new MarriageGump(deed));

            }
            else
            {
                from.SendMessage("That item must be in your backpack to use.");
                return;
            }
        }
    }
}

namespace Server.Items
{
    public class WeddingRing : Item
    {
        [Constructable]
        public WeddingRing()
            : this("unknown", "unknown")
        {
        }

        [Constructable]
        public WeddingRing(string from, string to)
            : base(4234)
        {
            Stackable = false;
            Weight = 1.0;
            Layer = Layer.Ring;
            Hue = 1153;
            LootType = LootType.Blessed;


            Name = "" + from + " & " + to + ".";

        }

        public WeddingRing(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 0)
            {
                Weight = 0.0;
                LootType = LootType.Blessed;
            }
        }
    }
}


namespace Server.Gumps
{

    public class MarriageGump : Gump
    {
        public Item deed;
        public string AcceptanceMessage;
        public MarriageGump(Item item)
            : base(0, 0)
        {
            (Item)deed = item;
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(213, 89, 352, 198, 9250);
            this.AddBackground(238, 137, 308, 84, 9350);
            this.AddTextEntry(243, 143, 296, 72, 0, (int)Buttons.MSG, @"Will you marry me? ");
            this.AddLabel(241, 108, 0, @"Your message to your love:");
            this.AddImage(246, 214, 105);
            this.AddButton(399, 234, 247, 248, (int)Buttons.Ok, GumpButtonType.Reply, 0);
            this.AddButton(470, 234, 241, 242, (int)Buttons.Cancel, GumpButtonType.Reply, 0);

        }

        public enum Buttons
        {

            MSG,
            Ok,
            Cancel,
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case (int)Buttons.Ok:
                    {                  
                        Mobile m = sender.Mobile;
                        AcceptanceMessage = GetString(info, 0);
                        m.SendMessage("Who do you wish to marry?");
                        m.BeginTarget(4, false, TargetFlags.None, new TargetCallback(OnTarget));
                        break;

                    }
                default:
                case (int)Buttons.Cancel:
                    {
                        Mobile m = sender.Mobile;
                        m.SendMessage("You decide not to marry today.");
                        break;
                    }

            }
        }
        private string GetString(RelayInfo info, int id)
        {
            TextRelay t = info.GetTextEntry(id);
            return (t == null ? null : t.Text.Trim());
        }
        protected void OnTarget(Mobile from, object targeted)
        {
            PlayerMobile m = targeted as PlayerMobile;

            if (targeted is PlayerMobile)
            {
                if (targeted != from)
                {
                    from.SendMessage("You have sent the request!");
                    m.SendGump(new AcceptMarriageGump((Mobile)from, (string)AcceptanceMessage, (Item)deed));
                }
                else
                {
                    m.SendMessage("You cannot marry yourself!");
                }
            }
            else
            {
                from.SendMessage("You cannot marry that!");
                return;
            }
        }
    }
}


namespace Server.Gumps
{

    public class AcceptMarriageGump : Gump
    {
        public Mobile from;
        public Item This;
        public AcceptMarriageGump(Mobile m, string message, Item item)
            : base(0, 0)
        {
            (Mobile)from = m;
            (Item)This = item;
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(178, 63, 317, 223, 9250);
            this.AddButton(396, 224, 1209, 1210, (int)Buttons.Yes, GumpButtonType.Reply, 0);
            this.AddLabel(418, 220, 0, @"Accept");
            this.AddHtml(205, 105, 267, 102, message, (bool)true, (bool)true);
            this.AddImage(199, 210, 105);
            this.AddButton(396, 246, 1209, 1210, (int)Buttons.No, GumpButtonType.Reply, 0);
            this.AddLabel(418, 243, 0, @"Decline");
            this.AddLabel(226, 79, 0, @"" + from.Name + " wishes to marry you!");

        }

        public enum Buttons
        {
            No,
            Yes,
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case (int)Buttons.Yes:
                    {
                        if (!This.Deleted)
                        {
                            Mobile m = sender.Mobile;
                            m.AddToBackpack(new WeddingRing(from.Name, m.Name));
                            from.AddToBackpack(new WeddingRing(from.Name, m.Name));
                            m.SendMessage("Congratulations! You are now married to " + from.Name + "!");
                            m.SendMessage("A wedding ring has been placed in your backpack.");

                            from.SendMessage("Congratulations! You are now married to " + m.Name + "!");
                            from.SendMessage("A wedding ring has been placed in your backpack.");
                            World.Broadcast(0x35, true, "Congratulations! " + m.Name + " & " + from.Name + " have been married!");
                            This.Delete(); // Deletes the deed after used
                            break;
                        }

                        break;

                    }

                case (int)Buttons.No:
                    {
                        Mobile m = sender.Mobile;
                        m.SendMessage("You decide not to marry today.");
                        from.SendMessage("They have declined marriage.");
                        break;
                    }

            }
        }

    }
}
// Yay. Its finnally finnished. Ima eat some bbq now. 