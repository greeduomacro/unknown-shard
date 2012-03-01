using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{

	public class BeastCloak : BaseCloak
	{

		[Constructable]
		public BeastCloak() : this( 0 )
		{
		}

		[Constructable]
		public BeastCloak( int hue ) : base( 0x1515, hue )
		{
		
			Name = "Beasts Cloak";
			Weight = 5.0;
			Hue = 1;
			LootType = LootType.Blessed;

			Attributes.ReflectPhysical = 50;
}

		public BeastCloak( Serial serial ) : base( serial )
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