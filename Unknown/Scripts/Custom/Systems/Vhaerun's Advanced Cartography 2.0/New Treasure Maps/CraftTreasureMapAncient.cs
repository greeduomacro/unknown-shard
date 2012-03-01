using System;

namespace Server.Items
{
	public class CraftTreasureMapAncient : TreasureMap
	{

		[Constructable]
		public CraftTreasureMapAncient(): this( 3, Map.Felucca )
		{
		}

		[Constructable]
		public CraftTreasureMapAncient( int Level, Map map) : base( Level, map )
		{
			Name = "A pieced-together treasure map";
			ItemID = 0x14EB;
			Hue = 0x594;
		}

		public CraftTreasureMapAncient( Serial serial ) : base( serial )
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