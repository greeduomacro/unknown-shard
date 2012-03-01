// Created By Lucid Nagual - Admin of The Conjuring
// I'd like to thank all the wonderful people for sharing they're scripts & support.
// I hope by submitting this I can at least partially pay back the Runuo Community.

using System;
using Server.Items;

namespace Server.Items
{
	public class DruidRegStone : Item
	{
		[Constructable]
		public DruidRegStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 0x48C;
			Name = "a druid reagent stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  //Large Bag of Holding---2050 Gold
			Item[] Token = from.Backpack.FindItemsByType( typeof( Gold ) );
		      if ( from.Backpack.ConsumeTotal( typeof( Gold ), 2050 ) )
		{
         	      BagOfDruidReagents BagOfDruidReagents = new BagOfDruidReagents( 50 );
		      from.AddToBackpack( BagOfDruidReagents );
			from.SendMessage( "2050 gold has been removed from your pack." );
		}
		   	else
		      {
		   		from.SendMessage( "You do not have enough funds for that." );
		   	}
					
		}

		public DruidRegStone( Serial serial ) : base( serial )
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
