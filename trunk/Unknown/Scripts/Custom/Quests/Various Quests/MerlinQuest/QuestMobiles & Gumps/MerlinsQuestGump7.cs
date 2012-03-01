
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
    public class MerlinsQuestGump7 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("MerlinsQuestGump7", AccessLevel.GameMaster, new CommandEventHandler(MerlinsQuestGump7_OnCommand));
        }

        private static void MerlinsQuestGump7_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new MerlinsQuestGump7(e.Mobile));
        }

        public MerlinsQuestGump7(Mobile owner)
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
"<BASEFONT COLOR=ORANGE><I>Slighty stunned at the words coming from your mouth he falls back into his chair</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE>Tell me now. Where did you get these words and how did you learn to speak them so accurately?<BR><BR>" +
"<BASEFONT COLOR=ORANGE><I>You lean against the table as you begin to tell Peiraniese of your endeavor</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE>Hrm uh huh I see. Well the spell he used was from an ancient past so long ago that time has almost forgotten it." +
"<BASEFONT COLOR=ORANGE> Let me see what I can do for you<I> He begins shifting through ancient texts and scrolls... *Sigh*</I><BR><BR>" +
"<BASEFONT COLOR=ORANGE>I fear I cannot help you. It seems I don't have the required ancient texts to fully translate this<BR><BR>" +
"<BASEFONT COLOR=ORANGE>However if you retrieve for me the Scroll of Archametes I'd then be able to translate it for you " +
"<BASEFONT COLOR=ORANGE>It's said that the sole remaining copy existed in two parts of the world, one held by a Guardian and another stolen by an evil Gargoyle " +
"<BASEFONT COLOR=ORANGE>The Guardian is west of an ancient pyramid in Malas and the Gargoyle is holed up on Marble Island<BR><BR>" +
"<BASEFONT COLOR=ORANGE>When you have both pieces put them together and return here and give them to me<BR><BR>" +


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

