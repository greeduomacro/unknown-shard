using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1405, 0x1404 )]
	public class FreshsWarFork : BaseSpear
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 220; } }
		public override int AosMaxDamage{ get{ return 300; } }
		public override int AosSpeed{ get{ return 4300; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 4; } }
		public override int OldMaxDamage{ get{ return 32; } }
		public override int OldSpeed{ get{ return 45; } }

		public override int DefHitSound{ get{ return 0x236; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public FreshsWarFork() : base( 0x1405 )
		{
			
			Name = "Freshs War Fork";
			Hue = 137;
			Weight = 3.0;

			Attributes.BonusStr = 10;
			Attributes.BonusDex = 50;
			Attributes.BonusInt = 10;
			Attributes.AttackChance = 75;
			Attributes.BonusHits = 30;
			Attributes.CastRecovery = 50;
			Attributes.CastSpeed = 50;
			Attributes.DefendChance = 60;
			Attributes.Luck = 50;
			Attributes.ReflectPhysical = 50;
		}

		public FreshsWarFork( Serial serial ) : base( serial )
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