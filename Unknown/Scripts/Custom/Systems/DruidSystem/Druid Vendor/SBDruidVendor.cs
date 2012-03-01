using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBDruidVendor : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDruidVendor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{ 
				Add( new GenericBuyInfo( "Blend With Forest", typeof( BlendWithForestScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Enchanted Grove", typeof( EnchantedGroveScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Grasping Roots", typeof( GraspingRootsScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Hollow Reed", typeof( HollowReedScroll ), 1500, 999, 0xE39, 1419 ) );
				Add( new GenericBuyInfo( "Lure Stone", typeof( LureStoneScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Mushroom Circle", typeof( MushroomCircleScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Mushroom Gateway", typeof( MushroomGatewayScroll ), 1500, 999, 0xE39, 1419 ) );
				Add( new GenericBuyInfo( "Natures Passage", typeof( NaturesPassageScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Pack of Beasts", typeof( PackOfBeastScroll ), 1500, 999, 0xE39, 1419 ) );
				Add( new GenericBuyInfo( "Restorative Soil", typeof( RestorativeSoilScroll ), 1500, 999, 0xE39, 1419 ) );
				Add( new GenericBuyInfo( "Shield of Earth", typeof( ShieldOfEarthScroll ), 1500, 999, 0xE39, 1419 ) );
				Add( new GenericBuyInfo( "Spring of Life", typeof( SpringOfLifeScroll ), 1500, 999, 0xE39, 1419 ) );
				Add( new GenericBuyInfo( "Swarm of Insects", typeof( SwarmOfInsectsScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Treefellow", typeof( TreefellowScroll ), 1500, 999, 0xE39, 1419 ) );
				//Add( new GenericBuyInfo( "Volcanic Eruption", typeof( VolcanicEruptionScroll ), 1500, 999, 0xE39, 1419 ) );
				Add( new GenericBuyInfo( "Summon Firefly", typeof( FireflyScroll ), 1500, 999, 0xE39, 1419 ) );

				//Add( new GenericBuyInfo( "Mage Reagents", typeof( BagOfReagents ), 1150, 10, 0xE76, 40 ) );
				//Add( new GenericBuyInfo( "Necro Reagents", typeof( BagOfNecroReagents ), 1150, 10, 0xE76, 367 ) );
				Add( new GenericBuyInfo( "Druid Reagents", typeof( BagOfDruidReagents ), 5000, 999, 0xE76, 1453 ) );
				
				Add( new GenericBuyInfo( "PetrafiedWood", typeof( PetrafiedWood ), 10, 999, 0x97A, 0x46C ) );
				Add( new GenericBuyInfo( "SpringWater", typeof( SpringWater ), 10, 999, 0xE24, 0x47F ) );
				Add( new GenericBuyInfo( "DestroyingAngel", typeof( DestroyingAngel ), 10, 999, 0xE1F, 0x290 ) );
				
				Add( new GenericBuyInfo( "Tome of Nature", typeof( DruidicSpellbook ), 60000, 999, 0xEFA, 1164 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{ 
				Add( typeof( PetrafiedWood ), 3 ); 
				Add( typeof( SpringWater ), 3 ); 
				Add( typeof( DestroyingAngel ), 3 ); 
				
				//Add( typeof( BagOfReagents ), 1150 );
				//Add( typeof( BagOfNecroReagents ), 1150 );
				//Add( typeof( BagOfDruidReagents ), 1150 );

			}
		}
	}
}
