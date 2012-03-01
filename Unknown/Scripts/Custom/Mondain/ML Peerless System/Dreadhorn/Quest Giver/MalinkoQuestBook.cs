
//////////////////////////
/// Created by Rosey1  ///  
/// thought up by Aeric///
///                    ///
//////////////////////////


///I got this script from the dragon heart quest of karmageddon.
///This Book was exported to c# file using daat99's copyBook script.
///Thanx a lot for jjarmis for his HUGE support on writing this script.
using System;
using Server;
namespace Server.Items
{
	public class MalinkoQuestBook: BaseBook
	{
		[Constructable]
		public MalinkoQuestBook() : base( 4030, 20, true)
		{
            Hue = 1161;
			Title = "Malinko's Quest";
			Author = "Malinko";
			LootType = LootType.Blessed;
			int cnt = 0;
			string[] lines;
			lines = new string[] //page 0
			{
				"Bring back the following:",
				"Irks Brain",
				"Gnaws Fang",
				"Blighted Cotton",
				"Thorny Briars",
				"Lady Lissiths Silk",
				"and Lady Sabrix Eye",
				"Once you Have all",
			};
			Pages[cnt++].Lines = lines;
			lines = new string[] //page 1
			{
			"of these Items",
				"Return to me with them",
				"In your backpack",
				"And Dreadhorns Demise",
				"will Come!!",
				"",
				"",
				"",
			};
			Pages[cnt++].Lines = lines;
			lines = new string[] //page 2
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
			lines = new string[] //page 3
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
			lines = new string[] //page 4
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
			lines = new string[] //page 5
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
			lines = new string[] //page 6
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
			lines = new string[] //page 7
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
			lines = new string[] //page 8
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
			lines = new string[] //page 9
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
			lines = new string[] //page 10
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
			lines = new string[] //page 11
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
			lines = new string[] //page 12
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
			lines = new string[] //page 13
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
			lines = new string[] //page 14
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
			lines = new string[] //page 15
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
			lines = new string[] //page 16
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
			lines = new string[] //page 17
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
			lines = new string[] //page 18
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
			lines = new string[] //page 19
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
		public MalinkoQuestBook( Serial serial ) : base( serial )
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
			writer.Write( (int)0 ); // version
		}
	}
}
