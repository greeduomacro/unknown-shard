using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class HerbalWater : BaseReagent, ICommodity
	{

		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} Herbal Water", Amount );
			}
		}

		[Constructable]
		public HerbalWater() : this( 1 )
		{
            Name = "Herbal Water";
		}

		[Constructable]
		public HerbalWater( int amount ) : base( 0x99C, amount )
		{
            Name = "Herbal Water";
		}

		public HerbalWater( Serial serial ) : base( serial )
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