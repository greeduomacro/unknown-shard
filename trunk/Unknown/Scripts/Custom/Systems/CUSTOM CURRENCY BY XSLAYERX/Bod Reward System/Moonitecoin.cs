//Please Leave Credit XSlayerX aka XLacaestX
using System;
namespace Server.Items
{
	public class Moonitecoin : Item
	{
		public override double DefaultWeight
		{
			get { return 0.02; }
		}

		[Constructable]
		public Moonitecoin() : this( 1 )
        {
        }

		[Constructable]
		public Moonitecoin( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}

		[Constructable]
		public Moonitecoin( int amount ) : base( 0xEED )
		{
			Stackable = true;
			Amount = amount;
            Hue = 3;
            Name = "Moonite Coins";
		}

        public Moonitecoin(Serial serial)
            : base(serial)
		{
		}

		public override int GetDropSound()
		{
			if ( Amount <= 1 )
				return 0x2E4;
			else if ( Amount <= 5 )
				return 0x2E5;
			else
				return 0x2E6;
		}

		protected override void OnAmountChange( int oldValue )
		{
			int newValue = this.Amount;

			UpdateTotal( this, TotalType.Gold, newValue - oldValue );
		}

		public override int GetTotal( TotalType type )
		{
			int baseTotal = base.GetTotal( type );

			if ( type == TotalType.Gold )
				baseTotal += this.Amount;

			return baseTotal;
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