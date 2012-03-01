using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicCe : RunicFletchersTools
	{

		[Constructable]
		public RunicCe() : this( 10 )
		{
		}		

		[Constructable]
		public RunicCe( int uses ) : base( CraftResource.Cedar )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicCe( Serial serial ) : base( serial )
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