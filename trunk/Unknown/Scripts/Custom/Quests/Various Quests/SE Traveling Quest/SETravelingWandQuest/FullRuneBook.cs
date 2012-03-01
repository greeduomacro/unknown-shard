using System;
using Server;

namespace Server.Items
{
	public class FullRuneBook : Item
	{
		[Constructable]
		public FullRuneBook() : this( 1 )
		{
		}

		[Constructable]
		public FullRuneBook( int amount ) : base( 0x22C5 )
		{
                        Name = "A Completed Rune Book";
			Stackable = false;
			Weight = 1.0;
			Hue = 1152;
			LootType = LootType.Blessed;;
			Amount = amount;
		}

		public FullRuneBook( Serial serial ) : base( serial )
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