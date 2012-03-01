using System;
using System.Collections;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("The Corpse Of Skeletal Horse")]
    public class SkeletalHorse : BaseWarHorse
    {

        [Constructable]
        public SkeletalHorse()
            : base(0x78, 0x3EAF, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {

            BaseSoundID = 0xA8;

            SetStr(100);
            SetDex(100);
            SetInt(100);

            SetHits(400);
            SetMana(150);
            SetStam(150);

            SetDamage(5, 15);

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
            Karma = -2500;

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 100.0;

            Name = "Skeletal Horse";
            Hue = 1950;

            VirtualArmor = 10;
        }
        public override bool AutoDispel { get { return true; } }
	public override bool AlwaysMurderer { get { return true; } }
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

        public SkeletalHorse(Serial serial)
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