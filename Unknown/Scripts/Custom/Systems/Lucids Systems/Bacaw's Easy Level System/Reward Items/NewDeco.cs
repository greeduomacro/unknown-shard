using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1A04, 0x1A03 )]
	public class NoBootSkeleton : Item
	{
		[Constructable]
		public NoBootSkeleton() : base( 0x1A04 )
		{
			Weight = 1.0;
			Name = "a decayed skeleton";
		}

		public NoBootSkeleton( Serial serial ) : base( serial )
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

namespace Server.Items
{
	[FlipableAttribute( 0x1A01, 0x1A02 )]
	public class BootsSkeleton : Item
	{
		[Constructable]
		public BootsSkeleton() : base( 0x1A01 )
		{
			Weight = 1.0;
			Name = "a decayed skeleton";
		}

		public BootsSkeleton( Serial serial ) : base( serial )
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

namespace Server.Items
{
	[FlipableAttribute( 0x1B1D, 0x1B1E )]
	public class MeatySkeleton : Item
	{
		[Constructable]
		public MeatySkeleton() : base( 0x1B1D )
		{
			Weight = 1.0;
			Name = "a half-decayed skeleton";
		}

		public MeatySkeleton( Serial serial ) : base( serial )
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
/*
namespace Server.Items
{
	[FlipableAttribute( 0x1268, 0x1246 )]
	public class Guillotine : Item
	{
		[Constructable]
		public Guillotine() : base( 0x1268 )
		{
			Weight = 10.0;
			Name = "a guillotine";
		}

		public Guillotine( Serial serial ) : base( serial )
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
*/
namespace Server.Items
{
	public class OpenIronMaiden : Item
	{
		[Constructable]
		public OpenIronMaiden() : base( 0x1249 )
		{
			Weight = 15.0;
			Name = "an open iron maiden";
		}

		public OpenIronMaiden( Serial serial ) : base( serial )
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

namespace Server.Items
{
	public class ClosedIronMaiden : Item
	{
		[Constructable]
		public ClosedIronMaiden() : base( 0x124D )
		{
			Weight = 15.0;
			Name = "a closed iron maiden";
		}

		public ClosedIronMaiden( Serial serial ) : base( serial )
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

namespace Server.Items
{
	public class SkullSpikes : Item
	{
		[Constructable]
		public SkullSpikes() : base( 0x21FC )
		{
			Weight = 13.0;
			Name = "a pile of skull spikes";
		}

		public SkullSpikes( Serial serial ) : base( serial )
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