using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ZombieRot : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} zombie rot", Amount );
			}
		}

		[Constructable]
		public ZombieRot() : this( 1 )
		{
		}

		[Constructable]
        public ZombieRot(int amount): base(0xF8F, amount)
		{
            Name = "Zombie Rot";
            Stackable = true;
            Hue = 57;
		}

        public ZombieRot(Serial serial)
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