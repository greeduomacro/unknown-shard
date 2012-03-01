using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class MerlinsField : Item
    {
        private bool m_AllowCreatures;

        [Constructable]
        public MerlinsField()
            : base(0x3967)
        {
            Movable = false;
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

        public MerlinsField(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}