using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfDruidReagents : Bag
	{

		[Constructable]
		public BagOfDruidReagents() : this( 1 ) 
		{ 
			Movable = true; 
			Hue = 0x48C; 
			Name = "bag of druid reagents";
		}

		[Constructable]
		public BagOfDruidReagents( int amount )
		{
			DropItem( new BlackPearl   ( 35 ) );
			DropItem( new Bloodmoss    ( 35 ) );
			DropItem( new Garlic       ( 35 ) );
			DropItem( new Ginseng      ( 35 ) );
			DropItem( new MandrakeRoot ( 35 ) );
			DropItem( new Nightshade   ( 35 ) );
			DropItem( new SulfurousAsh ( 35 ) );
			DropItem( new SpidersSilk  ( 35 ) );
			DropItem( new PetrafiedWood ( 35 ) );
			DropItem( new DestroyingAngel ( 35 ) );
			DropItem( new SpringWater ( 35 ) );
		}

		public BagOfDruidReagents( Serial serial ) : base( serial )
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
 
    
