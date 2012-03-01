using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicC : RunicHammer
	{

		[Constructable]
		public RunicC() : this( 10 )
		{
		}		

		[Constructable]
		public RunicC( int uses ) : base( CraftResource.Copper )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicC( Serial serial ) : base( serial )
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