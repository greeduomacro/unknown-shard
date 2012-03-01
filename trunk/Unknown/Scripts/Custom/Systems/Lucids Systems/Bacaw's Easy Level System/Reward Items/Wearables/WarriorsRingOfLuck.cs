using System;
using Server;

namespace Server.Items
{
	public class WarriorsRingOfLuck : GoldRing
	{
		[Constructable]
		public WarriorsRingOfLuck()
		{
			Name = "Warriors Ring Of Luck";
			Hue = 1172;

			Attributes.AttackChance = 10;
			Attributes.BonusDex = 3;
			Attributes.BonusStr = 5;
			Attributes.Luck = 500;
			Attributes.RegenHits = 7;
		}

		public WarriorsRingOfLuck( Serial serial ) : base( serial )
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