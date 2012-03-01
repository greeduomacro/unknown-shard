using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Gumps;

// -- TMSS 4.0.1 --
namespace Server.TMSS
{
	public class SkillBall : BaseTMSkillTicket
	{
		[Constructable]
		public SkillBall() : base(0xe2f)
		{
			this.Movable = true;
			this.Hue = SkillSettings.SkillHue;
			RequireOwner = true;
		}
		public SkillBall(Serial serial) : base(serial) { }

		public override void OnDoubleClick(Mobile from)
		{
			if (Owner != null && from != Owner)
			{ from.SendMessage( SkillSettings.NotYoursMessage ); return; }
			TMSkillSession session = new TMSkillSession(from, this);
			session.Start();
		}
		#region serdeser
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
		}
		#endregion
	}
}
