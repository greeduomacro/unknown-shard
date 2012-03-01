
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
	public class JonahQuestBook: BaseBook
	{
		[Constructable]
		public JonahQuestBook() : base( 4030, 20, true)
		{

			Title = "Jonah's Quest";
			Author = "Jonah";
			LootType = LootType.Blessed;
			int cnt = 0;
			string[] lines;
			lines = new string[] //page 0
			{
				"Bring back the following:",
				"Jonahs Note 1",
				"Jonahs Note 2",
				"Jonahs Note 3",
				"Master Jonas Death Vortex",
				"",
				"Return to Jonah with",
				"them in your backpack",
			};
			Pages[cnt++].Lines = lines;
			lines = new string[] //page 1
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
		public JonahQuestBook( Serial serial ) : base( serial )
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
