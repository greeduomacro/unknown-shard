using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicDa : RunicSewingKit
	{

		[Constructable]
		public RunicDa() : this( 10 )
		{
		}		

		[Constructable]
		public RunicDa( int uses ) : base( CraftResource.DaemonLeather )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicDa( Serial serial ) : base( serial )
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