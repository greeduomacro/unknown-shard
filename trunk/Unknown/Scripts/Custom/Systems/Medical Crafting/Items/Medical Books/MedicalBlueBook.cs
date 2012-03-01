using System;
using Server;

namespace Server.Items
{
	public class MedicalBlueBook : BaseBook
	{
		[Constructable]
		public MedicalBlueBook() : base( 0xFF2 )
		{
		}

		[Constructable]
		public MedicalBlueBook( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public MedicalBlueBook( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public MedicalBlueBook( bool writable ) : base( 0xFF2, writable )
		{
		}

		public MedicalBlueBook( Serial serial ) : base( serial )
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