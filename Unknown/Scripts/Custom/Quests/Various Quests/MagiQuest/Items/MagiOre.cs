using System;

namespace Server.Items
{
	public class MagiOre : Item
	{
		[Constructable]
		public MagiOre() : base( 0x19B9 )
		{
			Name = "Ore of the Magi";
			Hue= 1150;
			Weight = 0.1;						
		}

		public MagiOre( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}