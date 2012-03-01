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

namespace Server.Mobiles
{
    public class InvasionSpawn : BaseCreature
    {
        public InvasionController Controller;

        public InvasionSpawn(InvasionController c)
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Controller = c;
        }

        public override void OnDeath(Container c)
        {
            Controller.OnKill(this);
            c.DropItem(new Gold((int)Utility.RandomMinMax(60, 250)));
            base.OnDeath(c);
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (Controller == null)
                this.Delete();

            if (m.Region == null)
            {
                if(Controller.Spawn.Contains(m))
                    Controller.Spawn.Remove(this);
                this.Delete();

                return;
            }

            if (this.Region is InvasionRegion) { }
            else
            {
                if(Controller.Spawn.Contains(m))
                    Controller.Spawn.Remove(this);
                this.Delete();

                return;
            }

            base.OnMovement(m, oldLocation);
        }

        public InvasionSpawn(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write((InvasionController)Controller);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt(); // version
            Controller = (InvasionController)reader.ReadItem();
        }
    }

    public class InvasionRat : InvasionSpawn
    {
        public InvasionController Controller;

        public InvasionRat(InvasionController c)
            : base(c)
        {
            Controller = c;
            RandomSpawn();
        }

        public void RandomSpawn()
        {
            switch (Utility.Random(1, 3))
            {
                case 1:
                    {
                        Name = "a rat";
                        Body = 238;
                        BaseSoundID = 0xCC;

                        SetStr(9);
                        SetDex(35);
                        SetInt(5);

                        SetHits(6);
                        SetMana(0);

                        SetDamage(1, 2);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 5, 10);
                        SetResistance(ResistanceType.Poison, 5, 10);

                        SetSkill(SkillName.MagicResist, 4.0);
                        SetSkill(SkillName.Tactics, 4.0);
                        SetSkill(SkillName.Wrestling, 4.0);

                        Fame = 150;
                        Karma = -150;

                        VirtualArmor = 6;

                        Tamable = false;
                        ControlSlots = 1;
                        MinTameSkill = -0.9;

                        break;
                    }
                case 2:
                    {
                        Name = NameList.RandomName("ratman");
                        Body = 42;
                        BaseSoundID = 437;

                        SetStr(96, 120);
                        SetDex(81, 100);
                        SetInt(36, 60);

                        SetHits(58, 72);

                        SetDamage(4, 5);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 25, 30);
                        SetResistance(ResistanceType.Fire, 10, 20);
                        SetResistance(ResistanceType.Cold, 10, 20);
                        SetResistance(ResistanceType.Poison, 10, 20);
                        SetResistance(ResistanceType.Energy, 10, 20);

                        SetSkill(SkillName.MagicResist, 35.1, 60.0);
                        SetSkill(SkillName.Tactics, 50.1, 75.0);
                        SetSkill(SkillName.Wrestling, 50.1, 75.0);

                        Fame = 1500;
                        Karma = -1500;

                        VirtualArmor = 28;

                        break;
                    }
                case 3:
                    {
                        Name = NameList.RandomName("ratman");
                        Body = 0x8E;
                        BaseSoundID = 437;

                        SetStr(146, 180);
                        SetDex(101, 130);
                        SetInt(116, 140);

                        SetHits(88, 108);

                        SetDamage(4, 10);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 40, 55);
                        SetResistance(ResistanceType.Fire, 10, 20);
                        SetResistance(ResistanceType.Cold, 10, 20);
                        SetResistance(ResistanceType.Poison, 10, 20);
                        SetResistance(ResistanceType.Energy, 10, 20);

                        SetSkill(SkillName.Anatomy, 60.2, 100.0);
                        SetSkill(SkillName.Archery, 80.1, 90.0);
                        SetSkill(SkillName.MagicResist, 65.1, 90.0);
                        SetSkill(SkillName.Tactics, 50.1, 75.0);
                        SetSkill(SkillName.Wrestling, 50.1, 75.0);

                        Fame = 6500;
                        Karma = -6500;

                        VirtualArmor = 56;

                        AddItem(new Bow());
                        PackItem(new Arrow(Utility.RandomMinMax(50, 70)));

                        break;
                    }
            }
        }

        public InvasionRat(Serial serial)
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
            int version = reader.ReadInt(); // version
        }
    }

    public class InvasionOrc : InvasionSpawn
    {
        public InvasionController Controller;

        public InvasionOrc(InvasionController c)
            : base(c)
        {
            Controller = c;
            RandomSpawn();
        }

        public void RandomSpawn()
        {
            switch (Utility.Random(1, 3))
            {
                case 1:
                    {
                        Name = NameList.RandomName("orc");
                        Body = 17;
                        BaseSoundID = 0x45A;

                        SetStr(96, 120);
                        SetDex(81, 105);
                        SetInt(36, 60);

                        SetHits(58, 72);

                        SetDamage(5, 7);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 25, 30);
                        SetResistance(ResistanceType.Fire, 20, 30);
                        SetResistance(ResistanceType.Cold, 10, 20);
                        SetResistance(ResistanceType.Poison, 10, 20);
                        SetResistance(ResistanceType.Energy, 20, 30);

                        SetSkill(SkillName.MagicResist, 50.1, 75.0);
                        SetSkill(SkillName.Tactics, 55.1, 80.0);
                        SetSkill(SkillName.Wrestling, 50.1, 70.0);

                        Fame = 1500;
                        Karma = -1500;

                        VirtualArmor = 28;

                        switch (Utility.Random(20))
                        {
                            case 0: PackItem(new Scimitar()); break;
                            case 1: PackItem(new Katana()); break;
                            case 2: PackItem(new WarMace()); break;
                            case 3: PackItem(new WarHammer()); break;
                            case 4: PackItem(new Kryss()); break;
                            case 5: PackItem(new Pitchfork()); break;
                        }

                        PackItem(new ThighBoots());

                        switch (Utility.Random(3))
                        {
                            case 0: PackItem(new Ribs()); break;
                            case 1: PackItem(new Shaft()); break;
                            case 2: PackItem(new Candle()); break;
                        }

                        if (0.2 > Utility.RandomDouble())
                            PackItem(new BolaBall());

                        break;
                    }
                case 2:
                    {
                        Name = "an orcish lord";
                        Body = 138;
                        BaseSoundID = 0x45A;

                        SetStr(147, 215);
                        SetDex(91, 115);
                        SetInt(61, 85);

                        SetHits(95, 123);

                        SetDamage(4, 14);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 25, 35);
                        SetResistance(ResistanceType.Fire, 30, 40);
                        SetResistance(ResistanceType.Cold, 20, 30);
                        SetResistance(ResistanceType.Poison, 30, 40);
                        SetResistance(ResistanceType.Energy, 30, 40);

                        SetSkill(SkillName.MagicResist, 70.1, 85.0);
                        SetSkill(SkillName.Swords, 60.1, 85.0);
                        SetSkill(SkillName.Tactics, 75.1, 90.0);
                        SetSkill(SkillName.Wrestling, 60.1, 85.0);

                        Fame = 2500;
                        Karma = -2500;

                        switch (Utility.Random(5))
                        {
                            case 0: PackItem(new Lockpick()); break;
                            case 1: PackItem(new MortarPestle()); break;
                            case 2: PackItem(new Bottle()); break;
                            case 3: PackItem(new RawRibs()); break;
                            case 4: PackItem(new Shovel()); break;
                        }

                        PackItem(new RingmailChest());

                        if (0.3 > Utility.RandomDouble())
                            PackItem(Loot.RandomPossibleReagent());

                        if (0.2 > Utility.RandomDouble())
                            PackItem(new BolaBall());

                        break;
                    }
                case 3:
                    {
                        Name = "an ogre";
                        Body = 1;
                        BaseSoundID = 427;

                        SetStr(166, 195);
                        SetDex(46, 65);
                        SetInt(46, 70);

                        SetHits(100, 117);
                        SetMana(0);

                        SetDamage(9, 11);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 30, 35);
                        SetResistance(ResistanceType.Fire, 15, 25);
                        SetResistance(ResistanceType.Cold, 15, 25);
                        SetResistance(ResistanceType.Poison, 15, 25);
                        SetResistance(ResistanceType.Energy, 25);

                        SetSkill(SkillName.MagicResist, 55.1, 70.0);
                        SetSkill(SkillName.Tactics, 60.1, 70.0);
                        SetSkill(SkillName.Wrestling, 70.1, 80.0);

                        Fame = 3000;
                        Karma = -3000;

                        VirtualArmor = 32;

                        PackItem(new Club());

                        break;
                    }
            }
        }

        public InvasionOrc(Serial serial)
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
            int version = reader.ReadInt(); // version
        }
    }

    public class InvasionReptile : InvasionSpawn
    {
        public InvasionController Controller;

        public InvasionReptile(InvasionController c)
            : base(c)
        {
            Controller = c;
            RandomSpawn();
        }

        public void RandomSpawn()
        {
            switch (Utility.Random(1, 3))
            {
                case 1:
                    {
                        Name = "a drake";
                        Body = Utility.RandomList(60, 61);
                        BaseSoundID = 362;

                        SetStr(401, 430);
                        SetDex(133, 152);
                        SetInt(101, 140);

                        SetHits(241, 258);

                        SetDamage(11, 17);

                        SetDamageType(ResistanceType.Physical, 80);
                        SetDamageType(ResistanceType.Fire, 20);

                        SetResistance(ResistanceType.Physical, 45, 50);
                        SetResistance(ResistanceType.Fire, 50, 60);
                        SetResistance(ResistanceType.Cold, 40, 50);
                        SetResistance(ResistanceType.Poison, 20, 30);
                        SetResistance(ResistanceType.Energy, 30, 40);

                        SetSkill(SkillName.MagicResist, 65.1, 80.0);
                        SetSkill(SkillName.Tactics, 65.1, 90.0);
                        SetSkill(SkillName.Wrestling, 65.1, 80.0);

                        Fame = 5500;
                        Karma = -5500;

                        VirtualArmor = 46;

                        Tamable = true;
                        ControlSlots = 2;
                        MinTameSkill = 84.3;

                        PackReg(3);

                        break;
                    }
                case 2:
                    {
                        Name = NameList.RandomName("lizardman");
                        Body = Utility.RandomList(35, 36);
                        BaseSoundID = 417;

                        SetStr(96, 120);
                        SetDex(86, 105);
                        SetInt(36, 60);

                        SetHits(58, 72);

                        SetDamage(5, 7);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 25, 30);
                        SetResistance(ResistanceType.Fire, 5, 10);
                        SetResistance(ResistanceType.Cold, 5, 10);
                        SetResistance(ResistanceType.Poison, 10, 20);

                        SetSkill(SkillName.MagicResist, 35.1, 60.0);
                        SetSkill(SkillName.Tactics, 55.1, 80.0);
                        SetSkill(SkillName.Wrestling, 50.1, 70.0);

                        Fame = 1500;
                        Karma = -1500;

                        VirtualArmor = 28;

                        break;
                    }
                case 3:
                    {
                        Name = "a ophidian knight";
                        Body = 86;
                        BaseSoundID = 634;

                        SetStr(417, 595);
                        SetDex(166, 175);
                        SetInt(46, 70);

                        SetHits(266, 342);
                        SetMana(0);

                        SetDamage(16, 19);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 35, 40);
                        SetResistance(ResistanceType.Fire, 30, 40);
                        SetResistance(ResistanceType.Cold, 35, 45);
                        SetResistance(ResistanceType.Poison, 90, 100);
                        SetResistance(ResistanceType.Energy, 35, 45);

                        SetSkill(SkillName.Poisoning, 60.1, 80.0);
                        SetSkill(SkillName.MagicResist, 65.1, 80.0);
                        SetSkill(SkillName.Tactics, 90.1, 100.0);
                        SetSkill(SkillName.Wrestling, 90.1, 100.0);

                        Fame = 10000;
                        Karma = -10000;

                        VirtualArmor = 40;

                        PackItem(new LesserPoisonPotion());

                        break;
                    }
            }
        }

        public InvasionReptile(Serial serial)
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
            int version = reader.ReadInt(); // version
        }
    }

    public class InvasionArachnid : InvasionSpawn
    {
        public InvasionController Controller;

        public InvasionArachnid(InvasionController c)
            : base(c)
        {
            Controller = c;
            RandomSpawn();
        }

        public void RandomSpawn()
        {
            switch (Utility.Random(1, 3))
            {
                case 1:
                    {
                        Name = "a giant spider";
                        Body = 28;
                        BaseSoundID = 0x388;

                        SetStr(76, 100);
                        SetDex(76, 95);
                        SetInt(36, 60);

                        SetHits(46, 60);
                        SetMana(0);

                        SetDamage(5, 13);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 15, 20);
                        SetResistance(ResistanceType.Poison, 25, 35);

                        SetSkill(SkillName.Poisoning, 60.1, 80.0);
                        SetSkill(SkillName.MagicResist, 25.1, 40.0);
                        SetSkill(SkillName.Tactics, 35.1, 50.0);
                        SetSkill(SkillName.Wrestling, 50.1, 65.0);

                        Fame = 600;
                        Karma = -600;

                        VirtualArmor = 16;

                        Tamable = true;
                        ControlSlots = 1;
                        MinTameSkill = 59.1;

                        PackItem(new SpidersSilk(5));

                        break;
                    }
                case 2:
                    {
                        Name = "a terathan drone";
                        Body = 71;
                        BaseSoundID = 594;

                        SetStr(36, 65);
                        SetDex(96, 145);
                        SetInt(21, 45);

                        SetHits(22, 39);
                        SetMana(0);

                        SetDamage(6, 12);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 20, 25);
                        SetResistance(ResistanceType.Fire, 10, 20);
                        SetResistance(ResistanceType.Cold, 15, 25);
                        SetResistance(ResistanceType.Poison, 30, 40);
                        SetResistance(ResistanceType.Energy, 15, 25);

                        SetSkill(SkillName.Poisoning, 40.1, 60.0);
                        SetSkill(SkillName.MagicResist, 30.1, 45.0);
                        SetSkill(SkillName.Tactics, 30.1, 50.0);
                        SetSkill(SkillName.Wrestling, 40.1, 50.0);

                        Fame = 2000;
                        Karma = -2000;

                        VirtualArmor = 24;

                        PackItem(new SpidersSilk(2));

                        break;
                    }
                case 3:
                    {
                        Name = "a terathan warrior";
                        Body = 70;
                        BaseSoundID = 589;

                        SetStr(166, 215);
                        SetDex(96, 145);
                        SetInt(41, 65);

                        SetHits(100, 129);
                        SetMana(0);

                        SetDamage(7, 17);

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 30, 35);
                        SetResistance(ResistanceType.Fire, 20, 30);
                        SetResistance(ResistanceType.Cold, 25, 35);
                        SetResistance(ResistanceType.Poison, 30, 40);
                        SetResistance(ResistanceType.Energy, 25, 35);

                        SetSkill(SkillName.Poisoning, 60.1, 80.0);
                        SetSkill(SkillName.MagicResist, 60.1, 75.0);
                        SetSkill(SkillName.Tactics, 80.1, 100.0);
                        SetSkill(SkillName.Wrestling, 80.1, 90.0);

                        Fame = 4000;
                        Karma = -4000;

                        VirtualArmor = 30;

                        break;
                    }
            }
        }

        public InvasionArachnid(Serial serial)
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
            int version = reader.ReadInt(); // version
        }
    }
}