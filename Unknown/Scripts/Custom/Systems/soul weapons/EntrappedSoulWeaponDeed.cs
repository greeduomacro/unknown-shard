using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using Server.Gumps;

namespace Server.Items
{
	public class EntrappedSoulWeaponDeed : BaseSword
	{
		[Constructable]
		public EntrappedSoulWeaponDeed() : base( 0x227B )
		{
			Name = "EntrappedSoul Weapon Deed";
			Weight = 1.0;
			Hue = 2101;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) ) from.SendLocalizedMessage( 1042001 );
			else from.SendGump( new InternalGump( from, this ) );
		}

		private class InternalGump : Gump
		{
			private Mobile m_From;
			private EntrappedSoulWeaponDeed m_Deed;

			public InternalGump( Mobile from, EntrappedSoulWeaponDeed deed ) : base( 50, 50 )
			{
				m_From = from;
				m_Deed = deed;

				from.CloseGump( typeof( InternalGump ) );

				AddPage ( 0 );
				AddBackground( 10, 10, 465, 405, 0xA28 );

				AddImage(442,35, 10441);

				AddPage ( 1 );

				AddLabel( 120, 25, 0x34, "Select the Type of Weapon you Prefer.");

				AddLabel( 75,  55, 59, "EntrappedSoul Axes");
				AddLabel( 75,  85, 59, "EntrappedSoul Bows");
				AddLabel( 75, 115, 59, "EntrappedSoul Knives");
				AddLabel( 75, 145, 59, "EntrappedSoul Maces");
				AddLabel( 75, 175, 59, "EntrappedSoul Pole Arms");
				AddLabel( 75, 205, 59, "EntrappedSoul Spears and Forks");
				AddLabel( 75, 235, 59, "EntrappedSoul Staves");
				AddLabel( 75, 265, 59, "EntrappedSoul Swords");

				AddButton( 40,  58, 0x2623, 0x2622, 1, GumpButtonType.Page, 2 );
				AddButton( 40,  88, 0x2623, 0x2622, 2, GumpButtonType.Page, 3 );
				AddButton( 40, 118, 0x2623, 0x2622, 3, GumpButtonType.Page, 4 );
				AddButton( 40, 148, 0x2623, 0x2622, 4, GumpButtonType.Page, 5 );
				AddButton( 40, 178, 0x2623, 0x2622, 5, GumpButtonType.Page, 6 );
				AddButton( 40, 208, 0x2623, 0x2622, 6, GumpButtonType.Page, 7 );
				AddButton( 40, 238, 0x2623, 0x2622, 7, GumpButtonType.Page, 8 );
				AddButton( 40, 268, 0x2623, 0x2622, 8, GumpButtonType.Page, 9 );

				AddPage ( 2 );

				AddLabel( 160, 25, 0x34, "Select the Axe you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Axe");
				AddLabel( 75,  85, 59, "EntrappedSoul Battle Axe");
				AddLabel( 75, 115, 59, "EntrappedSoul Double Axe");
				AddLabel( 75, 145, 59, "EntrappedSoul Executioner's Axe");
				AddLabel( 75, 175, 59, "EntrappedSoul Hatchet");
				AddLabel( 75, 205, 59, "EntrappedSoul Large Battle Axe");
				AddLabel( 75, 235, 59, "EntrappedSoul Pickaxe");
				AddLabel( 75, 265, 59, "EntrappedSoul Two Handed Axe");
				AddLabel( 75, 295, 59, "EntrappedSoul War Axe");

				AddButton( 40,  58, 0x2623, 0x2622, 1, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 2, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 3, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 4, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 5, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 6, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 7, GumpButtonType.Reply, 0 );
				AddButton( 40, 268, 0x2623, 0x2622, 8, GumpButtonType.Reply, 0 );
				AddButton( 40, 298, 0x2623, 0x2622, 9, GumpButtonType.Reply, 0 );

				AddPage ( 3 );

				AddLabel( 160, 25, 0x34, "Select the Bow you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Bow");
				AddLabel( 75,  85, 59, "EntrappedSoul Composite Bow");
				AddLabel( 75, 115, 59, "EntrappedSoul Crossbow");
				AddLabel( 75, 145, 59, "EntrappedSoul Heavy Crossbow");
				AddLabel( 75, 175, 59, "EntrappedSoul Repeating Crossbow");

				AddButton( 40,  58, 0x2623, 0x2622, 10, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 11, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 12, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 13, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 14, GumpButtonType.Reply, 0 );

				AddPage ( 4 );

				AddLabel( 160, 25, 0x34, "Select the Knife you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Butcher Knife");
				AddLabel( 75,  85, 59, "EntrappedSoul Cleaver");
				AddLabel( 75, 115, 59, "EntrappedSoul Dagger");
				AddLabel( 75, 145, 59, "EntrappedSoul Skinning Knife");

				AddButton( 40,  58, 0x2623, 0x2622, 15, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 16, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 17, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 18, GumpButtonType.Reply, 0 );

				AddPage ( 5 );

				AddLabel( 160, 25, 0x34, "Select the Mace you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Club");
				AddLabel( 75,  85, 59, "EntrappedSoul Hammer Pick");
				AddLabel( 75, 115, 59, "EntrappedSoul Mace");
				AddLabel( 75, 145, 59, "EntrappedSoul Maul");
				AddLabel( 75, 175, 59, "EntrappedSoul Scepter");
				AddLabel( 75, 205, 59, "EntrappedSoul War Hammer");
				AddLabel( 75, 235, 59, "EntrappedSoul War Mace");

				AddButton( 40,  58, 0x2623, 0x2622, 19, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 20, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 21, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 22, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 23, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 24, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 25, GumpButtonType.Reply, 0 );

				AddPage ( 6 );

				AddLabel( 140, 25, 0x34, "Select the Pole Arm you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Bardiche");
				AddLabel( 75,  85, 59, "EntrappedSoul Halberd");
				AddLabel( 75, 115, 59, "EntrappedSoul Scythe");

				AddButton( 40,  58, 0x2623, 0x2622, 26, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 27, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 28, GumpButtonType.Reply, 0 );

				AddPage ( 7 );

				AddLabel( 130, 25, 0x34, "Select the Spear or Fork you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Bladed Staff");
				AddLabel( 75,  85, 59, "EntrappedSoul Double Bladed Staff");
				AddLabel( 75, 115, 59, "EntrappedSoul Pike");
				AddLabel( 75, 145, 59, "EntrappedSoul Pitchfork");
				AddLabel( 75, 175, 59, "EntrappedSoul Short Spear");
				AddLabel( 75, 205, 59, "EntrappedSoul Spear");
				AddLabel( 75, 235, 59, "EntrappedSoul War Fork");

				AddButton( 40,  58, 0x2623, 0x2622, 29, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 30, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 31, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 32, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 33, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 34, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 35, GumpButtonType.Reply, 0 );

				AddPage ( 8 );

				AddLabel( 160, 25, 0x34, "Select the Staff you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Black Staff");
				AddLabel( 75,  85, 59, "EntrappedSoul Gnarled Staff");
				AddLabel( 75, 115, 59, "EntrappedSoul Quarter Staff");
				AddLabel( 75, 145, 59, "EntrappedSoul Shepherd's Crook");

				AddButton( 40,  58, 0x2623, 0x2622, 36, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 37, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 38, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 39, GumpButtonType.Reply, 0 );

				AddPage ( 9 );

				AddLabel( 160, 25, 0x34, "Select the Sword you Desire.");

				AddLabel( 75,  55, 59, "EntrappedSoul Bone Harvester");
				AddLabel( 75,  85, 59, "EntrappedSoul Broad Sword");
				AddLabel( 75, 115, 59, "EntrappedSoul Crescent Blade");
				AddLabel( 75, 145, 59, "EntrappedSoul Cutlass");
				AddLabel( 75, 175, 59, "EntrappedSoul Katana");
				AddLabel( 75, 205, 59, "EntrappedSoul Kryss");
				AddLabel( 75, 235, 59, "EntrappedSoul Lance");
				AddLabel( 75, 265, 59, "EntrappedSoul Long Sword");
				AddLabel( 75, 295, 59, "EntrappedSoul Scimitar");
				AddLabel( 75, 325, 59, "EntrappedSoul Viking Sword");

				AddButton( 40,  58, 0x2623, 0x2622, 40, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 41, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 42, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 43, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 44, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 45, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 46, GumpButtonType.Reply, 0 );
				AddButton( 40, 268, 0x2623, 0x2622, 47, GumpButtonType.Reply, 0 );
				AddButton( 40, 298, 0x2623, 0x2622, 48, GumpButtonType.Reply, 0 );
				AddButton( 40, 328, 0x2623, 0x2622, 49, GumpButtonType.Reply, 0 );
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( m_Deed.Deleted ) return;

				BaseWeapon weapon = null;

				switch ( info.ButtonID )
				{
					case 0: return;
					case 1: weapon = new EntrappedSoulAxe() ; break;
					case 2: weapon = new EntrappedSoulBattleAxe() ; break;
					case 3: weapon = new EntrappedSoulDoubleAxe() ; break;
					case 4: weapon = new EntrappedSoulExecutionersAxe() ; break;
					case 5: weapon = new EntrappedSoulHatchet() ; break;
					case 6: weapon = new EntrappedSoulLargeBattleAxe() ; break;
					case 7: weapon = new EntrappedSoulPickaxe() ; break;
					case 8: weapon = new EntrappedSoulTwoHandedAxe() ; break;
					case 9: weapon = new EntrappedSoulWarAxe() ; break;
					case 10: weapon = new EntrappedSoulBow() ; break;
					case 11: weapon = new EntrappedSoulCompositeBow() ; break;
					case 12: weapon = new EntrappedSoulCrossbow() ; break;
					case 13: weapon = new EntrappedSoulHeavyCrossbow() ; break;
					case 14: weapon = new EntrappedSoulRepeatingCrossbow() ; break;
					case 15: weapon = new EntrappedSoulButcherKnife() ; break;
					case 16: weapon = new EntrappedSoulCleaver() ; break;
					case 17: weapon = new EntrappedSoulDagger() ; break;
					case 18: weapon = new EntrappedSoulSkinningKnife() ; break;
					case 19: weapon = new EntrappedSoulClub() ; break;
					case 20: weapon = new EntrappedSoulHammerPick() ; break;
					case 21: weapon = new EntrappedSoulMace() ; break;
					case 22: weapon = new EntrappedSoulMaul() ; break;
					case 23: weapon = new EntrappedSoulScepter() ; break;
					case 24: weapon = new EntrappedSoulWarHammer() ; break;
					case 25: weapon = new EntrappedSoulWarMace() ; break;
					case 26: weapon = new EntrappedSoulBardiche() ; break;
					case 27: weapon = new EntrappedSoulHalberd() ; break;
					case 28: weapon = new EntrappedSoulScythe() ; break;
					case 29: weapon = new EntrappedSoulBladedStaff() ; break;
					case 30: weapon = new EntrappedSoulDoubleBladedStaff() ; break;
					case 31: weapon = new EntrappedSoulPike() ; break;
					case 32: weapon = new EntrappedSoulPitchfork() ; break;
					case 33: weapon = new EntrappedSoulShortSpear() ; break;
					case 34: weapon = new EntrappedSoulSpear() ; break;
					case 35: weapon = new EntrappedSoulWarFork() ; break;
					case 36: weapon = new EntrappedSoulBlackStaff() ; break;
					case 37: weapon = new EntrappedSoulGnarledStaff() ; break;
					case 38: weapon = new EntrappedSoulQuarterStaff() ; break;
					case 39: weapon = new EntrappedSoulShepherdsCrook() ; break;
					case 40: weapon = new EntrappedSoulBoneHarvester() ; break;
					case 41: weapon = new EntrappedSoulBroadSword() ; break;
					case 42: weapon = new EntrappedSoulCrescentBlade() ; break;
					case 43: weapon = new EntrappedSoulCutlass() ; break;
					case 44: weapon = new EntrappedSoulKatana() ; break;
					case 45: weapon = new EntrappedSoulKryss() ; break;
					case 46: weapon = new EntrappedSoulLance() ; break;
					case 47: weapon = new EntrappedSoulLongSword() ; break;
					case 48: weapon = new EntrappedSoulScimitar() ; break;
					case 49: weapon = new EntrappedSoulVikingSword() ; break;
				}

				if ( weapon != null )
				{
					weapon.Quality = m_Deed.Quality;
					weapon.Resource = m_Deed.Resource;
					if ( m_Deed.Crafter != null ) weapon.Crafter = m_Deed.Crafter;
					m_From.Backpack.DropItem( weapon );
					m_From.SendMessage( "You summon the Entrapped Soul Weapon!" );
					m_Deed.Delete();
				}
			}
		}

		public EntrappedSoulWeaponDeed( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
}