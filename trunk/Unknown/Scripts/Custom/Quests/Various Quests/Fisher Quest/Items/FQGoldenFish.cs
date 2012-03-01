using System;
using Server.Network;

namespace Server.Items
{
	public class FQGoldenFish : Item
	{
		[Constructable]
		public FQGoldenFish() : base( 0x09CC )
		{
			Weight = 10.0;
			Hue = 52;
			Name = "Golden Fish";
		}

		public FQGoldenFish( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendAsciiMessage( "This looks like it belongs to a Legendary Fisher." );
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