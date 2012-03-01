// by Old School Oct 2008
#define RunUo2_0

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
    public class WantedCriminalsGump : Gump
    {
        Mobile caller;

        public static void Initialize()
        {
#if(RunUo2_0)
            CommandSystem.Register("WantedCriminals", AccessLevel.Player, new CommandEventHandler(WantedCriminals_OnCommand));
#else
            Register("WantedCriminals", AccessLevel.Player, new CommandEventHandler(WantedCriminals_OnCommand));
#endif
        }

        [Usage("WantedCriminals")]
        [Description("Makes a call to your custom gump.")]
        public static void WantedCriminals_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from.HasGump(typeof(WantedCriminalsGump)))
                from.CloseGump(typeof(WantedCriminalsGump));
            from.SendGump(new WantedCriminalsGump(from));
        }

        public WantedCriminalsGump(Mobile from) : this()
        {
            caller = from;
        }

        public WantedCriminalsGump() : base( 0, 0 )
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
			AddLabel(314, 188, 149, @"Wanted Criminals"); //Change name here
			AddHtml( 162, 221, 369, 279, @"wanted Dead or Alive
			
			Odin the Ruthless
			Crimes:Murdering Innocent Women and Children
			Reward:50,000 Gold
			
			Xerian the Terriable
			Crimes:Assassinating Overseer of Minic
			Reward:10,000 Gold
			
			Fanalaon the Bringer of Death
			Crimes:Slaying Innocent Mine Worker's
			Reward:10,000
			
			Marine the Killer
			Crimes:Killing Cattle
			Reward:5,000 Gold
			
			the Evil Wicked Clown
			Crimes:Terrifying Innocent Children, Murdering their Parents, Praticeing Witchcraft
			Reward:30,000 Gold
			
			Fresh the Master of Illusion
			Crimes:Praticeing Witchcraft, Mutilating Animals
			Reward:50,000 Gold
			
			Zinaga the Grand Master
			Crimes:Murdering Spellcrafters, Praticeing Witchcraft, Mutilating Animals
			Reward:45,000 Gold
			
			Beast the Magician
			Crimes:Witchcraft, Building a Time Machine, Time Travel
			Reward:35,000 Gold
			
			Old School the Grand Wizard
			Crimes:Murdering the Innocent, Stealing Horses, Time Travel, Praticeing Witchcraft
			Reward:25,000 Gold", (bool)true, (bool)true);
			

            
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