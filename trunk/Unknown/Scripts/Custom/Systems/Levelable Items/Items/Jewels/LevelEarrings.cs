using System;

namespace Server.Items
{
    public abstract class BaseLevelEarrings : BaseLevelJewel
	{
		public override int BaseGemTypeNumber{ get{ return 1044203; } } // star sapphire earrings

		public BaseLevelEarrings( int itemID ) : base( itemID, Layer.Earrings )
		{
		}

		public BaseLevelEarrings( Serial serial ) : base( serial )
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

	public class LevelGoldEarrings : BaseLevelEarrings
	{
		[Constructable]
		public LevelGoldEarrings() : base( 0x1087 )
		{
			Weight = 0.1;
		}

        public LevelGoldEarrings(Serial serial)
            : base(serial)
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

	public class LevelSilverEarrings : BaseLevelEarrings
	{
		[Constructable]
		public LevelSilverEarrings() : base( 0x1F07 )
		{
			Weight = 0.1;
		}

        public LevelSilverEarrings(Serial serial)
            : base(serial)
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