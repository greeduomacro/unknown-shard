using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ShadeMist : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} shade mist", Amount );
			}
		}

		[Constructable]
		public ShadeMist() : this( 1 )
		{
		}

		[Constructable]
        public ShadeMist(int amount): base(0x11EA, amount)
		{
            Name = "Shade Mist";
            Stackable = true;
            Hue = 902;
		}

        public ShadeMist(Serial serial)
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