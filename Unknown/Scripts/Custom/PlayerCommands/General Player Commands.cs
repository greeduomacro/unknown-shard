// by Old School Feb 2009
#define RunUo2_0

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
    public class HelpMeGump : Gump
    {
        Mobile caller;

        public static void Initialize()
        {
#if(RunUo2_0)
            CommandSystem.Register("HelpMe", AccessLevel.Player, new CommandEventHandler(HelpMe_OnCommand));
#else
            Register("HelpMe", AccessLevel.Player, new CommandEventHandler(HelpMe_OnCommand));
#endif
        }

        [Usage("HelpMe")]
        [Description("Makes a call to your custom gump.")]
        public static void HelpMe_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from.HasGump(typeof(HelpMeGump)))
                from.CloseGump(typeof(HelpMeGump));
            from.SendGump(new HelpMeGump(from));
        }

        public HelpMeGump(Mobile from) : this()
        {
            caller = from;
        }

        public HelpMeGump() : base( 0, 0 )
        {
            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=true;

            AddPage(0);
			AddImageTiled(130, 62, 628, 488, 2601);
			AddImageTiled(114, 44, 657, 23, 3601);
			AddImageTiled(118, 552, 653, 17, 3607);
			AddImageTiled(113, 60, 12, 505, 3605);
			AddImageTiled(766, 55, 13, 510, 3605);
			AddLabel(261, 75, 137, @"Ultima Online Knights General Player Commands");
			AddLabel(138, 110, 0, @"Chat");
			AddLabel(138, 129, 0, @"Simple type [c (enter message)");
			AddLabel(384, 112, 0, @"Help");
			AddLabel(383, 129, 0, @"[Help load help message");
			AddLabel(579, 113, 0, @"Your Charater Stats");
			AddLabel(580, 129, 0, @"[HelpMe");
			AddLabel(138, 157, 0, @"Banking");
			AddLabel(137, 175, 0, @"Type bank near a bank loads bank box");
			AddLabel(384, 157, 0, @"Checking");
			AddLabel(384, 173, 0, @"Type Bank check (value) creates a bank check");
			AddLabel(140, 200, 0, @"Pet Kill Command");
			AddLabel(140, 217, 0, @"Type All Kill");
			AddLabel(388, 201, 0, @"Pet Come Command");
			AddLabel(388, 216, 0, @"All Come");
			AddLabel(587, 200, 0, @"Stable Command");
			AddLabel(587, 215, 0, @"Stable");
			AddLabel(142, 254, 0, @"Other Commands");
			AddHtml( 138, 290, 618, 250, @"Vendor buy 
			Brings up the shopkeeper's inventory of items for sale. You can select items for purchase by double-clicking on the item or by using the + key located on the right side of the menu. 
      
Vendor sell 
Brings up a list of items in your backpack that the shopkeeper is able to purchase. You can select an item to sell by double-clicking on that item, or by using the + key located on the right side of the menu. 
      
[Name] train 
Brings up a list of all the skills that the NPC can teach (if any). 
      
[Name] train [skill] 
The vendor will quote a price in gold that must be paid before he can train you in the specified skill. Once the fee is paid, your skill (the one specified in the command) will raise. 
      
Destination 
When used around escort NPCs, the NPC will bark out information on where he/she needs to go. 
I will take thee Used around an escort NPC to except an escort. The NPC will then begin to follow you. Once you escort the NPC to its requested destination, it will usually offer some kind of payment in return. 
      
[Name] move 
Causes the NPC to step away from you. 
      
[Name] time 
The NPC will tell you the current time. 
      
[Name] where is [town/shop/building] 
The NPC will offer directions to the specified town/shop/building. 
      
News or{News
Can be said to a Barkeep or a Towncryer to hear news of any current scenarios.  
      
[Guard Name] order shield 
If you are in an Order guild, you can use this command around the guards inside Lord British's castle to get a free Order shield. 
      
[Guard Name] chaos shield 
If you are in a Chaos guild, you can use this command around the guards inside Lord Blackthorn's castle to get a free Chaos shield. 
      
Banker / Minter 
Balance 
      
Statement 
The banker will tell you the amount of gold in your bankbox. 
      
Bank 
The banker will open your bankbox for you. 
      
Check (amount) 
If you have the gold specified in your bank, a bank check of that value will be placed in your bank box and the gold will be removed. (between 5,000 and 1,000,000 gold)  
      
Barkeep 
News 
The barkeep will give a scenario hint, just like a town crier. 
giving money Amounts of gold under 50 gold will cause the Barkeep to speak this rumor. Amounts over 50 gold will be returned. Will only work if the owner did indeed give the barkeep a rumor to spread. 
saying a keyword The Barkeep will respond to a maximum of three keywords. Owners can set the keywords the Barkeep will respond to and the response the Barkeep will give. 
      
Broker 
Appraise 
The Real Estate Broker will tell you how much he will pay you for a house deed you wish to sell to him. If you wish to sell then drop the house deed on the broker after he mentioned the price. The gold will be deposited in your bank box. 
      
Escort 
I will take thee Will make the NPC who is waiting for an escort to follow you. You must be close to the NPC when you issue this command. 
      
Destination 
Will make the NPC tell you where he wants to be escorted to. 
      
Hirelings 
[Name] come 
Calls the hired NPC to your location. 
      
[Name] follow 
(target required) The NPC will follow the specified target. 
      
[Name] follow me 
The NPC will follow you. 
      
[Name] guard (target required) 
The NPC will guard the specified target. 
      
[Name] guard me 
The NPC will guard you. 
      
[Name] drop 
The NPC will drop all items it's holding to the ground. 
      
[Name] friend (target required) 
The NPC will treat the specified person as another owner. 
      
[Name] hire
      
[Name] mercenary
      
[Name] work
      
[Name] servant
The NPC will quote the price in gold that it cost you to hire it. Once the gold is given to the NPC, it will work for you. 
      
[Name] kill (target required)
[Name] attack (target required)
Commands the NPC to kill/attack the specified target. 
      
[Name] move 
Causes the NPC to step away from you. 
      
[Name] patrol 
Causes the NPC to patrol the immediate area around it. 
      
[Name] report 
The NPC will respond with a message that will tell you how they feel about their job. 
      
[Name] stay 
Commands the NPC to stop and stay in one spot. 
      
[Name] stop 
Commands the NPC to stop all actions. 
      
Withdraw (amount) 
Will place (amount) of gold from your bankbox in your backpack, if possible. 
      
[Name] transfer (target required) 
Transfers ownership of the NPC to the specified target. 
      
Stables
(commands must be said near a stablemaster) 
Claim/Retrieve 
The stablemaster will return any pets that you have stabled with him 
      
Stable (target required) 
Stables the targeted pet with the stablemaster. 
      
Teleporter 
      
Command Effect 
Doracron 
Will activate the Serpent Pillars in the sea in Britannia and teleport you to the sea in the Lost Lands. 
      
Recdu 
Will activate the teleporter in the north mage shop in Moonglow and teleport you to the mage shop in Papua. 
      
Sueacron 
Will activate the Serpent Pillars in the sea in the Lost Lands and teleport you to the sea in Britannia. 
      
Recsu 
Will activate the teleporter in the mage shop in Papua and teleport you to the north mage shop in Moonglow. 
      
Towncryer
       
news 
The Towncryer will give you a bit of news, if he has some. Repeat the command to hear the next bit of news. 
      
Vendor (Player) (Name) browse, (Name) view, (Name) look
Will open the bacpack of the vendor for you so you can see what is inside. This acts the same as double-clicking on a vendor. 
      
(Name) buy, (Name) purchase
You will get a targeting cursor with which you can select the item you want to buy. If you do not have enough gold in your backpack the amount will be taken straight out of your bankbox. 
      
(Name) collect, (Name) gold, (Name) 
get If you are the owner of the vendor, he will give you the gold he is holding. The amount will be in gold if less than 5000, or as a bank check if 5000 or more. The largest check one can receive is for one million gold, if the vendor holds more than that another request has to be made by the owner to collect the rest. 
      
(Name) status, (Name) info
If you are the owner of the vendor, he will tell you how much gold he is holding, how much he costs per UO day and for how many days he will continue to work for you. 
      
(Name) dismiss 
If you are the owner of the vendor, he will terminate the contract of employment with you. The Vendor will self-destruct, leaving no corpse. Any items or gold he is holding will not be reimbursed, so remove all tiems and issue a collect command first. 
      
Vendor (Shop)
       
Command Effect 
(Name) buy The inventory of the vendor will be shown to you. You can select which items you want to buy. You need to have the gold for the purchase on you, except when buying for a total of more than 2000gp, i.e. tents, houses, boats, guildstones or say *a lot* of reagents. In that case the amount will be taken straight out of your bankbox and you receive the item(s) you purchased in your backpack. 
(Name) sell The items in your backpack that can be sold to the vendor will be shown to you. You can select which items you want to sell. There is a maximum of 5 items per transaction.
      
I would like to cross 
This will tell the Skara Brae ferryman to take you across the water to the mainland, or back. (In fact any sentence with the word cross in it will work) 
      
Ship Commands
ALT 8 - Unfurl sail, forward  Moves the ship forward. 
ALT 5 - Furl sail, stop  Stops current ship movement. 
ALT 3 - Drop anchor  Toggles ship movement off. 
ALT 1 - Raise anchor  Toggles ship movement on. 
ALT 4 - Turn left, port, left, drift left  Left turn. 
ALT 6 - Turn right, starboard, right, drift right  Right turn. 
Turn around, come about  Turn around and proceed. 
Forward left, forward right, backward left, backward right, back left, back right, backward, back  Move in the direction indicated indicated. 
Slow forward, slow left, slow right, slow backwards, slow back  Move as directed. 
One forward, one left, one right, one backwards, one back  Move slightly in the direction indicated, then stop. 
      
Factions 
Score 
Tells you how many kill points you currently have. 
      
What is my faction term status  
When you quit a faction, there is a seven day wait period before you are actually removed from the faction. This command tells you how long you have left. 
      
I honor your leadership (target required) 
Transfers a few of your killpoints to the targeted person. The targeted person must be in the same faction. 
      
Message faction (Commander) 
Allows the Faction Commander to send a message to all faction members.  
      
I am sheriff (Sheriff) 
Once the Faction Commander chooses a Sheriff for a captured city, this command allows the Sheriff to perform his official duties. 
      
I wish to access the city treasury (Finance Minster) 
Once the Faction Commander chooses a Finance Minister for a captured city, this command allows the Finance Minister to access the town finance options. 
      
Orders Attack [faction]
Faction guard command. When spoken in succession, the guard will attack members of the specified faction on sight. 
      
Orders Follow 
Faction guard command. When spoken in succession, the guard will follow the faction member. 
      
Orders Ignore [faction]
Faction guard command. When spoken in succession, the guard will ignore all members of the specified faction. 
      
Orders Patrol 
Faction guard command. When spoken in succession, the guard will patrol the immediate area around him. 
      
Orders Warn [faction]
Faction guard command. When spoken in succession, the guard will call out a warning when members of the specified faction are in the area. 
      
You are fired
When said by the Faction Commander to a faction guard, this command will dismiss the NPC. 
      
Guilds 
I resign from my guild Removes you from a guild. 
      
Houses 
I wish to lock this down Locks down an item in your house. 
I wish to secure this Secures a container in your house. Each secure container can hold 125 lockdowns. 
I wish to release this Releases a lockdown item or a secure container. 
I wish to place a trash barrel Places a trash barrel right where your character is standing. 
Remove thyself Ejects a player or creature from your house. 
I ban thee Bans a player or creature from entering your house. 
I wish to place a strongbox Co-owner command. When spoken, a strongbox will appear at the co-owner's feet.  
      
Miscellaneous 
I must consider my sins 
Tells you the current Short Term, Long Term, and Ping Pong murder counts your character has accrued. 
      
Powerhour 
Tells you how long you have until your next powerhour begins. 
      
Recdu 
Activates the teleporter in the mage shop north of Moonglow. The teleporter will take you to Papua's mage shop. 
      
Recsu 
Activates the teleporter in Papua's mage shop. The teleporter will take you to the mage shop north of Moonglow. 
      
Doracron 
Activates the serpent pillars in Britannia's waters and transports you to the Lost Lands. 
      
Sueacron 
Activates the serpent pillars in the Lost Land and transports you to Britannia.  
      
New Players 
I renounce my young player status Removes young status from a character. Once removed, it cannot be restored. 
I resign from my quest Resigns you from your current quest. 
      
Pets
(all commands prefaced by the pet's name) 
Stay Commands the pet to stay put and to stop following you. 
Follow (target required) Commands the pet to follow a target. 
Friend (target required) The pet will treat the specified player as another owner. 
Kill (target required) Commands the pet to attack a target. 
Guard (target required) Commands the pet to guard a target. 
Stop Commands the pet to stop all actions. 
Release Reverses taming. Releases pet back into the wild. 
Transfer (target required) Transfers the pet to another person.  
      
Shrines / Karma 
      
OM OM OM 
When chanted on the stairs of the Shrine of Spirituality this will teleport you to the Ankh 
      
bal Chaos Shrine 
mu Compassion Shrine 
ahm Honesty Shrine 
summ Honor Shrine 
lum Humility Shrine 
beh Justice Shrine 
cah Sacrifice Shrine 
ra Valor Shrine 
om Spirtuality Shrine 
      
Murder Status 
I must consider my sins 
This will show your short term murder count, long term murder count and ping pong count  
      
Shield 
(Guard Name) Chaos shield 
When you are in a Chaos Guild, say this to a guard in Lord Blackthorns castle to receive a free Chaos Shield. 
      
(Guard Name) Order shield 
When you are in an Order Guild, say this to a guard in Lord British' castle to receive a free Order Shield. 
", (bool)true, (bool)true);
			

            
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