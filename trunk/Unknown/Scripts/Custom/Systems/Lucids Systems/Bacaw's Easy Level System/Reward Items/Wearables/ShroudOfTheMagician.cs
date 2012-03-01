using System;
using Server;

namespace Server.Items
{
	public class ShroudOfTheMagician : HoodedShroudOfShadows
	{
		[Constructable]
		public ShroudOfTheMagician()
		{
			Name = "Shroud Of The Magician";
			Hue = 1175;

			Attributes.BonusInt = 7;
			Attributes.BonusMana = 25;
			Attributes.LowerManaCost = 12;
			Attributes.LowerRegCost = 10;
			Attributes.NightSight = 1;
			Attributes.ReflectPhysical = 12;
			Attributes.RegenHits = 5;
			Attributes.RegenMana = 3;
			Attributes.RegenStam = 2;
			Attributes.SpellDamage = 11;
		}

		public ShroudOfTheMagician( Serial serial ) : base( serial )
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