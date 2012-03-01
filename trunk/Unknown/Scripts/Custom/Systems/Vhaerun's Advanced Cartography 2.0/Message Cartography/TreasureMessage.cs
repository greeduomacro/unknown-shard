using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Targeting;
using Server.ContextMenus;

namespace Server.Items
{
	public class TreasureMessage : MapItem
	{
		private int m_Level;
		private Map m_Map;
		private Point2D m_Location;
		private int m_MessageIndex;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level{ get{ return m_Level; } set{ m_Level = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Map ChestMap{ get{ return m_Map; } set{ m_Map = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Point2D Loc{ get{ return m_Location; } set{ m_Location = value; } }

		private static Point2D[] m_Locations;

		public static Point2D GetRandomLocation()
		{
			if ( m_Locations == null ) LoadLocations();
			if ( m_Locations.Length > 0 ) return m_Locations[Utility.Random( m_Locations.Length )];
			return Point2D.Zero;
		}

		private static void LoadLocations()
		{
			string filePath = Path.Combine( Core.BaseDirectory, "Data/treasure2.cfg" );

			ArrayList list = new ArrayList();
			ArrayList havenList = new ArrayList();

			if ( File.Exists( filePath ) )
			{
				using ( StreamReader ip = new StreamReader( filePath ) )
				{
					string line;

					while ( (line = ip.ReadLine()) != null )
					{
						try
						{
							string[] split = line.Split( ' ' );
							int x = Convert.ToInt32( split[0] ), y = Convert.ToInt32( split[1] );
							Point2D loc = new Point2D( x, y );
							list.Add( loc );
						}
						catch { }
					}
				}
			}

			m_Locations = (Point2D[])list.ToArray( typeof( Point2D ) );
		}

		[Constructable]
		public TreasureMessage( int level, Map map )
		{
			Name = "a handwritten message";
			Hue = 0x2EF;
			m_Level = level;
			m_Map = map;
			m_MessageIndex = Utility.Random( MessageEntry.Entries.Length );
			m_Location = GetRandomLocation();
		}

		public override void OnDoubleClick( Mobile from )
		{
			MessageEntry entry;

			if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 );
				return;
			}

			if ( m_MessageIndex >= 0 && m_MessageIndex < MessageEntry.Entries.Length ) entry = MessageEntry.Entries[m_MessageIndex];
			else entry = MessageEntry.Entries[m_MessageIndex = Utility.Random( MessageEntry.Entries.Length )];

			from.CloseGump( typeof( TreasureMessageGump ) );
			from.SendGump( new TreasureMessageGump( this, entry, m_Map, m_Location ) );
			SpawnGenerate( m_Location, Map );

			if ( from == null ) return;
		}

		protected void Spawn( Point2D p, Map map, BaseCreature spawn )
		{
			if ( map == null ) { spawn.Delete(); return; }

			int x = p.X, y = p.Y;

			if ( map.CanSpawnMobile( x, y, 0 ) )
			{
				spawn.MoveToWorld( new Point3D( x, y, 0 ), map );
			}
			else
			{
				int z = map.GetAverageZ( x, y );
				if ( map.CanSpawnMobile( x, y, z ) )
				{
					spawn.MoveToWorld( new Point3D( x, y, z ), map );
				}
				else if ( map.CanSpawnMobile( x, y, z+10 ) )
				{
					spawn.MoveToWorld( new Point3D( x, y, z+10 ), map );
				}
				else if ( map.CanSpawnMobile( x+1, y+1, z ) )
				{
					spawn.MoveToWorld( new Point3D( x+1, y+1, z ), map );
				}
				else if ( map.CanSpawnMobile( x+1, y+1, z+10 ) )
				{
					spawn.MoveToWorld( new Point3D( x+1, y+1, z+10 ), map );
				}
				else
				{
					spawn.MoveToWorld( new Point3D( x-1, y-1, 100 ), map );
				}
			}
			spawn.PackItem( new TreasureMessageChest( Utility.RandomMinMax( (((m_Level - 1) * 400) + 100), (((m_Level - 1) * 400) + 500) ) ) );
		}

		protected virtual void SpawnGenerate( Point2D p, Map map )
		{
			BaseCreature spawn;

			spawn = new TreasureEaters( (Utility.RandomMinMax( ((m_Level - 1) * 4), (((m_Level - 1) * 4) + 3) ) ) +1 );
			Spawn( p, map, spawn );
			Delete();
		}

		private class TreasureMessageGump : Gump
		{
			public TreasureMessage Tmessage = null;
			public int xc{ get{ if( Tmessage != null ) return Tmessage.Loc.X; else return 0; } }
			public int yc{ get{ if( Tmessage != null ) return Tmessage.Loc.Y; else return 0; } }

			public TreasureMessageGump( TreasureMessage tmessage, MessageEntry entry, Map map, Point2D loc ) : base( (640 - entry.Width) / 2, (480 - entry.Height) / 2 )
			{
				string fmtx;
				string fmty;
				Tmessage = tmessage;

				fmtx = String.Format( xc.ToString() );
				fmty = String.Format( yc.ToString() );

				AddPage( 0 );
				AddBackground( 0, 0, entry.Width, entry.Height, 2520 );

				switch ( Utility.Random( 4 ) )
				{
					case 0: AddHtml( 38, 38, entry.Width - 83, entry.Height - 86, String.Format( "I cannot find a way home, my friend. I am sending you this message in hopes you will come to my aid. Here are my coordinates." ), false, false ); break;
					case 1: AddHtml( 38, 38, entry.Width - 83, entry.Height - 86, String.Format( "My love, I've been set upon by evil creatures and I do not think I will survive. I am sorry... I've sent my coordinates in hope..." ), false, false ); break;
					case 2: AddHtml( 38, 38, entry.Width - 83, entry.Height - 86, String.Format( "I have found it! It was difficult, but I was victorious. Now, I must sleep in the forest at these coordinates." ), false, false ); break;
					case 3: AddHtml( 38, 38, entry.Width - 83, entry.Height - 86, String.Format( "Mother, I am coming home and I've made a friend. He's a nice bard named Durt. He said we need to take a detour along these coordinates." ), false, false ); break;
				}

				AddHtml( 50, 150, 150, 50, fmtx, false, false );
				AddHtml( 100, 150, 150, 100, fmty, false, false );
			}
		}

		private class MessageEntry
		{
			private int m_Width, m_Height;
			private string m_Message;

			public int Width{ get{ return m_Width; } }
			public int Height{ get{ return m_Height; } }
			public string Message{ get{ return m_Message; } }

			public MessageEntry( int width, int height, string message )
			{
				m_Width = width;
				m_Height = height;
				m_Message = message;
			}

			private static MessageEntry[] m_Entries = new MessageEntry[]
			{
				new MessageEntry( 280, 180, "You read the message, but the old parchment turns to dust when you do." )
			};

			public static MessageEntry[] Entries { get{ return m_Entries; } }
		}

		public TreasureMessage( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( m_Level );
			writer.Write( m_Map );
			writer.Write( m_Location );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (int)reader.ReadInt();
			m_Map = reader.ReadMap();
			m_Location = reader.ReadPoint2D();
		}
	}
}