
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
    public class MerlinsQuestGump3 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("MerlinsQuestGump3", AccessLevel.GameMaster, new CommandEventHandler(MerlinsQuestGump3_OnCommand));
        }

        private static void MerlinsQuestGump3_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new MerlinsQuestGump3(e.Mobile));
        }

        public MerlinsQuestGump3(Mobile owner)
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
"<BASEFONT COLOR=YELLOW><I>Talon looks up at you as you approach.</I><BR><BR>" +
"<BASEFONT COLOR=RED>Well what news do you have?<BR><BR>"+
"<BASEFONT COLOR=YELLOW><I>You tell Talon of your battle with Mordrid and how you are in search of Merlin.</I><BR><BR>"+
"<BASEFONT COLOR=RED>You have Merlins SpellBook!<BR><BR>"+
"<BASEFONT COLOR=YELLOW><I>Suddenly Talon begins to smile oddly...</I><BR><BR>"+
"<BASEFONT COLOR=RED>Well now seems my plan is working just as I wanted! Now I shall kill you and have the book for myself"+
"<BASEFONT COLOR=RED> Prepare to die!!!!<BR><BR>"+


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

            AddButton(225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0);

            //--------------------------------------------------------------------------------------------------------------
        }

        public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
                    {
                        from.SendMessage("Muahahaha");
                        break;
                    }
            }
        }
    }
}

