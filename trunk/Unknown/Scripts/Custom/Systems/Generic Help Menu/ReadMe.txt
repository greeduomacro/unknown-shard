/**************************************
*Script Name: Generic Help Menu       *
*Author: Joeku                        *
*For use with RunUO 2.0               *
*Client Tested with: 5.0.7.1          *
*Version: 1.3                         *
*Initial Release: 10/05/06            *
*Revision Date: 01/12/07              *
**************************************/

http://www.runuo.com/forums/showthread.php?p=586206#post586206

-Changelog-
-Version 1.0: Initial release.
-Version 1.0 -> 1.01 November 29, 2006: Consolidated everything into one gump
	("MainHelpMenu" is no longer used; to send the main help menu, you now send
	HelpMenu with no arguments). This prevents the gump from "moving around" when you
	are switching between the main help menu and the sub-menus. Also added the ability
	to override the display for subjects by adding an extra "title" argument to the
	SubjectInfo constructors.
-Version 1.1 -> 1.2 January 8, 2007: Fixed a small bug with the e-mail link (thanks Alari
	and Soultaker). Slightly revamped how commands/descriptions are called within the
	 gump.
-Version 1.2 -> 1.3 January 12, 2007: Fixed a crash when paging a GM from the Main Help
	Menu (thanks Dan "Puma1337"). Slightly adjusted some of the gump art positions.

-Description-
A generic help menu script, designed to make it easy for administrators to relay
information about their shard to their players. Using a hand-made display algorithm, I've
successfully made it as easy as possible. All you have to do is add your subject to the
Subject enumerator, and then add it as a SubjectInfo to the static array in the Variables
class (that's where you define the content of that particular topic).

-Features-
-Fast, easy additions to the help menu.
-Automatically processes miscellaneous shard information and applies it (Server Name, for
	example).
-Contains advanced functions for displaying available commands.
-Sexy! :D

-Installation-
	If you want this to replace the [Help command, then simply drop the contents of the
"Distros" folder into your Scripts folder. Distro files consist of: Handlers.cs,
TestCenter.cs. If not, delete them. Look for the following code in "Generic Help Menu.cs":
   public static readonly string Website = "http://www.uo.com/";
   public static readonly string Email = "E-mail address here!";   //Ex. "support@uo.com"
Make sure to change the values to match your website and the administrator's e-mail address.
Also be aware that, by default, this script uses your Server Name in "ServerList.cs".

Thank you for using this script, I hope you enjoy it! You can e-mail suggestions/requests
to demortris@adelphia.net.