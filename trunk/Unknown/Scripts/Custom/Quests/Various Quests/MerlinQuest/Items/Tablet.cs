
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;

namespace Server.Items
{
	public class Tablet : RedBook
	{
        [Constructable]
        public Tablet()
            : base("Greetings", "Lost Sinner", 24, false)
        {
            Hue = 0x89B;
            Weight = 1.0;
            Name = "Tablet contains Talons spell";
            Hue = 1055;


            Pages[0].Lines = new string[]
	        {
				"Matra Onus Seirta~",
                "When you find Peraniese",
                "Say his name and Hail",
                "Then say his name and",
                "translate. Goodluck",
				
			};
        }

        public Tablet(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}