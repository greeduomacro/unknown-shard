using System; 
using Server; 
using Server.Gumps; 
using Server.Network; 
using Server.Menus; 
using Server.Menus.Questions; 

namespace Server.Items 
{ 
	public class SETravelingWand : Item
		{ 
			[Constructable] 
				public SETravelingWand() : base( 0xDF2 ) 
					{ 
						Hue = 1161; 
						Movable = true; 
						Name = "Mystical Wand of Traveling"; 
						LootType = LootType.Blessed;
					} 

	public SETravelingWand( Serial serial ) : base( serial ) 
		{ 
		} 

	public override void OnDoubleClick( Mobile from ) 
		{ 
			from.SendGump( new SETravelingWandGump( from ) ); 
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
