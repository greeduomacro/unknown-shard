using System;
using Server;

namespace Server.Items
{
	public class GR95 : Item
	{
		[Constructable]
		public GR95() : this( 1 )
		{
		}

		[Constructable]
		public GR95( int amount ) : base( 0x1F1C )
		{
                        Name = "Glowing Rune of Fan Dancer Dojo Tokuno";
			Stackable = false;
			Weight = 1.0;
			Hue = 1152;
			 
			Amount = amount;
		}

		public GR95( Serial serial ) : base( serial )
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