using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class BladeofTorment : Bokuto
    {
        public override int ArtifactRarity { get { return 83; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ArmorIgnore; } }

        public override int AosStrengthReq { get { return 20; } }
        public override int AosMinDamage { get { return 15; } }
        public override int AosMaxDamage { get { return 18; } }
        public override int AosSpeed { get { return 53; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 13; } }
        public override int OldMaxDamage { get { return 15; } }
        public override int OldSpeed { get { return 53; } }

        public override int DefHitSound { get { return 0x536; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 50; } }

        public bool m_Transformed;
        public Timer m_TransformTimer;
        private DateTime m_End;

        private StatMod m_StatMod0;
		private StatMod m_StatMod1;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Transformed
        {
            get { return m_Transformed; }
            set { m_Transformed = value; }
        }

        [Constructable]
        public BladeofTorment()
        {
            LootType = LootType.Blessed;
            Name = "Blade of Torment";
            Weight = 3.0;
            Hue = 1157;
            Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 15;
			Attributes.WeaponDamage = 45;
			Attributes.AttackChance = 10;
			Attributes.DefendChance = 10;
			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 1;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLeechMana = 25;
        }

        public BladeofTorment(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {

            if (Parent != from)
            {
                from.SendMessage("The Sword must be eqquiped to use.");
            }
            else if (from.Title != "Merlin's Apprentance")
            {
                from.Title = "Merlin's Apprentance";

                from.BoltEffect(0);
                from.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);

                m_StatMod0 = new StatMod(StatType.Str, "MOD0", 10, TimeSpan.Zero);
                m_StatMod1 = new StatMod(StatType.Int, "MOD1", 10, TimeSpan.Zero);

                from.AddStatMod(m_StatMod0);
                from.AddStatMod(m_StatMod1);

                this.WeaponAttributes.HitLeechHits = 65;
                this.WeaponAttributes.HitLeechMana = 45;
                this.Attributes.WeaponSpeed = 30;
            }
            else
            {
                from.BoltEffect(0);
                from.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);

                from.Title = null;

                from.RemoveStatMod("MOD0");
                from.RemoveStatMod("MOD1");

                this.WeaponAttributes.HitLeechHits = 25;
                this.WeaponAttributes.HitLeechMana = 25;
                this.Attributes.WeaponSpeed = 15;
            }
        }

        public override void OnRemoved(object parent)
        {
            if (parent is Mobile)
            {
                Mobile m = (Mobile)parent;
                BaseWeapon weapon = m.Weapon as BaseWeapon;

                m.Title = null;

                m.RemoveStatMod("MOD0");
                m.RemoveStatMod("MOD1");

                this.WeaponAttributes.HitLeechHits = 25;
                this.WeaponAttributes.HitLeechMana = 25;
                this.Attributes.WeaponSpeed = 15;
            }
        }

        public override TimeSpan GetDelay(Mobile m)
        {
            int speed = this.Speed;

            if (speed == 0)
                return TimeSpan.FromHours(1.0);

            double delayInSeconds;


            if (Core.AOS)
            {
                int v = (m.Stam + 100) * speed;

                int bonus = AosAttributes.GetValue(m, AosAttribute.WeaponSpeed);

                if (Spells.Chivalry.DivineFurySpell.UnderEffect(m))
                    bonus += 10;

               // if (SkillHandlers.Discordance.GetScalar(m, ref discordanceScalar))
               //     bonus += (int)(discordanceScalar * 100);

                v += AOS.Scale(v, bonus);

                if (v <= 0)
                    v = 1;

                delayInSeconds = Math.Floor(40000.0 / v) * 0.5;
                if (delayInSeconds < 1.0)
                    delayInSeconds = .7;
            }
            else
            {
                int v = (m.Stam + 100) * speed;

                if (v <= 0)
                    v = 1;

                delayInSeconds = 15000.0 / v;
            }

            return TimeSpan.FromSeconds(delayInSeconds);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}