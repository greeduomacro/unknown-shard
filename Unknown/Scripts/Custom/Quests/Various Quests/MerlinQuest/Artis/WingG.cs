using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class WingG : Sandals
    {
        public override int ArtifactRarity { get { return 76; } }

        [Constructable]
        public WingG()
        {
            LootType = LootType.Blessed;
            ItemID = 5901;
            Name = "Wings of the Gargoyle";
            Hue = 1109;
            Weight = 1.0;
            Attributes.CastSpeed = 1;
            Attributes.CastRecovery = 1;
            Attributes.WeaponSpeed = 5;
            Attributes.ReflectPhysical = 15;
        }

        public WingG(Serial serial)
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