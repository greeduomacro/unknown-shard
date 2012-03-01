//Written by Lord Dalamar
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class GoldenMandrakeRoot : BaseReagent
	{

		[Constructable]
		public GoldenMandrakeRoot() : this( 1 )
		{

			Hue= 2213;
			Name = "Golden Mandrake Root";

		}

		[Constructable]
		public GoldenMandrakeRoot( int amount ) : base( 0xF86, amount )
		{
		}

		public GoldenMandrakeRoot( Serial serial ) : base( serial )
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