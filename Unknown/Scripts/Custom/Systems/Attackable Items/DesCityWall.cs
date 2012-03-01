using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class DesCityWallSouth : DamageableItem
	{
		[Constructable]
		public DesCityWallSouth( )
			: base( 641, 631, 632 )
		{
			Name = "City Wall";

			Level = ItemLevel.Hard;
			DropsLoot = false;
		}

		public DesCityWallSouth( Serial serial )
			: base( serial )
		{
		}

		public override void OnDestroyed( WoodenBox lootbox )
		{
			if( Utility.RandomDouble( ) < 0.25 )
			{
				lootbox.DropItem( new IronOre( Utility.RandomMinMax( 1, 8 ) ) );
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

	public class DesCityWallEast : DamageableItem
	{
		[Constructable]
		public DesCityWallEast( )
			: base( 642, 636, 633 )
		{
			Name = "City Wall";

			Level = ItemLevel.Hard;
			DropsLoot = false;
		}

		public DesCityWallEast( Serial serial )
			: base( serial )
		{
		}

		public override void OnDestroyed( WoodenBox lootbox )
		{
			if( Utility.RandomDouble( ) < 0.25 )
			{
				lootbox.DropItem( new IronOre( Utility.RandomMinMax( 1, 8 ) ) );
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