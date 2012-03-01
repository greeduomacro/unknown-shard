using System;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.SpellCrafting.Items;
using Server.SpellCrafting;

namespace Server.Items
{
	public class TreasureMessageChest : WoodenChest
	{
		[Constructable]
		public TreasureMessageChest() : this( 1200, 2000 ) { }

		[Constructable]
		public TreasureMessageChest( int low, int high ) : this( Utility.RandomMinMax( low < 15 ? 15 : low, high < low ? low : high ) ) { }

		[Constructable]
		public TreasureMessageChest( int amount ) : base()
		{
			Weight = (amount / 100) + 105;
			switch (Utility.RandomMinMax( 1, 10 ))
			{
				case 1: default: Name = "Chest"; break;
				case 2: Name = "Metal Chest"; break;
				case 3: Name = "Paragon Chest"; break;
				case 4: Name = "Treasure Chest"; break;
				case 5: Name = "Ingot Box"; break;
				case 6: Name = "Loot Chest"; break;
				case 7: Name = "Prize Chest"; break;
				case 8: Name = "Rare Chest"; break;
				case 9: Name = "Tool Box"; break;
				case 10: Name = "Resource Box"; break;
			}
			Hue = Utility.RandomMinMax( 2366, 2371 );

			switch ( Utility.Random( 6 ) )
			{
				case 0: default: TrapType = TrapType.None; break;
				case 1: TrapType = TrapType.PoisonTrap; break;
				case 2: TrapType = TrapType.DartTrap; break;
				case 3: TrapType = TrapType.MagicTrap; break;
				case 4: TrapType = TrapType.ExplosionTrap; break;
			}

			TrapPower = (int)(Utility.RandomMinMax( amount/40, amount /20));
					
			Locked = true;
			LockLevel = (int)(Utility.RandomMinMax( amount/40, amount /20));
			MaxLockLevel = LockLevel + 25;

			DropItem( new Gold( amount ) );

			int amountloot = Utility.RandomMinMax( (int)((amount /100) + 5) , (int)((amount /100) + 15) );
			int amountloot2 = (int)((amount /200));
			if (amountloot2 > 10 ) amountloot2 = 10;
			for ( int i = 0; i < amountloot; ++i )
			{
				if( Utility.RandomDouble() < .25 )
				{
					Item item = Loot.RandomGem();
					item.Amount = Utility.RandomMinMax( amountloot - 3, amountloot + 5 );
					this.DropItem( item );
				}

				if( Utility.RandomDouble() < .25 )
				{
					Item item = Loot.RandomPossibleReagent();
					item.Amount = Utility.RandomMinMax( amountloot - 3, amountloot + 5 );
					this.DropItem( item );
				}

				if( Utility.RandomDouble() < .25 )
				{
					this.DropItem( Loot.RandomScroll( 0, 63, SpellbookType.Regular ) );
				}

				if( Utility.RandomDouble() < .10 )
				{
					Item item;
					item = Loot.RandomArmorOrShieldOrWeaponOrJewelry();

					int attributeCount = (int)(amountloot2/2);
					if ( attributeCount < 1) attributeCount = 1;
					if ( attributeCount > 5) attributeCount = 5;
					int min = amountloot2 * 5;
					int max = amountloot2 * 10;
					if (max > 100) max = 100;

					if (item is BaseWeapon)
					{
						BaseWeapon weapon = (BaseWeapon)item;
						BaseRunicTool.ApplyAttributesTo(weapon, attributeCount, min, max);
						this.DropItem(item);
					}
					else if (item is BaseArmor)
					{
						BaseArmor armor = (BaseArmor)item;
						BaseRunicTool.ApplyAttributesTo(armor, attributeCount, min, max);
						this.DropItem(item);
					}
					else if (item is BaseJewel)
					{
						BaseRunicTool.ApplyAttributesTo((BaseJewel)item, attributeCount, min, max);
						this.DropItem(item);
					}
					else if (item is BaseHat)
					{
						BaseRunicTool.ApplyAttributesTo((BaseHat)item, attributeCount, min, max);
						this.DropItem(item);
					}
					else if( item != null )
						this.DropItem( item );
				}
			}
		}

		public TreasureMessageChest( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
}