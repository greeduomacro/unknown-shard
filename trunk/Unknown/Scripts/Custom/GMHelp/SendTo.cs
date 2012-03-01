using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Targeting;
using Server.Commands;
using Server.Commands.Generic;
using System.Collections.Generic;

	public class SendTo
	{
	public ArrayList List;
		
		public static void Initialize()
		{
			CommandSystem.Register( "SendTo", AccessLevel.Counselor, new CommandEventHandler( SendTo_OnCommand ) );
		}

		[Usage( "SendTo [name | serial | (x y [z]) | (deg min (N | S) deg min (E | W))]" )]
		[Description( "With no arguments, this command brings up the sendto menu. With one argument, (name), the target is moved to that regions \"go location.\" Or, if a numerical value is specified for one argument, (serial), the target is moved to that object. Two or three arguments, (x y [z]), will move the target to that location. When six arguments are specified, (deg min (N | S) deg min (E | W)), the target will go to an approximate of those sextant coordinates." )]
		private static void SendTo_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( e.Length == 0 )
			{
				SendToGump.DisplayTo( from );
			}
			else if ( e.Length == 1 )
			{
				try
				{
					int ser = e.GetInt32( 0 );

					IEntity ent = World.FindEntity( ser );

					if ( ent is Item )
					{
						Item item = (Item)ent;

						Map map = item.Map;
						Point3D loc = item.GetWorldLocation();

						Mobile owner = item.RootParent as Mobile;

						if ( owner != null && (owner.Map != null && owner.Map != Map.Internal) && !from.CanSee( owner ) )
						{
							from.SendMessage( "You can not go to what you can not see." );
							return;
						}
						else if ( owner != null && (owner.Map == null || owner.Map == Map.Internal) && owner.Hidden && owner.AccessLevel >= from.AccessLevel )
						{
							from.SendMessage( "You can not go to what you can not see." );
							return;
						}
						else if ( !FixMap( ref map, ref loc, item ) )
						{
							from.SendMessage( "That is an internal item and you cannot go to it." );
							return;
						}

						from.Target = new SendToTarget( loc, map );

						return;
					}
					else if ( ent is Mobile )
					{
						Mobile m = (Mobile)ent;

						Map map = m.Map;
						Point3D loc = m.Location;

						Mobile owner = m;

						if ( owner != null && (owner.Map != null && owner.Map != Map.Internal) && !from.CanSee( owner ) )
						{
							from.SendMessage( "You can not go to what you can not see." );
							return;
						}
						else if ( owner != null && (owner.Map == null || owner.Map == Map.Internal) && owner.Hidden && owner.AccessLevel >= from.AccessLevel )
						{
							from.SendMessage( "You can not go to what you can not see." );
							return;
						}
						else if ( !FixMap( ref map, ref loc, m ) )
						{
							from.SendMessage( "That is an internal mobile and you cannot go to it." );
							return;
						}

						from.Target = new SendToTarget( loc, map );

						return;
					}
					else
					{
						string name = e.GetString( 0 );

                        
                      List<Region> list = new List<Region>(from.Map.Regions.Values);

                        
						for ( int i = 0; i < list.Count; ++i )
						{
							Region r = (Region)list[i];

							if ( Insensitive.Equals( r.Name, name ) )
							{
								from.Target = new SendToTarget( new Point3D( r.GoLocation ), from.Map );
								return;
							}
						}

						if ( ser != 0 )
							from.SendMessage( "No object with that serial was found." );
						else
							from.SendMessage( "No region with that name was found." );

						return;
					}
				}
				catch
				{
				}

				from.SendMessage( "Region name not found" );
			}
			else if ( e.Length == 2 )
			{
				Map map = from.Map;

				if ( map != null )
				{
					int x = e.GetInt32( 0 ), y = e.GetInt32( 1 );
					int z = map.GetAverageZ( x, y );

					from.Target = new SendToTarget( new Point3D( x, y, z ), map ) ;
				}
			}
			else if ( e.Length == 3 )
			{
				from.Target = new SendToTarget( new Point3D( e.GetInt32( 0 ), e.GetInt32( 1 ), e.GetInt32( 2 ) ), from.Map ) ;
			}
			else if ( e.Length == 6 )
			{
				Map map = from.Map;

				if ( map != null )
				{
					Point3D p = Sextant.ReverseLookup( map, e.GetInt32( 3 ), e.GetInt32( 0 ), e.GetInt32( 4 ), e.GetInt32( 1 ), Insensitive.Equals( e.GetString( 5 ), "E" ), Insensitive.Equals( e.GetString( 2 ), "S" ) );

					if ( p != Point3D.Zero )
						from.Target = new SendToTarget( p, map );
					else
						from.SendMessage( "Sextant reverse lookup failed." );
				}
			}
			else
			{
				from.SendMessage( "Format: Go [name | serial | (x y [z]) | (deg min (N | S) deg min (E | W)]" );
			}
		}

		private static bool FixMap( ref Map map, ref Point3D loc, Item item )
		{
			if ( map == null || map == Map.Internal )
			{
				Mobile m = item.RootParent as Mobile;

				return ( m != null && FixMap( ref map, ref loc, m ) );
			}

			return true;
		}

		private static bool FixMap( ref Map map, ref Point3D loc, Mobile m )
		{
			if ( map == null || map == Map.Internal )
			{
				map = m.LogoutMap;
				loc = m.LogoutLocation;
			}

			return ( map != null && map != Map.Internal );
		}

		private class SendToTarget : Target
		{
			Point3D m_Destination;
			Map m_Map;
			
			public SendToTarget( Point3D p, Map m ) : base( -1, false, TargetFlags.None )
			{
				m_Destination = p;
				m_Map = m;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile )
				{
					Mobile t = (Mobile)targeted;
					t.MoveToWorld( m_Destination, m_Map );
					return;
				}
				else
				{
					from.SendMessage( "That is not a mobile. Try again." );
					from.Target = new SendToTarget( m_Destination, m_Map );
				}
			}
		}

		public class SendToGump : Gump
		{
			public static readonly LocationTree Felucca = new LocationTree( "felucca.xml", Map.Felucca );
			public static readonly LocationTree Trammel = new LocationTree( "trammel.xml", Map.Trammel );
			public static readonly LocationTree Ilshenar = new LocationTree( "ilshenar.xml", Map.Ilshenar );
			public static readonly LocationTree Malas = new LocationTree( "malas.xml", Map.Malas );
			public static readonly LocationTree Tokuno = new LocationTree( "Tokuno.xml", Map.Tokuno );

			public static bool OldStyle = PropsConfig.OldStyle;

            public static int GumpOffsetX = PropsConfig.GumpOffsetX;
            public static int GumpOffsetY = PropsConfig.GumpOffsetY;

            public static int TextHue = PropsConfig.TextHue;
            public static int TextOffsetX = PropsConfig.TextOffsetX;

            public static int OffsetGumpID = PropsConfig.OffsetGumpID;
            public static int HeaderGumpID = PropsConfig.HeaderGumpID;
            public static int EntryGumpID = PropsConfig.EntryGumpID;
            public static int BackGumpID = PropsConfig.BackGumpID;
            public static int SetGumpID = PropsConfig.SetGumpID;

            public static int SetWidth = PropsConfig.SetWidth;
            public static int SetOffsetX = PropsConfig.SetOffsetX, SetOffsetY = PropsConfig.SetOffsetY;
            public static int SetButtonID1 = PropsConfig.SetButtonID1;
            public static int SetButtonID2 = PropsConfig.SetButtonID2;

            public static int PrevWidth = PropsConfig.PrevWidth;
            public static int PrevOffsetX = PropsConfig.PrevOffsetX, PrevOffsetY = PropsConfig.PrevOffsetY;
            public static int PrevButtonID1 = PropsConfig.PrevButtonID1;
            public static int PrevButtonID2 = PropsConfig.PrevButtonID2;

            public static int NextWidth = PropsConfig.NextWidth;
            public static int NextOffsetX = PropsConfig.NextOffsetX, NextOffsetY = PropsConfig.NextOffsetY;
            public static int NextButtonID1 = PropsConfig.NextButtonID1;
            public static int NextButtonID2 = PropsConfig.NextButtonID2;

            public static int OffsetSize = PropsConfig.OffsetSize;

            public static int EntryHeight = PropsConfig.EntryHeight;
            public static int BorderSize = PropsConfig.BorderSize;

			private static bool PrevLabel = false, NextLabel = false;

            private static int PrevLabelOffsetX = PrevWidth + 1;
            private static int PrevLabelOffsetY = 0;

            private static int NextLabelOffsetX = -29;
            private static int NextLabelOffsetY = 0;

            private static int EntryWidth = 180;
            private static int EntryCount = 15;

            private static int TotalWidth = OffsetSize + EntryWidth + OffsetSize + SetWidth + OffsetSize;
            private static int TotalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (EntryCount + 1));

            private static int BackWidth = BorderSize + TotalWidth + BorderSize;
            private static int BackHeight = BorderSize + TotalHeight + BorderSize;

			public static void DisplayTo( Mobile from )
			{
				LocationTree tree;

				if ( from.Map == Map.Ilshenar )
					tree = Ilshenar;
				else if ( from.Map == Map.Felucca )
					tree = Felucca;
				else if ( from.Map == Map.Trammel )
					tree = Trammel;
				else if (from.Map == Map.Malas )
					tree = Malas;
				else
				    tree = Tokuno;

				ParentNode branch = (ParentNode)tree.LastBranch[from];

				if ( branch == null )
					branch = tree.Root;

				if ( branch != null )
					from.SendGump( new SendToGump( 0, from, tree, branch ) );
			}

			private LocationTree m_Tree;
			private ParentNode m_Node;
			private int m_Page;

			private SendToGump( int page, Mobile from, LocationTree tree, ParentNode node ) : base( 50, 50 )
			{
				from.CloseGump( typeof( SendToGump ) );

				tree.LastBranch[from] = node;

				m_Page = page;
				m_Tree = tree;
				m_Node = node;

				int x = BorderSize + OffsetSize;
				int y = BorderSize + OffsetSize;

				int count = node.Children.Length - (page * EntryCount);

				if ( count < 0 )
					count = 0;
				else if ( count > EntryCount )
					count = EntryCount;

				int totalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (count + 1));

				AddPage( 0 );

				AddBackground( 0, 0, BackWidth, BorderSize + totalHeight + BorderSize, BackGumpID );
				AddImageTiled( BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), totalHeight, OffsetGumpID );

				if ( OldStyle )
					AddImageTiled( x, y, TotalWidth - (OffsetSize * 3) - SetWidth, EntryHeight, HeaderGumpID );
				else
					AddImageTiled( x, y, PrevWidth, EntryHeight, HeaderGumpID );

				if ( node.Parent != null )
				{
					AddButton( x + PrevOffsetX, y + PrevOffsetY, PrevButtonID1, PrevButtonID2, 1, GumpButtonType.Reply, 0 );

					if ( PrevLabel )
						AddLabel( x + PrevLabelOffsetX, y + PrevLabelOffsetY, TextHue, "Previous" );
				}

				x += PrevWidth + OffsetSize;

				int emptyWidth = TotalWidth - (PrevWidth * 2) - NextWidth - (OffsetSize * 5) - (OldStyle ? SetWidth + OffsetSize : 0);

				if ( !OldStyle )
					AddImageTiled( x - (OldStyle ? OffsetSize : 0), y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0), EntryHeight, EntryGumpID );

				AddHtml( x + TextOffsetX, y, emptyWidth - TextOffsetX, EntryHeight, String.Format( "<center>{0}</center>", node.Name ), false, false );

				x += emptyWidth + OffsetSize;

				if ( OldStyle )
					AddImageTiled( x, y, TotalWidth - (OffsetSize * 3) - SetWidth, EntryHeight, HeaderGumpID );
				else
					AddImageTiled( x, y, PrevWidth, EntryHeight, HeaderGumpID );

				if ( page > 0 )
				{
					AddButton( x + PrevOffsetX, y + PrevOffsetY, PrevButtonID1, PrevButtonID2, 2, GumpButtonType.Reply, 0 );

					if ( PrevLabel )
						AddLabel( x + PrevLabelOffsetX, y + PrevLabelOffsetY, TextHue, "Previous" );
				}

				x += PrevWidth + OffsetSize;

				if ( !OldStyle )
					AddImageTiled( x, y, NextWidth, EntryHeight, HeaderGumpID );

				if ( (page + 1) * EntryCount < node.Children.Length )
				{
					AddButton( x + NextOffsetX, y + NextOffsetY, NextButtonID1, NextButtonID2, 3, GumpButtonType.Reply, 1 );

					if ( NextLabel )
						AddLabel( x + NextLabelOffsetX, y + NextLabelOffsetY, TextHue, "Next" );
				}

				for ( int i = 0, index = page * EntryCount; i < EntryCount && index < node.Children.Length; ++i, ++index )
				{
					x = BorderSize + OffsetSize;
					y += EntryHeight + OffsetSize;

					object child = node.Children[index];
					string name = "";

					if ( child is ParentNode )
						name = ((ParentNode)child).Name;
					else if ( child is ChildNode )
						name = ((ChildNode)child).Name;

					AddImageTiled( x, y, EntryWidth, EntryHeight, EntryGumpID );
					AddLabelCropped( x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, TextHue, name );

					x += EntryWidth + OffsetSize;

					if ( SetGumpID != 0 )
						AddImageTiled( x, y, SetWidth, EntryHeight, SetGumpID );

					AddButton( x + SetOffsetX, y + SetOffsetY, SetButtonID1, SetButtonID2, index + 4, GumpButtonType.Reply, 0 );
				}
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile;

				switch ( info.ButtonID )
				{
					case 1:
					{
						if ( m_Node.Parent != null )
							from.SendGump( new SendToGump( 0, from, m_Tree, m_Node.Parent ) );

						break;
					}
					case 2:
					{
						if ( m_Page > 0 )
							from.SendGump( new SendToGump( m_Page - 1, from, m_Tree, m_Node ) );

						break;
					}
					case 3:
					{
						if ( (m_Page + 1) * EntryCount < m_Node.Children.Length )
							from.SendGump( new SendToGump( m_Page + 1, from, m_Tree, m_Node ) );

						break;
					}
					default:
					{
						int index = info.ButtonID - 4;

						if ( index >= 0 && index < m_Node.Children.Length )
						{
							object o = m_Node.Children[index];

							if ( o is ParentNode )
							{
								from.SendGump( new SendToGump( 0, from, m_Tree, (ParentNode)o ) );
							}
							else
							{
								ChildNode n = (ChildNode)o;

								from.Target = new SendToTarget( n.Location, m_Tree.Map );
							}
						}

						break;
					}
				}
			}
		}
	}
