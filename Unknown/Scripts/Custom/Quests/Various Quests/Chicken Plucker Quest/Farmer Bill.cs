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
     	public class FarmerBill : BaseGuildmaster
	    {
		public override NpcGuild NpcGuild{ get{ return NpcGuild.TailorsGuild; } }

		public override bool ClickTitle{ get{ return true; } }

		[Constructable]
		public FarmerBill() : base( "Chicken Rancher" )
		{
			Name = "Farmer Bill";
			Title = "The Famous Chicken Rancher";
			Female = true;			

			SetSkill( SkillName.AnimalLore, 200, 500 );
			SetSkill( SkillName.Anatomy, 200, 500 );
			SetSkill( SkillName.AnimalTaming, 200, 500 );
			SetSkill( SkillName.Meditation, 200, 500 );
			SetSkill( SkillName.Wrestling, 200, 500 );
		}

		public override VendorShoeType ShoeType
		{
			get{ return VendorShoeType.Boots; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			Item item = ( Utility.RandomBool() ? null : new Server.Items.FancyShirt() );

			if ( item != null && !EquipItem( item ) )
			{
				item.Delete();
				item = null;
			}

			if ( item == null )
				AddItem( new Server.Items.LongPants() );

			AddItem( new Server.Items.ShepherdsCrook() );
		}

		
		public FarmerBill( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new FarmerBillEntry( from, this ) ); 
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
		
		public class FarmerBillEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public FarmerBillEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( FarmerBillGump ) ) )
					{
						mobile.SendGump( new FarmerBillGump( mobile ));
						
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
				if( dropped is OrderList )
         		{
         			

					dropped.Delete(); 
				mobile.SendMessage( "Farmer Bill has given you your reward" );
				mobile.AddToBackpack( new Gold( 1000 ) );

         		switch (Utility.Random( 11 )) 
		{
         			case 0: mobile.AddToBackpack( new RunicHammer( CraftResource.DullCopper, Core.AOS ? 50 : 50 ) ); break;
         			case 1: mobile.AddToBackpack( new RunicHammer( CraftResource.ShadowIron, Core.AOS ? 50 : 50 ) ); break;
				case 2: mobile.AddToBackpack( new RunicHammer( CraftResource.Copper, Core.AOS ? 50 : 50 ) ); break;
				case 3: mobile.AddToBackpack( new RunicHammer( CraftResource.Bronze, Core.AOS ? 50 : 50 ) ); break;
				case 4: mobile.AddToBackpack( new RunicHammer( CraftResource.Gold, Core.AOS ? 50 : 50 ) ); break;
				case 5: mobile.AddToBackpack( new RunicHammer( CraftResource.Agapite, Core.AOS ? 50 : 50 ) ); break;
				case 6: mobile.AddToBackpack( new RunicHammer( CraftResource.Verite, Core.AOS ? 50 : 50 ) ); break;
				case 7: mobile.AddToBackpack( new RunicHammer( CraftResource.Valorite, Core.AOS ? 50 : 50 ) ); break;
				case 8:mobile.AddToBackpack( new RunicSewingKit( CraftResource.SpinedLeather, Core.AOS ? 50 : 50 ) );; break;
				case 9:mobile.AddToBackpack( new RunicSewingKit( CraftResource.HornedLeather, Core.AOS ? 50 : 50 ) );; break;
				case 10:mobile.AddToBackpack( new RunicSewingKit( CraftResource.BarbedLeather, Core.AOS ? 50 : 50 ) );; break;
         			
		}
         			
				

					return true;
         		}
				
         		else
         		{
					SayTo( from, "I have no need for that, go back to that same area, find my corrupted chicken, bag him and bring me his loot!!" );
     			}
			}
			return false;

		
		}

	}
}