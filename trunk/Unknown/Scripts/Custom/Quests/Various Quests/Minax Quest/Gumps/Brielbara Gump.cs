//Written by Lord Dalamar
using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class BrielbaraGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "BrielbaraGump", AccessLevel.GameMaster, new CommandEventHandler( BrielbaraGump_OnCommand ) ); 
      } 

      private static void BrielbaraGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new BrielbaraGump( e.Mobile ) ); 
      } 

      public BrielbaraGump( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "The Search for Minax" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>*Brielbara continues stirring her pot as if your not there*<BR><BR>So you seek Lady Minax do you?<BR><BR>Well, who am I to argue with someone who wants to march to their doom.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>But if you must have her whereabouts, then I need an ingredient that only Lloth has. I must have two pieces of her spiders silk, that is the only way for me to locate Lady Minax.<BR>" +
"<BASEFONT COLOR=YELLOW>Bring me that which I ask for and you shall have what you ask and another piece to the prize you seek, not that it will do you any good dead. ha hah hehe.....<BR><BR>Lloth can be found at the heart of the Dungeon of Fire. Go if you dare.....<BR>" +
						     "</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               from.SendMessage( "The Search for Minax continues!!!" );
               break; 
            } 

         }
      }
   }
}