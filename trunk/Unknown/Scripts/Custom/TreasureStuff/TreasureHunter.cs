using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
//Script made By Kitchen_ Feb 2009
namespace Server.Custom
{
    public class TreasureHunter : BaseVendor
    {
        private ArrayList m_SBInfos = new ArrayList();
        protected override ArrayList SBInfos { get { return m_SBInfos; } }

        [Constructable]
        public TreasureHunter() : base( "The Treasure Hunter" )
        {
            SetSkill( SkillName.Cartography, 85.0, 100.0 );
            SetSkill( SkillName.Fishing, 65.0, 88.0 );
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add( new SBTreasureHunter() );
        }

        public TreasureHunter( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }

    public class SBTreasureHunter : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBTreasureHunter()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( TreasureMap ), 1000, 20, 0x14EC, 0, new object[] { 1, Map.Trammel } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 2000, 20, 0x14EC, 0, new object[] { 2, Map.Trammel } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 3000, 20, 0x14EC, 0, new object[] { 3, Map.Trammel } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 4000, 20, 0x14EC, 0, new object[] { 4, Map.Trammel } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 5000, 20, 0x14EC, 0, new object[] { 5, Map.Trammel } ) );
				Add( new GenericBuyInfo( typeof( TreasureMap ), 6000, 20, 0x14EC, 0, new object[] { 6, Map.Trammel } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 1000, 20, 0x14EC, 37, new object[] { 1, Map.Felucca } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 2000, 20, 0x14EC, 37, new object[] { 2, Map.Felucca } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 3000, 20, 0x14EC, 37, new object[] { 3, Map.Felucca } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 4000, 20, 0x14EC, 37, new object[] { 4, Map.Felucca } ) );
                Add( new GenericBuyInfo( typeof( TreasureMap ), 5000, 20, 0x14EC, 37, new object[] { 5, Map.Felucca } ) );
				Add( new GenericBuyInfo( typeof( TreasureMap ), 6000, 20, 0x14EC, 37, new object[] { 6, Map.Felucca } ) );
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