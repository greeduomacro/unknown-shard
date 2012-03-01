
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;

namespace Server.Items
{
    public class ISTile3 : Item
	{
        private bool m_AllowCreatures;

		[Constructable]
		public ISTile3()
		{
            ItemID = 1313;
			Weight = 1.0;
            Visible = false;
            Movable = false;
            Name = "IncorrectStepTile";
			Hue = 1;
        }

        public ISTile3(Serial serial)
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

            m.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
            m.PlaySound(0x307);
            m.Hits -= 25;
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