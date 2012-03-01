using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26BE, 0x26C8 )]
	public class BeastPike : BaseSpear
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 900; } }
		public override int AosMaxDamage{ get{ return 1200; } }
		public override int AosSpeed{ get{ return 370; } }

		public override int OldStrengthReq{ get{ return 50; } }
		public override int OldMinDamage{ get{ return 14; } }
		public override int OldMaxDamage{ get{ return 16; } }
		public override int OldSpeed{ get{ return 37; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		[Constructable]
		public BeastPike() : base( 0x26BE )
		{
			
			Name = "Beasts Pike";
			Hue = 137;
			Weight = 8.0;

			Attributes.BonusStr = 25;
			Attributes.BonusDex = 25;
			Attributes.BonusInt = 25;
			Attributes.AttackChance = 75;
			Attributes.BonusHits = 50;
			Attributes.CastRecovery = 50;
			Attributes.CastSpeed = 50;
			Attributes.DefendChance = 40;
			Attributes.Luck = 60;
			Attributes.ReflectPhysical = 70;
		}

		public BeastPike( Serial serial ) : base( serial )
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