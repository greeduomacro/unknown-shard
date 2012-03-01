using System;
using Server;

namespace Server.Items
{
	public class SpiderSilkPants : LongPants
	{
		[Constructable]
		public SpiderSilkPants()
		{
			Name = "Spider Silk Pants";
			Hue = 1151;

			Attributes.BonusDex = 5;
			Attributes.RegenStam = 8;
			Resistances.Fire = -9;
			Resistances.Physical = 15;
			SkillBonuses.SetValues( 0, SkillName.Tailoring, 10.0 );
		}

		public SpiderSilkPants( Serial serial ) : base( serial )
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