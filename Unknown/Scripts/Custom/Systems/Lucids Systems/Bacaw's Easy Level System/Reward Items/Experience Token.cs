using System;


namespace Server.Items
{
	public class ExpToken : Item
	{
		
		
		[Constructable]
		public ExpToken() : this( 1 )
		{
		}

		[Constructable]
		public ExpToken( int amountFrom, int amountTo ) : this( Utility.Random( amountFrom, amountTo - amountFrom ) )
		{
		}

		[Constructable]
		public ExpToken( int amount ) : base( 0xEED )
		{  
         	Name = "Experience Tokens"; 
         	Hue = 88; 
         	Stackable = true; 
         	Weight = 0.2;
         	Amount = amount;
		}

		public ExpToken( Serial serial ) : base( serial )
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
