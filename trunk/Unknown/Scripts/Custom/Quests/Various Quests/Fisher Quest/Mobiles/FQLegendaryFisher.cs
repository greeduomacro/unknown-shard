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
     	public class FQLegendaryFisher : BaseGuildmaster
	    {
		public override NpcGuild NpcGuild{ get{ return NpcGuild.TailorsGuild; } }

		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public FQLegendaryFisher() : base( "Fishing" )
		{
			Name = "The Legendary Fisher";
			Female = false;

			AddItem( new SpecialFishingBoots() );
			AddItem( new SpecialFishingGloves() );
			AddItem( new SpecialFishingHat() );
			AddItem( new SpecialFishingPants() );
			AddItem( new SpecialFishingSash() );
			AddItem( new SpecialFishingShirt() );
			AddItem( new FishingPole() );
		}
	
		public FQLegendaryFisher( Serial serial ) : base( serial )
		{
		}
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new FQLegendaryFisherEntry( from, this ) ); 
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
		
		public class FQLegendaryFisherEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public FQLegendaryFisherEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( FQLegendaryFisherGump ) ) )
					{
						mobile.SendGump( new FQLegendaryFisherGump( mobile ));
						
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
				if( dropped is FQGoldenFish )
         		{
         			

					dropped.Delete();
 
				mobile.SendMessage( "Thank you for bringing my prized Golden Fish. I hope you find your reward useful." );

				switch ( Utility.Random( 6 ))
			{
				case 0: mobile.AddToBackpack( new SpecialFishingBoots() ); break;
				case 1: mobile.AddToBackpack( new SpecialFishingGloves() ); break;
				case 2: mobile.AddToBackpack( new SpecialFishingHat() ); break;
				case 3: mobile.AddToBackpack( new SpecialFishingPants() ); break;
				case 4: mobile.AddToBackpack( new SpecialFishingSash() ); break;
				case 5: mobile.AddToBackpack( new SpecialFishingShirt() ); break;
			}

				if ( Utility.RandomDouble() < 0.10 )
				switch ( Utility.Random( 4 ))
			{
				case 0: mobile.AddToBackpack( new PowerScroll( SkillName.Fishing, 105 ) );; break;
				case 1: mobile.AddToBackpack( new PowerScroll( SkillName.Fishing, 110 ) ); break;
				case 2: mobile.AddToBackpack( new PowerScroll( SkillName.Fishing, 115 ) ); break;
				case 3: mobile.AddToBackpack( new PowerScroll( SkillName.Fishing, 120 ) ); break;
			}
					
				return true;

         		}
				
         		else
         		{
					SayTo( from, "I have no need for that. I only want my Golden Fish back!" );
     			}
			}
			return false;

		
		}

	}
}