using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
	public class MagiQuestGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register( "MagiQuestGump", AccessLevel.Administrator, new CommandEventHandler( MagiQuestGump_OnCommand ));
		}

		private static void MagiQuestGump_OnCommand( CommandEventArgs e) 
		{
			e.Mobile.SendGump( new MagiQuestGump( e.Mobile ));
		}

		public MagiQuestGump(Mobile owner)
			: base(50, 50)
		{
			//---------------------------------------------------------------------------------------------------

			AddPage(0);
			AddImageTiled(54, 33, 369, 400, 2624);
			AddAlphaRegion(54, 33, 369, 400);

			AddImageTiled(416, 39, 44, 389, 203);
			//--------------------------------Window size bar----------------------------------------------------

			AddImage(97, 49, 9005);
			AddImageTiled(58, 39, 29, 390, 10460);
			AddImageTiled(412, 37, 31, 389, 10460);
			AddLabel(140, 60, 0x34, "Magi Quest");


			AddHtml(107, 140, 300, 230, "<BODY>" +
			//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW><I>Master Of the Magis looks at you<BR><BR>" +
"<BASEFONT COLOR=YELLOW>I see you must like what i have on,indeed. " +
"<BASEFONT COLOR=YELLOW>If you wish to have a suit of this magical power you must do something in return. " +
"<BASEFONT COLOR=YELLOW>I require the ore of the magi and the scroll of the magi. " +
"<BASEFONT COLOR=YELLOW>You can find the creature that Weilds the ore deep within the dungeon of Wisps. " +
"<BASEFONT COLOR=YELLOW>The other creature that Weilds the Magi's Scroll may be found deep within the clutchs of Destard. " +
"<BASEFONT COLOR=YELLOW>Bring me these items i require and I shall reward you with a peice of the Magi's Great armor<BR><BR>" +
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

			//---------------------------------------------------------------------------------------------------
		}

		public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons
		{
			Mobile from = state.Mobile;

			switch ( info.ButtonID )
			{
				case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0
					{
						//Cancel
						from.SendMessage("GoodLuck");
						break;
					}
			}
		}
	}
}
