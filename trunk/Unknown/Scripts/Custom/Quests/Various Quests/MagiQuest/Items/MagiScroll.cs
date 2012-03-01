using System;

namespace Server.Items
{
	public class MagiScroll : Item
	{		
		[Constructable]
		public MagiScroll() : base( 0x1F3E )
		{
			Name = "Scroll of The Magi";			
			Hue = 1150;
			Weight = 0.1;						
		}

		public MagiScroll( Serial serial ) : base( serial )
		{
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
}