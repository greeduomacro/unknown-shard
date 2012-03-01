using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicHo : RunicSewingKit
	{

		[Constructable]
		public RunicHo() : this( 10 )
		{
		}		

		[Constructable]
		public RunicHo( int uses ) : base( CraftResource.HornedLeather )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicHo( Serial serial ) : base( serial )
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