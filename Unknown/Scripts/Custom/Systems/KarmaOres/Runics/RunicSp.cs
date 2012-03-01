using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicSp : RunicSewingKit
	{

		[Constructable]
		public RunicSp() : this( 10 )
		{
		}		

		[Constructable]
		public RunicSp( int uses ) : base( CraftResource.SpinedLeather )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicSp( Serial serial ) : base( serial )
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