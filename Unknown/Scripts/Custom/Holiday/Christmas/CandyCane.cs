using System;
using Server;
using Server.Items;


namespace Server.Items
{

    public class RedCandyCane : Food
    {

        [Constructable]
        public RedCandyCane()
            : base(0x1044)
        {
            Weight = 1.0;
            ItemID = Utility.RandomList(0x2BDD, 0x2BDE); //Red Candy Cane
        }

        public RedCandyCane(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); //Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
//Green Candy Cane
        public class GreenCandyCane : Food
        {

            [Constructable]
            public GreenCandyCane()
                : base(0x1044)
            {
                Weight = 1.0;
                ItemID = Utility.RandomList(0x2BDF, 0x2BE0); //Green Candy Cane
            }

            public GreenCandyCane(Serial serial)
                : base(serial)
            {
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)0); //Version
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();
            }

        }
    }
}

