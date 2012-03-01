using System;
using Server;


namespace Server.Items
{
	public class CurtainWhiteRight : Item
	{
		[Constructable]
		public CurtainWhiteRight() : this( 1 )
		{
		}

		[Constructable]
		public CurtainWhiteRight( int amount ) : base( 0x159F )
		{
			Name = "A White Decorative Curtain";
			Hue = 0x0;
			Stackable = false;
			Weight = 5.1;
			Amount = amount;
		}

		public CurtainWhiteRight( Serial serial ) : base( serial )
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
