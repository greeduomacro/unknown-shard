using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicVer : RunicHammer
	{

		[Constructable]
		public RunicVer() : this( 10 )
		{
		}		

		[Constructable]
		public RunicVer( int uses ) : base( CraftResource.Verite )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicVer( Serial serial ) : base( serial )
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