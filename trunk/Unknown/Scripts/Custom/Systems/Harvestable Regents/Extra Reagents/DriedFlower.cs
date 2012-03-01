using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class DriedFlower : BaseReagent, ICommodity
	{

		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} Dried Flowers", Amount );
			}
		}

		[Constructable]
		public DriedFlower() : this( 1 )
		{
            Name = "Dried Flowers";
		}

		[Constructable]
		public DriedFlower( int amount ) : base( 0xC3B, amount )
		{
            Name = "Dried Flowers";
		}

		public DriedFlower( Serial serial ) : base( serial )
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