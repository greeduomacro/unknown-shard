using System;
using Server;

namespace Server.Items
{
    public class LevelShadowDancerLeggings : LevelLeatherLegs
	{
		public override int LabelNumber{ get{ return 1061598; } } // Shadow Dancer Leggings
		public override int ArtifactRarity{ get{ return 11; } }

		public override int BasePhysicalResistance{ get{ return 17; } }
		public override int BasePoisonResistance{ get{ return 18; } }
		public override int BaseEnergyResistance{ get{ return 18; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public LevelShadowDancerLeggings()
		{
			ItemID = 0x13D2;
			Hue = 0x455;
			SkillBonuses.SetValues( 0, SkillName.Stealth, 20.0 );
			SkillBonuses.SetValues( 1, SkillName.Stealing, 20.0 );
		}

		public LevelShadowDancerLeggings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( ItemID == 0x13CB )
					ItemID = 0x13D2;

				PhysicalBonus = 0;
				PoisonBonus = 0;
				EnergyBonus = 0;
			}
		}
	}
}