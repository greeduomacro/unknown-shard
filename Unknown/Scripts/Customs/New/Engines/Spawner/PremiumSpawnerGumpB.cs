using System;
using System.Collections;
using Server.Network;
using Server.Gumps;

namespace Server.Mobiles
{
	public class PremiumSpawnerGumpB : Gump
	{
		private PremiumSpawner m_Spawner;

		public void AddBlackAlpha( int x, int y, int width, int height )
		{
			AddImageTiled( x, y, width, height, 2624 );
			AddAlphaRegion( x, y, width, height );
		}

		public PremiumSpawnerGumpB( PremiumSpawner spawner ) : base( 50, 50 )
		{
			m_Spawner = spawner;

			AddPage( 0 );

			AddBackground( 0, 0, 350, 360, 5054 );

			AddLabel( 80, 1, 52, "Creatures List 3" );

			AddLabel( 215, 3, 52, "PREMIUM SPAWNER" );
			AddBlackAlpha( 213, 23, 125, 270 );

			AddButton( 260, 40, 0xFB7, 0xFB9, 1, GumpButtonType.Reply, 0 );
			AddLabel( 260, 60, 52, "Okay" );

			AddButton( 260, 90, 0xFB4, 0xFB6, 2, GumpButtonType.Reply, 0 );
			AddLabel( 232, 110, 52, "Bring to Home" );

			AddButton( 260, 140, 0xFA8, 0xFAA, 3, GumpButtonType.Reply, 0 );
			AddLabel( 232, 160, 52, "Total Respawn" );

			AddButton( 260, 190, 0xFAB, 0xFAD, 1000, GumpButtonType.Reply, 0 );
			AddLabel( 245, 210, 52, "Properties" );

			AddButton( 260, 240, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0 );
			AddLabel( 256, 260, 52, "Cancel" );

			AddButton( 230, 320, 5603, 5607, 100, GumpButtonType.Reply, 0 );
			AddButton( 302, 320, 5601, 5605, 101, GumpButtonType.Reply, 0 );
			AddLabel( 258, 320, 52, "- 3 -" );

			for ( int i = 0;  i < 15; i++ )
			{
				AddButton( 5, ( 22 * i ) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0 );
				AddButton( 38, ( 22 * i ) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0 );

				AddImageTiled( 71, ( 22 * i ) + 20, 119, 23, 0xA40 );
				AddImageTiled( 72, ( 22 * i ) + 21, 117, 21, 0xBBC );

				string str = "";

				if ( i < spawner.SubSpawnerB.Count )
				{
					str = (string)spawner.SubSpawnerB[i];
					int count = m_Spawner.CountCreaturesB( str );

					AddLabel( 192, ( 22 * i ) + 20, 0, count.ToString() );
				}

				AddTextEntry( 75, ( 22 * i ) + 21, 114, 21, 0, i, str );
			}
		}

		public ArrayList CreateArray( RelayInfo info, Mobile from )
		{
			ArrayList subSpawnerB = new ArrayList();

			for ( int i = 0;  i < 15; i++ )
			{
				TextRelay te = info.GetTextEntry( i );

				if ( te != null )
				{
					string str = te.Text;

					if ( str.Length > 0 )
					{
						str = str.Trim();

						Type type = SpawnerType.GetType( str );

						if ( type != null )
							subSpawnerB.Add( str );
						else
							from.SendMessage( "{0} is not a valid type name.", str );
					}
				}
			}

			return subSpawnerB;
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( m_Spawner.Deleted )
				return;

			switch ( info.ButtonID )
			{
				case 0: // Closed
				{
					break;
				}
				case 1: // Okay
				{
					m_Spawner.SubSpawnerB = CreateArray( info, state.Mobile );

					break;
				}
				case 2: // Bring everything home
				{
					m_Spawner.BringToHome();

					break;
				}
				case 3: // Complete respawn
				{
					m_Spawner.Respawn();

					break;
				}
				case 100: // Page 2
				{
					state.Mobile.SendGump( new PremiumSpawnerGumpA( m_Spawner ) );

					break;
				}
				case 101: // Page 4
				{
					state.Mobile.SendGump( new PremiumSpawnerGumpC( m_Spawner ) );

					break;
				}
				case 1000: // Props
				{
					state.Mobile.SendGump( new PropertiesGump( state.Mobile, m_Spawner ) );
					state.Mobile.SendGump( new PremiumSpawnerGumpB( m_Spawner ) );

					break;
				}
				default:
				{
					int buttonID = info.ButtonID - 4;
					int index = buttonID / 2;
					int type = buttonID % 2;

					TextRelay entry = info.GetTextEntry( index );

					if ( entry != null && entry.Text.Length > 0 )
					{
						if ( type == 0 ) // Spawn creature
							m_Spawner.Spawn( entry.Text );
						else // Remove creatures
							m_Spawner.RemoveCreaturesB( entry.Text );

						m_Spawner.SubSpawnerB = CreateArray( info, state.Mobile );
					}

					break;
				}
			}
		}
	}
}