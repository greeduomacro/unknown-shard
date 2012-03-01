using System;
using Server;

namespace Server.Items
{
	public class DragonSilkShirt : FancyShirt
	{
		[Constructable]
		public DragonSilkShirt()
		{
			Name = "Dragon Silk Shirt";
			Hue = 1172;

			Attributes.BonusInt = 2;
			Attributes.BonusMana = 15;
			Attributes.BonusStr = 3;
			Attributes.LowerManaCost = 7;
			Attributes.LowerRegCost = 5;
			Attributes.ReflectPhysical = 20;
			Attributes.RegenHits = 5;
			Attributes.RegenMana = 1;
			Resistances.Energy = 8;
			Resistances.Fire = 35;
			Resistances.Physical = 23;
			Resistances.Poison = 2;
		}

		public DragonSilkShirt( Serial serial ) : base( serial )
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