using System;

namespace Server.Items
{
	public class CraftTreasureMap : TreasureMap
	{

		[Constructable]
		public CraftTreasureMap(): this( 1, Map.Felucca )
		{
		}

		[Constructable]
		public CraftTreasureMap( int Level, Map map) : base( Level, map )
		{
			Name = "A pieced-together treasure map";
			ItemID = 0x14EB;
			Hue = 0x4A7;
		}

		public CraftTreasureMap( Serial serial ) : base( serial )
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