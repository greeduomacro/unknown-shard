using System;
using Server;

namespace Server.Items
{
	public class GR66 : Item
	{
		[Constructable]
		public GR66() : this( 1 )
		{
		}

		[Constructable]
		public GR66( int amount ) : base( 0x1F1C )
		{
                        Name = "Glowing Rune of Orc Cave Trammel";
			Stackable = false;
			Weight = 1.0;
			Hue = 1152;
			 
			Amount = amount;
		}

		public GR66( Serial serial ) : base( serial )
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