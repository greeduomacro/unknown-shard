using System;

namespace Server.Items
{
	public class TreasureMapPieceAncient : Item
	{
		[Constructable]
		public TreasureMapPieceAncient() : base( 0xE34 )
		{
		      	Weight = 0.5;
			Stackable = true;
			Hue = 0x594;
			Name = "Ancient Treasure Map Piece";
		}

		public TreasureMapPieceAncient( Serial serial ) : base( serial )
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