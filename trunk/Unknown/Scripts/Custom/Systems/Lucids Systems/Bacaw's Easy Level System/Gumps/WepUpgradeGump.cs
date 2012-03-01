////////////////////////////  ///////////////////////
//// Created by Andyboi  //  // and Lucid Nagual ////
//////////////////////////  /////////////////////////
////   DO NOT REMOVE   //  // Easy Level System  ////
////   THIS HEADER!!  //  //   Version [2].0.1   ////
///////////////////////  ////////////////////////////
using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.ACC.CM;


namespace Server.Gumps
{
	public class WepUpgradeGump : Gump
	{
		private Item m_wep;
		private int m_cap2;

		public WepUpgradeGump( Mobile owner ) : base( 50,50 )
		{
			Item wep = owner.FindItemOnLayer( Layer.FirstValid );
			Item weps = owner.FindItemOnLayer( Layer.TwoHanded );

			if ( wep !=null && weps == null )
			{
				if ( wep is BaseWeapon )
				{
					if ( ( ( BaseWeapon )wep ).Identified == true )
					{
						m_wep = wep;
						BaseWeapon wa = m_wep as BaseWeapon;

						AddPage( 1 );
						this.Closable = false;

						AddBackground( 0, 0, 250, 300, 9270 );
						AddLabel( 65, 15, 1153, "Weapon Upgrades" );

						AddBackground( 20, 50, 200, 30, 9350 );
						AddLabel( 25, 55, 1150, "Name :" );
						AddTextEntry( 75, 55, 130, 20, 0, 1, string.Format( "{0}", m_wep.Name ) );
						AddButton( 220, 55, 1896, 1895, 1, GumpButtonType.Reply, 0 );
						AddBackground( 20, 100, 200, 30, 9350 );
						AddLabel( 25, 105, 1150, "Weapon Attributes" );
						AddButton( 185, 105, 4007, 4006, 0, GumpButtonType.Page, 2 );
						AddBackground( 20, 150, 200, 30, 9350 );
						AddLabel( 25, 155, 1150, "Attributes" );
						AddButton( 185, 155, 4007, 4006, 0, GumpButtonType.Page, 4 );
						AddHtml( 20, 200, 200, 45, "WARNING! If you press OK you cannot re-modifying this weapon!", true, false );
						AddLabel( 110, 260, 102, "Are you sure?" );
						AddButton( 205, 260, 4023, 4024, 0, GumpButtonType.Reply, 0 );

						//--<< Weapon Attributes Pg.2 >>
						
						AddPage( 2 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddBackground( 60, 20, 180, 30, 9300 );
						AddLabel( 85, 25, 1153, "Weapon Attributes" );

						AddLabel( 50, 50, 1150, "Attribute" );
						AddLabel( 200, 50, 1150, "Value" );
						AddBackground( 40, 70, 220, 300, 3000 );
						AddImageTiled( 190, 70, 2, 300, 10005 );
						for ( int y = 71; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 10; ++i )
							AddButton( 260, (30 * i) + 75 , 5601, 5605, i + 2, GumpButtonType.Reply, 0 );
						AddLabel( 45, 75, 0, "Durability Bonus" );
						AddLabel( 200, 75, 0, "" + wa.WeaponAttributes.DurabilityBonus );
						AddLabel( 45, 105, 0, "Hit Cold Area" );
						AddLabel( 200, 105, 0, "" + wa.WeaponAttributes.HitColdArea );
						AddLabel( 45, 135, 0, "Hit Dispel" );
						AddLabel( 200, 135, 0, "" + wa.WeaponAttributes.HitDispel );
						AddLabel( 45, 165, 0, "Hit Energy Area" );
						AddLabel( 200, 165, 0, "" + wa.WeaponAttributes.HitEnergyArea );
						AddLabel( 45, 195, 0, "Hit Fire Area" );
						AddLabel( 200, 195, 0, "" + wa.WeaponAttributes.HitFireArea );
						AddLabel( 45, 225, 0, "Hit Fireball" );
						AddLabel( 200, 225, 0, "" + wa.WeaponAttributes.HitFireball );
						AddLabel( 45, 255, 0, "Hit Harm" );
						AddLabel( 200, 255, 0, "" + wa.WeaponAttributes.HitHarm );
						AddLabel( 45, 285, 0, "Hit Leech Hits" );
						AddLabel( 200, 285, 0, "" + wa.WeaponAttributes.HitLeechHits );
						AddLabel( 45, 315, 0, "Hit Leech Mana" );
						AddLabel( 200, 315, 0, "" + wa.WeaponAttributes.HitLeechMana );
						AddLabel( 45, 345, 0, "Hit Leech Stam" );
						AddLabel( 200, 345, 0, "" + wa.WeaponAttributes.HitLeechStam );

						AddLabel( 190, 380, 1150, "Next Page" );
						AddButton( 260, 380, 9762, 9763, 0, GumpButtonType.Page, 3 );
						AddButton( 20, 385, 5223, 5223, 0, GumpButtonType.Page, 1 );
						AddLabel( 45, 385, 102, "Back" );
						
						//--<< Wep Attributes Pg.3 >>

						AddPage( 3 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddLabel( 50, 20, 1150, "Attribute" );
						AddLabel( 200, 20, 1150, "Value" );

						AddBackground( 40, 40, 220, 330, 3000 );
						AddImageTiled( 190, 40, 2, 330, 10005 );
						for ( int y = 41; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 11; ++i )
							AddButton( 260, (30 * i) + 45 , 5601, 5605, i + 12, GumpButtonType.Reply, 0 );
						AddLabel( 45, 45, 0, "Hit Lightning" );
						AddLabel( 200, 45, 0, ""+wa.WeaponAttributes.HitLightning );
						AddLabel( 45, 75, 0, "Hit Lower Attack" );
						AddLabel( 200, 75, 0, ""+wa.WeaponAttributes.HitLowerAttack );
						AddLabel( 45, 105, 0, "Hit Lower Defend" );
						AddLabel( 200, 105, 0, ""+wa.WeaponAttributes.HitLowerDefend );
						AddLabel( 45, 135, 0, "Hit Magic Arrow" );
						AddLabel( 200, 135, 0, ""+wa.WeaponAttributes.HitMagicArrow );
						AddLabel( 45, 165, 0, "Hit Physical Area" );
						AddLabel( 200, 165, 0, ""+wa.WeaponAttributes.HitPhysicalArea );
						AddLabel( 45, 195, 0, "Hit Poison Area" );
						AddLabel( 200, 195, 0, ""+wa.WeaponAttributes.HitPoisonArea );
						AddLabel( 45, 225, 0, "Resist Cold Bonus" );
						AddLabel( 200, 225, 0, ""+wa.WeaponAttributes.ResistColdBonus );
						AddLabel( 45, 255, 0, "Resist Energy Bonus" );
						AddLabel( 200, 255, 0, ""+wa.WeaponAttributes.ResistEnergyBonus );
						AddLabel( 45, 285, 0, "Resist Fire Bonus" );
						AddLabel( 200, 285, 0, ""+wa.WeaponAttributes.ResistFireBonus );
						AddLabel( 45, 315, 0, "Resist Poison Bonus" );
						AddLabel( 200, 315, 0, ""+wa.WeaponAttributes.ResistPoisonBonus );
						AddLabel( 45, 345, 0, "Self Repair" );
						AddLabel( 200, 345, 0, ""+wa.WeaponAttributes.SelfRepair );

						AddButton( 20, 385, 9706, 9707, 0, GumpButtonType.Page, 2 );
						AddLabel( 45, 385, 1150, "Last Page" );
						
						//--<< Attributes Pg.4 >>

						AddPage( 4 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddBackground( 60, 20, 180, 30, 9300 );
						AddLabel( 115, 25, 1153, "Attributes" );

						AddLabel( 50, 50, 1150, "Attribute" );
						AddLabel( 200, 50, 1150, "Value" );
						AddBackground( 40, 70, 220, 300, 3000 );
						AddImageTiled( 190, 70, 2, 300, 10005 );
						for ( int y = 71; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 10; ++i )
							AddButton( 260, (30 * i) + 75 , 5601, 5605, i + 23, GumpButtonType.Reply, 0 );
						AddLabel( 45, 75, 0, "Attack Chance" );
						AddLabel( 200, 75, 0, "" + wa.Attributes.AttackChance );
						AddLabel( 45, 105, 0, "Bonus Dex" );
						AddLabel( 200, 105, 0, "" + wa.Attributes.BonusDex );
						AddLabel( 45, 135, 0, "Bonus Hits" );
						AddLabel( 200, 135, 0, "" + wa.Attributes.BonusHits );
						AddLabel( 45, 165, 0, "Bonus Int" );
						AddLabel( 200, 165, 0, "" + wa.Attributes.BonusInt );
						AddLabel( 45, 195, 0, "Bonus Mana" );
						AddLabel( 200, 195, 0, "" + wa.Attributes.BonusMana );
						AddLabel( 45, 225, 0, "BonusStam" );
						AddLabel( 200, 225, 0, "" + wa.Attributes.BonusStam );
						AddLabel( 45, 255, 0, "Bonus Str" );
						AddLabel( 200, 255, 0, "" + wa.Attributes.BonusStr );
						AddLabel( 45, 285, 0, "Cast Recovery" );
						AddLabel( 200, 285, 0, "" + wa.Attributes.CastRecovery );
						AddLabel( 45, 315, 0, "Cast Speed" );
						AddLabel( 200, 315, 0, "" + wa.Attributes.CastSpeed );
						AddLabel( 45, 345, 0, "Defend Chance" );
						AddLabel( 200, 345, 0, "" + wa.Attributes.DefendChance );

						AddLabel( 190, 380, 1150, "Next Page" );
						AddButton( 260, 380, 9762, 9763, 0, GumpButtonType.Page, 5 );
						AddButton( 20, 385, 5223, 5223, 0, GumpButtonType.Page, 1 );
						AddLabel( 45, 385, 102, "Back" );
						
						//--<< Attributes Pg.5 >>

						AddPage( 5 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddLabel( 50, 20, 1150, "Attribute" );
						AddLabel( 200, 20, 1150, "Value" );

						AddBackground( 40, 40, 220, 330, 3000 );
						AddImageTiled( 190, 40, 2, 330, 10005 );
						for ( int y = 41; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 11; ++i )
							AddButton( 260, (30 * i) + 45 , 5601, 5605, i + 33, GumpButtonType.Reply, 0 );
						AddLabel( 45, 45, 0, "Lower Mana Cost" );
						AddLabel( 200, 45, 0, "" + wa.Attributes.LowerManaCost );
						AddLabel( 45, 75, 0, "Lower Reg Cost" );
						AddLabel( 200, 75, 0, "" + wa.Attributes.LowerRegCost );
						AddLabel( 45, 105, 0, "Luck" );
						AddLabel( 200, 105, 0, "" + wa.Attributes.Luck );
						AddLabel( 45, 135, 0, "Reflect Physical" );
						AddLabel( 200, 135, 0, "" + wa.Attributes.ReflectPhysical );
						AddLabel( 45, 165, 0, "Regen Hits" );
						AddLabel( 200, 165, 0, "" + wa.Attributes.RegenHits );
						AddLabel( 45, 195, 0, "Regen Mana" );
						AddLabel( 200, 195, 0, "" + wa.Attributes.RegenMana );
						AddLabel( 45, 225, 0, "Regen Stam" );
						AddLabel( 200, 225, 0, "" + wa.Attributes.RegenStam );
						AddLabel( 45, 255, 0, "Spell Channeling" );
						AddLabel( 200, 255, 0, "" + wa.Attributes.SpellChanneling );
						AddLabel( 45, 285, 0, "Spell Damage" );
						AddLabel( 200, 285, 0, "" + wa.Attributes.SpellDamage );
						AddLabel( 45, 315, 0, "Weapon Damage" );
						AddLabel( 200, 315, 0, "" + wa.Attributes.WeaponDamage );
						AddLabel( 45, 345, 0, "Weapon Speed" );
						AddLabel( 200, 345, 0, "" + wa.Attributes.WeaponSpeed );

						AddButton( 20, 385, 9706, 9707, 0, GumpButtonType.Page, 4 );
						AddLabel( 45, 385, 1150, "Last Page" );
					}
				}
			}
			
			//--<< Two Handed Weapons >>

			else if ( wep == null && weps !=null )
			{
				if( weps is BaseWeapon )
				{
					if( ( ( BaseWeapon )weps ).Identified == true )
					{
						m_wep = weps;
						BaseWeapon wa = weps as BaseWeapon;

						AddPage( 1 );
						this.Closable = false;

						AddBackground( 0, 0, 250, 300, 9270 );
						AddLabel( 65, 15, 1153, "Weapon Upgrades" );

						AddBackground( 20, 50, 200, 30, 9350 );
						AddLabel( 25, 55, 1150, "Name :" );
						AddTextEntry( 75, 55, 130, 20, 0, 1, string.Format( "{0}", m_wep.Name ) );
						AddButton( 220, 55, 1896, 1895, 1, GumpButtonType.Reply, 0 );
						AddBackground( 20, 100, 200, 30, 9350 );
						AddLabel( 25, 105, 1150, "Weapon Attributes" );
						AddButton( 185, 105, 4007, 4006, 0, GumpButtonType.Page, 2 );
						AddBackground( 20, 150, 200, 30, 9350 );
						AddLabel( 25, 155, 1150, "Attributes" );
						AddButton( 185, 155, 4007, 4006, 0, GumpButtonType.Page, 4 );
						AddHtml( 20, 200, 200, 45, "WARNING! If you press Ok you cannot remod this wep!", true, false );
						AddLabel( 110, 260, 102, "Are you sure?" );
						AddButton( 205, 260, 4023, 4024, 0, GumpButtonType.Reply, 0 );

						//--<< Weapon Attributes Pg.2 >>

						AddPage( 2 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddBackground( 60, 20, 180, 30, 9300 );
						AddLabel( 85, 25, 1153, "Weapon Attributes" );

						AddLabel( 50, 50, 1150, "Attribute" );
						AddLabel( 200, 50, 1150, "Value" );
						AddBackground( 40, 70, 220, 300, 3000 );
						AddImageTiled( 190, 70, 2, 300, 10005 );
						for ( int y = 71; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 10; ++i )
							AddButton( 260, (30 * i) + 75 , 5601, 5605, i + 2, GumpButtonType.Reply, 0 );
						AddLabel( 45, 75, 0, "Durability Bonus" );
						AddLabel( 200, 75, 0, ""+wa.WeaponAttributes.DurabilityBonus );
						AddLabel( 45, 105, 0, "Hit Cold Area" );
						AddLabel( 200, 105, 0, ""+wa.WeaponAttributes.HitColdArea );
						AddLabel( 45, 135, 0, "Hit Dispel" );
						AddLabel( 200, 135, 0, ""+wa.WeaponAttributes.HitDispel );
						AddLabel( 45, 165, 0, "Hit Energy Area" );
						AddLabel( 200, 165, 0, ""+wa.WeaponAttributes.HitEnergyArea );
						AddLabel( 45, 195, 0, "Hit Fire Area" );
						AddLabel( 200, 195, 0, ""+wa.WeaponAttributes.HitFireArea );
						AddLabel( 45, 225, 0, "Hit Fireball" );
						AddLabel( 200, 225, 0, ""+wa.WeaponAttributes.HitFireball );
						AddLabel( 45, 255, 0, "Hit Harm" );
						AddLabel( 200, 255, 0, ""+wa.WeaponAttributes.HitHarm );
						AddLabel( 45, 285, 0, "Hit Leech Hits" );
						AddLabel( 200, 285, 0, ""+wa.WeaponAttributes.HitLeechHits );
						AddLabel( 45, 315, 0, "Hit Leech Mana" );
						AddLabel( 200, 315, 0, ""+wa.WeaponAttributes.HitLeechMana );
						AddLabel( 45, 345, 0, "Hit Leech Stam" );
						AddLabel( 200, 345, 0, ""+wa.WeaponAttributes.HitLeechStam );

						AddLabel( 190, 380, 1150, "Next Page" );
						AddButton( 260, 380, 9762, 9763, 0, GumpButtonType.Page, 3 );
						AddButton( 20, 385, 5223, 5223, 0, GumpButtonType.Page, 1 );
						AddLabel( 45, 385, 102, "Back" );
						
						//--<< Weapon Attributes Pg.3 >>

						AddPage( 3 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddLabel( 50, 20, 1150, "Attribute" );
						AddLabel( 200, 20, 1150, "Value" );

						AddBackground( 40, 40, 220, 330, 3000 );
						AddImageTiled( 190, 40, 2, 330, 10005 );
						for ( int y = 41; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 11; ++i )
							AddButton( 260, (30 * i) + 45 , 5601, 5605, i + 12, GumpButtonType.Reply, 0 );
						AddLabel( 45, 45, 0, "Hit Lightning" );
						AddLabel( 200, 45, 0, ""+wa.WeaponAttributes.HitLightning );
						AddLabel( 45, 75, 0, "Hit Lower Attack" );
						AddLabel( 200, 75, 0, ""+wa.WeaponAttributes.HitLowerAttack );
						AddLabel( 45, 105, 0, "Hit Lower Defend" );
						AddLabel( 200, 105, 0, ""+wa.WeaponAttributes.HitLowerDefend );
						AddLabel( 45, 135, 0, "Hit Magic Arrow" );
						AddLabel( 200, 135, 0, ""+wa.WeaponAttributes.HitMagicArrow );
						AddLabel( 45, 165, 0, "Hit Physical Area" );
						AddLabel( 200, 165, 0, ""+wa.WeaponAttributes.HitPhysicalArea );
						AddLabel( 45, 195, 0, "Hit Poison Area" );
						AddLabel( 200, 195, 0, ""+wa.WeaponAttributes.HitPoisonArea );
						AddLabel( 45, 225, 0, "Resist Cold Bonus" );
						AddLabel( 200, 225, 0, ""+wa.WeaponAttributes.ResistColdBonus );
						AddLabel( 45, 255, 0, "Resist Energy Bonus" );
						AddLabel( 200, 255, 0, ""+wa.WeaponAttributes.ResistEnergyBonus );
						AddLabel( 45, 285, 0, "Resist Fire Bonus" );
						AddLabel( 200, 285, 0, ""+wa.WeaponAttributes.ResistFireBonus );
						AddLabel( 45, 315, 0, "Resist Poison Bonus" );
						AddLabel( 200, 315, 0, ""+wa.WeaponAttributes.ResistPoisonBonus );
						AddLabel( 45, 345, 0, "Self Repair" );
						AddLabel( 200, 345, 0, ""+wa.WeaponAttributes.SelfRepair );

						AddButton( 20, 385, 9706, 9707, 0, GumpButtonType.Page, 2 );
						AddLabel( 45, 385, 1150, "Last Page" );
						
						//--<< Attributes Pg.4 >>

						AddPage( 4 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddBackground( 60, 20, 180, 30, 9300 );
						AddLabel( 115, 25, 1153, "Attributes" );

						AddLabel( 50, 50, 1150, "Attribute" );
						AddLabel( 200, 50, 1150, "Value" );
						AddBackground( 40, 70, 220, 300, 3000 );
						AddImageTiled( 190, 70, 2, 300, 10005 );
						for ( int y = 71; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 10; ++i )
							AddButton( 260, (30 * i) + 75 , 5601, 5605, i + 23, GumpButtonType.Reply, 0 );
						AddLabel( 45, 75, 0, "Attack Chance" );
						AddLabel( 200, 75, 0, ""+wa.Attributes.AttackChance );
						AddLabel( 45, 105, 0, "Bonus Dex" );
						AddLabel( 200, 105, 0, ""+wa.Attributes.BonusDex );
						AddLabel( 45, 135, 0, "Bonus Hits" );
						AddLabel( 200, 135, 0, ""+wa.Attributes.BonusHits );
						AddLabel( 45, 165, 0, "Bonus Int" );
						AddLabel( 200, 165, 0, ""+wa.Attributes.BonusInt );
						AddLabel( 45, 195, 0, "Bonus Mana" );
						AddLabel( 200, 195, 0, ""+wa.Attributes.BonusMana );
						AddLabel( 45, 225, 0, "BonusStam" );
						AddLabel( 200, 225, 0, ""+wa.Attributes.BonusStam );
						AddLabel( 45, 255, 0, "Bonus Str" );
						AddLabel( 200, 255, 0, ""+wa.Attributes.BonusStr );
						AddLabel( 45, 285, 0, "Cast Recovery" );
						AddLabel( 200, 285, 0, ""+wa.Attributes.CastRecovery );
						AddLabel( 45, 315, 0, "Cast Speed" );
						AddLabel( 200, 315, 0, ""+wa.Attributes.CastSpeed );
						AddLabel( 45, 345, 0, "Defend Chance" );
						AddLabel( 200, 345, 0, ""+wa.Attributes.DefendChance );

						AddLabel( 190, 380, 1150, "Next Page" );
						AddButton( 260, 380, 9762, 9763, 0, GumpButtonType.Page, 5 );
						AddButton( 20, 385, 5223, 5223, 0, GumpButtonType.Page, 1 );
						AddLabel( 45, 385, 102, "Back" );
						
						//--<< Attributes Pg.5 >>

						AddPage( 5 );
						this.Closable = false;

						AddBackground( 0, 0, 300, 420, 3600 );
						AddLabel( 50, 20, 1150, "Attribute" );
						AddLabel( 200, 20, 1150, "Value" );

						AddBackground( 40, 40, 220, 330, 3000 );
						AddImageTiled( 190, 40, 2, 330, 10005 );
						for ( int y = 41; y <= 370; ++y )
						{
							y += 29;
							AddImageTiled( 40, y, 240, 2, 10001 );
						}
						for ( int i = 0; i < 11; ++i )
							AddButton( 260, (30 * i) + 45 , 5601, 5605, i + 33, GumpButtonType.Reply, 0 );
						AddLabel( 45, 45, 0, "Lower Mana Cost" );
						AddLabel( 200, 45, 0, ""+wa.Attributes.LowerManaCost );
						AddLabel( 45, 75, 0, "Lower Reg Cost" );
						AddLabel( 200, 75, 0, ""+wa.Attributes.LowerRegCost );
						AddLabel( 45, 105, 0, "Luck" );
						AddLabel( 200, 105, 0, ""+wa.Attributes.Luck );
						AddLabel( 45, 135, 0, "Reflect Physical" );
						AddLabel( 200, 135, 0, ""+wa.Attributes.ReflectPhysical );
						AddLabel( 45, 165, 0, "Regen Hits" );
						AddLabel( 200, 165, 0, ""+wa.Attributes.RegenHits );
						AddLabel( 45, 195, 0, "Regen Mana" );
						AddLabel( 200, 195, 0, ""+wa.Attributes.RegenMana );
						AddLabel( 45, 225, 0, "Regen Stam" );
						AddLabel( 200, 225, 0, ""+wa.Attributes.RegenStam );
						AddLabel( 45, 255, 0, "Spell Channeling" );
						AddLabel( 200, 255, 0, ""+wa.Attributes.SpellChanneling );
						AddLabel( 45, 285, 0, "Spell Damage" );
						AddLabel( 200, 285, 0, ""+wa.Attributes.SpellDamage );
						AddLabel( 45, 315, 0, "Weapon Damage" );
						AddLabel( 200, 315, 0, ""+wa.Attributes.WeaponDamage );
						AddLabel( 45, 345, 0, "Weapon Speed" );
						AddLabel( 200, 345, 0, ""+wa.Attributes.WeaponSpeed );

						AddButton( 20, 385, 9706, 9707, 0, GumpButtonType.Page, 4 );
						AddLabel( 45, 385, 1150, "Last Page" );
					}
				}
			}
		}

		private int m_incrate;
		private int m_cost;
		private int m_cap1;

		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
		{
			Mobile from = state.Mobile;
			PlayerMobile pm = from as PlayerMobile;
			PlayerModule module = pm.PlayerModule;

			BaseWeapon wa = m_wep as BaseWeapon;
			TextRelay tr = info.GetTextEntry( 1 );
			string text = ( tr == null ? "" : tr.Text.Trim() );
			m_incrate = 5;//Mod Increase Rate here!
			m_cost = 25;//Mod Cost here!
			m_cap1 = 25;//Mod max cap here  m_cap1 + 5 = max  25 + 5 = 30 <---current cap

			switch ( info.ButtonID )
			{
				case 0: //cancel
					{
						from.CloseGump( typeof( WepUpgradeGump ) );
						from.SendMessage( 47, "Enjoy your new weapon!" );
						break;
					}
				case 1: //Text Entry
					{
						if ( m_wep != null && !m_wep.Deleted )
						{
							from.SendMessage( 37, "Property Set" );
							m_wep.Name = text;
							break;
						}
						else
						{
							from.SendMessage( "You must have the customizable item equipped!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 2: //Dur Bonus
					{
						if ( m_wep == null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.DurabilityBonus > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.DurabilityBonus += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 3: //HCA
					{
						if ( m_wep == null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitColdArea > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitColdArea += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 4: //HD
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitDispel > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitDispel += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 5: //HEA
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitEnergyArea > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitEnergyArea += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 6: //HFA
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitFireArea > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitFireArea += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 7: //HF
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitFireball > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitFireball += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 8: //HH
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitHarm > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitHarm += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 9: //HLH
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitLeechHits > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitLeechHits += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 10: //HLM
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitLeechMana > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitLeechMana += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 11: //HLS
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitLeechStam > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitLeechStam += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 12: //HL
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitLightning > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitLightning += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 13: //HLA
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitLowerAttack > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitLowerAttack += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 14: //HLD
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitLowerDefend > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitLowerDefend += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 15: //HMA
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitMagicArrow > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitMagicArrow += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 16: //HPyA
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitPhysicalArea > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitPhysicalArea += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 17: //HPA
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.HitPoisonArea > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.HitPoisonArea += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 18: //RCB
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.ResistColdBonus > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.ResistColdBonus += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 19: //REB
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.ResistEnergyBonus > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.ResistEnergyBonus += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 20: //RFB
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.ResistFireBonus > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.ResistFireBonus += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 21: //RPB
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.ResistPoisonBonus > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.WeaponAttributes.ResistPoisonBonus += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 22: //SR
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.WeaponAttributes.SelfRepair > 8 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= 15 )
						{
							wa.WeaponAttributes.SelfRepair += 2; //InvalidateProperties();
							module.SkillPts -= 15;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 15 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 23: //Attack Chance
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.AttackChance > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.AttackChance += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 24: //Bonus Dex
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.BonusDex > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.BonusDex += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 25: //Bonus Hits
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.BonusHits > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.BonusHits += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 26: //Bonus Int
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.BonusInt > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.BonusInt += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 27: //Bonus Mana
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.BonusMana > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.BonusMana += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 28: //Bonus Stam
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.BonusStam > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.BonusStam += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 29: //Bonus Str
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.BonusStr > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.BonusStr += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 30: //Cast Recovery
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.CastRecovery > 10 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.CastRecovery += 1; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 31: //Cast Speed
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.CastSpeed > 5 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.CastSpeed += 1; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 32: //defend Chance
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.DefendChance > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.DefendChance += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 33: //Lower Mana
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.LowerManaCost > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.LowerManaCost += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 34: //lower reg cost
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.LowerRegCost > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.LowerRegCost += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 35: //luck
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.Luck > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.Luck += 100; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 36: //Reflecy Physical
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.ReflectPhysical > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.ReflectPhysical += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 37: //regen hits
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.RegenHits > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.RegenHits += 2; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 38: //Regen Mana
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.RegenMana > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.RegenMana += 2; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 39: //REgen Stam
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.RegenStam > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.RegenStam += 2; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 40: //Spell Channeling
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.SpellChanneling >= 1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.SpellChanneling += 1; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 41: //spell damage
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.SpellDamage > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.SpellDamage += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 42: //Weapon Damage
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.WeaponDamage > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.WeaponDamage += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
				case 43: //Weapon Speed
					{
						if ( m_wep ==null && m_wep.Deleted )
						{
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
						else if ( wa.Attributes.WeaponSpeed > m_cap1 )
						{
							from.SendMessage( 37, "The value of this skill is too high for that!" );
							break;
						}
						else if ( module.SkillPts >= m_cost )
						{
							wa.Attributes.WeaponSpeed += m_incrate; //InvalidateProperties();
							module.SkillPts -= m_cost;
							break;
						}
						else
						{
							from.SendMessage( 47, "You must have at least 25 Skill points to raise this!" );
							from.CloseGump( typeof( WepUpgradeGump ) );
							from.SendGump( new WepUpgradeGump( from ) );
							break;
						}
					}
			}
		}
	}
}
