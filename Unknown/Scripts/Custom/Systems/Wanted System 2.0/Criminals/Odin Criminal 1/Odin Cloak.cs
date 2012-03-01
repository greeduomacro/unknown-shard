using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{

	public class OdinCloak : BaseCloak
	{

		[Constructable]
		public OdinCloak() : this( 0 )
		{
		}

		[Constructable]
		public OdinCloak( int hue ) : base( 0x1515, hue )
		{
		
			Name = "Odins Cloak";
			Weight = 5.0;
			Hue = 1;
			LootType = LootType.Blessed;

			Attributes.ReflectPhysical = 50;
}

		public OdinCloak( Serial serial ) : base( serial )
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