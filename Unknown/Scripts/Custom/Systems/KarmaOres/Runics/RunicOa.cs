using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicOa : RunicFletchersTools
	{

		[Constructable]
		public RunicOa() : this( 10 )
		{
		}		

		[Constructable]
		public RunicOa( int uses ) : base( CraftResource.Oak )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicOa( Serial serial ) : base( serial )
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