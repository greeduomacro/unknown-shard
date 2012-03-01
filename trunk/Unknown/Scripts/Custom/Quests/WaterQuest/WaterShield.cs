using System;
using Server;

namespace Server.Items
{
	public class WaterShield : BaseShield
	{
public override int ArtifactRarity{ get{ return 10; } }

		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 2; } }
		public override int BaseColdResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 2; } }
		public override int BaseEnergyResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 200; } }

		public override int AosStrReq{ get{ return 15; } }

		public override int ArmorBase{ get{ return 16; } }

		[Constructable]
		public WaterShield() : base( 0x1B74 )
		{
			Hue = 2999;
			Weight = 1.0;
     ArmorAttributes.DurabilityBonus = 1;
      ArmorAttributes.LowerStatReq = 15;
      ArmorAttributes.MageArmor = 1;
      ArmorAttributes.SelfRepair = 1;
      Attributes.BonusDex = 2;
      Attributes.BonusHits = 2;
      Attributes.BonusInt = 2;
      Attributes.BonusMana = 2;
      Attributes.BonusStam = 2;
      Attributes.LowerManaCost = 1;
      Attributes.LowerRegCost = 1;
      Attributes.Luck = 1;
      Attributes.NightSight = 1;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 2;
      Attributes.BonusMana = 2;
      LootType = LootType.Blessed;
		}

		public WaterShield( Serial serial ) : base(serial)
		{
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 1.0 )
				Weight = 1.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
