//Created with Maraks Script Creator 4
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class PickaxeoftheCHICKENPAW : Pickaxe
  {
		public override int OldMinDamage{ get{ return 1; } }
		public override int AosMinDamage{ get{ return 1; } }
		public override int OldMaxDamage{ get{ return 2; } }
		public override int AosMaxDamage{ get{ return 2; } }

		public override int InitMinHits{ get{ return 400; } }
		public override int InitMaxHits{ get{ return 800; } }

      [Constructable]
		public PickaxeoftheCHICKENPAW()
		{
			Weight = 1;
          Name = "Pickaxe of the CHICKEN PAW!!!";
          Hue = 1971;
	Attributes.BonusStr = 400;
	Attributes.BonusStam = 400;
	Attributes.RegenStam = 50;
      WeaponAttributes.DurabilityBonus = 10;
      WeaponAttributes.HitFireArea = 10;
      WeaponAttributes.LowerStatReq = 50;
      WeaponAttributes.SelfRepair = 1;
      Attributes.DefendChance = 10;
      Attributes.Luck = 12;
      Attributes.NightSight = 1;
      Attributes.WeaponDamage = 13;
      Attributes.WeaponSpeed = 2;
      LootType = LootType.Blessed;
     Slayer = SlayerName.Exorcism ;
		}

		public PickaxeoftheCHICKENPAW( Serial serial ) : base( serial )
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
