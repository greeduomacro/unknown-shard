using System;

namespace Server.Items
{

	public class SpecialFishingPants : BasePants
	{
		[Constructable]
		public SpecialFishingPants() : this( 0 )
		{
		}

		[Constructable]
		public SpecialFishingPants( int hue ) : base( 0x1539, hue )
		{
			Weight = 2.0;
			Name = "Special Fishing Pants";
			SkillBonuses.SetValues( 0, SkillName.Fishing, 20.0 );
		}

		public SpecialFishingPants( Serial serial ) : base( serial )
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