using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicYe : RunicFletchersTools
	{

		[Constructable]
		public RunicYe() : this( 10 )
		{
		}		

		[Constructable]
		public RunicYe( int uses ) : base( CraftResource.Yew )
		{
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicYe( Serial serial ) : base( serial )
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