/*
 Original Mystical Sextant for Boats by Haazen
*/
using System;
using System.Text;
using Server.Gumps;
using Server.Multis;
using Server.Mobiles;
using Server.Movement;
using Server.Network;
using Server.Items;
using System.Reflection;

namespace Server.Commands
{
	public class StaffSextant
	{
		public static void Initialize()
		{
			CommandHandlers.Register("StaffSextant", AccessLevel.Counselor, new CommandEventHandler(SS_OnCommand));
			CommandSystem.Register( "SS", AccessLevel.Counselor, new CommandEventHandler( SS_OnCommand ) );
		}

		[Usage( "StaffSextant" )]
		[Aliases( "SS" )]
		[Description( "Opens Staff Sextant Gump." )]
		private static void SS_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;
			
			from.SendGump( new StaffSextantGump( (PlayerMobile)from ) );	
		}
	}
}

namespace Server.Items
{
	public class StaffSextant : Item
	{

		[Constructable]
		public StaffSextant() : base( 0x1057 )
		{
			Movable = true;
			Hue = 1266;
			Name = "Staff Sextant";
		}

		public override void OnDoubleClick( Mobile from )
		{			
			if ( IsChildOf( from.Backpack ) )
			{
				from.SendGump( new StaffSextantGump( (PlayerMobile)from ) );	
			}
			else
			{
				from.SendMessage( 1626, "It must be in your backpack." );
			}
		}

		public StaffSextant( Serial serial ) : base( serial )
		{
		}

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

	}
}

namespace Server.Gumps

{
	public class StaffSextantGump : Gump
	{
		private PlayerMobile m_From;

		public StaffSextantGump( PlayerMobile from ) : base( 40, 40 )
		{
			from.CloseGump( typeof( StaffSextantGump ) ); 
			m_From = from;

			AddPage( 0 );
			AddBackground( 0, 0, 140, 155, 83 );//5054 83
			AddImageTiled(8, 9, 126, 135, 1416);
			AddAlphaRegion(8, 9, 126, 135);

		AddButton( 20, 124, 0x15E6, 0x15E6, 1, GumpButtonType.Reply, 0 );// Bajar Z
		AddLabel( 52, 120, 0x34, "Height" );
		AddButton( 107, 124, 0x15E0, 0x15E0, 2, GumpButtonType.Reply, 0 );// Subir Z

		AddButton( 37, 31, 0x5787, 0x5787, 11, GumpButtonType.Reply, 0 ); //Oeste 1
		AddButton( 84, 31, 0x5780, 0x5780, 12, GumpButtonType.Reply, 0 ); //Norte 1
		AddButton( 37, 74, 0x5783, 0x5783, 13, GumpButtonType.Reply, 0 ); //Sur 1
		AddButton( 84, 74, 0x5784, 0x5784, 14, GumpButtonType.Reply, 0 ); //Este 1

		AddButton( 17, 11, 0x5787, 0x5787, 15, GumpButtonType.Reply, 0 ); //Oeste 5
		AddButton( 101, 11, 0x5780, 0x5780, 16, GumpButtonType.Reply, 0 ); //Norte 5
		AddButton( 17, 91, 0x5783, 0x5783, 17, GumpButtonType.Reply, 0 ); //Sur 5
		AddButton( 101, 91, 0x5784, 0x5784, 18, GumpButtonType.Reply, 0 ); //Este 5

		AddButton( 60, 10, 0x26AC, 0x26AC, 3, GumpButtonType.Reply, 0 ); //Noroeste 5
		AddButton( 60, 90, 0x26B2, 0x26B2, 4, GumpButtonType.Reply, 0 ); //Sureste 5
		AddButton( 20, 50, 0x26B5, 0x26B5, 5, GumpButtonType.Reply, 0 ); //Suroeste 5
		AddButton( 100, 50, 0x26AF, 0x26AF, 6, GumpButtonType.Reply, 0 ); //Noreste 5

		AddButton( 62, 31, 0x2621, 0x2621, 7, GumpButtonType.Reply, 0 ); //Noroeste 1
		AddButton( 62, 73, 0x2625, 0x2625, 8, GumpButtonType.Reply, 0 ); //Sureste 1
		AddButton( 40, 52, 0x2627, 0x2627, 9, GumpButtonType.Reply, 0 ); //Suroeste 1
		AddButton( 83, 52, 0x2623, 0x2623, 10, GumpButtonType.Reply, 0 ); //Noreste 1
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Container pack = m_From.Backpack;

			if ( pack != null ) // && pack.ConsumeTotal( typeof( Gold ), 2 ) )
			{
			   switch ( info.ButtonID )
			   {
				case 1: // Bajar Z
				{
					m_From.Z -= 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 2: // Subir Z
				{
					m_From.Z += 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 3: // Noroeste 5
				{
					m_From.X -= 5;
					m_From.Y -= 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 4: // Sureste 5
				{
					m_From.X += 5;
					m_From.Y += 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 5: // Suroeste 5
				{
					m_From.X -= 5;
					m_From.Y += 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 6: // Noreste 5
				{
					m_From.X += 5;
					m_From.Y -= 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 7: // Noroeste 1
				{
					m_From.X -= 1;
					m_From.Y -= 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 8: // Sureste 1
				{
					m_From.X += 1;
					m_From.Y += 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 9: // Suroeste 1
				{
					m_From.X -= 1;
					m_From.Y += 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 10: // Noreste 1
				{
					m_From.X += 1;
					m_From.Y -= 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 11: // Oeste 1
				{
					m_From.X -= 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 12: // Norte 1
				{
					m_From.Y -= 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 13: // Sur 1
				{
					m_From.Y += 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 14: // Este 1
				{
					m_From.X += 1;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 15: // Oeste 5
				{
					m_From.X -= 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 16: // Norte 5
				{
					m_From.Y -= 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 17: // Sur 5
				{
					m_From.Y += 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
				case 18: // Este 5
				{
					m_From.X += 5;
					m_From.SendGump( new StaffSextantGump( (PlayerMobile)m_From ) );
					break;
				}
			   }
			}
          	}
  	}
}
