using System;
using Server.Network;

namespace Server.Items
{

	public class DecoMapSouth : Item
	{
		[Constructable]
		public DecoMapSouth() : base( 0x2D74 )
		{
			Weight = 6;
			Name = "Decorative Wall Map";
			Movable = true;
		}

		public DecoMapSouth( Serial serial ) : base( serial )
		{
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

	public class DecoMapEast : Item
	{
		[Constructable]
		public DecoMapEast() : base( 0x2D73 )
		{
			Weight = 6;
			Name = "Decorative Wall Map";
			Movable = true;
		}

		public DecoMapEast( Serial serial ) : base( serial )
		{
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
