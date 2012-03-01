//Written by Lord Dalamar
using System;
using Server;

namespace Server.Items
{
	// books: Brown 0xFEF, Tan 0xFF0, Red 0xFF1, Blue 0xFF2, 
	// OpenSmall 0xFF3, Open 0xFF4, OpenOld 0xFBD, 0xFBE

	public class JhassoBook: BaseBook
	{
		private const string TITLE = "Whereabouts of Khelben Blackstaff";
		private const string AUTHOR = "Jhasso the Furtrader";
		private const int PAGES = 2;
		private const bool WRITABLE = false;
		
		[Constructable]
		public JhassoBook() : base( Utility.RandomList( 0xFEF, 0xFF0, 0xFF1, 0xFF2 ), TITLE, AUTHOR, PAGES, WRITABLE )
		{
			// NOTE: There are 8 lines per page and
			// approx 22 to 24 characters per line.
			//  0----+----1----+----2----+
			int cnt = 0;
			string[] lines;
			Hue = 1152;

			lines = new string[]
			{
				"Khelben is in the", 
				"city of Magincia.",
				"Visit him in the Magika",
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

		public JhassoBook( Serial serial ) : base( serial )
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