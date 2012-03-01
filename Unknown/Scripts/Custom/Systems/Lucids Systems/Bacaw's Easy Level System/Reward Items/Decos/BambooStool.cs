using System;
using Server;

namespace Server.Items
{
	public class BambooStool : Item
	{
		[Constructable]
		public BambooStool() : this( 1 )
		{
		}

		[Constructable]
		public BambooStool( int amount ) : base( 0x11fc )
		{
			Name = "A very odd looking stool";
			Hue = 0x0;
			Stackable = false;
			Weight = 5.1;
			Amount = amount;
		}

		public BambooStool( Serial serial ) : base( serial )
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
