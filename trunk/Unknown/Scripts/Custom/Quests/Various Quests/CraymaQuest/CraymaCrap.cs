using System;
using Server;

namespace Server.Items
{
	public class CraymaCrap : Item
	{
		[Constructable]
		public CraymaCrap() : this( 1 )
		{
		}

		[Constructable]
		public CraymaCrap( int amount ) : base( 0xF81 )
		{
                        Name = "Crayma Crap";
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
		}

		public CraymaCrap( Serial serial ) : base( serial )
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