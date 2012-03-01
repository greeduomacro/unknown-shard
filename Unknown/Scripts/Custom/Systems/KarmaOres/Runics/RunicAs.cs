using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicAs : RunicFletchersTools
	{

		[Constructable]
		public RunicAs() : this( 10 )
		{
		}		

		[Constructable]
		public RunicAs( int uses ) : base( CraftResource.Ash )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicAs( Serial serial ) : base( serial )
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