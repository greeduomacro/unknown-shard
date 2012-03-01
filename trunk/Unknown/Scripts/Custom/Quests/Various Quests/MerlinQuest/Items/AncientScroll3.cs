
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;

namespace Server.Items
{
	public class AncientScroll3 : Item
	{
        [Constructable]
        public AncientScroll3()
        {
            ItemID = 5360;
            Weight = 1.0;
            Name = "Sroll of Archametes";
            Hue = 1055;
				
        }

        public AncientScroll3(Serial serial)
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