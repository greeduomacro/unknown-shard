using System;

namespace Server.Items
{
    public abstract class BaseLevelRing : BaseLevelJewel
	{
		public override int BaseGemTypeNumber{ get{ return 1044176; } } // star sapphire ring

		public BaseLevelRing( int itemID ) : base( itemID, Layer.Ring )
		{
		}

		public BaseLevelRing( Serial serial ) : base( serial )
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

	public class LevelGoldRing : BaseLevelRing
	{
		[Constructable]
		public LevelGoldRing() : base( 0x108a )
		{
			Weight = 0.1;
		}

        public LevelGoldRing(Serial serial)
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

	public class LevelSilverRing : BaseLevelRing
	{
		[Constructable]
		public LevelSilverRing() : base( 0x1F09 )
		{
			Weight = 0.1;
		}

        public LevelSilverRing(Serial serial)
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
