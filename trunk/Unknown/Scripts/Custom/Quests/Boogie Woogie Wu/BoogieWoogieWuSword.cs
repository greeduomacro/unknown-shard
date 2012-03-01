// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server;

namespace Server.Items
{
    public class BoogieWoogieWuSword : Longsword
    {
        public override int ArtifactRarity { get { return 666; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public BoogieWoogieWuSword()
        {
            Weight = 0.0;
            Name = "Boogie Woogie Wu's Sword";
            Speed = 70;

            Light = LightType.Circle225;

            Hue = 1153;
            Slayer = SlayerName.ElementalBan;
            Attributes.BonusStr = 25;
            Attributes.BonusInt = 15;
            Attributes.BonusDex = 10;
            Attributes.BonusHits = 40;
            Attributes.BonusStam = 40;
            Attributes.BonusMana = 40;
            Attributes.RegenHits = 40;
            Attributes.RegenStam = 40;
            WeaponAttributes.HitLeechHits = 100;
            WeaponAttributes.HitLeechStam = 40;
            WeaponAttributes.HitLeechMana = 40;
            Attributes.AttackChance = 75;
            Attributes.DefendChance = 75;
            Attributes.WeaponDamage = 100;
            Attributes.WeaponSpeed = 100;
            Attributes.Luck = 1000;
            Attributes.ReflectPhysical = 75;
            Attributes.SpellDamage = 100;
            WeaponAttributes.ResistPhysicalBonus = 50;
            WeaponAttributes.ResistColdBonus = 50;
            WeaponAttributes.ResistFireBonus = 50;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPoisonBonus = 50;
            WeaponAttributes.DurabilityBonus = 1000;
            WeaponAttributes.SelfRepair = 50;
            Attributes.CastSpeed = 15;
            Attributes.CastRecovery = 10;
            Attributes.LowerManaCost = 85;
            Attributes.LowerRegCost = 85;
            WeaponAttributes.HitLowerAttack = 40;
            WeaponAttributes.HitLowerDefend = 40;
            WeaponAttributes.HitHarm = 75;
            WeaponAttributes.HitFireball = 75;
            WeaponAttributes.HitLightning = 75;
            WeaponAttributes.HitDispel = 75;
        }

        public BoogieWoogieWuSword(Serial serial)
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