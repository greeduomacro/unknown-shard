////////////////////////////  ///////////////////////
//// Created by Andyboi  //  // and Lucid Nagual ////
//////////////////////////  /////////////////////////
////   DO NOT REMOVE   //  // Easy Level System  ////
////   THIS HEADER!!  //  //   Version [2].0.1   ////
///////////////////////  ////////////////////////////
using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.LevelSystem;
using Server.ACC.CM;
using Server.Commands;
using Server.LucidNagual;


namespace Server.Gumps
{
	public class EasyLevelGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register( "Level", AccessLevel.Player, new CommandEventHandler( EasyLevelGump_OnCommand ) );
		}
		
		private static void EasyLevelGump_OnCommand( CommandEventArgs e )
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;
			PlayerModule module = pm.PlayerModule;

			e.Mobile.CloseGump( typeof( EasyLevelGump ) );
			e.Mobile.SendGump( new EasyLevelGump( e.Mobile ) );
		}
		
		private int m_Amount1;
		private int m_Amount2;
		private int m_Amount3;
		private int m_Amount4;
		private int m_Amount5;
		private int m_Amount6;
		private int m_Amount7;
		private int m_Amount8;
		
		public EasyLevelGump( Mobile owner ) : base( 50,50 )
		{
			PlayerMobile pm = owner as PlayerMobile;
			PlayerModule module = pm.PlayerModule;
			
			//Integers [Adjust the cost of Exp Tokens here.]
			m_Amount1 = 3;  //3 Exp Tokens
			m_Amount2 = 5;  //5 Exp Tokens
			m_Amount3 = 7;  //7 Exp Tokens
			m_Amount4 = 8;  //8 Exp Tokens
			m_Amount5 = 9;  //9 Exp Tokens
			m_Amount6 = 10; //10 Exp Tokens
			m_Amount7 = 12; //12 Exp Tokens
			m_Amount8 = 16; //16 Exp Tokens
			//Integers [Adjust the cost of Exp Tokens here.]
			
			if( DataCenter.EnablePlayerLevelSystem )
			{
				//--<<Main Menu>>--<Page 1>--[Start]
				AddPage( 1 );
				//Backgrounds
				AddBackground(28, 28, 501, 507, 2620);   //Main [Background]
				AddBackground(157, 53, 246, 34, 9350);   //[server name] Level System [Background]
				AddBackground(53, 111, 158, 36, 9300);   //My Exp Pts [Background]
				AddBackground(53, 156, 158, 36, 9300);   //Current Level [Background]
				AddBackground(53, 201, 158, 36, 9300);   //Current Rank [Background]
				AddBackground(53, 246, 158, 36, 9300);   //Current Age [Background]
				AddBackground(53, 291, 158, 36, 9300);   //My Skill Pts [Background]
				AddBackground(53, 416, 158, 36, 9350);   //Quick Status Menu [Background]
				AddBackground(283, 109, 219, 342, 3500); //Right-side [Background]
				//Backgrounds
				
				//Dividers
				AddImageTiled(241, 110, 16, 360, 10303); //Bottom Bar [Divider]
				AddImageTiled(48, 467, 462, 17, 10301);  //Center [Divider]
				//Dividers
				
				//Art
				AddImage(100, 340, 111); //Ankh [Art]
				AddImage(49, 340, 112);  //Left Sword [Art]
				AddImage(150, 340, 112); //Right Sword [Art]
				AddImage(346, 212, 990); //Person [Art]
				AddImage(342, 215, 653); //Axe [Art]
				AddImage(305, 363, 105); //Heart [Art]
				//Art
				
				//Strings
				AddLabel(216, 60, 89, string.Format( "{0} Level System", LevelControlStone.ServerName ) );
				AddLabel(65, 119, 1153,  "My Exp Pts: "    + module.Experience + "" );
				AddLabel(65, 164, 1153,  "Current Level: " + module.Level +      "" );
				AddLabel(65, 208, 1153,  "Current Rank: "  + module.RankPoints + "" );
				AddLabel(65, 254, 1153,  "Current Age: "   + module.Age +        "" );
				AddLabel(65, 297, 1153,  "My Skill Pts: "  + module.SkillPts +   "" );
				AddLabel(65, 424, 0,     "Quick Stats Menu: "  );
				AddLabel( 395, 500, 102, "Gump By Andy"        );
				AddLabel(303, 141, 1150, @"Level Info _________");
				//Strings
				
				//Buttons
				AddButton(184, 426, 9702, 9703,   1, GumpButtonType.Reply, 0 ); //Quick Staus Menu
				AddButton(453, 136, 10850, 10850, 0, GumpButtonType.Page,  2 ); //Level Info
				//Buttons
				
				//Other
				if ( DataCenter.EnableExpTokens )
				{
					AddLabel(303, 171, 1150, @"Spend Exp Tokens ____ ");
					AddButton(453, 166, 10830, 10830, 0, GumpButtonType.Page,  3 ); //Spend Exp Tokens
				}
				if ( DataCenter.EnableSkillPoints )
				{
					this.AddLabel(303, 201, 1150, @"Spend Skill Pts ______");
					this.AddButton(453, 196, 10810, 10810, 4, GumpButtonType.Reply, 0 ); //Spend Skill Pts
				}
				//Other
				//--<<Main Menu>>--<Page 1>--[End]
				
				
				//--<<Level Info>>--<Page 2>--[Start]
				AddPage( 2 );
				//Background & Tiled
				AddBackground( 0, 0, 250, 350, 3500 );   //Main [Background]
				AddBackground( 68, 15, 130, 30, 9300 );  //Level Info [Background]
				AddImageTiled( 161, 54, 2, 254, 10003 ); //Center [Divider]
				AddImageTiled( 58, 25, 150, 40, 93 );    //Top center line
				//Background & Tiled
				
				//Art
				AddImage( 9, 25, 92 );   //Left "flower" [Art]
				AddImage( 149, 25, 94 ); //Leaves [Art]
				AddImage( 201, 44, 59 ); //End of yelow divider [Art]
				//Art
				
				//Strings
				AddLabel( 79, 20, 1153, "Level Information" );
				AddLabel( 50, 55, 0, "Level 0: 0" );
				AddLabel( 50, 70, 0, "Level 1: 500" );
				AddLabel( 50, 85, 0, "Level 2: 1k" );
				AddLabel( 50, 100, 0, "Level 3: 2.5k" );
				AddLabel( 50, 115, 0, "Level 4: 5k" );
				AddLabel( 50, 130, 0, "Level 5: 10k" );
				AddLabel( 50, 145, 0, "Level 6: 25k" );
				AddLabel( 50, 160, 0, "Level 7: 50k" );
				AddLabel( 50, 175, 0, "Level 8: 100k" );
				AddLabel( 50, 190, 0, "Level 9: 200k" );
				AddLabel( 50, 205, 0, "Level 10: 300k" );
				AddLabel( 50, 220, 0, "Level 11: 400k" );
				AddLabel( 50, 235, 0, "Level 12: 500k" );
				AddLabel( 50, 250, 0, "Level 13: 600k" );
				AddLabel( 50, 265, 0, "Level 14: 700k" );
				AddLabel( 50, 280, 0, "Level 15: 800k" );
				AddLabel( 50, 295, 0, "Level 16: 900k" );
				//---------------------------------------
				AddLabel( 180, 55, 0, "500" );
				AddLabel( 180, 70, 0, "1k" );
				AddLabel( 180, 85, 0, "2.5k" );
				AddLabel( 180, 100, 0, "5k" );
				AddLabel( 180, 115, 0, "10k" );
				AddLabel( 180, 130, 0, "25k" );
				AddLabel( 180, 145, 0, "50k" );
				AddLabel( 180, 160, 0, "100k" );
				AddLabel( 180, 175, 0, "200k" );
				AddLabel( 180, 190, 0, "300k" );
				AddLabel( 180, 205, 0, "400k" );
				AddLabel( 180, 220, 0, "500k" );
				AddLabel( 180, 235, 0, "600k" );
				AddLabel( 180, 250, 0, "700k" );
				AddLabel( 180, 265, 0, "800k" );
				AddLabel( 180, 280, 0, "900k" );
				AddLabel( 180, 295, 0, "1mil" );
				AddLabel( 180, 318, 0, "By Andy" );
				//Strings
				
				//Other
				AddButton( 18, 318, 5223, 5223, 0, GumpButtonType.Page, 1 );
				AddLabel( 43, 316, 0, "Back" );
				//Other
				//--<<Level Info>>--<Page 2>--[End]
				
				
				//--<<Spend Exp>>--<Page 3>--[Start] //Main
				AddPage( 3 );
				AddBackground( 0, 0, 200, 250, 9270 );
				AddBackground( 15, 15, 170, 30, 9300 );
				AddLabel( 40, 20, 1153, "Purchasable Items" );
				
				AddBackground( 15, 70, 170, 30, 9350 );
				AddLabel( 20, 75, 1150, "Decorative Items" );
				AddButton( 150, 75, 4007, 4006, 0, GumpButtonType.Page, 4 );
				AddBackground( 15, 120, 170, 30, 9350 );
				AddLabel( 20, 125, 1150, "Clothing/Jewelery" );
				AddButton( 150, 125, 4005, 4006, 0, GumpButtonType.Page, 6 );
				AddBackground( 15, 170, 170, 30, 9350 );
				AddLabel( 20, 175, 1150, "Weapons/Armor" );
				AddButton( 150, 175, 4005, 4006, 0, GumpButtonType.Page, 7 );
				AddButton( 15, 215, 5223, 5223, 0, GumpButtonType.Page, 1 );
				AddLabel( 40, 215, 102, "Back" );
				//--<<Spend Exp>>--<Page 3>--[End] //Main
				
				
				//--<<Spend Exp>>--<Page 4>--[Start] //Deco
				AddPage( 4 );
				AddBackground( 0, 0, 220, 320, 9270 );
				AddBackground( 25, 15, 170, 30, 9300 );
				AddLabel( 50, 20, 1153, "Purchasable Items" );
				
				AddLabel( 35, 45, 1150, "Item" );
				AddLabel( 120, 45, 1150, "Price" );
				AddBackground( 15, 65, 190, 210, 3500 );
				AddImageTiled( 110, 74, 2, 192, 10005 );
				for ( int y = 0; y < 7; ++y )
					AddImageTiled( 24, ( 25 * y ) + 100, 172, 2, 10001 );
				for ( int i = 0; i < 7; ++i )
					AddButton( 175, ( 25 * i ) + 80, 5224, 5224, i + 5, GumpButtonType.Reply, 0 );
				AddLabel( 30, 80, 0, "Brazier B" );
				AddLabel( 120, 80, 0, "" + m_Amount1 );
				AddLabel( 30, 105, 0, "Brazier NB" );
				AddLabel( 120, 105, 0, "" + m_Amount2 );
				AddLabel( 30, 130, 0, "Curtain S" );
				AddLabel( 120, 130, 0, "" + m_Amount2 );
				AddLabel( 30, 155, 0, "Curtain E" );
				AddLabel( 120, 155, 0, "" + m_Amount2 );
				AddLabel( 30, 180, 0, "Candle" );
				AddLabel( 120, 180, 0, "" + m_Amount2 );
				AddLabel( 30, 205, 0, "Skeleton" );
				AddLabel( 120, 205, 0, "" + m_Amount3 );
				AddLabel( 30, 230, 0, "BSkeleton" );
				AddLabel( 120, 230, 0, "" + m_Amount4 );
				AddButton( 15, 285, 5223, 5223, 0, GumpButtonType.Page, 3 );
				AddLabel( 40, 285, 102, "Back" );
				AddLabel( 115, 280, 1150, "Next Page" );
				AddButton( 185, 285, 9702, 9703, 0, GumpButtonType.Page, 5 );
				//--<<Spend Exp>>--<Page 4>--[End] //Deco
				
				
				//--<<Spend Exp>>--<Page 5>--[Start] //Deco
				AddPage( 5 );
				AddBackground( 0, 0, 220, 320, 9270 );
				AddBackground( 25, 15, 170, 30, 9300 );
				AddLabel( 50, 20, 1153, "Purchasable Items" );
				
				AddLabel( 35, 45, 1150, "Item" );
				AddLabel( 120, 45, 1150, "Price" );
				AddBackground( 15, 65, 190, 210, 3500 );
				AddImageTiled( 110, 74, 2, 192, 10005 );
				for ( int y = 0; y < 5; ++y )
					AddImageTiled( 24, ( 25 * y ) + 100, 172, 2, 10001 );
				for ( int i = 0; i < 5; ++i )
					AddButton( 175, ( 25 * i ) + 80, 5224, 5224, i + 12, GumpButtonType.Reply, 0 );
				AddLabel( 30, 80, 0, "M Skeleton" );
				AddLabel( 120, 80, 0, "" + m_Amount5 );
				AddLabel( 30, 105, 0, "Guillotine" );
				AddLabel( 120, 105, 0, "" + m_Amount6 );
				AddLabel( 30, 130, 0, "Open Maiden" );
				AddLabel( 120, 130, 0, "" + m_Amount6 );
				AddLabel( 30, 155, 0, "Closed Maiden" );
				AddLabel( 120, 155, 0, "" + m_Amount6 );
				AddLabel( 30, 180, 0, "Skull Spikes" );
				AddLabel( 120, 180, 0, "" + m_Amount6 );
				//--<<Spend Exp>>--<Page 5>--[End] //Deco
				
				
				//--<<Spend Exp>>--<Page 6>--[Start] //Clothing & Jewelry
				AddPage( 6 );
				AddBackground( 0, 0, 250, 360, 9270 );
				AddBackground( 45, 15, 170, 30, 9300 );
				AddLabel( 70, 20, 1153, "Purchasable Items" );
				
				AddLabel( 35, 45, 1150, "Item" );
				AddLabel( 150, 45, 1150, "Price" );
				AddBackground( 15, 65, 220, 260, 3500 );
				AddImageTiled( 140, 74, 2, 242, 10005 );
				for ( int y = 0; y < 9; ++y )
					AddImageTiled( 24, ( 25 * y ) + 100, 202, 2, 10001 );
				for ( int i = 0; i < 9; ++i )
					AddButton( 205, ( 25 * i ) + 80, 5224, 5224, i + 17, GumpButtonType.Reply, 0 );
				AddLabel( 30, 80, 0, "Dragon Silk Shirt" );
				AddLabel( 150, 80, 0, "" + m_Amount7 );
				AddLabel( 30, 105, 0, "Cloak of Magician" );
				AddLabel( 150, 105, 0, "" + m_Amount7 );
				AddLabel( 30, 130, 0, "Spider Silk Pants" );
				AddLabel( 150, 130, 0, "" + m_Amount7 );
				AddLabel( 30, 155, 0, "Orc Skin Shoes" );
				AddLabel( 150, 155, 0, "" + m_Amount7 );
				AddLabel( 30, 180, 0, "Wizards Hat/Int" );
				AddLabel( 150, 180, 0, "" + m_Amount7 );
				AddLabel( 30, 205, 0, "Shroud of Magi" );
				AddLabel( 150, 205, 0, "" + m_Amount7 );
				AddLabel( 30, 230, 0, "Serpent Fang Ear" );
				AddLabel( 150, 230, 0, "" + m_Amount7 );
				AddLabel( 30, 255, 0, "Brace of Leaders" );
				AddLabel( 150, 255, 0, "" + m_Amount7 );
				AddLabel( 30, 280, 0, "Warriors Ring" );
				AddLabel( 150, 280, 0, "" + m_Amount7 );
				AddButton( 15, 325, 5223, 5223, 0, GumpButtonType.Page, 3 );
				AddLabel( 40, 325, 102, "Back" );
				//--<<Spend Exp>>--<Page 6>--[End] //Clothing & Jewelry
				
				
				//--<<Spend Exp>>--<Page 7>--[Start] //Armor & Weapons
				AddPage( 7 );
				AddBackground( 0, 0, 220, 320, 9270 );
				AddBackground( 25, 15, 170, 30, 9300 );
				AddLabel( 50, 20, 1153, "Purchasable Items" );
				
				AddLabel( 35, 45, 1150, "Item" );
				AddLabel( 120, 45, 1150, "Price" );
				AddBackground( 15, 65, 190, 210, 3500 );
				AddImageTiled( 110, 74, 2, 192, 10005 );
				for ( int y = 0; y < 2; ++y )
					AddImageTiled( 24, ( 25 * y ) + 100, 172, 2, 10001 );
				for ( int i = 0; i < 2; ++i )
					AddButton( 175, ( 25 * i ) + 80, 5224, 5224, i + 26, GumpButtonType.Reply, 0 );
				AddLabel( 30, 80, 0, "Pickaxe/Ages" );
				AddLabel( 120, 80, 0, "" + m_Amount8 );
				AddLabel( 30, 105, 0, "Glove/Shadw" );
				AddLabel( 120, 105, 0, "" + m_Amount8 );
				AddButton( 15, 285, 5223, 5223, 0, GumpButtonType.Page, 3 );
				AddLabel( 40, 285, 102, "Back" );
				//--<<Spend Exp>>--<Page 7>--[End] //Armor & Weapons
			}
		}
		//--------------------------------------------------------------------------------------------------------------
		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
		{
			Mobile from = state.Mobile;
			PlayerMobile pm = from as PlayerMobile;
			PlayerModule module = pm.PlayerModule; //This is a null check.

			Item ET = from.Backpack.FindItemByType( typeof( ExpToken ) );

			//string nofunds = "You do not have enough gold pieces in your backpack.";
			string notokens ="You do not have enough experience tokens in your backpack.";
			string given = "Your reward item has been placed in your backpack.";
			
			switch ( info.ButtonID )
			{
				case 0: //Cancel
					{
						from.SendMessage( "You stop viewing your level information" );
						break;
					}
				case 1://Quick Stats Menu
					{
						from.SendMessage( "You Open your quick status." );
						from.CloseGump( typeof( EasyLevelGump ) );
						from.SendGump( new LevelStatusGump( from ) );
						break;
					}
				case 4: //Skill point reward gump
					{
						from.SendGump( new SkillPointRewardGump( from ) );
						from.SendMessage( "You open the skill point reward system..." );
						break;
					}
				case 5: //Brazier Bottom
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount1 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new BrazierBottom() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 6: //Brazier No Bottom
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount2 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new BrazierNoBottom() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 7: //Curtain South
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount2 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new CurtainWhiteRight() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 8: //Curtain East
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount2 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new CurtainWhiteLeft() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 9: //Candle stub
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount2 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new CandleStub() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 10: //no boot Skeleton
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount3 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new NoBootSkeleton() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 11: //Boot Skeleton
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount4 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new BootsSkeleton() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 12: //Meaty Skeleton
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount5 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new MeatySkeleton() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 13: //Guillotine
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount6 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new Guillotine() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 14: //Open Maiden
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount6 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new OpenIronMaiden() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 15: //Closed Maiden
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount6 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new ClosedIronMaiden() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 16: //Skull Spikes
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount6 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new SkullSpikes() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 17: //Dragon Silk shirt
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new DragonSilkShirt() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 18: //Cloak of Magician
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new CloakOfTheMagician() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 19: //Spider Silk Pants
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new SpiderSilkPants() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 20: //Orc Skin Shoes
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new OrcSkinShoes() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 21: //wizards hat intel
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new WizardsHatOfIntelligence() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 22: //shroud of magician
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new ShroudOfTheMagician() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 23: //serpent fang earrings
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new SerpentFangEarrings() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 24: //Brace of Leaders
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new BraceletOfLeaders() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 25: //warriors ring o luck
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount7 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new WarriorsRingOfLuck() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 26: //Pickaxe of the Ages
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount8 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new PickaxeOfTheAges() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
				case 27: //gloves of the shadows
					{
						if ( ET != null )
						{
							if ( from.Backpack.ConsumeTotal( typeof( ExpToken ), m_Amount8 ) )
							{
								from.SendMessage( "{0}", given );
								from.AddToBackpack( new GlovesOfTheShadows() );
							}
							else
								from.SendMessage( 47, "{0}", notokens );
						}
						else
							from.SendMessage( 47, "{0}", notokens );
						break;
					}
			}
		}
	}
}


namespace Server.Gumps
{
	public class LevelStatusGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register( "QS", AccessLevel.Player, new CommandEventHandler( LevelStatusGump_OnCommand ) );
		}
		
		private static void LevelStatusGump_OnCommand( CommandEventArgs e )
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;
			PlayerModule module = pm.PlayerModule;

			e.Mobile.CloseGump( typeof( LevelStatusGump ) );
			e.Mobile.SendGump( new LevelStatusGump( e.Mobile ) );
		}
		
		public LevelStatusGump( Mobile owner ) : base( 50,50 )
		{
			PlayerMobile pm = owner as PlayerMobile;
			PlayerModule module = pm.PlayerModule;
			
			AddPage( 0 );
			AddBackground( 0, 0, 230, 380, 2620 );
			AddBackground( 20, 20, 190, 30, 9300 );
			AddLabel( 44, 26, 1153, "Level and Age Status" );
			
			AddBackground( 20, 70, 190, 30, 9350 );
			AddLabel( 30, 75, 1150, "Current Exp : " + ( ( PlayerModule )module ).Experience + "" );
			AddBackground( 20, 120, 190, 30, 9350 );
			AddLabel( 30, 125, 1150, "Current Level : " + ( ( PlayerModule )module ).Level + "" );
			AddBackground( 20, 170, 190, 30, 9350 );
			AddLabel( 30, 175, 1150, "Current Rank : " + ( ( PlayerModule )module ).RankPoints + "" );
			AddBackground( 20, 220, 190, 30, 9350 );
			AddLabel( 30, 225, 1150, "Your Age : " + ( ( PlayerModule )module ).Age + "" );
			AddBackground( 20, 270, 190, 30, 9350 );
			AddLabel( 30, 275, 1150, "Current Skill Pts : " + ( ( PlayerModule )module ).SkillPts + "" );
			
			AddItem( 24, 315, 8784, 1175 );
			AddItem( 154, 315, 8785, 1175 );
			AddItem( 58, 317, 3937, 1172 );
			AddItem( 82, 317, 3936, 1172 );
			AddLabel( 134, 351, 102, "Gump by Andy" );
			
			AddButton( 11, 357, 10006, 10006, 1, GumpButtonType.Reply, 1 );
			AddLabel( 27, 353, 1150, "Refresh" );
		}
		
		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
		{
			Mobile from = state.Mobile;
			Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
			
			switch ( info.ButtonID )
			{
				case 0: //Cancel
					{
						from.SendMessage( "Done lookin at ur stats ey? =)" );
						break;
					}
				case 1://Start Room
					{
						from.SendMessage( "You Refresh your current status." );
						from.CloseGump( typeof( LevelStatusGump ) );
						mobile.SendGump( new LevelStatusGump( m ) );
						break;
					}
			}
		}
	}
}
