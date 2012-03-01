using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class JonesquestGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "JonesquestGump", AccessLevel.GameMaster, new CommandEventHandler( JonesquestGump_OnCommand ) ); 
      } 

      private static void JonesquestGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new JonesquestGump( e.Mobile ) ); 
      } 

      public JonesquestGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Crappy Quest" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>Farmer Jones  looks at you with hope. After he puts down his hoe, he says If you are brave enough, I have a task for you<BR><BR>I take it you wish for me to continue. I am i need of fertilizer for my garden.<BR>" +
"<BASEFONT COLOR=WHITE>Are you still interested?<BR><BR>What I would need you to do, is go kill the Crayma and bring me their crap Some of them have it some don't. Some may also give you an Artifact." +
"<BASEFONT COLOR=WHITE>What I need from you, is to  bring me back 20 pieces of Crayma Crap so I can use it to help my garden grow.<BR><BR>If you decide to go through with this, I will give you a sword as well for your troubles." +
						     "</BODY>", false, true);
			
//			<BASEFONT COLOR=#0x481>			

//			AddLabel( 113, 135, 0x34, "Farmer Jones puts down his hoe and asks.." );
//			AddLabel( 113, 150, 0x34, "so you are going to help me?" );
//			AddLabel( 113, 165, 0x34, "Remember, I need 20 pieces of crap..." );
//			AddLabel( 113, 180, 0x34, "" );
//			AddLabel( 113, 195, 0x34, "You can find the crap on Crayma" );
//			AddLabel( 113, 210, 0x34, "after you kill those pesky Crayma" );
//			AddLabel( 113, 235, 0x34, "They are pretty hard to beat up but" );
//			AddLabel( 113, 250, 0x34, "I think you can handle it if you work hard" );
//			AddLabel( 113, 265, 0x34, "and have the motivation of a good sword." );
//			AddLabel( 113, 280, 0x34, "Good luck! Dont get to hurt and remember," );
//			AddLabel( 113, 295, 0x34, "20 pieces of crap can make my garden grow." );
//			AddLabel( 113, 310, 0x34, "" );
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
               from.SendMessage( "Farmer Jones goes back to his garden work." );
               break; 
            } 

         }
      }
   }
}