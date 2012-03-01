using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26BB, 0x26C5 )]
	public class FanalaonBoneHarvester : BaseSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return 400; } }
		public override int AosMaxDamage{ get{ return 450; } }
		public override int AosSpeed{ get{ return 360; } }

		public override int OldStrengthReq{ get{ return 25; } }
		public override int OldMinDamage{ get{ return 13; } }
		public override int OldMaxDamage{ get{ return 15; } }
		public override int OldSpeed{ get{ return 36; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public FanalaonBoneHarvester() : base( 0x26BB )
		{
			Name = "Fanalaons Bone Harvester";
			Hue = 137;
			Weight = 3.0;

			Attributes.BonusStr = 50;
			Attributes.BonusDex = 50;
			Attributes.BonusInt = 50;
			Attributes.AttackChance = 75;
			Attributes.BonusHits = 30;
			Attributes.CastRecovery = 50;
			Attributes.CastSpeed = 50;
			Attributes.DefendChance = 20;
			Attributes.Luck = 30;
			Attributes.ReflectPhysical = 30;
		}

		public FanalaonBoneHarvester( Serial serial ) : base( serial )
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