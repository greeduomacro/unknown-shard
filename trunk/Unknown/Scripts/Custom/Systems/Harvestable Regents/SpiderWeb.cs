using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
    public class SpiderWeb : BaseRegentPlant
    {
        [Constructable]
        public SpiderWeb()
            : base(0xF8D)
        {
            Name = "spider web";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 2) && Held > 0)
                HarvestPlant(from, new SpidersSilk(), this);
        }

        public SpiderWeb(Serial serial)
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