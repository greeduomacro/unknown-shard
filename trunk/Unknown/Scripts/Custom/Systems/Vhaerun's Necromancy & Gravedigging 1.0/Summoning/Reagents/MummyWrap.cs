using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MummyWrap : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} mummy wrap", Amount );
			}
		}

		[Constructable]
		public MummyWrap() : this( 1 )
		{
		}

		[Constructable]
        public MummyWrap(int amount): base(0xE21, amount)
		{
            Name = "Mummy Wrap";
            Stackable = true;
            Hue = 1151;
		}

        public MummyWrap(Serial serial)
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