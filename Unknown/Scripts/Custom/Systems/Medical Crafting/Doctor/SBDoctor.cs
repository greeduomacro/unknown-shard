using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBDoctor: SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDoctor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{
			Add( new GenericBuyInfo( typeof( MedicalTools ), 10000, 20, 0x1EB8, 0 ) );
			Add( new GenericBuyInfo( typeof( PrescriptionDemerol ), 8000, 20, 0x14F0, 0 ) );
			Add( new GenericBuyInfo( typeof( PrescriptionVicodin ), 12000, 20, 0x14F0, 0 ) );
			Add( new GenericBuyInfo( typeof( PrescriptionOxycontin ), 18000, 20, 0x14F0, 0 ) );
			Add( new GenericBuyInfo( typeof( PrescriptionMorphine ), 28000, 20, 0x14F0, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Bandaid ), 70 );
				Add( typeof( EnhancedBandaid ), 100 );
				Add( typeof( MedicalSling ), 150 );
				Add( typeof( SurgicalKnife ), 2000 );
				Add( typeof( MedicalBook1 ), 50 );
				Add( typeof( MedicalBook2 ), 50 );
				Add( typeof( MedicalBook3 ), 50 );
				Add( typeof( MedicalBook4 ), 50 );
				Add( typeof( MedicalBlueBook ), 100 );
				Add( typeof( MedicalBrownBook ), 100 );
				Add( typeof( MedicalRedBook ), 100 );
				Add( typeof( MedicalTanBook ), 100 );
				Add( typeof( MedicalTreatmentsBook ), 300 );
				Add( typeof( PrescriptionDemerol ), 5000 );
				Add( typeof( PrescriptionVicodin ), 7000 );
				Add( typeof( PrescriptionOxycontin ), 10000 );
				Add( typeof( PrescriptionMorphine ), 20000 );
			}
		}
	}
}
