using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicHw : RunicFletchersTools
	{

		[Constructable]
		public RunicHw() : this( 10 )
		{
		}		

		[Constructable]
		public RunicHw( int uses ) : base( CraftResource.Heartwood )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicHw( Serial serial ) : base( serial )
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