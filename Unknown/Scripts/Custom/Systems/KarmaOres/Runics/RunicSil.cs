using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicSil : RunicHammer
	{

		[Constructable]
		public RunicSil() : this( 10 )
		{
		}		

		[Constructable]
		public RunicSil( int uses ) : base( CraftResource.Silver )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicSil( Serial serial ) : base( serial )
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