// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;

namespace Server.Items
{
    public class BraceletOfBoogieWoogieWu : GoldBracelet
    {

        public override int ArtifactRarity { get { return 666; } }

        [Constructable]
        public BraceletOfBoogieWoogieWu()
        {
            Name = "Bracelet Of Boogie Woogie Wu";
            Hue = 1153;

            Attributes.Luck = 200;
            Attributes.BonusHits = 50;
            Attributes.BonusStam = 50;
            Attributes.BonusMana = 50;

            Attributes.SpellDamage = 20;
            Attributes.CastRecovery = 5;
            Attributes.CastSpeed = 5;

            Attributes.LowerManaCost = 20;
            Attributes.LowerRegCost = 50;

            Attributes.RegenMana = 5;
            Attributes.RegenHits = 5;
            Attributes.RegenStam = 5;



        }

        public BraceletOfBoogieWoogieWu(Serial serial)
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