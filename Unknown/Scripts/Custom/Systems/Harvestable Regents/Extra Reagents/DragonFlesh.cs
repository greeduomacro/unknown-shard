using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class DragonFlesh : BaseReagent, ICommodity
	{

		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} Dragon Flesh", Amount );
			}
		}

		[Constructable]
		public DragonFlesh() : this( 1 )
		{
            Name = "Dragon Flesh";
		}

		[Constructable]
		public DragonFlesh( int amount ) : base( 0x9F1, amount )
		{
            Name = "Dragon Flesh";
		}

		public DragonFlesh( Serial serial ) : base( serial )
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