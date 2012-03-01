using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SkeletonDust : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} skelton dust", Amount );
			}
		}

		[Constructable]
		public SkeletonDust() : this( 1 )
		{
		}

		[Constructable]
        public SkeletonDust(int amount): base(0xF8F, amount)
		{
            Name = "Skeleton Dust";
            Stackable = true;
            Hue = 545;
		}

        public SkeletonDust(Serial serial)
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