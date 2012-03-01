using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicVal : RunicHammer
	{

		[Constructable]
		public RunicVal() : this( 10 )
		{
		}		

		[Constructable]
		public RunicVal( int uses ) : base( CraftResource.Valorite )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicVal( Serial serial ) : base( serial )
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