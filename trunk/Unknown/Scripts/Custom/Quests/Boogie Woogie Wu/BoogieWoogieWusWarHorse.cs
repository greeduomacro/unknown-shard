// Created by BoogieWoogieWu aka Wicked2006


using System;
using System.Collections;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("The Corpse Of Boogie Woogie Wu War Horse")]
    public class BoogieWoogieWusWarHorse : BaseWarHorse
    {

        [Constructable]
        public BoogieWoogieWusWarHorse()
            : base(0x78, 0x3EAF, AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {

            BaseSoundID = 0xA8;

            SetStr(450, 750);
            SetDex(300, 360);
            SetInt(360, 600);

            SetHits(1000, 2000);
            SetMana(120, 160);
            SetStam(140, 170);

            SetDamage(15, 20);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Fire, 50);

            SetResistance(ResistanceType.Physical, 75, 80);
            SetResistance(ResistanceType.Poison, 80, 90);
            SetResistance(ResistanceType.Energy, 60, 80);
            SetResistance(ResistanceType.Cold, 30, 50);
            SetResistance(ResistanceType.Fire, 80, 100);


            SetSkill(SkillName.MagicResist, 70.0, 90.0);
            SetSkill(SkillName.Tactics, 78.0, 100.0);
            SetSkill(SkillName.Wrestling, 100.0, 110.0);
            SetSkill(SkillName.Poisoning, 75.0, 90.0);
            SetSkill(SkillName.Magery, 85.0, 100.0);
            SetSkill(SkillName.EvalInt, 85.0, 100.0);
            SetSkill(SkillName.Meditation, 85.0, 100.0);

            Fame = 800;
            Karma = -1500;

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 100.0;

            Name = "Boogie Woogie Wus War Horse";
            Hue = 1;

            VirtualArmor = 10;
        }
        public override bool AutoDispel { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        // TODO: "This creature can breath chaos.

        public void DrainLife()
        {
            ArrayList list = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(3))
            {
                if (m == this || !CanBeHarmful(m))
                    continue;

                if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
                    list.Add(m);
                if (m is BaseCreature)
                    list.Add(m);
                else if (m.Player)
                    list.Add(m);

            }

            foreach (Mobile m in list)
            {
                DoHarmful(m);

                m.FixedParticles(0x374A, 10, 15, 5013, 0x496, 0, EffectLayer.Waist);
                m.PlaySound(0x231);

                m.SendMessage("He Sucks Your Life Out!");

                int toDrain = Utility.RandomMinMax(30, 50);

                Hits += toDrain;
                m.Damage(toDrain, this);
            }
        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (0.33 >= Utility.RandomDouble())
                DrainLife();
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if (0.33 >= Utility.RandomDouble())
                DrainLife();
        }

        public BoogieWoogieWusWarHorse(Serial serial)
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