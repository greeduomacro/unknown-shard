using System;
using Server;

namespace Server.Items
{
	// books: Brown 0xFEF, Tan 0xFF0, Red 0xFF1, Blue 0xFF2, 
	// OpenSmall 0xFF3, Open 0xFF4, OpenOld 0xFBD, 0xFBE

	public class ArgyleBook: BaseBook
	{
		private const string TITLE = "Argyle's Book of Information";
		private const string AUTHOR = "Argyle, the Wandering Mage";
		private const int PAGES = 16;
		private const bool WRITABLE = false;
		
		[Constructable]
		public ArgyleBook() : base( Utility.RandomList( 0xFEF, 0xFF0, 0xFF1, 0xFF2 ), TITLE, AUTHOR, PAGES, WRITABLE )
		{
			// NOTE: There are 8 lines per page and
			// approx 22 to 24 characters per line.
			    //  0----+----1----+----2----+
			int cnt = 0;
			string[] lines;

			lines = new string[]
			{
				"TRAMMEL BANK RUNES", 
				"",
                                "1 Britain",
				"2 Buccaneer's Den",
                                "3 Cove",
				"4 Haven", 
                                "5 Jhelom",
				"6 Magincia",
				

			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"7 Minoc", 
				"8 Moonglow",
                                "9 Nujel'm",
				"10 Serpent's Hold",
                                "11 Skara Brae",
				"12 Trinsic", 
                                "13 Vesper",
				"14 Wind",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"15 Yew", 
				"16 Delucia",
                                "17 Papua",
				"",
                                "",
				"", 
                                "",
				"",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"FELUCCA BANK RUNES", 
				"",
                                "18 Britain",
				"19 Buccaneer's Den",
                                "20 Cove",
				"21 Jhelom", 
                                "22 Magincia",
				"23 Minoc",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"24 Moonglow",
                                "25 Nujel'm",
				"26 Ocllo",
				"27 Serpent's Hold",
                                "28 Skara Brae",
				"29 Trinsic", 
                                "30 Vesper",
				"31 Wind",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"32 Yew", 
				"33 Delucia",
                                "34 Papua",
				"",
                                "",
				"", 
                                "",
				"",
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"MALAS RUNES", 
				"",
                                "35 Luna",
				"36 Umbra",
                                "37 Doom",
				"38 Orc Fort", 
                                "39 Crystal Fens",
				"40 Corrupted Forest",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"41 Crumbling Mountains",
                                "42 Broken Mountains",
				"43 Dry Highlands",
				"44 Forgotten Pyramid",
                                "45 Grimswind Ruins",
				"46 Northern Crags", 
                                "",
				"",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"ILSHENAR RUNES", 
				"",
                                "47 Gargoyle City",
				"48 LakeShire",
                                "49 Mistas",
				"50 Montor", 
                                "51 Req Volon",
				"52 Ancient Citadel",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"53 Savage Camp",
                                "54 Terort Skitas",
				"55 Cyclops Dungeon",
				"56 Ratman Mine",
                                "57 Spider Dungeon",
				"58 Wisp Dungeon", 
                                "",
				"",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"TRAMMEL DUNGEONS", 
				"",
                                "59 Covetous",
				"60 Deceit",
                                "61 Despise",
				"62 Destard", 
                                "63 Hythloth",
				"64 Shame",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"65 Wrong",
                                "66 Orc Cave",
				"67 Fire",
				"68 Ice",
                                "69 Terathan Keep",
				"", 
                                "",
				"",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"FELUCCA DUNGEONS", 
				"",
                                "70 Covetous",
				"71 Deceit",
                                "72 Despise",
				"73 Destard", 
                                "74 Hythloth",
				"75 Shame",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"76 Wrong",
                                "77 Orc Cave",
				"78 Fire",
				"79 Ice",
                                "80 Terathan Keep",
				"81 Khaldun", 
                                "",
				"",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"TOKUNO RUNES", 
				"",
                                "82 Zento",
				"83 The Waste",
                                "84 Isamu-Jima Gate",
				"85 Lotus Lakes", 
                                "86 Mount Sho",
				"87 Winter Spur",
				
			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"88 Crane Marsh",
                                "89 Homare-Jima Gate",
				"90 Bushido Dojo",
				"91 Kitsune Woods",
                                "92 Field of Echoes",
				"93 Yomotsu Mines", 
                                "94 Dragon Valley",
				"95 Fan Dancer Dojo",
				
			};
			Pages[cnt++].Lines = lines;



		}

		public ArgyleBook( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); 
		}
	}
}