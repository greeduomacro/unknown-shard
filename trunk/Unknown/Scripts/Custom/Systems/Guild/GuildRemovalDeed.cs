using System;
using Server.Network;
using Server.Guilds;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class GuildRemovalDeed : Item
	{


		public override string DefaultName
		{
			get { return "a guild removal deed"; }
		}

		[Constructable]
		public GuildRemovalDeed() : base( 0x14F0 )
		{
			base.Weight = 1.0;
		}

		public GuildRemovalDeed( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			Guild m_Guild = from.Guild as Guild;

			if (m_Guild == null)
				return;
			else{
			m_Guild.RemoveMember( from );
			Delete();
			}
				
		}
	}
}












