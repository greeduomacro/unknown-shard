using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBMage : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Spellbook ), 18, 10, 0xEFA, 0 ) );

				Add( new GenericBuyInfo( typeof( FullMagerySpellbook ), 10000, 100, 0xEFA, 0 ) );
				Add( new GenericBuyInfo( typeof( FullNecroSpellbook ), 11000, 100, 0xFFFF, 0 ) );
				Add( new GenericBuyInfo( typeof( FullChivalrySpellbook ), 11000, 100, 0x3FF, 0 ) );
				Add( new GenericBuyInfo( typeof( FullBushidoSpellbook ), 11000, 100, 0x3F, 0 ) );
				Add( new GenericBuyInfo( typeof( FullNinjitsuSpellbook ), 11000, 100, 0xFF, 0 ) );
				Add( new GenericBuyInfo( typeof( FullSpellweavingSpellbook ), 11000, 100, 0xFFFF, 0 ) );
				Add( new GenericBuyInfo( typeof( TreasureShovel ), 1990, 100, 	0xF39, 0 ) );			
				Add( new GenericBuyInfo( typeof( Runebook ), 1000, 100, 0x22c5, 0 ) );
				Add( new GenericBuyInfo( typeof( BagOfAllReagents ), 3500, 100, 0xE76, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 100, 0x2253, 0 ) );
				
				Add( new GenericBuyInfo( typeof( ScribesPen ), 8, 99, 0xFBF, 0 ) );

				Add( new GenericBuyInfo( typeof( BlankScroll ), 5, 99, 0x0E34, 0 ) );

				Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, 99, 0x1718, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( RecallRune ), 15, 99, 0x1F14, 0 ) );
				Add( new GenericBuyInfo( typeof( RecallScroll ), 50, 99, 0x1F4C, 0 ) );
				Add( new GenericBuyInfo( typeof( MarkScroll ), 50, 99, 0x1F4C, 0 ) );

				Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, 99, 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( AgilityPotion ), 15, 99, 0xF08, 0 ) );
				Add( new GenericBuyInfo( typeof( NightSightPotion ), 15, 99, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, 99, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 15, 99, 0xF09, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 15, 99, 0xF0A, 0 ) );
 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 15, 99, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 21, 99, 0xF0D, 0 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 99, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 99, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, 99, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, 99, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 99, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, 99, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 99, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 99, 0xF8C, 0 ) );

                		Add(new GenericBuyInfo(typeof(BlightedCotton), 2, 99, 0x2DB, 0));
                		Add(new GenericBuyInfo(typeof(BacterialMud), 2, 99, 0x913, 0));
                		Add(new GenericBuyInfo(typeof(SerpentEggs), 2, 99, 0x9B5, 0));
                		Add(new GenericBuyInfo(typeof(HerbalWater), 2, 99, 0x9B5, 0));
                		Add(new GenericBuyInfo(typeof(DragonFlesh), 2, 99, 0x9F1, 0));
                		Add(new GenericBuyInfo(typeof(DriedFlower), 2, 99, 0xC3B, 0));
                		Add(new GenericBuyInfo(typeof(RareHerb), 2, 99, 0xC63, 0));

				Add( new GenericBuyInfo( typeof( BatWing ), 3, 99, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, 99, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 5, 99, 0xF8A, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, 99, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 3, 99, 0xF8F, 0 ) );

				Type[] types = Loot.RegularScrollTypes;

				int circles = 5;

				for ( int i = 0; i < circles*8 && i < types.Length; ++i )
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					Add( new GenericBuyInfo( types[i], 12 + ((i / 8) * 10), 20, itemID, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( WizardsHat ), 15 );
				Add( typeof( BlackPearl ), 3 ); 
				Add( typeof( Bloodmoss ),4 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 
				Add( typeof( RecallRune ), 13 );
				Add( typeof( Spellbook ), 25 );

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add( types[i], ((i / 8) + 2) * 5 );
			}
		}
	}
}