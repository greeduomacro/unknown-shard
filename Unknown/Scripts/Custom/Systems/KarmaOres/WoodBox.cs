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
	public class WoodBox : Item 
	{
		private int m_Board;
		private int m_Pine;
		private int m_Cedar;
		private int m_Cherry;
		private int m_Mahogany;
		private int m_Oak;
		private int m_Ash;
		private int m_Yew;
		private int m_Heartwood;
		private int m_Bloodwood;
		private int m_Frostwood;
		private int m_Saw;
		private int m_Hammer;		
		private int m_Fletcher;
		private int m_RunicPine;
		private int m_RunicCedar;
		private int m_RunicCherry;
		private int m_RunicMahogany;
		private int m_RunicOak;
		private int m_RunicAsh;
		private int m_RunicYew;
		private int m_RunicHeartwood;
		private int m_RunicBloodwood;
		private int m_RunicFrostwood;		
		private int m_WithdrawIncrement;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int WithdrawIncrement { get { return m_WithdrawIncrement; } set { m_WithdrawIncrement = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Board{ get{ return m_Board; } set{ m_Board = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Pine{ get{ return m_Pine; } set{ m_Pine = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Cedar{ get{ return m_Cedar; } set{ m_Cedar = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Cherry{ get{ return m_Cherry; } set{ m_Cherry = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Mahogany{ get{ return m_Mahogany; } set{ m_Mahogany = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Oak{ get{ return m_Oak; } set{ m_Oak = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Ash{ get{ return m_Ash; } set{ m_Ash = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Yew{ get{ return m_Yew; } set{ m_Yew = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Heartwood{ get{ return m_Heartwood; } set{ m_Heartwood = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Bloodwood{ get{ return m_Bloodwood; } set{ m_Bloodwood = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Frostwood{ get{ return m_Frostwood; } set{ m_Frostwood = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Saw{ get{ return m_Saw; } set{ m_Saw = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Hammer{ get{ return m_Hammer; } set{ m_Hammer = value; InvalidateProperties(); } }		
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Fletcher{ get{ return m_Fletcher; } set{ m_Fletcher = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicPine{ get{ return m_RunicPine; } set{ m_RunicPine = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicCedar{ get{ return m_RunicCedar; } set{ m_RunicCedar = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicCherry{ get{ return m_RunicCherry; } set{ m_RunicCherry = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicMahogany{ get{ return m_RunicMahogany; } set{ m_RunicMahogany = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicOak{ get{ return m_RunicOak; } set{ m_RunicOak = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicAsh{ get{ return m_RunicAsh; } set{ m_RunicAsh = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicYew{ get{ return m_RunicYew; } set{ m_RunicYew = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicHeartwood{ get{ return m_RunicHeartwood; } set{ m_RunicHeartwood = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicBloodwood{ get{ return m_RunicBloodwood; } set{ m_RunicBloodwood = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicFrostwood{ get{ return m_RunicFrostwood; } set{ m_RunicFrostwood = value; InvalidateProperties(); } }
		
		[Constructable]
		public WoodBox() : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 1150;
			Name = "Wood Box";
			WithdrawIncrement = 100;
		}
		
		[Constructable]
		public WoodBox( int withdrawincrement ) : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 1150;
			Name = "Wood Box";
			WithdrawIncrement = withdrawincrement;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( from is PlayerMobile )
			from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
		}

		public void BeginCombine( Mobile from )
		{
			from.Target = new WoodBoxTarget( this );
		}

		public void EndCombine( Mobile from, object o )
		{
			if (o is Item && (((Item)o).IsChildOf(from.Backpack) || ((Item)o).IsChildOf(from.BankBox)))
			{
				if (!( o is BaseBoard || o is BaseTool || o is BaseRunicTool ))
				{
					from.SendMessage( "That is not an item you can put in here." );
				}
				if ( o is Board )
				{

					if ( Board >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Board += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is PineBoard )
				{

					if ( Pine >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Pine += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is CedarBoard )
				{

					if ( Cedar >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Cedar += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is CherryBoard )
				{

					if ( Cherry >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Cherry += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is MahoganyBoard )
				{

					if ( Mahogany >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Mahogany += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is OakBoard )
				{

					if ( Oak >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Oak += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is AshBoard )
				{

					if ( Ash >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Ash += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is YewBoard )
				{

					if ( Yew >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Yew += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is HeartwoodBoard )
				{

					if ( Heartwood >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Heartwood += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is BloodwoodBoard )
				{

					if ( Bloodwood >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Bloodwood += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is FrostwoodBoard )
				{

					if ( Frostwood >= 20000 )
					from.SendMessage( "That wood type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Frostwood += curItem.Amount;
						curItem.Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is Saw )
				{

					if ( Saw > (20000 - ((BaseTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						Saw = ( Saw + ((BaseTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is Hammer )
				{

					if ( Hammer > (20000 - ((BaseTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						Hammer = ( Hammer + ((BaseTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is FletcherTools )
				{
					if ( Fletcher > (20000 - ((BaseTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						Fletcher = ( Fletcher + ((BaseTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Pine )
				{
					if ( RunicPine > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicPine = ( RunicPine + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicPi )
				{
					if ( RunicPine > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicPine = ( RunicPine + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Cedar )
				{
					if ( RunicCedar > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicCedar = ( RunicCedar + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicCe )
				{
					if ( RunicCedar > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicCedar = ( RunicCedar + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Cherry )
				{
					if ( RunicCherry > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicCherry = ( RunicCherry + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicCh )
				{
					if ( RunicCherry > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicCherry = ( RunicCherry + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Mahogany )
				{
					if ( RunicMahogany > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicMahogany = ( RunicMahogany + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicMa )
				{
					if ( RunicMahogany > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicMahogany = ( RunicMahogany + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Oak )
				{
					if ( RunicOak > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicOak = ( RunicOak + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicOa )
				{
					if ( RunicOak > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicOak = ( RunicOak + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Ash )
				{
					if ( RunicAsh > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicAsh = ( RunicAsh + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicAs )
				{
					if ( RunicAsh > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicAsh = ( RunicAsh + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Yew )
				{
					if ( RunicYew > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicYew = ( RunicYew + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicYe )
				{
					if ( RunicYew > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicYew = ( RunicYew + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Heartwood )
				{
					if ( RunicHeartwood > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicHeartwood = ( RunicHeartwood + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicHw )
				{
					if ( RunicHeartwood > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicHeartwood = ( RunicHeartwood + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Bloodwood )
				{
					if ( RunicBloodwood > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBloodwood = ( RunicBloodwood + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicBw )
				{
					if ( RunicBloodwood > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBloodwood = ( RunicBloodwood + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicFletchersTools && ((RunicFletchersTools)o).Resource == CraftResource.Frostwood )
				{
					if ( RunicFrostwood > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicFrostwood = ( RunicFrostwood + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicFw )
				{
					if ( RunicFrostwood > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicFrostwood = ( RunicFrostwood + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new WoodBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}				
				
			}
			else
			{
				from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
			}
		}

		public WoodBox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) m_Board);
			writer.Write( (int) m_Pine);
			writer.Write( (int) m_Cedar);
			writer.Write( (int) m_Cherry);
			writer.Write( (int) m_Mahogany);			
			writer.Write( (int) m_Oak);
			writer.Write( (int) m_Ash);
			writer.Write( (int) m_Yew);
			writer.Write( (int) m_Heartwood);
			writer.Write( (int) m_Bloodwood);
			writer.Write( (int) m_Frostwood);
			writer.Write( (int) m_Saw);
			writer.Write( (int) m_Hammer);			
			writer.Write( (int) m_Fletcher);
			writer.Write( (int) m_RunicPine);		
			writer.Write( (int) m_RunicCedar);
			writer.Write( (int) m_RunicCherry);
			writer.Write( (int) m_RunicMahogany);			
			writer.Write( (int) m_RunicOak);
			writer.Write( (int) m_RunicAsh);
			writer.Write( (int) m_RunicYew);
			writer.Write( (int) m_RunicHeartwood);
			writer.Write( (int) m_RunicBloodwood);
			writer.Write( (int) m_RunicFrostwood);			
			writer.Write( (int) m_WithdrawIncrement);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			m_Board = reader.ReadInt();
			m_Pine = reader.ReadInt();
			m_Cedar = reader.ReadInt();
			m_Cherry = reader.ReadInt();
			m_Mahogany = reader.ReadInt();			
			m_Oak = reader.ReadInt();
			m_Ash = reader.ReadInt();
			m_Yew = reader.ReadInt();
			m_Heartwood = reader.ReadInt();
			m_Bloodwood = reader.ReadInt();
			m_Frostwood = reader.ReadInt();
			m_Saw = reader.ReadInt();
			m_Hammer = reader.ReadInt();			
			m_Fletcher = reader.ReadInt();		
			m_RunicPine = reader.ReadInt();
			m_RunicCedar = reader.ReadInt();
			m_RunicCherry = reader.ReadInt();
			m_RunicMahogany = reader.ReadInt();			
			m_RunicOak = reader.ReadInt();
			m_RunicAsh = reader.ReadInt();
			m_RunicYew = reader.ReadInt();
			m_RunicHeartwood = reader.ReadInt();
			m_RunicBloodwood = reader.ReadInt();
			m_RunicFrostwood = reader.ReadInt();			
			m_WithdrawIncrement = reader.ReadInt();
		}
	}
}


namespace Server.Items
{
	public class WoodBoxGump : Gump
	{
		private PlayerMobile m_From;
		private WoodBox m_Box;

		public WoodBoxGump( PlayerMobile from, WoodBox box ) : base( 25, 25 )
		{
			m_From = from;
			m_Box = box;

			m_From.CloseGump( typeof( WoodBoxGump ) );

			AddPage( 0 );

			AddBackground( 12, 19, 486, 350, 9250);
			AddLabel( 200, 30, 32, @"Wood Box");
			
			AddLabel( 60, 50, 32, @"Add Item");
			AddButton( 25, 50, 4005, 4007, 1, GumpButtonType.Reply, 0);

			AddLabel( 60, 75, 32, @"Close");
			AddButton( 25, 75, 4005, 4007, 0, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 115, 0, @"Board");
			AddLabel( 150, 115, 0x480, box.Board.ToString() );
			AddButton( 25, 115, 4005, 4007, 3, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 135, 1149, @"Pine");
			AddLabel( 150, 135, 0x480, box.Pine.ToString() );
			AddButton( 25, 135, 4005, 4007, 4, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 155, 861, @"Cedar");
			AddLabel( 150, 155, 0x480, box.Cedar.ToString() );
			AddButton( 25, 155, 4005, 4007, 5, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 175, 1148, @"Cherry");
			AddLabel( 150, 175, 0x480, box.Cherry.ToString() );
			AddButton( 25, 175, 4005, 4007, 6, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 195, 1608, @"Mahogany");
			AddLabel(  150, 195, 0x480, box.Mahogany.ToString() );
			AddButton(  25, 195, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 215, 1189, @"Oak");
			AddLabel(  150, 215, 0x480, box.Oak.ToString() );
			AddButton(  25, 215, 4005, 4007, 8, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 235, 1190, @"Ash");
			AddLabel(  150, 235, 0x480, box.Ash.ToString() );
			AddButton(  25, 235, 4005, 4007, 9, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 255, 1191, @"Yew");
			AddLabel(  150, 255, 0x480, box.Yew.ToString() );
			AddButton(  25, 255, 4005, 4007, 10, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 275, 1192, @"Heartwood");
			AddLabel(  150, 275, 0x480, box.Heartwood.ToString() );
			AddButton(  25, 275, 4005, 4007, 11, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 295, 1193, @"Bloodwood");
			AddLabel(  150, 295, 0x480, box.Bloodwood.ToString() );
			AddButton(  25, 295, 4005, 4007, 12, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 315, 1194, @"Frostwood");
			AddLabel(  150, 315, 0x480, box.Frostwood.ToString() );
			AddButton(  25, 315, 4005, 4007, 13, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 335, 990, @"Saw");
			AddLabel(  150, 335, 0x480, box.Saw.ToString() );
			AddButton(  25, 335, 4005, 4007, 14, GumpButtonType.Reply, 0 );
						
			AddLabel( 320, 115, 0, @"Fletcher Tools" );
			AddLabel( 410, 115, 0x480, box.Fletcher.ToString() );
			AddButton( 285, 115, 4005, 4007, 15, GumpButtonType.Reply, 0 );			
			
			AddLabel(320, 135, 1149, @"Pine");
			AddLabel( 410, 135, 0x480, box.RunicPine.ToString() );
			AddButton(285, 135, 4005, 4007, 16, GumpButtonType.Reply, 0);
			
			AddLabel(320, 155, 861, @"Cedar");
			AddLabel( 410, 155, 0x480, box.RunicCedar.ToString() );
			AddButton(285, 155, 4005, 4007, 17, GumpButtonType.Reply, 0);
			
			AddLabel(320, 175, 1148, @"Cherry");
			AddLabel( 410, 175, 0x480, box.RunicCherry.ToString() );
			AddButton(285, 175, 4005, 4007, 18, GumpButtonType.Reply, 0);
			
			AddLabel(320, 195, 1608, @"Mahogany");
			AddLabel( 410, 195, 0x480, box.RunicMahogany.ToString() );
			AddButton(285, 195, 4005, 4007, 19, GumpButtonType.Reply, 0);
			
			AddLabel(320, 215, 1189, @"Oak");
			AddLabel( 410, 215, 0x480, box.RunicOak.ToString() );
			AddButton(285, 215, 4005, 4007, 20, GumpButtonType.Reply, 0);
			
			AddLabel( 320, 235, 1190, @"Ash");
			AddLabel(  410, 235, 0x480, box.RunicAsh.ToString() );
			AddButton( 285, 235, 4005, 4007, 21, GumpButtonType.Reply, 0 );
			
			AddLabel( 320, 255, 1191, @"Yew");
			AddLabel(  410, 255, 0x480, box.RunicYew.ToString() );
			AddButton(  285, 255, 4005, 4007, 22, GumpButtonType.Reply, 0 );
			
			AddLabel( 320, 275, 1192, @"Heartwood");
			AddLabel(  410, 275, 0x480, box.RunicHeartwood.ToString() );
			AddButton(  285, 275, 4005, 4007, 23, GumpButtonType.Reply, 0 );
			
			AddLabel( 320, 295, 1193, @"Bloodwood");
			AddLabel(  410, 295, 0x480, box.RunicBloodwood.ToString() );
			AddButton(  285, 295, 4005, 4007, 24, GumpButtonType.Reply, 0 );
			
			AddLabel( 320, 315, 1194, @"Frostwood");
			AddLabel(  410, 315, 0x480, box.RunicFrostwood.ToString() );
			AddButton(  285, 315, 4005, 4007, 25, GumpButtonType.Reply, 0 );
			
			AddLabel(320, 335, 990, @"Hammer");
			AddLabel( 410, 335, 0x480, box.Hammer.ToString() );
			AddButton(285, 335, 4005, 4007, 26, GumpButtonType.Reply, 0);
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Box.Deleted )
			return;
			
			if ( info.ButtonID == 1)
			{
				m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				m_Box.BeginCombine( m_From );
			}
			
			if ( info.ButtonID == 3 )
			{
				if ( m_Box.Board > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new Board(m_Box.WithdrawIncrement) );
					m_Box.Board = m_Box.Board - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if (m_Box.Board > 0)
                		{
                    			m_From.AddToBackpack(new Board(m_Box.Board));  					//Sends all stored ingots of whichever type to players backpack
                    			m_Box.Board = 0;						     						//Sets the count in the key back to 0
                    			m_From.SendGump(new WoodBoxGump(m_From, m_Box));					//Resets the gump with the new info
                		}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			
			if ( info.ButtonID == 4 )
			{
				if ( m_Box.Pine > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new PineBoard(m_Box.WithdrawIncrement) );
					m_Box.Pine = m_Box.Pine - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Pine > 0 )
				{
					m_From.AddToBackpack( new PineBoard(m_Box.Pine) );
					m_Box.Pine = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 5 )
			{
				if ( m_Box.Cedar > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new CedarBoard(m_Box.WithdrawIncrement) );
					m_Box.Cedar = m_Box.Cedar - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Cedar > 0 )
				{
					m_From.AddToBackpack( new CedarBoard(m_Box.Cedar) );
					m_Box.Cedar = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 6 )
			{
				if ( m_Box.Cherry > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new CherryBoard(m_Box.WithdrawIncrement) );
					m_Box.Cherry = m_Box.Cherry - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Cherry > 0 )
				{
					m_From.AddToBackpack( new CherryBoard(m_Box.Cherry) );
					m_Box.Cherry = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 7 )
			{
				if ( m_Box.Mahogany > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new MahoganyBoard(m_Box.WithdrawIncrement) );
					m_Box.Mahogany = m_Box.Mahogany - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Mahogany > 0 )
				{
					m_From.AddToBackpack( new MahoganyBoard(m_Box.Mahogany) );
					m_Box.Mahogany = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 8 )
			{
				if ( m_Box.Oak > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new OakBoard(m_Box.WithdrawIncrement) );
					m_Box.Oak = m_Box.Oak - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Oak > 0 )
				{
					m_From.AddToBackpack( new OakBoard(m_Box.Oak) );
					m_Box.Oak = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 9 )
			{
				if ( m_Box.Ash > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new AshBoard(m_Box.WithdrawIncrement) );
					m_Box.Ash = m_Box.Ash - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Ash > 0 )
				{
					m_From.AddToBackpack( new AshBoard(m_Box.Ash) );
					m_Box.Ash = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 10 )
			{
				if ( m_Box.Yew > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new YewBoard(m_Box.WithdrawIncrement) );
					m_Box.Yew = m_Box.Yew - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Yew > 0 )
				{
					m_From.AddToBackpack( new YewBoard(m_Box.Yew) );
					m_Box.Yew = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 11 )
			{
				if ( m_Box.Heartwood > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new HeartwoodBoard(m_Box.WithdrawIncrement) );
					m_Box.Heartwood = m_Box.Heartwood - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Heartwood > 0 )
				{
					m_From.AddToBackpack( new HeartwoodBoard(m_Box.Heartwood) );
					m_Box.Heartwood = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 12 )
			{
				if ( m_Box.Bloodwood > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new BloodwoodBoard(m_Box.WithdrawIncrement) );
					m_Box.Bloodwood = m_Box.Bloodwood - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Bloodwood > 0 )
				{
					m_From.AddToBackpack( new BloodwoodBoard(m_Box.Bloodwood) );
					m_Box.Bloodwood = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 13 )
			{
				if ( m_Box.Frostwood > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new FrostwoodBoard(m_Box.WithdrawIncrement) );
					m_Box.Frostwood = m_Box.Frostwood - m_Box.WithdrawIncrement;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Frostwood > 0 )
				{
					m_From.AddToBackpack( new FrostwoodBoard(m_Box.Frostwood) );
					m_Box.Frostwood = 0;
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that wood!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 14 )
			{
				if ( m_Box.Saw > 0 )
				{
					m_From.AddToBackpack( new Saw(m_Box.Saw) );
					m_Box.Saw = ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 15 )
			{
				if ( m_Box.Fletcher > 0 )
				{
					m_From.AddToBackpack( new FletcherTools(m_Box.Fletcher) );
					m_Box.Fletcher = ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 16 )
			{
				if ( m_Box.RunicPine > 0 )
				{
					m_From.AddToBackpack( new RunicPi(m_Box.RunicPine) );
					m_Box.RunicPine = ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 17 )
			{
				if ( m_Box.RunicCedar > 0 )
				{
					m_From.AddToBackpack( new RunicCe(m_Box.RunicCedar) );
					m_Box.RunicCedar = ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 18 )
			{
				if ( m_Box.RunicCherry > 0 )
				{
					m_From.AddToBackpack( new RunicCh(m_Box.RunicCherry) );
					m_Box.RunicCherry = ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 19 )
			{
				if ( m_Box.RunicMahogany > 0 )
				{
					m_From.AddToBackpack( new RunicMa(m_Box.RunicMahogany) );
					m_Box.RunicMahogany = ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 20 )
			{
				if ( m_Box.RunicOak > 0 )
				{
					m_From.AddToBackpack( new RunicOa(m_Box.RunicOak) );
					m_Box.RunicOak= ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 21 )
			{
				if ( m_Box.RunicAsh> 0 )
				{
					m_From.AddToBackpack( new RunicAs(m_Box.RunicAsh) );
					m_Box.RunicAsh= ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 22 )
			{
				if ( m_Box.RunicYew > 0 )
				{
					m_From.AddToBackpack( new RunicYe(m_Box.RunicYew) );
					m_Box.RunicYew= ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 23 )
			{
				if ( m_Box.RunicHeartwood > 0 )
				{
					m_From.AddToBackpack( new RunicHw(m_Box.RunicHeartwood) );
					m_Box.RunicHeartwood= ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 24 )
			{
				if ( m_Box.RunicBloodwood > 0 )
				{
					m_From.AddToBackpack( new RunicBw(m_Box.RunicBloodwood) );
					m_Box.RunicBloodwood= ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 25 )
			{
				if ( m_Box.RunicFrostwood > 0 )
				{
					m_From.AddToBackpack( new RunicFw(m_Box.RunicFrostwood) );
					m_Box.RunicFrostwood= ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 26 )
			{
				if ( m_Box.Hammer > 0 )
				{
					m_From.AddToBackpack( new Hammer(m_Box.Hammer) );
					m_Box.Hammer= ( 0 );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new WoodBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}						
		}
	}

}

namespace Server.Items
{
	public class WoodBoxTarget : Target
	{
		private WoodBox m_Box;

		public WoodBoxTarget( WoodBox box ) : base( 18, false, TargetFlags.None )
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
