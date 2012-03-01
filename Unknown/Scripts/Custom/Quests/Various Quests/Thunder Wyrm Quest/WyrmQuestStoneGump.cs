using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class WyrmQuestStoneGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "WyrmQuestStoneGump", AccessLevel.GameMaster, new CommandEventHandler( WyrmQuestStoneGump_OnCommand ) ); 
      } 


      private static void WyrmQuestStoneGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new WyrmQuestStoneGump( e.Mobile ) ); 
      }
      public WyrmQuestStoneGump( Mobile owner ) : base( 50,50 ) 
      { 
         AddPage( 0 ); 
         AddBackground( 0, 0, 375, 300, 5054 ); 
	 AddLabel( 130, 30, 0, "Claim Your Prize!");
	 AddItem( 200, 175, 9922 );

         AddButton( 60, 68, 0x2623, 0x2622, 1, GumpButtonType.Reply, 0 );
	 AddLabel( 85, 65, 33, "Wyrm's Soul Bow" ); 


}
public override void OnResponse( NetState state, RelayInfo info )
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: 
            { 

               from.SendMessage( "You decide not to claim your prizes." );
               break; 
            } 
            case 1: 
            { 
		   Item[] WQStone = from.Backpack.FindItemsByType( typeof( WQStone ) );
		   if ( from.Backpack.ConsumeTotal( typeof( WQStone ), 1 ) )

		   {
         	   WyrmSoulBow WyrmSoulBow = new WyrmSoulBow();
		   from.AddToBackpack( WyrmSoulBow );
               from.SendMessage( "a Wyrm Soul's Bow fall into your backpack." );
		   }
		   else
		   {
		   from.SendMessage( "You do not have a Wyrm Soul's Stone Ticket." );
		   }
		   break;

            }

	           
}
}
}
}