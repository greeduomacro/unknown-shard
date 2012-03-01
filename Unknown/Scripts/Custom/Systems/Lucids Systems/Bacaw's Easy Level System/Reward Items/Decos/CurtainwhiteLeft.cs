using System;
using Server;


namespace Server.Items
{
	public class CurtainWhiteLeft : Item
	{
		[Constructable]
		public CurtainWhiteLeft() : this( 1 )
		{
		}

		[Constructable]
		public CurtainWhiteLeft( int amount ) : base( 0x159E )
		{
			Name = "A Decorative White Curtain";
			Hue = 0x0;
			Stackable = false;
			Weight = 5.1;
			Amount = amount;
		}

		public CurtainWhiteLeft( Serial serial ) : base( serial )
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
