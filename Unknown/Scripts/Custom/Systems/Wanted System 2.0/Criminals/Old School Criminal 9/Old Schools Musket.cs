using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13FD, 0x13FC )]
	public class OldschoolsMusket : BaseRanged
	{
		public override int EffectID{ get{ return 0x36B0; } }
		public override int DefHitSound{ get{ return 0x11D; } }
		public override int DefMissSound{ get{ return 0x11D; } }
		public override Type AmmoType{ get{ return typeof( BallsofFire ); } }
		public override Item Ammo{ get{ return new BallsofFire(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.MovingShot; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

		public override int AosStrengthReq{ get{ return 90; } }
		public override int AosMinDamage{ get{ return 120; } }
		public override int AosMaxDamage{ get{ return 150; } }
		public override int AosSpeed{ get{ return 1000; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 11; } }
		public override int OldMaxDamage{ get{ return 56; } }
		public override int OldSpeed{ get{ return 100; } }

		public override int DefMaxRange{ get{ return 80; } }

		public override int InitMinHits{ get{ return 310; } }
		public override int InitMaxHits{ get{ return 500; } }

		private SkillMod m_SkillMod0;
        	private SkillMod m_SkillMod1;

		[Constructable]
		public OldschoolsMusket() : base( 0xDF0 )
		{
			Weight = 6.0;
			Layer = Layer.TwoHanded;
			Hue = 2406;
			Name = "Old schools Musket";
			LootType = LootType.Blessed;
			
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

		public OldschoolsMusket( Serial serial ) : base( serial )
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