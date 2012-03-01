using System;
using Server;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;

namespace Server.Mobiles
{
    [CorpseName("a lich corpse")]
    public class BlackLich : BaseCreature
    {
        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.MortalStrike;
        }

        [Constructable]
        public BlackLich()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "the black lich";
            Title = "master necro mage";
            Body = 24;
            Hue = 1;

            BaseSoundID = 0x3E9;

            SetStr(1000);
            SetDex(500);
            SetInt(1000);

            SetHits(1000);

            SetDamage(18, 22);

            SetDamageType(ResistanceType.Physical, 60);
            SetDamageType(ResistanceType.Cold, 50);

            SetResistance(ResistanceType.Physical, 70);
            SetResistance(ResistanceType.Fire, 10);
            SetResistance(ResistanceType.Cold, 70);
            SetResistance(ResistanceType.Energy, 50);
            SetResistance(ResistanceType.Poison, 70);

            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Magery, 120.0);
            SetSkill(SkillName.EvalInt, 120.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Anatomy, 120.0);
            SetSkill(SkillName.Wrestling, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.DetectHidden, 120.0);
            SetSkill(SkillName.Necromancy, 120.0);

            Fame = 25000;
            Karma = -25000;

            VirtualArmor = 65;

            PackItem(new Gold(Utility.RandomMinMax(8000, 15000)));
            PackItem(new BlackLichStaff());
            PackItem(new GraveDust(Utility.RandomMinMax(50, 80)));
            PackItem(new DaemonBlood(Utility.RandomMinMax(50, 80)));
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 12);
            AddLoot(LootPack.MedScrolls, 3);
        }

        public int originalbody;
        public string name;
        public Mobile spawn;
        public Point3D spawnloc;
        public Map spawnmap;
        public Point3D thisloc;
        public Map thismap;
        public Point3D mobloc;
        public Map mobmap;
        public Mobile owner;

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            name = from.Name;

            if (from != null)
            {
                if (0.15 > Utility.RandomDouble())//transformation
                {
                    if (from is BaseCreature)
                    {
                        from.Hits -= Utility.RandomMinMax(50, 150);
                        from.PlaySound(0x19C);
                    }
                    else if (from is PlayerMobile)
                    {

                        if (from != null)
                        {
                            if (from.BodyValue == 400)
                            {
                                originalbody = 400;
                            }
                            else if (from.BodyValue == 401)
                            {
                                originalbody = 401;
                            }
                            else
                            {
                            }

                            if (from != null)
                            {
                                from.BodyValue = Utility.RandomList(31, 24, 26, 50, 56, 147, 3);
                                from.SendMessage("{0}, you have been transformed into a undead!", name);
                                BodyReturnTimer m_timer = new BodyReturnTimer(from, originalbody);
                                m_timer.Start();
                                from.PlaySound(0x19C);


                                if (from.Mounted == true)
                                {

                                        IMount mount = from.Mount;

                                        if (mount != null)
                                        {
                                            mount.Rider = null;

                                            from.SendLocalizedMessage(1040023); 

                                            BaseMount.SetMountPrevention(from, BlockMountType.Dazed, TimeSpan.FromSeconds(3.0));

                                            BaseMount.SetMountPrevention(from, BlockMountType.Dazed, TimeSpan.FromSeconds(20.0));
                                        }
                                    
                                }
                                else if (from.Mounted == false)
                                {
                                    from.SendMessage("You are dazed by a critical hit!");
                                    BaseMount.SetMountPrevention(from, BlockMountType.Dazed, TimeSpan.FromSeconds(20.0));
                                }
                                else
                                {
                                    from.SendMessage("You are dazed by a critical hit!");
                                    BaseMount.SetMountPrevention(from, BlockMountType.Dazed, TimeSpan.FromSeconds(20.0));
                                }
                            }

                        }
                    }
                    else
                    {
                        from.Hits -= Utility.RandomMinMax(50, 150);
                        from.PlaySound(0x19C);
                    }
                }

                if (0.10 > Utility.RandomDouble())//spawn
                {
                    spawn = new UndeadSpawn();
                    spawnmap = this.Map;
                    spawnloc = new Point3D(this.X + Utility.RandomMinMax(0, 4), this.Y + Utility.RandomMinMax(0, 4), this.Z);
                    spawn.MoveToWorld(spawnloc, spawnmap);
                    Effects.PlaySound(spawnloc, spawnmap, 0x1FB);
                    Effects.SendLocationParticles(EffectItem.Create(spawnloc, spawnmap, EffectItem.DefaultDuration), 0x3789, 1, 40, 0x3F, 3, 9907, 0);
                    spawn.Combatant = from;
                }

                if (0.10 > Utility.RandomDouble())//wither
                {
                    ArrayList targets = new ArrayList();

                    foreach (Mobile m in this.GetMobilesInRange(4))
                    {
                        if (m is UndeadSpawn)
                        {
                        }
                        else
                        {
                            targets.Add(m);
                        }
                    }

                    thisloc = new Point3D(this.X, this.Y, this.Z);
                    thismap = this.Map;

                    Effects.PlaySound(thisloc, thismap, 0x1FB);
                    Effects.PlaySound(thisloc, thismap, 0x10B);
                    Effects.SendLocationParticles(EffectItem.Create(thisloc, thismap, EffectItem.DefaultDuration), 0x37CC, 1, 40, 97, 3, 9917, 0);

                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        m.Hits -= amount;

                        this.Mana -= 5;
                    }
                }
                else if (0.8 > Utility.RandomDouble())
                {
                    ArrayList targets = new ArrayList();

                    foreach (Mobile m in this.GetMobilesInRange(4))
                    {
                        targets.Add(m);
                    }

                    thisloc = new Point3D(this.X, this.Y, this.Z);
                    thismap = this.Map;

                    Effects.PlaySound(thisloc, thismap, 0x1FB);
                    Effects.PlaySound(thisloc, thismap, 0x10B);
                    Effects.SendLocationParticles(EffectItem.Create(thisloc, thismap, EffectItem.DefaultDuration), 0x37CC, 1, 40, 97, 3, 9917, 0);

                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        m.Hits -= amount;

                        this.Mana -= 5;
                    }
                }
                else
                {
                    ArrayList targets = new ArrayList();

                    foreach (Mobile m in this.GetMobilesInRange(4))
                    {
                        targets.Add(m);
                    }

                    thisloc = new Point3D(this.X, this.Y, this.Z);
                    thismap = this.Map;

                    Effects.PlaySound(thisloc, thismap, 0x1FB);
                    Effects.PlaySound(thisloc, thismap, 0x10B);
                    Effects.SendLocationParticles(EffectItem.Create(thisloc, thismap, EffectItem.DefaultDuration), 0x37CC, 1, 40, 97, 3, 9917, 0);

                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        m.Hits -= Utility.RandomMinMax(10, 20);

                        this.Mana -= 5;
                    }
                }

                if(0.2 > Utility.RandomDouble())//animate dead
                {
                    ArrayList corpses = new ArrayList();

                    foreach (Item item in this.GetItemsInRange(4))
                    {

                        if (item is Corpse)
                        {
                                corpses.Add(item);
                        }

                    }

                    for (int i = 0; i < corpses.Count; ++i)
                    {
                        Item corpse = (Item)corpses[i];

                        mobloc = new Point3D(corpse.X, corpse.Y, corpse.Z);
                        mobmap = corpse.Map;
                        spawn = new UndeadSpawn();
                        spawn.Name = corpse.Name;
                        spawn.Title = "wrongly resurected";
                        spawn.MoveToWorld(mobloc, mobmap);
                        spawn.Combatant = from;

                        Effects.PlaySound(mobloc, mobmap, 0x1FB);
                        Effects.SendLocationParticles(EffectItem.Create(mobloc, mobmap, EffectItem.DefaultDuration), 0x3789, 1, 40, 0x3F, 3, 9907, 0);

                        Corpse corpseb = (Corpse)corpse;

                        owner = corpseb.m_Owner;

                        if (owner is PlayerMobile)
                        {
                        }
                        else
                        {
                            corpseb.Delete();
                        }
                    }

                }

            }
        }

        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool BleedImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public BlackLich( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

    }

    public class BodyReturnTimer : Timer
    {
        private int m_body;
        private Mobile m_from;

        public BodyReturnTimer(Mobile from, int originalbody)
            : base(TimeSpan.FromSeconds(20))
        {
            m_from = from;
            m_body = originalbody;

            Priority = TimerPriority.OneSecond;
        }

        protected override void OnTick()
        {
            if (m_from == null || m_from.Deleted)
            {
                Stop();
                return;
            }

            m_from.BodyValue = m_body;
            m_from.SendMessage("You have returned to your normal figure.");
        }
    }

    [CorpseName("a undead corpse")]
    public class UndeadSpawn : Lich
    {

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.MortalStrike;
        }

        [Constructable]
        public UndeadSpawn()
        {
            Name = "undead spawn";
            Body = Utility.RandomList(31, 24, 26, 50, 56, 147, 3);

            SetResistance(ResistanceType.Physical, 60);
            SetResistance(ResistanceType.Fire, 0);
            SetResistance(ResistanceType.Cold, 60);
            SetResistance(ResistanceType.Energy, 40);
            SetResistance(ResistanceType.Poison, 60);
        }

        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public UndeadSpawn( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

    }

}