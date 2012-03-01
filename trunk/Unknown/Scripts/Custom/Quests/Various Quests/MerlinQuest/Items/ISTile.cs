
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;

namespace Server.Items
{
    public class ISTile1 : Item
	{
        private bool m_AllowCreatures;

		[Constructable]
		public ISTile1()
		{
            ItemID = 1313;
			Weight = 1.0;
            Visible = false;
            Movable = false;
            Name = "IncorrectStepTile";
			Hue = 1;
        }

        public ISTile1(Serial serial)
            : base(serial)
		{
		}

        public override bool OnMoveOver(Mobile m)
        {
            if (!m_AllowCreatures && !m.Player)
                return true;

            if (m.Backpack.ConsumeTotal(typeof(SphereOfProtection), 1))
            {
                return false;
            }

            m.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.Waist);
            m.PlaySound(0x208);
            m.Hits -= 40;
            return true;
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