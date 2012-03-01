using System;
using Server.Gumps;
using Server.Misc;
using Server.ContextMenus;
using System.Collections;
using Server.Network;
using Server.TMSS;
using Server;
using Server.Mobiles;
using System.Collections.Generic;

// -- TMSS 4.0.1 --
namespace Server.Items
{	
	public class SkillGate : BaseTMSkillTicket
	{
		#region Props
		private Point3D m_SendTo;

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D SendTo
		{
			get { return m_SendTo; }
			set { m_SendTo = value; }
		}

		private Map m_SendMap = null;

		[CommandProperty(AccessLevel.GameMaster)]
		public Map SendMap
		{
			get { return m_SendMap; }
			set { m_SendMap = value; }
		}
		#endregion

		#region Constructor
		[Constructable]
		public SkillGate() : base(0x1feb)
		{
			Movable = false;
			Name = "a skill gate";
			Light = LightType.Circle225;
		}
		public SkillGate( Serial serial ) : base( serial )
		{
		}
		#endregion

		#region Serdeser
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
		#endregion

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
		}
		public override void GetContextMenuEntries(Mobile from, System.Collections.Generic.List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);
			if (from.Alive && from.AccessLevel >= SkillSettings.GumpControlLevel)
			{
				list.Add(new ContextMenus.ProfileEntry(from, this));
			}
		}

		#region OnMoveOver
		public override bool OnMoveOver(Mobile m)
		{
			if (this.Profile != null)
			{
				for (int i = 0; i < 52; i++)
				{
					m.Skills[i].Base = 0;
				}
				if (Profile.StatEnable)
				{
					m.RawStr = Profile.StrVal;
					m.RawDex = Profile.DexVal;
					m.RawInt = Profile.IntVal;
				}
				if (Profile.SkillEnable)
				{
					IEnumerator ie = Profile.MasterHash.GetEnumerator();
					while (ie.MoveNext())
					{
						KeyValuePair<string, TMSkillInfo> kvp = (KeyValuePair<string, TMSkillInfo>)ie.Current;
						if (kvp.Value.SkillEnable)
						{
							int value = kvp.Value.SkillValue;
							int ID = kvp.Value.SkillID;

							m.Skills[ID].Base = value;
						}
					}
				}
				if (m_SendMap != null && m_SendMap != Map.Internal)
				{
					m.MoveToWorld(m_SendTo, m_SendMap);
					//m.Map = m_SendMap;
					//m.Location = new Point3D( m_SendTo.X, m_SendTo.Y, m_SendTo.Z );
					//m.MoveToWorld( m_SendTo, m_SendMap );
					SkillSettings.DoTell("Current x: " + m.X + " Target x: " + m_SendTo.X);
					//m.X = m_SendTo.X;
					SkillSettings.DoTell("Current y: " + m.Y + " Target y: " + m_SendTo.Y);
					//m.Y = m_SendTo.Y;
					SkillSettings.DoTell("Current z: " + m.Z + " Target z: " + m_SendTo.Z);
					//m.Z = m_SendTo.Z;
				}
			}
			else
			{
				m.SendMessage("Nothing Happens");
			}
			return false;
		}
		#endregion
	}
}