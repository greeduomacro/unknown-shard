using System;

namespace Server.Items
{
	public class BallsofFire : Item, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} BallsofFire" : "{0} BallsofFires", Amount );
			}
		}

		

		[Constructable]
		public BallsofFire() : this( 1 )
		{
		}

		[Constructable]
		public BallsofFire( int amount ) : base( 0x1869 )
		{
			Name = "Ball of Fire";
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
			Hue = 1;

		}

		public BallsofFire( Serial serial ) : base( serial )
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