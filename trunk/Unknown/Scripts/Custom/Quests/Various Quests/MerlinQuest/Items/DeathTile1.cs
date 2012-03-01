
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DeathTile1 : Item
	{
        private bool m_AllowCreatures;

		[Constructable]
		public DeathTile1()
		{
            ItemID = 1313;
			Weight = 1.0;
            Visible = false;
            Movable = false;
			Name = "Death tile";
			Hue = 1;
        }

        public DeathTile1(Serial serial)
            : base(serial)
		{
		}

        public override bool OnMoveOver(Mobile m)
        {
            if (!m_AllowCreatures && !m.Player)
                return true;

            Item c = m.FindItemOnLayer(Layer.Bracelet) as BraceletOfTalon;

            if (c != null)
            {
                m.SendMessage("You feel as if you're being protected from some evil force");
                return true;
            }
            else
            {
                m.Kill();
                return true;
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