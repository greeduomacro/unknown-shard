// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;

namespace Server.Items
{
    public class RingOfBoogieWoogieWu : GoldRing
    {

        public override int ArtifactRarity { get { return 666; } }

        [Constructable]
        public RingOfBoogieWoogieWu()
        {

            Name = "Ring Of Boogie Woogie Wu";
            Hue = 1153;

            Attributes.Luck = 200;
            Attributes.BonusDex = 20;
            Attributes.BonusStr = 20;
            Attributes.BonusInt = 20;

            Resistances.Fire = 10;
            Resistances.Cold = 10;
            Resistances.Poison = 10;
            Resistances.Energy = 10;

            Attributes.LowerManaCost = 20;
            Attributes.LowerRegCost = 50;


        }

        public RingOfBoogieWoogieWu(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}