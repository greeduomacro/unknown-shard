using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1407, 0x1406 )]
	public class MarinesWarMace : BaseBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

		public override int AosStrengthReq{ get{ return 80; } }
		public override int AosMinDamage{ get{ return 600; } }
		public override int AosMaxDamage{ get{ return 620; } }
		public override int AosSpeed{ get{ return 160; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 30; } }
		public override int OldSpeed{ get{ return 32; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		[Constructable]
		public MarinesWarMace() : base( 0x1407 )
		{
			
			Name = "Marines War Mace";
			Hue = 137;
			Weight = 5.0;

			Attributes.BonusStr = 50;
			Attributes.BonusDex = 50;
			Attributes.BonusInt = 50;
			Attributes.AttackChance = 75;
			Attributes.BonusHits = 30;
			Attributes.CastRecovery = 50;
			Attributes.CastSpeed = 50;
			Attributes.DefendChance = 20;
			Attributes.Luck = 40;
			Attributes.ReflectPhysical = 30;
		}

		public MarinesWarMace( Serial serial ) : base( serial )
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