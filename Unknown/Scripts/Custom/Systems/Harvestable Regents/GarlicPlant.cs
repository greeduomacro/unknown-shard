using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
    public class GarlicPlant : BaseRegentPlant
    {
        [Constructable]
        public GarlicPlant()
            : base(0x18E1)
        {
            Name = "garlic plant";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 2) && Held > 0)
                HarvestPlant(from, new Garlic(), this);
        }

        public GarlicPlant(Serial serial)
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