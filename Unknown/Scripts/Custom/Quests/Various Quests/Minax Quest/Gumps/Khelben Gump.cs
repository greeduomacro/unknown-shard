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
   public class KhelbenGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "KhelbenGump", AccessLevel.GameMaster, new CommandEventHandler( KhelbenGump_OnCommand ) ); 
      } 

      private static void KhelbenGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new KhelbenGump( e.Mobile ) ); 
      } 

      public KhelbenGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>*Khelben looks up from his tome and sneers at you*<BR><BR>Why have you disturbed my studies? Ask what you must and be gone.<BR><BR>Ahhh you seek the Lady Minax, a task you say, well then I must see what I can do.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>There is a way to track her down, but I am not one to give out my secrets so quickly. You must do something for me in return.<BR>" +
"<BASEFONT COLOR=YELLOW>There is a rare root that I need; it grows only on a great walking tree. He is as old as the forest and very dangerous, you must fell this beast and bring me the root I ask for and I shall give you the information you seek and another piece to your reward.<BR><BR>He can be found in the Forest north of the shrine of spirituality in ilshenar.<BR>" +
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