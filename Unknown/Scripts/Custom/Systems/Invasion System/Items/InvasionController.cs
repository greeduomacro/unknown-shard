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

namespace Server.Items
{
    public class InvasionController : Item
    {
        public bool inprogress;

        public InvasionRegion ThisRegion;
        public Rectangle2D regionpoint;
        public Map regionmap;

        public ArrayList Players;
        public ArrayList Spawn;

        public int killed;

        public InvasionWaveTimer WaveTimer;

        public InvasionSpawnType spawntype;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool InProgress
        {
            get { return inprogress; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Map RegionMap
        {
            get { return regionmap; }
            set { regionmap = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Rectangle2D RegionPoint
        {
            get { return regionpoint; }
            set { regionpoint = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Killed
        {
            get { return killed; }
            set { killed = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public InvasionSpawnType SpawnType
        {
            get { return spawntype; }
            set { spawntype = value; }
        }

        [Constructable]
        public InvasionController(): base(3796)
        {
            Name = "Invasion Controller";
            Movable = false;
            Visible = false;
            spawntype = InvasionSpawnType.None;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!inprogress)
                StartInvasion();
            else
                EndInvasion();

            base.OnDoubleClick(from);
        }

        public void StartInvasion()
        {
            ThisRegion = new InvasionRegion(this);

            if (spawntype == InvasionSpawnType.None)
                RandomSpawn();

            if (Players == null)
                Players = new ArrayList();
            if (Spawn == null)
                Spawn = new ArrayList();

            WaveTimer = new InvasionWaveTimer(this);
            inprogress = true;

            DoSpawn(InvasionConfig.WaveAmount);
        }

        public void EndInvasion()
        {
            WaveTimer.Stop();

            for (int i = 0; i < Spawn.Count; ++i)
            {
                Mobile m = (Mobile)Spawn[i];
                Spawn.Remove(m);
                m.Delete();
            }

            for (int i = 0; i < Players.Count; ++i)
            {
                PlayerMobile pm = (PlayerMobile)Players[i];
                Players.Remove(pm);

                BankBox bank = (BankBox)pm.BankBox;
                bank.DropItem(new BankCheck(InvasionConfig.Reward));
            }

            Killed = 0;
            inprogress = false;
            ThisRegion.Unregister();
            ThisRegion = null;
        }

        public void OnKill(Mobile killed)
        {
            Killed += 1;
            Spawn.Remove(killed);

            if (Killed >= InvasionConfig.KillAmount)
                EndInvasion();

            if (Spawn.Count < 20)
                DoSpawn(InvasionConfig.WaveAmount);
        }

        public void RandomSpawn()
        {
            switch (Utility.Random(1, 4))
            {
                case 1:
                    {
                        spawntype = InvasionSpawnType.Rat;
                        break;
                    }
                case 2:
                    {
                        spawntype = InvasionSpawnType.Orc;
                        break;
                    }
                case 3:
                    {
                        spawntype = InvasionSpawnType.Reptile;
                        break;
                    }
                case 5:
                    {
                        spawntype = InvasionSpawnType.Arachnid;
                        break;
                    }
            }
        }

        public void DoSpawn(int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (SpawnType == InvasionSpawnType.Rat)
                {
                    InvasionRat m = new InvasionRat(this);
                    SpawnMob(m);
                }
                else if (SpawnType == InvasionSpawnType.Orc)
                {
                    InvasionOrc m = new InvasionOrc(this);
                    SpawnMob(m);
                }
                else if (SpawnType == InvasionSpawnType.Reptile)
                {
                    InvasionReptile m = new InvasionReptile(this);
                    SpawnMob(m);
                }
                else if (SpawnType == InvasionSpawnType.Arachnid)
                {
                    InvasionArachnid m = new InvasionArachnid(this);
                    SpawnMob(m);
                }
            }
        }

        public void SpawnMob(Mobile m)
        {
            Point3D loc = GetRandomRegionPoint();

            if (loc.X != 0 && loc.Y != 0)
            {
                m.Location = loc;
                m.Map = regionmap;
                Spawn.Add(m);
            }
            else
            {
                m.Delete();
                return;
            }
        }

        public Point3D GetRandomRegionPoint()
        {
            bool done = false;
            Point3D toreturn = new Point3D();

            int attempts = 0;
            while (!done)
            {
                int x = Utility.RandomMinMax(regionpoint.X, (regionpoint.X + regionpoint.Width));
                int y = Utility.RandomMinMax(regionpoint.Y, (regionpoint.Y + regionpoint.Height));
                int z = regionmap.GetAverageZ(x, y); ;
                toreturn = new Point3D(x, y, z);

                if (SpellHelper.FindValidSpawnLocation(regionmap, ref toreturn, true))
                {
                    done = true;
                }
                attempts += 1;

                if (attempts >= 20)
                {
                    done = true;
                    toreturn = new Point3D(0, 0, 0);
                }
            }

            return toreturn;
        }

        public InvasionController(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            if (Players == null)
                Players = new ArrayList();
            if(Spawn == null)
                Spawn = new ArrayList();

            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write((bool)inprogress);
            writer.Write((int)Killed);
            writer.WriteMobileList(Players);
            writer.WriteMobileList(Spawn);
            writer.Write((int)spawntype);
            writer.Write((Rectangle2D)regionpoint);
            writer.Write((Map)regionmap);
        }

        public override void Deserialize(GenericReader reader)
        {
            Players = new ArrayList();
            Spawn = new ArrayList();

            base.Deserialize(reader);
            int version = reader.ReadInt(); // version
            inprogress = reader.ReadBool();
            Killed = reader.ReadInt();
            Players = reader.ReadMobileList();
            Spawn = reader.ReadMobileList();
            SpawnType = (InvasionSpawnType)reader.ReadInt();
            regionpoint = reader.ReadRect2D();
            regionmap = reader.ReadMap();

            if (inprogress)
                StartInvasion();
        }
    }

    public class InvasionWaveTimer : Timer
    {
        public InvasionController Controller;

        public InvasionWaveTimer(InvasionController c)
            : base(TimeSpan.FromMinutes(5))
        {
            this.Start();
            Controller = c;
        }

        protected override void OnTick()
        {
            if (!Controller.InProgress)
            {
                this.Stop();
                return;
            }

            if (Controller.Spawn.Count < InvasionConfig.WaveAmount)
                DoSpawn(InvasionConfig.WaveAmount);

            this.Stop();
            Controller.WaveTimer = new InvasionWaveTimer(Controller);
            return;
        }

        public void DoSpawn(int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Controller.SpawnType == InvasionSpawnType.Rat)
                {
                    InvasionRat m = new InvasionRat(Controller);
                    Spawn(m);
                }
                else if (Controller.SpawnType == InvasionSpawnType.Orc)
                {
                    InvasionOrc m = new InvasionOrc(Controller);
                    Spawn(m);
                }
                else if (Controller.SpawnType == InvasionSpawnType.Reptile)
                {
                    InvasionReptile m = new InvasionReptile(Controller);
                    Spawn(m);
                }
                else if (Controller.SpawnType == InvasionSpawnType.Arachnid)
                {
                    InvasionArachnid m = new InvasionArachnid(Controller);
                    Spawn(m);
                }
            }
        }

        public void Spawn(Mobile m)
        {
            m.Location = GetRandomRegionPoint();
            m.Map = Controller.regionmap;
            Controller.Spawn.Add(m);
        }

        public Point3D GetRandomRegionPoint()
        {
            bool done = false;
            Point3D toreturn = new Point3D();

            while (!done)
            {
                int x = Utility.RandomMinMax(Controller.regionpoint.X, (Controller.regionpoint.X + Controller.regionpoint.Width));
                int y = Utility.RandomMinMax(Controller.regionpoint.Y, (Controller.regionpoint.Y + Controller.regionpoint.Height));
                int z = Controller.regionmap.GetAverageZ(x, y); ;
                toreturn = new Point3D(x, y, z);

                if (SpellHelper.FindValidSpawnLocation(Controller.regionmap, ref toreturn, true))
                {
                    done = true;
                }
            }

            return toreturn;
        }
    }
}