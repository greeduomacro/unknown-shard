using System;
using Server;

namespace Server.Items
{
	public class OrcSkinShoes : Shoes
	{
		[Constructable]
		public OrcSkinShoes()
		{
			Name = "a Pair of Orc Skin Shoes";

			Attributes.BonusDex = 12;
			Attributes.BonusStam = 25;
			Attributes.CastRecovery = 3;
			Attributes.ReflectPhysical = 15;
			Attributes.RegenStam = 10;
			Attributes.WeaponSpeed = 3;
		}

		public OrcSkinShoes( Serial serial ) : base( serial )
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