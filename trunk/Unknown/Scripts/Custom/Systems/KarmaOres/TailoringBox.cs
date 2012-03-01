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
	public class TailoringBox : Item 
	{
		private int m_Leather;
		private int m_Spined;
		private int m_Horned;
		private int m_Barbed;
		private int m_Dragon;
		private int m_Daemon;
		private int m_Clothe;
		private int m_Bones;		
		private int m_Sewing;
		private int m_RunicSpined;
		private int m_RunicHorned;
		private int m_RunicBarbed;
		private int m_RunicDragon;
		private int m_RunicDaemon;		
		private int m_WithdrawIncrement;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int WithdrawIncrement { get { return m_WithdrawIncrement; } set { m_WithdrawIncrement = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Leather{ get{ return m_Leather; } set{ m_Leather = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Spined{ get{ return m_Spined; } set{ m_Spined = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Horned{ get{ return m_Horned; } set{ m_Horned = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Barbed{ get{ return m_Barbed; } set{ m_Barbed = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Dragon{ get{ return m_Dragon; } set{ m_Dragon = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Daemon{ get{ return m_Daemon; } set{ m_Daemon = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Clothe{ get{ return m_Clothe; } set{ m_Clothe = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Bones{ get{ return m_Bones; } set{ m_Bones = value; InvalidateProperties(); } }		
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Sewing{ get{ return m_Sewing; } set{ m_Sewing = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicSpined{ get{ return m_RunicSpined; } set{ m_RunicSpined = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicHorned{ get{ return m_RunicHorned; } set{ m_RunicHorned = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicBarbed{ get{ return m_RunicBarbed; } set{ m_RunicBarbed = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicDragon{ get{ return m_RunicDragon; } set{ m_RunicDragon = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicDaemon{ get{ return m_RunicDaemon; } set{ m_RunicDaemon = value; InvalidateProperties(); } }
		
		[Constructable]
		public TailoringBox() : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 3;
			Name = "Tailoring Box";
			WithdrawIncrement = 100;
		}
		
		[Constructable]
		public TailoringBox( int withdrawincrement ) : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 3;
			Name = "Tailroing Box";
			WithdrawIncrement = withdrawincrement;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( from is PlayerMobile )
			from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
		}

		public void BeginCombine( Mobile from )
		{
			from.Target = new TailoringBoxTarget( this );
		}

		public void EndCombine( Mobile from, object o )
		{
			if ( o is Item && ((Item)o).IsChildOf( from.Backpack ) )
			{
				if (!( o is BaseLeather || o is BaseTool || o is BaseRunicTool ))
				{
					from.SendMessage( "That is not an item you can put in here." );
				}
				if ( o is Leather )
				{

					if ( Leather >= 20000 )
					from.SendMessage( "That Leather type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Leather += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is SpinedLeather )
				{

					if ( Spined >= 20000 )
					from.SendMessage( "That Leather type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Spined += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is HornedLeather )
				{

					if ( Horned >= 20000 )
					from.SendMessage( "That Leather type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Horned += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is BarbedLeather )
				{

					if ( Barbed >= 20000 )
					from.SendMessage( "That Leather type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Barbed += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is DragonLeather )
				{

					if ( Dragon >= 20000 )
					from.SendMessage( "That Leather type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Dragon += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is DaemonLeather )
				{

					if ( Daemon >= 20000 )
					from.SendMessage( "That Leather type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Daemon += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is Cloth )
				{

					if ( Clothe >= 20000 )
					from.SendMessage( "That item is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Clothe += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is Bone )
				{

					if ( Bones >= 20000 )
					from.SendMessage( "That item is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Bones += curItem.Amount;
						curItem.Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is SewingKit )
				{
					if ( Sewing > (20000 - ((BaseTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						Sewing = ( Sewing + ((BaseTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicSewingKit && ((RunicSewingKit)o).Resource == CraftResource.SpinedLeather )
				{
					if ( RunicSpined > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicSpined = ( RunicSpined + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicSp )
				{
					if ( RunicSpined > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicSpined = ( RunicSpined + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicSewingKit && ((RunicSewingKit)o).Resource == CraftResource.HornedLeather )
				{
					if ( RunicHorned > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicHorned = ( RunicHorned + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicHo )
				{
					if ( RunicHorned > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicHorned = ( RunicHorned + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicSewingKit && ((RunicSewingKit)o).Resource == CraftResource.BarbedLeather )
				{
					if ( RunicBarbed > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBarbed = ( RunicBarbed + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicBa )
				{
					if ( RunicBarbed > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBarbed = ( RunicBarbed + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicSewingKit && ((RunicSewingKit)o).Resource == CraftResource.DragonLeather )
				{
					if ( RunicDragon > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicDragon = ( RunicDragon + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicDr )
				{
					if ( RunicDragon > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicDragon = ( RunicDragon + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicSewingKit && ((RunicSewingKit)o).Resource == CraftResource.DaemonLeather )
				{
					if ( RunicDaemon > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicDaemon = ( RunicDaemon + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicDa )
				{
					if ( RunicDaemon > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicDaemon = ( RunicDaemon + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new TailoringBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}				
				
			}
			else
			{
				from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
			}
		}

		public TailoringBox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) m_Leather);
			writer.Write( (int) m_Spined);
			writer.Write( (int) m_Horned);
			writer.Write( (int) m_Barbed);
			writer.Write( (int) m_Dragon);			
			writer.Write( (int) m_Daemon);
			writer.Write( (int) m_Clothe);
			writer.Write( (int) m_Bones);			
			writer.Write( (int) m_Sewing);
			writer.Write( (int) m_RunicSpined);		
			writer.Write( (int) m_RunicHorned);
			writer.Write( (int) m_RunicBarbed);
			writer.Write( (int) m_RunicDragon);			
			writer.Write( (int) m_RunicDaemon);			
			writer.Write( (int) m_WithdrawIncrement);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			m_Leather = reader.ReadInt();
			m_Spined = reader.ReadInt();
			m_Horned = reader.ReadInt();
			m_Barbed = reader.ReadInt();
			m_Dragon = reader.ReadInt();			
			m_Daemon = reader.ReadInt();
			m_Clothe = reader.ReadInt();
			m_Bones = reader.ReadInt();			
			m_Sewing = reader.ReadInt();		
			m_RunicSpined = reader.ReadInt();
			m_RunicHorned = reader.ReadInt();
			m_RunicBarbed = reader.ReadInt();
			m_RunicDragon = reader.ReadInt();			
			m_RunicDaemon = reader.ReadInt();			
			m_WithdrawIncrement = reader.ReadInt();
		}
	}
}


namespace Server.Items
{
	public class TailoringBoxGump : Gump
	{
		private PlayerMobile m_From;
		private TailoringBox m_Box;

		public TailoringBoxGump( PlayerMobile from, TailoringBox box ) : base( 25, 25 )
		{
			m_From = from;
			m_Box = box;

			m_From.CloseGump( typeof( TailoringBoxGump ) );

			AddPage( 0 );

			AddBackground( 12, 19, 486, 250, 9250);
			AddLabel( 200, 30, 32, @"Tailoring Box");
			
			AddLabel( 60, 50, 32, @"Add Item");
			AddButton( 25, 50, 4005, 4007, 1, GumpButtonType.Reply, 0);

			AddLabel( 60, 75, 32, @"Close");
			AddButton( 25, 75, 4005, 4007, 0, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 115, 0, @"Leather");
			AddLabel( 150, 115, 0x480, box.Leather.ToString() );
			AddButton( 25, 115, 4005, 4007, 3, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 135, 2219, @"Spined");
			AddLabel( 150, 135, 0x480, box.Spined.ToString() );
			AddButton( 25, 135, 4005, 4007, 4, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 155, 2116, @"Horned");
			AddLabel( 150, 155, 0x480, box.Horned.ToString() );
			AddButton( 25, 155, 4005, 4007, 5, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 175, 2128, @"Barbed");
			AddLabel( 150, 175, 0x480, box.Barbed.ToString() );
			AddButton( 25, 175, 4005, 4007, 6, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 195, 1159, @"Dragon");
			AddLabel(  150, 195, 0x480, box.Dragon.ToString() );
			AddButton(  25, 195, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 215, 986, @"Daemon");
			AddLabel(  150, 215, 0x480, box.Daemon.ToString() );
			AddButton(  25, 215, 4005, 4007, 8, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 235, 990, @"Cloth");
			AddLabel(  150, 235, 0x480, box.Clothe.ToString() );
			AddButton(  25, 235, 4005, 4007, 9, GumpButtonType.Reply, 0 );
						
			AddLabel( 320, 115, 0, @"Sewing Kit" );
			AddLabel( 410, 115, 0x480, box.Sewing.ToString() );
			AddButton( 285, 115, 4005, 4007, 10, GumpButtonType.Reply, 0 );			
			
			AddLabel(320, 135, 2219, @"Spined");
			AddLabel( 410, 135, 0x480, box.RunicSpined.ToString() );
			AddButton(285, 135, 4005, 4007, 11, GumpButtonType.Reply, 0);
			
			AddLabel(320, 155, 2116, @"Horned");
			AddLabel( 410, 155, 0x480, box.RunicHorned.ToString() );
			AddButton(285, 155, 4005, 4007, 12, GumpButtonType.Reply, 0);
			
			AddLabel(320, 175, 2128, @"Barbed");
			AddLabel( 410, 175, 0x480, box.RunicBarbed.ToString() );
			AddButton(285, 175, 4005, 4007, 13, GumpButtonType.Reply, 0);
			
			AddLabel(320, 195, 1159, @"Dragon");
			AddLabel( 410, 195, 0x480, box.RunicDragon.ToString() );
			AddButton(285, 195, 4005, 4007, 14, GumpButtonType.Reply, 0);
			
			AddLabel(320, 215, 986, @"Daemon");
			AddLabel( 410, 215, 0x480, box.RunicDaemon.ToString() );
			AddButton(285, 215, 4005, 4007, 15, GumpButtonType.Reply, 0);
			
			AddLabel(320, 235, 990, @"Bone");
			AddLabel( 410, 235, 0x480, box.Bones.ToString() );
			AddButton(285, 235, 4005, 4007, 16, GumpButtonType.Reply, 0);
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Box.Deleted )
			return;
			
			if ( info.ButtonID == 1)
			{
				m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				m_Box.BeginCombine( m_From );
			}
			
			if ( info.ButtonID == 3 )
			{
				if ( m_Box.Leather > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new Leather(m_Box.WithdrawIncrement) );
					m_Box.Leather = m_Box.Leather - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if (m_Box.Leather > 0)
                		{
                    			m_From.AddToBackpack(new Leather(m_Box.Leather));  					//Sends all stored ingots of whichever type to players backpack
                    			m_Box.Leather = 0;						     						//Sets the count in the key back to 0
                    			m_From.SendGump(new TailoringBoxGump(m_From, m_Box));					//Resets the gump with the new info
                		}
				else
				{
					m_From.SendMessage( "You do not have any of that Leather!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			
			if ( info.ButtonID == 4 )
			{
				if ( m_Box.Spined > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new SpinedLeather(m_Box.WithdrawIncrement) );
					m_Box.Spined = m_Box.Spined - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Spined > 0 )
				{
					m_From.AddToBackpack( new SpinedLeather(m_Box.Spined) );
					m_Box.Spined = 0;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Leather!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 5 )
			{
				if ( m_Box.Horned > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new HornedLeather(m_Box.WithdrawIncrement) );
					m_Box.Horned = m_Box.Horned - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Horned > 0 )
				{
					m_From.AddToBackpack( new HornedLeather(m_Box.Horned) );
					m_Box.Horned = 0;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Leather!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 6 )
			{
				if ( m_Box.Barbed > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new BarbedLeather(m_Box.WithdrawIncrement) );
					m_Box.Barbed = m_Box.Barbed - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Barbed > 0 )
				{
					m_From.AddToBackpack( new BarbedLeather(m_Box.Barbed) );
					m_Box.Barbed = 0;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Leather!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 7 )
			{
				if ( m_Box.Dragon > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new DragonLeather(m_Box.WithdrawIncrement) );
					m_Box.Dragon = m_Box.Dragon - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Dragon > 0 )
				{
					m_From.AddToBackpack( new DragonLeather(m_Box.Dragon) );
					m_Box.Dragon = 0;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Leather!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 8 )
			{
				if ( m_Box.Daemon > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new DaemonLeather(m_Box.WithdrawIncrement) );
					m_Box.Daemon = m_Box.Daemon - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Daemon > 0 )
				{
					m_From.AddToBackpack( new DaemonLeather(m_Box.Daemon) );
					m_Box.Daemon = 0;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Leather!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 9 )
			{
				if ( m_Box.Clothe > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new Cloth(m_Box.WithdrawIncrement) );
					m_Box.Clothe = m_Box.Clothe - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Clothe > 0 )
				{
					m_From.AddToBackpack( new Cloth(m_Box.Clothe) );
					m_Box.Clothe = 0;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 10 )
			{
				if ( m_Box.Sewing > 0 )
				{
					m_From.AddToBackpack( new SewingKit(m_Box.Sewing) );
					m_Box.Sewing = ( 0 );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 11 )
			{
				if ( m_Box.RunicSpined > 0 )
				{
					m_From.AddToBackpack( new RunicSp(m_Box.RunicSpined) );
					m_Box.RunicSpined = ( 0 );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 12 )
			{
				if ( m_Box.RunicHorned > 0 )
				{
					m_From.AddToBackpack( new RunicHo(m_Box.RunicHorned) );
					m_Box.RunicHorned = ( 0 );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 13 )
			{
				if ( m_Box.RunicBarbed > 0 )
				{
					m_From.AddToBackpack( new RunicBa(m_Box.RunicBarbed) );
					m_Box.RunicBarbed = ( 0 );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 14 )
			{
				if ( m_Box.RunicDragon > 0 )
				{
					m_From.AddToBackpack( new RunicDr(m_Box.RunicDragon) );
					m_Box.RunicDragon = ( 0 );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 15 )
			{
				if ( m_Box.RunicDaemon > 0 )
				{
					m_From.AddToBackpack( new RunicDa(m_Box.RunicDaemon) );
					m_Box.RunicDaemon= ( 0 );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 16 )
			{
				if ( m_Box.Bones > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new Bone(m_Box.WithdrawIncrement) );
					m_Box.Bones = m_Box.Bones - m_Box.WithdrawIncrement;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Bones > 0 )
				{
					m_From.AddToBackpack( new Bone(m_Box.Bones) );
					m_Box.Bones = 0;
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new TailoringBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}						
		}
	}

}

namespace Server.Items
{
	public class TailoringBoxTarget : Target
	{
		private TailoringBox m_Box;

		public TailoringBoxTarget( TailoringBox box ) : base( 18, false, TargetFlags.None )
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
