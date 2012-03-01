using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 6939, 6940 )]
	public class Spine : Item, IScissorable
	{
		[Constructable]
		public Spine() : base( 6939 + Utility.Random( 2 ) )
		{
			Stackable = false;
			Weight = 5.0;
		}

		public Spine( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) )
				return false;

			base.ScissorHelper( from, new Bone(), Utility.RandomMinMax( 3, 5 ) );

			return true;
		}
	}
}