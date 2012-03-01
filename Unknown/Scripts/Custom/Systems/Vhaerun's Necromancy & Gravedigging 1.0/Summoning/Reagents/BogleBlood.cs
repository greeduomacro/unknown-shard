using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BogleBlood : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} bogle blood", Amount );
			}
		}

		[Constructable]
		public BogleBlood() : this( 1 )
		{
		}

		[Constructable]
        public BogleBlood(int amount): base(0xF7D, amount)
		{
            Name = "Bogle Blood";
            Stackable = true;
            Hue = 992;
		}

        public BogleBlood(Serial serial)
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