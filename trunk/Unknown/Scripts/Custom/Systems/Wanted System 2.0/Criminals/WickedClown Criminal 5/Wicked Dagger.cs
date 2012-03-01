using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF52, 0xF51 )]
	public class WickedDagger : BaseKnife
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 25; } }
		public override int AosMaxDamage{ get{ return 40; } }
		public override int AosSpeed{ get{ return 40; } }

		public override int OldStrengthReq{ get{ return 25; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 29; } }
		public override int OldSpeed{ get{ return 45; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 0; } }
		public override int InitMaxHits{ get{ return 0; } }

		[Constructable]
		public WickedDagger() : base( 0xF52 )
		{
			Name = "A Wicked Dagger";
			Weight = 6.0;
			Hue = 1;

			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
			WeaponAttributes.UseBestSkill = 1;
			WeaponAttributes.HitLeechMana = 25;
			WeaponAttributes.HitHarm = 40;
			WeaponAttributes.HitLightning = 10;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 50;
			Attributes.AttackChance = 40;
			Attributes.DefendChance = 25;
			Attributes.LowerManaCost = 5;
			Attributes.CastRecovery = 5;
			Attributes.CastSpeed = 50;
			Attributes.SpellChanneling = 1;
			Attributes.Luck = 25;
			Attributes.BonusStr = 65;
			Attributes.BonusDex = 65;
			Attributes.BonusInt = 65;
			LootType = LootType.Blessed;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
		{
			fire = cold = pois = 0;
			phys = 50;
			nrgy = 50;
		}

		public override bool Decays
		{
			get{ return false; }
		}

		public WickedDagger( Serial serial ) : base( serial )
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
		}
	}
}