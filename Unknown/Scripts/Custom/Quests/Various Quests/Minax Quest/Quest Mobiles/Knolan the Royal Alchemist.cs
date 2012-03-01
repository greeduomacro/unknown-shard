//Written by Lord Dalamar
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

namespace Server.Mobiles
{
	[CorpseName( "Corpse of Knolan the Royal Alchemist" )]
	public class KnolanAlchemist : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public KnolanAlchemist()
		{
			Name = "Knolan";
			Title = "the Royal Alchemist";
			Body = 0x190;
			CantWalk = true;
			Hue = 33824;
			AddItem( new Sandals(1154));
			AddItem( new LongPants(204));
			AddItem( new FullApron(1154));
			AddItem( new FancyShirt(204));
			AddItem( new Goatee(1154));
			AddItem( new LongHair(1154));
		}

		public KnolanAlchemist( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new KnolanAlchemistEntry( from, this ) ); 
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

		public class KnolanAlchemistEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public KnolanAlchemistEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( KnolanGump ) ) )
					{
						mobile.SendGump( new KnolanGump( mobile ));
						
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
				if( dropped is MessageToKnolan )
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "That is not the amount I asked for!", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new MinaxCrystal() );
				
					return true;
         		}
				else if ( dropped is MessageToKnolan)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "What do I want with that?  Maybe something else...?", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
