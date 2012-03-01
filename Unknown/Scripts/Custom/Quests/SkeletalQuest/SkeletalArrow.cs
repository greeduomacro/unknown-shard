using System;

namespace Server.Items
{
	public class SkeletalArrow : Item, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} SkeletalArrow" : "{0} SkeletalArrows", Amount );
			}
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public SkeletalArrow() : this( 1 )
		{
		}

		[Constructable]
		public SkeletalArrow( int amount ) : base( 0xF3F )
		{
			Hue = 1950;
			Stackable = true;
			Amount = amount;
		}

		public SkeletalArrow( Serial serial ) : base( serial )
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