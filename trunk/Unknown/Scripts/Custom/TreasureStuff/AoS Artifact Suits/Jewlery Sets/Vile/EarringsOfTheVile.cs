using System;
using Server;

namespace Server.Items
{
	public class EarringsOfTheVile : GoldEarrings
	{
		public override int LabelNumber{ get{ return 1061102; } } // Earrings of the Vile
		public override int ArtifactRarity{ get{ return 11; } }

		[Constructable]
		public EarringsOfTheVile()
		{
			Name = "Earrings of the Vile";
			Hue = 0x4F7;
			Attributes.BonusDex = 6;
			Attributes.RegenStam = 4;
			Attributes.AttackChance = 12;
			Resistances.Poison = 20;
		}

		public EarringsOfTheVile( Serial serial ) : base( serial )
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

			if ( Hue == 0x4F4 )
				Hue = 0x4F7;
		}
	}
}