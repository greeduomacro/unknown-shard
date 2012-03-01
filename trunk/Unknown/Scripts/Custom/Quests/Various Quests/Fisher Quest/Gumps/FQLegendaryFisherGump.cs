using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class FQLegendaryFisherGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "FQLegendaryFisherGump", AccessLevel.GameMaster, new CommandEventHandler( FQLegendaryFisherGump_OnCommand ) ); 
      } 

      private static void FQLegendaryFisherGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new FQLegendaryFisherGump( e.Mobile ) ); 
      } 

      public FQLegendaryFisherGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Fisher Quest" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=White><I>The Legendary Fisher looks at you with concern.</I><br><br>" +
"<BASEFONT Color=White>Oh, please help me!<br><br>" + 
"<BASEFONT COLOR=White>A Theiving Serpentine has stolen the greatest catch of my life! I had caught a Golden Fish! Yes, that is right... a GOLDEN FISH!<br><br>" +
"<BASEFONT COLOR=White>I have many great fishing items that I can part with. I will give you a piece of my precious clothing, or maybe even a white scroll, for your efforts.<br><br>" +
"<BASEFONT COLOR=White>Please, please... I beg of thee to return to me the Golden Fish that is rightfully mine!<br><br>" +
"<BASEFONT COLOR=White>The Thieving Serpentine is located a very long ways south of this shop. You will find 2 fishing holes where the Golden Fish was stolen from me. The Serpentine should be close to there.<br><br>" +
"</BODY>", false, true);
			
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
               from.SendMessage( "Legendary Fisher Says: Please get me back my Golden Fish!" );
               break; 
            } 

         }
      }
   }
}