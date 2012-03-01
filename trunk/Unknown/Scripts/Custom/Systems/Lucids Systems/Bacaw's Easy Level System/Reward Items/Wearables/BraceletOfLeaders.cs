using System;
using Server;

namespace Server.Items
{
	public class BraceletOfLeaders : GoldBracelet
	{
		[Constructable]
		public BraceletOfLeaders()
		{
			Name = "Bracelet Of Leaders";
			Hue = 1161;

			Attributes.BonusDex = 2;
			Attributes.BonusInt = 14;
			Attributes.BonusStam = 8;
			Attributes.DefendChance = 13;
			Attributes.ReflectPhysical = 10;
		}

		public BraceletOfLeaders( Serial serial ) : base( serial )
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