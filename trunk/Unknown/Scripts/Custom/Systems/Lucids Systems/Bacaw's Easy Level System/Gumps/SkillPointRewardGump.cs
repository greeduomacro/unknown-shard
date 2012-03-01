////////////////////////////  ///////////////////////
//// Created by Andyboi  //  // and Lucid Nagual ////
//////////////////////////  /////////////////////////
////   DO NOT REMOVE   //  // Easy Level System  ////
////   THIS HEADER!!  //  //   Version [2].0.1   ////
///////////////////////  ////////////////////////////
using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.ACC.CM;


namespace Server.Gumps
{
	public class SkillPointRewardGump : Gump
	{
		public SkillPointRewardGump( Mobile owner ) : base( 50,50 )
		{
			AddPage( 1 );
			AddBackground( 0, 0, 160, 250, 9200 );
			AddBackground( 15, 15, 130, 30, 9300 );
			AddLabel( 30, 20, 1150, "Craftable Menu" );
			
			AddBackground( 15, 50, 130, 185, 3000 );
			AddLabel( 25, 60, 0, "Swords" );
			AddButton( 115, 60, 2087, 2087, 0, GumpButtonType.Page, 2 );
			AddLabel( 25, 90, 0, "Fencing" );
			AddButton( 115, 90, 2087, 2087, 0, GumpButtonType.Page, 3 );
			AddLabel( 25, 120, 0, "Macing" );
			AddButton( 115, 120, 2087, 2087, 0, GumpButtonType.Page, 4 );
			AddLabel( 25, 150, 0, "Archery" );
			AddButton( 115, 150, 2087, 2087, 0, GumpButtonType.Page, 5 );
			//AddLabel( 25, 180, 0, "Parrying" );
			//AddButton( 115, 180, 2087, 2087, 0, GumpButtonType.Page, 6 );
			AddLabel( 55, 210, 37, "READ!!!" );
			AddButton( 110, 210, 4027, 4028, 0, GumpButtonType.Page, 7 );
			
			//--<< Swords Menu Pg.2 >>

			AddPage( 2 );
			AddBackground( 0, 0, 160, 300, 9200 );
			AddBackground( 15, 15, 130, 30, 9300 );
			AddLabel( 35, 20, 1150, "Swords Menu" );
			
			AddBackground( 15, 50, 130, 235, 3000 );
			
			for ( int i = 0; i < 9; ++i )
				AddButton( 125, (25 * i) + 55 , 2087, 2087, i + 1, GumpButtonType.Reply, 0 );

			AddLabel( 25, 55, 0, "Katana" );
			AddLabel( 25, 80, 0, "Broad Sword" );
			AddLabel( 25, 105, 0, "Scimitar" );
			AddLabel( 25, 130, 0, "Viking Sword" );
			AddLabel( 25, 155, 0, "Halberd" );
			AddLabel( 25, 180, 0, "Bardiche" );
			AddLabel( 25, 205, 0, "Double Axe" );
			AddLabel( 25, 230, 0, "Lg. Battle Axe" );
			AddLabel( 25, 255, 0, "Axe" );
			
			AddButton( 5, 280, 5223, 5223, 0, GumpButtonType.Page, 1 );
			AddLabel( 25, 280, 1150, "Back" );
			
			//--<< Fencing Menu Pg.3 >>

			AddPage( 3 );
			AddBackground( 0, 0, 160, 300, 9200 );
			AddBackground( 15, 15, 130, 30, 9300 );
			AddLabel( 35, 20, 1150, "Fencing Menu" );
			
			AddBackground( 15, 50, 130, 235, 3000 );
			
			for( int i = 0; i < 9; ++i )
				AddButton( 125, (25 * i) + 55 , 2087, 2087, i + 10, GumpButtonType.Reply, 0 );

			AddLabel( 25, 55, 0, "Kryss" );
			AddLabel( 25, 80, 0, "War Fork" );
			AddLabel( 25, 105, 0, "Dagger" );
			AddLabel( 25, 130, 0, "Pike" );
			AddLabel( 25, 155, 0, "Short Spear" );
			AddLabel( 25, 180, 0, "Long Spear" );
			AddLabel( 25, 205, 0, "Pitchfork" );
			AddLabel( 25, 230, 0, "Lance" );
			AddLabel( 25, 255, 0, "Sai's" );
			
			AddButton( 5, 280, 5223, 5223, 0, GumpButtonType.Page, 1 );
			AddLabel( 25, 280, 1150, "Back" );
			
			//--<< Macing Menu Pg.4 >>

			AddPage( 4 );
			AddBackground( 0, 0, 160, 300, 9200 );
			AddBackground( 15, 15, 130, 30, 9300 );
			AddLabel( 35, 20, 1150, "Macing Menu" );
			
			AddBackground( 15, 50, 130, 235, 3000 );
			
			for ( int i = 0; i < 9; ++i )
				AddButton( 125, (25 * i) + 55 , 2087, 2087, i + 19, GumpButtonType.Reply, 0 );

			AddLabel( 25, 55, 0, "War Mace" );
			AddLabel( 25, 80, 0, "War Hammer" );
			AddLabel( 25, 105, 0, "Maul" );
			AddLabel( 25, 130, 0, "Club" );
			AddLabel( 25, 155, 0, "Quarter Staff" );
			AddLabel( 25, 180, 0, "Gnarled Staff" );
			AddLabel( 25, 205, 0, "Black Staff" );
			AddLabel( 25, 230, 0, "Hammer Pick" );
			AddLabel( 25, 255, 0, "War Axe" );
			
			AddButton( 5, 280, 5223, 5223, 0, GumpButtonType.Page, 1 );
			AddLabel( 25, 280, 1150, "Back" );
			
			//--<< Archery Menu Pg.5 >>

			AddPage( 5 );
			AddBackground( 0, 0, 160, 225, 9200 );
			AddBackground( 15, 15, 130, 30, 9300 );
			AddLabel( 35, 20, 1150, "Archery Menu" );
			
			AddBackground( 15, 50, 130, 155, 3000 );
			
			for ( int i = 0; i < 6; ++i )
				AddButton( 125, ( 25 * i ) + 55 , 2087, 2087, i + 28, GumpButtonType.Reply, 0 );

			AddLabel( 25, 55, 0, "Bow" );
			AddLabel( 25, 80, 0, "Composite Bow" );
			AddLabel( 25, 105, 0, "Crossbow" );
			AddLabel( 25, 130, 0, "Heavy Crossbow" );
			AddLabel( 25, 155, 0, "Repeating Xbow" );
			AddLabel( 25, 180, 0, "Yumi" );
			
			AddButton( 5, 205, 5223, 5223, 0, GumpButtonType.Page, 1 );
			AddLabel( 25, 205, 1150, "Back" );
			
			//--<< Parrying Menu Pg.6 >>

			/*AddPage( 6 );//EXPECT SUPPORT OF THIS FEATURE IN THE NEXT UPDATE!!
			AddBackground( 0, 0, 160, 275, 9200 );
			AddBackground( 15, 15, 130, 30, 9300 );
			AddLabel( 30, 20, 1150, "Parrying Menu" );

			AddBackground( 15, 50, 130, 210, 3000 );
			for ( int i = 0; i < 8; ++i )
			AddButton( 125, (25 * i) + 55 , 2087, 2087, i + 34, GumpButtonType.Reply, 0 );
			AddLabel( 25, 55, 0, "Bronze Shield" );
			AddLabel( 25, 80, 0, "Buckler" );
			AddLabel( 25, 105, 0, "Chaos Shield" );
			AddLabel( 25, 130, 0, "Order Shield" );
			AddLabel( 25, 155, 0, "Heater Shield" );
			AddLabel( 25, 180, 0, "Metal Shield" );
			AddLabel( 25, 205, 0, "Metal Kite" );
			AddLabel( 25, 230, 0, "Wooden Kite" );

			AddButton( 5, 255, 5223, 5223, 0, GumpButtonType.Page, 1 );
			AddLabel( 25, 255, 1150, "Back" );*/
			
			//--<< Information Pg.7 >>

			AddPage( 7 );
			AddBackground( 0, 0, 160, 250, 9200 );
			AddBackground( 15, 15, 130, 30, 9300 );
			AddLabel( 25, 20, 1150, "Item Information" );
			
			AddHtml( 15, 50, 130, 155, "<BODY>" +
			        "<BASEFONT COLOR=Red>IMPORTANT INFO!<BR><BR>All weapon will cost you a total of 50 skill points!! And on top of that each attribute added will cost an additional 25 <U>for 5 added</U>" +
			        "<BASEFONT COLOR=Red> with the exception of Self Repair, <U>Adds in increments of 2 at a cost of 15 per add</U>, and Luck which adds in increments of 100 at same cost.<BR><BR>ALSO be aware that you have <B>ONE SHOT</B> to mod ur wep thats it! It is reccomended that you wait till you have over 100!." +
			        "</BODY>", true, true );
			AddButton( 15, 220, 5223, 5223, 0, GumpButtonType.Page, 1 );
			AddLabel( 40, 220, 1150, "Back" );
		}
		
		private int m_cost;
		
		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
		{
			Mobile from = state.Mobile;
			PlayerMobile pm = from as PlayerMobile;
			PlayerModule module = pm.PlayerModule;

			m_cost = 50;//MOD COST OF WEAPON HERE!!
			Item wep = from.FindItemOnLayer( Layer.FirstValid );
			Item weps = from.FindItemOnLayer( Layer.TwoHanded );
			Container pack = from.Backpack;
			
			if ( wep !=null )
				pack.TryDropItem( from, wep, false );
			
			if ( weps !=null )
				pack.TryDropItem( from, weps, false );

			switch ( info.ButtonID )
			{
				case 0: //Cancel
					{
						from.SendMessage( "You decide against spending your skill points." );
						//from.SendGump( new LevelGump( from ) );
						break;
					}
				case 1: //Katana
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Katana kat = new Katana();
							( ( Item )kat ).Name = "Katana [Level Item]";
							kat.Identified = true;//Prevents others from being used in the upgrading!
							kat.LootType = LootType.Blessed;
							from.EquipItem( kat );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 2: //Broad Sword
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Broadsword bs = new Broadsword();
							bs.Identified = true;
							bs.Name = "Broadsword";
							bs.LootType = LootType.Blessed;
							from.EquipItem( bs );
							from.SendMessage( 102, "You chose a Broadsword" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 3: //Scimitar
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Scimitar sc = new Scimitar();
							sc.Identified = true;
							sc.Name = "Scimitar";
							sc.LootType = LootType.Blessed;
							from.EquipItem( sc );
							from.SendMessage( 102, "You chose a Scimitar" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 4: //Viking sword
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							VikingSword vs = new VikingSword();
							vs.Identified = true;
							vs.Name = "Vikingsword";
							vs.LootType = LootType.Blessed;
							from.EquipItem( vs );
							from.SendMessage( 102, "You chose a Viking Sword" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 5: //Halberd
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Halberd hb = new Halberd();
							hb.Identified = true;
							hb.Name = "Halberd";
							hb.LootType = LootType.Blessed;
							from.EquipItem( hb );
							from.SendMessage( 102, "You chose a Halberd" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 6: //Bardiche
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Bardiche bd = new Bardiche();
							bd.Identified = true;
							bd.Name = "Bardiche";
							bd.LootType = LootType.Blessed;
							from.EquipItem( bd );
							from.SendMessage( 102, "You chose a Bardiche" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 7: //Double Axe
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							DoubleAxe da = new DoubleAxe();
							da.Identified = true;
							da.Name = "Double Axe";
							da.LootType = LootType.Blessed;
							from.EquipItem( da );
							from.SendMessage( 102, "You chose a Double Axe" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 8: //Large Battle Axe
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							LargeBattleAxe lba = new LargeBattleAxe();
							lba.Identified = true;
							lba.Name = "Large Battle Axe";
							lba.LootType = LootType.Blessed;
							from.EquipItem( lba );
							from.SendMessage( 102, "You chose a Large Battle Axe" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 9: //Axe
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Axe a = new Axe();
							a.Identified = true;
							a.Name = "Axe";
							a.LootType = LootType.Blessed;
							from.EquipItem( a );
							from.SendMessage( 102, "You chose an Axe" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 10: //Kryss
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Kryss k = new Kryss();
							k.Identified = true;
							k.Name = "Kryss";
							k.LootType = LootType.Blessed;
							from.EquipItem( k );
							from.SendMessage( 102, "You chose a Kryss" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 11: //War Fork
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							WarFork wf = new WarFork();
							wf.Identified = true;
							wf.Name = "War Fork";
							wf.LootType = LootType.Blessed;
							from.EquipItem( wf );
							from.SendMessage( 102, "You chose a War Fork" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 12: //Dagger
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Dagger d = new Dagger();
							d.Identified = true;
							d.Name = "Dagger";
							d.LootType = LootType.Blessed;
							from.EquipItem( d );
							from.SendMessage( 102, "You chose a Dagger" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 13: //Pike
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Pike p = new Pike();
							p.Identified = true;
							p.Name = "Pike";
							p.LootType = LootType.Blessed;
							from.EquipItem( p );
							from.SendMessage( 102, "You chose a Pike" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 14: //Short Spear
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							ShortSpear ss = new ShortSpear();
							ss.Identified = true;
							ss.Name = "Short Spear";
							ss.LootType = LootType.Blessed;
							from.EquipItem( ss );
							from.SendMessage( 102, "You chose a Short Spear" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 15: //Long Spear
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Spear ls = new Spear();
							ls.Identified = true;
							ls.Name = "Long Spear";
							ls.LootType = LootType.Blessed;
							from.EquipItem( ls );
							from.SendMessage( 102, "You chose a Long Spear" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 16: //Pitchfork
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Pitchfork p = new Pitchfork();
							p.Identified = true;
							p.Name = "Pitchfork";
							p.LootType = LootType.Blessed;
							from.EquipItem( p );
							from.SendMessage( 102, "You chose a Pitchfork" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 17: //lance
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Lance l = new Lance();
							l.Identified = true;
							l.Name = "Lance";
							l.LootType = LootType.Blessed;
							from.EquipItem( l );
							from.SendMessage( 102, "You chose a Lance" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 18: //Sai's
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Sai s = new Sai();
							s.Identified = true;
							s.Name = "Sai";
							s.LootType = LootType.Blessed;
							from.EquipItem( s );
							from.SendMessage( 102, "You chose Sai's" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 19: //War Mace
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							WarMace wm = new WarMace();
							wm.Identified = true;
							wm.Name = "War Mace";
							wm.LootType = LootType.Blessed;
							from.EquipItem( wm );
							from.SendMessage( 102, "You chose a War Mace" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 20: //War Hammer
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							WarHammer wh = new WarHammer();
							wh.Identified = true;
							wh.Name = "War Hammer";
							wh.LootType = LootType.Blessed;
							from.EquipItem( wh );
							from.SendMessage( 102, "You chose a War Hammer" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 21: //Maul
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Maul w = new Maul();
							w.Identified = true;
							w.Name = "Maul";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Maul" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 22: //Club
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Club w = new Club();
							w.Identified = true;
							w.Name = "Club";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Club" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 23: //Q Staff
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							QuarterStaff w = new QuarterStaff();
							w.Identified = true;
							w.Name = "Quarter Staff";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Quarter Staff" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 24: //G Staff
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							GnarledStaff w = new GnarledStaff();
							w.Identified = true;
							w.Name = "Gnarled Staff";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Gnarled Staff" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 25: //B Staff
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							BlackStaff w = new BlackStaff();
							w.Identified = true;
							w.Name = "BlackStaff";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Black Staff" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 26: //Hammer Pick
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							HammerPick w = new HammerPick();
							w.Identified = true;
							w.Name = "Hammer Pick";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Hammer Pick" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 27: //War Axe
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							WarAxe w = new WarAxe();
							w.Identified = true;
							w.Name = "War Axe";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a War Axe" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 28: //Bow
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Bow w = new Bow();
							w.Identified = true;
							w.Name = "Bow";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Bow" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 29: //Composite Bow
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							CompositeBow w = new CompositeBow();
							w.Identified = true;
							w.Name = "Composite Bow";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Composite Bow" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 30: //Crossbow
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Crossbow w = new Crossbow();
							w.Identified = true;
							w.Name = "Crossbow";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Crossbow" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 31: //Heavy Crossbow
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							HeavyCrossbow w = new HeavyCrossbow();
							w.Identified = true;
							w.Name = "Heavy Crossbow";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Heavy Crossbow" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 32: //Repeating Crossbow
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							RepeatingCrossbow w = new RepeatingCrossbow();
							w.Identified = true;
							w.Name = "Repeating Crossbow";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Repeating Crossbow" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
				case 33: //Yumi
					{
						if ( module.SkillPts < m_cost )
							from.SendMessage( 37, "Not enough skill points!" );
						else
						{
							module.SkillPts -= m_cost;
							Yumi w = new Yumi();
							w.Identified = true;
							w.Name = "Yumi";
							w.LootType = LootType.Blessed;
							from.EquipItem( w );
							from.SendMessage( 102, "You chose a Yumi" );
						}
						
						from.SendGump( new WepUpgradeGump( from ) );
						break;
					}
			}
		}
	}
}
