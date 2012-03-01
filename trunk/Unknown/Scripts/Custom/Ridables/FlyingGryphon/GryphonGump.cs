using System;
using Server;
using Server.Items;
using Server.Multis;
using Server.Network;
using Server.Mobiles;
using Server.ContextMenus;
using System.Collections;
using Server.Misc;


namespace Server.Gumps
{
	public class Gryphongump : Gump
	{
		private Mobile m_Owner;
		public Mobile Owner{ get{ return m_Owner; } set{ m_Owner = value; } }

		public Gryphongump(Mobile owner, int page) : base( 20, 20 )
		{
			owner.CloseGump( typeof( Gryphongump ) );

			int gumpX = 0; int gumpY = 0;

			m_Owner = owner;

			Closable = false;
			Disposable = false;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddPage( 1 ); 

			gumpX = 10; gumpY = 10;
			AddImage( gumpX, gumpY, 0x1392 );

                        if ( page != 1 ) 
		        {
			gumpX = 87; gumpY = 40;
			AddButton( gumpX, gumpY, 0x1194, 0x1194, 1, GumpButtonType.Reply, 0);
                        }                        
                        if ( page != 2 ) 
		        {
			gumpX = 118; gumpY = 53;
			AddButton( gumpX, gumpY, 0x1195, 0x1195, 2, GumpButtonType.Reply, 0);
                        } 
                        if ( page != 3 ) 
		        {
			gumpX = 131; gumpY = 86;
			AddButton( gumpX, gumpY, 0x1196, 0x1196, 3, GumpButtonType.Reply, 0);
                        }
                        if ( page != 4 ) 
		        {
			gumpX = 114; gumpY = 117;
			AddButton( gumpX, gumpY, 0x1197, 0x1197, 4, GumpButtonType.Reply, 0);
                        }
                        if ( page != 5 ) 
		        {
			gumpX = 86; gumpY = 131;
			AddButton( gumpX, gumpY, 0x1198, 0x1198, 5, GumpButtonType.Reply, 0);
                        }
                        if ( page != 6 ) 
		        {
			gumpX = 54; gumpY = 119;
			AddButton( gumpX, gumpY, 0x1199, 0x1199, 6, GumpButtonType.Reply, 0);
                        }
                        if ( page != 7 ) 
		        {
			gumpX = 41; gumpY = 86;
			AddButton( gumpX, gumpY, 0x119A, 0x119A, 7, GumpButtonType.Reply, 0);
                        }
                        if ( page != 8 ) 
		        {
			gumpX = 54; gumpY = 52;
			AddButton( gumpX, gumpY, 0x119B, 0x119B, 8, GumpButtonType.Reply, 0);
                        }
                        if ( page != 9 ) 
		        {
			gumpX = 101; gumpY = 89;
			AddButton( gumpX, gumpY, 0x26AC, 0x26AE, 9, GumpButtonType.Reply, 0);
                        }
                        if ( page != 10 )
		        {
			gumpX = 102; gumpY = 112;
			AddButton( gumpX, gumpY, 0x26B2, 0x26B4, 10, GumpButtonType.Reply, 0);
                        }


                        if ( page == 1) 
		        {
			gumpX = 87; gumpY = 40;
			AddButton( gumpX, gumpY, 0x1194, 0x1194, 11, GumpButtonType.Reply, 0);

			gumpX = 87; gumpY = 40;
			AddImage( gumpX, gumpY, 0x1194, 69 );
                        }
                        else if ( page == 2 )              
		        {
			gumpX = 118; gumpY = 53;
			AddButton( gumpX, gumpY, 0x1195, 0x1195, 12, GumpButtonType.Reply, 0);

			gumpX = 118; gumpY = 53;
			AddImage( gumpX, gumpY, 0x1195, 69 );
                        }
                        else if ( page == 3 )             
		        {
			gumpX = 131; gumpY = 86;
			AddButton( gumpX, gumpY, 0x1196, 0x1196, 13, GumpButtonType.Reply, 0);

			gumpX = 131; gumpY = 86;
			AddImage( gumpX, gumpY, 0x1196, 69 );
                        }
                        else if ( page == 4 )              
		        {
			gumpX = 114; gumpY = 117;
			AddButton( gumpX, gumpY, 0x1197, 0x1197, 14, GumpButtonType.Reply, 0);

			gumpX = 114; gumpY = 117;
			AddImage( gumpX, gumpY, 0x1197, 69 );
                        }
                        else if ( page == 5 )             
		        {
			gumpX = 86; gumpY = 131;
			AddButton( gumpX, gumpY, 0x1198, 0x1198, 15, GumpButtonType.Reply, 0);

			gumpX = 86; gumpY = 131;
			AddImage( gumpX, gumpY, 0x1198, 69 );
                        }
                        else if ( page == 6 )             
		        {
			gumpX = 54; gumpY = 119;
			AddButton( gumpX, gumpY, 0x1199, 0x1199, 16, GumpButtonType.Reply, 0);

			gumpX = 54; gumpY = 119;
			AddImage( gumpX, gumpY, 0x1199, 69 );
                        }
                        else if ( page == 7 )             
		        {
			gumpX = 41; gumpY = 86;
			AddButton( gumpX, gumpY, 0x119A, 0x119A, 17, GumpButtonType.Reply, 0);

			gumpX = 41; gumpY = 86;
			AddImage( gumpX, gumpY, 0x119A, 69 );
                        }
                        else if ( page == 8 )             
		        {
			gumpX = 54; gumpY = 52;
			AddButton( gumpX, gumpY, 0x119B, 0x119B, 18, GumpButtonType.Reply, 0);

			gumpX = 54; gumpY = 52;
			AddImage( gumpX, gumpY, 0x119B, 69 );
                        }
                        else if ( page == 9 )            
		        {
			gumpX = 101; gumpY = 89;
			AddButton( gumpX, gumpY, 0x26AC, 0x26AE, 19, GumpButtonType.Reply, 0);

			gumpX = 101; gumpY = 89;
			AddImage( gumpX, gumpY, 0x26AC, 69 );
                        }
                        else if ( page == 10 )           
		        {
			gumpX = 102; gumpY = 112;
			AddButton( gumpX, gumpY, 0x26B2, 0x26B4, 20, GumpButtonType.Reply, 0);

			gumpX = 102; gumpY = 112;
			AddImage( gumpX, gumpY, 0x26B2, 69 );
                        }

		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;

	                PlayerMobile pm = (PlayerMobile)from;

			Tile landTile = pm.Map.Tiles.GetLandTile(pm.X, pm.Y );

                      	bool location = ( landTile.Z <= ( pm.Z -6 )  );

                      	if (location )
                      	animateflying(from);

			switch( info.ButtonID )
			{
                          	case 0:
				break;

                                case 1:
                                from.Direction = Direction.Up;
                                from.SendGump(new Gryphongump( from , 1) );
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 1 );  
                               	pm.m_Flyingtimer.Start();                          
				break;

				case 2:
                                from.Direction = Direction.North;
                                from.SendGump(new Gryphongump( from , 2) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 2 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 3:
                                from.Direction = Direction.Right;
                                from.SendGump(new Gryphongump( from , 3) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 3 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 4:
                                from.Direction = Direction.East;
                                from.SendGump(new Gryphongump( from , 4) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 4 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 5:
                                from.Direction = Direction.Down;
                                from.SendGump(new Gryphongump( from , 5) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 5 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 6:
                                from.Direction = Direction.South;
                                from.SendGump(new Gryphongump( from , 6) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 6 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 7:
                                from.Direction = Direction.Left;
                                from.SendGump(new Gryphongump( from , 7) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 7 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 8:
                                from.Direction = Direction.West;
                                from.SendGump(new Gryphongump( from , 8) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 8 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 9:
                                from.SendGump(new Gryphongump( from , 9) ); 
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 9 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 10:
                                from.SendGump(new Gryphongump( from , 10) );                           
 			       	if ( pm.m_Flyingtimer != null )
                               	pm.m_Flyingtimer.Stop();
                               	pm.m_Flyingtimer = new Flyingtimer( pm, 10 );  
                               	pm.m_Flyingtimer.Start();     
				break;

				case 11:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        }
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 12:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 13:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 14:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 15:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 16:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 17:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 18:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 19:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;

				case 20:
			        if ( pm.m_Flyingtimer != null )
                                pm.m_Flyingtimer.Stop();
                                if ( location )
			        {
                                	pm.m_Flyingtimer = new Flyingtimer( pm, 0 );
                                	pm.m_Flyingtimer.Start();
	                        } 
                                else
                                pm.m_Flyingtimer = null;
                                from.SendGump(new Gryphongump( from , 0) );  
				break;
	                }
		}

		public static void animateflying( Mobile m )
		{
               		m.PlaySound( 0x2D0 );
			m.Animate( 24, 5, 1, true, false, 0 );
		}

		public static bool checkmap( Mobile m )
		{
                	if ( m.Map == Map.Malas && m.Z >= 0 )
			return true;

                	if ( m.Map == Map.Trammel && m.Z >= 100 )
			return true;

                	if ( m.Map == Map.Ilshenar && m.Z >= 100 )
			return true;


			return false;
		}

		private class Flyingtimer : Timer 
                { 
                	private PlayerMobile m_Mobile; 
                	private int d;
			private int anim = 0;

                	public Flyingtimer( PlayerMobile m, int seq ) : base( TimeSpan.FromSeconds( 0.2 ) )
                	{
                		m_Mobile = m;
                		d = seq;
                	} 

                	protected override void OnTick() 
                	{
				bool location1 = false;               
                		bool location2 = false;  

				if ( !m_Mobile.Alive || m_Mobile.NetState == null || !( m_Mobile.Mount is Gryphon ) )
                		{
					m_Mobile.Animate( 23, 5, 1, true, false, 0 );
                			Stop();
                		}
                 		else if (d == 0)
                 		{
				Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

				if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           	location1 = true;

                             		if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 
                             			Stop();
                             		}
                             		else
                             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                					anim -= 1;
                				}
						Start();
                 			}
				}           
                 		else if (d == 1) 
                 		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X - 1 ), ( m_Mobile.Y - 1 ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}
                             		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                           			location2 = true;
                           		}
					if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                				anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
						m_Mobile.X -= 1;
                             			m_Mobile.Y -= 1;

						Start(); 
                             		}
				}
                		else if ( d == 2) 
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X ), ( m_Mobile.Y - 1 ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                           			location2 = true;
                           		}

					if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                            	 		m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                				anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
						m_Mobile.Y -= 1;
                             			Start(); 
                             		}
                		}
                		else if ( d == 3)
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X + 1 ), ( m_Mobile.Y - 1 ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                           			location2 = true;
                           		}
					
					if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                					anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
						m_Mobile.X += 1;
                             			m_Mobile.Y -= 1;
                             			Start(); 
                             		}
                		}
                		else if ( d == 4)
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X + 1 ), ( m_Mobile.Y ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                           			location2 = true;
                           		}

					if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                				anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
						m_Mobile.X += 1;
                             			Start(); 
                             		}
                		}
                		else if ( d == 5)
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X + 1 ), ( m_Mobile.Y + 1 ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                          	 		location2 = true;
                           		}

					if ( location1 )
		             		{
                            	 		m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                				anim -= 1;
                				}
	
						m_Mobile.Direction |= Direction.Running;
						m_Mobile.X += 1;
                             			m_Mobile.Y += 1;
                             			Start(); 
                             		}
                		}
                		else if ( d == 6)
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X ), ( m_Mobile.Y + 1 ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                           			location2 = true;
                           		}
				
					if ( location1 )
		             		{
                            		 	m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                				anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
						m_Mobile.Y += 1;
                             			Start(); 
                             		}
                		}
                		else if ( d == 7)
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X - 1 ), ( m_Mobile.Y + 1 ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                           			location2 = true;
                           		}
				
					if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                					anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
						m_Mobile.X -= 1;
                             			m_Mobile.Y += 1;
                             			Start(); 
                             		} 
                		}
                		else if ( d == 8)
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X - 1 ), ( m_Mobile.Y ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -5 ))
                           			location1 = true;
                           		}

                             		if ( landTile.Z >= ( m_Mobile.Z -5 )  )
                           		{
                           			location1 = true;
                           			location2 = true;
                           		}
					
					if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                            	 		m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 

                             			if (location2)
                             			Stop();
                             			else
                             			{
                             				d = 0;
                             				Start();
                             			}
					}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                				anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
						m_Mobile.X -= 1;
                             			Start(); 
                             		}
                		}
                		else if ( d == 9) 
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X ), ( m_Mobile.Y ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z +5 ) )
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z +5 )  )
                           		location1 = true;

					if ( location1 || checkmap( m_Mobile ) )
		             		{
                            			m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 
                             			Start();
                             		}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                				anim -= 1;
                				}	
		
						m_Mobile.Direction |= Direction.Running;
						m_Mobile.Z += 1;
                             			Start(); 
                             		}
                		}
                		else if ( d == 10) 
                		{
                      			Tile[] tiles = m_Mobile.Map.Tiles.GetStaticTiles( ( m_Mobile.X ), ( m_Mobile.Y ), true );
		      			Tile landTile = m_Mobile.Map.Tiles.GetLandTile( m_Mobile.X, m_Mobile.Y );

					for ( int i = 0; i < tiles.Length; ++i )
		           		{
		           			Tile tile = tiles[i];
                           			if ( tile.Z >= ( m_Mobile.Z -6 ))
                           			location1 = true;
                           		}
                             
                           		if ( landTile.Z >= ( m_Mobile.Z -6 )  )
                           		location1 = true;

					if ( location1 )
		             		{
                             			m_Mobile.CloseGump( typeof( Gryphongump ) );
                             			m_Mobile.SendGump(new Gryphongump( m_Mobile , 0) ); 
		             			m_Mobile.Animate( 23, 5, 1, true, false, 0 );
                             			Stop();
                             		}
                             		else
		             		{
						if ( anim <= 0)
                				{
                					animateflying(m_Mobile);
                					anim = 2;
                				}
                				else
                				{
                					anim -= 1;
                				}

						m_Mobile.Direction |= Direction.Running;
	 					m_Mobile.Z -= 1;
                             			Start(); 
                             		}
                		}
                		else
                		{
                		Stop();
                		} 
			} 
		} 
	}
}
