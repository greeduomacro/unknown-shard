using System;
using System.Collections.Generic;
using System.Text;
using Server.TMSS;

// -- TMSS 4.0.1 --
namespace Server.Items
{
	public class SkillTicket : BaseTMSkillTicket
	{
		private bool m_Standalone = false;
		[CommandProperty(AccessLevel.GameMaster)]
		public bool Standalone
		{
			get { return m_Standalone; }
			set { m_Standalone = value; }
		}

		[Constructable]
		public SkillTicket() : base( )
		{ RequireOwner = true; Hue = SkillSettings.SkillHue; Movable = true; }

		[Constructable]
		public SkillTicket( bool requireowner ) : base()
		{ RequireOwner = requireowner; Hue = SkillSettings.SkillHue; Movable = true;}

		[Constructable]
		public SkillTicket(Mobile m)
			: base(m)
		{ Hue = SkillSettings.SkillHue; Movable = true; }

		public SkillTicket(Serial serial) : base(serial) { }

		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
		public override void OnDoubleClick(Mobile from)
		{
			if (this.Owner == null && this.RequireOwner)
			{ from.SendMessage("This ticket has no owner, and an owner is required for use."); return; }
			if (this.RequireOwner && from != Owner)
			{ from.SendMessage(SkillSettings.NotYoursMessage); return; }
			if (!from.Backpack.Items.Contains(this))
			{ from.SendMessage("You must have this in your backpack to use it."); return; }
			if (this.Profile == null)
			{ from.SendMessage("This Ticket is incorrectly configured, and cannot start a sesssion (lack of profile)."); return; }
			if (this.Skin == null)
			{ from.SendMessage("This Ticket is incorrectly configured, and cannot start a session (lack of skin)."); return; }
			if( m_Standalone )
				base.OnDoubleClick(from);
			else
				from.SendMessage(SkillSettings.HowToUseMessage);
		}
	}
}
