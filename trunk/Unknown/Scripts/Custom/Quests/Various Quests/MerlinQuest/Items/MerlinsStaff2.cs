  /////////////////////////////
 //////  LostSinner  /////////
/////////////////////////////

using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	
	public class MerlinsStaff2 : QuarterStaff
	{

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public MerlinsStaff2()
		{
			ItemID = 3721;
			Name = "The Staff of Merlin";
			Hue = 1055;
		}

        public MerlinsStaff2(Serial serial)
            : base(serial)
		{
		}

        public override void OnDoubleClick(Mobile from)
        {
            MerlinsStaff Staff = from.FindItemOnLayer(Layer.TwoHanded) as MerlinsStaff;

            if (Parent != from)
            {
                from.SendMessage("You remember that you must equip the staff to summon a portal to Merlin");
            }
            else
            {
                Item mg2 = new MerlinsGate2();
                mg2.Location = from.Location;
                mg2.Map = from.Map;
                from.PrivateOverheadMessage( MessageType.Regular, 1153, false, "You feel the power of the Staff and Spellbook working together", from.NetState );
            }
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