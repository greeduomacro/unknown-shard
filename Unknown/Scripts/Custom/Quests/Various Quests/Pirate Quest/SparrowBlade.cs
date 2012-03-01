using System;
using Server;

namespace Server.Items
{
	public class SparrowBlade : Katana 
	{
		public override int ArtifactRarity{ get{ return 6; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public SparrowBlade()
		{
			Weight = 5.0;
            		Name = "Captian Sparrow's Blade";
            		Hue = 1157;

			WeaponAttributes.HitLightning = 40;
			WeaponAttributes.HitHarm = 45;
			WeaponAttributes.HitLowerDefend = 45;

			Attributes.Luck = 300;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 25;

			StrRequirement = 70;

			LootType = LootType.Regular;
		}

		public SparrowBlade( Serial serial ) : base( serial )
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