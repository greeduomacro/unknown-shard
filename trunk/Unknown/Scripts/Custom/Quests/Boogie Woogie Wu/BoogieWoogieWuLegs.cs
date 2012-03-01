// Created by BoogieWoogieWu aka Wicked2006

using System;
using Server;

namespace Server.Items
{
    public class BoogieWoogieWuLegs : BoneLegs
    {
        public override int BasePhysicalResistance{ get{ return 50; } }
        public override int BaseColdResistance{ get{ return 50; } }
        public override int BaseFireResistance{ get{ return 100; } }
        public override int BaseEnergyResistance{ get{ return 50; } }
        public override int BasePoisonResistance{ get{ return 50; } }
        public override int ArtifactRarity{ get{ return 666; } }
        public override int InitMinHits{ get{ return 100; } }
        public override int InitMaxHits{ get{ return 1000; } }

        [Constructable]
        public BoogieWoogieWuLegs()
        {
            Name = "Boogie Woogie Wu Legs";
            Hue = 1153;

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
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.DurabilityBonus = 1000;
            Attributes.CastSpeed = 15;
            Attributes.CastRecovery = 15;
            Attributes.LowerManaCost = 15;
            Attributes.LowerRegCost = 15;
            SkillBonuses.SetValues( 0, SkillName.Parry, 15.0 );
            SkillBonuses.SetValues( 1, SkillName.Anatomy, 15.0 );
            SkillBonuses.SetValues( 2, SkillName.Tactics, 15.0 );
            SkillBonuses.SetValues( 3, SkillName.Wrestling, 15.0 );
        }

        public BoogieWoogieWuLegs(Serial serial) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    } // End Class
} // End Namespace
