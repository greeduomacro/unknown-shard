using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicSu : RunicHammer
	{

		[Constructable]
		public RunicSu() : this( 10 )
		{
		}		

		[Constructable]
		public RunicSu( int uses ) : base( CraftResource.Sunstone )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicSu( Serial serial ) : base( serial )
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