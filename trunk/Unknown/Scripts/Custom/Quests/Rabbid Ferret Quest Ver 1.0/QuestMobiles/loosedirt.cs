// by evilfreak for the rabbid ferret quest v 1.0
using System;
using Server;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;


namespace Server.Items
{
	public class LooseDirt : Item
	{	
		private const string fallingFormat = "You fall through the loose dirt!!";

		private AccessLevel m_AccessLevel = (AccessLevel)2;//4 = Admin, 3 = Seer, 2 = Gm etc

		private ArrayList m_Destinations = new ArrayList();
		private ArrayList m_DestX = new ArrayList();
		private ArrayList m_DestY = new ArrayList();
		private ArrayList m_DestZ = new ArrayList();
		private ArrayList m_DestMaps = new ArrayList();

		
		
		[Constructable]
		public LooseDirt() : base( 0x913 )
		{
			Movable = false;
			
			Name = "Loose Dirt";
			
			
		}

		public LooseDirt( Serial serial ) : base( serial )
		{
		}

		public override bool OnMoveOver( Mobile m)
		{
			if ( m != null && m.Player && m.Mounted && m.Followers != 0 || m is BaseCreature )
			{
				m.SendMessage("Your mount is too afraid to go any further!!"); // You may not enter while mounted.
				m.SendMessage("You must dismount before you can go any further..."); // You may not enter while mounted.
				return false;
			}
			if ( m.Followers != 0 )
			{	
				return false;
			}
			else
			{
	
		



							//Gate Message
				m.LocalOverheadMessage( MessageType.Regular, Hue, true, String.Format( fallingFormat ) );
				m.SendMessage("You find yourself deeper inside the ferret tunnels.");
				
				m.X = 5169;
				m.Y = 1149;
				m.Z = 0;
							//End Message
			return false;
			}
		}

		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version

			writer.Write( (int)m_Destinations.Count );
			for ( int i = 0; i < m_Destinations.Count; ++i )
			{
				writer.Write( (string)m_Destinations[i] );
				writer.Write( (int)m_DestX[i] );
				writer.Write( (int)m_DestY[i] );
				writer.Write( (int)m_DestZ[i] );
				writer.Write( (int)m_DestMaps[i] );
			}
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					int count = reader.ReadInt();
					for ( int i = 0; i < count; ++i )
					{
						m_Destinations.Add( reader.ReadString() );
						m_DestX.Add( reader.ReadInt() );
						m_DestY.Add( reader.ReadInt() );
						m_DestZ.Add( reader.ReadInt() );
						m_DestMaps.Add( reader.ReadInt() );
					}
					break;
				}
			}
		}
	}
}




		



