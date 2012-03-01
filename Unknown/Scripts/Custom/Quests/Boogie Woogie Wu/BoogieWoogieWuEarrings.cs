// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;

namespace Server.Items
{
    public class EarringsOfBoogieWoogieWu : BaseEarrings
    {

        public override int ArtifactRarity { get { return 666; } }

        [Constructable]

        public EarringsOfBoogieWoogieWu()
            : base(0x1087)
        {
            Name = "Earrings Of Boogie Woogie Wu";
            Weight = 0.1;
            Hue = 1153;

            Attributes.BonusDex = 10;
            Attributes.BonusStr = 10;
            Attributes.BonusInt = 10;

            Attributes.BonusHits = 10;
            Attributes.BonusStam = 10;
            Attributes.BonusMana = 10;

            Attributes.AttackChance = 10;
            Attributes.ReflectPhysical = 10;
            Attributes.DefendChance = 10;


            Attributes.SpellDamage = 10;
            Attributes.WeaponDamage = 10;

            Resistances.Fire = 10;
            Resistances.Cold = 10;
            Resistances.Poison = 10;
            Resistances.Energy = 10;

            Attributes.LowerManaCost = 10;
            Attributes.RegenMana = 5;
            Attributes.RegenHits = 5;
            Attributes.RegenStam = 5;


        }

        public EarringsOfBoogieWoogieWu(Serial serial)
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