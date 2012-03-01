//Written by Lord Dalamar
using System;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GoldenWool : Item, IDyable
	{
		[Constructable]
		public GoldenWool() : this( 1 )
		{
		}

		[Constructable]
		public GoldenWool( int amount ) : base( 0xDF8 )
		{
			Stackable = true;
			Weight = 4.0;
			Amount = amount;
			Hue = 2213;
			Name = "Golden Wool";

		}

		public GoldenWool( Serial serial ) : base( serial )
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

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

	}
}