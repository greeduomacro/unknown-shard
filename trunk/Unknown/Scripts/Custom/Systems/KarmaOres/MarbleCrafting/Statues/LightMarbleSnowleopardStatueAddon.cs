/////////////////////////////////////////////////
//                                             //
// Automatically generated by the              //
// AddonGenerator script by Arya,              //
// modified for coloring by Manu               //
// Splitterwelt.com                            //
// german roleplay freeshard                   //
//                                             //
/////////////////////////////////////////////////
using System;
using Server;

namespace Server.Items
{
	public class LightMarbleSnowleopardStatueAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new LightMarbleSnowleopardStatueAddonDeed(); } }

		public override bool RetainDeedHue{ get{ return true; } }

		[Constructable]
		public LightMarbleSnowleopardStatueAddon() : this( 0 )
		{
		}

		[ Constructable ]
		public LightMarbleSnowleopardStatueAddon( int hue )
		{
			AddonComponent ac;
			ac = new AddonComponent( 9635 );
			ac.Hue = hue;
			ac.Name = "Marble Snow Leopard Statue";
			AddComponent( ac, 0, 0, 11 );
			ac = new AddonComponent( 4643 );
			ac.Hue = 1150;
			ac.Name = "Marble Statue Pedestal";
			AddComponent( ac, 0, 0, 0 );
		}

		public LightMarbleSnowleopardStatueAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class LightMarbleSnowleopardStatueAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon { get{ return new LightMarbleSnowleopardStatueAddon( this.Hue ); } }

		[Constructable]
		public LightMarbleSnowleopardStatueAddonDeed()
		{
			Name = "Marble Snow Leopard Statue (Bright Pedestal)";
		}

		public LightMarbleSnowleopardStatueAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}