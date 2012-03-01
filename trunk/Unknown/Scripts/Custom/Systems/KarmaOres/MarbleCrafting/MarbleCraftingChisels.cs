/////////////////////////////////////////////////
//                                             //
// Created by Manu for                         //
// Splitterwelt.com                            //
// german roleplay freeshard                   //
//                                             //
// may be used and modified as you like, as    //
// long as this header is kept                 //
/////////////////////////////////////////////////
using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class MarbleCraftingChisels : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefMarbleCrafting.CraftSystem; } }
		
		[Constructable]
		public MarbleCraftingChisels() : this( Utility.RandomMinMax ( 25,75 ) )
		{
		}

		[Constructable]
		public MarbleCraftingChisels( int uses ) : base( 0x12B3 )
		{
			Name = "Marble Crafting Tools";
			Weight = 8.0;
			UsesRemaining = uses;
		}


		public MarbleCraftingChisels( Serial serial ) : base( serial )
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