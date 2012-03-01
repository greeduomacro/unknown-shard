using System;

namespace Server.Items
{
	public class SpecialFishingHat : BaseHat
	{
		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 0; } }

		[Constructable]
		public SpecialFishingHat() : this( 0 )
		{
		}

		[Constructable]
		public SpecialFishingHat( int hue ) : base( 0x171B, hue )
		{
			Weight = 1.0;
			Name = "Special Fishing Hat";
			SkillBonuses.SetValues( 0, SkillName.Fishing, 20.0 );	
		}

		public SpecialFishingHat( Serial serial ) : base( serial )
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