using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SkeletalDragonScale : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} skelton dragon scale", Amount );
			}
		}

		[Constructable]
		public SkeletalDragonScale() : this( 1 )
		{
		}

		[Constructable]
        public SkeletalDragonScale(int amount)
            : base(0x26B4, amount)
		{
            Name = "Skeletal Dragon Scale";
            Stackable = true;
            Hue = 643;
		}

        public SkeletalDragonScale(Serial serial)
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