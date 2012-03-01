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
using Server.Network;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using Server.Targeting;

namespace Server.Games.PaintBall
{
	public class PBGMGump : Gump
	{
		private PBGameItem m_PBGI;

		public PBGMGump( PBGameItem pbgi) : base( 0, 0 )
		{
			m_PBGI = pbgi;

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;

			AddPage(0);

			AddBackground( 100, 75, 480, 300, 83 );
			AddLabel( 350, 95, 1153, "Paintball GM Control" );

			AddBackground( 108, 85, 165, 280, 2620 );
			AddButton( 159, 95, 2443, 2444, (int)Buttons.Prizes, GumpButtonType.Reply, 0 );
			AddLabel( 168, 97, 1153, "Prizes" );
			Item item;
			for( int i = 0; i < m_PBGI.m_WinnersPrizes.Count; i++ )
			{
				item = m_PBGI.m_WinnersPrizes[i] as Item;
				AddLabel( 115, 120+i*20, 1153, string.Format( "{0} {1}", item.Amount, item.GetType().Name ) );
			}

			AddButton( 374, 125, 2443, 2444, (int)Buttons.Teams, GumpButtonType.Reply, 0 );
			AddLabel( 385, 127, 1153, "Teams" );
			AddLabel( 447, 127, 1153, m_PBGI.Teams.ToString() );

			AddButton( 285, 155, 2443, 2444, (int)Buttons.T1Entry, GumpButtonType.Reply, 0 );
			AddButton( 285, 180, 2443, 2444, (int)Buttons.T2Entry, GumpButtonType.Reply, 0 );
			AddButton( 285, 205, 2443, 2444, (int)Buttons.T3Entry, GumpButtonType.Reply, 0 );
			AddButton( 285, 230, 2443, 2444, (int)Buttons.T4Entry, GumpButtonType.Reply, 0 );
			AddLabel( 290, 157, (m_PBGI.Team1Dest == m_PBGI.Location ? 138 : 1153), "T1 Entry" );
			AddLabel( 290, 182, (m_PBGI.Team2Dest == m_PBGI.Location ? 138 : 1153), "T2 Entry" );
			AddLabel( 290, 207, (m_PBGI.Team3Dest == m_PBGI.Location ? 138 : 1153), "T3 Entry" );
			AddLabel( 290, 232, (m_PBGI.Team4Dest == m_PBGI.Location ? 138 : 1153), "T4 Entry" );
			AddLabel( 355, 157, (m_PBGI.Team1Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Team1Dest.X + ", " + m_PBGI.Team1Dest.Y );
			AddLabel( 355, 182, (m_PBGI.Team2Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Team2Dest.X + ", " + m_PBGI.Team2Dest.Y );
			AddLabel( 355, 207, (m_PBGI.Team3Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Team3Dest.X + ", " + m_PBGI.Team3Dest.Y );
			AddLabel( 355, 232, (m_PBGI.Team4Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Team4Dest.X + ", " + m_PBGI.Team4Dest.Y );

			AddButton( 430, 155, 2443, 2444, (int)Buttons.T1Exit, GumpButtonType.Reply, 0 );
			AddButton( 430, 180, 2443, 2444, (int)Buttons.T2Exit, GumpButtonType.Reply, 0 );
			AddButton( 430, 205, 2443, 2444, (int)Buttons.T3Exit, GumpButtonType.Reply, 0 );
			AddButton( 430, 230, 2443, 2444, (int)Buttons.T4Exit, GumpButtonType.Reply, 0 );
			AddLabel( 440, 157, (m_PBGI.Exit1Dest == m_PBGI.Location ? 138 : 1153), "T1 Exit" );
			AddLabel( 440, 182, (m_PBGI.Exit2Dest == m_PBGI.Location ? 138 : 1153), "T2 Exit" );
			AddLabel( 440, 207, (m_PBGI.Exit3Dest == m_PBGI.Location ? 138 : 1153), "T3 Exit" );
			AddLabel( 440, 232, (m_PBGI.Exit4Dest == m_PBGI.Location ? 138 : 1153), "T4 Exit" );
			AddLabel( 500, 157, (m_PBGI.Exit1Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Exit1Dest.X + ", " + m_PBGI.Exit1Dest.Y );
			AddLabel( 500, 182, (m_PBGI.Exit2Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Exit2Dest.X + ", " + m_PBGI.Exit2Dest.Y );
			AddLabel( 500, 207, (m_PBGI.Exit3Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Exit3Dest.X + ", " + m_PBGI.Exit3Dest.Y );
			AddLabel( 500, 232, (m_PBGI.Exit4Dest == m_PBGI.Location ? 138 : 1153), m_PBGI.Exit4Dest.X + ", " + m_PBGI.Exit4Dest.Y );

			AddButton( 285, 335, 2443, 2444, (int)Buttons.Start, GumpButtonType.Reply, 0 );
			AddButton( 385, 335, 2443, 2444, (int)Buttons.Stop, GumpButtonType.Reply, 0 );
			AddButton( 485, 335, 2443, 2444, (int)Buttons.Pause, GumpButtonType.Reply, 0 );
			AddLabel( 296, 337, 67, "Start" );
			AddLabel( 400, 337, 38, "Stop" );
			AddLabel( 496, 337, 53, "Pause" );
		}

		public enum Buttons
		{
			Exit,

			Prizes,

			Teams,
			T1Entry, T2Entry, T3Entry, T4Entry,
			T1Exit, T2Exit, T3Exit, T4Exit,

			Start, Stop, Pause,
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			int BID = info.ButtonID;

			if( BID == (int)Buttons.Start )
			{
				m_PBGI.Active = true;
				if( m_PBGI.GameTimer != null )
					m_PBGI.GameTimer.Start();
				else
				{
					m_PBGI.GameTimer = new PBTimer( m_PBGI );
					m_PBGI.GameTimer.Start();
				}


				foreach( PlayerMobile pm in m_PBGI.Players )
				{
					pm.Frozen = false;
					pm.Warmode = true;
					pm.SendMessage( "The game has started!  GO GO GOOOOOO!" );
				}
				from.SendMessage( "You have started the game." );
				from.SendGump( new PBGMGump( m_PBGI ) );
			}

			else if( BID == (int)Buttons.Stop )
			{
				m_PBGI.EndGame();
				from.SendMessage( "You have ended the game." );
			}

			else if( BID == (int)Buttons.Pause )
			{
				m_PBGI.Active = false;
				foreach( PlayerMobile pm in m_PBGI.Players )
				{
					pm.Frozen = true;
					pm.Warmode = false;
					pm.SendMessage( "A GM has paused the game" );
				}
				from.SendMessage( "You have paused the game." );
				from.SendGump( new PBGMGump( m_PBGI ) );
			}

			else if( BID == (int)Buttons.Prizes )
			{
				from.Target = new PBPrizeTarget( m_PBGI );
			}

			else if( BID >= (int)Buttons.T1Entry && BID <= (int)Buttons.T4Exit )
			{
				from.SendMessage( "Please select the location" );
				from.Target = new PBLocTarget( m_PBGI, BID );
			}

			else if( BID == (int)Buttons.Teams )
			{
				m_PBGI.Teams += 1;
				if( m_PBGI.Teams > 4 || m_PBGI.Teams < 2 )
					m_PBGI.Teams = 2;
				from.SendGump( new PBGMGump( m_PBGI ) );
			}
		}

		private class PBLocTarget : Target
		{
			private PBGameItem m_PBGI;
			private int m_ID;

			public PBLocTarget( PBGameItem pbgi, int id ) : base( -1, true, TargetFlags.None )
			{
				m_PBGI = pbgi;
				m_ID = id;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				IPoint3D t = targeted as IPoint3D;
				if( t == null )
					return;

				Point3D loc = new Point3D( t );
				switch( m_ID )
				{
					case (int)Buttons.T1Entry	:	{ from.SendMessage( "Setting Team 1's Entry Point" );	m_PBGI.Team1Dest = loc;	break; }
					case (int)Buttons.T2Entry	:	{ from.SendMessage( "Setting Team 2's Entry Point" );	m_PBGI.Team2Dest = loc;	break; }
					case (int)Buttons.T3Entry	:	{ from.SendMessage( "Setting Team 3's Entry Point" );	m_PBGI.Team3Dest = loc;	break; }
					case (int)Buttons.T4Entry	:	{ from.SendMessage( "Setting Team 4's Entry Point" );	m_PBGI.Team4Dest = loc;	break; }
					case (int)Buttons.T1Exit	:	{ from.SendMessage( "Setting Team 1's Exit Point" );	m_PBGI.Exit1Dest = loc;	break; }
					case (int)Buttons.T2Exit	:	{ from.SendMessage( "Setting Team 2's Exit Point" );	m_PBGI.Exit2Dest = loc;	break; }
					case (int)Buttons.T3Exit	:	{ from.SendMessage( "Setting Team 3's Exit Point" );	m_PBGI.Exit3Dest = loc;	break; }
					case (int)Buttons.T4Exit	:	{ from.SendMessage( "Setting Team 4's Exit Point" );	m_PBGI.Exit4Dest = loc;	break; }
				}
				from.SendGump( new PBGMGump( m_PBGI ) );
			}

			protected override void OnTargetCancel( Mobile from, TargetCancelType cancelType )
			{
				from.SendGump( new PBGMGump( m_PBGI ) );
			}
		}

		private class PBPrizeTarget : Target
		{
			private PBGameItem m_PBGI;

			public PBPrizeTarget( PBGameItem pbgi ) : base( -1, false, TargetFlags.None )
			{
				m_PBGI = pbgi;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if( targeted is Container )
					foreach( Item item in ((Container)targeted).Items )
					{
						from.SendMessage( string.Format("Adding {0} {1} to the Prize List", item.Amount, item.GetType().Name ) );
						m_PBGI.m_WinnersPrizes.Add( item );
					}
				else
					from.SendMessage( "Please target a bag with the prizes in it" );

				from.SendGump( new PBGMGump( m_PBGI ) );
			}

			protected override void OnTargetCancel( Mobile from, TargetCancelType cancelType )
			{
				from.SendGump( new PBGMGump( m_PBGI ) );
			}
		}
	}
}