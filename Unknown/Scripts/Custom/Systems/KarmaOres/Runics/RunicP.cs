using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicP : RunicHammer
	{

		[Constructable]
		public RunicP() : this( 10 )
		{
		}		

		[Constructable]
		public RunicP( int uses ) : base( CraftResource.Platinum )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicP( Serial serial ) : base( serial )
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