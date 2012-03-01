using System;
using Server;

namespace Server.Items
{
	public class WyrmSoulBow : CompositeBow 
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

		public override int AosMinDamage{ get{ return 18; } }
		public override int AosMaxDamage{ get{ return 22; } }
		public override int AosSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public WyrmSoulBow()
		{
			Weight = 5.0;
            		Name = "a Wyrm Soul's Bow";
            		Hue = 1154;
                         
			WeaponAttributes.HitLightning = 100;

			Attributes.SpellChanneling = 1;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 30;
			Attributes.Luck = 200;

			DexRequirement = 35;

			LootType = LootType.Blessed;
		}

		public WyrmSoulBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}