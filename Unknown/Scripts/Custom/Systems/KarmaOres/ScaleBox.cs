// Original Ingot Box Author Unknown
// Scripted by Karmageddon
using System;
using System.Collections;
using Server;
using Server.Prompts;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Multis;
using Server.Regions;
using Server.Engines.Craft;

namespace Server.Items
{	
	public class ScaleBox : Item 
	{
		private int m_Black;
		private int m_Blue;
		private int m_Green;
		private int m_Red;
		private int m_Yellow;
		private int m_White;
		private int m_WithdrawIncrement;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int WithdrawIncrement { get { return m_WithdrawIncrement; } set { m_WithdrawIncrement = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Black{ get{ return m_Black; } set{ m_Black = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Blue{ get{ return m_Blue; } set{ m_Blue = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Green{ get{ return m_Green; } set{ m_Green = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Red{ get{ return m_Red; } set{ m_Red = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Yellow{ get{ return m_Yellow; } set{ m_Yellow = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int White{ get{ return m_White; } set{ m_White = value; InvalidateProperties(); } }
		[Constructable]
		
		public ScaleBox() : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 1109;
			Name = "Scale Box";
			WithdrawIncrement = 100;
		}
		
		[Constructable]
		public ScaleBox( int withdrawincrement ) : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 1109;
			Name = "Scale Box";
			WithdrawIncrement = withdrawincrement;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( from is PlayerMobile )
			from.SendGump( new ScaleBoxGump( (PlayerMobile)from, this ) );
		}

		public void BeginCombine( Mobile from )
		{
			from.Target = new ScaleBoxTarget( this );
		}

		public void EndCombine( Mobile from, object o )
		{
			if ( o is Item && ((Item)o).IsChildOf( from.Backpack ) )
			{
				if (!( o is BaseScales || o is BaseTool ))
				{
					from.SendMessage( "That is not an item you can put in here." );
				}
				if ( o is BlackScales )
				{

					if ( Black >= 20000 )
					from.SendMessage( "That Scale type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Black += curItem.Amount;
						curItem.Delete();
						from.SendGump( new ScaleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is BlueScales )
				{

					if ( Blue >= 20000 )
					from.SendMessage( "That Scale type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Blue += curItem.Amount;
						curItem.Delete();
						from.SendGump( new ScaleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is GreenScales )
				{

					if ( Green >= 20000 )
					from.SendMessage( "That Scale type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Green += curItem.Amount;
						curItem.Delete();
						from.SendGump( new ScaleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is RedScales )
				{

					if ( Red >= 20000 )
					from.SendMessage( "That Scale type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Red += curItem.Amount;
						curItem.Delete();
						from.SendGump( new ScaleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is YellowScales )
				{

					if ( Yellow >= 20000 )
					from.SendMessage( "That Scale type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Yellow += curItem.Amount;
						curItem.Delete();
						from.SendGump( new ScaleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is WhiteScales )
				{

					if ( White >= 20000 )
					from.SendMessage( "That Scale type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						White += curItem.Amount;
						curItem.Delete();
						from.SendGump( new ScaleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
			}
			else
			{
				from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
			}
		}

		public ScaleBox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) m_Black);
			writer.Write( (int) m_Blue);
			writer.Write( (int) m_Green);
			writer.Write( (int) m_Red);
			writer.Write( (int) m_Yellow);			
			writer.Write( (int) m_White);			
			writer.Write( (int) m_WithdrawIncrement);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			m_Black = reader.ReadInt();
			m_Blue = reader.ReadInt();
			m_Green = reader.ReadInt();
			m_Red = reader.ReadInt();
			m_Yellow = reader.ReadInt();			
			m_White = reader.ReadInt();	
			m_WithdrawIncrement = reader.ReadInt();
		}
	}
}


namespace Server.Items
{
	public class ScaleBoxGump : Gump
	{
		private PlayerMobile m_From;
		private ScaleBox m_Box;

		public ScaleBoxGump( PlayerMobile from, ScaleBox box ) : base( 25, 25 )
		{
			m_From = from;
			m_Box = box;

			m_From.CloseGump( typeof( ScaleBoxGump ) );

			AddPage( 0 );

			AddBackground( 12, 19, 210, 230, 9250);
			AddLabel( 100, 30, 32, @"Scale Box");
			
			AddLabel( 60, 50, 32, @"Add Item");
			AddButton( 25, 50, 4005, 4007, 1, GumpButtonType.Reply, 0);

			AddLabel( 60, 75, 32, @"Close");
			AddButton( 25, 75, 4005, 4007, 0, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 115, 0, @"Black");
			AddLabel( 150, 115, 0x480, box.Black.ToString() );
			AddButton( 25, 115, 4005, 4007, 3, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 135, 2223, @"Blue");
			AddLabel( 150, 135, 0x480, box.Blue.ToString() );
			AddButton( 25, 135, 4005, 4007, 4, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 155, 2128, @"Green");
			AddLabel( 150, 155, 0x480, box.Green.ToString() );
			AddButton( 25, 155, 4005, 4007, 5, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 175, 1644, @"Red");
			AddLabel( 150, 175, 0x480, box.Red.ToString() );
			AddButton( 25, 175, 4005, 4007, 6, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 195, 2215, @"Yellow");
			AddLabel(  150, 195, 0x480, box.Yellow.ToString() );
			AddButton(  25, 195, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 215, 2300, @"White");
			AddLabel(  150, 215, 0x480, box.White.ToString() );
			AddButton(  25, 215, 4005, 4007, 8, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Box.Deleted )
			return;
			
			if ( info.ButtonID == 1)
			{
				m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
				m_Box.BeginCombine( m_From );
			}
			
			if ( info.ButtonID == 3 )
			{
				if ( m_Box.Black > 0 )
				{
					if ( m_Box.Black > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new BlackScales(m_Box.WithdrawIncrement) );
						m_Box.Black = m_Box.Black - m_Box.WithdrawIncrement;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.Black > 0)
                				{
						m_From.AddToBackpack( new BlackScales(m_Box.Black) );
						m_Box.Black = 0;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that Scale!" );
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			
			if ( info.ButtonID == 4 )
			{
				if ( m_Box.Blue > 0 )
				{
					if ( m_Box.Blue > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new BlueScales(m_Box.WithdrawIncrement) );
						m_Box.Blue = m_Box.Blue - m_Box.WithdrawIncrement;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.Blue> 0)
                				{
						m_From.AddToBackpack( new BlueScales(m_Box.Blue) );
						m_Box.Blue = 0;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that Scales!" );
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 5 )
			{
				if ( m_Box.Green > 0 )
				{
					if ( m_Box.Green > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new GreenScales(m_Box.WithdrawIncrement) );
						m_Box.Green = m_Box.Green - m_Box.WithdrawIncrement;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.Green> 0)
                				{
						m_From.AddToBackpack( new GreenScales(m_Box.Green) );
						m_Box.Green = 0;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that Scale!" );
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 6 )
			{
				if ( m_Box.Red > 0 )
				{
					if ( m_Box.Red > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new RedScales(m_Box.WithdrawIncrement) );
						m_Box.Red = m_Box.Red - m_Box.WithdrawIncrement;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.Red> 0)
                				{
						m_From.AddToBackpack( new RedScales(m_Box.Red) );
						m_Box.Red = 0;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that Scale!" );
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
			if ( info.ButtonID == 7 )
			{
				if ( m_Box.Yellow > 0 )
				{
					if ( m_Box.Yellow > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new YellowScales(m_Box.WithdrawIncrement) );
						m_Box.Yellow = m_Box.Yellow - m_Box.WithdrawIncrement;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.Yellow > 0)
                				{
						m_From.AddToBackpack( new YellowScales(m_Box.Yellow) );
						m_Box.Yellow = 0;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that Scale!" );
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}			
			if ( info.ButtonID == 8 )
			{
				if ( m_Box.White > 0 )
				{
					if ( m_Box.White > m_Box.WithdrawIncrement )
					{
						m_From.AddToBackpack( new WhiteScales(m_Box.WithdrawIncrement) );
						m_Box.White = m_Box.White - m_Box.WithdrawIncrement;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else if (m_Box.White > 0)
                				{
						m_From.AddToBackpack( new WhiteScales(m_Box.White) );
						m_Box.White = 0;
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
					}
					else
					{
						m_From.SendMessage( "You do not have any of that Scale!" );
						m_From.SendGump( new ScaleBoxGump( m_From, m_Box ) );
						m_Box.BeginCombine( m_From );
					}
				}
			}
		}
	}

}

namespace Server.Items
{
	public class ScaleBoxTarget : Target
	{
		private ScaleBox m_Box;

		public ScaleBoxTarget( ScaleBox box ) : base( 18, false, TargetFlags.None )
		{
			m_Box = box;
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
			if ( m_Box.Deleted )
			return;

			m_Box.EndCombine( from, targeted );
		}
	}
}
