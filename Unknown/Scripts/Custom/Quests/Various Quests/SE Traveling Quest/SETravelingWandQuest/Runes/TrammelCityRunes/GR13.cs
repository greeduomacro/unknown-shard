using System;
using Server;

namespace Server.Items
{
	public class GR13 : Item
	{
		[Constructable]
		public GR13() : this( 1 )
		{
		}

		[Constructable]
		public GR13( int amount ) : base( 0x1F1C )
		{
                        Name = "Glowing Rune of Vesper Trammel";
			Stackable = false;
			Weight = 1.0;
			Hue = 1152;
			 
			Amount = amount;
		}

		public GR13( Serial serial ) : base( serial )
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