//Written by Lord Dalamar
using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c00, 0x1c01 )]
	public class LegsMinax : LeatherShorts
	{
		public override int BasePhysicalResistance{ get{ return 20; } }
		public override int BaseFireResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 20; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 500; } }
		public override int InitMaxHits{ get{ return 500; } }

		[Constructable]
		public LegsMinax()
		{
			Weight = 3.0;
			Hue = 1172;
			Name = "Shorts of Lady Minax";
			Attributes.LowerRegCost = 100;

			LootType = LootType.Blessed;

		}

		public LegsMinax( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}