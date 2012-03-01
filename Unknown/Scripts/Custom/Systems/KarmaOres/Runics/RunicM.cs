using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicM : RunicHammer
	{

		[Constructable]
		public RunicM() : this( 10 )
		{
		}		

		[Constructable]
		public RunicM( int uses ) : base( CraftResource.Mythril )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicM( Serial serial ) : base( serial )
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