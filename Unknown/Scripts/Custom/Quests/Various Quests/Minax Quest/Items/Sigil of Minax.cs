//Written by Lord Dalamar
using System;
using Server.Network;
using Server.Prompts;
using Server.Guilds;
using Server.Multis;
using Server.Regions;

namespace Server.Items
{
	public class SigilofMinax : Item
	{
		private Item m_Stone;

		public override int LabelNumber{ get{ return 1041054; } } // Sigil of Minax

		[Constructable]
		public SigilofMinax() : this( null )
		{
		}

		public SigilofMinax( Item stone ) : base( 0x1869 )
		{
			Weight = 1.0;
			Name = "Sigil of Minax";
			Hue = 1172;
			LootType = LootType.Cursed;

			m_Stone = stone;
		}

		public SigilofMinax( Serial serial ) : base( serial )
		{
		}

		public override bool DisplayLootType{ get{ return false; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Stone );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			LootType = LootType.Cursed;

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Stone = reader.ReadItem();

					break;
				}
			}

			if ( Weight == 0.0 )
				Weight = 1.0;
		}

	}
}