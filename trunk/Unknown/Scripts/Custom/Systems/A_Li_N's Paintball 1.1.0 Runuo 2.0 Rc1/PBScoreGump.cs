/*********************************************************************************/
/*                PBEquipment.cs | PBGameItem.cs | PBPlayerStorage.cs            */
/*            PBScoreBoard.cs | PBScoreGump.cs | PBGMGump.cs | PBTimer.cs        */
/*                             Created by A_Li_N                                 */
/*         Credits:                                                              */
/*                      Original Idea + Some Code - Clarke76                     */
/*                      Some Ideas + Code - Lucid Nagual                         */
/*********************************************************************************/

using System;
using Server;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Games.PaintBall
{
	public class PBScoreGump : Gump
	{
		private PBGameItem m_PBGI;

		public PBScoreGump( PBGameItem pbgi )	: base( 0, 0 )
		{
			m_PBGI = pbgi;

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;

			AddPage(0);

			AddBackground(0, 0, 595, 400, 83);
			AddLabel(233, 20, 1153, "Paintball Scoreboard");

			AddBackground(13, 50, 135, 338, 9270);
			AddBackground(159, 50, 135, 338, 9270);
			if( m_PBGI.Teams > 2 )
				AddBackground(305, 50, 135, 338, 9270);
			if( m_PBGI.Teams > 3 )
				AddBackground(450, 50, 135, 338, 9270);

			AddPlayers();
		}

		private void AddPlayers()
		{
			int Team1, Team2, Team3, Team4;
			Team1 = Team2 = Team3 = Team4 = 0;
			int team;

			foreach( PlayerMobile pm in m_PBGI.Players )
			{
				team = pm.FindItemOnLayer( Layer.TwoHanded ).Hue;
				switch( team )
				{
					case 3:
					{
						if( pm.ChestArmor != null && pm.ChestArmor.Hue == team )
							AddLabel( 25, 95+Team1*20, 3, pm.Name );
						else
							AddLabel( 25, 95+Team1*20, 1153, pm.Name );

						Team1 += 1;
						break;
					}
					case 38:
					{
						if( pm.ChestArmor != null && pm.ChestArmor.Hue == team )
							AddLabel( 172, 95+Team2*20, 38, pm.Name );
						else
							AddLabel( 172, 95+Team2*20, 1153, pm.Name );

						Team2 += 1;
						break;
					}
					case 68:
					{
						if( m_PBGI.Teams > 2 )
						{
							if( pm.ChestArmor != null && pm.ChestArmor.Hue == team )
								AddLabel( 318, 95+Team3*20, 68, pm.Name );
							else
								AddLabel( 318, 95+Team3*20, 1153, pm.Name );

							Team3 += 1;
						}
						break;
					}
					case 53:
					{
						if( m_PBGI.Teams > 3 )
						{
							if( pm.ChestArmor != null && pm.ChestArmor.Hue == team )
								AddLabel( 463, 95+Team4*20, 53, pm.Name );
							else
								AddLabel( 463, 95+Team4*20, 1153, pm.Name );

							Team4 += 1;
						}
						break;
					}
					default:				break;
				}
			}

			AddLabel(44, 70, 3, "Team 1 - " + Team1.ToString());
			AddLabel(188, 70, 38, "Team 2 - " + Team2.ToString());
			if( m_PBGI.Teams > 2 )
				AddLabel(334, 70, 68, "Team 3 - " + Team3.ToString());
			if( m_PBGI.Teams > 3 )
				AddLabel(478, 70, 53, "Team 4 - " + Team4.ToString());
		}
	}
}