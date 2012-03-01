using System; 
using System.Collections; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBwSherif : SBInfo 
	{ 
		private ArrayList m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBwSherif() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override ArrayList BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : ArrayList 
		{ 
			public InternalBuyInfo() 
			{ 	
				Add( new GenericBuyInfo( typeof( WantedCrinminalsDeed ), 5, 200, 0x14F0, 0 ) );
				
				if ( Core.AOS )
				{
				}

				if( Core.AOS )
				{
				}
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( HeadofOdin ), 50000 );
				Add( typeof( HeadofXerian ), 10000 );
				Add( typeof( HeadofFanalaon ), 10000 );
				Add( typeof( HeadofMarine ), 5000 );
				Add( typeof( HeadofWickedClown ), 30000 );
				Add( typeof( HeadofFresh ), 50000 );
				Add( typeof( HeadofZinaga ), 45000 );
				Add( typeof( HeadofBeast ), 35000 );
				Add( typeof( HeadofOldSchool ), 25000 ); 

				if( Core.AOS )
				{
				}
			} 
		} 
	} 
}