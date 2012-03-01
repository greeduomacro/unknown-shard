// by Old School Oct 2008
#define RunUo2_0

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
    public class GeneralNewspaper : Gump
    {
        Mobile caller;

        public static void Initialize()
        {
#if(RunUo2_0)
            CommandSystem.Register("GNews", AccessLevel.Player, new CommandEventHandler(GNews_OnCommand));
#else
            Register("GNews", AccessLevel.Player, new CommandEventHandler(GNews_OnCommand));
#endif
        }

        [Usage("GNews")]
        [Description("Makes a call to your custom gump.")]
        public static void GNews_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from.HasGump(typeof(GeneralNewspaper)))
                from.CloseGump(typeof(GeneralNewspaper));
            from.SendGump(new GeneralNewspaper(from));
        }

        public GeneralNewspaper(Mobile from) : this()
        {
            caller = from;
        }

        public GeneralNewspaper() : base( 0, 0 )
        {
            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=true;

			AddPage(0);
			AddImageTiled(137, 146, 422, 385, 9394);
			AddImage(462, 144, 9392);
			AddImage(120, 144, 9390);
			AddImage(234, 144, 9391);
			AddImage(291, 144, 9391);
			AddImage(348, 144, 9391);
			AddImage(405, 144, 9391);
			AddImage(119, 404, 9396);
			AddImage(118, 284, 9393);
			AddImage(119, 326, 9393);
			AddImage(120, 362, 9393);
			AddImage(233, 404, 9397);
			AddImage(290, 404, 9397);
			AddImage(347, 404, 9397);
			AddImage(461, 404, 9398);
			AddImage(404, 404, 9397);
			AddImage(462, 362, 9395);
			AddImage(463, 320, 9395);
			AddImage(462, 279, 9395);
			AddLabel(314, 188, 149, @"Declare of Diversity"); //Change name here
			AddHtml( 162, 221, 369, 279, @"Put news in here", (bool)true, (bool)true);
			

            
        }

        

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch(info.ButtonID)
            {
                				case 0:
				{

					break;
				}

            }
        }
    }
}