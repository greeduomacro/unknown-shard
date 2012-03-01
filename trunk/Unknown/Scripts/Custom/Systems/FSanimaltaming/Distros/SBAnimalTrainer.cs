
using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBAnimalTrainer : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{
				Add( new AnimalBuyInfo( 1, typeof( Cat ), 132, 500, 201, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Dog ), 170, 500, 217, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Horse ), 550, 500, 204, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 631, 500, 291, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( PackLlama ), 565, 500, 292, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Rabbit ), 106, 500, 205, 0 ) );
                		Add(new AnimalBuyInfo(1, typeof(BioTool), 72, 500, 0x1373, 1175));
                		Add(new AnimalBuyInfo(1, typeof(BioEnginerBook), 10001, 500, 4084, 0));
                		Add(new AnimalBuyInfo(1, typeof(PetShrinkPotion), 16, 500, 0xE26, 0));
                		Add(new AnimalBuyInfo(1, typeof(PetLeash), 2500, 500, 0x1374, 0));
                		Add(new AnimalBuyInfo(1, typeof(HitchingPostEastDeed), 5200, 500, 0x14F0, 0));
                		Add(new AnimalBuyInfo(1, typeof(HitchingPostSouthDeed), 5200, 500, 0x14F0, 0));
                		Add(new AnimalBuyInfo(1, typeof(Brush), 72, 500, 0x1373, 0));

				if( !Core.AOS )
				{
					Add( new AnimalBuyInfo( 1, typeof( Eagle ), 402, 500, 5, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( BrownBear ), 855, 500, 167, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( GrizzlyBear ), 1767, 500, 212, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( Panther ), 1271, 500, 214, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( TimberWolf ), 768, 500, 225, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( Rat ), 107, 500, 238, 0 ) );
				}
					
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
