using System;
using Server;

namespace Server.Items
{
	public class MedicalBrownBook : BaseBook
	{
		[Constructable]
		public MedicalBrownBook() : base( 0xFEF )
		{
		}

		[Constructable]
		public MedicalBrownBook( int pageCount, bool writable ) : base( 0xFEF, pageCount, writable )
		{
		}

		[Constructable]
		public MedicalBrownBook( string title, string author, int pageCount, bool writable ) : base( 0xFEF, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public MedicalBrownBook( bool writable ) : base( 0xFEF, writable )
		{
		}

		public MedicalBrownBook( Serial serial ) : base( serial )
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