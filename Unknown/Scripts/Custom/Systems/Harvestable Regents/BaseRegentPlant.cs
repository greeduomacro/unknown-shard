using System; // Declare use of namespaces
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items // Declare namespace
{
    public class BaseRegentPlant : Item // Declare Class, Inherit from Base Class 'Item'
    {
        private int held;

        [CommandProperty(AccessLevel.GameMaster)] // Declare public in-game accessible property
        public int Held
        {
            get { return held;  InvalidateProperties(); }
            set { held = value; InvalidateProperties(); } // Uses InvalidateProperties() to make sure on ML shards it is displaying the correct amount
        }

        public BaseRegentPlant(int itemID) // The constructor for baseregent plant, takes a itemid as an argument
            : base(itemID)
        {
            Movable = false; // The plant at defualt is not movable
            Held = Utility.RandomMinMax(1, 5); // spawns with a random amount of held regent
            InvalidateProperties();
        }

        public override void GetProperties(ObjectPropertyList list) // Overides the ObjectPropertyList to display the amount held by the plant
        {
            base.GetProperties(list);
            list.Add((string)String.Format("Amount: ", Held.ToString()));
        }

        public void HarvestPlant(Mobile from, Item i_item, BaseRegentPlant i_item2) // This is the handler for when the plant is harvested
        {
            Item item = i_item; // The regent the plant has created
            BaseRegentPlant regentplant = i_item2; // The plant itself
            Mobile m = from; // The mobile that harvested the plant

            item.Amount = regentplant.Held; // Sets the amount of the item harvested to that of which the plant held

            if (m.Skills[SkillName.Cooking].Value > 95.0 || m.Skills[SkillName.Lumberjacking].Value > 95.0) // Checks to see if the harvester is eligable for a skill bonus
            {
                item.Amount += (int)(m.Skills[SkillName.Cooking].Value - 95.0) < 0 ? 0 : (int)(m.Skills[SkillName.Cooking].Value - 95.0); // Takes 95 away from the base of their cooking skill & adds the remainer to the harvested items amount,  checks if the result would be a negative number
                item.Amount += (int)(m.Skills[SkillName.Lumberjacking].Value - 95.0) < 0 ? 0 : (int)(m.Skills[SkillName.Lumberjacking].Value - 95.0); // same as above except for lumberjack
                m.SendMessage("You use you expert skill to gain more then average from the plant.");
            }

            double chance = Utility.RandomDouble(); // If it is a wild plant the chance to get a seed is 30%, else if it is potted the chance is 100%
            if (0.30 > chance || regentplant.Name.ToLower().Contains("potted"))
                GiveSeed(m, regentplant);

            m.SendMessage("You harvest from the plant.");
            AddHarvestToPack(m, item);
            regentplant.Delete(); // Deletes the harvested plant
        }

        public void GiveSeed(Mobile m, BaseRegentPlant plant) // Gets the kind of seed depending on the kind of plant
        {
            Backpack pack = (Backpack)m.Backpack; // References the mobiles backpack

            if (plant is BloodMossPlant)
                pack.DropItem(new BaseRegentSeed(0));
            else if (plant is GarlicPlant)
                pack.DropItem(new BaseRegentSeed(1));
            else if (plant is GinsengPlant)
                pack.DropItem(new BaseRegentSeed(2));
            else if (plant is MandrakePlant)
                pack.DropItem(new BaseRegentSeed(3));
            else if (plant is NightshadePlant)
                pack.DropItem(new BaseRegentSeed(4));
        }

        private void AddHarvestToPack(Mobile m, Item i) // Adds a passed item to the passed mobiles pack
        {
            Backpack pack = (Backpack)m.Backpack;
            pack.DropItem(i);
        }

        public BaseRegentPlant(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write((int)held); // Saves the held amount
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt(); // version
            Held = reader.ReadInt(); // Loads the held amount
        }
    }
}