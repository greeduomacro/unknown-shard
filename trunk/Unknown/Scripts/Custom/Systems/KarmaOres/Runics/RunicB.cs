using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicB : RunicHammer
	{

		[Constructable]
		public RunicB() : this( 10 )
		{
		}		

		[Constructable]
		public RunicB( int uses ) : base( CraftResource.Bronze )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicB( Serial serial ) : base( serial )
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