using System;

namespace Server.Items
{

	public class SpecialFishingSash : BaseMiddleTorso
	{
		[Constructable]
		public SpecialFishingSash() : this( 0 )
		{
		}

		[Constructable]
		public SpecialFishingSash( int hue ) : base( 0x1541, hue )
		{
			Weight = 1.0;
			Name = "Special Fishing Sash";
			SkillBonuses.SetValues( 0, SkillName.Fishing, 20.0 );

		}

		public SpecialFishingSash( Serial serial ) : base( serial )
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