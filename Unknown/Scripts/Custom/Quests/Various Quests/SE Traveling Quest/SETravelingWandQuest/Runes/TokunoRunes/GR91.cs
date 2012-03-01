using System;
using Server;

namespace Server.Items
{
	public class GR91 : Item
	{
		[Constructable]
		public GR91() : this( 1 )
		{
		}

		[Constructable]
		public GR91( int amount ) : base( 0x1F1C )
		{
                        Name = "Glowing Rune of Kitsune Woods Tokuno";
			Stackable = false;
			Weight = 1.0;
			Hue = 1152;
			 
			Amount = amount;
		}

		public GR91( Serial serial ) : base( serial )
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