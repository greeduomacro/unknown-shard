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
   public class KnolanGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "KnolanGump", AccessLevel.GameMaster, new CommandEventHandler( KnolanGump_OnCommand ) ); 
      } 

      private static void KnolanGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new KnolanGump( e.Mobile ) ); 
      } 

      public KnolanGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>*Knolan eyes you with contempt*<BR><BR>Do you think ye worthy of a task set forth by the King? If so listen close fair adventurer, for the task I have for thee is most perilous.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>A message of great importance has been stolen by Lady Minax.<BR>It is safe for now for there is an enchantment on the parchment that only allows me to read it, but it is only a matter of time before the enchantment is broken and all is lost.<BR>" +
"<BASEFONT COLOR=YELLOW>Bring me this message and you shall be rewarded greatly upon the completion of your task.<BR><BR>Throughout your journey, each person you talk to will give you a piece of your reward.<BR>" +
"<BASEFONT COLOR=YELLOW>You must seek out an old friend of mine, a fur trader named Jhasso. He has information on how to locate Lady Minax.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>He was last seen near Delucia.<BR><BR>Go seek him out.....<BR>" +
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
               from.SendMessage( "The Search for Minax is on!!!" );
               break; 
            } 

         }
      }
   }
}