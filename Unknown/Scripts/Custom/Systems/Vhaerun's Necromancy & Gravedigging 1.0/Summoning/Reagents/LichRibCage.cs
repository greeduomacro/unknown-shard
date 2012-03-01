using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class LichRibCage : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} lich rib cage", Amount );
			}
		}

		[Constructable]
		public LichRibCage() : this( 1 )
		{
		}

		[Constructable]
        public LichRibCage(int amount)
            : base(0x1B17, amount)
		{
            Name = "Lich Rib Cage";
            Stackable = true;
            Hue = 952;
		}

        public LichRibCage(Serial serial)
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