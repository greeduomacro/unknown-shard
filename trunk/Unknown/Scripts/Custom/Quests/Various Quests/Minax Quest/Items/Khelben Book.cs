//Written by Lord Dalamar
using System;
using Server;

namespace Server.Items
{
	// books: Brown 0xFEF, Tan 0xFF0, Red 0xFF1, Blue 0xFF2, 
	// OpenSmall 0xFF3, Open 0xFF4, OpenOld 0xFBD, 0xFBE

	public class KhelbenBook: BaseBook
	{
		private const string TITLE = "Whereabouts of Brielbara the Witch";
		private const string AUTHOR = "Khelben Blackstaff";
		private const int PAGES = 2;
		private const bool WRITABLE = false;
		
		[Constructable]
		public KhelbenBook() : base( Utility.RandomList( 0xFEF, 0xFF0, 0xFF1, 0xFF2 ), TITLE, AUTHOR, PAGES, WRITABLE )
		{
			// NOTE: There are 8 lines per page and
			// approx 22 to 24 characters per line.
			//  0----+----1----+----2----+
			int cnt = 0;
			string[] lines;
			Hue = 1167;

			lines = new string[]
			{
				"Brielbara is in the", 
				"swamps south of.",
				"Papua. Visit her",
				"to learn the",
				"whereabouts of Minax.",

			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
			};
			Pages[cnt++].Lines = lines;



		}

		public KhelbenBook( Serial serial ) : base( serial )
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