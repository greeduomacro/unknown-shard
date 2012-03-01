using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicA : RunicHammer
	{

		[Constructable]
		public RunicA() : this( 10 )
		{
		}		

		[Constructable]
		public RunicA( int uses ) : base( CraftResource.Agapite )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicA( Serial serial ) : base( serial )
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