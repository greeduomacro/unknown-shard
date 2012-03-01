
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
    public class MerlinsQuestGump6 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("MerlinsQuestGump6", AccessLevel.GameMaster, new CommandEventHandler(MerlinsQuestGump6_OnCommand));
        }

        private static void MerlinsQuestGump6_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new MerlinsQuestGump6(e.Mobile));
        }

        public MerlinsQuestGump6(Mobile owner)
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
"<BASEFONT COLOR=YELLOW><I>You fall to the ground as you feel all your essence being pulled from you.</I><BR><BR>"+
"<BASEFONT COLOR=RED><I>Talon speaks</I><BR><BR>You fool, did you think you honestly had bested me!  That defeat was merely staged."+
"<BASEFONT COLOR=RED> I needed you to recover the staff because one must be pure of heart to remove the staff.  I myself couldn't retrieve it alone."+
"<BASEFONT COLOR=RED> And without the spellbook the staff is useless!! Muahahahaha... I took it from you as I gave you the bracelet..<BR><BR>"+
"<BASEFONT COLOR=RED> Hence you my precious pawn are doing all my dirty work! Muahahaha<BR><BR>"+
"<BASEFONT COLOR=YELLOW>Lacking the ability to do anything you try to make out this evil wizards incantation hoping for a clue as to where he intends to go. <BR><BR>"+
"<BASEFONT COLOR=RED>Matra Onus Seirta~!<BR><BR>"+
"<BASEFONT COLOR=YELLOW>You realize that you must write these words down and find someone to translate them.<BR><BR>"+
"<BASEFONT COLOR=YELLOW><I>You remember a Scholar named Peraniese somewhere in Trinsic and wonder if he could aid you.<BR><BR>"+


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

