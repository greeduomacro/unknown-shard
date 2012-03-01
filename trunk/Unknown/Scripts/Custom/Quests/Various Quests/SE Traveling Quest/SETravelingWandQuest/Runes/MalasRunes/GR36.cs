using System;
using Server;

namespace Server.Items
{
	public class GR36 : Item
	{
		[Constructable]
		public GR36() : this( 1 )
		{
		}

		[Constructable]
		public GR36( int amount ) : base( 0x1F1C )
		{
                        Name = "Glowing Rune of Umbra Malas";
			Stackable = false;
			Weight = 1.0;
			Hue = 1152;
			 
			Amount = amount;
		}

		public GR36( Serial serial ) : base( serial )
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