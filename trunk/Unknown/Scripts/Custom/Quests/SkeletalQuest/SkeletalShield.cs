using System;
using Server;

namespace Server.Items
{
    public class SkeletalShield : BaseLevelShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 145; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int AosStrReq{ get{ return 45; } }

		public override int ArmorBase{ get{ return 16; } }

		[Constructable]
		public SkeletalShield() : base( 0x1B74 )
		{
			Name = "Skeletal Shield";
			Hue = 1950;
			Weight = 7.0;
		}

		public SkeletalShield( Serial serial ) : base(serial)
		{
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 5.0 )
				Weight = 7.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
