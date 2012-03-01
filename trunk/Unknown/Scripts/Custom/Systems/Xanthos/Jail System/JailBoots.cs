using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;

namespace Xanthos.JailSystem
{
	class JailBoots : Boots
	{
		[Constructable]
		public JailBoots( string playerName ) : base( JailConfig.RobeHue )
		{
			Name = "Smoldering boots of " + playerName;
		}

		public JailBoots( Serial serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
		}
	}
}
