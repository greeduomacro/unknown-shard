using System;
using Server;

namespace Server.Items
{
	public class GR67 : Item
	{
		[Constructable]
		public GR67() : this( 1 )
		{
		}

		[Constructable]
		public GR67( int amount ) : base( 0x1F1C )
		{
                        Name = "Glowing Rune of Fire Trammel";
			Stackable = false;
			Weight = 1.0;
			Hue = 1152;
			 
			Amount = amount;
		}

		public GR67( Serial serial ) : base( serial )
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