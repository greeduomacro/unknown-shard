using System;
using Server;

namespace Server.Items
{
	public class WizardsHatOfIntelligence : WizardsHat
	{
		[Constructable]
		public WizardsHatOfIntelligence()
		{
			Name = "Wizards Hat Of Intelligence";

			Attributes.BonusInt = 15;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 7;
			Attributes.RegenMana = 2;
			Attributes.SpellDamage = 2;
			Resistances.Energy = 13;
		}

		public WizardsHatOfIntelligence( Serial serial ) : base( serial )
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