#region AuthorHeader
//
//	Jail version 2.0, by Xanthos
//
//  Based on original code and concept by Sirens Song
//  (ie, Matron de Winter) 2004 and Grim Reaper.  Thanks to
//	Thundar for his ideas and testing.
//
#endregion AuthorHeader
#undef JAIL_TESTING
using System;
using Server;
using Server.Items;

namespace Xanthos.JailSystem
{
	public class JailRock : Item
	{
#if JAIL_TESTING
		[Constructable]
#endif
		public JailRock() : this( 1 )
		{
		}

#if JAIL_TESTING
		[Constructable]
#endif
		public JailRock( int amount ) : base( 0x19B9 )
		{
			Name = JailConfig.JailRockName;
			Hue = JailConfig.RockHue;
			Stackable = true;
			Weight = JailConfig.JailRockWeight;
			Amount = amount;
		}

		public JailRock( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}