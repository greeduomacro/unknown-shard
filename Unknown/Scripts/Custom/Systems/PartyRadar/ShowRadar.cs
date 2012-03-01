using System;
using Server;
using Server.Commands;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Scripts.Commands 
{
	public class ShowRadar
	{
		public static void Initialize() 
		{
			CommandSystem.Register( "ShowRadar", AccessLevel.Player, new CommandEventHandler( ShowRadar_OnCommand ) ); 
		}

		[Usage( "ShowRadar" )] 
		public static void ShowRadar_OnCommand( CommandEventArgs e ) 
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;

			if ( pm.ShowRadar )
			{
				pm.ShowRadar = false;
				pm.SendMessage("Show Party Radar: OFF");
			}
			else
			{
				pm.ShowRadar = true;
				pm.SendMessage("Show Party Radar: ON");
			}

		}
	}
}