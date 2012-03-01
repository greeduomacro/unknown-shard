using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;
using Server.Engines.Plants;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.ContextMenus;
using Server.Gumps;

namespace Server.Items
{
    public class BaseRegentSeed : Item, ISecurable
    {

        private int type;
        private SecureLevel m_Level;

        [CommandProperty(AccessLevel.GameMaster)]
        public SecureLevel Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        [Constructable]
        public BaseRegentSeed(int t)
            : base(0xDCF)
        {
            type = t;
            Name = "" + GetSeedName();
            Hue = GetSeedHue();
        }

        /*
         * Type 0 = Blood Moss
         * Type 1 = Garlic
         * Type 2 = Ginseng
         * Type 3 = Mandrake
         * Type 4 = Nightshade
         */

        public string GetSeedName()
        {
            switch (type)
            {
                case 0:
                    {
                        return "a dull red seed";
                        break;
                    }
                case 1:
                    {
                        return "a white seed";
                        break;
                    }
                case 2:
                    {
                        return "a brown seed";
                        break;
                    }
                case 3:
                    {
                        return "a dull brown seed";
                        break;
                    }
                case 4:
                    {
                        return "a green seed";
                        break;
                    }
            }
            return "a regent seed";
        }

        public int GetSeedHue()
        {
            switch (type)
            {
                case 0:
                    {
                        return 39;
                        break;
                    }
                case 1:
                    {
                        return 1151;
                        break;
                    }
                case 2:
                    {
                        return 1140;
                        break;
                    }
                case 3:
                    {
                        return 1145;
                        break;
                    }
                case 4:
                    {
                        return 70;
                        break;
                    }
            }
            return 0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.Target = new RegentTarget(this);
            from.SendMessage("Target a pot of dirt.");
        }

        public BaseRegentSeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((int)type);

            writer.Write((int)m_Level);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            type = reader.ReadInt();

            m_Level = (SecureLevel)reader.ReadInt();
        }

    }

    public class RegentTarget : Target
    {

        private static BaseRegentSeed seed;

        public RegentTarget(BaseRegentSeed s)
            : base(2, false, TargetFlags.None)
        {
            seed = s;
        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target is PlantItem)
            {
                PlantItem bowl = (PlantItem)target;

                if (bowl.PlantSystem.Water < 2)
                {
                    from.SendMessage("The dirt must be softened.");
                    return;
                }
                else if (bowl.PlantStatus > PlantStatus.BowlOfDirt)
                {
                    from.SendMessage("That already contains a plant.");
                    return;
                }
                else if (!bowl.IsChildOf(from.Backpack))
                {
                    from.SendMessage("That must be in your back pack.");
                    return;
                }
                else
                {
                    Backpack pack = (Backpack)from.Backpack;

                    BaseRegentPlant plant = GetPlant();
                    plant.Held = 0;
                    plant.Name = plant.Name + " potted";
                    plant.Movable = true;

                    pack.DropItem(plant);

                    bowl.Delete();
                    seed.Delete();
                }
            }
        }

        /*
         * Type 0 = Blood Moss
         * Type 1 = Garlic
         * Type 2 = Ginseng
         * Type 3 = Mandrake
         * Type 4 = Nightshade
         */

        public BaseRegentPlant GetPlant()
        {
            switch (seed.Type)
            {
                case 0:
                    {
                        return new BloodMossPlant();
                        break;
                    }
                case 1:
                    {
                        return new GarlicPlant();
                        break;
                    }
                case 2:
                    {
                        return new GinsengPlant();
                        break;
                    }
                case 3:
                    {
                        return new MandrakePlant();
                        break;
                    }
                case 4:
                    {
                        return new NightshadePlant();
                        break;
                    }
            }
            return new NightshadePlant();
        }

    }
}