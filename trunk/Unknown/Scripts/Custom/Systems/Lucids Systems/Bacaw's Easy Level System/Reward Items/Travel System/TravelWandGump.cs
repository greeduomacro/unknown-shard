using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;


namespace Server.Gumps
{
	public class TravelWandGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register( "Travel", AccessLevel.Owner, new CommandEventHandler( TravelWandGump_OnCommand ) );
		}
		
		private static void TravelWandGump_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendGump( new TravelWandGump( e.Mobile ) );
		}
		
		public TravelWandGump( Mobile owner ) : base( 50,50 )
		{
			AddPage( 0 );
			AddBackground( 0, 0, 500, 320, 5054);
			AddLabel( 425, 292, 0x34, "Close" );
			AddButton( 395, 292, 0xFB1, 0xFB3, 27, GumpButtonType.Reply, 0 );
			AddAlphaRegion( 10, 60, 325, 250 );
			AddImage( 470, 3, 10410);
			AddImage( 470, 305, 10412);
			AddImage( 470, 150, 10411);
			
			AddPage( 1 );
			AddHtml( 20, 20, 460, 27,"Unknown Shard", true, false );
			
			AddHtml( 345, 60, 140, 225,"Fel Towns.", true, true );
			AddLabel( 65, 275, 2072, "Page 12" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 12 );
			
			AddLabel( 180, 275, 2066, "Page 2" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 2 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 1, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2066, "Britain" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 2, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2066, "Buc’s Den" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 3, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2066, "Cove" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 4, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2066, "Delucia" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 5, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2066, "Jhelom" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 6, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2066, "Minoc" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 7, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2066, "Moonglow" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 8, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2066, "Nujel’m" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 9, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2066, "Occlo" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 10, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2066, "Papua" );
			
			AddButton( 135, 153, 0x2623, 0x2622, 13, GumpButtonType.Reply, 0 );
			AddLabel( 155, 150, 2066, "Serpent's Hold" );
			
			AddButton( 135, 183, 0x2623, 0x2622, 14, GumpButtonType.Reply, 0 );
			AddLabel( 155, 180, 2066, "Skara Brae" );
			
			AddButton( 135, 213, 0x2623, 0x2622, 15, GumpButtonType.Reply, 0 );
			AddLabel( 155, 210, 2066, "Trinsic" );
			
			AddButton( 135, 243, 0x2623, 0x2622, 16, GumpButtonType.Reply, 0 );
			AddLabel( 155, 240, 2066, "Vesper" );
			
			AddButton( 235, 63,0x2623, 0x2622, 17, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2066, "Wind" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 18, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2066, "Yew" );
			
			
			//// START PAGE 2
			
			AddPage( 2 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, "These are Felucca’s Shrines.", true, true );
			AddLabel( 65, 275, 2066, "Page 1" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 1 );
			
			AddLabel( 180, 275, 2066, "Page 3" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 3 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 19, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2066, "Chaos" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 20, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2066, "Compassion" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 21, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2066, "Honesty" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 22, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2066, "Honor" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 23, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2066, "Humility" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 24, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2066, "Justice" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 25, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2066, "Sacrifice" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 26, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2066, "Spirituality" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 27, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2066, "Valor" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 28, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2066, "Fire Island" );
			
			AddButton( 135, 150, 0x2623, 0x2622, 29, GumpButtonType.Reply, 0 );
			AddLabel( 155, 153, 2066, "Fisher’s Hut" );
			
			AddButton( 135, 180, 0x2623, 0x2622, 30, GumpButtonType.Reply, 0 );
			AddLabel( 155, 183, 2066, "Waterfall" );
			
			AddButton( 135, 210, 0x2623, 0x2622, 31, GumpButtonType.Reply, 0 );
			AddLabel( 155, 213, 2066, "Hedge Maze" );
			
			AddButton( 135, 240, 0x2623, 0x2622, 32, GumpButtonType.Reply, 0 );
			AddLabel( 155, 243, 2066, "Hidden Valley" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 33, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2066, "Marble Island" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 34, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2066, "Temple Island" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 35, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2066, "Cove Orc Fort" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 36, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2066, "Brigand Camp" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 37, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2066, "Yew Orc Fort" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 38, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2066, "Vesper Camp" );
			
			
			///// END PAGE 2
			
			//// START PAGE 3
			
			AddPage( 3 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, "These are Felucca Dungeons and Graveyards.", true, true );
			AddLabel( 65, 275, 2066, "Page 2" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 2 );
			
			AddLabel( 180, 275, 2067, "Page 4" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 4 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 39, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2066, "City Of The Dead" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 40, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2066, "Britain G.Y." );
			
			AddButton( 35, 123, 0x2623, 0x2622, 41, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2066, "Cove G.Y." );
			
			AddButton( 35, 153, 0x2623, 0x2622, 42, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2066, "Jhelom G.Y." );
			
			AddButton( 35, 183, 0x2623, 0x2622, 43, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2066, "Moonglow G.Y." );
			
			AddButton( 35, 213, 0x2623, 0x2622, 44, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2066, "Nujel’m G.Y." );
			
			AddButton( 35, 243, 0x2623, 0x2622, 45, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2066, "Vesper G.Y." );
			
			AddButton( 135, 63, 0x2623, 0x2622, 46, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2066, "Yew G.Y." );
			
			AddButton( 135, 123, 0x2623, 0x2622, 47, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2066, "Yew Crypts" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 48, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2066, "Britain Passage" );
			
			AddButton( 135, 150, 0x2623, 0x2622, 49, GumpButtonType.Reply, 0 );
			AddLabel( 155, 153, 2066, "Covetous" );
			
			AddButton( 135, 180, 0x2623, 0x2622, 50, GumpButtonType.Reply, 0 );
			AddLabel( 155, 183, 2066, "Deceit" );
			
			AddButton( 135, 210, 0x2623, 0x2622, 51, GumpButtonType.Reply, 0 );
			AddLabel( 155, 213, 2066, "Despise" );
			
			AddButton( 135, 240, 0x2623, 0x2622, 52, GumpButtonType.Reply, 0 );
			AddLabel( 155, 243, 2066, "Destard" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 53, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2066, "Fire" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 54, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2066, "Hythloth" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 55, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2066, "Ice" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 56, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2066, "Shame" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 57, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2066, "Terathan Keep" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 58, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2066, "Trinsic Passage" );
			
			AddButton( 235, 243, 0x2623, 0x2622, 59, GumpButtonType.Reply, 0 );
			AddLabel( 255, 240, 2066, "Wrong" );
			
			
			
			///// END PAGE 3
			
			
			//// START PAGE 4
			
			AddPage( 4 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			
			AddHtml( 345, 60, 140, 225, "Towns of Trammel.", true, true );
			AddLabel( 65, 275, 2066, "Page 3" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 3 );
			
			AddLabel( 195, 275, 2067, "Page 5" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 5 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 60, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2067, "Britain" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 61, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2067, "Buc’s Den" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 62, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2067, "Cove" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 63, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2067, "Delucia" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 66, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2067, "Haven" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 67, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2067, "Jhelom" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 68, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2067, "Minoc" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 69, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2067, "Moonglow" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 70, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2067, "Nujel’m" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 71, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2067, "Papua" );
			
			AddButton( 135, 183, 0x2623, 0x2622, 72, GumpButtonType.Reply, 0 );
			AddLabel( 155, 180, 2067, "Serpent’s Hold" );
			
			AddButton( 135, 153, 0x2623, 0x2622, 73, GumpButtonType.Reply, 0 );
			AddLabel( 155, 150, 2067, "Skara Brae" );
			
			AddButton( 135, 243, 0x2623, 0x2622, 75, GumpButtonType.Reply, 0 );
			AddLabel( 155, 240, 2067, "Trinsic" );
			
			AddButton( 135, 213, 0x2623, 0x2622, 77, GumpButtonType.Reply, 0 );
			AddLabel( 155, 210, 2067, "Vesper" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 78, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2067, "Wind" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 79, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2067, "Yew" );
			
			
			///// END PAGE 4
			
			
			//// START PAGE 5
			
			AddPage( 5 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, "These are Trammel Shrines.", true, true );
			AddLabel( 65, 275, 2067, "Page 4" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 4 );
			
			AddLabel( 180, 275, 2067, "Page 6" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 6 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 80, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2067, "Chaos" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 81, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2067, "Compassion" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 82, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2067, "Honesty" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 83, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2067, "Honor" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 84, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2067, "Humility" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 85, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2067, "Justice" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 86, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2067, "Sacrifice" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 87, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2067, "Spirituality" );
			
			AddButton( 135, 153, 0x2623, 0x2622, 88, GumpButtonType.Reply, 0 );
			AddLabel( 155, 150, 2067, "Valor" );
			
			AddButton( 135, 183, 0x2623, 0x2622, 89, GumpButtonType.Reply, 0 );
			AddLabel( 155, 180, 2067, "Fire Island" );
			
			AddButton( 135, 213, 0x2623, 0x2622, 90, GumpButtonType.Reply, 0 );
			AddLabel( 155, 210, 2067, "Fisher’s Hut" );
			
			AddButton( 135, 243, 0x2623, 0x2622, 91, GumpButtonType.Reply, 0 );
			AddLabel( 155, 240, 2067, "Waterfall" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 92, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2067, "Hedge Maze" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 93, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2067, "Hidden Valley" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 94, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2067, "Marble Island" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 95, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2067, "Temple Island" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 96, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2067, "Cove Orc Fort" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 97, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2067, "Brigand Camp" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 98, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2067, "Yew Orc Fort" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 99, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2067, "Vesper Camp" );
			
			
			///// END PAGE 5
			
			
			//// START PAGE 6
			
			AddPage( 6 );
			AddHtml( 20, 20, 460, 27,"Shard Names", true, false );
			
			AddHtml( 345, 60, 140, 225, "These are Trammel Dungeons and Graveyards.", true, true );
			AddLabel( 65, 275, 2067, "Page 5" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 5 );
			
			AddLabel( 180, 275, 2069, "Page 7" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 7 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 100, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2067, "City Of The Dead" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 101, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2067, "Britain G.Y." );
			
			AddButton( 35, 123, 0x2623, 0x2622, 102, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2067, "Cove G.Y." );
			
			AddButton( 35, 153, 0x2623, 0x2622, 103, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2067, "Jhelom G.Y." );
			
			AddButton( 35, 183, 0x2623, 0x2622, 104, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2067, "Moonglow G.Y." );
			
			AddButton( 35, 213, 0x2623, 0x2622, 105, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2067, "Nujel’m G.Y." );
			
			AddButton( 35, 243, 0x2623, 0x2622, 106, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2067, "Vesper G.Y." );
			
			AddButton( 135, 63, 0x2623, 0x2622, 107, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2067, "Yew G.Y." );
			
			AddButton( 135, 123, 0x2623, 0x2622, 108, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2067, "Yew Crypts" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 109, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2067, "Britain Passage" );
			
			AddButton( 135, 150, 0x2623, 0x2622, 110, GumpButtonType.Reply, 0 );
			AddLabel( 155, 153, 2067, "Covetous" );
			
			AddButton( 135, 180, 0x2623, 0x2622, 111, GumpButtonType.Reply, 0 );
			AddLabel( 155, 183, 2067, "Deceit" );
			
			AddButton( 135, 210, 0x2623, 0x2622, 112, GumpButtonType.Reply, 0 );
			AddLabel( 155, 213, 2067, "Despise" );
			
			AddButton( 135, 240, 0x2623, 0x2622, 113, GumpButtonType.Reply, 0 );
			AddLabel( 155, 243, 2067, "Destard" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 114, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2067, "Fire" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 115, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2067, "Hythloth" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 116, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2067, "Ice" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 117, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2067, "Shame" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 118, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2067, "Terathan Keep" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 119, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2067, "Trinsic Passage" );
			
			AddButton( 235, 243, 0x2623, 0x2622, 120, GumpButtonType.Reply, 0 );
			AddLabel( 255, 240, 2067, "Wrong" );
			
			
			///// END PAGE 6
			
			
			//// START PAGE 7
			
			AddPage( 7 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, "These locations are to Ilshenar.", true, true );
			AddLabel( 65, 275, 2067, "Page 6" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 6 );
			
			AddLabel( 180, 275, 2069, "Page 8" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 8 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 121, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2069, "Alex’s Bowl" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 122, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2069, "Ancient Citadel" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 123, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2069, "Gargoyle City" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 124, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2069, "Lakeshire" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 125, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2069, "Mistas" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 126, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2069, "Montor" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 127, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2069, "Savage Camp" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 128, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2069, "Solitude Isle" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 129, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2069, "Terort Skitas" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 130, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2069, "Cyclops Temple" );
			
			AddButton( 135, 150, 0x2623, 0x2622, 131, GumpButtonType.Reply, 0 );
			AddLabel( 155, 153, 2069, "Blackthorn’s Castle" );
			
			AddButton( 135, 180, 0x2623, 0x2622, 132, GumpButtonType.Reply, 0 );
			AddLabel( 155, 183, 2069, "Nox Tereg" );
			
			AddButton( 135, 210, 0x2623, 0x2622, 133, GumpButtonType.Reply, 0 );
			AddLabel( 155, 213, 2069, "Pormir Felwis" );
			
			AddButton( 135, 240, 0x2623, 0x2622, 134, GumpButtonType.Reply, 0 );
			AddLabel( 155, 243, 2069, "Pormir Harm" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 135, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2069, "Twin Oaks" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 136, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2069, "Ancient Lair" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 137, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2069, "Gypsy Camp" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 138, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2069, "Gypsy Camp 2" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 139, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2069, "Gypsy Camp 3" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 140, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2069, "Gypsy Camp 4" );
			
			AddButton( 235, 243, 0x2623, 0x2622, 141, GumpButtonType.Reply, 0 );
			AddLabel( 255, 240, 2069, "Gypsy Camp 5" );
			
			
			///// END PAGE 7
			
			//// START PAGE 8
			
			AddPage( 8 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, "These Ilshenar shrines.", true, true );
			AddLabel( 65, 275, 2069, "Page 7" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 7 );
			
			AddLabel( 180, 275, 2070, "Page 9" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 9 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 142, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2069, "Chaos" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 143, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2069, "Compassion" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 144, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2069, "Honesty" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 145, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2069, "Humility" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 146, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2069, "Justice" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 147, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2069, "Sacrifice" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 148, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2069, "Spirituality" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 149, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2069, "Sacrifice" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 150, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2069, "Valor" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 151, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2069, "Lizard Passage" );
			
			AddButton( 135, 150, 0x2623, 0x2622, 152, GumpButtonType.Reply, 0 );
			AddLabel( 155, 153, 2069, "Mushroom Cave" );
			
			AddButton( 135, 180, 0x2623, 0x2622, 153, GumpButtonType.Reply, 0 );
			AddLabel( 155, 183, 2069, "Rat Cave" );
			
			AddButton( 135, 210, 0x2623, 0x2622, 154, GumpButtonType.Reply, 0 );
			AddLabel( 155, 213, 2069, "Rat Fort" );
			
			AddButton( 135, 240, 0x2623, 0x2622, 155, GumpButtonType.Reply, 0 );
			AddLabel( 155, 243, 2069, "Spider Cave" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 156, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2069, "Ankh" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 157, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2069, "Blood" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 158, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2069, "Exodus" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 159, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2069, "Rock" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 160, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2069, "Sorcerers" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 161, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2069, "Spectre" );
			
			AddButton( 235, 243, 0x2623, 0x2622, 162, GumpButtonType.Reply, 0 );
			AddLabel( 255, 240, 2069, "Wisp" );
			
			
			///// END PAGE 8
			
			
			//// START PAGE 9
			
			AddPage( 9 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, "Malas.", true, true );
			AddLabel( 65, 275, 2069, "Page 8" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 8 );
			
			AddLabel( 180, 275, 2070, "Page 10" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 10 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 163, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2070, "Luna" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 164, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2070, "Umbra" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 165, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2070, "Arena" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 166, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2070, "Doom" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 167, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2070, "Broken Mountains" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 168, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2070, "Corrupted Forest" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 169, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2070, "Crumbling Continent" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 170, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2070, "Crystal Fens" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 171, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2070, "Divide Of The Abyss" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 172, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2070, "Dry Highlands" );
			
			AddButton( 135, 150, 0x2623, 0x2622, 173, GumpButtonType.Reply, 0 );
			AddLabel( 155, 153, 2070, "Forgotten Pyramid" );
			
			AddButton( 135, 180, 0x2623, 0x2622, 174, GumpButtonType.Reply, 0 );
			AddLabel( 155, 183, 2070, "Gravewater Lake" );
			
			AddButton( 135, 210, 0x2623, 0x2622, 175, GumpButtonType.Reply, 0 );
			AddLabel( 155, 213, 2070, "Grimswind Ruins" );
			
			AddButton( 135, 240, 0x2623, 0x2622, 176, GumpButtonType.Reply, 0 );
			AddLabel( 155, 243, 2070, "Hanse’s Hostel" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 177, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2070, "Orc Fortress" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 178, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2070, "Orc Fort" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 179, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2070, "Orc Fort 2" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 180, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2070, "Orc Fort 3" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 181, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2070, "Orc Fort 4" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 182, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2070, "Orc Fort 5" );
			
			AddButton( 235, 243, 0x2623, 0x2622, 183, GumpButtonType.Reply, 0 );
			AddLabel( 255, 240, 2070, "Orc Fort 6" );
			
			
			///// END PAGE 9
			
			
			
			//// START PAGE 10
			
			AddPage( 10 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, "Malas.", true, true );
			AddLabel( 65, 275, 2070, "Page 9" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 9 );
			
			AddLabel( 180, 275, 2071, "Page 11" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 11 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 184, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2070, "Mine" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 185, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2070, "Mine 2" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 186, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2070, "Mine 3" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 187, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2070, "Mine 4" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 188, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2070, "Mine 5" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 189, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2070, "Mine 6" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 190, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2070, "Mine 7" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 191, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2070, "Mine 8" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 192, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2070, "Mine 9" );
			
			
			///// END PAGE 10
			
			
			
			//// START PAGE 11
			
			AddPage( 11 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, " Tokono.", true, true );
			AddLabel( 65, 275, 2070, "Page 10" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 10 );
			
			AddLabel( 180, 275, 2072, "Page 12" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 12 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 193, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2071, "Zento" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 194, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2071, "Compassion" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 195, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2071, "Spirituality" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 196, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2071, "Valor" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 197, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2071, "Bushido Dojo" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 198, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2071, "FanDancer’s Dojo" );
			
			AddButton( 35, 243, 0x2623, 0x2622, 199, GumpButtonType.Reply, 0 );
			AddLabel( 55, 240, 2071, "Ninja’s Enclave" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 200, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2071, "Crane Marsh" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 205, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2071, "Mt. Sho" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 206, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2071, "Phoenix Mountains" );
			
			AddButton( 135, 153, 0x2623, 0x2622, 201, GumpButtonType.Reply, 0 );
			AddLabel( 155, 150, 2071, "Defiance Point" );
			
			AddButton( 135, 183, 0x2623, 0x2622, 202, GumpButtonType.Reply, 0 );
			AddLabel( 155, 180, 2071, "Field Of Echoes" );
			
			AddButton( 135, 213, 0x2623, 0x2622, 203, GumpButtonType.Reply, 0 );
			AddLabel( 155, 210, 2071, "Kitsume Woods" );
			
			AddButton( 135, 243, 0x2623, 0x2622, 204, GumpButtonType.Reply, 0 );
			AddLabel( 155, 240, 2071, "Lotus Lakes" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 207, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2071, "Storm Point" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 208, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2071, "Valley Of The Sleeping Dragon" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 209, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2071, "Wasteland" );
			
			AddButton( 235, 153, 0x2623, 0x2622, 210, GumpButtonType.Reply, 0 );
			AddLabel( 255, 150, 2071, "Winter Spur" );
			
			AddButton( 235, 183, 0x2623, 0x2622, 211, GumpButtonType.Reply, 0 );
			AddLabel( 255, 180, 2071, "Yomotsu Mines" );
			
			AddButton( 235, 213, 0x2623, 0x2622, 227, GumpButtonType.Reply, 0 );
			AddLabel( 255, 210, 2071, "Citadel" );
			
			AddButton( 235, 243, 0x2623, 0x2622, 228, GumpButtonType.Reply, 0 );
			AddLabel( 255, 240, 2071, "Sakuto" );
			
			
			///// END PAGE 11
			
			//// START PAGE 12
			
			AddPage( 12 );
			AddHtml( 20, 20, 460, 27,"Shard Name", true, false );
			
			AddHtml( 345, 60, 140, 225, " Mondain,(1st column are fel, 2nd column are tram, 3rd column are malas)", true, true );
			AddLabel( 65, 275, 2071, "Page 11" );
			AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 11 );
			
			AddLabel( 180, 275, 2066, "Page 1" );
			AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 1 );
			
			AddButton( 35, 63, 0x2623, 0x2622, 214, GumpButtonType.Reply, 0 );
			AddLabel( 55, 60, 2072, "Heartwood" );
			
			AddButton( 35, 93, 0x2623, 0x2622, 215, GumpButtonType.Reply, 0 );
			AddLabel( 55, 90, 2072, "Blight Grove" );
			
			AddButton( 35, 123, 0x2623, 0x2622, 216, GumpButtonType.Reply, 0 );
			AddLabel( 55, 120, 2072, "Paroxysmus" );
			
			AddButton( 35, 153, 0x2623, 0x2622, 217, GumpButtonType.Reply, 0 );
			AddLabel( 55, 150, 2072, "Prism Of Light" );
			
			AddButton( 35, 183, 0x2623, 0x2622, 218, GumpButtonType.Reply, 0 );
			AddLabel( 55, 180, 2072, "Sanctuary" );
			
			AddButton( 35, 213, 0x2623, 0x2622, 229, GumpButtonType.Reply, 0 );
			AddLabel( 55, 210, 2072, "Painted Caves" );
			
			AddButton( 135, 63, 0x2623, 0x2622, 219, GumpButtonType.Reply, 0 );
			AddLabel( 155, 60, 2072, "Heartwood" );
			
			AddButton( 135, 93, 0x2623, 0x2622, 220, GumpButtonType.Reply, 0 );
			AddLabel( 155, 90, 2072, "Blight Grove" );
			
			AddButton( 135, 123, 0x2623, 0x2622, 221, GumpButtonType.Reply, 0 );
			AddLabel( 155, 120, 2072, "Paroxysmus" );
			
			AddButton( 135, 153, 0x2623, 0x2622, 222, GumpButtonType.Reply, 0 );
			AddLabel( 155, 150, 2072, "Prism Of Light" );
			
			AddButton( 135, 183, 0x2623, 0x2622, 223, GumpButtonType.Reply, 0 );
			AddLabel( 155, 180, 2072, "Sanctuary" );
			
			AddButton( 135, 213, 0x2623, 0x2622, 230, GumpButtonType.Reply, 0 );
			AddLabel( 155, 210, 2072, "Painted Caves" );
			
			AddButton( 235, 63, 0x2623, 0x2622, 224, GumpButtonType.Reply, 0 );
			AddLabel( 255, 60, 2072, "Bedlam" );
			
			AddButton( 235, 93, 0x2623, 0x2622, 225, GumpButtonType.Reply, 0 );
			AddLabel( 255, 90, 2072, "Isle Divide" );
			
			AddButton( 235, 123, 0x2623, 0x2622, 226, GumpButtonType.Reply, 0 );
			AddLabel( 255, 120, 2072, "Labrynth" );
			
			
			///// END PAGE 12
			
			
		}
		
		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
		{
			Mobile from = state.Mobile;
			
			
			switch ( info.ButtonID )
			{
				case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0
					{
						//Cancel
						from.SendMessage( "You have chosen to stay here." );
						break;
					}
				case 1: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0
					{
						//Britian
						from.Map = Map.Felucca;
						from.Location = new Point3D(1430,1688,0);
						break;
					}
				case 2: //Same as above
					{
						//Buc’s Den
						from.Map = Map.Felucca;
						from.Location = new Point3D(2735,2135,0);
						break;
					}
				case 3: //Same as above
					{
						
						//Cove
						from.Map = Map.Felucca;
						from.Location = new Point3D(2234,1198,0);
						break;
					}
				case 4: //Same as above
					{
						//Delucia
						from.Map = Map.Felucca;
						from.Location = new Point3D(5271,3997,38);
						break;
					}
				case 5: //Same as above
					{
						//Jhelom
						from.Map = Map.Felucca;
						from.Location = new Point3D(1324,3779,0);
						break;
					}
				case 6: //Same as above
					{
						//Minoc
						from.Map = Map.Felucca;
						from.Location = new Point3D(2504,565,0);
						break;
					}
				case 7: //Same as above
					{
						//Moonglow
						from.Map = Map.Felucca;
						from.Location = new Point3D(4471,1167,0);
						break;
					}
				case 8: //Same as above
					{
						//Nujel’m
						from.Map = Map.Felucca;
						from.Location = new Point3D(3778,1306,0);
						break;
					}
				case 9: //Same as above
					{
						//Occlo
						from.Map = Map.Felucca;
						from.Location = new Point3D(3679,2520,0);
						
						break;
					}
				case 10: //Same as above
					{
						//Papua
						from.Map = Map.Felucca;
						from.Location = new Point3D(5676,3147,12);
						break;
					}
					/*case 11: //Same as above
{
// Pet Vs. Pet
from.Map = Map.Felucca;
from.Location = new Point3D(2233,837,0);
break;
}
case 12: //Same as above
{
//PVP Arena
from.Map = Map.Felucca;
from.Location = new Point3D(5577,1218,2);
break;
} */
					
				case 13: //Same as above
					{
						//Serpent’s Hold
						from.Map = Map.Felucca;
						from.Location = new Point3D(2876,3471,15);
						break;
					}
				case 14: //Same as above
					
					{
						//Skara Brae
						from.Map = Map.Felucca;
						from.Location = new Point3D(591,2157,0);
						break;
					}
				case 15: //Same as above
					{
						//Trinsic
						from.Map = Map.Felucca;
						from.Location = new Point3D(1827,2822,0);
						break;
					}
				case 16: //Same as above
					{
						//Vesper
						from.Map = Map.Felucca;
						from.Location = new Point3D(2903,690,0);
						break;
					}
				case 17: //Same as above
					{
						//Wind
						
						from.Map = Map.Felucca;
						from.Location = new Point3D(1371,891,0);
						break;
						
					}
				case 18: //Same as above
					{
						//Yew
						from.Map = Map.Felucca;
						from.Location = new Point3D(635,819,0 );
						break;
					}
				case 19: //Same as above
					{
						//Chaos
						from.Map = Map.Felucca;
						from.Location = new Point3D(1462,844,0);
						break;
					}
				case 20: //Same as above
					{
						//Compassion
						from.Map = Map.Felucca;
						
						from.Location = new Point3D(1857,860,7);
						break;
					}
				case 21: //Same as above
					{
						//Honesty
						from.Map = Map.Felucca;
						from.Location = new Point3D(4220,564,36);
						break;
					}
				case 22: //Same as above
					{
						//Honor
						
						from.Map = Map.Felucca;
						from.Location = new Point3D(1737,3527,0);
						break;
					}
				case 23: //Same as above
					{
						//Humility
						from.Map = Map.Felucca;
						from.Location = new Point3D(4269,3704,0 );
						break;
					}
				case 24: //Same as above
					{
						// Justice
						from.Map = Map.Felucca;
						from.Location = new Point3D(1301,644,7);
						break;
					}
				case 25: //Same as above
					{
						// Sacrifice
						from.Map = Map.Felucca;
						from.Location = new Point3D(3355,301,9);
						
						
						break;
					}
				case 26: //Same as above
					{
						// Spirituality
						from.Map = Map.Felucca;
						from.Location = new Point3D(1610,2490,0);
						break;
					}
				case 27: //Same as above
					{
						//Valor
						from.Map = Map.Felucca;
						from.Location = new Point3D(2500,3932,3);
						break;
					}
				case 28: //Same as above
					{
						// Fire Island
						from.Map = Map.Felucca;
						from.Location = new Point3D(4596,3626,30);
						break;
					}
				case 29: //Same as above
					{
						// Fisherman’s Hut
						from.Map = Map.Felucca;
						from.Location = new Point3D(2380,3486,3);
						break;
					}
				case 30: //Same as above
					{
						// Great Waterfall
						from.Map = Map.Felucca;
						from.Location = new Point3D(1322,547,30);
						break;
					}
				case 31: //Same as above
					{
						// Hedge Maze
						from.Map = Map.Felucca;
						from.Location = new Point3D(1149,2235,40);
						break;
					}
				case 32: //Same as above
					{
						// Hidden Valley
						from.Map = Map.Felucca;
						from.Location = new Point3D(1690,2986,0);
						break;
					}
				case 33: //Same as above
					{
						// Marble Island
						from.Map = Map.Felucca;
						from.Location = new Point3D(1906,2128,0);
						break;
					}
				case 34: //Same as above
					{
						// Temple Island
						from.Map = Map.Felucca;
						from.Location = new Point3D(2494,3603,0);
						break;
					}
				case 35: //Same as above
					{
						//Cove Orc Fort
						from.Map = Map.Felucca;
						from.Location = new Point3D(2171,1332,0);
						
						break;
					}
				case 36: //Same as above
					{
						//Yew Brigand Camp
						from.Map = Map.Felucca;
						from.Location = new Point3D(885,1682,0);
						break;
					}
				case 37: //Same as above
					{
						//Yew Orc Fort
						from.Map = Map.Felucca;
						from.Location = new Point3D(634,1500,0);
						break;
					}
				case 38: //Same as above
					{
						//Vesper Camp
						from.Map = Map.Felucca;
						from.Location = new Point3D(3349,573,0);
						break;
					}
				case 39: //Same as above
					{
						// City Of The Dead
						from.Map = Map.Felucca;
						from.Location = new Point3D(5223,3660,0);
						break;
					}
				case 40: //Same as above
					{
						// Britain Graveyard
						from.Map = Map.Felucca;
						from.Location = new Point3D(1384,1498,10);
						break;
					}
				case 41: //Same as above
					{
						// Cove Graveyard
						from.Map = Map.Felucca;
						from.Location = new Point3D(2444,1123,5);
						break;
					}
				case 42: //Same as above
					{
						// Jhelom Graveyard
						from.Map = Map.Felucca;
						from.Location = new Point3D(1295,3720,0 );
						break;
					}
				case 43: //Same as above
					{
						// Moonglow Graveyard
						from.Map = Map.Felucca;
						
						from.Location = new Point3D(4545,1339,8);
						break;
					}
				case 44: //Same as above
					{
						// Nujel’m Graveyard
						from.Map = Map.Felucca;
						from.Location = new Point3D(3537,1157,20 );
						break;
					}
				case 45: //Same as above
					{
						// Vesper Graveyard
						from.Map = Map.Felucca;
						from.Location = new Point3D(2787,867,0);
						break;
					}
				case 46: //Same as above
					{
						// Yew Graveyard
						from.Map = Map.Felucca;
						from.Location = new Point3D(724,1139,0);
						break;
					}
				case 47: //Same as above
					{
						//Yew Crypts
						from.Map = Map.Felucca;
						from.Location = new Point3D(972,768,0);
						break;
					}
				case 48: //Same as above
					{
						//Britain Passage
						from.Map = Map.Felucca;
						from.Location = new Point3D(6032,1500,25);
						break;
					}
				case 49: //Same as above
					{
						//Covetous
						from.Map = Map.Felucca;
						from.Location = new Point3D(2499,922,0 );
						break;
					}
				case 50: //Same as above
					{
						// Deceit
						from.Map = Map.Felucca;
						from.Location = new Point3D(4111,434,5);
						break;
					}
				case 51: //Same as above
					{
						// Despise
						from.Map = Map.Felucca;
						from.Location = new Point3D(1302,1081,0);
						break;
					}
				case 52: //Same as above
					{
						// Destard
						from.Map = Map.Felucca;
						from.Location = new Point3D(1176,2639,0);
						break;
					}
				case 53: //Same as above
					{
						// Fire
						from.Map = Map.Felucca;
						from.Location = new Point3D(5761,2907,15);
						break;
					}
				case 54: //Same as above
					{
						// Hythloth
						from.Map = Map.Felucca;
						from.Location = new Point3D(4722,3825,0);
						break;
					}
				case 55: //Same as above
					{
						// Ice
						from.Map = Map.Felucca;
						
						from.Location = new Point3D(1999,81,5);
						break;
					}
				case 56: //Same as above
					{
						// Shame
						from.Map = Map.Felucca;
						from.Location = new Point3D(514,1561,0);
						break;
					}
				case 57: //Same as above
					
					{
						// Terathan Keep
						from.Map = Map.Felucca;
						from.Location = new Point3D(5499,3224,0);
						break;
					}
				case 58: //Same as above
					{
						// Trinsic Passage
						from.Map = Map.Felucca;
						from.Location = new Point3D(1628,3323,0);
						break;
					}
				case 59: //Same as above
					{
						// Wrong
						from.Map = Map.Felucca;
						from.Location = new Point3D(2044,238,10);
						break;
					}
				case 60: //Same as above
					{
						// Britain
						from.Map = Map.Trammel;
						from.Location = new Point3D(1430,1688,0);
						break;
					}
				case 61: //Same as above
					{
						// Buc’s Den
						from.Map = Map.Trammel;
						from.Location = new Point3D(2735,2135,0);
						break;
					}
				case 62: //Same as above
					{
						// Cove
						from.Map = Map.Trammel;
						from.Location = new Point3D(2234,1198,0);
						break;
					}
				case 63: //Same as above
					{
						// Delucia
						from.Map = Map.Trammel;
						from.Location = new Point3D(5271,3997,38);
						break;
					}
					/*case 64: //Same as above
{
// Dye House
from.Map = Map.Trammel;
from.Location = new Point3D(3711,2049,5);
break;
}
case 65: //Same as above
{
// Hall Of Worlds
from.Map = Map.Trammel;
from.Location = new Point3D(5140,1773,0);
break;
} */
				case 66: //Same as above
					{
						// Haven
						from.Map = Map.Trammel;
						from.Location = new Point3D(3623,2618,21);
						break;
					}
				case 67: //Same as above
					{
						// Jhelom
						from.Map = Map.Trammel;
						from.Location = new Point3D(1324,3779,0);
						break;
					}
				case 68: //Same as above
					{
						// Minoc
						from.Map = Map.Trammel;
						from.Location = new Point3D(2504,565,0);
						break;
					}
				case 69: //Same as above
					{
						// Moonglow
						from.Map = Map.Trammel;
						from.Location = new Point3D(4471,1167,0);
						break;
					}
				case 70: //Same as above
					{
						// Nujel’m
						from.Map = Map.Trammel;
						from.Location = new Point3D(3778,1306,0 );
						
						break;
					}
				case 71: //Same as above
					{
						// Papua
						from.Map = Map.Trammel;
						from.Location = new Point3D(5676,3147,12);
						break;
					}
				case 72: //Same as above
					{
						// Serpent’s Hold
						from.Map = Map.Trammel;
						from.Location = new Point3D(2876,3471,15);
						break;
					}
				case 73: //Same as above
					{
						// Skara Brae
						from.Map = Map.Trammel;
						from.Location = new Point3D(591,2157,0);
						break;
					}
					/*case 74: //Same as above
{
// Trainers
from.Map = Map.Trammel;
from.Location = new Point3D(2236,843,0);
break;
} */
				case 75: //Same as above
					{
						// Trinsic
						from.Map = Map.Trammel;
						from.Location = new Point3D(1827,2822,0);
						break;
					}
					/*case 76: //Same as above
{
// Vendor Mall
from.Map = Map.Trammel;
from.Location = new Point3D(5587,1210,0 );
break;
} */
				case 77: //Same as above
					{
						// Vesper
						from.Map = Map.Trammel;
						from.Location = new Point3D(2903,690,0);
						break;
					}
				case 78: //Same as above
					{
						// Wind
						from.Map = Map.Trammel;
						from.Location = new Point3D(1371,891,0);
						break;
					}
				case 79: //Same as above
					{
						// Yew
						from.Map = Map.Trammel;
						from.Location = new Point3D(635,819,0);
						break;
					}
				case 80: //Same as above
					{
						// Chaos
						from.Map = Map.Trammel;
						from.Location = new Point3D(1462,844,0);
						break;
					}
				case 81: //Same as above
					{
						// Compassion
						from.Map = Map.Trammel;
						from.Location = new Point3D(1857,860,7);
						break;
					}
				case 82: //Same as above
					{
						// Honesty
						from.Map = Map.Trammel;
						from.Location = new Point3D(4220,564,36);
						break;
					}
				case 83: //Same as above
					{
						// Honor
						from.Map = Map.Trammel;
						from.Location = new Point3D(1737,3527,0);
						break;
					}
				case 84: //Same as above
					{
						// Humility
						from.Map = Map.Trammel;
						from.Location = new Point3D(4269,3704,0);
						break;
					}
				case 85: //Same as above
					{
						// Justice
						from.Map = Map.Trammel;
						from.Location = new Point3D(1301,644,7);
						
						break;
					}
				case 86: //Same as above
					{
						// Sacrifice
						from.Map = Map.Trammel;
						from.Location = new Point3D(3355,301,9);
						break;
					}
				case 87: //Same as above
					{
						// Spirituality
						from.Map = Map.Trammel;
						from.Location = new Point3D(1610,2490,0);
						break;
					}
				case 88: //Same as above
					{
						// Valor
						from.Map = Map.Trammel;
						from.Location = new Point3D(2500,3932,3);
						break;
					}
				case 89: //Same as above
					{
						// Fire Island
						from.Map = Map.Trammel;
						from.Location = new Point3D(4596,3626,30);
						break;
					}
				case 90: //Same as above
					{
						// Fisherman’s Hut
						from.Map = Map.Trammel;
						from.Location = new Point3D(2380,3486,3);
						break;
					}
				case 91: //Same as above
					{
						// Great Waterfall
						from.Map = Map.Trammel;
						from.Location = new Point3D(1322,547,30);
						break;
					}
				case 92: //Same as above
					{
						// Hedge Maze
						from.Map = Map.Trammel;
						from.Location = new Point3D(1149,2235,40);
						break;
					}
				case 93: //Same as above
					{
						// Hidden Valley
						from.Map = Map.Trammel;
						from.Location = new Point3D(1690,2986,0);
						break;
					}
				case 94: //Same as above
					{
						
						// Marble Island
						from.Map = Map.Trammel;
						from.Location = new Point3D(1906,2128,0);
						break;
					}
				case 95: //Same as above
					{
						// Temple Island
						from.Map = Map.Trammel;
						from.Location = new Point3D(2494,3603,0);
						break;
					}
				case 96: //Same as above
					{
						// Cove Orc Fort
						from.Map = Map.Trammel;
						from.Location = new Point3D(2171,1332,0 );
						break;
					}
				case 97: //Same as above
					{
						// Yew Brigand Camp
						from.Map = Map.Trammel;
						from.Location = new Point3D(885,1682,0);
						break;
					}
				case 98: //Same as above
					{
						// Yew Orc Fort
						from.Map = Map.Trammel;
						from.Location = new Point3D(634,1500,0);
						break;
					}
				case 99: //Same as above
					{
						// Vesper Camp
						from.Map = Map.Trammel;
						
						from.Location = new Point3D(3349,573,0);
						break;
					}
				case 100: //Same as above
					{
						// City Of The Dead
						from.Map = Map.Trammel;
						from.Location = new Point3D(5223,3660,0);
						break;
					}
				case 101: //Same as above
					{
						// Britain Graveyard
						from.Map = Map.Trammel;
						from.Location = new Point3D(1384,1498,10);
						break;
					}
				case 102: //Same as above
					{
						// Cove Graveyard
						from.Map = Map.Trammel;
						from.Location = new Point3D(2444,1123,5);
						break;
					}
				case 103: //Same as above
					{
						// Jhelom Graveyard
						from.Map = Map.Trammel;
						from.Location = new Point3D(1295,3720,0);
						break;
					}
				case 104: //Same as above
					{
						// Moonglow Graveyard
						from.Map = Map.Trammel;
						from.Location = new Point3D(4545,1339,8);
						break;
					}
				case 105: //Same as above
					{
						// Nujel’m Graveyard
						from.Map = Map.Trammel;
						from.Location = new Point3D(3537,1157,20);
						break;
					}
				case 106: //Same as above
					{
						// Vesper Graveyard
						from.Map = Map.Trammel;
						
						from.Location = new Point3D(2787,867,0);
						break;
					}
				case 107: //Same as above
					{
						// Yew Graveyard
						from.Map = Map.Trammel;
						
						from.Location = new Point3D(724,1139,0);
						break;
					}
				case 108: //Same as above
					{
						// Yew Crypts
						from.Map = Map.Trammel;
						from.Location = new Point3D(972,768,0);
						break;
					}
				case 109: //Same as above
					{
						// Britain Passage
						from.Map = Map.Trammel;
						from.Location = new Point3D(6032,1500,25);
						break;
					}
				case 110: //Same as above
					{
						// Covetous
						from.Map = Map.Trammel;
						from.Location = new Point3D(2499,922,0);
						break;
					}
				case 111: //Same as above
					{
						// Deceit
						from.Map = Map.Trammel;
						from.Location = new Point3D(4111,434,5);
						break;
					}
				case 112: //Same as above
					{
						// Despise
						from.Map = Map.Trammel;
						from.Location = new Point3D(1302,1081,0);
						break;
					}
				case 113: //Same as above
					{
						// Destard
						from.Map = Map.Trammel;
						from.Location = new Point3D(1176,2639,0 );
						break;
					}
				case 114: //Same as above
					{
						// Fire
						from.Map = Map.Trammel;
						from.Location = new Point3D(5761,2907,15);
						break;
					}
				case 115: //Same as above
					{
						// Hythloth
						from.Map = Map.Trammel;
						from.Location = new Point3D(4722,3825,0);
						break;
					}
				case 116: //Same as above
					{
						// Ice
						from.Map = Map.Trammel;
						from.Location = new Point3D(1999,81,5);
						break;
					}
				case 117: //Same as above
					{
						// Shame
						from.Map = Map.Trammel;
						from.Location = new Point3D(514,1561,0);
						break;
					}
				case 118: //Same as above
					{
						// Terathan Keep
						from.Map = Map.Trammel;
						from.Location = new Point3D(5499,3224,0);
						break;
					}
				case 119: //Same as above
					{
						// Trinsic Passage
						from.Map = Map.Trammel;
						
						from.Location = new Point3D(1628,3323,0);
						break;
					}
				case 120: //Same as above
					{
						// Wrong
						from.Map = Map.Trammel;
						from.Location = new Point3D(2044,238,10);
						break;
					}
					/*case 212: //Same as above
{
// Rural Chapel
from.Map = Map.Trammel;
from.Location = new Point3D(866,618,0);
break;
}
case 213: //Same as above
{
// Water Dungeon
from.Map = Map.Trammel;
from.Location = new Point3D(4425,2173,-5);
break;
}*/
				case 214: //Same as above
					{
						// Heartwood
						from.Map = Map.Felucca;
						from.Location = new Point3D(540,993,0);
						break;
					}
				case 215: //Same as above
					{
						// Blight Groves
						from.Map = Map.Felucca;
						
						from.Location = new Point3D(585,1645,-6);
						break;
					}
				case 216: //Same as above
					{
						// Palace Of Paroxysmus
						from.Map = Map.Felucca;
						from.Location = new Point3D(5608,3032,30);
						break;
					}
				case 217: //Same as above
					{
						// Prism Of Light
						from.Map = Map.Felucca;
						from.Location = new Point3D(3786,1107,20);
						break;
					}
				case 218: //Same as above
					{
						// Sanctuary
						from.Map = Map.Felucca;
						from.Location = new Point3D(791,1613,0);
						break;
					}
				case 219: //Same as above
					{
						// Heartwood
						from.Map = Map.Trammel;
						from.Location = new Point3D(540,993,0);
						break;
					}
				case 220: //Same as above
					{
						// Blight Groves
						from.Map = Map.Trammel;
						
						from.Location = new Point3D(585,1645,-6);
						break;
					}
				case 221: //Same as above
					{
						// Palace Of Paroxysmus
						from.Map = Map.Trammel;
						from.Location = new Point3D(5608,3032,30);
						break;
					}
				case 222: //Same as above
					{
						// Prism Of Light
						from.Map = Map.Trammel;
						from.Location = new Point3D(3786,1107,20);
						break;
					}
				case 223: //Same as above
					{
						// Sanctuary
						from.Map = Map.Trammel;
						from.Location = new Point3D(791,1613,0);
						break;
					}
				case 229: //Same as above
					{
						// Painted Caves
						from.Map = Map.Felucca;
						from.Location = new Point3D(1716,2992,0);
						break;
					}
				case 230: //Same as above
					{
						// Painted Caves
						from.Map = Map.Trammel;
						from.Location = new Point3D(1716,2992,0);
						break;
					}
					
					
					////// START OF ILSHENAR CASES
					
				case 121: //Same as above
					{
						// Alexandretta’s Bowl
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1395,433,-14);
						break;
					}
				case 122: //Same as above
					{
						// Ancient Citadel
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1518,568,-13);
						break;
					}
				case 123: //Same as above
					{
						// Gargoyle City
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(852,602,-40);
						break;
					}
				case 124: //Same as above
					{
						// Lakeshire
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1203,1124,-25);
						break;
						
					}
					
				case 125: //Same as above
					{
						// Mistas
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(820,1073,-30);
						break;
					}
				case 126: //Same as above
					{
						// Montor
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1643,310,48);
						break;
					}
				case 127: //Same as above
					{
						// Savage Camp
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1251,743,-80);
						break;
					}
				case 128: //Same as above
					{
						// Solitude Isle
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(857,896,-32);
						break;
					}
				case 129: //Same as above
					{
						// Terort Skitas
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(566,453,-1);
						break;
					}
				case 130: //Same as above
					{
						// Cyclops Temple
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(842,1327,-70);
						break;
					}
				case 131: //Same as above
					{
						// Blackthorn’s Castle
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1084,652,0);
						break;
					}
				case 132: //Same as above
					
					{
						// Nox Tereg
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(416,1176,0);
						break;
					}
				case 133: //Same as above
					{
						// Pormir Felwis
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(491,348,-59);
						break;
					}
				case 134: //Same as above
					{
						// Pormir Harm
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(755,496,-62);
						break;
					}
				case 135: //Same as above
					{
						// Twin Oaks
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1576,1047,-8);
						break;
					}
				case 136: //Same as above
					{
						// Ancient Lair
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(940,503,-30);
						break;
					}
				case 137: //Same as above
					{
						// Gypsy Camp
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(506,539,-60);
						break;
					}
				case 138: //Same as above
					{
						// Gypsy Camp 2
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1612,548,-15);
						break;
					}
				case 139: //Same as above
					{
						// Gypsy Camp 3
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(860,464,0);
						break;
					}
				case 140: //Same as above
					{
						// Gypsy Camp 4
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1228,544,0);
						break;
					}
				case 141: //Same as above
					{
						// Gypsy Camp 5
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1392,432,0);
						break;
					}
				case 142: //Same as above
					{
						// Chaos
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1735,269,49);
						break;
					}
				case 143: //Same as above
					{
						// Compassion
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1217,469,-13);
						break;
					}
				case 144: //Same as above
					{
						// Honesty
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(726,1339,-59);
						break;
					}
				case 145: //Same as above
					{
						// Honor
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(748,728,-29);
						break;
					}
				case 146: //Same as above
					{
						// Humility
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(287,1016,0);
						break;
					}
				case 147: //Same as above
					{
						// Justice
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(987,1007,-36);
						break;
					}
				case 148: //Same as above
					{
						// Sacrifice
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1175,1287,-30);
						break;
					}
				case 149: //Same as above
					{
						// Spirituality
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1532,1341,-3);
						break;
					}
				case 150: //Same as above
					{
						// Valor
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(527,218,-43);
						break;
					}
					
				case 151: //Same as above
					{
						// Lizard Passage
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(314,1334,-35);
						break;
					}
				case 152: //Same as above
					{
						// Mushroom Cave
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1459,1329,-24);
						break;
					}
				case 153: //Same as above
					{
						// Rat Cave
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1034,1153,-22);
						break;
					}
				case 154: //Same as above
					{
						// Rat Fort
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(642,845,-58);
						break;
					}
				case 155: //Same as above
					{
						// Spider Cave
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1421,913,-16);
						break;
					}
				case 156: //Same as above
					{
						// Ankh
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(576,1150,-100);
						break;
					}
				case 157: //Same as above
					{
						// Blood
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1747,1228,-1);
						break;
					}
				case 158: //Same as above
					{
						
						// Exodus
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(907,779,-80);
						break;
					}
				case 159: //Same as above
					{
						// Rock
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1788,573,71);
						break;
					}
				case 160: //Same as above
					{
						// Sorcerers
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(548,462,-53);
						break;
					}
				case 161: //Same as above
					{
						// Spectre
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(1363,1103,-26);
						break;
					}
				case 162: //Same as above
					{
						
						// Wisp
						from.Map = Map.Ilshenar;
						from.Location = new Point3D(651,1302,-58);
						break;
					}
					
					
					///// END OF ILSHENAR
					
					
					////  START MALAS CASES
					
					
				case 163: //Same as above
					{
						// Luna
						from.Map = Map.Malas;
						from.Location = new Point3D(991,519,-50);
						break;
					}
				case 164: //Same as above
					{
						// Umbra
						from.Map = Map.Malas;
						from.Location = new Point3D(2044,1344,-85);
						break;
					}
				case 165: //Same as above
					{
						// Arena
						from.Map = Map.Malas;
						from.Location = new Point3D(2365,1129,-90);
						break;
					}
				case 166: //Same as above
					
					
					{
						// Doom
						from.Map = Map.Malas;
						from.Location = new Point3D(2367,1268,-85);
						break;
					}
				case 167: //Same as above
					{
						// Broken Mountains
						from.Map = Map.Malas;
						from.Location = new Point3D(1111,1461,-90);
						break;
					}
				case 168: //Same as above
					{
						// Corrupted Forest
						
						
						from.Map = Map.Malas;
						from.Location = new Point3D(2172,1144,-87);
						break;
					}
				case 169: //Same as above
					{
						// Crumbling Contintent
						from.Map = Map.Malas;
						from.Location = new Point3D(736,1180,-92);
						break;
					}
				case 170: //Same as above
					{
						// Crystal Fens
						from.Map = Map.Malas;
						from.Location = new Point3D(1388,616,-85);
						break;
					}
				case 171: //Same as above
					{
						// Divide Of The Abyss
						from.Map = Map.Malas;
						from.Location = new Point3D(1545,877,-85);
						break;
					}
				case 172: //Same as above
					{
						// Dry Highlands
						from.Map = Map.Malas;
						from.Location = new Point3D(2128,1668,-90);
						break;
					}
				case 173: //Same as above
					{
						// Forgotten Pyramid
						from.Map = Map.Malas;
						from.Location = new Point3D(1852,1798,-109);
						break;
					}
				case 174: //Same as above
					{
						// Gravewater Lake
						from.Map = Map.Malas;
						from.Location = new Point3D(1618,1724,-110);
						break;
					}
				case 175: //Same as above
					{
						// Grimswind Ruins
						from.Map = Map.Malas;
						from.Location = new Point3D(2192,330,-90 );
						break;
					}
				case 176: //Same as above
					{
						// Hanse’s Hostel
						from.Map = Map.Malas;
						from.Location = new Point3D(1065,1435,-90);
						break;
					}
				case 177: //Same as above
					{
						// Orc Fortress
						from.Map = Map.Malas;
						from.Location = new Point3D(1340,1226,-90 );
						break;
					}
				case 178: //Same as above
					{
						// Orc Fort
						from.Map = Map.Malas;
						from.Location = new Point3D(912,193,-79);
						break;
					}
				case 179: //Same as above
					{
						// Orc Fort 2
						from.Map = Map.Malas;
						from.Location = new Point3D(1680,369,-50);
						break;
					}
				case 180: //Same as above
					{
						// Orc Fort 3
						from.Map = Map.Malas;
						from.Location = new Point3D(1364,599,-87);
						break;
					}
				case 181: //Same as above
					{
						// Orc Fort 4
						from.Map = Map.Malas;
						from.Location = new Point3D(1205,705,-90);
						break;
					}
				case 182: //Same as above
					{
						// Orc Fort 5
						from.Map = Map.Malas;
						from.Location = new Point3D(1257,1331,-87);
						break;
					}
				case 183: //Same as above
					{
						
						// Orc Fort 6
						from.Map = Map.Malas;
						from.Location = new Point3D(1598,1825,-110);
						break;
					}
				case 184: //Same as above
					{
						// Mine
						from.Map = Map.Malas;
						from.Location = new Point3D(2102,558,-90);
						break;
					}
				case 185: //Same as above
					{
						// Mine 2
						from.Map = Map.Malas;
						from.Location = new Point3D(2157,459,-90);
						break;
					}
					
					
				case 186: //Same as above
					{
						// Mine 3
						from.Map = Map.Malas;
						from.Location = new Point3D(1811,365,-90);
						break;
					}
				case 187: //Same as above
					{
						// Mine 4
						from.Map = Map.Malas;
						from.Location = new Point3D(1793,472,-90);
						break;
					}
				case 188: //Same as above
					{
						// Mine 5
						from.Map = Map.Malas;
						from.Location = new Point3D(1629,430,-85);
						break;
					}
				case 189: //Same as above
					{
						// Mine 6
						from.Map = Map.Malas;
						from.Location = new Point3D(1658,308,-85);
						break;
					}
				case 190: //Same as above
					{
						// Mine 7
						from.Map = Map.Malas;
						from.Location = new Point3D(1073,244,-90);
						break;
					}
				case 191: //Same as above
					{
						//  Mine 8
						from.Map = Map.Malas;
						from.Location = new Point3D(1095,205,-90);
						break;
					}
				case 192: //Same as above
					{
						//  Mine 9
						from.Map = Map.Malas;
						from.Location = new Point3D(1195,509,-90);
						break;
					}
				case 193: //Same as above
					{
						// Zento
						from.Map = Map.Maps[4];
						from.Location = new Point3D(711,1322,25);
						break;
					}
				case 194: //Same as above
					{
						// Compassion
						from.Map = Map.Maps[4];
						from.Location = new Point3D(746,1179,25);
						break;
					}
				case 195: //Same as above
					{
						// Spirituality
						
						from.Map = Map.Maps[4];
						from.Location = new Point3D(288,712,55);
						break;
					}
				case 196: //Same as above
					{
						// Valor
						from.Map = Map.Maps[4];
						from.Location = new Point3D(1042,512,15);
						break;
					}
				case 197: //Same as above
					{
						// Bushido Dojo
						from.Map = Map.Maps[4];
						from.Location = new Point3D(312,452,32);
						break;
					}
				case 198: //Same as above
					{
						// Fan Dancer’s Dojo
						from.Map = Map.Maps[4];
						from.Location = new Point3D(977,231,23);
						break;
					}
				case 199: //Same as above
					{
						// Ninja’s Enclave
						from.Map = Map.Maps[4];
						from.Location = new Point3D(1229,781,8);
						break;
					}
				case 200: //Same as above
					{
						// Crane Marsh
						from.Map = Map.Maps[4];
						from.Location = new Point3D(243,1100,10 );
						break;
					}
				case 201: //Same as above
					{
						// Defiance Point
						from.Map = Map.Maps[4];
						from.Location = new Point3D(317,1207,10);
						break;
					}
				case 202: //Same as above
					{
						// Field Of Echos
						from.Map = Map.Maps[4];
						from.Location = new Point3D(168,634,41 );
						break;
					}
				case 203: //Same as above
					{
						// Kisume Woods
						from.Map = Map.Maps[4];
						from.Location = new Point3D(516,499,32);
						break;
					}
				case 204: //Same as above
					{
						
						// Lotus Lakes
						from.Map = Map.Maps[4];
						from.Location = new Point3D(1064,838,31);
						break;
					}
				case 205: //Same as above
					{
						// Mt Sho
						from.Map = Map.Maps[4];
						from.Location = new Point3D(1128,713,88);
						break;
					}
				case 206: //Same as above
					{
						// Phoenix Mountains
						from.Map = Map.Maps[4];
						from.Location = new Point3D(726,1088,38);
						break;
					}
				case 207: //Same as above
					{
						// Storm Point
						from.Map = Map.Maps[4];
						from.Location = new Point3D(1161,1030,24);
						break;
					}
				case 208: //Same as above
					{
						// Valley Of The Sleeping Dragons
						from.Map = Map.Maps[4];
						from.Location = new Point3D(926,435,11);
						break;
					}
				case 209: //Same as above
					{
						// Wasteland
						from.Map = Map.Maps[4];
						from.Location = new Point3D(728,1045,31);
						break;
					}
				case 210: //Same as above
					{
						// Winter Spur
						from.Map = Map.Maps[4];
						from.Location = new Point3D(929,193,18);
						break;
					}
				case 211: //Same as above
					{
						// Yomotsu Mines
						from.Map = Map.Maps[4];
						from.Location = new Point3D(225,788,64);
						break;
					}
				case 224: //Same as above
					{
						// Bedlam
						from.Map = Map.Malas;
						from.Location = new Point3D(2079,1375,-70);
						break;
					}
				case 225: //Same as above
					{
						// Isle Divide
						from.Map = Map.Malas;
						from.Location = new Point3D(1728,1160,-90);
						break;
					}
				case 226: //Same as above
					{
						// Labrynth
						from.Map = Map.Malas;
						from.Location = new Point3D(1732,979,-80);
						break;
					}
				case 227: //Same as above
					{
						// Citadel
						from.Map = Map.Maps[4];
						from.Location = new Point3D(1346,770,19);
						break;
					}
				case 228: //Same as above
					{
						// Sakuto
						from.Map = Map.Malas;
						from.Location = new Point3D(382,741,-1);
						break;
					}
					
					
					///// END OF MALAS
			}
		}
	}
	
}
