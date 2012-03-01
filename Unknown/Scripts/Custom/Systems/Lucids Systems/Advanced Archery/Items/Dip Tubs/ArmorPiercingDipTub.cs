/*  _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2005 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \     lucidnagual@gmail.com     \
    \_     ===================      \
     \   -Admin of "The Conjuring"-  \
      \_     ===================     ~\
       )      Advanced Archery         )
      /~      Version [2].0.1        _/
    _/_______________________________/
 -=(_)_______________________________)=-
 */
using System;
using Server;
using Server.Targeting;
using Server.HuePickers;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;


namespace Server.Items
{
	public class ArmorPiercingDipTub : BaseTub
	{
		private int i_Owner, i_Charges;
		
		public int Owner { get{ return i_Owner; } set{ i_Owner = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges { get{ return i_Charges; } set{ i_Charges = value; InvalidateProperties(); } }
		
		[Constructable]
		public ArmorPiercingDipTub() : this ( 50, 0 )
		{
		}
		
		[Constructable]
		public ArmorPiercingDipTub( int charges, int owner ) : base ( 0xFAB )
		{
			Name = "Armor Piercing Dip Tub";
			Charges = charges;
			Owner = owner;
			Hue = 1153;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				if (i_Charges >= 1 )
					from.Target = new InternalTarget( this );
				
				else if ( i_Charges < 1 )
					from.SendMessage( "You don't have enough charges to poison anymore." );
			}
		}
		
		public ArmorPiercingDipTub( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write( (int) i_Charges );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			i_Charges = reader.ReadInt();
		}
		
		public override void AddNameProperties( ObjectPropertyList list )
		{
			AddNameProperty( list );
			
			if (Charges < 1)
				list.Add("{0} without charges", Name);
			else
				list.Add("{0} with {1} charges", Name, Charges);
			
			if ( IsSecure )
				AddSecureProperty( list );
			else if ( IsLockedDown )
				AddLockedDownProperty( list );
			
			if ( DisplayLootType )
				AddLootTypeProperty( list );
		}
		
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
		}
		
		
		private class InternalTarget : Target
		{
			private ArmorPiercingDipTub it_Tub;
			
			public InternalTarget( ArmorPiercingDipTub tub ) : base( 1, false, TargetFlags.None )
			{
				it_Tub = tub;
			}
			
			protected override void OnTarget( Mobile from, object targeted )
			{
				Arrow arrow = targeted as Arrow;
				Bolt bolt = targeted as Bolt;
				Item item = targeted as Item;

				if ( targeted is PlayerMobile || targeted is BaseCreature )
					from.SendMessage( "You cannot target that." );
						
				if ( targeted != null && targeted is Arrow )
				{
					if ( it_Tub != null )
					{
						if (!( item.IsChildOf(from.Backpack )))
						{
							from.SendMessage( "This must be in your backpack." );
						}
						else if ( item.IsChildOf(from.Backpack ) && arrow.Amount == 20 )
						{
							from.SendMessage( "You carefully apply the armor piercing material to your bundle of arrows." );
							
							it_Tub.Charges--;
							arrow.Consume( 20 );
							//Note: pack.ConsumeTotal( typeof(Arrow), 20 )
							from.AddToBackpack( new ArmorPiercingArrow( 20 ) );
						}
						else if ( targeted != null && arrow.Amount != 20 )
							from.SendMessage( "You must use a bundle of 20 at a time." );
					}
					else
						return;
				}
				else if ( targeted != null && targeted is Bolt )
				{
					if ( it_Tub != null )
					{
						if (!( item.IsChildOf(from.Backpack )))
						{
							from.SendMessage( "This must be in your backpack." );
						}
						else if ( item.IsChildOf(from.Backpack ) && bolt.Amount == 20 )
						{
							from.SendMessage( "You carefully apply the armor piercing material to your bundle of bolts." );
							
							it_Tub.Charges--;
							bolt.Consume( 20 );
							//Note: pack.ConsumeTotal( typeof(Bolt), 20 )
							from.AddToBackpack( new ArmorPiercingBolt( 20 ) );
						}
						else if ( targeted != null && bolt.Amount != 20 )
							from.SendMessage( "You must use a bundle of 20 bolts at a time." );
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
