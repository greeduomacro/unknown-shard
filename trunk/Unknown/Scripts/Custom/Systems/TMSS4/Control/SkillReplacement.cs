using Server.Network;
using System;

namespace Server.TMSS
{
	public class SkillReplacement
	{
		private const bool UseParallelGump = false;

		public static void Configure()
		{
			SkillSettings.SystemWrite("-- // P // -- Configuring Skill Replacement. Custom Skill Gump will " + ( UseParallelGump ? "" : "not") + " be used." );
			if (UseParallelGump)
				Server.Network.PacketHandlers.Register(0x34, 10, true, new Server.Network.OnPacketReceive(Server.TMSS.SkillReplacement.MobileQuery2));
		}

		public static void MobileQuery2(NetState state, PacketReader pvSrc)
		{
			Mobile from = state.Mobile;

			pvSrc.ReadInt32(); // 0xEDEDEDED
			int type = pvSrc.ReadByte();
			Mobile m = World.FindMobile(pvSrc.ReadInt32());

			if (m != null)
			{
				switch (type)
				{
					case 0x00: // Unknown, sent by godclient
					{
						if ( PacketHandlers.VerifyGC( state ) )
							Console.WriteLine( "God Client: {0}: Query 0x{1:X2} on {2} '{3}'", state, type, m.Serial, m.Name );

						break;
					}
					case 0x04: // Stats
					{
						m.OnStatsQuery( from );
						break;
					}
					case 0x05:
					{
						m.SendGump( new TMSS.ParallelSkillsGump( m ) );
						break;
					}
					default:
					{
						pvSrc.Trace( state );
						break;
					}
				}
			}
		}
	}
}