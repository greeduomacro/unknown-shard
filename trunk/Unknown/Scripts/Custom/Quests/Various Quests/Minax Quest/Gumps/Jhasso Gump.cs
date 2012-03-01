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
   public class JhassoGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "JhassoGump", AccessLevel.GameMaster, new CommandEventHandler( JhassoGump_OnCommand ) ); 
      } 

      private static void JhassoGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new JhassoGump( e.Mobile ) ); 
      } 

      public JhassoGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>*Jhasso looks up at you and smiles.*<BR><BR>Well I see you have been sent by Knolan.<BR><BR>Yeah I know how to find Lady Minax, but that kind of information is not easily obtained, so you must do something for me.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>There is a great beast with a beautiful golden coat that I have sought for sometime now. I don't have the strength to face the beast.<BR>Bring me the golden wool from the beast and I will give you the information you seek and the first part of your reward.<BR>" +
"<BASEFONT COLOR=YELLOW>The beast roams somewhere north of here.<BR>" +
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