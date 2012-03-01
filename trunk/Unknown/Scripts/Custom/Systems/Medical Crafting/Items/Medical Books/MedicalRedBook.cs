using System;
using Server;

namespace Server.Items
{
	public class MedicalRedBook : BaseBook
	{
		[Constructable]
		public MedicalRedBook() : base( 0xFF1 )
		{
		}

		[Constructable]
		public MedicalRedBook( int pageCount, bool writable ) : base( 0xFF1, pageCount, writable )
		{
		}

		[Constructable]
		public MedicalRedBook( string title, string author, int pageCount, bool writable ) : base( 0xFF1, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public MedicalRedBook( bool writable ) : base( 0xFF1, writable )
		{
		}

		public MedicalRedBook( Serial serial ) : base( serial )
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