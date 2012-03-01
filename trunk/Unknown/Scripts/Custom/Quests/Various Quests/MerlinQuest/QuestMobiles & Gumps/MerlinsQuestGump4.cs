
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
    public class MerlinsQuestGump4 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("MerlinsQuestGump4", AccessLevel.GameMaster, new CommandEventHandler(MerlinsQuestGump4_OnCommand));
        }

        private static void MerlinsQuestGump4_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new MerlinsQuestGump4(e.Mobile));
        }

        public MerlinsQuestGump4(Mobile owner)
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
"<BASEFONT COLOR=YELLOW><I>You see Merlin huddled in the center of the magical cage. You have to wonder why he seems so terrified to move.</I><BR><BR>" +
"<BASEFONT COLOR=YELLOW><I>Merlins yells for you to stay at a distance as you come towards him,  stopping you short from what you'll learn would have been your last step</I><BR><BR>"+
"<BASEFONT COLOR=YELLOW>You must defeat the Key Holder, he posseses an item that will allow you to pass through this wretched field.<BR><BR>"+
"<BASEFONT COLOR=YELLOW><I>Merlin points towards the east as if motioning where death waits for all..</I><BR><BR>"+
"<BASEFONT COLOR=YELLOW>Be careful if you wish to slay that horrible beast, he is powerful even for me<BR><BR>"+



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
                case 0: //Case uses the ActionIDs defined above. Case 0 defines the actions for the button with the action id 0 
                    {
                        from.SendMessage("Be Careful");
                        break;
                    }
            }
        }
    }
}

