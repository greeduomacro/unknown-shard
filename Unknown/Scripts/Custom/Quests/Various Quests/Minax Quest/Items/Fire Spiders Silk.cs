//Written by Lord Dalamar
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class FireSilk : BaseReagent
	{
		
		[Constructable]
		public FireSilk() : this( 1 )
		{

			Hue = 1161;
			Name = "Fire Spiders Silk";

		}

		[Constructable]
		public FireSilk( int amount ) : base( 0xF8D, amount )
		{
		}

		public FireSilk( Serial serial ) : base( serial )
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