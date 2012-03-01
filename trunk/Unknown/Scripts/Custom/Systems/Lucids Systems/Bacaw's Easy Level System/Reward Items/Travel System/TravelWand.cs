using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Menus;
using Server.Menus.Questions;

namespace Server.Items
{
	public class TravelWand : Item
	{
		[Constructable]
		public TravelWand() : base( 0xDF2 )
		{
			Hue = 1161;
			Movable = true;
			Name = "a Wand of Safe Passage";
			LootType = LootType.Blessed;
		}
		
		public TravelWand( Serial serial ) : base( serial )
		{
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			from.SendGump( new TravelWandGump( from ) );
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
	}
}
