
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
    public class MerlinsQuestGump8 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("MerlinsQuestGump8", AccessLevel.GameMaster, new CommandEventHandler(MerlinsQuestGump8_OnCommand));
        }

        private static void MerlinsQuestGump8_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new MerlinsQuestGump8(e.Mobile));
        }

        public MerlinsQuestGump8(Mobile owner)
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
"<BASEFONT COLOR=ORANGE><I>Peraniese smiles as you approach</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE>You have done well. <I>Peraniese shoves his collection of works off the table and begins reading over the text</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE>Ahhh ha very well done indeed! His location is deep within Ankh Dungeon!" +
"<BASEFONT COLOR=ORANGE> But be warned his magic is of the utmost strength and it will take all you have to defeat him.<BR><BR>" +
"<BASEFONT COLOR=ORANGE>GoodLuck<BR><BR>" +


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
                        break;
                    }
            }
        }
    }
}

