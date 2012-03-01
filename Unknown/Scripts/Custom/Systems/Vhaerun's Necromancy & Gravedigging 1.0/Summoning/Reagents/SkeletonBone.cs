using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SkeletonBone : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} skelton bone", Amount );
			}
		}

		[Constructable]
		public SkeletonBone() : this( 1 )
		{
		}

		[Constructable]
        public SkeletonBone(int amount): base(0xf7e, amount)
		{
            Name = "Skeleton Bone";
            Stackable = true;
		}

        public SkeletonBone(Serial serial)
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