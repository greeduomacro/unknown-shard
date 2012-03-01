using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicMa : RunicFletchersTools
	{

		[Constructable]
		public RunicMa() : this( 10 )
		{
		}		

		[Constructable]
		public RunicMa( int uses ) : base( CraftResource.Mahogany )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicMa( Serial serial ) : base( serial )
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