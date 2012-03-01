using System;
using Server.Items;

namespace Server.Items
{
	public class SkeletalBone : Item, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} SkeletalBone" : "{0} SkeletalBones", Amount );
			}
		}

		[Constructable]
		public SkeletalBone() : this( 1 )
		{
		}

		[Constructable]
		public SkeletalBone( int amount ) : base( 0xf7e )
		{
			Hue = 1950;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public SkeletalBone( Serial serial ) : base( serial )
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