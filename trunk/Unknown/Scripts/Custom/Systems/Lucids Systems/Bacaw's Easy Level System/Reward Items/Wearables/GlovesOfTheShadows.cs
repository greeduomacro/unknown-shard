using System;
using Server;

namespace Server.Items
{
	public class GlovesOfTheShadows : LeatherGloves
	{
		public override int InitMinHits{ get{ return 200; } }
		public override int InitMaxHits{ get{ return 250; } }

		[Constructable]
		public GlovesOfTheShadows()
		{
			Name = "Gloves Of The Shadows";
			SkillBonuses.SetValues( 0, SkillName.Hiding, 3.0 );
			SkillBonuses.SetValues( 1, SkillName.Snooping, 5.0 );
			SkillBonuses.SetValues( 2, SkillName.Stealing, 2.0 );
			SkillBonuses.SetValues( 3, SkillName.Stealth, 1.0 );
			SkillBonuses.SetValues( 4, SkillName.Camping, 10.0 );
			Attributes.Luck = 725;
		}

		public GlovesOfTheShadows( Serial serial ) : base( serial )
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