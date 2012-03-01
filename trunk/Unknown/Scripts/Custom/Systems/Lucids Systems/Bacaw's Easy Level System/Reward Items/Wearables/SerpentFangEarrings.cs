using System;
using Server;

namespace Server.Items
{
	public class SerpentFangEarrings : SilverEarrings
	{
		[Constructable]
		public SerpentFangEarrings()
		{
			Name = "Serpent Fang Earrings";
			Hue = 1160;

			Attributes.EnhancePotions = 25;
			Attributes.Luck = 105;
			Attributes.BonusInt = 4;
			SkillBonuses.SetValues( 0, SkillName.Poisoning, 5.0 );
			SkillBonuses.SetValues( 1, SkillName.Alchemy, 7.0 );
		}

		public SerpentFangEarrings( Serial serial ) : base( serial )
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