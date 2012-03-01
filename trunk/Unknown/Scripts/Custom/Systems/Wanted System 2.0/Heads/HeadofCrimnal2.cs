using System;
using Server;

namespace Server.Items
{
	public class HeadofXerian : Item
	{
		public override int LabelNumber{ get{ return 1063489; } }
		
		[Constructable]
		public HeadofXerian() : base( 0x1DA0 )
		{

			Name = "Xerian's Head";
			Weight = 0.1;
			Hue = 0;

		}

		public HeadofXerian( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}