//////////////////////////
/// Created by Rosey1  ///  
/// thought up by Aeric///
///                    ///
//////////////////////////

using System;
using Server;
using Server.ContextMenus;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Misc;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "a wounded explorer corpse" )]
	public class Jonah : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
                
		[Constructable]
		public Jonah()
		{
			Name = "Master Jonah";
		    Title = ", the Wizard ";
            Body = 401;
            Hue = 33770;
            VirtualArmor = 50;
			CantWalk = true;

           Item hair = new Item( Utility.RandomList( 0x203B, 0x203C, 0x203D, 0x2044, 0x2045, 0x2047, 0x2049, 0x204A ) );
            hair.Hue = Utility.RandomHairHue();
		    hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem( hair );

            AddItem(new Server.Items.Skirt( Utility.RandomNeutralHue() ));
			AddItem(new Server.Items.Doublet( Utility.RandomNeutralHue() ));
            AddItem(new Server.Items.Sandals(0));

            GoldNecklace goldnecklace = new GoldNecklace();
            goldnecklace.Hue = 0;
            goldnecklace.Movable = false;
            AddItem(goldnecklace);

            GoldRing goldring = new GoldRing();
            goldring.Hue = 0;
            goldring.Movable = false;
            AddItem(goldring);
			
			Blessed = true;
			
		}
		public Jonah( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new JonahEntry( from, this ) ); 
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

		public class JonahEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public JonahEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			 public override void OnClick()
            {
                
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
				
				{

					
					Item am = mobile.Backpack.FindItemByType(typeof(JonahMarker));
					if (am != null)
					{
					    Item ss = mobile.Backpack.FindItemByType(typeof(JonahNote1));
						Item si = mobile.Backpack.FindItemByType(typeof (JonahNote2));
						Item sm = mobile.Backpack.FindItemByType(typeof(JonahNote3));
						Item sp = mobile.Backpack.FindItemByType(typeof (JonahDeath));
						
                        if ( ss == null || ss.Amount < 1 || si== null || si.Amount < 1)
						{
						mobile.SendMessage("You do not have all the required items");
						}	
						
						else
                        {
                        
                            mobile.SendGump(new JonahQuestGump2(mobile));
                            mobile.Backpack.ConsumeTotal( typeof( JonahNote1 ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( JonahNote2 ), 1 );
							mobile.Backpack.ConsumeTotal( typeof( JonahNote3 ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( JonahDeath ), 1 );
							am.Delete();
							
							switch ( Utility.Random( 1 ) )
							{
								
								case  0: mobile.AddToBackpack( new MonstrousInterredGrizzleKey() );; break;
							}
                        }
                    }
					
										else
                            {
                                mobile.SendGump(new JonahQuestGump(mobile));
							
                            }
					
                    
                }
				
				
				
            }
		}

		
	}
}
