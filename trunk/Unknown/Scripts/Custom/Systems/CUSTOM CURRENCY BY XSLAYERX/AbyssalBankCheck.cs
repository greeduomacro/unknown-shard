//Please Leave Credit XSlayerX aka XLacaestX
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class AbyssalCoinBankCheck : Item
	{
		private int m_Worth;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Worth
		{
			get{ return m_Worth; }
			set{ m_Worth = value; InvalidateProperties(); }
		}

		public AbyssalCoinBankCheck( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_Worth );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			LootType = LootType.Blessed;

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Worth = reader.ReadInt();
					break;
				}
			}
		}

		[Constructable]
		public AbyssalCoinBankCheck( int worth ) : base( 0x14F0 )
		{
			Name = "Abyssal Coin Bank Check";
			Weight = 0;
			Hue = 37;
			LootType = LootType.Blessed;

			m_Worth = worth;
		}

		public override bool DisplayLootType{ get{ return false; } }

		public override int LabelNumber{ get{ return 1041361; } } // A bank check

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties( list );

			list.Add( 1060738, m_Worth.ToString() ); // value: ~1_val~
		}

		public override void OnSingleClick( Mobile from )
		{
			from.Send( new MessageLocalizedAffix( Serial, ItemID, MessageType.Label, 0x3B2, 3, 1041361, "", AffixType.Append, String.Concat( " ", m_Worth.ToString() ), "" ) ); // A bank check:
		}

		public override void OnDoubleClick( Mobile from )
		{
			BankBox box = from.BankBox;

			if ( box != null && IsChildOf( box ) )
			{
				Delete();

				int deposited = 0;

				int toAdd = m_Worth;

				     Abyssalcoin Abyssalcoin;

				while ( toAdd > 60000 )
				{
					Abyssalcoin = new Abyssalcoin( 60000 );

					if ( box.TryDropItem( from, Abyssalcoin, false ) )
					{
						toAdd -= 60000;
						deposited += 60000;
					}
					else
					{
						Abyssalcoin.Delete();

						from.AddToBackpack( new AbyssalCoinBankCheck( toAdd ) );
						toAdd = 0;

						break;
					}
				}

				if ( toAdd > 0 )
				{
					Abyssalcoin = new Abyssalcoin( toAdd );

					if ( box.TryDropItem( from, Abyssalcoin, false ) )
					{
						deposited += toAdd;
					}
					else
					{
						Abyssalcoin.Delete();

						from.AddToBackpack( new AbyssalCoinBankCheck( toAdd ) );
					}
				}

				// Tokens was deposited in your Backpack:
			from.SendMessage( m_Worth/1000 + "Abyssal Coins were placed in your backpack." );
			}
			else
			{
			from.SendLocalizedMessage( 1047026 );
			}
		}
	}
}
