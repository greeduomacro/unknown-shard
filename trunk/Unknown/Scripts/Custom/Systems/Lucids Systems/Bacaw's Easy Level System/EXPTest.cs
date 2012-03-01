////////////////////////////  ///////////////////////
//// Created by Andyboi  //  // and Lucid Nagual ////
//////////////////////////  /////////////////////////
////   DO NOT REMOVE   //  // Easy Level System  ////
////   THIS HEADER!!  //  //   Version [2].0.1   ////
///////////////////////  ////////////////////////////
using System;
using System.Collections;
using Server.Items;
using Server.Misc;
using Server.LevelSystem;
using Server.ACC.CM;
using Server.Accounting;
using Server.LucidNagual;


namespace Server.Mobiles
{
	public class EXPValidate
	{
		public static TimeSpan AgeInterval = TimeSpan.FromDays( 30.0 );
		
		private static void PlaceItemIn( Container parent, int x, int y, Item item )
		{
			parent.AddItem( item );
			item.Location = new Point3D( x, y, 0 );
		}
		
		public static void EXPTest( Mobile from, BaseCreature bc )
		{
			PlayerMobile pm = from as PlayerMobile;
			PlayerModule module = pm.PlayerModule;

			int expbase = ( bc.HitsMax + bc.SkillsTotal + bc.Fame ) / 120;
			int age = 0;
			
			Account acct = from.Account as Account;
			TimeSpan totalTime = ( DateTime.Now - acct.Created );
			
			if ( AgeInterval.TotalDays < 30 )
				age = 0;
			else
				age = ( int )( totalTime.TotalDays / AgeInterval.TotalDays );
			
			module.NextLevelUp = module.NextLevelUp;
			
			if ( acct != null )
				module.Age = age;
			
			if ( DataCenter.EnableSkillPoints && Utility.RandomDouble() <= 0.1 )
			{
				module.SkillPts += 1;
				from.SendMessage( 102, "You have been awarded a skill point for your valor." );
			}
			
			if ( DataCenter.EnablePlayerLevelSystem )
			{
				module.Experience += expbase;
				from.SendMessage( "You have been awarded {0} experience points.", expbase );
				
				if ( module.Experience >= module.NextLevelUp ) //Leveling up.
				{
					if( module.Level == 16 && module.Experience > 1000000 )
					{
						module.Level = 0;
						module.PlayerRanks += 1;
						module.Experience = 0;
						module.RewardsClaimed += 1;
						from.StatCap += 3000;
						from.Skills.Cap += 15100;
						//from.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Rank Increase!.", from.NetState );
						from.SendMessage( "" );
						from.SendMessage( "===============================" );
						from.SendMessage( "Congrats! You have climbed in rank." );
						from.SendMessage( "Your level will be reset to zero." );
						from.SendMessage( "Your stat cap has increased by 1 point." );
						from.SendMessage( "Your skill cap has increased by 10 points." );
						from.SendMessage( "===============================" );
						from.SendMessage( "" );
						//from.PrivateOverheadMessage( MessageType.Regular, 1153, false, "", from.NetState );

						if ( from.Backpack != null ) //Prevent a crash.
						{
							LevelRewardBall l_ball = new LevelRewardBall();
							from.AddToBackpack( l_ball );
						}
						else
							from.SendMessage( "Attention: You don't have a backpack and must report this issue to the staff right away. They owe you a level reward ball" );
					}
					else if( module.Level < 16 )
					{
						module.NextLevelUp = module.NextLevelUp;
						module.Level += 1;
						module.RewardsClaimed += 1;
						//from.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Level Up!.", from.NetState );
						from.SendMessage( "" );
						from.SendMessage( "===============================" );
						from.SendMessage( "Congrats! You have gained a level." );
						from.SendMessage( "===============================" );
						from.SendMessage( "" );
						//from.PrivateOverheadMessage( MessageType.Regular, 1153, false, "", from.NetState );

						if ( from.Backpack != null ) //Prevent a crash.
						{
							LevelRewardBall l_ball = new LevelRewardBall();
							from.AddToBackpack( l_ball );
						}
						else
							from.SendMessage( "Attention: You don't have a backpack and must report this issue to the staff right away. They owe you a level reward ball" );
					}
					else
						return;
				}
				else
					return;
			}
		}
	}
}

