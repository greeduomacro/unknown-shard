////////////////////////////  ///////////////////////
//// Created by Andyboi  //  // and Lucid Nagual ////
//////////////////////////  /////////////////////////
////   DO NOT REMOVE   //  // Easy Level System  ////
////   THIS HEADER!!  //  //   Version [2].0.1   ////
///////////////////////  ////////////////////////////
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.LevelSystem;

namespace Server.Gumps
{
	public class LevelControlStoneGump : Gump
	{
		private static LevelControlStone m_Stone;
		
		public LevelControlStoneGump() : base( 50,50 )
		{
			AddPage( 1 );
			AddBackground( 0, 0, 250, 330, 9200 );
			AddBackground( 25, 15, 190, 30, 9300 );
			AddLabel( 35, 20, 1153, "Level System Control Gump" );

			AddBackground( 15, 65, 215, 250, 9350 );
			AddLabel( 20, 45, 37, "Restrictions" );
			AddLabel( 135, 45, 37, "Value" );
			for ( int i = 0; i < 7; ++i )
			AddImageTiled( 15, ( 25 * i ) + 90, 215, 3, 96 );
			for ( int i = 0; i < 6; ++i )
			AddButton( 195, ( i*25 ) + 67, 4026, 4027, i + 1, GumpButtonType.Reply, 0 );
			AddImageTiled( 130, 65, 2, 250, 10004 );
			AddImageTiled( 190, 65, 2, 250, 10004 );
			AddLabel( 25, 70, 0, "Allow SkillPts" );
			AddLabel( 140, 70, 0, "" + LevelControlStone.AllowSkillPts );
			AddLabel( 25, 95, 0, "Allow Aging" );
			AddLabel( 140, 95, 0, "" + LevelControlStone.AllowAging );
			AddLabel( 25, 120, 0, "Allow Exp" );
			AddLabel( 140, 120, 0, "" + LevelControlStone.AllowExp );
			AddLabel( 25, 145, 0, "Allow SP Reward" );
			AddLabel( 140, 145, 0, "" + LevelControlStone.AllowSPRewardSystem );
			AddLabel( 25, 170, 0, "Allow XP Reward" );
			AddLabel( 140, 170, 0, "" + LevelControlStone.AllowEXPRewardSystem );
			AddLabel( 25, 195, 0, "Level Gump Name" );
			AddTextEntry( 135, 195, 50, 20, 0, 1, string.Format( "{0}", LevelControlStone.ServerName ) );
			AddLabel( 25, 220, 0, "Level Keepers" );
			AddLabel( 140, 220, 0, "" + m_Stone.LevelKeepers.Count );
		}

		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons
		{
			Mobile from = state.Mobile;
			TextRelay tr = info.GetTextEntry( 1 );
			string text = ( tr == null ? "" : tr.Text.Trim() );

			switch ( info.ButtonID )
			{
				case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0
				{
					from.SendMessage( "Thanks for using Andys Level System!" );
					break;
				}
				case 1: //Allow Skill Pts
				{
					if ( LevelControlStone.EnableLevelSystem == true )
					{
						if ( LevelControlStone.AllowSkillPts == false )
						{
							LevelControlStone.AllowSkillPts = true;
							from.SendMessage( 1161, "Property successfully set!" );
						}
						else if ( LevelControlStone.AllowSkillPts == true )
						{
							LevelControlStone.AllowSkillPts = false;
							from.SendMessage( 1161, "Property successfully set!" );
						}
					}
					else
					from.SendMessage( 1161, "You must enable this stone first!" );

					from.CloseGump( typeof( LevelControlStoneGump ) );
					from.SendGump( new LevelControlStoneGump() );
					break;
				}
				case 2: //Allow Aging
				{
					if ( LevelControlStone.EnableLevelSystem == true )
					{
						if ( LevelControlStone.AllowAging == true )
						{
							LevelControlStone.AllowAging = false;
							from.SendMessage( 1161, "Property successfully set!" );
						}
						else if ( LevelControlStone.AllowAging == false )
						{
							LevelControlStone.AllowAging = true;
							from.SendMessage( 1161, "Property successfully set!" );
						}
					}
					else
					from.SendMessage ( 1161, "You must enable this stone first!" );

					from.CloseGump( typeof( LevelControlStoneGump ) );
					from.SendGump( new LevelControlStoneGump() );
					break;
				}
				case 3: //Allow Exp
				{
					if ( LevelControlStone.EnableLevelSystem == true )
					{
						if ( LevelControlStone.AllowExp == true )
						{
							LevelControlStone.AllowExp = false;
							from.SendMessage( 1161, "Property successfully set!" );
						}
						else if ( LevelControlStone.AllowExp == false )
						{
							LevelControlStone.AllowExp = true;
							from.SendMessage( 1161, "Property successfully set!" );
						}
					}
					else
					from.SendMessage( 1161, "You must enable this stone first!" );

					from.CloseGump( typeof( LevelControlStoneGump ) );
					from.SendGump( new LevelControlStoneGump() );
					break;
				}
				case 4: //Allow SP Reward System
				{
					if ( LevelControlStone.EnableLevelSystem == true )
					{
						if ( LevelControlStone.AllowSPRewardSystem == true )
						{
							LevelControlStone.AllowSPRewardSystem = false;
							from.SendMessage( 1161, "Property Successfully set!" );
						}
						else if ( LevelControlStone.AllowSPRewardSystem == false )
						{
							LevelControlStone.AllowSPRewardSystem = true;
							from.SendMessage( 1161, "Property successfully set!" );
						}
					}
					else
					from.SendMessage( 1161, "You must enable this stone first!" );

					from.CloseGump( typeof( LevelControlStoneGump ) );
					from.SendGump( new LevelControlStoneGump() );
					break;
				}
				case 5: //Allow EXP Reward
				{
					if ( LevelControlStone.EnableLevelSystem == true )
					{
						if ( LevelControlStone.AllowEXPRewardSystem == true )
						{
							LevelControlStone.AllowEXPRewardSystem = false;
							from.SendMessage( 1161, "Property successfully set!" );
						}
						else if ( LevelControlStone.AllowEXPRewardSystem == false )
						{
							LevelControlStone.AllowEXPRewardSystem = true;
							from.SendMessage( 1161, "Property successfully set!" );
						}
					}
					else
					from.SendMessage( 1161, "You must enable this stone first!" );
					
					from.CloseGump( typeof( LevelControlStoneGump ) );
					from.SendGump( new LevelControlStoneGump() );
					break;
				}
				case 6: //Server Name
				{
					if ( LevelControlStone.EnableLevelSystem == true )
					{
						from.SendMessage( 1161, "Property successfully set!" );
						LevelControlStone.ServerName = text;
					}
					else
					from.SendMessage( 1161, "You must enable this stone first!" );

					from.CloseGump( typeof( LevelControlStoneGump ) );
					from.SendGump( new LevelControlStoneGump() );
					break;
				}
			}
		}
	}
}

