#region AuthorHeader
//
//	Jail version 2.0, by Xanthos
//
//  Based on original code and concept by Sirens Song
//  (ie, Matron de Winter) 2004 and Grim Reaper.  Thanks to
//	Thundar for his ideas and testing.
//
#endregion AuthorHeader
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;

namespace Xanthos.JailSystem
{
	public class JailTeleporter : Item
	{

		[Constructable]
		public JailTeleporter() : base( 7107 )
		{
			Visible = true;
			Movable = false;
			Hue = 2964; 
			Name = "The Door To Freedom";
		}

		public override bool OnMoveOver( Mobile from )
		{
			PlayerMobile player = from as PlayerMobile;

			if ( null != player )
			{
				if ( player.FindItemOnLayer( Layer.OneHanded ) is JailHammer )
					player.Emote( "*Seems somewhat more convinced that mining {0} is a good idea*", JailConfig.JailRockName );
				else
				{
					Jail.FreeThem( player );
					return false;
				}
			}
			return true;
		}

		public JailTeleporter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 5 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch ( version )
			{
				case 5:
					break;
			}
		}
	}
}