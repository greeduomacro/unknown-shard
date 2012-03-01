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
	public class MarbleBox : Item 
	{
		private int m_Marble;
		private int m_DullCopper;
		private int m_ShadowIron;
		private int m_Copper;
		private int m_Bronze;
		private int m_Silver;
		private int m_Gold;
		private int m_Agapite;
		private int m_Platinum;
		private int m_Mythril;
		private int m_Verite;
		private int m_Valorite;
		private int m_Obsidian;
		private int m_Jade;
		private int m_Moonstone;
		private int m_Sunstone;
		private int m_Bloodstone;
		private int m_MarbleChisel;		
		private int m_WithdrawIncrement;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int WithdrawIncrement { get { return m_WithdrawIncrement; } set { m_WithdrawIncrement = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Marble{ get{ return m_Marble; } set{ m_Marble = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int DullCopper{ get{ return m_DullCopper; } set{ m_DullCopper = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int ShadowIron{ get{ return m_ShadowIron; } set{ m_ShadowIron = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Copper{ get{ return m_Copper; } set{ m_Copper = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Bronze{ get{ return m_Bronze; } set{ m_Bronze = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Silver{ get{ return m_Silver; } set{ m_Silver = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Gold{ get{ return m_Gold; } set{ m_Gold = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Agapite{ get{ return m_Agapite; } set{ m_Agapite = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Platinum{ get{ return m_Platinum; } set{ m_Platinum = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Mythril{ get{ return m_Mythril; } set{ m_Mythril = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Verite{ get{ return m_Verite; } set{ m_Verite = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Valorite{ get{ return m_Valorite; } set{ m_Valorite = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Obsidian{ get{ return m_Obsidian; } set{ m_Obsidian = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Jade{ get{ return m_Jade; } set{ m_Jade = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Moonstone{ get{ return m_Moonstone; } set{ m_Moonstone = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Sunstone{ get{ return m_Sunstone; } set{ m_Sunstone = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Bloodstone{ get{ return m_Bloodstone; } set{ m_Bloodstone = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int MarbleChisel{ get{ return m_MarbleChisel; } set{ m_MarbleChisel = value; InvalidateProperties(); } }
		
		[Constructable]
		public MarbleBox() : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 991;
			Name = "Marble Box";
			WithdrawIncrement = 10;
		}
		
		[Constructable]
		public MarbleBox( int withdrawincrement ) : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 991;
			Name = "Marble Box";
			WithdrawIncrement = withdrawincrement;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( from is PlayerMobile )
			from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
		}

		public void BeginCombine( Mobile from )
		{
			from.Target = new MarbleBoxTarget( this );
		}

		public void EndCombine( Mobile from, object o )
		{
			if (o is Item && (((Item)o).IsChildOf(from.Backpack) || ((Item)o).IsChildOf(from.BankBox)))
			{
				if (!( o is BaseMarble || o is BaseTool ))
				{
					from.SendMessage( "That is not an item you can put in here." );
				}
				if ( o is Marble )
				{

					if ( Marble >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Marble += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is DullCopperMarble )
				{

					if ( DullCopper >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						DullCopper += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is ShadowIronMarble )
				{

					if ( ShadowIron >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						ShadowIron += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is CopperMarble )
				{

					if ( Copper >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Copper += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is BronzeMarble )
				{

					if ( Bronze >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Bronze += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is SilverMarble )
				{

					if ( Silver >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Silver += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is GoldMarble )
				{

					if ( Gold >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Gold += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is AgapiteMarble )
				{

					if ( Agapite >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Agapite += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is PlatinumMarble )
				{

					if ( Platinum >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Platinum += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is MythrilMarble )
				{

					if ( Mythril >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Mythril += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is VeriteMarble )
				{

					if ( Verite >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Verite += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is ValoriteMarble )
				{

					if ( Valorite >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Valorite += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is ObsidianMarble )
				{

					if ( Obsidian >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Obsidian += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is JadeMarble )
				{

					if ( Jade >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Jade += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is MoonstoneMarble )
				{

					if ( Moonstone >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Moonstone += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is SunstoneMarble )
				{

					if ( Sunstone >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Sunstone += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is BloodstoneMarble )
				{

					if ( Bloodstone >= 20000 )
					from.SendMessage( "That Marble type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Bloodstone += curItem.Amount;
						curItem.Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is MarbleCraftingChisels )
				{
					if ( MarbleChisel > (20000 - ((BaseTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						MarbleChisel = ( MarbleChisel + ((BaseTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new MarbleBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}				
				
			}
			else
			{
				from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
			}
		}

		public MarbleBox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) m_Marble);
			writer.Write( (int) m_DullCopper);
			writer.Write( (int) m_ShadowIron);
			writer.Write( (int) m_Copper);
			writer.Write( (int) m_Bronze);			
			writer.Write( (int) m_Gold);
			writer.Write( (int) m_Agapite);			
			writer.Write( (int) m_Verite);
			writer.Write( (int) m_Valorite);
			writer.Write( (int) m_Silver);
			writer.Write( (int) m_Platinum);
			writer.Write( (int) m_Mythril);
			writer.Write( (int) m_Obsidian);
			writer.Write( (int) m_Jade);
			writer.Write( (int) m_Moonstone);
			writer.Write( (int) m_Sunstone);
			writer.Write( (int) m_Bloodstone);
			writer.Write( (int) m_MarbleChisel);			
			writer.Write( (int) m_WithdrawIncrement);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			m_Marble = reader.ReadInt();
			m_DullCopper = reader.ReadInt();
			m_ShadowIron = reader.ReadInt();
			m_Copper = reader.ReadInt();
			m_Bronze = reader.ReadInt();			
			m_Gold = reader.ReadInt();
			m_Agapite = reader.ReadInt();			
			m_Verite = reader.ReadInt();
			m_Valorite = reader.ReadInt();
			m_Silver = reader.ReadInt();
			m_Platinum = reader.ReadInt();
			m_Mythril = reader.ReadInt();
			m_Obsidian = reader.ReadInt();
			m_Jade = reader.ReadInt();
			m_Moonstone = reader.ReadInt();
			m_Sunstone = reader.ReadInt();
			m_Bloodstone = reader.ReadInt();
			m_MarbleChisel = reader.ReadInt();			
			m_WithdrawIncrement = reader.ReadInt();
		}
	}
}


namespace Server.Items
{
	public class MarbleBoxGump : Gump
	{
		private PlayerMobile m_From;
		private MarbleBox m_Box;

		public MarbleBoxGump( PlayerMobile from, MarbleBox box ) : base( 25, 25 )
		{
			m_From = from;
			m_Box = box;

			m_From.CloseGump( typeof( MarbleBoxGump ) );

			AddPage( 0 );

			AddBackground( 12, 19, 486, 290, 9250);
			AddLabel( 200, 30, 32, @"Marble Box");
			
			AddLabel( 60, 50, 32, @"Add Item");
			AddButton( 25, 50, 4005, 4007, 1, GumpButtonType.Reply, 0);

			AddLabel( 60, 75, 32, @"Close");
			AddButton( 25, 75, 4005, 4007, 0, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 115, 0, @"Marble");
			AddLabel( 150, 115, 0x480, box.Marble.ToString() );
			AddButton( 25, 115, 4005, 4007, 3, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 135, 2418, @"Dull Copper");
			AddLabel( 150, 135, 0x480, box.DullCopper.ToString() );
			AddButton( 25, 135, 4005, 4007, 4, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 155, 2405, @"Shadow Iron");
			AddLabel( 150, 155, 0x480, box.ShadowIron.ToString() );
			AddButton( 25, 155, 4005, 4007, 5, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 175, 2412, @"Copper");
			AddLabel( 150, 175, 0x480, box.Copper.ToString() );
			AddButton( 25, 175, 4005, 4007, 6, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 195, 2417, @"Bronze");
			AddLabel(  150, 195, 0x480, box.Bronze.ToString() );
			AddButton(  25, 195, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 215, 2212, @"Golden");
			AddLabel(  150, 215, 0x480, box.Gold.ToString() );
			AddButton(  25, 215, 4005, 4007, 8, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 235, 2424, @"Agapite");
			AddLabel( 150, 235, 0x480, box.Agapite.ToString() );
			AddButton( 25, 235, 4005, 4007, 9, GumpButtonType.Reply, 0 );
						
			AddLabel( 60, 255, 2206, @"Verite");
			AddLabel( 150, 255, 0x480, box.Verite.ToString() );
			AddButton( 25, 255, 4005, 4007, 10, GumpButtonType.Reply, 0 );			
			
			AddLabel( 60, 275, 2218, @"Valorite");
			AddLabel( 150, 275, 0x480, box.Valorite.ToString() );
			AddButton( 25, 275, 4005, 4007, 11, GumpButtonType.Reply, 0);
			
			AddLabel(320, 115, 1149, @"Silver");
			AddLabel( 425, 115, 0x480, box.Silver.ToString() );
			AddButton(285, 115, 4005, 4007, 12, GumpButtonType.Reply, 0);
			
			AddLabel(320, 135, 1171, @"Platinum");
			AddLabel( 425, 135, 0x480, box.Platinum.ToString() );
			AddButton(285, 135, 4005, 4007, 13, GumpButtonType.Reply, 0);
			
			AddLabel(320, 155, 1157, @"Mythril");
			AddLabel( 425, 155, 0x480, box.Mythril.ToString() );
			AddButton(285, 155, 4005, 4007, 14, GumpButtonType.Reply, 0);
			
			AddLabel(320, 175, 1108, @"Obsidian");
			AddLabel( 425, 175, 0x480, box.Obsidian.ToString() );
			AddButton(285, 175, 4005, 4007, 15, GumpButtonType.Reply, 0);
			
			AddLabel(320, 195, 1163, @"Jade");
			AddLabel( 425, 195, 0x480, box.Jade.ToString() );
			AddButton(285, 195, 4005, 4007, 16, GumpButtonType.Reply, 0);
			
			AddLabel(320, 215, 1155, @"Moonstone");
			AddLabel( 425, 215, 0x480, box.Moonstone.ToString() );
			AddButton(285, 215, 4005, 4007, 17, GumpButtonType.Reply, 0);
			
			AddLabel(320, 235, 1359, @"Sunstone");
			AddLabel( 425, 235, 0x480, box.Sunstone.ToString() );
			AddButton(285, 235, 4005, 4007, 18, GumpButtonType.Reply, 0);
			
			AddLabel(320, 255, 1156, @"Bloodstone");
			AddLabel( 425, 255, 0x480, box.Bloodstone.ToString() );
			AddButton(285, 255, 4005, 4007, 19, GumpButtonType.Reply, 0);
			
			AddLabel(320, 275, 990, @"Marble Chisels");
			AddLabel( 425, 275, 0x480, box.MarbleChisel.ToString() );
			AddButton(285, 275, 4005, 4007, 20, GumpButtonType.Reply, 0);
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Box.Deleted )
			return;
			
			if ( info.ButtonID == 1)
			{
				m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				m_Box.BeginCombine( m_From );
			}
			
			if ( info.ButtonID == 3 )
			{				
				if (m_Box.Marble > 0)
                		{
                    			m_From.AddToBackpack(new Marble());  					//Sends all stored Marbles of whichever type to players backpack
                    			m_Box.Marble = m_Box.Marble - 1;						     						//Sets the count in the key back to 0
                    			m_From.SendGump(new MarbleBoxGump(m_From, m_Box));					//Resets the gump with the new info
                		}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			
			if ( info.ButtonID == 4 )
			{
				if ( m_Box.DullCopper > 0 )
				{
					m_From.AddToBackpack( new DullCopperMarble() );
					m_Box.DullCopper = m_Box.DullCopper - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 5 )
			{
				if ( m_Box.ShadowIron > 0 )
				{
					m_From.AddToBackpack( new ShadowIronMarble() );
					m_Box.ShadowIron = m_Box.ShadowIron - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 6 )
			{
				if ( m_Box.Copper > 0 )
				{
					m_From.AddToBackpack( new CopperMarble() );
					m_Box.Copper = m_Box.Copper - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 7 )
			{
				if ( m_Box.Bronze > 0 )
				{
					m_From.AddToBackpack( new BronzeMarble() );
					m_Box.Bronze = m_Box.Bronze - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 8 )
			{
				if ( m_Box.Gold > 0 )
				{
					m_From.AddToBackpack( new GoldMarble() );
					m_Box.Gold = m_Box.Gold - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 9 )
			{
				if ( m_Box.Agapite > 0 )
				{
					m_From.AddToBackpack( new AgapiteMarble() );
					m_Box.Agapite = m_Box.Agapite - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 10 )
			{
				if ( m_Box.Verite > 0 )
				{
					m_From.AddToBackpack( new VeriteMarble() );
					m_Box.Verite = m_Box.Verite - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 11 )
			{
				if ( m_Box.Valorite > 0 )
				{
					m_From.AddToBackpack( new ValoriteMarble() );
					m_Box.Valorite = m_Box.Valorite - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 12 )
			{
				if ( m_Box.Silver > 0 )
				{
					m_From.AddToBackpack( new SilverMarble() );
					m_Box.Silver = m_Box.Silver - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 13 )
			{
				if ( m_Box.Platinum > 0 )
				{
					m_From.AddToBackpack( new PlatinumMarble() );
					m_Box.Platinum = m_Box.Platinum - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 14 )
			{
				if ( m_Box.Mythril > 0 )
				{
					m_From.AddToBackpack( new MythrilMarble() );
					m_Box.Mythril = m_Box.Mythril - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 15 )
			{
				if ( m_Box.Obsidian > 0 )
				{
					m_From.AddToBackpack( new ObsidianMarble() );
					m_Box.Obsidian = m_Box.Obsidian - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 16 )
			{
				if ( m_Box.Jade > 0 )
				{
					m_From.AddToBackpack( new JadeMarble() );
					m_Box.Jade = m_Box.Jade - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 17 )
			{
				if ( m_Box.Moonstone > 0 )
				{
					m_From.AddToBackpack( new MoonstoneMarble() );
					m_Box.Moonstone = m_Box.Moonstone - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}

			if ( info.ButtonID == 18 )
			{
				if ( m_Box.Sunstone > 0 )
				{
					m_From.AddToBackpack( new SunstoneMarble() );
					m_Box.Sunstone = m_Box.Sunstone - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 19 )
			{
				if ( m_Box.Bloodstone > 0 )
				{
					m_From.AddToBackpack( new BloodstoneMarble() );
					m_Box.Bloodstone = m_Box.Bloodstone - 1;
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Marble!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 20 )
			{
				if ( m_Box.MarbleChisel > 0 )
				{
					m_From.AddToBackpack( new MarbleCraftingChisels(m_Box.MarbleChisel) );
					m_Box.MarbleChisel = ( 0 );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new MarbleBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}						
		}
	}

}

namespace Server.Items
{
	public class MarbleBoxTarget : Target
	{
		private MarbleBox m_Box;

		public MarbleBoxTarget( MarbleBox box ) : base( 18, false, TargetFlags.None )
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
