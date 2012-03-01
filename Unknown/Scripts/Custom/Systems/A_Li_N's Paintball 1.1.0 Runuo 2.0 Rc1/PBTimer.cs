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

namespace Server.Games.PaintBall
{
	public class PBTimer : Timer
	{
		PBGameItem m_PBGI;

		public PBTimer( PBGameItem pbgi ) : base( TimeSpan.FromSeconds( 1 ), TimeSpan.FromSeconds( 1 ) )
		{
			m_PBGI = pbgi;
		}

		protected override void OnTick()
		{
			if( m_PBGI.Active )
			{
				int teams = m_PBGI.Teams;
				if( teams == 2 && (m_PBGI.m_Team1 == 0 || m_PBGI.m_Team2 == 0) )
					m_PBGI.EndGame();
				else if( teams == 3 )
				{
					if( m_PBGI.m_Team1 == 0 )
						if( m_PBGI.m_Team2 == 0 || m_PBGI.m_Team3 == 0 )
							m_PBGI.EndGame();
					else if( m_PBGI.m_Team2 == 0 )
						if( m_PBGI.m_Team3 == 0 )
							m_PBGI.EndGame();
				}
				else if( teams == 4 )
				{
					if( m_PBGI.m_Team1 == 0 )
					{
						if( m_PBGI.m_Team2 == 0 )
							if( m_PBGI.m_Team3 == 0 || m_PBGI.m_Team4 == 0 )
								m_PBGI.EndGame();
						else if( m_PBGI.m_Team3 == 0 )
							if( m_PBGI.m_Team4 == 0 )
								m_PBGI.EndGame();
					}
					else if( m_PBGI.m_Team2 == 0 )
						if( m_PBGI.m_Team3 == 0 || m_PBGI.m_Team4 == 0 )
							m_PBGI.EndGame();
				}
			}
			else
				this.Stop();
		}
	}
}