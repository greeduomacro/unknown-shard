using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class RareHerb : BaseReagent, ICommodity
	{

		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} Rare Herb", Amount );
			}
		}

		[Constructable]
		public RareHerb() : this( 1 )
		{
            Name = "Rare Herb";
		}

		[Constructable]
		public RareHerb( int amount ) : base( 0xC63, amount )
		{
            Name = "Rare Herb";
		}

		public RareHerb( Serial serial ) : base( serial )
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