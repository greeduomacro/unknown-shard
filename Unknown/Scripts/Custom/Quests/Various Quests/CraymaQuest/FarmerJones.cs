using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Commands;

namespace Server.Mobiles
{
	[CorpseName( "Good luck getting a reward now" )]
	public class FarmerJones : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public FarmerJones()
		{
			Name = "Jones";
                        Title = "the Farmer";
			Body = 0x190;
			CantWalk = true;
			Hue = Utility.RandomSkinHue();

			Item Boots = new Boots();
			Boots.Hue = 2829;
      	    Boots.Name = "Non-Leather Boots";
			Boots.Movable = false;
			AddItem( Boots ); 

			Item FancyShirt = new FancyShirt();
			FancyShirt.Hue = 2829;
      	    FancyShirt.Name = "Shirt";
			FancyShirt.Movable = false;
			AddItem( FancyShirt ); 

			Item LongPants = new LongPants();
			LongPants.Hue = 847;
      	    LongPants.Name = "Pants";
			LongPants.Movable = false;
			AddItem( LongPants ); 

			Item Pitchfork = new Pitchfork();
			//Cloak.Hue = 1267;
      	    Pitchfork.Name = "Farm Tool";
			Pitchfork.Movable = false;
			AddItem( Pitchfork ); 




                        int hairHue = 1814;

			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new PonyTail( hairHue ) ); break;
				case 1: AddItem( new Goatee( hairHue ) ); break;
			} 
			
			Blessed = true;
			
			}



		public FarmerJones( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new FarmerJonesEntry( from, this ) ); 
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

		public class FarmerJonesEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public FarmerJonesEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( JonesquestGump ) ) )
					{
						mobile.SendGump( new JonesquestGump( mobile ));
						//mobile.AddToBackpack( new DrIvanBook() );
						
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
				if( dropped is CraymaCrap)
         		{
         			if(dropped.Amount!=20)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "That is not the amount I asked for.", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new NobleSword() );

				
					return true;
         		}
				else if ( dropped is CraymaCrap)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I did not ask for this item.", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
