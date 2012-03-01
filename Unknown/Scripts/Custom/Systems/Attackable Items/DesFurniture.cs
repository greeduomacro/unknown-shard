using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class DesBookCaseSouth : DamageableItem
	{
		[Constructable]
		public DesBookCaseSouth( )
			: base( 2715, 3092, 3094 )
		{
			Name = "Book Case";

			Level = ItemLevel.Easy;
			DropsLoot = true;
		}

		public DesBookCaseSouth( Serial serial )
			: base( serial )
		{
		}

		public override void OnDestroyed( WoodenBox lootbox )
		{
			Item book;

			if( Utility.RandomBool( ) )
			{
				book = new BlueBook( );
			}
			else
			{
				book = new BrownBook( );
			}

			if( book != null || !book.Deleted )
				lootbox.DropItem( book );

			if( Utility.RandomDouble( ) < 0.25 )
			{
				Item loot;

				if( Utility.RandomBool( ) )
				{
					loot = new ScribesPen( );
				}
				else
				{
					loot = new MapmakersPen( );
				}

				if( loot != null || !loot.Deleted )
					lootbox.DropItem( loot );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt( );
		}
	}

	public class DesBookCaseEast : DamageableItem
	{
		[Constructable]
		public DesBookCaseEast( )
			: base( 2716, 3093, 3094 )
		{
			Name = "Book Case";

			Level = ItemLevel.Easy;
			DropsLoot = true;
		}

		public DesBookCaseEast( Serial serial )
			: base( serial )
		{
		}

		public override void OnDestroyed( WoodenBox lootbox )
		{
			Item book;

			if( Utility.RandomBool( ) )
			{
				book = new BlueBook( );
			}
			else
			{
				book = new BrownBook( );
			}

			if( book != null || !book.Deleted )
				lootbox.DropItem( book );

			if( Utility.RandomDouble( ) < 0.25 )
			{
				Item loot;

				if( Utility.RandomBool( ) )
				{
					loot = new ScribesPen( );
				}
				else
				{
					loot = new MapmakersPen( );
				}

				if( loot != null || !loot.Deleted )
					lootbox.DropItem( loot );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt( );
		}
	}

}