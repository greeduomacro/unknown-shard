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
using Server.Accounting;

namespace Server.Mobiles
{
	[CorpseName( "Argyle's corpse" )]
	public class Argyle : Mobile
	{
		public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public Argyle()
		{
			Name = "Argyle";
			Title = "the Wandering Mage";
			Body = 400;
			CantWalk = true;
			
			AddItem( new Server.Items.Boots() );
			AddItem( new Server.Items.Cloak(113) );
			AddItem( new Server.Items.Robe(1366) );
			
			
			AddItem( new LongHair(1001));
			
		}
		
		public Argyle( Serial serial ) : base( serial )
		{
		}
		
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new LotharEntry( from, this ) );
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
		
		public class LotharEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public LotharEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ArgyleStartGump ) ) )
					{
						mobile.SendGump( new ArgyleStartGump( mobile ));
						mobile.AddToBackpack( new EmptyRuneBook() );
						mobile.AddToBackpack( new ArgyleBook() );
						
					}
				}
			}
		}
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
			Account acct=(Account)from.Account;
			bool SETravelingWandReceived = Convert.ToBoolean( acct.GetTag("SETravelingWandReceived") );

			if ( mobile != null)
			{
				if( dropped is FullRuneBook )
         		
         			
					if ( !SETravelingWandReceived ) //added account tag check
		                {
					dropped.Delete(); 
					mobile.AddToBackpack( new SETravelingWand() );
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Thank you for your help!  Take this wand to aid you in your future travels!", mobile.NetState );
                                        acct.SetTag( "SETravelingWandReceived", "false" );

				
         		        }
				else //what to do if account has already been tagged
         			{
         				this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Thank you for bringing me another full rune book!", mobile.NetState );
         				mobile.AddToBackpack( new Gold( 5000 ) );
         				dropped.Delete();
         			}
         		}
				else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no need for this item.", mobile.NetState );
     			}
			return false;
		}
	}
}