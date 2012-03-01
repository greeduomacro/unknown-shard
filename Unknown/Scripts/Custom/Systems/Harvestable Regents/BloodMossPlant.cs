using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
    public class BloodMossPlant : BaseRegentPlant
    {
        [Constructable]
        public BloodMossPlant()
            : base(0xD13)
        {
            Name = "blood moss plant";
            Hue = 32;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 2) && Held > 0)
                HarvestPlant(from, new Bloodmoss(), this);
        }

        public BloodMossPlant(Serial serial)
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