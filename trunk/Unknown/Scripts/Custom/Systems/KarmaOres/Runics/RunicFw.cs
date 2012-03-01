using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicFw : RunicFletchersTools
	{

		[Constructable]
		public RunicFw() : this( 10 )
		{
		}		

		[Constructable]
		public RunicFw( int uses ) : base( CraftResource.Frostwood )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicFw( Serial serial ) : base( serial )
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