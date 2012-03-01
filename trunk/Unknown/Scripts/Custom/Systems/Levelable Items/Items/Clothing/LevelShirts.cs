using System;

namespace Server.Items
{
	public abstract class BaseLevelShirt : BaseLevelClothing
	{
		public BaseLevelShirt( int itemID ) : this( itemID, 0 )
		{
		}

		public BaseLevelShirt( int itemID, int hue ) : base( itemID, Layer.Shirt, hue )
		{
		}

		public BaseLevelShirt( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1efd, 0x1efe )]
	public class LevelFancyShirt : BaseLevelShirt
	{
		[Constructable]
		public LevelFancyShirt() : this( 0 )
		{
		}

		[Constructable]
		public LevelFancyShirt( int hue ) : base( 0x1EFD, hue )
		{
			Weight = 2.0;
		}

        public LevelFancyShirt(Serial serial)
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

	[FlipableAttribute( 0x1517, 0x1518 )]
	public class LevelShirt : BaseLevelShirt
	{
		[Constructable]
		public LevelShirt() : this( 0 )
		{
		}

		[Constructable]
		public LevelShirt( int hue ) : base( 0x1517, hue )
		{
			Weight = 1.0;
		}

        public LevelShirt(Serial serial)
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

			if ( Weight == 2.0 )
				Weight = 1.0;
		}
	}

	[Flipable( 0x2794, 0x27DF )]
	public class LevelClothNinjaJacket : BaseLevelShirt
	{
		[Constructable]
		public LevelClothNinjaJacket() : this( 0 )
		{
		}

		[Constructable]
		public LevelClothNinjaJacket( int hue ) : base( 0x2794, hue )
		{
			Weight = 5.0;
			Layer = Layer.InnerTorso;
		}

        public LevelClothNinjaJacket(Serial serial)
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

	public class LevelElvenShirt : BaseLevelShirt
	{
		public override Race RequiredRace { get { return Race.Elf; } }

		[Constructable]
		public LevelElvenShirt() : this( 0 )
		{
		}

		[Constructable]
		public LevelElvenShirt( int hue ) : base( 0x3175, hue )
		{
			Weight = 2.0;
		}

        public LevelElvenShirt(Serial serial)
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public class LevelElvenDarkShirt : BaseLevelShirt
	{
		public override Race RequiredRace { get { return Race.Elf; } }
		[Constructable]
		public LevelElvenDarkShirt() : this( 0 )
		{
		}

		[Constructable]
		public LevelElvenDarkShirt( int hue ) : base( 0x3176, hue )
		{
			Weight = 2.0;
		}

        public LevelElvenDarkShirt(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}