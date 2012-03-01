using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{
    public class ElementQuestGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("ElementQuestGump", AccessLevel.GameMaster, new CommandEventHandler(ElementQuestGump_OnCommand));
        }

        private static void ElementQuestGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new ElementQuestGump(e.Mobile));
        }

        public ElementQuestGump(Mobile owner)
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
            AddLabel(140, 60, 0x34, "Four Elements's Quest");


          
            AddHtml(107, 140, 300, 230, "<BODY>" +
                //----------------------/----------------------------------------------/
"<BASEFONT COLOR=ORANGE><I>Oracle looks at you fixedly while you approach.</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE>Hello young adventurer!I need help! *looks pensive*<BR><BR>" +
"<BASEFONT COLOR=ORANGE>I made a stupid bet! The Gods challenge me to find an adventurer capable of finding the Four Elements that I need.<BR><BR>" +
"<BASEFONT COLOR=ORANGE>Are you the one who will seek out such a task? I will give you a riddle to solve.<BR><BR>" +
"<BASEFONT COLOR=ORANGE>Find the answer to each of these riddles. Seek out each God, say his name followed by the answer to each riddle.<BR><BR>" +
"<BASEFONT COLOR=ORANGE>He will give you one of the Elements that you should bring back to me.<BR><BR>" +
"<BASEFONT COLOR=ORANGE>If you manage to bring me Four Elements I shall surely reward you well!<BR><BR>" +
"<BASEFONT COLOR=ORANGE>Here is the first riddle.<BR><BR>" +
"<BASEFONT COLOR=ORANGE><I>Without wing I fly.</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE><I>Without voice I scream.</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE><I>Without eyes I see.</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE><I>Who am I ?</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE>Visit Hephaistos the God of the Fire, he is somewhere on the Isle of Fire.<BR><BR>" +
"<BASEFONT COLOR=ORANGE>Go my friend, speak his name, then the answer to the riddle and return with the Element of the Fire !<BR><BR>" +




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
                        break;
                    }
            }
        }
    }
}

