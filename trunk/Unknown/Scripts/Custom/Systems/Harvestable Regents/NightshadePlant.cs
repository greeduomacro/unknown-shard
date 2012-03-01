using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
    public class NightshadePlant : BaseRegentPlant
    {
        [Constructable]
        public NightshadePlant()
            : base(0x18E5)
        {
            Name = "nightshade plant";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 2) && Held > 0)
                HarvestPlant(from, new Nightshade(), this);
        }

        public NightshadePlant(Serial serial)
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