using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBAlchemist : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{  
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, 99, 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( AgilityPotion ), 15, 99, 0xF08, 0 ) );
				Add( new GenericBuyInfo( typeof( NightSightPotion ), 15, 99, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, 99, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 15, 99, 0xF09, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 15, 99, 0xF0A, 0 ) );
 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 15, 99, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 21, 99, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( typeof( MortarPestle ), 8, 99, 0xE9B, 0 ) );
                		Add(new GenericBuyInfo(typeof(PetShrinkPotion), 160, 99, 0xF0B, 0));

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

				Add( new GenericBuyInfo( typeof( Bottle ), 5, 99, 0xF0E, 0 ) ); 
				Add( new GenericBuyInfo( typeof( HeatingStand ), 2, 99, 0x1849, 0 ) ); 

				Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 37, 99, 0xEFF, 0 ) );

				Add( new GenericBuyInfo( typeof( HeatingStand ), 2, 99, 0x1849, 0 ) ); // This is on OSI :-P


			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BlackPearl ), 3 ); 
				Add( typeof( Bloodmoss ), 3 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 
				Add( typeof( Bottle ), 3 );
				Add( typeof( MortarPestle ), 4 );
				Add( typeof( HairDye ), 19 );

				Add( typeof( NightSightPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( LesserExplosionPotion ), 10 );
                Add(typeof(PetShrinkPotion), 10);
			}
		}
	}
}
