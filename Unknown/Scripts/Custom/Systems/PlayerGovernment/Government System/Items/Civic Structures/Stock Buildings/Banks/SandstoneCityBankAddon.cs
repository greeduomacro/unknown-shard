/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SandstoneCityBankAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				//return new SandstoneCityBankAddonDeed();
				return null;
			}
		}

		[ Constructable ]
		public SandstoneCityBankAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 351 );
			AddComponent( ac, -3, 3, 7 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, -3, 2, 7 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, -3, 0, 7 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, -3, -1, 7 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, -3, -3, 7 );
			ac = new AddonComponent( 353 );
			AddComponent( ac, -3, -4, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, 1, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, -2, 0, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, -2, -1, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, -3, 7 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, -2, 3, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, -2, -4, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, -3, 2, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, -3, 0, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, -3, -2, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, -3, -3, 0 );
			ac = new AddonComponent( 102 );
			AddComponent( ac, -3, -4, 0 );
			ac = new AddonComponent( 352 );
			AddComponent( ac, -2, -4, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, -2, 3, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, -2, 2, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, -2, -2, 7 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, -3, 3, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, -3, 1, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, -3, -1, 0 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, -3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, -2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, -1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, 0, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, 1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, 2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -2, 3, 27 );
			ac = new AddonComponent( 355 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, -2, 3, 7 );
			ac = new AddonComponent( 354 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, -3, 1, 7 );
			ac = new AddonComponent( 354 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, -3, -2, 7 );
			ac = new AddonComponent( 363 );
			AddComponent( ac, -3, -4, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, -2, -4, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, -3, -3, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, -3, -2, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, -3, -1, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, -3, 0, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, -3, 1, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, -3, 2, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, -3, 3, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, -2, 3, 27 );
			ac = new AddonComponent( 2974 );
			AddComponent( ac, -3, 4, 7 );
			ac = new AddonComponent( 2880 );
			AddComponent( ac, -2, -3, 7 );
			ac = new AddonComponent( 3823 );
			AddComponent( ac, -2, -3, 13 );
			ac = new AddonComponent( 352 );
			AddComponent( ac, 1, -4, 7 );
			ac = new AddonComponent( 352 );
			AddComponent( ac, 0, -4, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 4, 3, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 4, 2, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 4, 1, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 4, 0, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, -1, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 4, -2, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 4, -3, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 3, 3, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 3, 1, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 3, 0, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 3, -2, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 3, -3, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, 3, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 2, 2, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, 1, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 2, 0, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 2, -1, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 2, -2, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 2, -3, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 1, 3, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 1, 1, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 1, -2, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 0, 3, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 0, 2, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, 1, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 0, 0, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 0, -1, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 0, -2, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, -1, 3, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, -1, 2, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, 1, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, 0, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, -1, -1, 7 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, 4, 1, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, 4, -1, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, 4, -2, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, 4, -3, 0 );
			ac = new AddonComponent( 1873 );
			AddComponent( ac, 0, 4, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 3, 3, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 2, 3, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 1, 3, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 0, 3, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, -1, 3, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 3, -4, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 2, -4, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, -1, -4, 0 );
			ac = new AddonComponent( 352 );
			AddComponent( ac, 4, -4, 7 );
			ac = new AddonComponent( 352 );
			AddComponent( ac, 3, -4, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 3, 2, 7 );
			ac = new AddonComponent( 1182 );
			AddComponent( ac, 3, -1, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 1, 2, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 1, 0, 7 );
			ac = new AddonComponent( 1184 );
			AddComponent( ac, 1, -1, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, 1, -3, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, -3, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, -2, 7 );
			ac = new AddonComponent( 1183 );
			AddComponent( ac, -1, -3, 7 );
			ac = new AddonComponent( 101 );
			AddComponent( ac, 4, 3, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, 4, 2, 0 );
			ac = new AddonComponent( 100 );
			AddComponent( ac, 4, 0, 0 );
			ac = new AddonComponent( 1873 );
			AddComponent( ac, 1, 4, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 4, -4, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 1, -4, 0 );
			ac = new AddonComponent( 99 );
			AddComponent( ac, 0, -4, 0 );
			ac = new AddonComponent( 352 );
			AddComponent( ac, -1, 3, 7 );
			ac = new AddonComponent( 1882 );
			AddComponent( ac, 2, 4, 0 );
			ac = new AddonComponent( 1883 );
			AddComponent( ac, -1, 4, 0 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, 4, -3, 7 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, 4, -1, 7 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, 4, 0, 7 );
			ac = new AddonComponent( 351 );
			AddComponent( ac, 4, 2, 7 );
			ac = new AddonComponent( 352 );
			AddComponent( ac, 2, 3, 7 );
			ac = new AddonComponent( 350 );
			AddComponent( ac, 4, 3, 7 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, -3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, -2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, -1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, 0, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, 1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, 2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, -1, 3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, -3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, -2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, -1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, 0, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, 1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, 2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, 3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 1, -3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 1, -2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 1, -1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 1, 0, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 1, 1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 1, 2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 1, 3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, -3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, -2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, -1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, 0, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, 1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, 2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 2, 3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 3, -3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 3, -2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 3, -1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 3, 0, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 3, 1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 3, 2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 3, 3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, -3, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, -2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, -1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, 0, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, 1, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, 2, 27 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 4, 3, 27 );
			ac = new AddonComponent( 355 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 3, 3, 7 );
			ac = new AddonComponent( 355 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, -1, -4, 7 );
			ac = new AddonComponent( 355 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 2, -4, 7 );
			ac = new AddonComponent( 354 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 4, 1, 7 );
			ac = new AddonComponent( 354 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 4, -2, 7 );
			ac = new AddonComponent( 360 );
			AddComponent( ac, 4, 3, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, 4, -3, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, 4, -2, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, 4, -1, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, 4, 0, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, 4, 1, 27 );
			ac = new AddonComponent( 361 );
			AddComponent( ac, 4, 2, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, -1, 3, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 0, 3, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 1, 3, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 2, 3, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 3, 3, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, -1, -4, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 0, -4, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 1, -4, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 2, -4, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 3, -4, 27 );
			ac = new AddonComponent( 362 );
			AddComponent( ac, 4, -4, 27 );
			ac = new AddonComponent( 2880 );
			AddComponent( ac, -1, -3, 7 );
			ac = new AddonComponent( 3826 );
			AddComponent( ac, -1, -3, 13 );

		}

		public SandstoneCityBankAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	
}
