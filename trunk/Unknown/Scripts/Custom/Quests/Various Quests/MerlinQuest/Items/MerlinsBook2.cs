
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;

namespace Server.Items
{
	public class MerlinsBook2 : Item
	{
		[Constructable]
		public MerlinsBook2()
		{
			Hue = 1401;
            ItemID = 3834;
			Weight = 1.0;
			Name = "Matra omi Onus";
        }

        public MerlinsBook2(Serial serial)
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