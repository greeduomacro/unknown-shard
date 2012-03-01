using System;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.TMSS;
using System.Collections;
using System.Collections.Generic;
// -- TMSS 4.0 -- CORE FILES --
//Random versions. File concurrent since 2.0.2
//Version 3.0 (v4 init)
//Computer meus nefandus est.
namespace Server.ContextMenus
{
	#region CenterStone
	//3000179
	public class ProfileEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private BaseTMSkillItem m_Stone;
		
		public ProfileEntry(Mobile from, BaseTMSkillItem stone)
			: base(179, 1)
		{
			m_From = from;
			m_Stone = stone;
		}


		public override void OnClick()
		{
			if( m_Stone != null )
			{
				if (m_Stone.Deleted)
					return;
				if (m_From.AccessLevel >= SkillSettings.GumpControlLevel)
				{
					Dictionary<string, object> args = new Dictionary<string, object>();
					args.Add("Skin", SkinHelper.getSkin( SkillSettings.ControlSkinName ) );
					args.Add("Mobile", m_From );
					m_From.SendGump( new TMQueryPage( "Profile Selector", args ));
				}
				else
					m_From.SendMessage("You do not have the proper accesslevel for that.");
			}
			else
				m_From.SendMessage("Unkown object to work with.");			
		}
	}
	public class CenterStoneEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private BaseTMSkillItem m_Stone;

		public CenterStoneEntry(Mobile from, BaseTMSkillItem stone)
			: base(0097, 1)
		{
			m_From = from;
			m_Stone = stone;
		}

		public override void OnClick()
		{
			if (m_Stone.Deleted)
				return;
			if (m_From.AccessLevel >= SkillSettings.GumpControlLevel)
			{ 
				Dictionary<string,object> args = new Dictionary<string,object>();
				args.Add("Skin", SkinHelper.getSkin(SkillSettings.ControlSkinName) );
				args.Add("Mobile", m_From );
				m_From.SendGump( new TMQueryPage( "Main Menu", args )) ;
			}
			//m_From.SendGump(new TMControlPage(ControlPageHelper.getPluginID("Main Menu")));

			else
				m_From.SendMessage("You do not have the proper accesslevel for that.");
		}
	}
	public class CenterStoneEntry2 : ContextMenuEntry
	{
		private Mobile m_From;
		private BaseTMSkillItem m_Stone;

		public CenterStoneEntry2(Mobile from, BaseTMSkillItem stone)
			: base(0134, 1)
		{
			m_From = from;
			m_Stone = stone;
		}

		public override void OnClick()
		{
			if (m_Stone.Deleted || !m_From.CheckAlive())
				return;
			if (m_From.AccessLevel >= SkillSettings.GumpControlLevel)
			{
				Dictionary<string,object> args = new Dictionary<string,object>();
				args.Add("Skin", SkinHelper.getSkin(SkillSettings.ControlSkinName));
				args.Add("Mobile", m_From);
				m_From.SendGump(new TMQueryPage("Main Menu", args));
			} //m_From.SendGump(new TMControlPage(ControlPageHelper.getPluginID("Main Menu")));//TODO: Change to Help Gump

			else
				m_From.SendMessage("You do not have the proper accesslevel for that.");
		}
	}
	#endregion

	#region Plugin
	public class SkillControlEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private SkillProfile m_profile;

		public SkillControlEntry(Mobile from, SkillProfile stone)
			: base(5101, 1)
		{
			m_From = from;
			m_profile = stone;
		}

		public override void OnClick()
		{
			if (!m_From.CheckAlive())
				return;
			if (m_From.AccessLevel >= SkillSettings.GumpControlLevel)
			{
				Dictionary<string,object> args = new Dictionary<string,object>();
				args.Add("Skin", SkinHelper.getSkin(SkillSettings.ControlSkinName));
				args.Add("Mobile", m_From);
				m_From.SendGump(new TMQueryPage("Profile Selector", args));
			}//m_From.SendGump(new SkillSetGump(m_profile));

			else
				m_From.SendMessage("You do not have the proper accesslevel for that.");
		}
	}
	#endregion
}