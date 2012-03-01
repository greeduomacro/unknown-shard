using System;
using Server;

namespace Server.Items
{
	public class MedicalTanBook : BaseBook
	{
		[Constructable]
		public MedicalTanBook() : base( 0xFF0 )
		{
		}

		[Constructable]
		public MedicalTanBook( int pageCount, bool writable ) : base( 0xFF0, pageCount, writable )
		{
		}

		[Constructable]
		public MedicalTanBook( string title, string author, int pageCount, bool writable ) : base( 0xFF0, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public MedicalTanBook( bool writable ) : base( 0xFF0, writable )
		{
		}

		public MedicalTanBook( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}
	}
}