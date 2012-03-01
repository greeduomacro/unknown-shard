
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
    [CorpseName("Corpse Of Talon")]
    public class Talon3 : BaseCreature
    {

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

        [Constructable]
        public Talon3()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Title = "Student of the arts";
            Name = "Talon";
            Body = 400;
            Hue = 33770;

            SetStr(500, 600);
            SetDex(291, 315);
            SetInt(600, 720);

            SetHits(920, 1125);

            SetDamage(6, 8);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 1);
            SetResistance(ResistanceType.Fire, 0, 1);
            SetResistance(ResistanceType.Poison, 0, 1);
            SetResistance(ResistanceType.Energy, 0, 1);

            SetSkill(SkillName.EvalInt, 85.0, 100.0);
            SetSkill(SkillName.Tactics, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 75.0, 97.5);
            SetSkill(SkillName.Wrestling, 20.2, 60.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Focus, 120.0);
            SetSkill(SkillName.Magery, 90.0, 100.0);

            Fame = 2500;
            Karma = -2500;

            VirtualArmor = 50;

            ME me = new ME();
            me.Hue = 1154;
            me.Movable = false;
            AddItem(me);

            int hairHue = 0;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }
            switch (Utility.Random(1))
            {
                case 0: AddItem(new ShortBeard(hairHue)); break;
            }

            AddItem(new Server.Items.HoodedShroudOfShadows(0));
            AddItem(new Server.Items.Sandals(0));

            GoldNecklace goldnecklace = new GoldNecklace();
            goldnecklace.Hue = 0;
            goldnecklace.Movable = false;
            AddItem(goldnecklace);

            GoldRing goldring = new GoldRing();
            goldring.Hue = 0;
            goldring.Movable = false;
            AddItem(goldring);

            Backpack backpack = new Backpack();
            backpack.Hue = 1150;
            backpack.Movable = false;
            AddItem(backpack);

        }

        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override bool AlwaysMurderer { get { return true; } }

        public override void GenerateLoot()
        {
            PackGold(9575);
            AddLoot(LootPack.MedScrolls, 2);
            AddLoot(LootPack.Gems, 5);
        }

        public Talon3(Serial serial)
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
        public override void OnDeath(Container c)
        {
            Talon4 t4 = new Talon4();
            t4.Map = this.Map;
            t4.Location = this.Location;
            
            base.OnDeath(c);
            c.Delete();
        }
    }
}