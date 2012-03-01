using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class FarmerBillGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "FarmerBillGump", AccessLevel.GameMaster, new CommandEventHandler( FarmerBillGump_OnCommand ) ); 
      } 

      private static void FarmerBillGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new FarmerBillGump( e.Mobile ) ); 
      } 

      public FarmerBillGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Quest Of The Chicken Plucker " );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=White><I>Farmer Bill looks at you in complete dissaray<br>" +
"<BASEFONT Color=White><I>Oh me, Oh my, so you wish to partake on an epic journey eh? You are such a foolish soul.<br>" + 
"<BASEFONT COLOR=White><I>The Evil Chicken Plucker has stolen my prize chickens and the the item I crafted from their unique feathers!!<br>" +
"<BASEFONT COLOR=White><I>But with your great skills you should be able to kill him and retrieve the item that I had crafted?<br>" +
"<BASEFONT COLOR=White><I>The Chicken Plucker has retreated to the dangerous Islands of Tokuno somewhere near the Fan Dancers Dojo!<br>" +
"<BASEFONT COLOR=White><I>Find him, kill him, and the item he has is yours!!<br>" +
"<BASEFONT COLOR=White><I>I must warn you to be very careful as Chicken Plucker is no easy foe to defeat and he has corrupted my wonderful chickens!!<br>" + 
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
               from.SendMessage( "Now go kill that dirty Chicken Plucker" );
               break; 
            } 

         }
      }
   }
}