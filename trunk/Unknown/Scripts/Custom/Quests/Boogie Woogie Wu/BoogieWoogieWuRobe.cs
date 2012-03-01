// Created by BoogieWoogieWu aka Wicked2006
using System;
using Server.Items;

namespace Server.Items
{
    public class BoogieWoogieWusRobe : BaseArmor
    {

        public override int BasePhysicalResistance { get { return 50; } }
        public override int BaseFireResistance { get { return 50; } }
        public override int BaseColdResistance { get { return 50; } }
        public override int BasePoisonResistance { get { return 50; } }
        public override int BaseEnergyResistance { get { return 50; } }


        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }

        public override int ArtifactRarity { get { return 666; } }

        [Constructable]
        public BoogieWoogieWusRobe()
            : base(0x2683)
        {
            Weight = 0.0;
            Name = "Boogie Woogie Wu's Robe";
            Hue = 1153;


            Attributes.BonusHits = 20;
            Attributes.BonusMana = 20;
            Attributes.BonusStam = 20;
            Attributes.Luck = 150;
            Attributes.BonusInt = 5;
            Attributes.BonusStr = 5;
            Attributes.BonusDex = 5;
            Attributes.RegenHits = 2;
            Attributes.CastRecovery = 6;
            Attributes.CastSpeed = 2;
            Attributes.LowerManaCost = 100;
            Attributes.LowerRegCost = 100;
            Attributes.WeaponDamage = 100;
            Attributes.SpellDamage = 15;
            Attributes.DefendChance = 45;


        }

        public override void OnDoubleClick(Mobile m)
        {
            if (Parent != m)
            {
                m.SendMessage("You must be wearing the robe to use it!");
            }
            else
            {
                if (ItemID == 0x2683 || ItemID == 0x2684)
                {
                    m.SendMessage("You lower the hood.");
                    m.PlaySound(0x57);
                    ItemID = 0x1F03;
                    m.NameMod = null;
                    m.RemoveItem(this);
                    m.EquipItem(this);
                    if (m.Kills >= 5)
                    {
                        m.Criminal = true;
                    }
                    if (m.GuildTitle != null)
                    {
                        m.DisplayGuildTitle = true;
                    }
                }
                else if (ItemID == 0x1F03 || ItemID == 0x1F04)
                {
                    m.SendMessage("You pull the hood over your head.");
                    m.PlaySound(0x57);
                    ItemID = 0x2683;
                    m.DisplayGuildTitle = false;
                    m.Criminal = false;
                    m.RemoveItem(this);
                    m.EquipItem(this);
                }
            }
        }

        public override bool OnEquip(Mobile from)
        {
            if (ItemID == 0x2683)
            {
                from.DisplayGuildTitle = false;
                from.Criminal = false;
            }
            return base.OnEquip(from);
        }

        public override void OnRemoved(Object o)
        {
            if (o is Mobile)
            {
                ((Mobile)o).NameMod = null;
            }
            if (o is Mobile && ((Mobile)o).Kills >= 5)
            {
                ((Mobile)o).Criminal = true;
            }
            if (o is Mobile && ((Mobile)o).GuildTitle != null)
            {
                ((Mobile)o).DisplayGuildTitle = true;
            }
            base.OnRemoved(o);
        }

        public BoogieWoogieWusRobe(Serial serial)
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