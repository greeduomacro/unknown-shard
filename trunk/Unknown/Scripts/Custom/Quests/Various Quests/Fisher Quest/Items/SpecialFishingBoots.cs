using System;

namespace Server.Items
{

	public class SpecialFishingBoots : BaseShoes
	{
		[Constructable]
		public SpecialFishingBoots() : this( 0 )
		{
		}

		[Constructable]
		public SpecialFishingBoots( int hue ) : base( 0x1711, hue )
		{
			Weight = 3.0;
			Name = "Special Fishing Boots";
			SkillBonuses.SetValues( 0, SkillName.Fishing, 20.0 );
		}

		public SpecialFishingBoots( Serial serial ) : base( serial )
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