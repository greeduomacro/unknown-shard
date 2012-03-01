using System;
using Server;

namespace Server.Items
{
	public class CloakOfTheMagician : Cloak
	{
		[Constructable]
		public CloakOfTheMagician()
		{
			Name = "Cloak Of The Magician";
			Hue = 1175;

			Attributes.LowerRegCost = 6;
			Attributes.ReflectPhysical = 8;
			Attributes.SpellDamage = 15;
			Attributes.RegenMana = 4;
			Resistances.Cold = 7;
			Resistances.Energy = 2;
			Resistances.Fire = 6;
			Resistances.Physical = 5;
			Resistances.Poison = 1;
		}

		public CloakOfTheMagician( Serial serial ) : base( serial )
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