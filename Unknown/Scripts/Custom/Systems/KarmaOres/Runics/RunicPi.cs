using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicPi : RunicFletchersTools
	{

		[Constructable]
		public RunicPi() : this( 10 )
		{
		}		

		[Constructable]
		public RunicPi( int uses ) : base( CraftResource.Pine )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicPi( Serial serial ) : base( serial )
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