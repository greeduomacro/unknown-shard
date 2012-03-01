using System;
using Server.Network;
using Server.Items;


namespace Server.Items
{
	public class Charm : Item
	{
		private static bool isactive = false;
		
		[Constructable]
		public Charm() : base( 0xE73 )
		{
			Weight = 1.0;
			Name = "Charm";
		}
		
		public override bool OnDroppedInto( Mobile from, Container target, Point3D p )
		{
			if( target == from.Backpack || target.IsChildOf( from.Backpack) )
			{
				from.Str += 5;
				isactive = true;
			}
			return base.OnDroppedInto(from,target,p);
		}
		
		public override void OnItemLifted( Mobile from, Item item )
		{
			if( item.IsChildOf( from.Backpack) )
			{
				from.Str -= 5;
				isactive = false;
			}
			base.OnItemLifted(from,item);
		}
		
		public Charm( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write( (bool) isactive );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch( version )
			{
				case 0:
					{
						isactive = reader.ReadBool();
						break;
					}
			}
		}
	}
}
