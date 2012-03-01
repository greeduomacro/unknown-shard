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
	
	public class MerlinsStaff : QuarterStaff
	{

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public MerlinsStaff()
		{
			ItemID = 3721;
			Name = "The Staff of Merlin";
			Hue = 1055;
		}

        public MerlinsStaff(Serial serial)
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
                Item marker1 = from.Backpack.FindItemByType(typeof(Marker1));
                if (marker1 != null)
                {
                    marker1.Delete();

                    from.AddToBackpack(new Marker2());
                    from.AddToBackpack(new Tablet());
                    from.FixedParticles(0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot);
                    from.SendGump(new MerlinsQuestGump6(from));
                    from.SendMessage("Muahahahaha!!!! You fool!");
                    Talon2 tl = new Talon2();
                    tl.Map = from.Map;
                    tl.Location = from.Location;
                    Delete();
                }
                else
                {
                    from.SendMessage("You have no right to have this staff!!!!");
                }
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