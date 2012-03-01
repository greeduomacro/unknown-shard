using System;

namespace Server.Items
{

	[Furniture]
	public class ElegantLowTable : BaseFurniture
	{
		[Constructable]
		public ElegantLowTable() : base(0x2819)
		{
			Weight = 1.0;
		}

		public ElegantLowTable(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Furniture]
	public class PlainLowTable : BaseFurniture
	{
		[Constructable]
		public PlainLowTable() : base(0x281A)
		{
			Weight = 1.0;
		}

		public PlainLowTable(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Furniture]
	[Flipable(0xB90,0xB7D)]
	public class LargeTable : BaseFurniture
	{
		[Constructable]
		public LargeTable() : base(0xB90)
		{
			Weight = 1.0;
		}

		public LargeTable(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

	[Furniture]
	[Flipable(0xB35,0xB34)]
	public class Nightstand : BaseFurniture
	{
		[Constructable]
		public Nightstand() : base(0xB35)
		{
			Weight = 1.0;
		}

		public Nightstand(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

	[Furniture]
	[Flipable(0xB8F,0xB7C)]
	public class YewWoodTable : BaseFurniture
	{
		[Constructable]
		public YewWoodTable() : base(0xB8F)
		{
			Weight = 1.0;
		}

		public YewWoodTable(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}
}