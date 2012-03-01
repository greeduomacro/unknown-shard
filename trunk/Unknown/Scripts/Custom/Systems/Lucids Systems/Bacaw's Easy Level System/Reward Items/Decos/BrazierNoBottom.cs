using System;
using Server;


namespace Server.Items
{
	public class BrazierNoBottom : Item
	{
		[Constructable]
		public BrazierNoBottom() : this( 1 )
		{
		}

		[Constructable]
		public BrazierNoBottom( int amount ) : base( 0x1F2B )
		{
			Name = "A Braizer";
			Hue = 0x0;
			Stackable = false;
			Weight = 5.1;
			Amount = amount;
		}

		public BrazierNoBottom( Serial serial ) : base( serial )
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
