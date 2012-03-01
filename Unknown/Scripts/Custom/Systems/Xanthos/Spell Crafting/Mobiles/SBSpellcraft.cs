#region AuthorHeader
//
//	SpellCrafting version 3.0, by Xanthos and TheOutkastDev
//
//  Based on original ideas and code by TheOutkastDev
//
#endregion AuthorHeader
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SpellCrafting.Items;

namespace Server.SpellCrafting.Mobiles
{
	public class SBSpellCraft : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSpellCraft()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Strength Bonus Craft", typeof( BonusStrengthJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Dexterity Bonus Craft", typeof( BonusDexterityJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Intelligence Bonus Craft", typeof( BonusIntelligenceJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Point Bonus Craft", typeof( BonusHitsJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Stamina Bonus Craft", typeof( BonusStaminaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Mana Bonus Craft", typeof( BonusManaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Physical Resist Craft", typeof( PhysicalResistJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Fire Resist Craft", typeof( FireResistJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Cold Resist Craft", typeof( ColdResistJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Poison Resist Craft", typeof( PoisonResistJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Energy Resist Craft", typeof( EnergyResistJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "HP Regenation Craft", typeof( RegenerateHitsJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Mana Regenation Craft", typeof( RegenerateManaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Stamina Regeneration Craft", typeof( RegenerateStaminaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Faster Cast Recovery Craft", typeof( CastRecoveryJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Faster Cast Speed Craft", typeof( CastSpeedJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Lower Mana Cost Craft", typeof( LowerManaCostJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Lower Reagent Cost Craft", typeof( LowerReagentCostJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Mage Armor Craft", typeof( MageArmorJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Mage Weapon Craft", typeof( MageWeaponJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Spell Channeling Craft", typeof( SpellChannelingJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Spell Damage Increase Craft", typeof( SpellDamageJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Cold Area Craft", typeof( HitColdAreaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Energy Area Craft", typeof( HitEnergyAreaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Fire Area Craft", typeof( HitFireAreaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Physical Area Craft", typeof( HitPhysicalAreaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Poison Area Craft", typeof( HitPoisonAreaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Dispel Craft", typeof( HitDispelJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Fireball Craft", typeof( HitFireballJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Harm Craft", typeof( HitHarmJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Lightning Craft", typeof( HitLightningJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Magic Arrow Craft", typeof( HitMagicArrowJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Lower Attack Craft", typeof( HitLowerAttackJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Lower Defence Craft", typeof( HitLowerDefendJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Leech Hits Craft", typeof( HitLeechHitsJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Leech Mana Craft", typeof( HitLeechManaJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Leech Stamina Craft", typeof( HitLeechStamJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Use Best Weapon Skill Craft", typeof( UseBestSkillJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Weapon Damage Increase Craft", typeof( WeaponDamageJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Swing Speed Increase Craft", typeof( WeaponSpeedJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Hit Chance Increase Craft", typeof( AttackChanceJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Defense Chance Increase Craft", typeof( DefendChanceJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Enhance Potions Craft", typeof( EnhancePotionsJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Lower Stat Requirements Craft", typeof( LowerStatRequirementsJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Luck Craft", typeof( LuckJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Reflect Physical Craft", typeof( ReflectPhysicalJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Self Repair Craft", typeof( SelfRepairJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Night Sight Craft", typeof( NightSightJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Slayer Craft", typeof( SlayerJewel ), 15000, 5, 0x1EA7, 1161 ) );
				Add( new GenericBuyInfo( "Durability Craft", typeof( DurabilityJewel ), 15000, 5, 0x1EA7, 1161 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BonusStrengthJewel ), 7500 );
				Add( typeof( BonusDexterityJewel ), 7500 );
				Add( typeof( BonusIntelligenceJewel ), 7500 );
				Add( typeof( BonusHitsJewel ), 7500 );
				Add( typeof( BonusStaminaJewel ), 7500 );
				Add( typeof( BonusManaJewel ), 7500 );
				Add( typeof( PhysicalResistJewel ), 7500 );
				Add( typeof( FireResistJewel ), 7500 );
				Add( typeof( ColdResistJewel ), 7500 );
				Add( typeof( PoisonResistJewel ), 7500 );
				Add( typeof( EnergyResistJewel ), 7500 );
				Add( typeof( RegenerateHitsJewel ), 7500 );
				Add( typeof( RegenerateManaJewel ), 7500 );
				Add( typeof( RegenerateStaminaJewel ), 7500 );
				Add( typeof( CastRecoveryJewel ), 7500 );
				Add( typeof( CastSpeedJewel ), 7500 );
				Add( typeof( LowerManaCostJewel ), 7500 );
				Add( typeof( LowerReagentCostJewel ), 7500 );
				Add( typeof( MageArmorJewel ), 7500 );
				Add( typeof( MageWeaponJewel ), 7500 );
				Add( typeof( SpellChannelingJewel ), 7500 );
				Add( typeof( SpellDamageJewel ), 7500 );
				Add( typeof( HitColdAreaJewel ), 7500 );
				Add( typeof( HitEnergyAreaJewel ), 7500 );
				Add( typeof( HitFireAreaJewel ), 7500 );
				Add( typeof( HitPhysicalAreaJewel ), 7500 );
				Add( typeof( HitPoisonAreaJewel ), 7500 );
				Add( typeof( HitDispelJewel ), 7500 );
				Add( typeof( HitFireballJewel ), 7500 );
				Add( typeof( HitHarmJewel ), 7500 );
				Add( typeof( HitLightningJewel ), 7500 );
				Add( typeof( HitMagicArrowJewel ), 7500 );
				Add( typeof( HitLowerAttackJewel ), 7500 );
				Add( typeof( HitLowerDefendJewel ), 7500 );
				Add( typeof( HitLeechHitsJewel ), 7500 );
				Add( typeof( HitLeechManaJewel ), 7500 );
				Add( typeof( HitLeechStamJewel ), 7500 );
				Add( typeof( UseBestSkillJewel ), 7500 );
				Add( typeof( WeaponDamageJewel ), 7500 );
				Add( typeof( WeaponSpeedJewel ), 7500 );
				Add( typeof( AttackChanceJewel ), 7500 );
				Add( typeof( DefendChanceJewel ), 7500 );
				Add( typeof( EnhancePotionsJewel ), 7500 );
				Add( typeof( LowerStatRequirementsJewel ), 7500 );
				Add( typeof( LuckJewel ), 7500 );
				Add( typeof( ReflectPhysicalJewel ), 7500 );
				Add( typeof( SelfRepairJewel ), 7500 );
				Add( typeof( NightSightJewel ), 7500 );
				Add( typeof( SlayerJewel ), 7500 );
				Add( typeof( DurabilityJewel ), 7500 );
			}
		}
	}
}