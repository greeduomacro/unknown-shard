using System;
using Server.Network;
using Server.Items;
using Server.Engines.Harvest;

namespace Server.Items
{
	[FlipableAttribute( 0x26BA, 0x26C4 )]
	public class ZinagaScythe : BasePoleArm
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 18; } }
		public override int AosSpeed{ get{ return 32; } }

		public override int OldStrengthReq{ get{ return 45; } }
		public override int OldMinDamage{ get{ return 15; } }
		public override int OldMaxDamage{ get{ return 18; } }
		public override int OldSpeed{ get{ return 32; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override HarvestSystem HarvestSystem{ get{ return null; } }

		[Constructable]
		public ZinagaScythe() : base( 0x26BA )
		{
			Name = "ZinagaScythe";
			Weight = 5.0;
			
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
			WeaponAttributes.UseBestSkill = 1;
			WeaponAttributes.HitLeechMana = 25;
			WeaponAttributes.HitHarm = 66;
			WeaponAttributes.HitLightning = 20;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 66;
			Attributes.AttackChance = 20;
			Attributes.DefendChance = 50;
			Attributes.LowerManaCost = 66;
			Attributes.CastRecovery = 25;
			Attributes.CastSpeed = 66;
			Attributes.SpellChanneling = 2;
			Attributes.Luck = 66;
			Attributes.BonusStr = 35;
			Attributes.BonusDex = 35;
			Attributes.BonusInt = 35;
			LootType = LootType.Blessed;
		}

		public ZinagaScythe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 15.0 )
				Weight = 5.0;
		}
	}
}