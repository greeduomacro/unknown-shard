using System;
using Server;

namespace Server.Items
{
	public class LevelBraceletOfHealth : LevelGoldBracelet
	{
		public override int LabelNumber{ get{ return 1061103; } } // Bracelet of Health
		public override int ArtifactRarity{ get{ return 11; } }

		[Constructable]
		public LevelBraceletOfHealth()
		{
			Hue = 0x21;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 10;
		}

		public LevelBraceletOfHealth( Serial serial ) : base( serial )
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