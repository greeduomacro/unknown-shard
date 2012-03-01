using System;
using Server;

namespace Server.Items
{
	public class MedicalTreatmentsBook : BaseBook
	{
		[Constructable]
		public MedicalTreatmentsBook() : base( 0xFF2 )
		{
		}

		[Constructable]
		public MedicalTreatmentsBook( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public MedicalTreatmentsBook( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public MedicalTreatmentsBook( bool writable ) : base( 0xFF2, writable )
		{
		}

		public MedicalTreatmentsBook( Serial serial ) : base( serial )
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