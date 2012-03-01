using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class JesusBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
            (
                "Help/Rules", "Owner Jesus",
                new BookPageInfo
                (
                    "Welcome new player",
                    "This book teaches you",
                    "all of the basics for",
                    "this server. Frist of",
                    "all lets get to the",
                    "rules. 1) No Cheating.",
                    "2) no afk macroing at",
                    "all."
                ),
                new BookPageInfo
                (
                    "3) No Pking in player",
                    "newbie areas, which ",
                    "include their property",
                    "newbied mines and all",
                    "town owned graveyards",
                    "4) Cussing is allowed",
                    "but don't harass players",
                    "it is stupid."
                ),
                new BookPageInfo
                (
                    "5) Don't ask staff for",
                    "special treatment.  I",
                    "have enough work to do",
                    "other then deal with",
                    "immaturity. 6) Report",
                    "all bugs as soon as",
                    "possible. failure to",
                    "do so will result in",
                    "jailing or banning."
                ),
                new BookPageInfo
                (
                    "7) Use the help menu",
                    "system before asking for",
                    "help from staff. 8) Signs",
                    "show you what something is",
                    "and where to go for places.",
                    "9) Items have single click",
                    "and double click features.",
                    "10)Drag and drop is the",
                    "main way of moving items."
                ),
                new BookPageInfo
                (
                    "Rules are subject for",
                    "updates. Entire ingame",
                    "command listing please",
                    "type [help in the main",
                    "game window. Saying what",
                    "is my status. In game",
                    "will check your fame",
                    "karma and various",
                    "other stats"
                ),
                new BookPageInfo
                (
                    "[chat displays the main",
                    "menu of the chat system.",
                    "[characterchange",
                    ".charname. will instantly",
                    "change character ingame"
                ),
                new BookPageInfo
                (
                    "[bondtime displays how",
                    "long it will take till",
                    "your pet bonds to you.",
                    "[afk puts you into afk",
                    "status.  Protects you",
                    "from pks and afk",
                    "macroing."
                ),
                new BookPageInfo
                (
                    "[dump allows a player",
                    "to dump everything",
                    "from one container to",
                    "another.",
                    "[sort allows a player",
                    "to sort items from",
                    "one container to",
                    "another."
                ),
                new BookPageInfo
                (
                    "Type [sort followed",
                    "by a keyword, target",
                    "FROM container and",
                    "then target TO",
                    "container Keywords",
                    "are: gems, wands,",
                    "regs, scrolls, armor,"
                ),
                new BookPageInfo
                (
                    "weapons, clothing,",
                    "potions, hides,",
                    "jewelry, help (to",
                    "get list of keywords)",
                    "[moveitems will allow",
                    "you to move items of",
                    "a specific type from",
                    "one container to",
                    "another."
                ),
                new BookPageInfo
                (
                    "This is similar to",
                    "the Sort command",
                    "but rather than",
                    "using a keyword,",
                    "the player can",
                    "target an item."
                ),
                new BookPageInfo
                (
                    "Chat system details.",
                    "Public chat is [c",
                    "or [ch, followed",
                    "by text. Guild is",
                    "[g or [guild.",
                    "Alliance is [a or",
                    "[ally."
                ),
                new BookPageInfo
                (
                    "Faction is [f or",
                    "[faction. Pirvate",
                    "message is [pm or",
                    "[msg with name",
                    "then text. Mail is",
                    "[ma or [mail."
                ),
                new BookPageInfo
                (
                    "Further chat help",
                    "can be located by",
                    "[HC."
                ),
                new BookPageInfo
                (
                    "[verbosemobfactions",
                    "true/false - this",
                    "command can be run by",
                    "players to toggle the",
                    "verbose reporting of",
                    "faction gained and",
                    "lost for the mobs",
                    "they kill."
                ),
                new BookPageInfo
                (
                    "[checkmobfactions",
                    "- this command can",
                    "be run by players",
                    "to report their",
                    "current standing",
                    "with all existing",
                    "mob factions."
                    ),
                new BookPageInfo
                (
                    "To add Sockets to",
                    "weapons or armor",
                    "you must purchase",
                    "or earn a",
                    "SocketHammer. Then",
                    "apply the sockets",
                    "as you wish. 10%",
                    "chance of item",
                    "being destroyed."
                ),
                new BookPageInfo
                (
                    "Siege Repair too",
                    "- Just double-",
                    "click to use and",
                    "target the damaged",
                    "object to be",
                    "repaired. Requires",
                    "stones/wood/ore",
                    "to repair items."
                ),
                new BookPageInfo
                (
                    "Repairing speed",
                    "depends on dex and",
                    "carpentry skill",
                    "level. IronIngot/",
                    "board/granite are",
                    "the materials",
                    "needed to repair."
                ),
                new BookPageInfo
                (
                    "Loading a ",
                    "cannonball-Just",
                    "double-click a",
                    "ball and then",
                    "target a cannon.",
                    "You must be close",
                    "enough to both,",
                    "although you can",
                    "dclick the ball,",
                    "and then move to",
                    "the cannon."
                ),
                new BookPageInfo
                (
                    "Create rental",
                    "contract, players",
                    "can use this spoken",
                    "command in their",
                    "home to begin the",
                    "setup for renting",
                    "portions of their",
                    "home."
                ),
                new BookPageInfo
                (
                    "Check house rent,",
                    "can check to see",
                    "how long before",
                    "their rental cycle",
                    "expires by speaking",
                    "these words while",
                    "in their home."
                ),
                new BookPageInfo
                (
                    "Check storage,",
                    "While usable by",
                    "all home owners,",
                    "this command is",
                    "especially useful",
                    "for renters. It",
                    "will detail how",
                    "many lockdowns and",
                    "secures are used",
                    "by their rental"
                ),
                new BookPageInfo
                (
                    "property, and",
                    "include those",
                    "figures in how",
                    "much storage they",
                    "have available."
                ),
                new BookPageInfo
                (
                    "[myauction brings",
                    "up a list of your",
                    "current auctioned",
                    "items in the server",
                    "wide auction house.",
                    "Auctioner located at",
                    "town banks."
                ),
		new BookPageInfo
		(
		    "[getpet allows you",
		    "be teleported to your",
		    "pet for a fee of course",
		    "[mystats allows you to",
		    "see some more",
		    "information on your",
		    "character"
		),
		new BookPageInfo
		(
		    "Added what is my status",
		    "to allow players",
		    "to see time information",
		    "on their account"
		),
                new BookPageInfo
                (
                    "20071116",
                    "Enjoy your Stay",
                    "Owner Jesus"
                )
            );

        public override BookContent DefaultContent
        {
            get
            {
                return Content;
            }
        }

        [Constructable]
        public JesusBook()
            : base(false)
        {
            Hue = 0x504;
        }

        public JesusBook(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}