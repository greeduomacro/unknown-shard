using System;
using Server;


namespace Server.Items
{
	public class CandleStub : Item
	{
		[Constructable]
		public CandleStub() : this( 1 )
		{
		}

		[Constructable]
		public CandleStub( int amount ) : base( 0x1436 )
		{
			Name = "A Candle Stub";
			Hue = 0x0;
			Stackable = false;
			Weight = 5.1;
			Amount = amount;
		}

		public CandleStub( Serial serial ) : base( serial )
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
