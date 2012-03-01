using System;

namespace Server.Items
{

	public class SpecialFishingShirt : BaseShirt
	{
		[Constructable]
		public SpecialFishingShirt() : this( 0 )
		{
		}

		[Constructable]
		public SpecialFishingShirt( int hue ) : base( 0x1EFD, hue )
		{
			Weight = 2.0;
			Name = "Special Fishing Shirt";
			SkillBonuses.SetValues( 0, SkillName.Fishing, 20.0 );
		}

		public SpecialFishingShirt( Serial serial ) : base( serial )
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