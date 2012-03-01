//Property of Milkman Dan
// Demonic Ridez http://www.demonicridez.com
using System;
using Server;
namespace Server.Items
{
	public class JabbaQuestBook: BaseBook
	{
		[Constructable]
		public JabbaQuestBook() : base( 4030, 20, true)
		{
            Hue = 1161;
			Title = "Jabba's Quest";
			Author = "Jabba";
			LootType = LootType.Blessed;
			int cnt = 0;
			string[] lines;
			lines = new string[] //page 0
			{
				"Bring back the following:",
				"Proxy Legs",
				"Proxy Head",
				"Proxy Torso",
				"Putrifier Spleen",
				"Gather and return onto me",
				"And You shall do battle with",
				"Chief Proxymous",
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
		public JabbaQuestBook( Serial serial ) : base( serial )
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
