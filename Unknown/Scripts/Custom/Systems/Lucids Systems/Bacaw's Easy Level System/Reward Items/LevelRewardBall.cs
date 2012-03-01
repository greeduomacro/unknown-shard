using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using Server.LevelSystem;
using Server.LucidNagual;
using Server.ACC.CM;


namespace Server.Items
{
	public class LevelRewardBall : Item
	{
		[Constructable]
		public LevelRewardBall() : base( 6249 )
		{
			Name = "Level Reward Ball";
			Movable = false;
			Hue = 1153;
			LootType = LootType.Newbied;
		}
		
		private static void PlaceItemIn( Container parent, int x, int y, Item item )
		{
			parent.AddItem( item );
			item.Location = new Point3D( x, y, 0 );
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;
			PlayerModule module = pm.PlayerModule;
			
			if ( from.Backpack == null || from.BankBox == null )
			{
				from.SendMessage( "Attention: You are missing a backpack or bankbox and must report this problem to a staff member right away." );
				return;
			}
			else
			{
				Container pack = from.Backpack;
				BankBox box = from.BankBox;
				
				from.PlaySound( 0x1F7 );
				from.SendMessage( "Congrats on your promotion!" );
				
				if( module.RankPoints < 1 )
				{
					if ( module.RewardsClaimed < 7 ) //Levels 6 and below.
						PlaceItemIn( pack, 18, 18, ( new WelcomeSkillBall() ) );
					else if ( module.RewardsClaimed == 7 ) //Level 7
						PlaceItemIn( pack, 25, 169, ( new ThrowPillows() ) );
					else if ( module.RewardsClaimed == 8 ) //Level 8
						PlaceItemIn( pack, 25, 169, ( new TillerBell() ) );
					else if ( module.RewardsClaimed == 9 ) //Level 9
						PlaceItemIn( pack, 25, 169, ( new WoopieCushion() ) );
					else if ( module.RewardsClaimed == 10 ) //Level 10
						PlaceItemIn( pack, 25, 169, ( new LogoutRune() ) );
					else if ( module.RewardsClaimed == 11 ) //Level 11
						PlaceItemIn( pack, 25, 169, ( new RuneLute() ) );
					else if ( module.RewardsClaimed == 12 ) //Level 12
						PlaceItemIn( pack, 25, 169, ( new ToolBox() ) );
					else if ( module.RewardsClaimed == 13 ) //Level 13
						PlaceItemIn( pack, 25, 169, ( new Sprinkler() ) );
					else if ( module.RewardsClaimed == 14 ) //Level 14
						PlaceItemIn( pack, 25, 169, ( new Charm() ) );
					else if ( module.RewardsClaimed == 15 ) //Level 15
						PlaceItemIn( pack, 25, 169, ( new TravelWand() ) );
					else if ( module.RewardsClaimed == 16 ) //Level 16
						PlaceItemIn( pack, 25, 169, ( new HoodedRobe() ) );
					else
						return;
				}
				else if( module.RankPoints > 0 )
					PlaceItemIn( pack, 25, 250, ( new Diamond( module.RankPoints + module.RewardsClaimed ) ) );
				else
					return;
				
				if( DataCenter.EnableExpTokens )
					PlaceItemIn( pack, 25, 25, ( new ExpToken( module.RankPoints + 1 ) ) );
				
				PlaceItemIn( pack, 25, 35, ( new BankCheck( module.Level + module.RewardsClaimed * 500 ) ) );
				
				this.Delete();
			}
		}
		
		public LevelRewardBall( Serial serial ) : base( serial )
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


