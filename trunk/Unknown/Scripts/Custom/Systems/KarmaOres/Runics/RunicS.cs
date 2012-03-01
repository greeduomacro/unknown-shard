using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicS : RunicHammer
	{

		[Constructable]
		public RunicS() : this( 10 )
		{
		}		

		[Constructable]
		public RunicS( int uses ) : base( CraftResource.ShadowIron )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicS( Serial serial ) : base( serial )
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