using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Engines.Quests;

namespace Server.Mobiles
{
	[CorpseName( "Master of The Magi Corpse" )]
	public class MasterMagi : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
                
		[Constructable]
		public MasterMagi()
		{
			Name = "Magicus";
                        		Title = "the Master of the Magi";
			Body = 0x190;
			CantWalk = true;
			Hue = Utility.RandomSkinHue();
			AddItem( new Server.Items.HatOfTheMagi() );
			AddItem( new Server.Items.StaffOfTheMagi() );
			AddItem( new Server.Items.CloakOfTheMagi() );
			AddItem( new Server.Items.SashOfTheMagi() );
			AddItem( new Server.Items.Legsofthemagi() );
			AddItem( new Server.Items.Chestofthemagi() );
			AddItem( new Server.Items.Glovesofthemagi() );
			AddItem( new Server.Items.Gorgetofthemagi() );
			AddItem( new Server.Items.Armsofthemagi() );
                        		int hairHue = 1153;
			
			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new LongHair( hairHue ) ); break;
			} 
			Blessed = true;
			
		}
		public MasterMagi( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new MasterMagiEntry( from, this ) ); 
	        } 

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public class MasterMagiEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public MasterMagiEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
				

                          if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;

				{
					if ( ! mobile.HasGump( typeof( MagiQuestGump ) ) )
					{
						mobile.SendGump( new MagiQuestGump( mobile ));
						
					} 
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is MagiScroll )
         			{
         			Container pack = from.Backpack;
	
				if ( pack != null && pack.ConsumeTotal( typeof( MagiOre ), 1 ) )
				{
					if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop 
					switch ( Utility.Random( 10 ))  
					{ 
		
							case 0: mobile.AddToBackpack( new Chestofthemagi() ); break;
							case 1: mobile.AddToBackpack( new ChestoftheFemaleMagi() ); break;
							case 2: mobile.AddToBackpack( new Glovesofthemagi() ); break;
							case 3: mobile.AddToBackpack( new Legsofthemagi() ); break;
							case 4: mobile.AddToBackpack( new Gorgetofthemagi() ); break;
							case 5: mobile.AddToBackpack( new Armsofthemagi() ); break;
							case 6: mobile.AddToBackpack( new StaffOfTheMagi() ); break;
							case 7: mobile.AddToBackpack( new HatOfTheMagi() ); break;
							case 8: mobile.AddToBackpack( new CloakOfTheMagi() ); break;					
							case 9: mobile.AddToBackpack( new SashOfTheMagi() ); break;

					}
				
							return true;
				}
				else
				{
					from.SendMessage(0x22,"You also need a Magi Ore before you recieve a piece of armor.");
			
				}				
					return false;
         			}
				else if ( dropped is MagiOre)
				{
					Container pack = from.Backpack;
					
					if ( pack != null && pack.ConsumeTotal( typeof( MagiScroll ), 1 ) )
					{
						if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop 
						switch ( Utility.Random( 10 ))  
						{ 
		
							case 0: mobile.AddToBackpack( new Chestofthemagi() ); break;
							case 1: mobile.AddToBackpack( new ChestoftheFemaleMagi() ); break;
							case 2: mobile.AddToBackpack( new Glovesofthemagi() ); break;
							case 3: mobile.AddToBackpack( new Legsofthemagi() ); break;
							case 4: mobile.AddToBackpack( new Gorgetofthemagi() ); break;
							case 5: mobile.AddToBackpack( new Armsofthemagi() ); break;
							case 6: mobile.AddToBackpack( new StaffOfTheMagi() ); break;
							case 7: mobile.AddToBackpack( new HatOfTheMagi() ); break;
							case 8: mobile.AddToBackpack( new CloakOfTheMagi() ); break;					
							case 9: mobile.AddToBackpack( new SashOfTheMagi() ); break;
					
						}
				
							return true;
					}
					else
					{
						from.SendMessage(0x22,"You also need a Magi Scroll before you recieve a piece of armor.");
			
					}				
						return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no need of this!", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
