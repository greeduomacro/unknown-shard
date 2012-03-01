using System; 
using Server; 
using Server.Gumps; 
using Server.Network; 
using Server.Commands;

namespace Server.Gumps 
{ 
public class SETravelingWandGump : Gump 
{ 
public static void Initialize() 
{ 
CommandSystem.Register( "SETravelingWandGump", AccessLevel.GameMaster, new CommandEventHandler( SETravelingWandGump_OnCommand ) ); 
} 

private static void SETravelingWandGump_OnCommand( CommandEventArgs e ) 
{ 
e.Mobile.SendGump( new SETravelingWandGump( e.Mobile ) ); 
} 

public SETravelingWandGump( Mobile owner ) : base( 50,50 ) 
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
AddHtml( 20, 20, 460, 27,"Trammel Cities- Select one of these 17 options!", true, false ); 
AddLabel( 180, 275, 32, "Felucca Cities" ); 

AddHtml( 345, 60, 140, 225,"From rambling, secluded villages to the polished stone towers of Lord British’s Castle, the cities and villages of Britannia provide much for the citizens. In the north lie trade centers and the rugged towns of the workingman. To the east, scholars toil in pursuit of the magic of the realm. Within cities throughout the land, however, one finds the adventurous citizens of Britannia, plying wares, searching for adventure or merely sipping ale with friends. ", true, true ); 


AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 2 ); 

AddButton( 35, 63, 0x2623, 0x2622, 1, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 60, 0x34, "Britain" ); 

AddButton( 35, 93, 0x2623, 0x2622, 2, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 90, 0x34, "Buc's Den" ); 

AddButton( 35, 123, 0x2623, 0x2622, 3, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 120, 0x34, "Cove" ); 

AddButton( 35, 153, 0x2623, 0x2622, 4, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 150, 0x34, "Haven" ); 

AddButton( 35, 183, 0x2623, 0x2622, 5, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 180, 0x34, "Jhelom" ); 

AddButton( 35, 213, 0x2623, 0x2622, 6, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 210, 0x34, "Magincia" ); 

AddButton( 35, 243, 0x2623, 0x2622, 7, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 240, 0x34, "Minoc" ); 

AddButton( 135, 63, 0x2623, 0x2622, 8, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 60, 0x34, "Moonglow" ); 

AddButton( 135, 93, 0x2623, 0x2622, 9, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 90, 0x34, "Nujel'm" ); 

AddButton( 135, 123, 0x2623, 0x2622, 10, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 120, 0x34, "Serp Hold" ); 

AddButton( 135, 153, 0x2623, 0x2622, 11, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 150, 0x34, "Skara Brae" ); 

AddButton( 135, 183, 0x2623, 0x2622, 12, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 180, 0x34, "Trinsic" ); 

AddButton( 135, 213, 0x2623, 0x2622, 13, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 210, 0x34, "Vesper" ); 

AddButton( 135, 243, 0x2623, 0x2622, 14, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 240, 0x34, "Wind" ); 

AddButton( 235, 63,0x2623, 0x2622, 15, GumpButtonType.Reply, 0 ); 
AddLabel( 255, 60, 0x34, "Yew" ); 

AddButton( 235, 93, 0x2623, 0x2622, 16, GumpButtonType.Reply, 0 ); 
AddLabel( 255, 90, 0x34, "Delucia" ); 

AddButton( 235, 123, 0x2623, 0x2622, 17, GumpButtonType.Reply, 0 ); 
AddLabel( 255, 120, 0x34, "Papua" ); 


//// START PAGE 2

AddPage( 2 ); 
AddHtml( 20, 20, 460, 27,"Felucca Cities- Select one of these 17 options!", true, false ); 
AddLabel( 65, 275, 0x34, "Trammel Cities" ); 
AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 1 ); 

AddLabel( 180, 275, 1161, "Land of Malas" ); 
AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 3 ); 

AddHtml( 345, 60, 140, 225,"Citizens beware!  Felucca has been taken over by evil.  Life grows scarcely in this land.  Even though you may think as your friend, can stab you in the back here when you least expect.  Consider yourself warned!", true, true ); 

AddButton( 35, 63, 0x2623, 0x2622, 18, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 60, 32, "Britain" ); 

AddButton( 35, 93, 0x2623, 0x2622, 19, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 90, 32, "Buc's Den" ); 

AddButton( 35, 123, 0x2623, 0x2622, 20, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 120, 32, "Cove" ); 

AddButton( 35, 153, 0x2623, 0x2622, 21, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 150, 32, "Jhelom" ); 

AddButton( 35, 183, 0x2623, 0x2622, 22, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 180, 32, "Magincia" ); 

AddButton( 35, 213, 0x2623, 0x2622, 23, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 210, 32, "Minoc" ); 

AddButton( 35, 243, 0x2623, 0x2622, 24, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 240, 32, "Moonglow" ); 

AddButton( 135, 63, 0x2623, 0x2622, 25, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 60, 32, "Nujel'm" ); 

AddButton( 135, 93, 0x2623, 0x2622, 26, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 90, 32, "Ocllo" ); 

AddButton( 135, 123, 0x2623, 0x2622, 27, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 120, 32, "Serp Hold" ); 

AddButton( 135, 153, 0x2623, 0x2622, 28, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 150, 32, "Skara Brae" ); 

AddButton( 135, 183, 0x2623, 0x2622, 29, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 180, 32, "Trinsic" ); 

AddButton( 135, 213, 0x2623, 0x2622, 30, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 210, 32, "Vesper" ); 

AddButton( 135, 243, 0x2623, 0x2622, 31, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 240, 32, "Wind" ); 

AddButton( 235, 63,0x2623, 0x2622, 32, GumpButtonType.Reply, 0 ); 
AddLabel( 255, 60, 32, "Yew" ); 

AddButton( 235, 93, 0x2623, 0x2622, 33, GumpButtonType.Reply, 0 ); 
AddLabel( 255, 90, 32, "Delucia" ); 

AddButton( 235, 123, 0x2623, 0x2622, 34, GumpButtonType.Reply, 0 ); 
AddLabel( 255, 120, 32, "Papua" );
 

///// END PAGE 2


//// START PAGE 3

AddPage( 3 ); 
AddHtml( 20, 20, 460, 27,"Land of Malas - Select one of these 12 options!", true, false ); 

AddHtml( 345, 60, 140, 225,"Floating within a dark sea of stars, Malas is a broken facet, wracked by great tremors that constantly threaten the stability of its continents. Its origin is a mystery, and its future inscrutable, but what is known is that this facet is unlike any other. Three great sections of land - one of which is already in the process of crumbling into smaller islands - are connected by bridges, and in between them lays a vast abyss of nothingness. And yet, despite this unstable environment, life has flourished in the Dark Facet; creatures of all types call Malas home, and even humans have forged lives there.", true, true ); 

AddLabel( 65, 275, 32, "Felucca Cities" ); 
AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 2 ); 

AddLabel( 180, 275, 59, "Land of Ilshenar" ); 
AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 4 ); 

AddButton( 35, 63, 0x2623, 0x2622, 35, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 60, 1161, "Luna" ); 

AddButton( 35, 93, 0x2623, 0x2622, 36, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 90, 1161, "Umbra" ); 

AddButton( 35, 123, 0x2623, 0x2622, 37, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 120, 1161, "Doom" ); 

AddButton( 35, 153, 0x2623, 0x2622, 38, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 150, 1161, "Orc Fort" ); 

AddButton( 35, 183, 0x2623, 0x2622, 39, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 180, 1161, "Crystal Fens" ); 

AddButton( 35, 213, 0x2623, 0x2622, 40, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 210, 1161, "Corrupted Forest" ); 

AddButton( 35, 243, 0x2623, 0x2622, 41, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 240, 1161, "Crumbling Mountains" ); 

AddButton( 135, 63, 0x2623, 0x2622, 42, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 60, 1161, "Broken Mountains" ); 

AddButton( 135, 153, 0x2623, 0x2622, 43, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 150, 1161, "Dry Highlands" ); 

AddButton( 135, 93, 0x2623, 0x2622, 44, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 90, 1161, "Forgotten Pyramid" ); 

AddButton( 135, 123, 0x2623, 0x2622, 45, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 120, 1161, "Grimswind Ruins" );

AddButton( 135, 183, 0x2623, 0x2622, 46, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 180, 1161, "Northern Crags" );

///// END PAGE 3


//// START PAGE 4

AddPage( 4 ); 
AddHtml( 20, 20, 460, 27," Land of Ilshenar - Select one of these 12 options!", true, false ); 

AddHtml( 345, 60, 140, 225,"Very little is known regarding this new wilderness except that many of its creatures are quite magical in nature. Ilshenar, much like Felucca, protects players from being attacked or stolen from by other players.", true, true ); 

AddLabel( 65, 275, 1161, "Land of Malas" ); 
AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 3 ); 

AddLabel( 180, 275, 0x34, "Trammel Dungeons" ); 
AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 5 ); 

AddButton( 35, 63, 0x2623, 0x2622, 47, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 60, 59, "Garg City" ); 

AddButton( 35, 93, 0x2623, 0x2622, 48, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 90, 59, "LakeShire" ); 

AddButton( 35, 123, 0x2623, 0x2622, 49, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 120, 59, "Mistas" ); 

AddButton( 35, 153, 0x2623, 0x2622, 50, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 150, 59, "Montor" ); 

AddButton( 35, 183, 0x2623, 0x2622, 51, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 180, 59, "Req Volon" ); 

AddButton( 35, 213, 0x2623, 0x2622, 52, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 210, 59, "Ancient Citadel" ); 

AddButton( 35, 243, 0x2623, 0x2622, 53, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 240, 59, "Savage Camp" ); 

AddButton( 135, 63, 0x2623, 0x2622, 54, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 60, 59, "Terort Skitas" ); 

AddButton( 135, 123, 0x2623, 0x2622, 55, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 120, 59, "Cyclops Dungeon" ); 

AddButton( 135, 93, 0x2623, 0x2622, 56, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 90, 59, "Ratman Mine" ); 

AddButton( 135, 183, 0x2623, 0x2622, 57, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 180, 59, "Spider Dungeon" ); 

AddButton( 135, 153, 0x2623, 0x2622, 58, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 150, 59, "Wisp Dungeon" ); 


///// END PAGE 4


//// START PAGE 5

AddPage( 5 );
AddHtml( 20, 20, 460, 27,"Trammel Dungeons - Select one of these 11 options!", true, false ); 

AddHtml( 345, 60, 140, 225,"Dungeons are dangerous places where you can seek gold and glory, some might even contain powerful champions for you to slay. If your new and your skills untrained you should pick an easy dungeon such as Covetous.", true, true ); 

AddLabel( 65, 275, 59, "Land of Ilshenar" ); 
AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 4 ); 

AddLabel( 180, 275, 32, "Felucca Dungeons" ); 
AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 6 ); 

AddButton( 35, 63, 0x2623, 0x2622, 59, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 60, 0x34, "Covetous" ); 

AddButton( 35, 93, 0x2623, 0x2622, 60, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 90, 0x34, "Deceit" ); 

AddButton( 35, 123, 0x2623, 0x2622, 61, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 120, 0x34, "Despise" ); 

AddButton( 35, 153, 0x2623, 0x2622, 62, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 150, 0x34, "Destard" ); 

AddButton( 35, 183, 0x2623, 0x2622, 63, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 180, 0x34, "Hythloth" ); 

AddButton( 35, 213, 0x2623, 0x2622, 64, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 210, 0x34, "Shame" ); 

AddButton( 35, 243, 0x2623, 0x2622, 65, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 240, 0x34, "Wrong" ); 

AddButton( 135, 63, 0x2623, 0x2622, 66, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 60, 0x34, "Orc Cave" ); 

AddButton( 135, 93, 0x2623, 0x2622, 67, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 90, 0x34, "Fire" ); 

AddButton( 135, 123, 0x2623, 0x2622, 68, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 120, 0x34, "Ice" ); 

AddButton( 135, 153, 0x2623, 0x2622, 69, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 150, 0x34, "Terathan Keep" );

///// END PAGE 5


//// START PAGE 6

AddPage( 6 );
AddHtml( 20, 20, 460, 27,"Felucca Dungeons - Select one of these 12 options!", true, false ); 

AddHtml( 345, 60, 140, 225,"Dungeons are dangerous places where you can seek gold and glory, some might even contain powerful champions for you to slay. If your new and your skills untrained you should pick an easy dungeon such as Covetous.", true, true ); 

AddLabel( 65, 275, 0x34, "Trammel Dungeons" ); 
AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 5 );

AddLabel( 180, 275, 118, "Tokuno" ); 
AddButton( 285, 260, 0x1196, 0x1196, 2, GumpButtonType.Page, 7 ); 

AddButton( 35, 63, 0x2623, 0x2622, 70, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 60, 32, "Covetous" ); 

AddButton( 35, 93, 0x2623, 0x2622, 71, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 90, 32, "Deceit" ); 

AddButton( 35, 123, 0x2623, 0x2622, 72, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 120, 32, "Despise" ); 

AddButton( 35, 153, 0x2623, 0x2622, 73, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 150, 32, "Destard" ); 

AddButton( 35, 183, 0x2623, 0x2622, 74, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 180, 32, "Hythloth" ); 

AddButton( 35, 213, 0x2623, 0x2622, 75, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 210, 32, "Shame" ); 

AddButton( 35, 243, 0x2623, 0x2622, 76, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 240, 32, "Wrong" ); 

AddButton( 135, 63, 0x2623, 0x2622, 77, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 60, 32, "Orc Cave" ); 

AddButton( 135, 93, 0x2623, 0x2622, 78, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 90, 32, "Fire" ); 

AddButton( 135, 123, 0x2623, 0x2622, 79, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 120, 32, "Ice" ); 

AddButton( 135, 153, 0x2623, 0x2622, 80, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 150, 32, "Terathan Keep" );

AddButton( 135, 183, 0x2623, 0x2622, 81, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 180, 32, "Khaldun" );

///// END PAGE 6

//// START PAGE 7

AddPage( 7 );
AddHtml( 20, 20, 460, 27,"Tokuno - Select one of these 14 options!", true, false ); 

AddHtml( 345, 60, 140, 225,"The Lost Islands of Tokuno have recently been found. Much of the information about these islands is unknown. Discover new adventures here on the Islands.", true, true ); 

AddLabel( 65, 275, 32, "Felucca Dungeons" ); 
AddButton( 10, 260, 0x119a, 0x119a, 1, GumpButtonType.Page, 6 );

AddButton( 35, 63, 0x2623, 0x2622, 82, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 60, 118, "Zento" ); 

AddButton( 35, 93, 0x2623, 0x2622, 83, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 90, 118, "The Waste" ); 

AddButton( 35, 123, 0x2623, 0x2622, 84, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 120, 118, "Isamu-Jima" ); 

AddButton( 35, 153, 0x2623, 0x2622, 85, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 150, 118, "Lotus Lakes" ); 

AddButton( 35, 183, 0x2623, 0x2622, 86, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 180, 118, "Mount Sho" ); 

AddButton( 35, 213, 0x2623, 0x2622, 87, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 210, 118, "Winter Spur" ); 

AddButton( 35, 243, 0x2623, 0x2622, 88, GumpButtonType.Reply, 0 ); 
AddLabel( 55, 240, 118, "Crane Marsh" ); 

AddButton( 135, 63, 0x2623, 0x2622, 89, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 60, 118, "Homare-Jima" ); 

AddButton( 135, 93, 0x2623, 0x2622, 90, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 90, 118, "Bushido Dojo" ); 

AddButton( 135, 123, 0x2623, 0x2622, 91, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 120, 118, "Kitsune Woods" ); 

AddButton( 135, 153, 0x2623, 0x2622, 92, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 150, 118, "Field of Echoes" );

AddButton( 135, 183, 0x2623, 0x2622, 93, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 180, 118, "Yomotsu Mines" );

AddButton( 135, 213, 0x2623, 0x2622, 94, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 210, 118, "Dragon Valley" );

AddButton( 135, 243, 0x2623, 0x2622, 95, GumpButtonType.Reply, 0 ); 
AddLabel( 155, 240, 118, "Fan Dancer Dojo" );

////END PAGE 7

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

//START TRAMMEL CITY CASES

case 1: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
{ 
//Britain 
from.Map = Map.Trammel;
from.Location = new Point3D(1433,1698,0); 
break; 
} 
case 2: //Same as above 
{ 
//Buc's Den 
from.Map = Map.Trammel;
from.Location = new Point3D(2725,2193,0); 
break; 
} 
case 3: 
{ 
//Cove 
from.Map = Map.Trammel;
from.Location = new Point3D(2235,1198,0); 
break; 
} 
case 4: 
{ 
//Haven 
from.Map = Map.Trammel;
from.Location = new Point3D(3630,2610,0); 
break; 
} 
case 5: 
{ 
//Jhelom 
from.Map = Map.Trammel;
from.Location = new Point3D(1325,3780,0); 
break; 
} 

case 6: 
{ 
//Magincia 
from.Map = Map.Trammel;
from.Location = new Point3D(3730,2163,20); 
break; 
} 
case 7: 
{ 
//Minoc 
from.Map = Map.Trammel;
from.Location = new Point3D(2503,563,0); 
break; 
} 
case 8: 
{ 
//Moonglow 
from.Map = Map.Trammel;
from.Location = new Point3D(4471,1178,0); 
break; 
} 
case 9: 
{ 
//Nujel'm 
from.Map = Map.Trammel;
from.Location = new Point3D(3771,1315,0); 
break; 
} 
case 10: 
{ 
//Serp hold 
from.Map = Map.Trammel;
from.Location = new Point3D(2894,3475,15); 
break; 
} 
case 11: 
{ 
//Skara Brae 
from.Map = Map.Trammel;
from.Location = new Point3D(597,2156,0); 
break; 
} 
case 12: 
{ 
//Trinsic 
from.Map = Map.Trammel;
from.Location = new Point3D(1909,2687,0); 
break; 
} 

case 13: 
{ 
//Vesper
from.Map = Map.Trammel;
from.Location = new Point3D(2900,675,0); 
break; 
} 
case 14: 
{ 
//Wind 
from.Map = Map.Trammel;
from.Location = new Point3D(5344,92,15); 
break; 
} 
case 15: 
{ 
//Yew 
from.Map = Map.Trammel;
from.Location = new Point3D(659,814,0); 
break; 
} 
case 16: 
{ 
//Delucia 
from.Map = Map.Trammel;
from.Location = new Point3D(5272,3993,37 ); 
break; 
} 
case 17: 
{ 
//Papua 
from.Map = Map.Trammel;
from.Location = new Point3D(5675,3143,12); 
break; 
} 

//END TRAMMEL CITY CASES

//START FELUCCA CITY CASES

case 18:
{ 
//Britain 
from.Map = Map.Felucca;
from.Location = new Point3D(1433,1698,0); 
break; 
} 
case 19:
{ 
//Buc's Den 
from.Map = Map.Felucca;
from.Location = new Point3D(2725,2193,0); 
break; 
} 
case 20: 
{ 
//Cove 
from.Map = Map.Felucca;
from.Location = new Point3D(2235,1198,0); 
break; 
} 
case 21: 
{ 
//Jhelom 
from.Map = Map.Felucca;
from.Location = new Point3D(1325,3780,0); 
break; 
} 

case 22: 
{ 
//Magincia 
from.Map = Map.Felucca;
from.Location = new Point3D(3730,2163,20); 
break; 
} 
case 23: 
{ 
//Minoc 
from.Map = Map.Felucca;
from.Location = new Point3D(2503,563,0); 
break; 
} 
case 24: 
{ 
//Moonglow 
from.Map = Map.Felucca;
from.Location = new Point3D(4471,1178,0); 
break; 
} 
case 25: 
{ 
//Nujel'm 
from.Map = Map.Felucca;
from.Location = new Point3D(3771,1315,0); 
break; 
} 
case 26: 
{ 
//Ocllo 
from.Map = Map.Felucca;
from.Location = new Point3D(3691,2523,0); 
break; 
} 
case 27: 
{ 
//Serp hold 
from.Map = Map.Felucca;
from.Location = new Point3D(2894,3475,15); 
break; 
} 
case 28: 
{ 
//Skara Brae 
from.Map = Map.Felucca;
from.Location = new Point3D(597,2156,0); 
break; 
} 
case 29: 
{ 
//Trinsic 
from.Map = Map.Felucca;
from.Location = new Point3D(1909,2687,0); 
break; 
} 

case 30: 
{ 
//Vesper
from.Map = Map.Felucca;
from.Location = new Point3D(2900,675,0); 
break; 
} 
case 31: 
{ 
//Wind 
from.Map = Map.Felucca;
from.Location = new Point3D(5344,92,15); 
break; 
} 
case 32: 
{ 
//Yew 
from.Map = Map.Felucca;
from.Location = new Point3D(659,814,0); 
break; 
} 
case 33: 
{ 
//Delucia 
from.Map = Map.Felucca;
from.Location = new Point3D(5272,3993,37 ); 
break; 
} 
case 34: 
{ 
//Papua 
from.Map = Map.Felucca;
from.Location = new Point3D(5675,3143,12); 
break; 
}

//END FELUCCA CITY CASES

//START MALAS CASES

case 35: 
{ 
//Luna
from.Map = Map.Malas;
from.Location = new Point3D(981,520,-50); 
break; 
} 
case 36: 
{ 
//Umbra
from.Map = Map.Malas;
from.Location = new Point3D(2058,1343,-85); 
break; 
} 
case 37: 
{ 
//Doom
from.Map = Map.Malas;
from.Location = new Point3D(2367,1268,-85); 
break; 
} 
case 38: 
{ 
//Orc Fort
from.Map = Map.Malas;
from.Location = new Point3D(1342,1260,-90); 
break; 
} 
case 39: 
{ 
//Crystal Fens
from.Map = Map.Malas;
from.Location = new Point3D(1408,610,-87); 
break; 
} 
case 40: 
{ 
//Corrupted Forest
from.Map = Map.Malas;
from.Location = new Point3D(2176,1141,-87); 
break; 
} 
case 41: 
{ 
//Crumbling Mountains
from.Map = Map.Malas;
from.Location = new Point3D(712,1212,-90); 
break; 
} 
case 42: 
{ 
//Broken Mountains
from.Map = Map.Malas;
from.Location = new Point3D(1106,1462,-90); 
break; 
} 
case 43: 
{ 
//Dry Highlands
from.Map = Map.Malas;
from.Location = new Point3D(2128,1668,-90); 
break; 
} 
case 44: 
{ 
//Forgotten Pyramid
from.Map = Map.Malas;
from.Location = new Point3D(1824,1786,-110); 
break; 
} 
case 45: 
{ 
//Grimswind Ruins
from.Map = Map.Malas;
from.Location = new Point3D(2192,340,-90); 
break; 
} 
case 46: 
{ 
//Northern Crags
from.Map = Map.Malas;
from.Location = new Point3D(1580,387,-50); 
break; 
} 

//END MALAS CASES

//START ILSHENAR CASES

case 47: 
{ 
//Garg City
from.Map = Map.Ilshenar;
from.Location = new Point3D(836,641,-20); 
break; 
} 
case 48: 
{ 
//LakeShire
from.Map = Map.Ilshenar;
from.Location = new Point3D(1203,1124,-25); 
break; 
} 
case 49: 
{ 
//Mistas
from.Map = Map.Ilshenar;
from.Location = new Point3D(820,1073,-30); 
break; 
} 
case 50: 
{ 
//Montor
from.Map = Map.Ilshenar;
from.Location = new Point3D(1643,310,48); 
break; 
} 
case 51: 
{ 
//Req Volon
from.Map = Map.Ilshenar;
from.Location = new Point3D(1362,1073,-13); 
break; 
} 
case 52: 
{ 
//Ancient Citadel
from.Map = Map.Ilshenar;
from.Location = new Point3D(1518,568,-14); 
break; 
} 
case 53: 
{ 
//Savage Camp
from.Map = Map.Ilshenar;
from.Location = new Point3D(1188,692,-80); 
break; 
} 
case 54: 
{ 
//Terort Skitas
from.Map = Map.Ilshenar;
from.Location = new Point3D(567,439,21); 
break; 
} 
case 55: 
{ 
//Cyclops Dungeon
from.Map = Map.Ilshenar;
from.Location = new Point3D(863,1304,-71); 
break; 
} 
case 56: 
{ 
//Ratman Mine
from.Map = Map.Ilshenar;
from.Location = new Point3D(1034,1153,-23); 
break; 
} 
case 57: 
{ 
//Spider Dungeon
from.Map = Map.Ilshenar;
from.Location = new Point3D(1420,913,-16); 
break; 
} 
case 58: 
{ 
//Wisp Dungeon
from.Map = Map.Ilshenar;
from.Location = new Point3D(651,1304,-59); 
break; 
} 

//END ILSHENAR CASES

//BEGIN TRAMMEL DUNGEON CASES

case 59: 
{ 
//Covetous 
from.Map = Map.Trammel;
from.Location = new Point3D(2499,922,0); 
break; 
} 
case 60: 
{ 
//Deceit 
from.Map = Map.Trammel;
from.Location = new Point3D(4111,434,5); 
break; 
} 
case 61: 
{ 
//Despise 
from.Map = Map.Trammel;
from.Location = new Point3D(1301,1080,0); 
break; 
} 
case 62: 
{ 
//Destard 
from.Map = Map.Trammel;
from.Location = new Point3D(1176,2639,0); 
break; 
} 
case 63: 
{ 
//Hythloth 
from.Map = Map.Trammel;
from.Location = new Point3D(4722,3824,0); 
break; 
} 
case 64: 
{ 
//Shame 
from.Map = Map.Trammel;
from.Location = new Point3D(512,1565,0); 
break; 
} 
case 65: 
{ 
//Wrong 
from.Map = Map.Trammel;
from.Location = new Point3D(2044,238,10); 
break; 
} 
case 66: 
{ 
//Orc Cave 
from.Map = Map.Trammel;
from.Location = new Point3D(1016,1433,0); 
break; 
} 
case 67: 
{ 
//Fire 
from.Map = Map.Trammel;
from.Location = new Point3D(5760,2908,15); 
break; 
} 
case 68: 
{ 
//Ice
from.Map = Map.Trammel;
from.Location = new Point3D(1999,81,4); 
break; 
} 
case 69: 
{ 
//Terathan Keep
from.Map = Map.Trammel;
from.Location = new Point3D(5499,3224,0); 
break; 
} 

//END TRAMMEL DUNGEON CASES

//BEGIN FELUCCA DUNGEON CASES

case 70: 
{ 
//Covetous 
from.Map = Map.Felucca;
from.Location = new Point3D(2499,922,0); 
break; 
} 
case 71: 
{ 
//Deceit 
from.Map = Map.Felucca;
from.Location = new Point3D(4111,434,5); 
break; 
} 
case 72: 
{ 
//Despise 
from.Map = Map.Felucca;
from.Location = new Point3D(1301,1080,0); 
break; 
} 
case 73: 
{ 
//Destard 
from.Map = Map.Felucca;
from.Location = new Point3D(1176,2639,0); 
break; 
} 
case 74: 
{ 
//Hythloth 
from.Map = Map.Felucca;
from.Location = new Point3D(4722,3824,0); 
break; 
} 
case 75: 
{ 
//Shame 
from.Map = Map.Felucca;
from.Location = new Point3D(512,1565,0); 
break; 
} 
case 76: 
{ 
//Wrong 
from.Map = Map.Felucca;
from.Location = new Point3D(2044,238,10); 
break; 
} 
case 77: 
{ 
//Orc Cave 
from.Map = Map.Felucca;
from.Location = new Point3D(1016,1433,0); 
break; 
} 
case 78: 
{ 
//Fire 
from.Map = Map.Felucca;
from.Location = new Point3D(5760,2908,15); 
break; 
} 
case 79: 
{ 
//Ice
from.Map = Map.Felucca;
from.Location = new Point3D(1999,81,4); 
break; 
} 
case 80: 
{ 
//Terathan Keep
from.Map = Map.Felucca;
from.Location = new Point3D(5499,3224,0); 
break; 
}
case 81: 
{ 
//Khaldun
from.Map = Map.Felucca;
from.Location = new Point3D(6013,3775,21); 
break; 
}

//END FELUCCA DUNGEON CASES

//START TOKUNO CASES

case 82: 
{ 
//Zento 
from.Map = Map.Tokuno;
from.Location = new Point3D(739,1257,30); 
break; 
} 
case 83: 
{ 
//The Waste 
from.Map = Map.Tokuno;
from.Location = new Point3D(728,952,39); 
break; 
} 
case 84: 
{ 
//Isamu-Jima 
from.Map = Map.Tokuno;
from.Location = new Point3D(1165,1002,37); 
break; 
} 
case 85: 
{ 
//Lotus Lakes 
from.Map = Map.Tokuno;
from.Location = new Point3D(1066,817,20); 
break; 
} 
case 86: 
{ 
//Mount Sho 
from.Map = Map.Tokuno;
from.Location = new Point3D(1131,710,87); 
break; 
} 
case 87: 
{ 
//Winter Spur 
from.Map = Map.Tokuno;
from.Location = new Point3D(926,139,49); 
break; 
} 
case 88: 
{ 
//Crane Marsh 
from.Map = Map.Tokuno;
from.Location = new Point3D(232,1107,10); 
break; 
} 
case 89: 
{ 
//Homare-Jima 
from.Map = Map.Tokuno;
from.Location = new Point3D(266,624,14); 
break; 
} 
case 90: 
{ 
//Bushido Dojo 
from.Map = Map.Tokuno;
from.Location = new Point3D(326,407,32); 
break; 
} 
case 91: 
{ 
//Kitsune Woods
from.Map = Map.Tokuno;
from.Location = new Point3D(521,523,32); 
break; 
} 
case 92: 
{ 
//Field of Echoes
from.Map = Map.Tokuno;
from.Location = new Point3D(164,654,35); 
break; 
}
case 93: 
{ 
//Yomotsu Mines
from.Map = Map.Tokuno;
from.Location = new Point3D(258,787,64); 
break; 
}
case 94: 
{ 
//Dragon Valley
from.Map = Map.Tokuno;
from.Location = new Point3D(948,432,8); 
break; 
}
case 95: 
{ 
//Fan Dancer Dojo
from.Map = Map.Tokuno;
from.Location = new Point3D(977,206,24); 
break; 
}

//END TOKUNO CASES

} 
} 
} 
}
