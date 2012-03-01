
//////////////////////////
//Created by LostSinner//
////////////////////////
using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{
    public class MerlinsQuestGump1 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("MerlinsQuestGump1", AccessLevel.GameMaster, new CommandEventHandler(MerlinsQuestGump1_OnCommand));
        }

        private static void MerlinsQuestGump1_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new MerlinsQuestGump1(e.Mobile));
        }

        public MerlinsQuestGump1(Mobile owner)
            : base(50, 50)
        {
            //----------------------------------------------------------------------------------------------------

            AddPage(0);
            AddImageTiled(54, 33, 369, 400, 2624);
            AddAlphaRegion(54, 33, 369, 400);

            AddImageTiled(416, 39, 44, 389, 203);
            //--------------------------------------Window size bar--------------------------------------------

            AddImage(97, 49, 9005);
            AddImageTiled(58, 39, 29, 390, 10460);
            AddImageTiled(412, 37, 31, 389, 10460);
            AddLabel(140, 60, 0x34, "Merlins Quest by LostSinner");


            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW><I>Merlin eyes you up as you walk through the magic field</I><BR><BR>" +
"<BASEFONT COLOR=YELLOW>Seems you've managed to defeat the Key Holder.  Quite impressive! Perhaps you might aid me in retrieving my SpellBook, without it I am nothing. " +
"<BASEFONT COLOR=YELLOW> Mordrid took it from me when she imprisioned me here. I haven't the strength to defeat her myself in my current condition."+
"<BASEFONT COLOR=YELLOW> Give me the Sphere of Protection and I will use the power within it to open a gate to Mordrids and return then to my student to wait for you.<BR><BR>" +
"<BASEFONT COLOR=YELLOW> As you begin to go through the gate Merlin stops you and hands you a set of earrings. Take these to aid you in your fight.<BR><BR>"+

            "</BODY>", false, true);


            AddImage(430, 9, 10441);
            AddImageTiled(40, 38, 17, 391, 9263);
            AddImage(6, 25, 10421);
            AddImage(34, 12, 10420);
            AddImageTiled(94, 25, 342, 15, 10304);
            AddImageTiled(40, 427, 415, 16, 10304);
            AddImage(-10, 314, 10402);
            AddImage(56, 150, 10411);
            AddImage(155, 120, 2103);
            AddImage(136, 84, 96);

            AddButton(250, 375, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(280, 375, 1152, "Give him the Sphere");
            AddButton(110, 375, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(140, 375, 1152, "Not right now");

            //--------------------------------------------------------------------------------------------------------------
        }

        public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
        {
            Mobile from = state.Mobile;

            if (info.ButtonID == 1)
            {
                if (from.Backpack.ConsumeTotal(typeof(SphereOfProtection), 1))
                {
                    Item item = new MordridTeleporter();
                    item.Location = from.Location;
                    item.Map = from.Map;
                    from.SendMessage("Goodluck");
                    from.AddToBackpack(new MerlinsEarrings());
                }
            }
            if (info.ButtonID == 2)
            {
                from.SendMessage("You decide to not aid Merlin");
            }
        }
    }
}

