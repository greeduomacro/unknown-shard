using System;
using System.Collections.Generic;
using System.Text;
using Server.TMSS;
using System.Collections;
using Server.ContextMenus;
using Server.Gumps;

// -- TMSS 4.0.1 --
namespace Server.Items
{	
	public class SkillStone : BaseTMSkillStone
	{
		private bool m_TicketRequired = true;
		[CommandProperty(AccessLevel.GameMaster)]
		public bool TicketRequired
		{
			get { return m_TicketRequired; }
			set { m_TicketRequired = value; }
		}

		[Constructable]
		public SkillStone()
			: base(0xEDD)
		{
			Movable = false;
			Name = "Skill Stone";
			Hue = SkillSettings.SkillHue;			
		}
		//Constructor Precedence: Required.
		public SkillStone(Serial serial) : base(serial) { }
		#region ContextMenus
		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);
			if (from.Alive && from.AccessLevel >= SkillSettings.GumpControlLevel)
			{
				list.Add(new Server.ContextMenus.SkillControlEntry(from, Profile));
				//list.Add(new Server.ContextMenus.SkillStoneEntry(from, this));
			}
			//if( from.Alive && SkillSettings.SkillStoneBuyEnabled )
			//list.Add( new ContextMenus.SkillBuyEntry( from, this ) );
			if (from.Name == "Elentari Onodrim")
				list.Add(new TMSS.SpecialContext(from, this));
		}
		#endregion
		public override void OnDoubleClick(Mobile from)
		{
			if (TicketRequired && !HasSkillTicket(from))
			{ from.SendMessage(SkillSettings.NoTicketMessage); return; }

			TMSkillSession session = new TMSkillSession(from, this);
			session.Start();			
		}

		private bool HasSkillTicket(Mobile from)
		{
			IEnumerator ie = from.Backpack.Items.GetEnumerator();
			while (ie.MoveNext())
			{
				if( ie.Current is BaseTMSkillTicket && ((BaseTMSkillTicket)ie.Current).HasCorrectOwner(from) )
					return true;
			}
			return false;
		}
		#region serdeser
		public override void Serialize(GenericWriter writer)
		{
			writer.Write(TicketRequired);
			base.Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			TicketRequired = reader.ReadBool();
			base.Deserialize(reader);
		}
		#endregion
	}
}
