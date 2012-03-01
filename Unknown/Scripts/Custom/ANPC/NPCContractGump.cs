using System; 
using Server;
using Server.Gumps;
using Server.Items; 
using Server.Commands;
using Server.Menus;
using Server.Menus.Questions; 
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Prompts;
using Server.Accounting;
using Server.Regions; 

namespace Server.Gumps 
{ 
   public class NPCContractGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "NPCContractGump", AccessLevel.GameMaster, new CommandEventHandler( NPCContractGump_OnCommand ) ); 
      } 

      private static void NPCContractGump_OnCommand( CommandEventArgs e ) 
      { 
        e.Mobile.SendGump( new NPCContractGump( e.Mobile ) ); 
        } 

        public NPCContractGump( Mobile owner ) : base( 50,50 ) 
        { 
        
         AddPage( 0 ); 
         AddBackground( 7, 12, 299, 451, 83 );
		 AddBackground( 16, 22, 283, 71, 3600 );
		 AddBackground( 16, 94, 283, 71, 3600 );
		 AddBackground( 16, 166, 283, 71, 3600 );
		 AddBackground( 16, 238, 283, 71, 3600 );
		 AddBackground( 16, 309, 283, 71, 3600 );
		 AddBackground( 16, 381, 283, 71, 3600 );
		 AddLabel( 50, 33, 1150, "Make Sure You Stand In The Spot" );
		 AddLabel( 55, 48, 1150, "Where You Want Your NPC To" );
		 AddLabel( 40, 63, 1150, "Stand When Placing It In Your House." ); 
                 
         AddButton( 34, 115, 2151, 2154, 1, GumpButtonType.Reply, 0 ); AddLabel( 66, 120, 37, "ALCHEMIST" ); 		 
		 AddButton( 163, 115, 2151, 2154, 2, GumpButtonType.Reply, 0 ); AddLabel( 196, 114, 1257, "ANIMAL" ); AddLabel( 195, 130, 1257, "TRAINER" ); 		 
		 AddButton( 34, 187, 2151, 2154, 3, GumpButtonType.Reply, 0 ); AddLabel( 66, 192, 1161, "BANKER" ); 		 
		 AddButton( 163, 187, 2151, 2154, 4, GumpButtonType.Reply, 0 ); AddLabel( 196, 192, 1368, "BLACKSMITH" );  
         AddButton( 34, 259, 2151, 2154, 5, GumpButtonType.Reply, 0 ); AddLabel( 66, 265, 1265, "CARPENTER" ); 
         AddButton( 163, 259, 2151, 2154, 6, GumpButtonType.Reply, 0 ); AddLabel( 196, 265, 97, "JEWELER" );  
         AddButton( 34, 330, 2151, 2154, 7, GumpButtonType.Reply, 0 ); AddLabel( 66, 335, 111, "MAGE" );  
         AddButton( 163, 330, 2151, 2154, 8, GumpButtonType.Reply, 0 ); AddLabel( 196, 335, 171, "PROVISIONER" );  
         AddButton( 34, 402, 2151, 2154, 9, GumpButtonType.Reply, 0 ); AddLabel( 66, 408, 95, "TAILOR" );  
         AddButton( 163, 402, 2151, 2154, 10, GumpButtonType.Reply, 0 ); AddLabel( 196, 408, 416, "TINKER" );          		 		        
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
          case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0
            { 
               //Cancel 
               from.SendMessage( 33, "You decide not to make your selection at this time." ); 
               break; 
            } 
            case 1: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    AAlchemistContract AAlchemistContract = new AAlchemistContract(); 
                    from.AddToBackpack ( AAlchemistContract );
			        from.SendMessage( "An Alchemist Contract has been placed in your pack." );
			} 
            break;
			}
			case 2: 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    AAnimalTrainerContract AAnimalTrainerContract = new AAnimalTrainerContract(); 
                    from.AddToBackpack ( AAnimalTrainerContract );
			        from.SendMessage( "An Animal Trainer Contract has been placed in your pack." );
			} 
            break;
			}
			case 3: 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    ABankerContract ABankerContract = new ABankerContract(); 
                    from.AddToBackpack ( ABankerContract );
			        from.SendMessage( "A Banker Contract has been placed in your pack." );
			} 
            break;
			}
			case 4:
            {
			     Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    ABlacksmithContract ABlacksmithContract = new ABlacksmithContract(); 
                    from.AddToBackpack ( ABlacksmithContract );
			        from.SendMessage( "A Blacksmith Contract has been placed in your pack." );
			} 
            break; 
            } 
            case 5: //Same as above 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    ACarpenterContract ACarpenterContract = new ACarpenterContract(); 
                    from.AddToBackpack ( ACarpenterContract );
			        from.SendMessage( "A Carpenter Contract has been placed in your pack." );
			}
			break;  
            } 
            case 6: 
            {
			     Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    AJewelerContract AJewelerContract = new AJewelerContract(); 
                    from.AddToBackpack ( AJewelerContract );
			        from.SendMessage( "A Jeweler Contract has been placed in your pack." );
			}
			break; 
            } 
            case 7: 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{ 
                    AMageContract AMageContract = new AMageContract(); 
                    from.AddToBackpack ( AMageContract );
			        from.SendMessage( "A Mage Contract has been placed in your pack." );
			}
			break; 
            } 
            case 8: 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{ 
                    AProvisionerContract AProvisionerContract = new AProvisionerContract(); 
                    from.AddToBackpack ( AProvisionerContract );
			        from.SendMessage( "A Provisioner Contract has been placed in your pack." );
			}
			break; 
            } 
            case 9: 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    ATailorContract ATailorContract = new ATailorContract(); 
                    from.AddToBackpack ( ATailorContract );
			        from.SendMessage( "A Tailor Contract has been placed in your pack." );
			}
			break; 
            } 
            case 10: 
            {
			    Item[] NPCToken = from.Backpack.FindItemsByType( typeof ( NPCToken ) );
				if ( from.Backpack.ConsumeTotal( typeof( NPCToken ), 1 ) )
				{  
                    ATinkerContract ATinkerContract = new ATinkerContract(); 
                    from.AddToBackpack ( ATinkerContract );
			        from.SendMessage( "A Tinker Contract has been placed in your pack." );
			}
			break;     
            } 
         } 
      } 
   } 
}