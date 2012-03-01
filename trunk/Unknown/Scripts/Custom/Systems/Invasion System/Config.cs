using System;
using Server;
using System.Collections;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using System.Collections.Generic;
using System.IO;
using Server.Regions;
using Server.Commands;
using Server.Misc;
using Server.Spells;
using Server.Spells.Necromancy;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Eighth;

namespace Server
{
    public class InvasionConfig
    {
        public static bool Enabled = true; // is this system enabled?

        public static int WaveAmount = 150; // the amount of spawn to respawn

        public static int KillAmount = 500; // Amount to kill before the invasion ends

        public static int Reward = 25000; // The amount of gold offered as a reward
    }

    public enum InvasionSpawnType
    {
        None = 0,
        Rat = 1,
        Orc = 2,
        Reptile = 3,
        Arachnid = 4
    }
}