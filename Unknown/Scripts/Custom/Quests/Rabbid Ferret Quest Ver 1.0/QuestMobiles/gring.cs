// by evilfreak for the rabbid ferret quest v1.0

using System;



namespace Server.Items
{
	public abstract class CaseBracelet : BaseJewel
	{
		public override int BaseGemTypeNumber{ get{ return 1044221; } } // star sapphire bracelet

		public CaseBracelet( int itemID ) : base( itemID, Layer.Bracelet )
		{
		}

		public CaseBracelet( Serial serial ) : base( serial )
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
	}

	public class GrandmasBrace : BaseBracelet
	{
		[Constructable]
		public GrandmasBrace() : base( 0x1F06 )
		{
			
			LootType = LootType.Blessed;
			Hue = 1153;
			Weight = 0.1;
		}

		public GrandmasBrace( Serial serial ) : base( serial )
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
	}
}