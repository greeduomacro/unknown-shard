using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class SaveGump : Gump
	{
		public SaveGump() : base( 50, 50 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(5, 5, 415, 100, 9270);
			this.AddLabel(165, 30, 2062, String.Format( "{0}", Server.Misc.ServerList.ServerName ) );
			this.AddLabel(105, 55, 1165, @"Saving information, please wait.");
			this.AddImage(25, 25, 5608);
			this.AddItem(360, 50, 6168);
		}
	}
}