
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Corpse Of Talon")]
    public class Talon2 : BaseCreature
    {
        public static TimeSpan TalkDelay = TimeSpan.FromSeconds(10.0); //the delay between talks is 10 seconds
        public DateTime m_NextTalk;

        public virtual bool IsInvulnerable { get { return true; } }
        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

        [Constructable]
        public Talon2()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Title = "Student of the arts";
            Name = "Talon";
            Body = 400;
            Hue = 33770;

            Blessed = true;

            SetStr(900, 1100);
            SetDex(291, 315);
            SetInt(600, 720);

            SetHits(5520, 5725);

            SetDamage(10, 15);

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
            SetSkill(SkillName.Magery, 140.0, 150.0);

            Fame = 2500;
            Karma = -2500;

            VirtualArmor = 50;

            int hairHue = 0;
            Blessed = true;

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

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (DateTime.Now >= m_NextTalk) // check if it's time to talk & mobile in range & in los.
            {
                m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 

                m.FixedParticles(0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot);
                Delete();

            }
        }
        
        public Talon2(Serial serial)
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
    }
}