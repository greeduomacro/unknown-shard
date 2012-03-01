using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class DesEnergyFieldSouth : DamageableItem
	{
		[Constructable]
		public DesEnergyFieldSouth( )
			: base( 14662, 14695, 12696 )
		{
			Name = "energy field";

			Level = ItemLevel.VeryHard;
			DropsLoot = false;
		}

		public DesEnergyFieldSouth( Serial serial )
			: base( serial )
		{
		}

		public override void OnDestroyed( WoodenBox lootbox )
		{

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

	public class DesEnergyFieldEast : DamageableItem
	{
		[Constructable]
		public DesEnergyFieldEast( )
			: base( 14678, 14713, 12696 )
		{
			Name = "energy field";

			Level = ItemLevel.VeryHard;
			DropsLoot = false;
		}

		public DesEnergyFieldEast( Serial serial )
			: base( serial )
		{
		}

		public override void OnDestroyed( WoodenBox lootbox )
		{
			
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