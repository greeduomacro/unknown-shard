using System;
using System.Net;
using Server;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class StoneGump : Gump
	{
		private Mobile m_Mobile;
	      private Item m_Deed;

      	public StoneGump(Mobile from, Item deed)
			:base(20, 15)
        	{
            	m_Mobile = from;
            	m_Deed = deed;
			Closable = true;
            	Disposable = true;
            	Dragable = true;
			Resizable = false;
	  	            AddPage(0);

		AddBackground( 0, 0, 300, 400, 3000 ); 
         	AddBackground( 8, 8, 284, 384, 5120 ); 
            	 AddLabel( 40, 12, 37, "PICK YOUR REWARD FOR VOTING!" ); 
			AddButton(74, 111, 4023, 4024, 1, GumpButtonType.Reply, 0); //Shroud
			AddButton(74, 140, 4023, 4024, 2, GumpButtonType.Reply, 1); //Earrings
			AddButton(74, 169, 4023, 4024, 3, GumpButtonType.Reply, 2); //Sandals
			AddButton(74, 198, 4023, 4024, 4, GumpButtonType.Reply, 3); //Sandals            
         		AddButton( 12, 360, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddLabel( 52, 360, 37, "Close" ); 
			AddLabel(113, 111, 0, @"Vote Shroud");
			AddLabel(113, 140, 0, @"Vote Earrings");
 			AddLabel(113, 169, 0, @"Vote Sandals");
			AddLabel(113, 198, 0, @"Vote Half Apron");
		}

	public override void OnResponse(NetState state, RelayInfo info)

        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0: //Close Gump 
                    {
                        from.CloseGump(typeof(StoneGump));
                        break;
                    }
                case 1: // Voterobe
                    {
                        Item item = new VoteShroud();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(StoneGump));
                                                break;
                    }
                case 2: // Vote Earrings
                    {
                        Item item = new VoteEarrings();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(StoneGump));
                                             break;
                    }
                case 3: // Vote Sandals
                    {
                        Item item = new VoteSandals();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(StoneGump));
                                               break;
                    }
                case 4: // Vote Half Apron
                    {
                        Item item = new VoteHalf();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(StoneGump));
                                               break;
                    }
   
            }
        }
    }
}


