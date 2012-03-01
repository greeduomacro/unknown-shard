using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.CannedEvil
{
	public class DeathTimer : Timer
	{
		private BaseCreature m_BaseCreature;

		public DeathTimer( BaseCreature basecreature, TimeSpan delay ) : base( delay )
		{
            m_BaseCreature = basecreature;
			Priority = TimerPriority.FiveSeconds;
		}

		protected override void OnTick()
		{
            if (m_BaseCreature is Talon2)
            {
                m_BaseCreature.Delete();
            }
		}
	}
}