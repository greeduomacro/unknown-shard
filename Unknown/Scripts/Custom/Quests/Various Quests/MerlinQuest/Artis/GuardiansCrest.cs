  /////////////////////////////
 //////  LostSinner  /////////
/////////////////////////////

using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class GuardianCrest : BaseShield
    {
        public bool m_Transformed;
        public Timer m_TransformTimer;
        private DateTime m_End;

        private StatMod m_StatMod5;

        public override int BasePhysicalResistance { get { return 7; } }
        public override int BaseFireResistance { get { return 7; } }
        public override int BaseColdResistance { get { return 7; } }
        public override int BasePoisonResistance { get { return 7; } }
        public override int BaseEnergyResistance { get { return 7; } }

        public override int ArtifactRarity { get { return 73; } }

        public override int InitMinHits { get { return 1500; } }
        public override int InitMaxHits { get { return 1500; } }

        public override int AosStrReq { get { return 70; } }
        public override int OldStrReq { get { return 70; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Transformed
        {
            get { return m_Transformed; }
            set { m_Transformed = value; }
        }

		[Constructable]
        public GuardianCrest()
            : base(0x1BC3)
		{
            LootType = LootType.Blessed;
            Name = "Guardian's Crest";
			Hue = 1157;
			Attributes.WeaponDamage = 5;
			Attributes.ReflectPhysical = 5;
            Attributes.DefendChance = 15;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 5;
			Attributes.NightSight = 1;
		}

        public override void OnDoubleClick(Mobile from)
        {
            if (Parent != from)
            {
                if( this.ItemID == 7107 ) this.ItemID = 7108;
				else if( this.ItemID == 7108 ) this.ItemID = 7107;
            }
            else if (from.Title != "Gaurdian of the Ages")
            {
                if (ItemID == 7107)
                {
                    if (from.Karma <= 0)
                    {
                        from.Title = "Gaurdian of the Ages";
                        from.BodyMod = 753;
                        from.HueMod = 1109;

                        from.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);

                        m_StatMod5 = new StatMod(StatType.Str, "MOD5", 10, TimeSpan.Zero);

                        from.AddStatMod(m_StatMod5);

                        this.Attributes.WeaponDamage = 15;
                        this.Attributes.ReflectPhysical = 15;
                        this.Attributes.DefendChance = 25;
                        this.Attributes.WeaponSpeed = 5;
                        this.Attributes.SpellChanneling = 1;
                        this.Attributes.SpellDamage = 10;
                        this.Attributes.NightSight = 1;
                    }
                    else
                    {

                        from.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);

                        m_StatMod5 = new StatMod(StatType.Str, "MOD5", 10, TimeSpan.Zero);

                        from.AddStatMod(m_StatMod5);

                        this.Attributes.WeaponDamage = 15;
                        this.Attributes.ReflectPhysical = 15;
                        this.Attributes.DefendChance = 25;
                        this.Attributes.WeaponSpeed = 5;
                        this.Attributes.SpellChanneling = 1;
                        this.Attributes.SpellDamage = 10;
                        this.Attributes.NightSight = 1;
                    }
                }
                else if (ItemID == 7108)
                {
                    if (from.Karma >= 0)
                    {

                        from.Title = "Gaurdian of the Ages";
                        from.BodyMod = 752;
                        from.HueMod = 1157;

                        from.FixedParticles(0x373A, 1, 17, 1108, 7, 9914, 0);
                        from.FixedParticles(0x376A, 1, 22, 67, 7, 9502, 0);

                        m_StatMod5 = new StatMod(StatType.Str, "MOD5", 10, TimeSpan.Zero);

                        from.AddStatMod(m_StatMod5);

                        this.Attributes.WeaponDamage = 15;
                        this.Attributes.ReflectPhysical = 15;
                        this.Attributes.DefendChance = 25;
                        this.Attributes.WeaponSpeed = 5;
                        this.Attributes.SpellChanneling = 1;
                        this.Attributes.SpellDamage = 10;
                        this.Attributes.NightSight = 1;
                    }
                    else
                    {
                        from.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);

                        m_StatMod5 = new StatMod(StatType.Str, "MOD5", 10, TimeSpan.Zero);

                        from.AddStatMod(m_StatMod5);

                        this.Attributes.WeaponDamage = 15;
                        this.Attributes.ReflectPhysical = 15;
                        this.Attributes.DefendChance = 25;
                        this.Attributes.WeaponSpeed = 5;
                        this.Attributes.SpellChanneling = 1;
                        this.Attributes.SpellDamage = 10;
                        this.Attributes.NightSight = 1;
                    }
                }
            }
            else
            {
                from.BoltEffect(0);
                from.FixedParticles(0x376A, 1, 29, 0x47D, 2, 9962, 0);

                from.HueMod = -1;
                from.Title = null;
                from.BodyMod = 0x0;

                from.RemoveStatMod("MOD5");

                this.Attributes.WeaponDamage = 5;
                this.Attributes.ReflectPhysical = 5;
                this.Attributes.DefendChance = 15;
                this.Attributes.WeaponSpeed = 0;
                this.Attributes.SpellChanneling = 1;
                this.Attributes.SpellDamage = 5;
                this.Attributes.NightSight = 1;
            }
        }

        public override void OnRemoved(object parent)
        {
            if (parent is Mobile)
            {
                Mobile m = (Mobile)parent;

                m.Title = null;
                m.BodyMod = 0x0;
                m.HueMod = -1;

                m.RemoveStatMod("MOD5");

                this.Attributes.WeaponDamage = 5;
                this.Attributes.ReflectPhysical = 5;
                this.Attributes.DefendChance = 15;
                this.Attributes.WeaponSpeed = 0;
                this.Attributes.SpellChanneling = 1;
                this.Attributes.SpellDamage = 5;
                this.Attributes.NightSight = 1;
            }
        }
        public GuardianCrest(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}