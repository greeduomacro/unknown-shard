// Created by BoogieWoogieWu aka Wicked2006
using System;

namespace Server.Items
{
    public class BoogieWoogieWuApron : HalfApron
    {

        [Constructable]
        public BoogieWoogieWuApron()
        {
            Name = "Boogie Woogie Wu Apron";
            Hue = 1;
            Attributes.NightSight = 1;
            Attributes.BonusStr = 5;
            Attributes.BonusInt = 5;
            Attributes.BonusDex = 5;
            Attributes.BonusHits = 5;
            Attributes.BonusStam = 5;
            Attributes.BonusMana = 5;
            Attributes.RegenHits = 5;
            Attributes.RegenStam = 5;
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 5;
            Attributes.WeaponDamage = 5;
            Attributes.WeaponSpeed = 5;
            Attributes.CastSpeed = 5;
            Attributes.CastRecovery = 5;
            Attributes.LowerManaCost = 5;
            Attributes.LowerRegCost = 5;

        }

        public BoogieWoogieWuApron(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
