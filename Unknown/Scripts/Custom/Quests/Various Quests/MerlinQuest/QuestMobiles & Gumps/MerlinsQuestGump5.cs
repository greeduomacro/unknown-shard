
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
    public class MerlinsQuestGump5 : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("MerlinsQuestGump5", AccessLevel.GameMaster, new CommandEventHandler(MerlinsQuestGump5_OnCommand));
        }

        private static void MerlinsQuestGump5_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new MerlinsQuestGump5(e.Mobile));
        }

        public MerlinsQuestGump5(Mobile owner)
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
"<BASEFONT COLOR=RED>I cannot believe you've beat me!!<BR><BR></COLOR><COLOR=YELLOW><I> You can't help but to pity this young man as blood drains from his mouth and ears</I><BR><BR>" +
"<BASEFONT COLOR=RED>So be it if you wish to reach Merlin but you must first obtain his staff.  When you get his staff, equip it and double click it and it will teleport you to Merlins home.<BR><BR>"+
"<BASEFONT COLOR=RED><I> coughing blood as he tries to speak</I><BR><BR> Go now... through this gate<BR><BR><I>He struggles as he waves his hands creating a portal where you stand</I><BR><BR>"+
"<BASEFONT COLOR=RED>Go now and make your way through the elaborate setting Merlin has made to guard his Staff<BR><BR><I>You notice Talon reaching into his pocket to retrive what looks like a bracelet<BR><BR>"+
"<BASEFONT COLOR=RED>Wear this or you surely die in your efforts to reach the staff...<I>cough cough</I> It will require not only that bracelet but all the magic you have to obtain the staff<BR><BR>"+
"<BASEFONT COLOR=RED><I>Talon slumps fully over now as he releases his final gurgling breath</I><BR><BR>"+



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

