using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
    public class MandrakePlant : BaseRegentPlant
    {
        [Constructable]
        public MandrakePlant()
            : base(0x18DF)
        {
            Name = "mandrake plant";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 2) && Held > 0)
                HarvestPlant(from, new MandrakeRoot(), this);
        }

        public MandrakePlant(Serial serial)
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