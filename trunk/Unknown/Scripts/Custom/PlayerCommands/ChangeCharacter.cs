/*

$Id: //depot/c%23/RunUO Core Scripts/RunUO Core Scripts/Customs/Commands/ChangeCharacter.cs#4 $

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

*/

using System;
using System.Collections.Generic;
using Server;
using Server.Accounting;
using Server.Commands;
using Server.Mobiles;
using Server.Network;

namespace Server.Commands
{
    public sealed class ChangeCharacter
    {
        public static void Initialize()
        {
            CommandSystem.Register("ChangeCharacter", AccessLevel.Player, new CommandEventHandler(ChangeCharacter_OnCommand));
        }

        [Usage("ChangeCharacter")]
        [Description("Allows you to switch to one of your other characters without having to log out.")]
        public static void ChangeCharacter_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            NetState ns = from.NetState;

            if (from.GetLogoutDelay() > TimeSpan.Zero)
            {
                from.SendMessage("You can't insta-log here, or right now; you cannot switch characters.");
                return;
            }

            if (e.ArgString.Length == 0)
            {
                from.CloseAllGumps();

                // Return player to character select screen.
                ns.BlockAllPackets = true;

                from.NetState = null;

                ns.BlockAllPackets = false;

                ns.Send(new CharacterList(ns.Account, ns.CityInfo));

                Console.WriteLine("Client: {0}: Returning to character select. [{1}]",
                    ns.ToString(),
                    ns.Account.Username);

                return;
            }

            if (e.ArgString.ToUpper() == from.Name.ToUpper())
            {
                from.SendMessage("You're already using that character!");
                return;
            }

            Mobile newchar = null;

            for (int i = 0; i < from.Account.Length; i++)
            {
                if (from.Account[i] == null)
                    continue;

                if (from.Account[i].Name.ToUpper() == e.ArgString.ToUpper())
                {
                    newchar = from.Account[i];
                    break;
                }
            }

            if (newchar == null)
            {
                from.SendMessage("Can't find a character named '{0}' on your account.", e.ArgString);
                return;
            }

            // do the switch!
            from.CloseAllGumps();

            ns.BlockAllPackets = true;

            from.NetState = null;
            newchar.NetState = ns;
            ns.Mobile = newchar;

            ns.BlockAllPackets = false;

            PacketHandlers.DoLogin(ns, newchar);

            Console.WriteLine("Client: {0}: Character switch from '{2}' to '{3}' [{1}]", ns.ToString(),
                from.Account.Username, from.Name, newchar.Name);
        }
    }
}
