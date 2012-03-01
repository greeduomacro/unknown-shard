using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicBl : RunicHammer
	{

		[Constructable]
		public RunicBl() : this( 10 )
		{
		}		

		[Constructable]
		public RunicBl( int uses ) : base( CraftResource.Bloodstone )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicBl( Serial serial ) : base( serial )
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