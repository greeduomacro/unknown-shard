
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class AncientScroll1 : Item
	{
        [Constructable]
        public AncientScroll1()
        {
            ItemID = 5357;
            Weight = 1.0;
            Name = "A section of an anceint scroll";
            Hue = 1055;
				
        }

        public override void OnDoubleClick(Mobile from)
        {
            Item n = from.Backpack.FindItemByType(typeof(AncientScroll2));
            if (n != null)
            {
                from.AddToBackpack(new AncientScroll3());
                n.Delete();
                Delete();
            }
            else
            {
                from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "You lack the other piece to combine with this", from.NetState);
            }
        }

        public AncientScroll1(Serial serial)
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