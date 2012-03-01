using System;
using System.Net;
using Server;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Regions;
using System.Collections;
using Server.Engines.PartySystem;

namespace Server.Items
{

	public class DreadhornKey : Item
	{

		[Constructable]
		public DreadhornKey() : this( null )
		{
		}
		
		[Constructable]
		public DreadhornKey( string name ) : base( 0x2258 )
		{
			Name = "Dreadhorn Teleporter. Dont Spawn Here till you use this!";
			LootType = LootType.Blessed;
		}
		
		public DreadhornKey( Serial serial ) : base( serial )
		{
		}
		
		public override void OnDoubleClick( Mobile from )
		{			
			ArrayList list = new ArrayList();
			
			foreach ( Mobile m in World.Mobiles.Values )
			{
				if ( m is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)m;
					
					if ( bc is DreadHorn )
						list.Add( bc );
				}
			}
			if ( list.Count > 0 )
				from.SendMessage( "A Party is Already in Battle With Dreadhorn. Please Wait" );

			
			else
			{
				from.SendGump( new DreadhornGump( from, this ) );
			}
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
	}

	
	
		public class DreadhornGump : Gump
		{
		private Mobile m_Mobile;
		private Item m_Deed;
		
		public DreadhornGump( Mobile from, Item deed ) : base( 30, 20 )
		{
			m_Mobile = from;
			m_Deed = deed;
						
			Account a = from.Account as Account;
			
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );
			AddImageTiled( 416, 39, 44, 389, 203 );			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Destroy Dreadhorn" );
			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 136, 84, 96 );
			AddImage( 215, 150, 5536 );

			AddButton( 225, 390, 0xF7, 0xF8, 1, GumpButtonType.Reply, 0 );
			
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			
			switch( info.ButtonID )
			{
				case 0:
					{
						from.CloseGump( typeof( DreadhornGump ) );
						break;
					}
								case 1: //Case uses the ActionIDs defenied above. Case 1 defenies the actions for the button with the action id 1 
					{
						Party party = Party.Get( from );

						if( party != null )
						{
							for( int i = 0; i < party.Count; i++ )
							{
								Mobile m = party[ i ].Mobile;

								if( Utility.InRange( from.Location, m.Location, 6 ) )
								{
									m.MoveToWorld( new Point3D( 2153, 1262, -60 ), Map.Ilshenar );
									DreadHorn dh = new DreadHorn();
                                    dh.MoveToWorld( new Point3D( 2139, 1249, -60 ), Map.Ilshenar );
									m_Deed.Delete(); // Delete the deed
								}
							}
						}
						else
						{
							from.MoveToWorld( new Point3D( 2153, 1262, -60 ), Map.Ilshenar );
							DreadHorn dh = new DreadHorn();
                            dh.MoveToWorld( new Point3D( 2139, 1249, -60 ), Map.Ilshenar );
							m_Deed.Delete();
							
						}
                                                break;
					}
			}
		}
	}
}