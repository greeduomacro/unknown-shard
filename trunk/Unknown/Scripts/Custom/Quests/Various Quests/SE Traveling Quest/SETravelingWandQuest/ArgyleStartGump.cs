using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class ArgyleStartGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ArgyleStartGump", AccessLevel.GameMaster, new CommandEventHandler( ArgyleStartGump_OnCommand ) ); 
      } 

      private static void ArgyleStartGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ArgyleStartGump( e.Mobile ) ); 
      } 

      public ArgyleStartGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Argyle's Missing Runes" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Greetings!  I am in need of some help!<BR><BR>I once had a special rune book that would allow me to travel all the world over. But then one day I lost it! The only thing I have now is this traveling wand to get me around. It will do the job, but I really miss my rune book!<BR><BR>Say! I'll make a deal with you. If you can restore my rune book, I will gladly trade you for this special wand I have. Even though I know how to use the rune book properly, you will not be able to use it. However, this wand can be used by those with less experience in the arcane arts, such as yourself.<BR><BR>Do you want to help me?<BR><BR>Then here. Take this empty rune book and fill it up with the glowing runes from all over the world. These runes are found at city banks, at dungeon entrances, and other special points of interest I have found over the years, including on the Tokuno Islands. Be sure not to miss any, for there are 95 total runes in all!<BR><BR>Oh, I almost forgot. Here's a book of my notes that you might find useful. It has information on where the special runes can be found!<BR><BR>If you return to me with my full rune book, I will gladly trade you for this wand I have. You can then use it to freely travel to the places where you find the runes.<BR><BR>Now go and restore my rune book! I'm counting on you!" +
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
               from.SendMessage( "Restore the rune book!" );
               break; 
            } 

         }
      }
   }
}