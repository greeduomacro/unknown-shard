
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;

namespace Server.Items
{
    public class DeathTile : Item
	{
        private bool m_AllowCreatures;

		[Constructable]
		public DeathTile()
		{
            ItemID = 1313;
			Weight = 1.0;
            Visible = false;
            Movable = false;
			Name = "Death tile";
			Hue = 1;
        }

        public DeathTile(Serial serial)
            : base(serial)
		{
		}

        public override bool OnMoveOver(Mobile m)
        {
            if (!m_AllowCreatures && !m.Player)
                return true;

            Item a = m.Backpack.FindItemByType(typeof(SphereOfProtection));
            if (!m_AllowCreatures && !m.Player)
                return true;
            if (a != null)
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