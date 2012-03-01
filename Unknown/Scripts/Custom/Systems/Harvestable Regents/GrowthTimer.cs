using System; // Declare namespaces
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;

namespace Server.Items // Declare namespace
{
    public class GrowthTimer : Timer // Declare class GrowthTimer, Inherits from base class 'Timer'
    {
        public static void Initialize() // Handles server Initialization
        {
            new GrowthTimer(); // Creates a new instance of a growth timer
        }

        private static ArrayList plants; // Declares 'plants' as an arraylist

        public GrowthTimer() // GrowthTimer constructor
            : base(TimeSpan.FromMinutes(45)) // Has a 45 tick delay
        {
            plants = new ArrayList(); // Init 'plants'
            this.Start(); // Starts itself
        }

        protected override void OnTick() // Overrides OnTick
        {
            foreach (Item item in World.Items.Values) // Iterates through all items in world
            {
                if (item is BaseRegentPlant) // Checks if item is type of 'BaseRegentPlant'
                {
                    BaseRegentPlant plant = (BaseRegentPlant)item; // Casts 'item' as a 'BaseRegentPlant' to reference class specific properties

                    if (plant.Held < 12 || plant.Held < 14 && plant.Name.ToLower().Contains("potted")) // Checks if a plant it valid to grow, if it is adds it to the 'plants' arraylist
                        plants.Add(plant);
                }
            }

            for (int i = 0; i < plants.Count; ++i) // Iterate through 'plants' & add 1 to the held amount of each plant in the arraylist
            {
                BaseRegentPlant plant = (BaseRegentPlant)plants[i];
                plant.Held += 1;
            }
            this.Stop(); // Stops/Disposes the current timer

            new GrowthTimer(); // Creates new timer to take place
        }
    }
}