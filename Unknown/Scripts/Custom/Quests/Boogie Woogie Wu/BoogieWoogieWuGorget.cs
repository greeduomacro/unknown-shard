// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;
namespace Server.Items
{
    public class BoogieWoogieWuGorget : LeatherGorget
    {
        public override int InitMinHits { get { return 1500; } }
        public override int InitMaxHits { get { return 1500; } }
        [Constructable]
        public BoogieWoogieWuGorget()
        {
            Hue = 1153;
            Name = "Boogie Woogie Wu Gorget";
            ColdBonus = 20;
            EnergyBonus = 20;
            PhysicalBonus = 20;
            PoisonBonus = 20;
            FireBonus = 20;
            ArmorAttributes.SelfRepair = 10;
            Attributes.BonusDex = 45;
            Attributes.BonusHits = 10;
            Attributes.BonusInt = 45;
            Attributes.BonusMana = 10;
            Attributes.BonusStam = 10;
            Attributes.BonusStr = 45;
            Attributes.CastRecovery = 1;
            Attributes.CastSpeed = 1;
            Attributes.LowerManaCost = 40;
            Attributes.LowerRegCost = 100;
            Attributes.ReflectPhysical = 20;
            Attributes.SpellDamage = 15;

        }
        public BoogieWoogieWuGorget(Serial serial)
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
