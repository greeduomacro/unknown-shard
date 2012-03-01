// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;

namespace Server.Items
{
    public class BoogieWoogieWuShield : OrderShield
    {
        public override int ArtifactRarity { get { return 666; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public BoogieWoogieWuShield()
        {
            Weight = 5.0;
            Name = "Boogie Woogie Wu Shield";

            Hue = 2052;
            ColdBonus = 60;
            EnergyBonus = 60;
            PhysicalBonus = 60;
            PoisonBonus = 60;
            FireBonus = 60;

            Attributes.Luck = 500;
            Attributes.NightSight = 1;
            Attributes.WeaponSpeed = 50;
            Attributes.AttackChance = 50;

            Attributes.BonusDex = 30;
            Attributes.BonusStr = 20;
            Attributes.BonusInt = 50;
            Attributes.BonusStam = 30;
            Attributes.BonusMana = 30;
            Attributes.DefendChance = 60;
            Attributes.RegenStam = 50;
            Attributes.SpellChanneling = 1;

        }

        public BoogieWoogieWuShield(Serial serial)
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