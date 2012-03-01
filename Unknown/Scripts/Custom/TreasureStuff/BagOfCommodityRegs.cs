using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfCommodityRegs : Bag 
	{ 
		[Constructable] 
		public BagOfCommodityRegs() : this( 500 ) 
		{ 
		} 

		[Constructable] 
		public BagOfCommodityRegs( int amount ) 
		{ 
			DropItem( new CommodityDeed( new Bloodmoss    ( amount ) ) ); 
			DropItem( new CommodityDeed( new MandrakeRoot ( amount ) ) ); 
			DropItem( new CommodityDeed( new BlackPearl   ( amount ) ) ); 
			DropItem( new CommodityDeed( new Nightshade   ( amount ) ) ); 
			DropItem( new CommodityDeed( new SulfurousAsh ( amount ) ) ); 
			DropItem( new CommodityDeed( new Garlic       ( amount ) ) ); 
			DropItem( new CommodityDeed( new SpidersSilk  ( amount ) ) ); 
			DropItem( new CommodityDeed( new Ginseng      ( amount ) ) ); 


		} 

		public BagOfCommodityRegs( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 
} 
