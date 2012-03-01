/// Trash 4 Gold Trash Barrel v0.1
///created by Doctor Who
using System;
using System.Collections;
using Server.Multis;
using Server.ContextMenus;
using System.Collections.Generic;


namespace Server.Items
{
	public class Trash4GoldTrashBarrel : Container
	{
		public override int MaxWeight{ get{ return 0; } } // A value of 0 signals unlimited weight
		public override int DefaultGumpID{ get{ return 0x3C; } }
		public override int DefaultDropSound{ get{ return 0x50; } }

		private DateTime m_LastTrash;
		public DateTime LastTrash{ get{ return m_LastTrash; } set{ m_LastTrash = value; } }


		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 18, 105, 144, 73 ); }
		}

		[Constructable]
		public Trash4GoldTrashBarrel() : base( 0x9b2 )
		{
			Name = "Trash 4 Gold Trash Barrel"; 
			Hue = 1174;
			ItemID = 3703;
                                                LiftOverride = true;
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( from == null || dropped == null )
				return false;
			
			List<Item> items = this.Items;
			
			if ( items.Count > 0 && m_LastTrash <= DateTime.Now)
			{
				Empty(from);
				from.SendMessage("3 minutes safety was over clearing trash before adding more");
			}
			//TotalWeight = 0;
			if ( !base.OnDragDrop( from, dropped ) )
				return false;
			m_LastTrash = (DateTime.Now + TimeSpan.FromMinutes( 3 ));
			return true;
		}

		public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
		{
			if ( from == null || item == null )
				return false;
			
			List<Item> items = this.Items;
			
			if ( items.Count > 0 && m_LastTrash <= DateTime.Now)
			{
				Empty(from);
				from.SendMessage("3 minutes safety was over clearing trash before adding more");
			}
			//TotalWeight = 0;
			if ( !base.OnDragDropInto( from, item, p ) )
				return false;
			m_LastTrash = (DateTime.Now + TimeSpan.FromMinutes( 3 ));
			return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from == null )
				return;
			
			List<Item> items = this.Items;
			
			if ( items.Count > 0 && m_LastTrash <= DateTime.Now)
			{
				Empty(from);
				from.SendMessage("The 3 minutes safety was over, you can not recover the items.");
			}
			base.OnDoubleClick(from);
		}

		public override void OnItemRemoved( Item item ) 
		{ 
			if ( item == null )
				return;
			
			if (m_LastTrash <= DateTime.Now)
			{
				item.Delete();
				Empty();
			}
			else 
				base.OnItemRemoved( item );
			//TotalWeight = 0;
		} 

		public override void UpdateTotals()
		{
			base.UpdateTotals();
			//SetTotalWeight( 0 );
		}

		public override void OnItemAdded( Item item )
		{
			base.OnItemAdded( item );
			//TotalWeight = 0;
		}

		public void Empty()
		{
			List<Item> items = this.Items;
			
			if ( items.Count > 0 )
			{
				Mobile from = RootParent as Mobile;
				
				if ( from != null )
				{
					from.SendMessage( "You passed the 3 minutes safety, you can't recover the items." );
					Empty(from);
				}
				else
				{
					for ( int i = items.Count - 1; i >= 0; --i )
					{
						if ( i >= items.Count )
							continue;
						((Item)items[i]).Delete();
					}
				}
			}
		}

		public void Empty( Mobile from )
		{
			if ( from == null )
				return;
			
			EmptyTrash( from, this );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			if ( from == null )
				return;
			
			base.GetContextMenuEntries( from, list );
			List<Item> items = this.Items;
			if ( items.Count > 0 )
				list.Add( new EmptyTrash4GoldTrashBarrel( from, this ) );
		}

		public Trash4GoldTrashBarrel( Serial serial ) : base( serial )
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
			
			m_LastTrash = DateTime.Now;
		}

		
		public static void EmptyTrash(Mobile from, Item item)
		{
			if ( from == null || item == null )
				return;
			
			List<Item> items = item.Items;
			
			if ( items.Count > 0 )
			{
				int i_Reward = 0;
				from.PlaySound(0x76);
				for ( int i = items.Count - 1; i >= 0; --i )
				{
					if ( i >= items.Count )
						continue;
					Item it = (Item)items[i] as Item;
					if ( it.Stackable == false && !(item is BaseBook) )
						i_Reward += Utility.RandomMinMax(2,5);
					((Item)items[i]).Delete();
							
						
							from.AddToBackpack( new Gold(1) );
							i_Reward -= 1;
						}
					}
				}

		public class EmptyTrash4GoldTrashBarrel : ContextMenuEntry
		{
			private Mobile m_From;
			private Item m_Item;

			public EmptyTrash4GoldTrashBarrel( Mobile from, Item item ) : base( 0154, 5 )
			{
				m_From = from;
				m_Item = item;
			}

			public override void OnClick()
			{
				EmptyTrash(m_From, m_Item);
			}
		}
	}
}

