using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class GenericSellInfo : IShopSellInfo
	{
		private Hashtable m_Table = new Hashtable();
		private Type[] m_Types;

		public GenericSellInfo()
		{
		}

		public void Add( Type type, int price )
		{
			m_Table[type] = price;
			m_Types = null;
		}

		public int GetSellPriceFor( Item item )
		{
			int price = (int)m_Table[item.GetType()];

			if ( item is BaseArmor )
			{
				BaseArmor armor = (BaseArmor)item;

				if ( armor.Quality == ArmorQuality.Low )
					price = (int)( price * 0.60 );
				else if ( armor.Quality == ArmorQuality.Exceptional )
					price = (int)( price * 1.25 );

				/* Lines added to make Colored Armor and Weapons Sell at different prices */
				switch ( armor.Resource )
					{
						case CraftResource.DullCopper: price = (int)( price * 2.5 ); break;
						case CraftResource.ShadowIron: price = (int)( price * 3 ); break;
						case CraftResource.Copper: price = (int)( price * 3.5 ); break;
						case CraftResource.Bronze: price = (int)( price * 4 ); break;
						case CraftResource.Gold: price = (int)( price * 4.5 ); break;
						case CraftResource.Agapite: price = (int)( price * 5 ); break;
						case CraftResource.Verite: price = (int)( price * 5.5 ); break;
						case CraftResource.Valorite: price = (int)( price * 6 ); break;
						case CraftResource.Silver: price = (int)( price * 6.5 ); break;
						case CraftResource.Platinum: price = (int)( price * 7 ); break;
						case CraftResource.Mythril: price = (int)( price * 7.5 ); break;
						case CraftResource.Obsidian: price = (int)( price * 8 ); break;
						case CraftResource.Jade: price = (int)( price * 8.5 ); break;
						case CraftResource.Moonstone: price = (int)( price * 9 ); break;
						case CraftResource.Sunstone: price = (int)( price * 9.5 ); break;
						case CraftResource.Bloodstone: price = (int)( price * 10 ); break;
					}
				/* End of Changes */ 
				
				price += 100 * (int)armor.Durability;

				price += 100 * (int)armor.ProtectionLevel;

				if ( price < 1 )
					price = 1;
			}

			else if ( item is BaseWeapon )
			{
				BaseWeapon weapon = (BaseWeapon)item;

				if ( weapon.Quality == WeaponQuality.Low )
					price = (int)( price * 0.60 );
				else if ( weapon.Quality == WeaponQuality.Exceptional )
					price = (int)( price * 1.25 );

                /* Lines added to make Colored Armor and Weapons Sell at different prices */
                switch ( weapon.Resource )
                    {
                        case CraftResource.DullCopper: price = (int)( price * 2.5 ); break;
			case CraftResource.ShadowIron: price = (int)( price * 3 ); break;
			case CraftResource.Copper: price = (int)( price * 3.5 ); break;
			case CraftResource.Bronze: price = (int)( price * 4 ); break;
			case CraftResource.Gold: price = (int)( price * 4.5 ); break;
			case CraftResource.Agapite: price = (int)( price * 5 ); break;
			case CraftResource.Verite: price = (int)( price * 5.5 ); break;
			case CraftResource.Valorite: price = (int)( price * 6 ); break;
			case CraftResource.Silver: price = (int)( price * 6.5 ); break;
			case CraftResource.Platinum: price = (int)( price * 7 ); break;
			case CraftResource.Mythril: price = (int)( price * 7.5 ); break;
			case CraftResource.Obsidian: price = (int)( price * 8 ); break;
			case CraftResource.Jade: price = (int)( price * 8.5 ); break;
			case CraftResource.Moonstone: price = (int)( price * 9 ); break;
			case CraftResource.Sunstone: price = (int)( price * 9.5 ); break;
			case CraftResource.Bloodstone: price = (int)( price * 10 ); break;
                    }
                /* End of Changes */
                
				price += 100 * (int)weapon.DurabilityLevel;

				price += 100 * (int)weapon.DamageLevel;

				if ( price < 1 )
					price = 1;
			}
			else if ( item is BaseBeverage )
			{
				int price1 = price, price2 = price;

				if ( item is Pitcher )
				{ price1 = 3; price2 = 5; }
				else if ( item is BeverageBottle )
				{ price1 = 3; price2 = 3; }
				else if ( item is Jug )
				{ price1 = 6; price2 = 6; }

				BaseBeverage bev = (BaseBeverage)item;

				if ( bev.IsEmpty || bev.Content == BeverageType.Milk )
					price = price1;
				else
					price = price2;
			}

			return price;
		}

		public int GetBuyPriceFor( Item item )
		{
			return (int)( 1.90 * GetSellPriceFor( item ) );
		}

		public Type[] Types
		{
			get
			{
				if ( m_Types == null )
				{
					m_Types = new Type[m_Table.Keys.Count];
					m_Table.Keys.CopyTo( m_Types, 0 );
				}

				return m_Types;
			}
		}

		public string GetNameFor( Item item )
		{
			if ( item.Name != null )
				return item.Name;
			else
				return item.LabelNumber.ToString();
		}

		public bool IsSellable( Item item )
		{
			

			return IsInList( item.GetType() );
		}
	 
		public bool IsResellable( Item item )
		{
			

			return IsInList( item.GetType() );
		}

		public bool IsInList( Type type )
		{
			Object o = m_Table[type];

			if ( o == null )
				return false;
			else
				return true;
		}
	}
}
