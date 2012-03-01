using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13B2, 0x13B1 )]
	public class XerianBow : BaseRanged
	{
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 90; } }
		public override int AosMinDamage{ get{ return 160; } }
		public override int AosMaxDamage{ get{ return 380; } }
		public override int AosSpeed{ get{ return 950; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 9; } }
		public override int OldMaxDamage{ get{ return 41; } }
		public override int OldSpeed{ get{ return 20; } }

		public override int DefMaxRange{ get{ return 20; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public XerianBow() : base( 0x13B2 )
		{
			Name = "Xerians Bow";
			Hue = 104;
			Weight = 20.0;
			Layer = Layer.OneHanded;
			
			Attributes.AttackChance = 30;
			Attributes.BonusDex = 50;
			Attributes.BonusHits = 50;
			Attributes.BonusInt = 100;
			Attributes.BonusMana = 50;
			Attributes.BonusStam = 50;
			Attributes.BonusStr = 50;
			Attributes.CastRecovery = 20;
			Attributes.CastSpeed = 100;
			Attributes.DefendChance = 50;
			Attributes.EnhancePotions = 40;
			Attributes.LowerManaCost = 50;
			Attributes.LowerRegCost = 5;
			Attributes.Luck = 10;
			Attributes.ReflectPhysical = 50;
			Attributes.RegenHits = 50;
			Attributes.RegenMana = 50;
			Attributes.RegenStam = 50;
			Attributes.WeaponDamage = 100;
			Attributes.WeaponSpeed = 50;
		}

		public XerianBow( Serial serial ) : base( serial )
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

			if ( Weight == 7.0 )
				Weight = 6.0;
		}
	}
}