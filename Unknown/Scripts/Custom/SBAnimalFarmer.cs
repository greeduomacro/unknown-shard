using System; 
using System.Collections; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBAnimalFarmer : SBInfo 
	{ 
		private ArrayList m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBAnimalFarmer() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override ArrayList BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : ArrayList 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( Eggs ), 3, 40, 0x9B5, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, 20, 0x9AD, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 40, 20, 0x97E, 0 ) ); // comment out if you don't want the milk and cheese system
                Add(new GenericBuyInfo(typeof(CheeseForm), 150, 1, 0x0E78, 0x481));
                Add(new GenericBuyInfo(typeof(MilkBucket), 150, 5, 0x0FFA, 1001));
                Add(new GenericBuyInfo(typeof(Wool), 3, 20, 0xDF8, 0));

                Add(new AnimalBuyInfo(1, "a chicken", typeof(Chicken), 150, 5, 0xD0, 0));
                Add( new AnimalBuyInfo( 1, "a pig", typeof( Pig ), 350, 3, 0xCB, 0 ) );
                Add( new AnimalBuyInfo( 1, "a goat", typeof( Goat ), 400, 3, 0xD1, 0 ) );
                Add( new AnimalBuyInfo( 1, "a sheep", typeof( Sheep ), 400, 5, 0xCF, 0 ) );
                Add( new AnimalBuyInfo( 1, "a cow", typeof( Cow ), 850, 5, 0xE7, 0 ) );
                Add( new AnimalBuyInfo( 1, "a bull", typeof( Bull ), 850, 1, 0xE8, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 

				Add( typeof( CheeseForm ), 75 );
				Add( typeof( MilkBucket ), 75 );
				Add( typeof( Pitcher ), 5 );

				Add( typeof( Apple ), 1 );
				Add( typeof( Cabbage ), 1 );
				Add( typeof( Lettuce ), 1 );
                Add( typeof( SheafOfHay ), 1 );
				Add( typeof( Carrot ), 1 );
				Add( typeof( Pumpkin ), 1 );
				Add( typeof( Onion ), 1 );
			} 
		} 
	} 
}
