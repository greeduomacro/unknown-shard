using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
    public abstract class PouchOfReagentHolding : BackpackOfReduction
    {
        private int m_MaxReagents;
        public abstract Type[] m_AllowedReagents { get; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxReagents { get { return m_MaxReagents; } set { m_MaxReagents = value; } }

        private int RandomBagHue { get { return Utility.RandomList(1230, 1303, 1420, 1619, 1640, 2001); } }

        public PouchOfReagentHolding(int maxReagents)
            : base(100)
        {
            ItemID = 3705;
            Hue = RandomBagHue;
            LootType = LootType.Blessed;
            m_MaxReagents = maxReagents;
        }

        private bool CheckDrop(Mobile from, Item dropped)
        {
            bool valid = false;
            for (int i = 0; i < m_AllowedReagents.Length; i++)
            {
                if (dropped.GetType() == m_AllowedReagents[i])
                {
                    valid = true;
                    break;
                }
            }
            if (valid)
            {
                int curAmount = 0;
                List<Item> items = this.Items;

                foreach (Item item in items)
                {
                    if (item.GetType() == dropped.GetType())
                        curAmount += item.Amount;
                }

                if ((curAmount + dropped.Amount) > m_MaxReagents)
                {
                    from.SendMessage("That pouch cannot hold anymore of that type of reagent!");
                    return false;
                }
                else return true;
            }
            else
            {
                from.SendMessage("You can only place reagents in this pouch.");
                return false;
            }
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (CheckDrop(from, dropped))
                return base.OnDragDrop(from, dropped);
            else
                return false;
        }

        public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
        {
            if (CheckDrop(from, item))
                return base.OnDragDropInto(from, item, p);
            else
                return false;
        }

        public override bool OnStackAttempt(Mobile from, Item stack, Item dropped)
        {
            if (CheckDrop(from, dropped))
                return base.OnStackAttempt(from, stack, dropped);
            else
                return false;
        }

        public PouchOfReagentHolding(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0); // version
            writer.WriteEncodedInt(m_MaxReagents);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();

            switch (version)
            {
                case 0:
                    m_MaxReagents = reader.ReadEncodedInt();
                    break;
            }
        }
    }

    public sealed class MagesPouch : PouchOfReagentHolding
    {
        public override Type[] m_AllowedReagents
        {
            get
            {
                return new Type[]
                {
                    typeof(Bloodmoss), typeof(BlackPearl), typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot),
                    typeof(SulfurousAsh), typeof(Nightshade), typeof(SpidersSilk)
                };
            }
        }

        [Constructable]
        public MagesPouch()
            : this(100)
        {
        }

        [Constructable]
        public MagesPouch(int maxReagents)
            : base(maxReagents)
        {
            Name = "Mage's Pouch";
        }

        public MagesPouch(Serial serial)
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

    public sealed class NecromancersPouch : PouchOfReagentHolding
    {
        public override Type[] m_AllowedReagents
        {
            get
            {
                return new Type[]
                {
                    typeof(BatWing), typeof(DaemonBlood), typeof(GraveDust), typeof(NoxCrystal), typeof(PigIron)
                };
            }
        }

        [Constructable]
        public NecromancersPouch()
            : this(100)
        {
        }

        [Constructable]
        public NecromancersPouch(int maxReagents)
            : base(maxReagents)
        {
            Name = "Necromancer's Pouch";
        }

        public NecromancersPouch(Serial serial)
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
