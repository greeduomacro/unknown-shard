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
	[FlipableAttribute( 0xE41, 0xE40 )]
	public class BlackSmithBox : Item 
	{
		private int m_Iron;
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
		private int m_BlackSmith;
		private int m_RunicDullCopper;
		private int m_RunicShadowIron;
		private int m_RunicCopper;
		private int m_RunicBronze;
		private int m_RunicSilver;
		private int m_RunicGold;
		private int m_RunicAgapite;
		private int m_RunicPlatinum;
		private int m_RunicMythril;
		private int m_RunicVerite;
		private int m_RunicValorite;
		private int m_RunicObsidian;
		private int m_RunicJade;
		private int m_RunicMoonstone;
		private int m_RunicSunstone;
		private int m_RunicBloodstone;
		private int m_WithdrawIncrement;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int WithdrawIncrement { get { return m_WithdrawIncrement; } set { m_WithdrawIncrement = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Iron{ get{ return m_Iron; } set{ m_Iron = value; InvalidateProperties(); } }

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
		public int BlackSmith{ get{ return m_BlackSmith; } set{ m_BlackSmith = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicDullCopper{ get{ return m_RunicDullCopper; } set{ m_RunicDullCopper = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicShadowIron{ get{ return m_RunicShadowIron; } set{ m_RunicShadowIron = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicCopper{ get{ return m_RunicCopper; } set{ m_RunicCopper = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicBronze{ get{ return m_RunicBronze; } set{ m_RunicBronze = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicSilver{ get{ return m_RunicSilver; } set{ m_RunicSilver = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicGold{ get{ return m_RunicGold; } set{ m_RunicGold = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicAgapite{ get{ return m_RunicAgapite; } set{ m_RunicAgapite = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicPlatinum{ get{ return m_RunicPlatinum; } set{ m_RunicPlatinum = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicMythril{ get{ return m_RunicMythril; } set{ m_RunicMythril = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicVerite{ get{ return m_RunicVerite; } set{ m_RunicVerite = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicValorite{ get{ return m_RunicValorite; } set{ m_RunicValorite = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicObsidian{ get{ return m_RunicObsidian; } set{ m_RunicObsidian = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicJade{ get{ return m_RunicJade; } set{ m_RunicJade = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicMoonstone{ get{ return m_RunicMoonstone; } set{ m_RunicMoonstone = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicSunstone{ get{ return m_RunicSunstone; } set{ m_RunicSunstone = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RunicBloodstone{ get{ return m_RunicBloodstone; } set{ m_RunicBloodstone = value; InvalidateProperties(); } }

		[Constructable]
		public BlackSmithBox() : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 0x488;
			Name = "BlackSmith Box";
			WithdrawIncrement = 100;
		}
		
		[Constructable]
		public BlackSmithBox( int withdrawincrement ) : base( 0xE80 )
		{
			Movable = true;
			Weight = 10.0;
			Hue = 0x488;
			Name = "BlackSmith Box";
			WithdrawIncrement = withdrawincrement;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( from is PlayerMobile )
			from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
		}

		public void BeginCombine( Mobile from )
		{
			from.Target = new BlackSmithBoxTarget( this );
		}

		public void EndCombine( Mobile from, object o )
		{
			if ( o is Item && ((Item)o).IsChildOf( from.Backpack ) )
			{
				if (!( o is BaseIngot || o is BaseTool || o is BaseRunicTool ))
				{
					from.SendMessage( "That is not an item you can put in here." );
				}
				if ( o is IronIngot )
				{

					if ( Iron >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Iron += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is DullCopperIngot )
				{

					if ( DullCopper >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						DullCopper += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is ShadowIronIngot )
				{

					if ( ShadowIron >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						ShadowIron += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is CopperIngot )
				{

					if ( Copper >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Copper += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is BronzeIngot )
				{

					if ( Bronze >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Bronze += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is SilverIngot )
				{

					if ( Silver >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Silver += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is GoldIngot )
				{

					if ( Gold >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Gold += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is AgapiteIngot )
				{

					if ( Agapite >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Agapite += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is PlatinumIngot )
				{

					if ( Platinum >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Platinum += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is MythrilIngot )
				{

					if ( Mythril >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Mythril += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is VeriteIngot )
				{

					if ( Verite >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Verite += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is ValoriteIngot )
				{

					if ( Valorite >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Valorite += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is ObsidianIngot )
				{

					if ( Obsidian >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Obsidian += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is JadeIngot )
				{

					if ( Jade >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Jade += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is MoonstoneIngot )
				{

					if ( Moonstone >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Moonstone += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is SunstoneIngot )
				{

					if ( Sunstone >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Sunstone += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if (o is BloodstoneIngot )
				{

					if ( Bloodstone >= 20000 )
					from.SendMessage( "That Ingot type is too full to add more." );
					else
					{
						Item curItem = o as Item;
						Bloodstone += curItem.Amount;
						curItem.Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is SmithHammer )
				{
					if ( BlackSmith > (20000 - ((BaseTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						BlackSmith = ( BlackSmith + ((BaseTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.DullCopper )
				{
					if ( RunicDullCopper > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicDullCopper = ( RunicDullCopper + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicDC )
				{
					if ( RunicDullCopper > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicDullCopper = ( RunicDullCopper + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.ShadowIron )
				{
					if ( RunicShadowIron > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicShadowIron = ( RunicShadowIron + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicS )
				{
					if ( RunicShadowIron > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicShadowIron = ( RunicShadowIron + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Copper )
				{
					if ( RunicCopper > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicCopper = ( RunicCopper + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicC )
				{
					if ( RunicCopper > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicCopper = ( RunicCopper + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Bronze )
				{
					if ( RunicBronze > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBronze = ( RunicBronze + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicB )
				{
					if ( RunicBronze > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBronze = ( RunicBronze + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Gold )
				{
					if ( RunicGold > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicGold = ( RunicGold + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicG )
				{
					if ( RunicGold > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicGold = ( RunicGold + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Agapite )
				{
					if ( RunicAgapite > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicAgapite = ( RunicAgapite + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicA )
				{
					if ( RunicAgapite > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicAgapite = ( RunicAgapite + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Verite )
				{
					if ( RunicVerite > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicVerite = ( RunicVerite + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicVer )
				{
					if ( RunicVerite > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicVerite = ( RunicVerite + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Valorite )
				{
					if ( RunicValorite > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicValorite = ( RunicValorite + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicVal )
				{
					if ( RunicValorite > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicValorite = ( RunicValorite + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Silver )
				{
					if ( RunicSilver > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicSilver = ( RunicSilver + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicSil )
				{
					if ( RunicSilver > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicSilver = ( RunicSilver + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Platinum )
				{
					if ( RunicPlatinum > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicPlatinum = ( RunicPlatinum + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicP )
				{
					if ( RunicPlatinum > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicPlatinum = ( RunicPlatinum + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Mythril )
				{
					if ( RunicMythril > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicMythril = ( RunicMythril + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicM )
				{
					if ( RunicMythril > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicMythril = ( RunicMythril + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Obsidian )
				{
					if ( RunicObsidian > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicObsidian = ( RunicObsidian + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicO )
				{
					if ( RunicObsidian > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicObsidian = ( RunicObsidian + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Jade )
				{
					if ( RunicJade > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicJade = ( RunicJade + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicJ )
				{
					if ( RunicJade > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicJade = ( RunicJade + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Moonstone )
				{
					if ( RunicMoonstone > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicMoonstone = ( RunicMoonstone + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicMo )
				{
					if ( RunicMoonstone > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicMoonstone = ( RunicMoonstone + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Sunstone )
				{
					if ( RunicSunstone > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicSunstone = ( RunicSunstone + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicSu )
				{
					if ( RunicSunstone > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicSunstone = ( RunicSunstone + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				if ( o is RunicHammer && ((RunicHammer)o).Resource == CraftResource.Bloodstone )
				{
					if ( RunicBloodstone > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBloodstone = ( RunicBloodstone + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				else if ( o is RunicBl )
				{
					if ( RunicBloodstone > (20000 - ((BaseRunicTool)o).UsesRemaining) )
					from.SendMessage( "That tool type is too full to add more." );
					else
					{
						RunicBloodstone = ( RunicBloodstone + ((BaseRunicTool)o).UsesRemaining );
						((Item)o).Delete();
						from.SendGump( new BlackSmithBoxGump( (PlayerMobile)from, this ) );
						BeginCombine( from );
					}
				}
				
			}
			else
			{
				from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
			}
		}

		public BlackSmithBox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) m_Iron);
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
			writer.Write( (int) m_BlackSmith);
			writer.Write( (int) m_RunicDullCopper);		
			writer.Write( (int) m_RunicShadowIron);
			writer.Write( (int) m_RunicCopper);
			writer.Write( (int) m_RunicBronze);			
			writer.Write( (int) m_RunicGold);
			writer.Write( (int) m_RunicAgapite);			
			writer.Write( (int) m_RunicVerite);
			writer.Write( (int) m_RunicValorite);
			writer.Write( (int) m_RunicSilver);
			writer.Write( (int) m_RunicPlatinum);
			writer.Write( (int) m_RunicMythril);
			writer.Write( (int) m_RunicObsidian);
			writer.Write( (int) m_RunicJade);
			writer.Write( (int) m_RunicMoonstone);
			writer.Write( (int) m_RunicSunstone);
			writer.Write( (int) m_RunicBloodstone);
			writer.Write( (int) m_WithdrawIncrement);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			m_Iron = reader.ReadInt();
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
			m_BlackSmith = reader.ReadInt();		
			m_RunicDullCopper = reader.ReadInt();
			m_RunicShadowIron = reader.ReadInt();
			m_RunicCopper = reader.ReadInt();
			m_RunicBronze = reader.ReadInt();			
			m_RunicGold = reader.ReadInt();
			m_RunicAgapite = reader.ReadInt();			
			m_RunicVerite = reader.ReadInt();
			m_RunicValorite = reader.ReadInt();
			m_RunicSilver = reader.ReadInt();
			m_RunicPlatinum = reader.ReadInt();
			m_RunicMythril = reader.ReadInt();
			m_RunicObsidian = reader.ReadInt();
			m_RunicJade = reader.ReadInt();
			m_RunicMoonstone = reader.ReadInt();
			m_RunicSunstone = reader.ReadInt();
			m_RunicBloodstone = reader.ReadInt();
			m_WithdrawIncrement = reader.ReadInt();
		}
	}
}


namespace Server.Items
{
	public class BlackSmithBoxGump : Gump
	{
		private PlayerMobile m_From;
		private BlackSmithBox m_Box;

		public BlackSmithBoxGump( PlayerMobile from, BlackSmithBox box ) : base( 25, 25 )
		{
			m_From = from;
			m_Box = box;

			m_From.CloseGump( typeof( BlackSmithBoxGump ) );

			AddPage( 0 );

			AddBackground( 12, 19, 486, 457, 9250);
			AddLabel( 150, 30, 32, @"Blacksmith Box");
			
			AddLabel( 60, 50, 32, @"Add Item");
			AddButton( 25, 50, 4005, 4007, 1, GumpButtonType.Reply, 0);

			AddLabel( 60, 75, 32, @"Close");
			AddButton( 25, 75, 4005, 4007, 0, GumpButtonType.Reply, 0);
			
			AddLabel( 60, 115, 0, @"Iron Ingots");
			AddLabel( 150, 115, 0x480, box.Iron.ToString() );
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
			AddLabel(  150, 235, 0x480, box.Agapite.ToString() );
			AddButton(  25, 235, 4005, 4007, 9, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 255, 2206, @"Verite");
			AddLabel(  150, 255, 0x480, box.Verite.ToString() );
			AddButton( 25, 255, 4005, 4007, 10, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 275, 2218, @"Valorite");
			AddLabel(  150, 275, 0x480, box.Valorite.ToString() );
			AddButton( 25, 275, 4005, 4007, 11, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 295, 1149, @"Silver");
			AddLabel(  150, 295, 0x480, box.Silver.ToString() );
			AddButton( 25, 295, 4005, 4007, 12, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 315, 1171, @"Platinum");
			AddLabel(  150, 315, 0x480, box.Platinum.ToString() );
			AddButton( 25, 315, 4005, 4007, 13, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 336, 1157, @"Mythril");
			AddLabel(  150, 335, 0x480, box.Mythril.ToString() );
			AddButton( 25, 335, 4005, 4007, 14, GumpButtonType.Reply, 0 );
			
			AddLabel( 60, 355, 1108, @"Obsidian");
			AddLabel(  150, 355, 0x480, box.Obsidian.ToString() );
			AddButton( 25, 355, 4005, 4007, 15, GumpButtonType.Reply, 0 );
			
			AddLabel(  60, 375, 1163, @"Jade" );
			AddLabel(  150, 375, 0x480, box.Jade.ToString() );
			AddButton( 25, 375, 4005, 4007, 16, GumpButtonType.Reply, 0 );
			
			AddLabel(  60, 395, 1155, @"Moonstone" );
			AddLabel(  150, 395, 0x480, box.Moonstone.ToString() );
			AddButton( 25, 395, 4005, 4007, 17, GumpButtonType.Reply, 0 );
			
			AddLabel(  60, 415, 1359, @"Sunstone" );
			AddLabel(  150, 415, 0x480, box.Sunstone.ToString() );
			AddButton( 25, 415, 4005, 4007, 18, GumpButtonType.Reply, 0 );
			
			AddLabel(  60, 435, 1156, @"Bloodstone" );
			AddLabel(  150, 435, 0x480, box.Bloodstone.ToString() );
			AddButton( 25, 435, 4005, 4007, 19, GumpButtonType.Reply, 0 );
			
			AddLabel( 320, 115, 0, @"Smith Hammer" );
			AddLabel( 410, 115, 0x480, box.BlackSmith.ToString() );
			AddButton( 285, 115, 4005, 4007, 20, GumpButtonType.Reply, 0 );			
			
			AddLabel(320, 135, 2418, @"Dull Copper");
			AddLabel( 410, 135, 0x480, box.RunicDullCopper.ToString() );
			AddButton(285, 135, 4005, 4007, 21, GumpButtonType.Reply, 0);
			
			AddLabel(320, 155, 2405, @"Shadow Iron");
			AddLabel( 410, 155, 0x480, box.RunicShadowIron.ToString() );
			AddButton(285, 155, 4005, 4007, 22, GumpButtonType.Reply, 0);
			
			AddLabel(320, 175, 2412, @"Copper");
			AddLabel( 410, 175, 0x480, box.RunicCopper.ToString() );
			AddButton(285, 175, 4005, 4007, 23, GumpButtonType.Reply, 0);
			
			AddLabel(320, 195, 2417, @"Bronze");
			AddLabel( 410, 195, 0x480, box.RunicBronze.ToString() );
			AddButton(285, 195, 4005, 4007, 24, GumpButtonType.Reply, 0);
			
			AddLabel(320, 215, 2212, @"Golden");
			AddLabel( 410, 215, 0x480, box.RunicGold.ToString() );
			AddButton(285, 215, 4005, 4007, 25, GumpButtonType.Reply, 0);
			
			AddLabel(320, 235, 2424, @"Agapite");
			AddLabel( 410, 235, 0x480, box.RunicAgapite.ToString() );
			AddButton(285, 235, 4005, 4007, 26, GumpButtonType.Reply, 0);
			
			AddLabel(320, 255, 2206, @"Verite");
			AddLabel( 410, 255, 0x480, box.RunicVerite.ToString() );
			AddButton(285, 255, 4005, 4007, 27, GumpButtonType.Reply, 0);
			
			AddLabel(320, 275, 2218, @"Valorite");
			AddLabel( 410, 275, 0x480, box.RunicValorite.ToString() );
			AddButton(285, 275, 4005, 4007, 28, GumpButtonType.Reply, 0);
			
			AddLabel(320, 295, 1149, @"Silver");
			AddLabel( 410, 295, 0x480, box.RunicSilver.ToString() );
			AddButton(285, 295, 4005, 4007, 29, GumpButtonType.Reply, 0);
			
			AddLabel(320, 315, 1171, @"Platinum");
			AddLabel( 410, 315, 0x480, box.RunicPlatinum.ToString() );
			AddButton(285, 315, 4005, 4007, 30, GumpButtonType.Reply, 0);
			
			AddLabel(320, 335, 1157, @"Mythril");
			AddLabel( 410, 335, 0x480, box.RunicMythril.ToString() );
			AddButton(285, 335, 4005, 4007, 31, GumpButtonType.Reply, 0);
			
			AddLabel(320, 355, 1108, @"Obsidian");
			AddLabel( 410, 355, 0x480, box.RunicObsidian.ToString() );
			AddButton(285, 355, 4005, 4007, 32, GumpButtonType.Reply, 0);
			
			AddLabel(320, 375, 1163, @"Jade");
			AddLabel( 410, 375, 0x480, box.RunicJade.ToString() );
			AddButton(285, 375, 4005, 4007, 33, GumpButtonType.Reply, 0);
			
			AddLabel(320, 395, 1155, @"Moonstone");
			AddLabel( 410, 395, 0x480, box.RunicMoonstone.ToString() );
			AddButton(285, 395, 4005, 4007, 34, GumpButtonType.Reply, 0);
			
			AddLabel(320, 415, 1359, @"Sunstone");
			AddLabel( 410, 415, 0x480, box.RunicSunstone.ToString() );
			AddButton(285, 415, 4005, 4007, 35, GumpButtonType.Reply, 0);
			
			AddLabel(320, 435, 1156, @"Bloodstone");
			AddLabel( 410, 435, 0x480, box.RunicBloodstone.ToString() );
			AddButton(285, 435, 4005, 4007, 36, GumpButtonType.Reply, 0);

		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Box.Deleted )
			return;
			
			if ( info.ButtonID == 1)
			{
				m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				m_Box.BeginCombine( m_From );
			}
			
			if ( info.ButtonID == 3 )
			{
				if ( m_Box.Iron > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new IronIngot(m_Box.WithdrawIncrement) );
					m_Box.Iron = m_Box.Iron - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if (m_Box.Iron > 0)
                		{
                    			m_From.AddToBackpack(new IronIngot(m_Box.Iron));  					//Sends all stored ingots of whichever type to players backpack
                    			m_Box.Iron = 0;						     						//Sets the count in the key back to 0
                    			m_From.SendGump(new BlackSmithBoxGump(m_From, m_Box));					//Resets the gump with the new info
                		}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			
			if ( info.ButtonID == 4 )
			{
				if ( m_Box.DullCopper > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new DullCopperIngot(m_Box.WithdrawIncrement) );
					m_Box.DullCopper = m_Box.DullCopper - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.DullCopper > 0 )
				{
					m_From.AddToBackpack( new DullCopperIngot(m_Box.DullCopper) );
					m_Box.DullCopper = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 5 )
			{
				if ( m_Box.ShadowIron > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new ShadowIronIngot(m_Box.WithdrawIncrement) );
					m_Box.ShadowIron  = m_Box.ShadowIron - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.ShadowIron > 0 )
				{
					m_From.AddToBackpack( new ShadowIronIngot(m_Box.ShadowIron) );
					m_Box.ShadowIron = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 6 )
			{
				if ( m_Box.Copper > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new CopperIngot(m_Box.WithdrawIncrement) );
					m_Box.Copper = m_Box.Copper - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Copper > 0 )
				{
					m_From.AddToBackpack( new CopperIngot(m_Box.Copper) );
					m_Box.Copper = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 7 )
			{
				if ( m_Box.Bronze > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new BronzeIngot(m_Box.WithdrawIncrement) );
					m_Box.Bronze = m_Box.Bronze - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Bronze > 0 )
				{
					m_From.AddToBackpack( new BronzeIngot(m_Box.Bronze) );
					m_Box.Bronze = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 8 )
			{
				if ( m_Box.Gold > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new GoldIngot(m_Box.WithdrawIncrement) );
					m_Box.Gold = m_Box.Gold - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Gold > 0 )
				{
					m_From.AddToBackpack( new GoldIngot(m_Box.Gold) );
					m_Box.Gold = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 9 )
			{
				if ( m_Box.Agapite > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new AgapiteIngot(m_Box.WithdrawIncrement) );
					m_Box.Agapite = m_Box.Agapite - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Agapite > 0 )
				{
					m_From.AddToBackpack( new AgapiteIngot(m_Box.Agapite) );
					m_Box.Agapite = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
			if ( info.ButtonID == 10 )
			{
				if ( m_Box.Verite > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new VeriteIngot(m_Box.WithdrawIncrement) );
					m_Box.Verite = m_Box.Verite - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Verite > 0 )
				{
					m_From.AddToBackpack( new VeriteIngot(m_Box.Verite) );
					m_Box.Verite = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 11 )
			{
				if ( m_Box.Valorite > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new ValoriteIngot(m_Box.WithdrawIncrement) );
					m_Box.Valorite = m_Box.Valorite - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Valorite > 0 )
				{
					m_From.AddToBackpack( new ValoriteIngot(m_Box.Valorite) );
					m_Box.Valorite = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 12 )
			{
				if ( m_Box.Silver > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new SilverIngot(m_Box.WithdrawIncrement) );
					m_Box.Silver = m_Box.Silver - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Silver > 0 )
				{
					m_From.AddToBackpack( new SilverIngot(m_Box.Silver) );
					m_Box.Silver = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 13 )
			{
				if ( m_Box.Platinum > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new PlatinumIngot(m_Box.WithdrawIncrement) );
					m_Box.Platinum = m_Box.Platinum - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Platinum > 0 )
				{
					m_From.AddToBackpack( new PlatinumIngot(m_Box.Platinum) );
					m_Box.Platinum = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 14 )
			{
				if ( m_Box.Mythril > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new MythrilIngot(m_Box.WithdrawIncrement) );
					m_Box.Mythril = m_Box.Mythril - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Mythril > 0 )
				{
					m_From.AddToBackpack( new MythrilIngot(m_Box.Mythril) );
					m_Box.Mythril = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 15 )
			{
				if ( m_Box.Obsidian > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new ObsidianIngot(m_Box.WithdrawIncrement) );
					m_Box.Obsidian = m_Box.Obsidian - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Obsidian > 0 )
				{
					m_From.AddToBackpack( new ObsidianIngot(m_Box.Obsidian) );
					m_Box.Obsidian = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 16 )
			{
				if ( m_Box.Jade > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new JadeIngot(m_Box.WithdrawIncrement) );
					m_Box.Jade = m_Box.Jade - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Jade > 0 )
				{
					m_From.AddToBackpack( new JadeIngot(m_Box.Jade) );
					m_Box.Jade = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 17 )
			{
				if ( m_Box.Moonstone > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new MoonstoneIngot(m_Box.WithdrawIncrement) );
					m_Box.Moonstone = m_Box.Moonstone - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Moonstone > 0 )
				{
					m_From.AddToBackpack( new MoonstoneIngot(m_Box.Moonstone) );
					m_Box.Moonstone = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}

			if ( info.ButtonID == 18 )
			{
				if ( m_Box.Sunstone > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new SunstoneIngot(m_Box.WithdrawIncrement) );
					m_Box.Sunstone = m_Box.Sunstone - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Sunstone > 0 )
				{
					m_From.AddToBackpack( new SunstoneIngot(m_Box.Sunstone) );
					m_Box.Sunstone = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 19 )
			{
				if ( m_Box.Bloodstone > m_Box.WithdrawIncrement )
				{
					m_From.AddToBackpack( new BloodstoneIngot(m_Box.WithdrawIncrement) );
					m_Box.Bloodstone = m_Box.Bloodstone - m_Box.WithdrawIncrement;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else if ( m_Box.Bloodstone > 0 )
				{
					m_From.AddToBackpack( new BloodstoneIngot(m_Box.Bloodstone) );
					m_Box.Bloodstone = 0;
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that Ingot!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 20 )
			{
				if ( m_Box.BlackSmith > 0 )
				{
					m_From.AddToBackpack( new SmithHammer(m_Box.BlackSmith) );
					m_Box.BlackSmith = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 21 )
			{
				if ( m_Box.RunicDullCopper > 0 )
				{
					m_From.AddToBackpack( new RunicDC(m_Box.RunicDullCopper) );
					m_Box.RunicDullCopper = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 22 )
			{
				if ( m_Box.RunicShadowIron > 0 )
				{
					m_From.AddToBackpack( new RunicS(m_Box.RunicShadowIron) );
					m_Box.RunicShadowIron = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 23 )
			{
				if ( m_Box.RunicCopper > 0 )
				{
					m_From.AddToBackpack( new RunicC(m_Box.RunicCopper) );
					m_Box.RunicCopper = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 24 )
			{
				if ( m_Box.RunicBronze > 0 )
				{
					m_From.AddToBackpack( new RunicB(m_Box.RunicBronze) );
					m_Box.RunicBronze = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 25 )
			{
				if ( m_Box.RunicGold > 0 )
				{
					m_From.AddToBackpack( new RunicG(m_Box.RunicGold) );
					m_Box.RunicGold = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 26 )
			{
				if ( m_Box.RunicAgapite > 0 )
				{
					m_From.AddToBackpack( new RunicA(m_Box.RunicAgapite) );
					m_Box.RunicAgapite = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 27 )
			{
				if ( m_Box.RunicVerite > 0 )
				{
					m_From.AddToBackpack( new RunicVer(m_Box.RunicVerite) );
					m_Box.RunicVerite = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 28 )
			{
				if ( m_Box.RunicValorite > 0 )
				{
					m_From.AddToBackpack( new RunicVal(m_Box.RunicValorite) );
					m_Box.RunicValorite = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 29 )
			{
				if ( m_Box.RunicSilver > 0 )
				{
					m_From.AddToBackpack( new RunicSil(m_Box.RunicSilver) );
					m_Box.RunicSilver = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 30 )
			{
				if ( m_Box.RunicPlatinum > 0 )
				{
					m_From.AddToBackpack( new RunicP(m_Box.RunicPlatinum) );
					m_Box.RunicPlatinum = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 31 )
			{
				if ( m_Box.RunicMythril > 0 )
				{
					m_From.AddToBackpack( new RunicM(m_Box.RunicMythril) );
					m_Box.RunicMythril = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 32 )
			{
				if ( m_Box.RunicObsidian > 0 )
				{
					m_From.AddToBackpack( new RunicO(m_Box.RunicObsidian) );
					m_Box.RunicObsidian = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 33 )
			{
				if ( m_Box.RunicJade > 0 )
				{
					m_From.AddToBackpack( new RunicJ(m_Box.RunicJade) );
					m_Box.RunicJade = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 34 )
			{
				if ( m_Box.RunicMoonstone > 0 )
				{
					m_From.AddToBackpack( new RunicMo(m_Box.RunicMoonstone) );
					m_Box.RunicMoonstone = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 35 )
			{
				if ( m_Box.RunicSunstone > 0 )
				{
					m_From.AddToBackpack( new RunicSu(m_Box.RunicSunstone) );
					m_Box.RunicSunstone = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}
			if ( info.ButtonID == 36 )
			{
				if ( m_Box.RunicBloodstone > 0 )
				{
					m_From.AddToBackpack( new RunicBl(m_Box.RunicBloodstone) );
					m_Box.RunicBloodstone = ( 0 );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
				}
				else
				{
					m_From.SendMessage( "You do not have any of that item!" );
					m_From.SendGump( new BlackSmithBoxGump( m_From, m_Box ) );
					m_Box.BeginCombine( m_From );
				}
			}			
		}
	}

}

namespace Server.Items
{
	public class BlackSmithBoxTarget : Target
	{
		private BlackSmithBox m_Box;

		public BlackSmithBoxTarget( BlackSmithBox box ) : base( 18, false, TargetFlags.None )
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
