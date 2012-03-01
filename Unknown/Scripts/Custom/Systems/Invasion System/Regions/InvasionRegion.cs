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

namespace Server.Regions
{
    public class InvasionRegion : BaseRegion
    {
        public InvasionController Controller;

        public InvasionRegion(InvasionController c)
            : base("InvasionRegion", c.RegionMap, 100, c.RegionPoint)
        {
            Controller = c;
            this.Register();
        }

        public override void OnRegister()
        {
            Console.WriteLine("Invasion Region Registered");
            base.OnRegister();
        }

        public override bool OnDoubleClick(Mobile m, object o)
        {
            return base.OnDoubleClick(m, o);
        }

        public override void OnEnter(Mobile m)
        {
            if (m is PlayerMobile && !Controller.Players.Contains(m))
            {
                Controller.Players.Add(m);
            }

            base.OnEnter(m);
        }

        public override void OnExit(Mobile m)
        {
            if (Controller.Players.Contains(m))
                Controller.Players.Remove(m);

            base.OnExit(m);
        }

        public override TimeSpan GetLogoutDelay(Mobile m)
        {
            if (m.AccessLevel < AccessLevel.Counselor)
                return TimeSpan.FromMinutes(2);

            return base.GetLogoutDelay(m);
        }

        public override bool OnSkillUse(Mobile m, int Skill)
        {
            return base.OnSkillUse(m, Skill);
        }

        public override bool OnBeginSpellCast(Mobile m, ISpell s)
        {
            return base.OnBeginSpellCast(m, s);
        }

        public override bool AllowHousing(Mobile from, Point3D p)
        {
            return from.AccessLevel != AccessLevel.Player;
        }
    }
}