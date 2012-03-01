using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicDC : RunicHammer
	{
	
		[Constructable]
		public RunicDC() : this( 10 )
		{
		}		

		[Constructable]
		public RunicDC( int uses ) : base( CraftResource.DullCopper )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicDC( Serial serial ) : base( serial )
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