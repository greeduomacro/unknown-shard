//Created with Maraks Script Creator 4
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class WaterBlade : VikingSword
  {
public override int ArtifactRarity{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 15; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 200; } }

      [Constructable]
		public WaterBlade()
		{
			Weight = 1;
          Name = "Water Blade";
          Hue = 2999;
      WeaponAttributes.DurabilityBonus = 1;
      WeaponAttributes.HitColdArea = 1;
      WeaponAttributes.HitEnergyArea = 1;
      WeaponAttributes.HitLeechMana = 1;
      WeaponAttributes.LowerStatReq = 15;
      WeaponAttributes.MageWeapon = 1;
      WeaponAttributes.ResistColdBonus = 25;
      WeaponAttributes.ResistEnergyBonus = 25;
      WeaponAttributes.ResistPhysicalBonus = 2;
      WeaponAttributes.ResistPoisonBonus = 2;
      WeaponAttributes.ResistFireBonus = 2;
      WeaponAttributes.SelfRepair = 1;
      Attributes.AttackChance = 10;
      Attributes.BonusDex = 2;
      Attributes.BonusHits = 2;
      Attributes.BonusInt = 2;
      Attributes.BonusMana = 2;
      Attributes.BonusStam = 2;
      Attributes.DefendChance = 1;
      Attributes.LowerManaCost = 1;
      Attributes.LowerRegCost = 1;
      Attributes.Luck = 1;
      Attributes.ReflectPhysical = 2;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 2;
      Attributes.SpellChanneling = 1;
      Attributes.WeaponDamage = 12;
      Attributes.WeaponSpeed = 20;
      Attributes.BonusMana = 2;
      LootType = LootType.Blessed;
     Slayer = SlayerName.WaterDissipation ;
		}

		public WaterBlade( Serial serial ) : base( serial )
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
