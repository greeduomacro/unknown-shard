using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class Rubble : Item
	{
		[Constructable]
		public Rubble( )
			: this( 632, "" )
		{

		}

		[Constructable]
		public Rubble( int itemID, string namePrefix )
			: base( itemID )
		{
			Name = namePrefix + " Rubble";
			Movable = true;
		}

		public Rubble( Serial serial )
			: base( serial )
		{

		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 );//Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = ( int )reader.ReadInt( );
		}
	}
}