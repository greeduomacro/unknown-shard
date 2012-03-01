// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;
namespace Server.Items
{
    public class BoogieWoogieWuSandals : Sandals
    {
        [Constructable]
        public BoogieWoogieWuSandals()
            : base(11012)
        {
            Hue = 1153;
            Name = "Boogie Woogie Wu Sandals";
            Attributes.NightSight = 1;
            Attributes.BonusStr = 15;
            Attributes.BonusInt = 15;
            Attributes.BonusDex = 15;
            Attributes.BonusHits = 15;
            Attributes.BonusStam = 15;
            Attributes.BonusMana = 15;
            Attributes.RegenHits = 15;
            Attributes.RegenStam = 15;
            Attributes.AttackChance = 75;
            Attributes.DefendChance = 75;
            Attributes.WeaponDamage = 75;
            Attributes.WeaponSpeed = 75;
            Attributes.CastSpeed = 15;
            Attributes.CastRecovery = 15;
            Attributes.LowerManaCost = 15;
            Attributes.LowerRegCost = 15;
        }
        public BoogieWoogieWuSandals(Serial serial)
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
