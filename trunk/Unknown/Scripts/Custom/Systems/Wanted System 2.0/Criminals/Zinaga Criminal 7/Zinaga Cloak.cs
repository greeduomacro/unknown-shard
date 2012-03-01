using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{

	public class ZinagaCloak : BaseCloak
	{

		[Constructable]
		public ZinagaCloak() : this( 0 )
		{
		}

		[Constructable]
		public ZinagaCloak( int hue ) : base( 0x1515, hue )
		{
		
			Name = "Zinagas Cloak";
			Weight = 5.0;
			Hue = 1;
			LootType = LootType.Blessed;

			Attributes.ReflectPhysical = 50;
}

		public ZinagaCloak( Serial serial ) : base( serial )
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