//Written by Lord Dalamar
using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class MessageToKnolan : Item
	{
		[Constructable]
		public MessageToKnolan() : base( 0x14F0 )
		{
			base.Weight = 1.0;
			base.Name = "Message To Knolan the Royal Alchemist";
			Hue = 1162;
		}

		public MessageToKnolan( Serial serial ) : base( serial )
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
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "Message To Knolan the Royal Alchemist!" );
		}
	}
}


