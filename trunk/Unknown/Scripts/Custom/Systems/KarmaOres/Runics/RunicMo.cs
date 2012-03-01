using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicMo : RunicHammer
	{

		[Constructable]
		public RunicMo() : this( 10 )
		{
		}		

		[Constructable]
		public RunicMo( int uses ) : base( CraftResource.Moonstone )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicMo( Serial serial ) : base( serial )
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