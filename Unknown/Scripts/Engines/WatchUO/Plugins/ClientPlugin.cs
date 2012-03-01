// Client Plugin - 7/14/2005 - ssalter
// Beta 1. Next version will have skills and properties panels

using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Server.Network;
using Server.Accounting;
using Server.Mobiles;

namespace Server.Engines.WatchUO.Plugins {
	public class ClientPlugin : BasePlugin {
		private ArrayList m_Clients;
		private  Mobile m_Mobile;
 
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.ListBox ListBox1;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Label address;
		private System.Windows.Forms.Label client;
		private System.Windows.Forms.Label version;
		private System.Windows.Forms.Label mobile;
		private System.Windows.Forms.Label location;
		private System.Windows.Forms.Label locationinfo;
		private System.Windows.Forms.Label mobileinfo;
		private System.Windows.Forms.Label accountinfo;
		private System.Windows.Forms.Label versioninfo;
		private System.Windows.Forms.Label clientinfo;
		private System.Windows.Forms.Label addressinfo;
		private System.Windows.Forms.Label lastlogininfo;
		private System.Windows.Forms.Label lastlogin;
		private System.Windows.Forms.Button butt_Disconnect;
		private System.Windows.Forms.Button butt_Kill;
		private System.Windows.Forms.Button butt_Resurrect;
		private System.Windows.Forms.Label serialinfo;
		private System.Windows.Forms.Label serial;
		private System.Windows.Forms.Label healthinfo;
		private System.Windows.Forms.Label Health;
		private System.Windows.Forms.Label ingameinfo;
		private System.Windows.Forms.Label ingame;
		private System.Windows.Forms.Label createdinfo;
		private System.Windows.Forms.Label created;
		private System.Windows.Forms.Button butt_Refresh;
		private System.Windows.Forms.Label currentsessioninfo;
		private System.Windows.Forms.Label currentsession;
		private System.Windows.Forms.TabControl ClientTab;
		private System.Windows.Forms.TabPage MainSkillsTab;
		private System.Windows.Forms.TabPage MainPropsTab;
		internal System.Windows.Forms.TabControl SkillsTab;
		internal PropertyTabControl PropsTab;
		internal System.Windows.Forms.TabPage TCrafting;
		internal System.Windows.Forms.TabPage TBardic;
		internal System.Windows.Forms.TabPage TMagical;
		internal System.Windows.Forms.TabPage TMisc;
		internal System.Windows.Forms.TabPage TCombat;
		internal System.Windows.Forms.TabPage TActions;
		internal System.Windows.Forms.TabPage TKnowledge;
		private System.Windows.Forms.Label Alchemy;
		private System.Windows.Forms.Label Blacksmith;
		private System.Windows.Forms.Label Cartography;
		private System.Windows.Forms.Label Fletching;
		private System.Windows.Forms.Label Cooking;
		private System.Windows.Forms.Label Carpentry;
		private System.Windows.Forms.Label Tinkering;
		private System.Windows.Forms.Label Tailoring;
		private System.Windows.Forms.TextBox alchemyinfo;
		private System.Windows.Forms.Button butt_alchemy;
		private System.Windows.Forms.Button butt_blacksmith;
		private System.Windows.Forms.TextBox blacksmithinfo;
		private System.Windows.Forms.Button butt_cartography;
		private System.Windows.Forms.TextBox cartographyinfo;
		private System.Windows.Forms.Button butt_fletching;
		private System.Windows.Forms.TextBox fletchinginfo;
		private System.Windows.Forms.Button butt_cooking;
		private System.Windows.Forms.TextBox cookinginfo;
		private System.Windows.Forms.Button butt_carpentry;
		private System.Windows.Forms.TextBox carpentryinfo;
		private System.Windows.Forms.Button butt_tinkering;
		private System.Windows.Forms.TextBox tinkeringinfo;
		private System.Windows.Forms.Button butt_tailoring;
		private System.Windows.Forms.TextBox tailoringinfo;
		private System.Windows.Forms.Button butt_inscribe;
		private System.Windows.Forms.TextBox inscribeinfo;
		private System.Windows.Forms.Button butt_provocation;
		private System.Windows.Forms.TextBox provocationinfo;
		private System.Windows.Forms.Button butt_peacemaking;
		private System.Windows.Forms.TextBox peacemakinginfo;
		private System.Windows.Forms.Button butt_musicianship;
		private System.Windows.Forms.TextBox musicianshipinfo;
		private System.Windows.Forms.Button butt_discordance;
		private System.Windows.Forms.TextBox discordanceinfo;
		private System.Windows.Forms.Label Provocation;
		private System.Windows.Forms.Label Peacemaking;
		private System.Windows.Forms.Label Musicianship;
		private System.Windows.Forms.Label Discordance;
		private System.Windows.Forms.Button butt_bushido;
		private System.Windows.Forms.TextBox bushidoinfo;
		private System.Windows.Forms.Button butt_ninjitsu;
		private System.Windows.Forms.TextBox ninjitsuinfo;
		private System.Windows.Forms.Button butt_spiritspeak;
		private System.Windows.Forms.TextBox spiritspeakinfo;
		private System.Windows.Forms.Button butt_necromancy;
		private System.Windows.Forms.TextBox necromancyinfo;
		private System.Windows.Forms.Button butt_meditation;
		private System.Windows.Forms.TextBox meditationinfo;
		private System.Windows.Forms.Button butt_magicresist;
		private System.Windows.Forms.TextBox magicresistinfo;
		private System.Windows.Forms.Button butt_magery;
		private System.Windows.Forms.TextBox mageryinfo;
		private System.Windows.Forms.Button butt_evalint;
		private System.Windows.Forms.TextBox evalintinfo;
		private System.Windows.Forms.Button butt_chivalry;
		private System.Windows.Forms.TextBox chivalryinfo;
		private System.Windows.Forms.Label Bushido;
		private System.Windows.Forms.Label Ninjitsu;
		private System.Windows.Forms.Label SpiritSpeak;
		private System.Windows.Forms.Label Necromancy;
		private System.Windows.Forms.Label Meditation;
		private System.Windows.Forms.Label MagicResist;
		private System.Windows.Forms.Label Magery;
		private System.Windows.Forms.Label EvalInt;
		private System.Windows.Forms.Label Chivalry;
		private System.Windows.Forms.TextBox snoopinginfo;
		private System.Windows.Forms.TextBox mininginfo;
		private System.Windows.Forms.TextBox lumberjackinginfo;
		private System.Windows.Forms.TextBox lockpickinginfo;
		private System.Windows.Forms.TextBox herdinginfo;
		private System.Windows.Forms.TextBox healinginfo;
		private System.Windows.Forms.TextBox fishinginfo;
		private System.Windows.Forms.TextBox campinginfo;
		private System.Windows.Forms.Label Snooping;
		private System.Windows.Forms.Label Mining;
		private System.Windows.Forms.Label Lumberjacking;
		private System.Windows.Forms.Label Lockpicking;
		private System.Windows.Forms.Label Herding;
		private System.Windows.Forms.Label Healing;
		private System.Windows.Forms.Label Fishing;
		private System.Windows.Forms.Label Camping;
		private System.Windows.Forms.Button butt_snooping;
		private System.Windows.Forms.Button butt_mining;
		private System.Windows.Forms.Button butt_lumberjacking;
		private System.Windows.Forms.Button butt_lockpicking;
		private System.Windows.Forms.Button butt_herding;
		private System.Windows.Forms.Button butt_healing;
		private System.Windows.Forms.Button butt_fishing;
		private System.Windows.Forms.Button butt_camping;
		private System.Windows.Forms.Button butt_veterinary;
		private System.Windows.Forms.TextBox veterinaryinfo;
		private System.Windows.Forms.Label Veterinary;
		private System.Windows.Forms.Button butt_wrestling;
		private System.Windows.Forms.TextBox wrestlinginfo;
		private System.Windows.Forms.Button butt_tactics;
		private System.Windows.Forms.TextBox tacticsinfo;
		private System.Windows.Forms.Button butt_swords;
		private System.Windows.Forms.TextBox swordsinfo;
		private System.Windows.Forms.Button butt_parry;
		private System.Windows.Forms.TextBox parryinfo;
		private System.Windows.Forms.Button butt_macing;
		private System.Windows.Forms.TextBox macinginfo;
		private System.Windows.Forms.Button butt_fencing;
		private System.Windows.Forms.TextBox fencinginfo;
		private System.Windows.Forms.Button butt_archery;
		private System.Windows.Forms.TextBox archeryinfo;
		private System.Windows.Forms.Label Wrestling;
		private System.Windows.Forms.Label Tactics;
		private System.Windows.Forms.Label Swords;
		private System.Windows.Forms.Label Parry;
		private System.Windows.Forms.Label Macing;
		private System.Windows.Forms.Label Fencing;
		private System.Windows.Forms.Label Archery;
		private System.Windows.Forms.Label Tracking;
		private System.Windows.Forms.Label Stealth;
		private System.Windows.Forms.Label Stealing;
		private System.Windows.Forms.Label Poisoning;
		private System.Windows.Forms.Label RemoveTrap;
		private System.Windows.Forms.Label Hiding;
		private System.Windows.Forms.Label DetectHidden;
		private System.Windows.Forms.Label Begging;
		private System.Windows.Forms.Label AnimalTaming;
		private System.Windows.Forms.Button butt_tracking;
		private System.Windows.Forms.TextBox trackinginfo;
		private System.Windows.Forms.Button butt_stealth;
		private System.Windows.Forms.TextBox stealthinfo;
		private System.Windows.Forms.Button butt_stealing;
		private System.Windows.Forms.TextBox stealinginfo;
		private System.Windows.Forms.Button butt_poisoning;
		private System.Windows.Forms.TextBox poisoninginfo;
		private System.Windows.Forms.Button butt_removetrap;
		private System.Windows.Forms.TextBox removetrapinfo;
		private System.Windows.Forms.Button butt_hiding;
		private System.Windows.Forms.TextBox hidinginfo;
		private System.Windows.Forms.Button butt_detecthidden;
		private System.Windows.Forms.TextBox detecthiddeninfo;
		private System.Windows.Forms.Button butt_begging;
		private System.Windows.Forms.TextBox begginginfo;
		private System.Windows.Forms.Button butt_animaltaming;
		private System.Windows.Forms.TextBox animaltaminginfo;
		private System.Windows.Forms.Button butt_tasteid;
		private System.Windows.Forms.TextBox tasteidinfo;
		private System.Windows.Forms.Button butt_itemid;
		private System.Windows.Forms.TextBox itemidinfo;
		private System.Windows.Forms.Button butt_forensics;
		private System.Windows.Forms.TextBox forensicsinfo;
		private System.Windows.Forms.Button butt_armslore;
		private System.Windows.Forms.TextBox armsloreinfo;
		private System.Windows.Forms.Button butt_animallore;
		private System.Windows.Forms.TextBox animalloreinfo;
		private System.Windows.Forms.Button butt_anatomy;
		private System.Windows.Forms.TextBox anatomyinfo;
		private System.Windows.Forms.Label TasteID;
		private System.Windows.Forms.Label ItemID;
		private System.Windows.Forms.Label Forensics;
		private System.Windows.Forms.Label ArmsLore;
		private System.Windows.Forms.Label AnimalLore;
		private System.Windows.Forms.Label Anatomy;
		private System.Windows.Forms.Button Account;
		private System.Windows.Forms.Label Inscribe;
		private System.Windows.Forms.Button butt_focus;
		private System.Windows.Forms.TextBox focusinfo;
		private System.Windows.Forms.Label focuslabel;
		private System.Windows.Forms.Button butt_firewall;
		
		public ClientPlugin() : base ("Online Clients") {
			this.Order = 15;

			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.ClientTab = new System.Windows.Forms.TabControl();
			this.MainSkillsTab = new System.Windows.Forms.TabPage();
			this.SkillsTab = new System.Windows.Forms.TabControl();
			this.PropsTab = new PropertyTabControl();
			this.TCrafting = new System.Windows.Forms.TabPage();
			this.butt_tinkering = new System.Windows.Forms.Button();
			this.tinkeringinfo = new System.Windows.Forms.TextBox();
			this.butt_tailoring = new System.Windows.Forms.Button();
			this.tailoringinfo = new System.Windows.Forms.TextBox();
			this.butt_inscribe = new System.Windows.Forms.Button();
			this.inscribeinfo = new System.Windows.Forms.TextBox();
			this.butt_fletching = new System.Windows.Forms.Button();
			this.fletchinginfo = new System.Windows.Forms.TextBox();
			this.butt_cooking = new System.Windows.Forms.Button();
			this.cookinginfo = new System.Windows.Forms.TextBox();
			this.butt_carpentry = new System.Windows.Forms.Button();
			this.carpentryinfo = new System.Windows.Forms.TextBox();
			this.butt_cartography = new System.Windows.Forms.Button();
			this.cartographyinfo = new System.Windows.Forms.TextBox();
			this.butt_blacksmith = new System.Windows.Forms.Button();
			this.blacksmithinfo = new System.Windows.Forms.TextBox();
			this.butt_alchemy = new System.Windows.Forms.Button();
			this.alchemyinfo = new System.Windows.Forms.TextBox();
			this.Tinkering = new System.Windows.Forms.Label();
			this.Tailoring = new System.Windows.Forms.Label();
			this.Inscribe = new System.Windows.Forms.Label();
			this.Fletching = new System.Windows.Forms.Label();
			this.Cooking = new System.Windows.Forms.Label();
			this.Carpentry = new System.Windows.Forms.Label();
			this.Cartography = new System.Windows.Forms.Label();
			this.Blacksmith = new System.Windows.Forms.Label();
			this.Alchemy = new System.Windows.Forms.Label();
			this.TBardic = new System.Windows.Forms.TabPage();
			this.butt_provocation = new System.Windows.Forms.Button();
			this.provocationinfo = new System.Windows.Forms.TextBox();
			this.butt_peacemaking = new System.Windows.Forms.Button();
			this.peacemakinginfo = new System.Windows.Forms.TextBox();
			this.butt_musicianship = new System.Windows.Forms.Button();
			this.musicianshipinfo = new System.Windows.Forms.TextBox();
			this.butt_discordance = new System.Windows.Forms.Button();
			this.discordanceinfo = new System.Windows.Forms.TextBox();
			this.Provocation = new System.Windows.Forms.Label();
			this.Peacemaking = new System.Windows.Forms.Label();
			this.Musicianship = new System.Windows.Forms.Label();
			this.Discordance = new System.Windows.Forms.Label();
			this.TMagical = new System.Windows.Forms.TabPage();
			this.butt_bushido = new System.Windows.Forms.Button();
			this.bushidoinfo = new System.Windows.Forms.TextBox();
			this.butt_ninjitsu = new System.Windows.Forms.Button();
			this.ninjitsuinfo = new System.Windows.Forms.TextBox();
			this.butt_spiritspeak = new System.Windows.Forms.Button();
			this.spiritspeakinfo = new System.Windows.Forms.TextBox();
			this.butt_necromancy = new System.Windows.Forms.Button();
			this.necromancyinfo = new System.Windows.Forms.TextBox();
			this.butt_meditation = new System.Windows.Forms.Button();
			this.meditationinfo = new System.Windows.Forms.TextBox();
			this.butt_magicresist = new System.Windows.Forms.Button();
			this.magicresistinfo = new System.Windows.Forms.TextBox();
			this.butt_magery = new System.Windows.Forms.Button();
			this.mageryinfo = new System.Windows.Forms.TextBox();
			this.butt_evalint = new System.Windows.Forms.Button();
			this.evalintinfo = new System.Windows.Forms.TextBox();
			this.butt_chivalry = new System.Windows.Forms.Button();
			this.chivalryinfo = new System.Windows.Forms.TextBox();
			this.Bushido = new System.Windows.Forms.Label();
			this.Ninjitsu = new System.Windows.Forms.Label();
			this.SpiritSpeak = new System.Windows.Forms.Label();
			this.Necromancy = new System.Windows.Forms.Label();
			this.Meditation = new System.Windows.Forms.Label();
			this.MagicResist = new System.Windows.Forms.Label();
			this.Magery = new System.Windows.Forms.Label();
			this.EvalInt = new System.Windows.Forms.Label();
			this.Chivalry = new System.Windows.Forms.Label();
			this.TMisc = new System.Windows.Forms.TabPage();
			this.butt_veterinary = new System.Windows.Forms.Button();
			this.veterinaryinfo = new System.Windows.Forms.TextBox();
			this.Veterinary = new System.Windows.Forms.Label();
			this.butt_snooping = new System.Windows.Forms.Button();
			this.snoopinginfo = new System.Windows.Forms.TextBox();
			this.butt_mining = new System.Windows.Forms.Button();
			this.mininginfo = new System.Windows.Forms.TextBox();
			this.butt_lumberjacking = new System.Windows.Forms.Button();
			this.lumberjackinginfo = new System.Windows.Forms.TextBox();
			this.butt_lockpicking = new System.Windows.Forms.Button();
			this.lockpickinginfo = new System.Windows.Forms.TextBox();
			this.butt_herding = new System.Windows.Forms.Button();
			this.herdinginfo = new System.Windows.Forms.TextBox();
			this.butt_healing = new System.Windows.Forms.Button();
			this.healinginfo = new System.Windows.Forms.TextBox();
			this.butt_focus = new System.Windows.Forms.Button();
			this.focusinfo = new System.Windows.Forms.TextBox();
			this.butt_fishing = new System.Windows.Forms.Button();
			this.fishinginfo = new System.Windows.Forms.TextBox();
			this.butt_camping = new System.Windows.Forms.Button();
			this.campinginfo = new System.Windows.Forms.TextBox();
			this.Snooping = new System.Windows.Forms.Label();
			this.Mining = new System.Windows.Forms.Label();
			this.Lumberjacking = new System.Windows.Forms.Label();
			this.Lockpicking = new System.Windows.Forms.Label();
			this.Herding = new System.Windows.Forms.Label();
			this.Healing = new System.Windows.Forms.Label();
			this.focuslabel = new System.Windows.Forms.Label();
			this.Fishing = new System.Windows.Forms.Label();
			this.Camping = new System.Windows.Forms.Label();
			this.TCombat = new System.Windows.Forms.TabPage();
			this.butt_wrestling = new System.Windows.Forms.Button();
			this.wrestlinginfo = new System.Windows.Forms.TextBox();
			this.butt_tactics = new System.Windows.Forms.Button();
			this.tacticsinfo = new System.Windows.Forms.TextBox();
			this.butt_swords = new System.Windows.Forms.Button();
			this.swordsinfo = new System.Windows.Forms.TextBox();
			this.butt_parry = new System.Windows.Forms.Button();
			this.parryinfo = new System.Windows.Forms.TextBox();
			this.butt_macing = new System.Windows.Forms.Button();
			this.macinginfo = new System.Windows.Forms.TextBox();
			this.butt_fencing = new System.Windows.Forms.Button();
			this.fencinginfo = new System.Windows.Forms.TextBox();
			this.butt_archery = new System.Windows.Forms.Button();
			this.archeryinfo = new System.Windows.Forms.TextBox();
			this.Wrestling = new System.Windows.Forms.Label();
			this.Tactics = new System.Windows.Forms.Label();
			this.Swords = new System.Windows.Forms.Label();
			this.Parry = new System.Windows.Forms.Label();
			this.Macing = new System.Windows.Forms.Label();
			this.Fencing = new System.Windows.Forms.Label();
			this.Archery = new System.Windows.Forms.Label();
			this.TActions = new System.Windows.Forms.TabPage();
			this.butt_tracking = new System.Windows.Forms.Button();
			this.trackinginfo = new System.Windows.Forms.TextBox();
			this.butt_stealth = new System.Windows.Forms.Button();
			this.stealthinfo = new System.Windows.Forms.TextBox();
			this.butt_stealing = new System.Windows.Forms.Button();
			this.stealinginfo = new System.Windows.Forms.TextBox();
			this.butt_poisoning = new System.Windows.Forms.Button();
			this.poisoninginfo = new System.Windows.Forms.TextBox();
			this.butt_removetrap = new System.Windows.Forms.Button();
			this.removetrapinfo = new System.Windows.Forms.TextBox();
			this.butt_hiding = new System.Windows.Forms.Button();
			this.hidinginfo = new System.Windows.Forms.TextBox();
			this.butt_detecthidden = new System.Windows.Forms.Button();
			this.detecthiddeninfo = new System.Windows.Forms.TextBox();
			this.butt_begging = new System.Windows.Forms.Button();
			this.begginginfo = new System.Windows.Forms.TextBox();
			this.butt_animaltaming = new System.Windows.Forms.Button();
			this.animaltaminginfo = new System.Windows.Forms.TextBox();
			this.Tracking = new System.Windows.Forms.Label();
			this.Stealth = new System.Windows.Forms.Label();
			this.Stealing = new System.Windows.Forms.Label();
			this.Poisoning = new System.Windows.Forms.Label();
			this.RemoveTrap = new System.Windows.Forms.Label();
			this.Hiding = new System.Windows.Forms.Label();
			this.DetectHidden = new System.Windows.Forms.Label();
			this.Begging = new System.Windows.Forms.Label();
			this.AnimalTaming = new System.Windows.Forms.Label();
			this.TKnowledge = new System.Windows.Forms.TabPage();
			this.butt_tasteid = new System.Windows.Forms.Button();
			this.tasteidinfo = new System.Windows.Forms.TextBox();
			this.butt_itemid = new System.Windows.Forms.Button();
			this.itemidinfo = new System.Windows.Forms.TextBox();
			this.butt_forensics = new System.Windows.Forms.Button();
			this.forensicsinfo = new System.Windows.Forms.TextBox();
			this.butt_armslore = new System.Windows.Forms.Button();
			this.armsloreinfo = new System.Windows.Forms.TextBox();
			this.butt_animallore = new System.Windows.Forms.Button();
			this.animalloreinfo = new System.Windows.Forms.TextBox();
			this.butt_anatomy = new System.Windows.Forms.Button();
			this.anatomyinfo = new System.Windows.Forms.TextBox();
			this.TasteID = new System.Windows.Forms.Label();
			this.ItemID = new System.Windows.Forms.Label();
			this.Forensics = new System.Windows.Forms.Label();
			this.ArmsLore = new System.Windows.Forms.Label();
			this.AnimalLore = new System.Windows.Forms.Label();
			this.Anatomy = new System.Windows.Forms.Label();
			this.MainPropsTab = new System.Windows.Forms.TabPage();
			this.butt_Refresh = new System.Windows.Forms.Button();
			this.butt_Resurrect = new System.Windows.Forms.Button();
			this.butt_Kill = new System.Windows.Forms.Button();
			this.butt_Disconnect = new System.Windows.Forms.Button();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Account = new System.Windows.Forms.Button();
			this.currentsessioninfo = new System.Windows.Forms.Label();
			this.currentsession = new System.Windows.Forms.Label();
			this.ingameinfo = new System.Windows.Forms.Label();
			this.ingame = new System.Windows.Forms.Label();
			this.createdinfo = new System.Windows.Forms.Label();
			this.created = new System.Windows.Forms.Label();
			this.healthinfo = new System.Windows.Forms.Label();
			this.Health = new System.Windows.Forms.Label();
			this.serialinfo = new System.Windows.Forms.Label();
			this.serial = new System.Windows.Forms.Label();
			this.lastlogininfo = new System.Windows.Forms.Label();
			this.lastlogin = new System.Windows.Forms.Label();
			this.locationinfo = new System.Windows.Forms.Label();
			this.mobileinfo = new System.Windows.Forms.Label();
			this.accountinfo = new System.Windows.Forms.Label();
			this.versioninfo = new System.Windows.Forms.Label();
			this.clientinfo = new System.Windows.Forms.Label();
			this.addressinfo = new System.Windows.Forms.Label();
			this.location = new System.Windows.Forms.Label();
			this.mobile = new System.Windows.Forms.Label();
			this.version = new System.Windows.Forms.Label();
			this.client = new System.Windows.Forms.Label();
			this.address = new System.Windows.Forms.Label();
			this.ListBox1 = new System.Windows.Forms.ListBox();
			this.butt_firewall = new System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			this.ClientTab.SuspendLayout();
			this.MainSkillsTab.SuspendLayout();
			this.SkillsTab.SuspendLayout();
			this.TCrafting.SuspendLayout();
			this.TBardic.SuspendLayout();
			this.TMagical.SuspendLayout();
			this.TMisc.SuspendLayout();
			this.TCombat.SuspendLayout();
			this.TActions.SuspendLayout();
			this.TKnowledge.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.SuspendLayout();
			
			this.Controls.Add(this.GroupBox1);
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.butt_firewall);
			this.GroupBox1.Controls.Add(this.ClientTab);
			this.GroupBox1.Controls.Add(this.butt_Refresh);
			this.GroupBox1.Controls.Add(this.butt_Resurrect);
			this.GroupBox1.Controls.Add(this.butt_Kill);
			this.GroupBox1.Controls.Add(this.butt_Disconnect);
			this.GroupBox1.Controls.Add(this.GroupBox2);
			this.GroupBox1.Controls.Add(this.ListBox1);
			this.GroupBox1.Location = new System.Drawing.Point(8, 5);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(768, 505);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Online Clients";
			// 
			// ClientTab
			// 
			this.ClientTab.Controls.Add(this.MainSkillsTab);
			this.ClientTab.Controls.Add(this.MainPropsTab);
			this.ClientTab.Location = new System.Drawing.Point(248, 184);
			this.ClientTab.Name = "ClientTab";
			this.ClientTab.SelectedIndex = 0;
			this.ClientTab.Size = new System.Drawing.Size(392, 315);
			this.ClientTab.TabIndex = 13;
			// 
			// MainSkillsTab
			// 
			this.MainSkillsTab.Controls.Add(this.SkillsTab);
			this.MainSkillsTab.Location = new System.Drawing.Point(4, 25);
			this.MainSkillsTab.Name = "MainSkillsTab";
			this.MainSkillsTab.TabIndex = 0;
			this.MainSkillsTab.Text = "Skills";
			// 
			// SkillsTab
			// 
			this.SkillsTab.Controls.Add(this.TCrafting);
			this.SkillsTab.Controls.Add(this.TMisc);
			this.SkillsTab.Controls.Add(this.TBardic);
			this.SkillsTab.Controls.Add(this.TMagical);
			this.SkillsTab.Controls.Add(this.TCombat);
			this.SkillsTab.Controls.Add(this.TActions);
			this.SkillsTab.Controls.Add(this.TKnowledge);
			this.SkillsTab.Location = new System.Drawing.Point(5, 2);
			this.SkillsTab.Name = "SkillsTab";
			this.SkillsTab.SelectedIndex = 0;
			this.SkillsTab.Size = new System.Drawing.Size(370, 283);
			this.SkillsTab.TabIndex = 13;
			//
			// PropsTab
			//
			this.PropsTab.Location = new System.Drawing.Point(5, 2);
			this.PropsTab.Name = "PropsTab";
			this.PropsTab.Size = new System.Drawing.Size(370, 283);
			// 
			// TCrafting
			// 
			this.TCrafting.Controls.Add(this.butt_tinkering);
			this.TCrafting.Controls.Add(this.tinkeringinfo);
			this.TCrafting.Controls.Add(this.butt_tailoring);
			this.TCrafting.Controls.Add(this.tailoringinfo);
			this.TCrafting.Controls.Add(this.butt_inscribe);
			this.TCrafting.Controls.Add(this.inscribeinfo);
			this.TCrafting.Controls.Add(this.butt_fletching);
			this.TCrafting.Controls.Add(this.fletchinginfo);
			this.TCrafting.Controls.Add(this.butt_cooking);
			this.TCrafting.Controls.Add(this.cookinginfo);
			this.TCrafting.Controls.Add(this.butt_carpentry);
			this.TCrafting.Controls.Add(this.carpentryinfo);
			this.TCrafting.Controls.Add(this.butt_cartography);
			this.TCrafting.Controls.Add(this.cartographyinfo);
			this.TCrafting.Controls.Add(this.butt_blacksmith);
			this.TCrafting.Controls.Add(this.blacksmithinfo);
			this.TCrafting.Controls.Add(this.butt_alchemy);
			this.TCrafting.Controls.Add(this.alchemyinfo);
			this.TCrafting.Controls.Add(this.Tinkering);
			this.TCrafting.Controls.Add(this.Tailoring);
			this.TCrafting.Controls.Add(this.Inscribe);
			this.TCrafting.Controls.Add(this.Fletching);
			this.TCrafting.Controls.Add(this.Cooking);
			this.TCrafting.Controls.Add(this.Carpentry);
			this.TCrafting.Controls.Add(this.Cartography);
			this.TCrafting.Controls.Add(this.Blacksmith);
			this.TCrafting.Controls.Add(this.Alchemy);
			this.TCrafting.Location = new System.Drawing.Point(4, 25);
			this.TCrafting.Name = "TCrafting";
			this.TCrafting.TabIndex = 0;
			this.TCrafting.Text = "Crafting";
			// 
			// butt_tinkering
			// 
			this.butt_tinkering.Location = new System.Drawing.Point(278, 231);
			this.butt_tinkering.Name = "butt_tinkering";
			this.butt_tinkering.Size = new System.Drawing.Size(29, 18);
			this.butt_tinkering.TabIndex = 26;
			this.butt_tinkering.Text = ">";
			this.butt_tinkering.Click += new System.EventHandler(this.butt_tinkering_Click);
			// 
			// tinkeringinfo
			// 
			this.tinkeringinfo.Location = new System.Drawing.Point(154, 231);
			this.tinkeringinfo.Name = "tinkeringinfo";
			this.tinkeringinfo.Size = new System.Drawing.Size(105, 22);
			this.tinkeringinfo.TabIndex = 25;
			this.tinkeringinfo.Text = "TextBox7";
			// 
			// butt_tailoring
			// 
			this.butt_tailoring.Location = new System.Drawing.Point(278, 203);
			this.butt_tailoring.Name = "butt_tailoring";
			this.butt_tailoring.Size = new System.Drawing.Size(29, 19);
			this.butt_tailoring.TabIndex = 24;
			this.butt_tailoring.Text = ">";
			this.butt_tailoring.Click += new System.EventHandler(this.butt_tailoring_Click);
			// 
			// tailoringinfo
			// 
			this.tailoringinfo.Location = new System.Drawing.Point(154, 203);
			this.tailoringinfo.Name = "tailoringinfo";
			this.tailoringinfo.Size = new System.Drawing.Size(105, 22);
			this.tailoringinfo.TabIndex = 23;
			this.tailoringinfo.Text = "TextBox8";
			// 
			// butt_inscribe
			// 
			this.butt_inscribe.Location = new System.Drawing.Point(278, 175);
			this.butt_inscribe.Name = "butt_inscribe";
			this.butt_inscribe.Size = new System.Drawing.Size(29, 19);
			this.butt_inscribe.TabIndex = 22;
			this.butt_inscribe.Text = ">";
			this.butt_inscribe.Click += new System.EventHandler(this.butt_inscribe_Click);
			// 
			// inscribeinfo
			// 
			this.inscribeinfo.Location = new System.Drawing.Point(154, 175);
			this.inscribeinfo.Name = "inscribeinfo";
			this.inscribeinfo.Size = new System.Drawing.Size(105, 22);
			this.inscribeinfo.TabIndex = 21;
			this.inscribeinfo.Text = "TextBox9";
			// 
			// butt_fletching
			// 
			this.butt_fletching.Location = new System.Drawing.Point(278, 148);
			this.butt_fletching.Name = "butt_fletching";
			this.butt_fletching.Size = new System.Drawing.Size(29, 18);
			this.butt_fletching.TabIndex = 20;
			this.butt_fletching.Text = ">";
			this.butt_fletching.Click += new System.EventHandler(this.butt_fletching_Click);
			// 
			// fletchinginfo
			// 
			this.fletchinginfo.Location = new System.Drawing.Point(154, 148);
			this.fletchinginfo.Name = "fletchinginfo";
			this.fletchinginfo.Size = new System.Drawing.Size(105, 22);
			this.fletchinginfo.TabIndex = 19;
			this.fletchinginfo.Text = "TextBox4";
			// 
			// butt_cooking
			// 
			this.butt_cooking.Location = new System.Drawing.Point(278, 120);
			this.butt_cooking.Name = "butt_cooking";
			this.butt_cooking.Size = new System.Drawing.Size(29, 18);
			this.butt_cooking.TabIndex = 18;
			this.butt_cooking.Text = ">";
			this.butt_cooking.Click += new System.EventHandler(this.butt_cooking_Click);
			// 
			// cookinginfo
			// 
			this.cookinginfo.Location = new System.Drawing.Point(154, 120);
			this.cookinginfo.Name = "cookinginfo";
			this.cookinginfo.Size = new System.Drawing.Size(105, 22);
			this.cookinginfo.TabIndex = 17;
			this.cookinginfo.Text = "TextBox5";
			// 
			// butt_carpentry
			// 
			this.butt_carpentry.Location = new System.Drawing.Point(278, 92);
			this.butt_carpentry.Name = "butt_carpentry";
			this.butt_carpentry.Size = new System.Drawing.Size(29, 19);
			this.butt_carpentry.TabIndex = 16;
			this.butt_carpentry.Text = ">";
			this.butt_carpentry.Click += new System.EventHandler(this.butt_carpentry_Click);
			// 
			// carpentryinfo
			// 
			this.carpentryinfo.Location = new System.Drawing.Point(154, 92);
			this.carpentryinfo.Name = "carpentryinfo";
			this.carpentryinfo.Size = new System.Drawing.Size(105, 22);
			this.carpentryinfo.TabIndex = 15;
			this.carpentryinfo.Text = "TextBox6";
			// 
			// butt_cartography
			// 
			this.butt_cartography.Location = new System.Drawing.Point(278, 65);
			this.butt_cartography.Name = "butt_cartography";
			this.butt_cartography.Size = new System.Drawing.Size(29, 18);
			this.butt_cartography.TabIndex = 14;
			this.butt_cartography.Text = ">";
			this.butt_cartography.Click += new System.EventHandler(this.butt_cartography_Click);
			// 
			// cartographyinfo
			// 
			this.cartographyinfo.Location = new System.Drawing.Point(154, 65);
			this.cartographyinfo.Name = "cartographyinfo";
			this.cartographyinfo.Size = new System.Drawing.Size(105, 22);
			this.cartographyinfo.TabIndex = 13;
			this.cartographyinfo.Text = "TextBox3";
			// 
			// butt_blacksmith
			// 
			this.butt_blacksmith.Location = new System.Drawing.Point(278, 37);
			this.butt_blacksmith.Name = "butt_blacksmith";
			this.butt_blacksmith.Size = new System.Drawing.Size(29, 18);
			this.butt_blacksmith.TabIndex = 12;
			this.butt_blacksmith.Text = ">";
			this.butt_blacksmith.Click += new System.EventHandler(this.butt_blacksmith_Click);
			// 
			// blacksmithinfo
			// 
			this.blacksmithinfo.Location = new System.Drawing.Point(154, 37);
			this.blacksmithinfo.Name = "blacksmithinfo";
			this.blacksmithinfo.Size = new System.Drawing.Size(105, 22);
			this.blacksmithinfo.TabIndex = 11;
			this.blacksmithinfo.Text = "TextBox2";
			// 
			// butt_alchemy
			// 
			this.butt_alchemy.Location = new System.Drawing.Point(278, 9);
			this.butt_alchemy.Name = "butt_alchemy";
			this.butt_alchemy.Size = new System.Drawing.Size(29, 19);
			this.butt_alchemy.TabIndex = 10;
			this.butt_alchemy.Text = ">";
			this.butt_alchemy.Click += new System.EventHandler(this.butt_alchemy_Click);
			// 
			// alchemyinfo
			// 
			this.alchemyinfo.Location = new System.Drawing.Point(154, 9);
			this.alchemyinfo.Name = "alchemyinfo";
			this.alchemyinfo.Size = new System.Drawing.Size(105, 22);
			this.alchemyinfo.TabIndex = 9;
			this.alchemyinfo.Text = "TextBox1";
			// 
			// Tinkering
			// 
			this.Tinkering.Location = new System.Drawing.Point(10, 231);
			this.Tinkering.Name = "Tinkering";
			this.Tinkering.Size = new System.Drawing.Size(138, 18);
			this.Tinkering.TabIndex = 8;
			this.Tinkering.Text = "Tinkering";
			// 
			// Tailoring
			// 
			this.Tailoring.Location = new System.Drawing.Point(10, 203);
			this.Tailoring.Name = "Tailoring";
			this.Tailoring.Size = new System.Drawing.Size(138, 19);
			this.Tailoring.TabIndex = 7;
			this.Tailoring.Text = "Tailoring";
			// 
			// Inscribe
			// 
			this.Inscribe.Location = new System.Drawing.Point(10, 175);
			this.Inscribe.Name = "Inscribe";
			this.Inscribe.Size = new System.Drawing.Size(138, 19);
			this.Inscribe.TabIndex = 6;
			this.Inscribe.Text = "Inscribe";
			// 
			// Fletching
			// 
			this.Fletching.Location = new System.Drawing.Point(10, 148);
			this.Fletching.Name = "Fletching";
			this.Fletching.Size = new System.Drawing.Size(138, 18);
			this.Fletching.TabIndex = 5;
			this.Fletching.Text = "Fletching";
			// 
			// Cooking
			// 
			this.Cooking.Location = new System.Drawing.Point(10, 120);
			this.Cooking.Name = "Cooking";
			this.Cooking.Size = new System.Drawing.Size(138, 18);
			this.Cooking.TabIndex = 4;
			this.Cooking.Text = "Cooking";
			// 
			// Carpentry
			// 
			this.Carpentry.Location = new System.Drawing.Point(10, 92);
			this.Carpentry.Name = "Carpentry";
			this.Carpentry.Size = new System.Drawing.Size(138, 19);
			this.Carpentry.TabIndex = 3;
			this.Carpentry.Text = "Carpentry";
			// 
			// Cartography
			// 
			this.Cartography.Location = new System.Drawing.Point(10, 65);
			this.Cartography.Name = "Cartography";
			this.Cartography.Size = new System.Drawing.Size(138, 18);
			this.Cartography.TabIndex = 2;
			this.Cartography.Text = "Cartography";
			// 
			// Blacksmith
			// 
			this.Blacksmith.Location = new System.Drawing.Point(10, 37);
			this.Blacksmith.Name = "Blacksmith";
			this.Blacksmith.Size = new System.Drawing.Size(138, 18);
			this.Blacksmith.TabIndex = 1;
			this.Blacksmith.Text = "Blacksmith";
			// 
			// Alchemy
			// 
			this.Alchemy.Location = new System.Drawing.Point(10, 9);
			this.Alchemy.Name = "Alchemy";
			this.Alchemy.Size = new System.Drawing.Size(138, 19);
			this.Alchemy.TabIndex = 0;
			this.Alchemy.Text = "Alchemy";
			// 
			// TBardic
			// 
			this.TBardic.Controls.Add(this.butt_provocation);
			this.TBardic.Controls.Add(this.provocationinfo);
			this.TBardic.Controls.Add(this.butt_peacemaking);
			this.TBardic.Controls.Add(this.peacemakinginfo);
			this.TBardic.Controls.Add(this.butt_musicianship);
			this.TBardic.Controls.Add(this.musicianshipinfo);
			this.TBardic.Controls.Add(this.butt_discordance);
			this.TBardic.Controls.Add(this.discordanceinfo);
			this.TBardic.Controls.Add(this.Provocation);
			this.TBardic.Controls.Add(this.Peacemaking);
			this.TBardic.Controls.Add(this.Musicianship);
			this.TBardic.Controls.Add(this.Discordance);
			this.TBardic.Location = new System.Drawing.Point(4, 25);
			this.TBardic.Name = "TBardic";
			this.TBardic.TabIndex = 1;
			this.TBardic.Text = "Bardic";
			this.TBardic.Visible = false;
			// 
			// butt_provocation
			// 
			this.butt_provocation.Location = new System.Drawing.Point(278, 92);
			this.butt_provocation.Name = "butt_provocation";
			this.butt_provocation.Size = new System.Drawing.Size(29, 19);
			this.butt_provocation.TabIndex = 43;
			this.butt_provocation.Text = ">";
			this.butt_provocation.Click += new System.EventHandler(this.butt_provocation_Click);
			// 
			// provocationinfo
			// 
			this.provocationinfo.Location = new System.Drawing.Point(154, 92);
			this.provocationinfo.Name = "provocationinfo";
			this.provocationinfo.Size = new System.Drawing.Size(105, 22);
			this.provocationinfo.TabIndex = 42;
			this.provocationinfo.Text = "provocationinfo";
			// 
			// butt_peacemaking
			// 
			this.butt_peacemaking.Location = new System.Drawing.Point(278, 65);
			this.butt_peacemaking.Name = "butt_peacemaking";
			this.butt_peacemaking.Size = new System.Drawing.Size(29, 18);
			this.butt_peacemaking.TabIndex = 41;
			this.butt_peacemaking.Text = ">";
			this.butt_peacemaking.Click += new System.EventHandler(this.butt_peacemaking_Click);
			// 
			// peacemakinginfo
			// 
			this.peacemakinginfo.Location = new System.Drawing.Point(154, 65);
			this.peacemakinginfo.Name = "peacemakinginfo";
			this.peacemakinginfo.Size = new System.Drawing.Size(105, 22);
			this.peacemakinginfo.TabIndex = 40;
			this.peacemakinginfo.Text = "peacemakinginfo";
			// 
			// butt_musicianship
			// 
			this.butt_musicianship.Location = new System.Drawing.Point(278, 37);
			this.butt_musicianship.Name = "butt_musicianship";
			this.butt_musicianship.Size = new System.Drawing.Size(29, 18);
			this.butt_musicianship.TabIndex = 39;
			this.butt_musicianship.Text = ">";
			this.butt_musicianship.Click += new System.EventHandler(this.butt_musicianship_Click);
			// 
			// musicianshipinfo
			// 
			this.musicianshipinfo.Location = new System.Drawing.Point(154, 37);
			this.musicianshipinfo.Name = "musicianshipinfo";
			this.musicianshipinfo.Size = new System.Drawing.Size(105, 22);
			this.musicianshipinfo.TabIndex = 38;
			this.musicianshipinfo.Text = "musicianshipinfo";
			// 
			// butt_discordance
			// 
			this.butt_discordance.Location = new System.Drawing.Point(278, 9);
			this.butt_discordance.Name = "butt_discordance";
			this.butt_discordance.Size = new System.Drawing.Size(29, 19);
			this.butt_discordance.TabIndex = 37;
			this.butt_discordance.Text = ">";
			this.butt_discordance.Click += new System.EventHandler(this.butt_discordance_Click);
			// 
			// discordanceinfo
			// 
			this.discordanceinfo.Location = new System.Drawing.Point(154, 9);
			this.discordanceinfo.Name = "discordanceinfo";
			this.discordanceinfo.Size = new System.Drawing.Size(105, 22);
			this.discordanceinfo.TabIndex = 36;
			this.discordanceinfo.Text = "discordanceinfo";
			// 
			// Provocation
			// 
			this.Provocation.Location = new System.Drawing.Point(10, 92);
			this.Provocation.Name = "Provocation";
			this.Provocation.Size = new System.Drawing.Size(138, 19);
			this.Provocation.TabIndex = 30;
			this.Provocation.Text = "Provocation";
			// 
			// Peacemaking
			// 
			this.Peacemaking.Location = new System.Drawing.Point(10, 65);
			this.Peacemaking.Name = "Peacemaking";
			this.Peacemaking.Size = new System.Drawing.Size(138, 18);
			this.Peacemaking.TabIndex = 29;
			this.Peacemaking.Text = "Peacemaking";
			// 
			// Musicianship
			// 
			this.Musicianship.Location = new System.Drawing.Point(10, 37);
			this.Musicianship.Name = "Musicianship";
			this.Musicianship.Size = new System.Drawing.Size(138, 18);
			this.Musicianship.TabIndex = 28;
			this.Musicianship.Text = "Musicianship";
			// 
			// Discordance
			// 
			this.Discordance.Location = new System.Drawing.Point(10, 9);
			this.Discordance.Name = "Discordance";
			this.Discordance.Size = new System.Drawing.Size(138, 19);
			this.Discordance.TabIndex = 27;
			this.Discordance.Text = "Discordance";
			// 
			// TMagical
			// 
			this.TMagical.Controls.Add(this.butt_bushido);
			this.TMagical.Controls.Add(this.bushidoinfo);
			this.TMagical.Controls.Add(this.butt_ninjitsu);
			this.TMagical.Controls.Add(this.ninjitsuinfo);
			this.TMagical.Controls.Add(this.butt_spiritspeak);
			this.TMagical.Controls.Add(this.spiritspeakinfo);
			this.TMagical.Controls.Add(this.butt_necromancy);
			this.TMagical.Controls.Add(this.necromancyinfo);
			this.TMagical.Controls.Add(this.butt_meditation);
			this.TMagical.Controls.Add(this.meditationinfo);
			this.TMagical.Controls.Add(this.butt_magicresist);
			this.TMagical.Controls.Add(this.magicresistinfo);
			this.TMagical.Controls.Add(this.butt_magery);
			this.TMagical.Controls.Add(this.mageryinfo);
			this.TMagical.Controls.Add(this.butt_evalint);
			this.TMagical.Controls.Add(this.evalintinfo);
			this.TMagical.Controls.Add(this.butt_chivalry);
			this.TMagical.Controls.Add(this.chivalryinfo);
			this.TMagical.Controls.Add(this.Bushido);
			this.TMagical.Controls.Add(this.Ninjitsu);
			this.TMagical.Controls.Add(this.SpiritSpeak);
			this.TMagical.Controls.Add(this.Necromancy);
			this.TMagical.Controls.Add(this.Meditation);
			this.TMagical.Controls.Add(this.MagicResist);
			this.TMagical.Controls.Add(this.Magery);
			this.TMagical.Controls.Add(this.EvalInt);
			this.TMagical.Controls.Add(this.Chivalry);
			this.TMagical.Location = new System.Drawing.Point(4, 25);
			this.TMagical.Name = "TMagical";
			this.TMagical.TabIndex = 2;
			this.TMagical.Text = "Magical";
			this.TMagical.Visible = false;
			// 
			// butt_bushido
			// 
			this.butt_bushido.Location = new System.Drawing.Point(278, 231);
			this.butt_bushido.Name = "butt_bushido";
			this.butt_bushido.Size = new System.Drawing.Size(29, 18);
			this.butt_bushido.TabIndex = 53;
			this.butt_bushido.Text = ">";
			this.butt_bushido.Click += new System.EventHandler(this.butt_bushido_Click);
			// 
			// bushidoinfo
			// 
			this.bushidoinfo.Location = new System.Drawing.Point(154, 231);
			this.bushidoinfo.Name = "bushidoinfo";
			this.bushidoinfo.Size = new System.Drawing.Size(105, 22);
			this.bushidoinfo.TabIndex = 52;
			this.bushidoinfo.Text = "TextBox7";
			// 
			// butt_ninjitsu
			// 
			this.butt_ninjitsu.Location = new System.Drawing.Point(278, 203);
			this.butt_ninjitsu.Name = "butt_ninjitsu";
			this.butt_ninjitsu.Size = new System.Drawing.Size(29, 19);
			this.butt_ninjitsu.TabIndex = 51;
			this.butt_ninjitsu.Text = ">";
			this.butt_ninjitsu.Click += new System.EventHandler(this.butt_ninjitsu_Click);
			// 
			// ninjitsuinfo
			// 
			this.ninjitsuinfo.Location = new System.Drawing.Point(154, 203);
			this.ninjitsuinfo.Name = "ninjitsuinfo";
			this.ninjitsuinfo.Size = new System.Drawing.Size(105, 22);
			this.ninjitsuinfo.TabIndex = 50;
			this.ninjitsuinfo.Text = "TextBox8";
			// 
			// butt_spiritspeak
			// 
			this.butt_spiritspeak.Location = new System.Drawing.Point(278, 175);
			this.butt_spiritspeak.Name = "butt_spiritspeak";
			this.butt_spiritspeak.Size = new System.Drawing.Size(29, 19);
			this.butt_spiritspeak.TabIndex = 49;
			this.butt_spiritspeak.Text = ">";
			this.butt_spiritspeak.Click += new System.EventHandler(this.butt_spiritspeak_Click);
			// 
			// spiritspeakinfo
			// 
			this.spiritspeakinfo.Location = new System.Drawing.Point(154, 175);
			this.spiritspeakinfo.Name = "spiritspeakinfo";
			this.spiritspeakinfo.Size = new System.Drawing.Size(105, 22);
			this.spiritspeakinfo.TabIndex = 48;
			this.spiritspeakinfo.Text = "TextBox9";
			// 
			// butt_necromancy
			// 
			this.butt_necromancy.Location = new System.Drawing.Point(278, 148);
			this.butt_necromancy.Name = "butt_necromancy";
			this.butt_necromancy.Size = new System.Drawing.Size(29, 18);
			this.butt_necromancy.TabIndex = 47;
			this.butt_necromancy.Text = ">";
			this.butt_necromancy.Click += new System.EventHandler(this.butt_necromancy_Click);
			// 
			// necromancyinfo
			// 
			this.necromancyinfo.Location = new System.Drawing.Point(154, 148);
			this.necromancyinfo.Name = "necromancyinfo";
			this.necromancyinfo.Size = new System.Drawing.Size(105, 22);
			this.necromancyinfo.TabIndex = 46;
			this.necromancyinfo.Text = "TextBox4";
			// 
			// butt_meditation
			// 
			this.butt_meditation.Location = new System.Drawing.Point(278, 120);
			this.butt_meditation.Name = "butt_meditation";
			this.butt_meditation.Size = new System.Drawing.Size(29, 18);
			this.butt_meditation.TabIndex = 45;
			this.butt_meditation.Text = ">";
			this.butt_meditation.Click += new System.EventHandler(this.butt_meditation_Click);
			// 
			// meditationinfo
			// 
			this.meditationinfo.Location = new System.Drawing.Point(154, 120);
			this.meditationinfo.Name = "meditationinfo";
			this.meditationinfo.Size = new System.Drawing.Size(105, 22);
			this.meditationinfo.TabIndex = 44;
			this.meditationinfo.Text = "TextBox5";
			// 
			// butt_magicresist
			// 
			this.butt_magicresist.Location = new System.Drawing.Point(278, 92);
			this.butt_magicresist.Name = "butt_magicresist";
			this.butt_magicresist.Size = new System.Drawing.Size(29, 19);
			this.butt_magicresist.TabIndex = 43;
			this.butt_magicresist.Text = ">";
			this.butt_magicresist.Click += new System.EventHandler(this.butt_magicresist_Click);
			// 
			// magicresistinfo
			// 
			this.magicresistinfo.Location = new System.Drawing.Point(154, 92);
			this.magicresistinfo.Name = "magicresistinfo";
			this.magicresistinfo.Size = new System.Drawing.Size(105, 22);
			this.magicresistinfo.TabIndex = 42;
			this.magicresistinfo.Text = "TextBox6";
			// 
			// butt_magery
			// 
			this.butt_magery.Location = new System.Drawing.Point(278, 65);
			this.butt_magery.Name = "butt_magery";
			this.butt_magery.Size = new System.Drawing.Size(29, 18);
			this.butt_magery.TabIndex = 41;
			this.butt_magery.Text = ">";
			this.butt_magery.Click += new System.EventHandler(this.butt_magery_Click);
			// 
			// mageryinfo
			// 
			this.mageryinfo.Location = new System.Drawing.Point(154, 65);
			this.mageryinfo.Name = "mageryinfo";
			this.mageryinfo.Size = new System.Drawing.Size(105, 22);
			this.mageryinfo.TabIndex = 40;
			this.mageryinfo.Text = "TextBox3";
			// 
			// butt_evalint
			// 
			this.butt_evalint.Location = new System.Drawing.Point(278, 37);
			this.butt_evalint.Name = "butt_evalint";
			this.butt_evalint.Size = new System.Drawing.Size(29, 18);
			this.butt_evalint.TabIndex = 39;
			this.butt_evalint.Text = ">";
			this.butt_evalint.Click += new System.EventHandler(this.butt_evalint_Click);
			// 
			// evalintinfo
			// 
			this.evalintinfo.Location = new System.Drawing.Point(154, 37);
			this.evalintinfo.Name = "evalintinfo";
			this.evalintinfo.Size = new System.Drawing.Size(105, 22);
			this.evalintinfo.TabIndex = 38;
			this.evalintinfo.Text = "TextBox2";
			// 
			// butt_chivalry
			// 
			this.butt_chivalry.Location = new System.Drawing.Point(278, 9);
			this.butt_chivalry.Name = "butt_chivalry";
			this.butt_chivalry.Size = new System.Drawing.Size(29, 19);
			this.butt_chivalry.TabIndex = 37;
			this.butt_chivalry.Text = ">";
			this.butt_chivalry.Click += new System.EventHandler(this.butt_chivalry_Click);
			// 
			// chivalryinfo
			// 
			this.chivalryinfo.Location = new System.Drawing.Point(154, 9);
			this.chivalryinfo.Name = "chivalryinfo";
			this.chivalryinfo.Size = new System.Drawing.Size(105, 22);
			this.chivalryinfo.TabIndex = 36;
			this.chivalryinfo.Text = "TextBox1";
			// 
			// Bushido
			// 
			this.Bushido.Location = new System.Drawing.Point(10, 231);
			this.Bushido.Name = "Bushido";
			this.Bushido.Size = new System.Drawing.Size(138, 18);
			this.Bushido.TabIndex = 35;
			this.Bushido.Text = "Bushido";
			// 
			// Ninjitsu
			// 
			this.Ninjitsu.Location = new System.Drawing.Point(10, 203);
			this.Ninjitsu.Name = "Ninjitsu";
			this.Ninjitsu.Size = new System.Drawing.Size(138, 19);
			this.Ninjitsu.TabIndex = 34;
			this.Ninjitsu.Text = "Ninjitsu";
			// 
			// SpiritSpeak
			// 
			this.SpiritSpeak.Location = new System.Drawing.Point(10, 175);
			this.SpiritSpeak.Name = "SpiritSpeak";
			this.SpiritSpeak.Size = new System.Drawing.Size(138, 19);
			this.SpiritSpeak.TabIndex = 33;
			this.SpiritSpeak.Text = "SpiritSpeak";
			// 
			// Necromancy
			// 
			this.Necromancy.Location = new System.Drawing.Point(10, 148);
			this.Necromancy.Name = "Necromancy";
			this.Necromancy.Size = new System.Drawing.Size(138, 18);
			this.Necromancy.TabIndex = 32;
			this.Necromancy.Text = "Necromancy";
			// 
			// Meditation
			// 
			this.Meditation.Location = new System.Drawing.Point(10, 120);
			this.Meditation.Name = "Meditation";
			this.Meditation.Size = new System.Drawing.Size(138, 18);
			this.Meditation.TabIndex = 31;
			this.Meditation.Text = "Meditation";
			// 
			// MagicResist
			// 
			this.MagicResist.Location = new System.Drawing.Point(10, 92);
			this.MagicResist.Name = "MagicResist";
			this.MagicResist.Size = new System.Drawing.Size(138, 19);
			this.MagicResist.TabIndex = 30;
			this.MagicResist.Text = "MagicResist";
			// 
			// Magery
			// 
			this.Magery.Location = new System.Drawing.Point(10, 65);
			this.Magery.Name = "Magery";
			this.Magery.Size = new System.Drawing.Size(138, 18);
			this.Magery.TabIndex = 29;
			this.Magery.Text = "Magery";
			// 
			// EvalInt
			// 
			this.EvalInt.Location = new System.Drawing.Point(10, 37);
			this.EvalInt.Name = "EvalInt";
			this.EvalInt.Size = new System.Drawing.Size(138, 18);
			this.EvalInt.TabIndex = 28;
			this.EvalInt.Text = "EvalInt";
			// 
			// Chivalry
			// 
			this.Chivalry.Location = new System.Drawing.Point(10, 9);
			this.Chivalry.Name = "Chivalry";
			this.Chivalry.Size = new System.Drawing.Size(138, 19);
			this.Chivalry.TabIndex = 27;
			this.Chivalry.Text = "Chivalry";
			// 
			// TMisc
			// 
			this.TMisc.Controls.Add(this.butt_veterinary);
			this.TMisc.Controls.Add(this.veterinaryinfo);
			this.TMisc.Controls.Add(this.Veterinary);
			this.TMisc.Controls.Add(this.butt_snooping);
			this.TMisc.Controls.Add(this.snoopinginfo);
			this.TMisc.Controls.Add(this.butt_mining);
			this.TMisc.Controls.Add(this.mininginfo);
			this.TMisc.Controls.Add(this.butt_lumberjacking);
			this.TMisc.Controls.Add(this.lumberjackinginfo);
			this.TMisc.Controls.Add(this.butt_lockpicking);
			this.TMisc.Controls.Add(this.lockpickinginfo);
			this.TMisc.Controls.Add(this.butt_herding);
			this.TMisc.Controls.Add(this.herdinginfo);
			this.TMisc.Controls.Add(this.butt_healing);
			this.TMisc.Controls.Add(this.healinginfo);
			this.TMisc.Controls.Add(this.butt_focus);
			this.TMisc.Controls.Add(this.focusinfo);
			this.TMisc.Controls.Add(this.butt_fishing);
			this.TMisc.Controls.Add(this.fishinginfo);
			this.TMisc.Controls.Add(this.butt_camping);
			this.TMisc.Controls.Add(this.campinginfo);
			this.TMisc.Controls.Add(this.Snooping);
			this.TMisc.Controls.Add(this.Mining);
			this.TMisc.Controls.Add(this.Lumberjacking);
			this.TMisc.Controls.Add(this.Lockpicking);
			this.TMisc.Controls.Add(this.Herding);
			this.TMisc.Controls.Add(this.Healing);
			this.TMisc.Controls.Add(this.focuslabel);
			this.TMisc.Controls.Add(this.Fishing);
			this.TMisc.Controls.Add(this.Camping);
			this.TMisc.Location = new System.Drawing.Point(4, 25);
			this.TMisc.Name = "TMisc";
			this.TMisc.TabIndex = 3;
			this.TMisc.Text = "Misc";
			this.TMisc.Visible = false;
			// 
			// butt_veterinary
			// 
			this.butt_veterinary.Location = new System.Drawing.Point(278, 222);
			this.butt_veterinary.Name = "butt_veterinary";
			this.butt_veterinary.Size = new System.Drawing.Size(29, 19);
			this.butt_veterinary.TabIndex = 56;
			this.butt_veterinary.Text = ">";
			this.butt_veterinary.Click += new System.EventHandler(this.butt_veterinary_Click);
			// 
			// veterinaryinfo
			// 
			this.veterinaryinfo.Location = new System.Drawing.Point(154, 222);
			this.veterinaryinfo.Name = "veterinaryinfo";
			this.veterinaryinfo.Size = new System.Drawing.Size(105, 22);
			this.veterinaryinfo.TabIndex = 55;
			this.veterinaryinfo.Text = "TextBox7";
			// 
			// Veterinary
			// 
			this.Veterinary.Location = new System.Drawing.Point(10, 222);
			this.Veterinary.Name = "Veterinary";
			this.Veterinary.Size = new System.Drawing.Size(110, 18);
			this.Veterinary.TabIndex = 54;
			this.Veterinary.Text = "Veterinary";
			// 
			// butt_snooping
			// 
			this.butt_snooping.Location = new System.Drawing.Point(278, 199);
			this.butt_snooping.Name = "butt_snooping";
			this.butt_snooping.Size = new System.Drawing.Size(29, 18);
			this.butt_snooping.TabIndex = 53;
			this.butt_snooping.Text = ">";
			this.butt_snooping.Click += new System.EventHandler(this.butt_snooping_Click);
			// 
			// snoopinginfo
			// 
			this.snoopinginfo.Location = new System.Drawing.Point(154, 199);
			this.snoopinginfo.Name = "snoopinginfo";
			this.snoopinginfo.Size = new System.Drawing.Size(105, 22);
			this.snoopinginfo.TabIndex = 52;
			this.snoopinginfo.Text = "TextBox7";
			// 
			// butt_mining
			// 
			this.butt_mining.Location = new System.Drawing.Point(278, 176);
			this.butt_mining.Name = "butt_mining";
			this.butt_mining.Size = new System.Drawing.Size(29, 19);
			this.butt_mining.TabIndex = 51;
			this.butt_mining.Text = ">";
			this.butt_mining.Click += new System.EventHandler(this.butt_mining_Click);
			// 
			// mininginfo
			// 
			this.mininginfo.Location = new System.Drawing.Point(154, 176);
			this.mininginfo.Name = "mininginfo";
			this.mininginfo.Size = new System.Drawing.Size(105, 22);
			this.mininginfo.TabIndex = 50;
			this.mininginfo.Text = "TextBox8";
			// 
			// butt_lumberjacking
			// 
			this.butt_lumberjacking.Location = new System.Drawing.Point(278, 153);
			this.butt_lumberjacking.Name = "butt_lumberjacking";
			this.butt_lumberjacking.Size = new System.Drawing.Size(29, 19);
			this.butt_lumberjacking.TabIndex = 49;
			this.butt_lumberjacking.Text = ">";
			this.butt_lumberjacking.Click += new System.EventHandler(this.butt_lumberjacking_Click);
			// 
			// lumberjackinginfo
			// 
			this.lumberjackinginfo.Location = new System.Drawing.Point(154, 153);
			this.lumberjackinginfo.Name = "lumberjackinginfo";
			this.lumberjackinginfo.Size = new System.Drawing.Size(105, 22);
			this.lumberjackinginfo.TabIndex = 48;
			this.lumberjackinginfo.Text = "TextBox9";
			// 
			// butt_lockpicking
			// 
			this.butt_lockpicking.Location = new System.Drawing.Point(278, 129);
			this.butt_lockpicking.Name = "butt_lockpicking";
			this.butt_lockpicking.Size = new System.Drawing.Size(29, 18);
			this.butt_lockpicking.TabIndex = 47;
			this.butt_lockpicking.Text = ">";
			this.butt_lockpicking.Click += new System.EventHandler(this.butt_lockpicking_Click);
			// 
			// lockpickinginfo
			// 
			this.lockpickinginfo.Location = new System.Drawing.Point(154, 129);
			this.lockpickinginfo.Name = "lockpickinginfo";
			this.lockpickinginfo.Size = new System.Drawing.Size(105, 22);
			this.lockpickinginfo.TabIndex = 46;
			this.lockpickinginfo.Text = "TextBox4";
			// 
			// butt_herding
			// 
			this.butt_herding.Location = new System.Drawing.Point(278, 105);
			this.butt_herding.Name = "butt_herding";
			this.butt_herding.Size = new System.Drawing.Size(29, 18);
			this.butt_herding.TabIndex = 45;
			this.butt_herding.Text = ">";
			this.butt_herding.Click += new System.EventHandler(this.butt_herding_Click);
			// 
			// herdinginfo
			// 
			this.herdinginfo.Location = new System.Drawing.Point(154, 105);
			this.herdinginfo.Name = "herdinginfo";
			this.herdinginfo.Size = new System.Drawing.Size(105, 22);
			this.herdinginfo.TabIndex = 44;
			this.herdinginfo.Text = "TextBox5";
			// 
			// butt_healing
			// 
			this.butt_healing.Location = new System.Drawing.Point(278, 81);
			this.butt_healing.Name = "butt_healing";
			this.butt_healing.Size = new System.Drawing.Size(29, 19);
			this.butt_healing.TabIndex = 43;
			this.butt_healing.Text = ">";
			this.butt_healing.Click += new System.EventHandler(this.butt_healing_Click);
			// 
			// healinginfo
			// 
			this.healinginfo.Location = new System.Drawing.Point(154, 81);
			this.healinginfo.Name = "healinginfo";
			this.healinginfo.Size = new System.Drawing.Size(105, 22);
			this.healinginfo.TabIndex = 42;
			this.healinginfo.Text = "TextBox6";
			// 
			// butt_focus
			// 
			this.butt_focus.Location = new System.Drawing.Point(278, 57);
			this.butt_focus.Name = "butt_focus";
			this.butt_focus.Size = new System.Drawing.Size(29, 18);
			this.butt_focus.TabIndex = 57;
			this.butt_focus.Text = ">";
			this.butt_focus.Click +=new EventHandler(butt_focus_Click);
			// 
			// focusinfo
			// 
			this.focusinfo.Location = new System.Drawing.Point(154, 57);
			this.focusinfo.Name = "focusinfo";
			this.focusinfo.Size = new System.Drawing.Size(105, 22);
			this.focusinfo.TabIndex = 58;
			this.focusinfo.Text = "TextBox3";
			// 
			// butt_fishing
			// 
			this.butt_fishing.Location = new System.Drawing.Point(278, 33);
			this.butt_fishing.Name = "butt_fishing";
			this.butt_fishing.Size = new System.Drawing.Size(29, 18);
			this.butt_fishing.TabIndex = 39;
			this.butt_fishing.Text = ">";
			this.butt_fishing.Click += new System.EventHandler(this.butt_fishing_Click);
			// 
			// fishinginfo
			// 
			this.fishinginfo.Location = new System.Drawing.Point(154, 33);
			this.fishinginfo.Name = "fishinginfo";
			this.fishinginfo.Size = new System.Drawing.Size(105, 22);
			this.fishinginfo.TabIndex = 38;
			this.fishinginfo.Text = "TextBox2";
			// 
			// butt_camping
			// 
			this.butt_camping.Location = new System.Drawing.Point(278, 9);
			this.butt_camping.Name = "butt_camping";
			this.butt_camping.Size = new System.Drawing.Size(29, 19);
			this.butt_camping.TabIndex = 37;
			this.butt_camping.Text = ">";
			this.butt_camping.Click += new System.EventHandler(this.butt_camping_Click);
			// 
			// campinginfo
			// 
			this.campinginfo.Location = new System.Drawing.Point(154, 9);
			this.campinginfo.Name = "campinginfo";
			this.campinginfo.Size = new System.Drawing.Size(105, 22);
			this.campinginfo.TabIndex = 36;
			this.campinginfo.Text = "TextBox1";
			// 
			// Snooping
			// 
			this.Snooping.Location = new System.Drawing.Point(10, 199);
			this.Snooping.Name = "Snooping";
			this.Snooping.Size = new System.Drawing.Size(110, 18);
			this.Snooping.TabIndex = 35;
			this.Snooping.Text = "Snooping";
			// 
			// Mining
			// 
			this.Mining.Location = new System.Drawing.Point(10, 176);
			this.Mining.Name = "Mining";
			this.Mining.Size = new System.Drawing.Size(110, 18);
			this.Mining.TabIndex = 34;
			this.Mining.Text = "Mining";
			// 
			// Lumberjacking
			// 
			this.Lumberjacking.Location = new System.Drawing.Point(10, 153);
			this.Lumberjacking.Name = "Lumberjacking";
			this.Lumberjacking.Size = new System.Drawing.Size(110, 18);
			this.Lumberjacking.TabIndex = 33;
			this.Lumberjacking.Text = "Lumberjacking";
			// 
			// Lockpicking
			// 
			this.Lockpicking.Location = new System.Drawing.Point(10, 129);
			this.Lockpicking.Name = "Lockpicking";
			this.Lockpicking.Size = new System.Drawing.Size(110, 18);
			this.Lockpicking.TabIndex = 32;
			this.Lockpicking.Text = "Lockpicking";
			// 
			// Herding
			// 
			this.Herding.Location = new System.Drawing.Point(10, 105);
			this.Herding.Name = "Herding";
			this.Herding.Size = new System.Drawing.Size(110, 18);
			this.Herding.TabIndex = 31;
			this.Herding.Text = "Herding";
			// 
			// Healing
			// 
			this.Healing.Location = new System.Drawing.Point(10, 81);
			this.Healing.Name = "Healing";
			this.Healing.Size = new System.Drawing.Size(110, 18);
			this.Healing.TabIndex = 30;
			this.Healing.Text = "Healing";
			// 
			// focuslabel
			// 
			this.focuslabel.Location = new System.Drawing.Point(10, 57);
			this.focuslabel.Name = "Focus";
			this.focuslabel.Size = new System.Drawing.Size(110, 18);
			this.focuslabel.TabIndex = 59;
			this.focuslabel.Text = "Focus";
			// 
			// Fishing
			// 
			this.Fishing.Location = new System.Drawing.Point(10, 33);
			this.Fishing.Name = "Fishing";
			this.Fishing.Size = new System.Drawing.Size(110, 18);
			this.Fishing.TabIndex = 28;
			this.Fishing.Text = "Fishing";
			// 
			// Camping
			// 
			this.Camping.Location = new System.Drawing.Point(10, 9);
			this.Camping.Name = "Camping";
			this.Camping.Size = new System.Drawing.Size(110, 18);
			this.Camping.TabIndex = 27;
			this.Camping.Text = "Camping";
			// 
			// TCombat
			// 
			this.TCombat.Controls.Add(this.butt_wrestling);
			this.TCombat.Controls.Add(this.wrestlinginfo);
			this.TCombat.Controls.Add(this.butt_tactics);
			this.TCombat.Controls.Add(this.tacticsinfo);
			this.TCombat.Controls.Add(this.butt_swords);
			this.TCombat.Controls.Add(this.swordsinfo);
			this.TCombat.Controls.Add(this.butt_parry);
			this.TCombat.Controls.Add(this.parryinfo);
			this.TCombat.Controls.Add(this.butt_macing);
			this.TCombat.Controls.Add(this.macinginfo);
			this.TCombat.Controls.Add(this.butt_fencing);
			this.TCombat.Controls.Add(this.fencinginfo);
			this.TCombat.Controls.Add(this.butt_archery);
			this.TCombat.Controls.Add(this.archeryinfo);
			this.TCombat.Controls.Add(this.Wrestling);
			this.TCombat.Controls.Add(this.Tactics);
			this.TCombat.Controls.Add(this.Swords);
			this.TCombat.Controls.Add(this.Parry);
			this.TCombat.Controls.Add(this.Macing);
			this.TCombat.Controls.Add(this.Fencing);
			this.TCombat.Controls.Add(this.Archery);
			this.TCombat.Location = new System.Drawing.Point(4, 25);
			this.TCombat.Name = "TCombat";
			this.TCombat.TabIndex = 4;
			this.TCombat.Text = "Combat";
			this.TCombat.Visible = false;
			// 
			// butt_wrestling
			// 
			this.butt_wrestling.Location = new System.Drawing.Point(278, 175);
			this.butt_wrestling.Name = "butt_wrestling";
			this.butt_wrestling.Size = new System.Drawing.Size(29, 19);
			this.butt_wrestling.TabIndex = 49;
			this.butt_wrestling.Text = ">";
			this.butt_wrestling.Click += new System.EventHandler(this.butt_wrestling_Click);
			// 
			// wrestlinginfo
			// 
			this.wrestlinginfo.Location = new System.Drawing.Point(154, 175);
			this.wrestlinginfo.Name = "wrestlinginfo";
			this.wrestlinginfo.Size = new System.Drawing.Size(105, 22);
			this.wrestlinginfo.TabIndex = 48;
			this.wrestlinginfo.Text = "TextBox9";
			// 
			// butt_tactics
			// 
			this.butt_tactics.Location = new System.Drawing.Point(278, 148);
			this.butt_tactics.Name = "butt_tactics";
			this.butt_tactics.Size = new System.Drawing.Size(29, 18);
			this.butt_tactics.TabIndex = 47;
			this.butt_tactics.Text = ">";
			this.butt_tactics.Click += new System.EventHandler(this.butt_tactics_Click);
			// 
			// tacticsinfo
			// 
			this.tacticsinfo.Location = new System.Drawing.Point(154, 148);
			this.tacticsinfo.Name = "tacticsinfo";
			this.tacticsinfo.Size = new System.Drawing.Size(105, 22);
			this.tacticsinfo.TabIndex = 46;
			this.tacticsinfo.Text = "TextBox4";
			// 
			// butt_swords
			// 
			this.butt_swords.Location = new System.Drawing.Point(278, 120);
			this.butt_swords.Name = "butt_swords";
			this.butt_swords.Size = new System.Drawing.Size(29, 18);
			this.butt_swords.TabIndex = 45;
			this.butt_swords.Text = ">";
			this.butt_swords.Click += new System.EventHandler(this.butt_swords_Click);
			// 
			// swordsinfo
			// 
			this.swordsinfo.Location = new System.Drawing.Point(154, 120);
			this.swordsinfo.Name = "swordsinfo";
			this.swordsinfo.Size = new System.Drawing.Size(105, 22);
			this.swordsinfo.TabIndex = 44;
			this.swordsinfo.Text = "TextBox5";
			// 
			// butt_parry
			// 
			this.butt_parry.Location = new System.Drawing.Point(278, 92);
			this.butt_parry.Name = "butt_parry";
			this.butt_parry.Size = new System.Drawing.Size(29, 19);
			this.butt_parry.TabIndex = 43;
			this.butt_parry.Text = ">";
			this.butt_parry.Click += new System.EventHandler(this.butt_parry_Click);
			// 
			// parryinfo
			// 
			this.parryinfo.Location = new System.Drawing.Point(154, 92);
			this.parryinfo.Name = "parryinfo";
			this.parryinfo.Size = new System.Drawing.Size(105, 22);
			this.parryinfo.TabIndex = 42;
			this.parryinfo.Text = "TextBox6";
			// 
			// butt_macing
			// 
			this.butt_macing.Location = new System.Drawing.Point(278, 65);
			this.butt_macing.Name = "butt_macing";
			this.butt_macing.Size = new System.Drawing.Size(29, 18);
			this.butt_macing.TabIndex = 41;
			this.butt_macing.Text = ">";
			this.butt_macing.Click += new System.EventHandler(this.butt_macing_Click);
			// 
			// macinginfo
			// 
			this.macinginfo.Location = new System.Drawing.Point(154, 65);
			this.macinginfo.Name = "macinginfo";
			this.macinginfo.Size = new System.Drawing.Size(105, 22);
			this.macinginfo.TabIndex = 40;
			this.macinginfo.Text = "TextBox3";
			// 
			// butt_fencing
			// 
			this.butt_fencing.Location = new System.Drawing.Point(278, 37);
			this.butt_fencing.Name = "butt_fencing";
			this.butt_fencing.Size = new System.Drawing.Size(29, 18);
			this.butt_fencing.TabIndex = 39;
			this.butt_fencing.Text = ">";
			this.butt_fencing.Click += new System.EventHandler(this.butt_fencing_Click);
			// 
			// fencinginfo
			// 
			this.fencinginfo.Location = new System.Drawing.Point(154, 37);
			this.fencinginfo.Name = "fencinginfo";
			this.fencinginfo.Size = new System.Drawing.Size(105, 22);
			this.fencinginfo.TabIndex = 38;
			this.fencinginfo.Text = "TextBox2";
			// 
			// butt_archery
			// 
			this.butt_archery.Location = new System.Drawing.Point(278, 9);
			this.butt_archery.Name = "butt_archery";
			this.butt_archery.Size = new System.Drawing.Size(29, 19);
			this.butt_archery.TabIndex = 37;
			this.butt_archery.Text = ">";
			this.butt_archery.Click += new System.EventHandler(this.butt_archery_Click);
			// 
			// archeryinfo
			// 
			this.archeryinfo.Location = new System.Drawing.Point(154, 9);
			this.archeryinfo.Name = "archeryinfo";
			this.archeryinfo.Size = new System.Drawing.Size(105, 22);
			this.archeryinfo.TabIndex = 36;
			this.archeryinfo.Text = "TextBox1";
			// 
			// Wrestling
			// 
			this.Wrestling.Location = new System.Drawing.Point(10, 175);
			this.Wrestling.Name = "Wrestling";
			this.Wrestling.Size = new System.Drawing.Size(138, 19);
			this.Wrestling.TabIndex = 33;
			this.Wrestling.Text = "Wrestling";
			// 
			// Tactics
			// 
			this.Tactics.Location = new System.Drawing.Point(10, 148);
			this.Tactics.Name = "Tactics";
			this.Tactics.Size = new System.Drawing.Size(138, 18);
			this.Tactics.TabIndex = 32;
			this.Tactics.Text = "Tactics";
			// 
			// Swords
			// 
			this.Swords.Location = new System.Drawing.Point(10, 120);
			this.Swords.Name = "Swords";
			this.Swords.Size = new System.Drawing.Size(138, 18);
			this.Swords.TabIndex = 31;
			this.Swords.Text = "Swords";
			// 
			// Parry
			// 
			this.Parry.Location = new System.Drawing.Point(10, 92);
			this.Parry.Name = "Parry";
			this.Parry.Size = new System.Drawing.Size(138, 19);
			this.Parry.TabIndex = 30;
			this.Parry.Text = "Parry";
			// 
			// Macing
			// 
			this.Macing.Location = new System.Drawing.Point(10, 65);
			this.Macing.Name = "Macing";
			this.Macing.Size = new System.Drawing.Size(138, 18);
			this.Macing.TabIndex = 29;
			this.Macing.Text = "Macing";
			// 
			// Fencing
			// 
			this.Fencing.Location = new System.Drawing.Point(10, 37);
			this.Fencing.Name = "Fencing";
			this.Fencing.Size = new System.Drawing.Size(138, 18);
			this.Fencing.TabIndex = 28;
			this.Fencing.Text = "Fencing";
			// 
			// Archery
			// 
			this.Archery.Location = new System.Drawing.Point(10, 9);
			this.Archery.Name = "Archery";
			this.Archery.Size = new System.Drawing.Size(138, 19);
			this.Archery.TabIndex = 27;
			this.Archery.Text = "Archery";
			// 
			// TActions
			// 
			this.TActions.Controls.Add(this.butt_tracking);
			this.TActions.Controls.Add(this.trackinginfo);
			this.TActions.Controls.Add(this.butt_stealth);
			this.TActions.Controls.Add(this.stealthinfo);
			this.TActions.Controls.Add(this.butt_stealing);
			this.TActions.Controls.Add(this.stealinginfo);
			this.TActions.Controls.Add(this.butt_poisoning);
			this.TActions.Controls.Add(this.poisoninginfo);
			this.TActions.Controls.Add(this.butt_removetrap);
			this.TActions.Controls.Add(this.removetrapinfo);
			this.TActions.Controls.Add(this.butt_hiding);
			this.TActions.Controls.Add(this.hidinginfo);
			this.TActions.Controls.Add(this.butt_detecthidden);
			this.TActions.Controls.Add(this.detecthiddeninfo);
			this.TActions.Controls.Add(this.butt_begging);
			this.TActions.Controls.Add(this.begginginfo);
			this.TActions.Controls.Add(this.butt_animaltaming);
			this.TActions.Controls.Add(this.animaltaminginfo);
			this.TActions.Controls.Add(this.Tracking);
			this.TActions.Controls.Add(this.Stealth);
			this.TActions.Controls.Add(this.Stealing);
			this.TActions.Controls.Add(this.Poisoning);
			this.TActions.Controls.Add(this.RemoveTrap);
			this.TActions.Controls.Add(this.Hiding);
			this.TActions.Controls.Add(this.DetectHidden);
			this.TActions.Controls.Add(this.Begging);
			this.TActions.Controls.Add(this.AnimalTaming);
			this.TActions.Location = new System.Drawing.Point(4, 25);
			this.TActions.Name = "TActions";
			this.TActions.TabIndex = 5;
			this.TActions.Text = "Actions";
			this.TActions.Visible = false;
			// 
			// butt_tracking
			// 
			this.butt_tracking.Location = new System.Drawing.Point(278, 231);
			this.butt_tracking.Name = "butt_tracking";
			this.butt_tracking.Size = new System.Drawing.Size(29, 18);
			this.butt_tracking.TabIndex = 53;
			this.butt_tracking.Text = ">";
			this.butt_tracking.Click += new System.EventHandler(this.butt_tracking_Click);
			// 
			// trackinginfo
			// 
			this.trackinginfo.Location = new System.Drawing.Point(154, 231);
			this.trackinginfo.Name = "trackinginfo";
			this.trackinginfo.Size = new System.Drawing.Size(105, 22);
			this.trackinginfo.TabIndex = 52;
			this.trackinginfo.Text = "TextBox7";
			// 
			// butt_stealth
			// 
			this.butt_stealth.Location = new System.Drawing.Point(278, 203);
			this.butt_stealth.Name = "butt_stealth";
			this.butt_stealth.Size = new System.Drawing.Size(29, 19);
			this.butt_stealth.TabIndex = 51;
			this.butt_stealth.Text = ">";
			this.butt_stealth.Click += new System.EventHandler(this.butt_stealth_Click);
			// 
			// stealthinfo
			// 
			this.stealthinfo.Location = new System.Drawing.Point(154, 203);
			this.stealthinfo.Name = "stealthinfo";
			this.stealthinfo.Size = new System.Drawing.Size(105, 22);
			this.stealthinfo.TabIndex = 50;
			this.stealthinfo.Text = "TextBox8";
			// 
			// butt_stealing
			// 
			this.butt_stealing.Location = new System.Drawing.Point(278, 175);
			this.butt_stealing.Name = "butt_stealing";
			this.butt_stealing.Size = new System.Drawing.Size(29, 19);
			this.butt_stealing.TabIndex = 49;
			this.butt_stealing.Text = ">";
			this.butt_stealing.Click += new System.EventHandler(this.butt_stealing_Click);
			// 
			// stealinginfo
			// 
			this.stealinginfo.Location = new System.Drawing.Point(154, 175);
			this.stealinginfo.Name = "stealinginfo";
			this.stealinginfo.Size = new System.Drawing.Size(105, 22);
			this.stealinginfo.TabIndex = 48;
			this.stealinginfo.Text = "TextBox9";
			// 
			// butt_poisoning
			// 
			this.butt_poisoning.Location = new System.Drawing.Point(278, 148);
			this.butt_poisoning.Name = "butt_poisoning";
			this.butt_poisoning.Size = new System.Drawing.Size(29, 18);
			this.butt_poisoning.TabIndex = 47;
			this.butt_poisoning.Text = ">";
			this.butt_poisoning.Click += new System.EventHandler(this.butt_poisoning_Click);
			// 
			// poisoninginfo
			// 
			this.poisoninginfo.Location = new System.Drawing.Point(154, 148);
			this.poisoninginfo.Name = "poisoninginfo";
			this.poisoninginfo.Size = new System.Drawing.Size(105, 22);
			this.poisoninginfo.TabIndex = 46;
			this.poisoninginfo.Text = "TextBox4";
			// 
			// butt_removetrap
			// 
			this.butt_removetrap.Location = new System.Drawing.Point(278, 120);
			this.butt_removetrap.Name = "butt_removetrap";
			this.butt_removetrap.Size = new System.Drawing.Size(29, 18);
			this.butt_removetrap.TabIndex = 45;
			this.butt_removetrap.Text = ">";
			this.butt_removetrap.Click += new System.EventHandler(this.butt_removetrap_Click);
			// 
			// removetrapinfo
			// 
			this.removetrapinfo.Location = new System.Drawing.Point(154, 120);
			this.removetrapinfo.Name = "removetrapinfo";
			this.removetrapinfo.Size = new System.Drawing.Size(105, 22);
			this.removetrapinfo.TabIndex = 44;
			this.removetrapinfo.Text = "TextBox5";
			// 
			// butt_hiding
			// 
			this.butt_hiding.Location = new System.Drawing.Point(278, 92);
			this.butt_hiding.Name = "butt_hiding";
			this.butt_hiding.Size = new System.Drawing.Size(29, 19);
			this.butt_hiding.TabIndex = 43;
			this.butt_hiding.Text = ">";
			this.butt_hiding.Click += new System.EventHandler(this.butt_hiding_Click);
			// 
			// hidinginfo
			// 
			this.hidinginfo.Location = new System.Drawing.Point(154, 92);
			this.hidinginfo.Name = "hidinginfo";
			this.hidinginfo.Size = new System.Drawing.Size(105, 22);
			this.hidinginfo.TabIndex = 42;
			this.hidinginfo.Text = "TextBox6";
			// 
			// butt_detecthidden
			// 
			this.butt_detecthidden.Location = new System.Drawing.Point(278, 65);
			this.butt_detecthidden.Name = "butt_detecthidden";
			this.butt_detecthidden.Size = new System.Drawing.Size(29, 18);
			this.butt_detecthidden.TabIndex = 41;
			this.butt_detecthidden.Text = ">";
			this.butt_detecthidden.Click += new System.EventHandler(this.butt_detecthidden_Click);
			// 
			// detecthiddeninfo
			// 
			this.detecthiddeninfo.Location = new System.Drawing.Point(154, 65);
			this.detecthiddeninfo.Name = "detecthiddeninfo";
			this.detecthiddeninfo.Size = new System.Drawing.Size(105, 22);
			this.detecthiddeninfo.TabIndex = 40;
			this.detecthiddeninfo.Text = "TextBox3";
			// 
			// butt_begging
			// 
			this.butt_begging.Location = new System.Drawing.Point(278, 37);
			this.butt_begging.Name = "butt_begging";
			this.butt_begging.Size = new System.Drawing.Size(29, 18);
			this.butt_begging.TabIndex = 39;
			this.butt_begging.Text = ">";
			this.butt_begging.Click += new System.EventHandler(this.butt_begging_Click);
			// 
			// begginginfo
			// 
			this.begginginfo.Location = new System.Drawing.Point(154, 37);
			this.begginginfo.Name = "begginginfo";
			this.begginginfo.Size = new System.Drawing.Size(105, 22);
			this.begginginfo.TabIndex = 38;
			this.begginginfo.Text = "TextBox2";
			// 
			// butt_animaltaming
			// 
			this.butt_animaltaming.Location = new System.Drawing.Point(278, 9);
			this.butt_animaltaming.Name = "butt_animaltaming";
			this.butt_animaltaming.Size = new System.Drawing.Size(29, 19);
			this.butt_animaltaming.TabIndex = 37;
			this.butt_animaltaming.Text = ">";
			this.butt_animaltaming.Click += new System.EventHandler(this.butt_animaltaming_Click);
			// 
			// animaltaminginfo
			// 
			this.animaltaminginfo.Location = new System.Drawing.Point(154, 9);
			this.animaltaminginfo.Name = "animaltaminginfo";
			this.animaltaminginfo.Size = new System.Drawing.Size(105, 22);
			this.animaltaminginfo.TabIndex = 36;
			this.animaltaminginfo.Text = "TextBox1";
			// 
			// Tracking
			// 
			this.Tracking.Location = new System.Drawing.Point(10, 231);
			this.Tracking.Name = "Tracking";
			this.Tracking.Size = new System.Drawing.Size(138, 18);
			this.Tracking.TabIndex = 35;
			this.Tracking.Text = "Tracking";
			// 
			// Stealth
			// 
			this.Stealth.Location = new System.Drawing.Point(10, 203);
			this.Stealth.Name = "Stealth";
			this.Stealth.Size = new System.Drawing.Size(138, 19);
			this.Stealth.TabIndex = 34;
			this.Stealth.Text = "Stealth";
			// 
			// Stealing
			// 
			this.Stealing.Location = new System.Drawing.Point(10, 175);
			this.Stealing.Name = "Stealing";
			this.Stealing.Size = new System.Drawing.Size(138, 19);
			this.Stealing.TabIndex = 33;
			this.Stealing.Text = "Stealing";
			// 
			// Poisoning
			// 
			this.Poisoning.Location = new System.Drawing.Point(10, 148);
			this.Poisoning.Name = "Poisoning";
			this.Poisoning.Size = new System.Drawing.Size(138, 18);
			this.Poisoning.TabIndex = 32;
			this.Poisoning.Text = "Poisoning";
			// 
			// RemoveTrap
			// 
			this.RemoveTrap.Location = new System.Drawing.Point(10, 120);
			this.RemoveTrap.Name = "RemoveTrap";
			this.RemoveTrap.Size = new System.Drawing.Size(138, 18);
			this.RemoveTrap.TabIndex = 31;
			this.RemoveTrap.Text = "RemoveTrap";
			// 
			// Hiding
			// 
			this.Hiding.Location = new System.Drawing.Point(10, 92);
			this.Hiding.Name = "Hiding";
			this.Hiding.Size = new System.Drawing.Size(138, 19);
			this.Hiding.TabIndex = 30;
			this.Hiding.Text = "Hiding";
			// 
			// DetectHidden
			// 
			this.DetectHidden.Location = new System.Drawing.Point(10, 65);
			this.DetectHidden.Name = "DetectHidden";
			this.DetectHidden.Size = new System.Drawing.Size(138, 18);
			this.DetectHidden.TabIndex = 29;
			this.DetectHidden.Text = "DetectHidden";
			// 
			// Begging
			// 
			this.Begging.Location = new System.Drawing.Point(10, 37);
			this.Begging.Name = "Begging";
			this.Begging.Size = new System.Drawing.Size(138, 18);
			this.Begging.TabIndex = 28;
			this.Begging.Text = "Begging";
			// 
			// AnimalTaming
			// 
			this.AnimalTaming.Location = new System.Drawing.Point(10, 9);
			this.AnimalTaming.Name = "AnimalTaming";
			this.AnimalTaming.Size = new System.Drawing.Size(138, 19);
			this.AnimalTaming.TabIndex = 27;
			this.AnimalTaming.Text = "AnimalTaming";
			// 
			// TKnowledge
			// 
			this.TKnowledge.Controls.Add(this.butt_tasteid);
			this.TKnowledge.Controls.Add(this.tasteidinfo);
			this.TKnowledge.Controls.Add(this.butt_itemid);
			this.TKnowledge.Controls.Add(this.itemidinfo);
			this.TKnowledge.Controls.Add(this.butt_forensics);
			this.TKnowledge.Controls.Add(this.forensicsinfo);
			this.TKnowledge.Controls.Add(this.butt_armslore);
			this.TKnowledge.Controls.Add(this.armsloreinfo);
			this.TKnowledge.Controls.Add(this.butt_animallore);
			this.TKnowledge.Controls.Add(this.animalloreinfo);
			this.TKnowledge.Controls.Add(this.butt_anatomy);
			this.TKnowledge.Controls.Add(this.anatomyinfo);
			this.TKnowledge.Controls.Add(this.TasteID);
			this.TKnowledge.Controls.Add(this.ItemID);
			this.TKnowledge.Controls.Add(this.Forensics);
			this.TKnowledge.Controls.Add(this.ArmsLore);
			this.TKnowledge.Controls.Add(this.AnimalLore);
			this.TKnowledge.Controls.Add(this.Anatomy);
			this.TKnowledge.Location = new System.Drawing.Point(4, 25);
			this.TKnowledge.Name = "TKnowledge";
			this.TKnowledge.Size = new System.Drawing.Size(433, 266);
			this.TKnowledge.TabIndex = 6;
			this.TKnowledge.Text = "Knowledge";
			this.TKnowledge.Visible = false;
			// 
			// butt_tasteid
			// 
			this.butt_tasteid.Location = new System.Drawing.Point(278, 148);
			this.butt_tasteid.Name = "butt_tasteid";
			this.butt_tasteid.Size = new System.Drawing.Size(29, 18);
			this.butt_tasteid.TabIndex = 47;
			this.butt_tasteid.Text = ">";
			this.butt_tasteid.Click += new System.EventHandler(this.butt_tasteid_Click);
			// 
			// tasteidinfo
			// 
			this.tasteidinfo.Location = new System.Drawing.Point(154, 148);
			this.tasteidinfo.Name = "tasteidinfo";
			this.tasteidinfo.Size = new System.Drawing.Size(105, 22);
			this.tasteidinfo.TabIndex = 46;
			this.tasteidinfo.Text = "TextBox4";
			// 
			// butt_itemid
			// 
			this.butt_itemid.Location = new System.Drawing.Point(278, 120);
			this.butt_itemid.Name = "butt_itemid";
			this.butt_itemid.Size = new System.Drawing.Size(29, 18);
			this.butt_itemid.TabIndex = 45;
			this.butt_itemid.Text = ">";
			this.butt_itemid.Click += new System.EventHandler(this.butt_itemid_Click);
			// 
			// itemidinfo
			// 
			this.itemidinfo.Location = new System.Drawing.Point(154, 120);
			this.itemidinfo.Name = "itemidinfo";
			this.itemidinfo.Size = new System.Drawing.Size(105, 22);
			this.itemidinfo.TabIndex = 44;
			this.itemidinfo.Text = "TextBox5";
			// 
			// butt_forensics
			// 
			this.butt_forensics.Location = new System.Drawing.Point(278, 92);
			this.butt_forensics.Name = "butt_forensics";
			this.butt_forensics.Size = new System.Drawing.Size(29, 19);
			this.butt_forensics.TabIndex = 43;
			this.butt_forensics.Text = ">";
			this.butt_forensics.Click += new System.EventHandler(this.butt_forensics_Click);
			// 
			// forensicsinfo
			// 
			this.forensicsinfo.Location = new System.Drawing.Point(154, 92);
			this.forensicsinfo.Name = "forensicsinfo";
			this.forensicsinfo.Size = new System.Drawing.Size(105, 22);
			this.forensicsinfo.TabIndex = 42;
			this.forensicsinfo.Text = "TextBox6";
			// 
			// butt_armslore
			// 
			this.butt_armslore.Location = new System.Drawing.Point(278, 65);
			this.butt_armslore.Name = "butt_armslore";
			this.butt_armslore.Size = new System.Drawing.Size(29, 18);
			this.butt_armslore.TabIndex = 41;
			this.butt_armslore.Text = ">";
			this.butt_armslore.Click += new System.EventHandler(this.butt_armslore_Click);
			// 
			// armsloreinfo
			// 
			this.armsloreinfo.Location = new System.Drawing.Point(154, 65);
			this.armsloreinfo.Name = "armsloreinfo";
			this.armsloreinfo.Size = new System.Drawing.Size(105, 22);
			this.armsloreinfo.TabIndex = 40;
			this.armsloreinfo.Text = "TextBox3";
			// 
			// butt_animallore
			// 
			this.butt_animallore.Location = new System.Drawing.Point(278, 37);
			this.butt_animallore.Name = "butt_animallore";
			this.butt_animallore.Size = new System.Drawing.Size(29, 18);
			this.butt_animallore.TabIndex = 39;
			this.butt_animallore.Text = ">";
			this.butt_animallore.Click += new System.EventHandler(this.butt_animallore_Click);
			// 
			// animalloreinfo
			// 
			this.animalloreinfo.Location = new System.Drawing.Point(154, 37);
			this.animalloreinfo.Name = "animalloreinfo";
			this.animalloreinfo.Size = new System.Drawing.Size(105, 22);
			this.animalloreinfo.TabIndex = 38;
			this.animalloreinfo.Text = "TextBox2";
			// 
			// butt_anatomy
			// 
			this.butt_anatomy.Location = new System.Drawing.Point(278, 9);
			this.butt_anatomy.Name = "butt_anatomy";
			this.butt_anatomy.Size = new System.Drawing.Size(29, 19);
			this.butt_anatomy.TabIndex = 37;
			this.butt_anatomy.Text = ">";
			this.butt_anatomy.Click += new System.EventHandler(this.butt_anatomy_Click);
			// 
			// anatomyinfo
			// 
			this.anatomyinfo.Location = new System.Drawing.Point(154, 9);
			this.anatomyinfo.Name = "anatomyinfo";
			this.anatomyinfo.Size = new System.Drawing.Size(105, 22);
			this.anatomyinfo.TabIndex = 36;
			this.anatomyinfo.Text = "TextBox1";
			// 
			// TasteID
			// 
			this.TasteID.Location = new System.Drawing.Point(10, 148);
			this.TasteID.Name = "TasteID";
			this.TasteID.Size = new System.Drawing.Size(138, 18);
			this.TasteID.TabIndex = 32;
			this.TasteID.Text = "TasteID";
			// 
			// ItemID
			// 
			this.ItemID.Location = new System.Drawing.Point(10, 120);
			this.ItemID.Name = "ItemID";
			this.ItemID.Size = new System.Drawing.Size(138, 18);
			this.ItemID.TabIndex = 31;
			this.ItemID.Text = "ItemID";
			// 
			// Forensics
			// 
			this.Forensics.Location = new System.Drawing.Point(10, 92);
			this.Forensics.Name = "Forensics";
			this.Forensics.Size = new System.Drawing.Size(138, 19);
			this.Forensics.TabIndex = 30;
			this.Forensics.Text = "Forensics";
			// 
			// ArmsLore
			// 
			this.ArmsLore.Location = new System.Drawing.Point(10, 65);
			this.ArmsLore.Name = "ArmsLore";
			this.ArmsLore.Size = new System.Drawing.Size(138, 18);
			this.ArmsLore.TabIndex = 29;
			this.ArmsLore.Text = "ArmsLore";
			// 
			// AnimalLore
			// 
			this.AnimalLore.Location = new System.Drawing.Point(10, 37);
			this.AnimalLore.Name = "AnimalLore";
			this.AnimalLore.Size = new System.Drawing.Size(138, 18);
			this.AnimalLore.TabIndex = 28;
			this.AnimalLore.Text = "AnimalLore";
			// 
			// Anatomy
			// 
			this.Anatomy.Location = new System.Drawing.Point(10, 9);
			this.Anatomy.Name = "Anatomy";
			this.Anatomy.Size = new System.Drawing.Size(138, 19);
			this.Anatomy.TabIndex = 27;
			this.Anatomy.Text = "Anatomy";
			// 
			// MainPropsTab
			// 
			this.MainPropsTab.Controls.Add(this.PropsTab);
			this.MainPropsTab.Location = new System.Drawing.Point(4, 25);
			this.MainPropsTab.Name = "MainPropsTab";
			this.MainPropsTab.TabIndex = 1;
			this.MainPropsTab.Text = "Properties";
			// 
			// butt_Refresh
			// 
			this.butt_Refresh.Location = new System.Drawing.Point(24, 425);
			this.butt_Refresh.Name = "butt_Refresh";
			this.butt_Refresh.Size = new System.Drawing.Size(176, 28);
			this.butt_Refresh.TabIndex = 11;
			this.butt_Refresh.Text = "Refresh List";
			this.butt_Refresh.Click += new System.EventHandler(this.butt_Refresh_Click);
			// 
			// butt_Resurrect
			// 
			this.butt_Resurrect.Location = new System.Drawing.Point(656, 304);
			this.butt_Resurrect.Name = "butt_Resurrect";
			this.butt_Resurrect.Size = new System.Drawing.Size(88, 27);
			this.butt_Resurrect.TabIndex = 10;
			this.butt_Resurrect.Text = "Resurrect";
			this.butt_Resurrect.Click += new System.EventHandler(this.butt_Resurrect_Click);
			// 
			// butt_Kill
			// 
			this.butt_Kill.Location = new System.Drawing.Point(656, 264);
			this.butt_Kill.Name = "butt_Kill";
			this.butt_Kill.Size = new System.Drawing.Size(88, 27);
			this.butt_Kill.TabIndex = 9;
			this.butt_Kill.Text = "Kill";
			this.butt_Kill.Click += new System.EventHandler(this.butt_Kill_Click);
			// 
			// butt_Disconnect
			// 
			this.butt_Disconnect.Location = new System.Drawing.Point(656, 224);
			this.butt_Disconnect.Name = "butt_Disconnect";
			this.butt_Disconnect.Size = new System.Drawing.Size(88, 28);
			this.butt_Disconnect.TabIndex = 7;
			this.butt_Disconnect.Text = "Disconnect";
			this.butt_Disconnect.Click += new System.EventHandler(this.butt_Disconnect_Click);
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add(this.Account);
			this.GroupBox2.Controls.Add(this.currentsessioninfo);
			this.GroupBox2.Controls.Add(this.currentsession);
			this.GroupBox2.Controls.Add(this.ingameinfo);
			this.GroupBox2.Controls.Add(this.ingame);
			this.GroupBox2.Controls.Add(this.createdinfo);
			this.GroupBox2.Controls.Add(this.created);
			this.GroupBox2.Controls.Add(this.healthinfo);
			this.GroupBox2.Controls.Add(this.Health);
			this.GroupBox2.Controls.Add(this.serialinfo);
			this.GroupBox2.Controls.Add(this.serial);
			this.GroupBox2.Controls.Add(this.lastlogininfo);
			this.GroupBox2.Controls.Add(this.lastlogin);
			this.GroupBox2.Controls.Add(this.locationinfo);
			this.GroupBox2.Controls.Add(this.mobileinfo);
			this.GroupBox2.Controls.Add(this.accountinfo);
			this.GroupBox2.Controls.Add(this.versioninfo);
			this.GroupBox2.Controls.Add(this.clientinfo);
			this.GroupBox2.Controls.Add(this.addressinfo);
			this.GroupBox2.Controls.Add(this.location);
			this.GroupBox2.Controls.Add(this.mobile);
			this.GroupBox2.Controls.Add(this.version);
			this.GroupBox2.Controls.Add(this.client);
			this.GroupBox2.Controls.Add(this.address);
			this.GroupBox2.Location = new System.Drawing.Point(248, 9);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(504, 168);
			this.GroupBox2.TabIndex = 1;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Client Information";
			// 
			// Account
			// 
			this.Account.Location = new System.Drawing.Point(19, 18);
			this.Account.Name = "Account";
			this.Account.Size = new System.Drawing.Size(101, 22);
			this.Account.TabIndex = 24;
			this.Account.Text = "Account";
			this.Account.Click += new System.EventHandler(this.Account_Click);
			// 
			// currentsessioninfo
			// 
			this.currentsessioninfo.Location = new System.Drawing.Point(384, 141);
			this.currentsessioninfo.Name = "currentsessioninfo";
			this.currentsessioninfo.Size = new System.Drawing.Size(110, 18);
			this.currentsessioninfo.TabIndex = 23;
			this.currentsessioninfo.Text = "currentsessioninfo";
			// 
			// currentsession
			// 
			this.currentsession.Location = new System.Drawing.Point(264, 141);
			this.currentsession.Name = "currentsession";
			this.currentsession.Size = new System.Drawing.Size(110, 18);
			this.currentsession.TabIndex = 22;
			this.currentsession.Text = "Current Session";
			// 
			// ingameinfo
			// 
			this.ingameinfo.Location = new System.Drawing.Point(144, 141);
			this.ingameinfo.Name = "ingameinfo";
			this.ingameinfo.Size = new System.Drawing.Size(110, 18);
			this.ingameinfo.TabIndex = 21;
			this.ingameinfo.Text = "ingameinfo";
			// 
			// ingame
			// 
			this.ingame.Location = new System.Drawing.Point(19, 141);
			this.ingame.Name = "ingame";
			this.ingame.Size = new System.Drawing.Size(110, 18);
			this.ingame.TabIndex = 20;
			this.ingame.Text = "In-Game Time";
			// 
			// createdinfo
			// 
			this.createdinfo.Location = new System.Drawing.Point(144, 95);
			this.createdinfo.Name = "createdinfo";
			this.createdinfo.Size = new System.Drawing.Size(110, 18);
			this.createdinfo.TabIndex = 19;
			this.createdinfo.Text = "created";
			// 
			// created
			// 
			this.created.Location = new System.Drawing.Point(19, 95);
			this.created.Name = "created";
			this.created.Size = new System.Drawing.Size(110, 18);
			this.created.TabIndex = 18;
			this.created.Text = "Created";
			// 
			// healthinfo
			// 
			this.healthinfo.Location = new System.Drawing.Point(384, 118);
			this.healthinfo.Name = "healthinfo";
			this.healthinfo.Size = new System.Drawing.Size(110, 18);
			this.healthinfo.TabIndex = 17;
			this.healthinfo.Text = "healthinfo";
			// 
			// Health
			// 
			this.Health.Location = new System.Drawing.Point(264, 118);
			this.Health.Name = "Health";
			this.Health.Size = new System.Drawing.Size(110, 18);
			this.Health.TabIndex = 16;
			this.Health.Text = "Health";
			// 
			// serialinfo
			// 
			this.serialinfo.Location = new System.Drawing.Point(384, 49);
			this.serialinfo.Name = "serialinfo";
			this.serialinfo.Size = new System.Drawing.Size(110, 18);
			this.serialinfo.TabIndex = 15;
			this.serialinfo.Text = "serialinfo";
			// 
			// serial
			// 
			this.serial.Location = new System.Drawing.Point(264, 49);
			this.serial.Name = "serial";
			this.serial.Size = new System.Drawing.Size(110, 18);
			this.serial.TabIndex = 14;
			this.serial.Text = "Mobile Serial";
			// 
			// lastlogininfo
			// 
			this.lastlogininfo.Location = new System.Drawing.Point(384, 95);
			this.lastlogininfo.Name = "lastlogininfo";
			this.lastlogininfo.Size = new System.Drawing.Size(110, 18);
			this.lastlogininfo.TabIndex = 13;
			this.lastlogininfo.Text = "lastlogininfo";
			// 
			// lastlogin
			// 
			this.lastlogin.Location = new System.Drawing.Point(264, 95);
			this.lastlogin.Name = "lastlogin";
			this.lastlogin.Size = new System.Drawing.Size(110, 18);
			this.lastlogin.TabIndex = 12;
			this.lastlogin.Text = "Last Login";
			// 
			// locationinfo
			// 
			this.locationinfo.Location = new System.Drawing.Point(144, 118);
			this.locationinfo.Name = "locationinfo";
			this.locationinfo.Size = new System.Drawing.Size(110, 18);
			this.locationinfo.TabIndex = 11;
			this.locationinfo.Text = "locationinfo";
			// 
			// mobileinfo
			// 
			this.mobileinfo.Location = new System.Drawing.Point(384, 20);
			this.mobileinfo.Name = "mobileinfo";
			this.mobileinfo.Size = new System.Drawing.Size(110, 18);
			this.mobileinfo.TabIndex = 10;
			this.mobileinfo.Text = "mobileinfo";
			// 
			// accountinfo
			// 
			this.accountinfo.Location = new System.Drawing.Point(144, 20);
			this.accountinfo.Name = "accountinfo";
			this.accountinfo.Size = new System.Drawing.Size(110, 18);
			this.accountinfo.TabIndex = 9;
			this.accountinfo.Text = "accountinfo";
			// 
			// versioninfo
			// 
			this.versioninfo.Location = new System.Drawing.Point(384, 72);
			this.versioninfo.Name = "versioninfo";
			this.versioninfo.Size = new System.Drawing.Size(110, 18);
			this.versioninfo.TabIndex = 8;
			this.versioninfo.Text = "versioninfo";
			// 
			// clientinfo
			// 
			this.clientinfo.Location = new System.Drawing.Point(144, 72);
			this.clientinfo.Name = "clientinfo";
			this.clientinfo.Size = new System.Drawing.Size(110, 18);
			this.clientinfo.TabIndex = 7;
			this.clientinfo.Text = "clientinfo";
			// 
			// addressinfo
			// 
			this.addressinfo.Location = new System.Drawing.Point(144, 49);
			this.addressinfo.Name = "addressinfo";
			this.addressinfo.Size = new System.Drawing.Size(110, 18);
			this.addressinfo.TabIndex = 6;
			this.addressinfo.Text = "addressinfo";
			// 
			// location
			// 
			this.location.Location = new System.Drawing.Point(19, 118);
			this.location.Name = "location";
			this.location.Size = new System.Drawing.Size(110, 18);
			this.location.TabIndex = 5;
			this.location.Text = "Location";
			// 
			// mobile
			// 
			this.mobile.Location = new System.Drawing.Point(264, 20);
			this.mobile.Name = "mobile";
			this.mobile.Size = new System.Drawing.Size(110, 18);
			this.mobile.TabIndex = 4;
			this.mobile.Text = "Mobile Name";
			// 
			// version
			// 
			this.version.Location = new System.Drawing.Point(264, 72);
			this.version.Name = "version";
			this.version.Size = new System.Drawing.Size(110, 18);
			this.version.TabIndex = 2;
			this.version.Text = "Client Version";
			// 
			// client
			// 
			this.client.Location = new System.Drawing.Point(19, 72);
			this.client.Name = "client";
			this.client.Size = new System.Drawing.Size(110, 18);
			this.client.TabIndex = 1;
			this.client.Text = "Client Type";
			// 
			// address
			// 
			this.address.Location = new System.Drawing.Point(19, 49);
			this.address.Name = "address";
			this.address.Size = new System.Drawing.Size(110, 18);
			this.address.TabIndex = 0;
			this.address.Text = "IP Address";
			// 
			// ListBox1
			// 
			this.ListBox1.ItemHeight = 16;
			this.ListBox1.Location = new System.Drawing.Point(19, 24);
			this.ListBox1.Name = "ListBox1";
			this.ListBox1.Size = new System.Drawing.Size(181, 400);
			this.ListBox1.TabIndex = 0;
			this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
			// 
			// butt_firewall
			// 
			this.butt_firewall.Location = new System.Drawing.Point(656, 344);
			this.butt_firewall.Name = "butt_firewall";
			this.butt_firewall.Size = new System.Drawing.Size(88, 27);
			this.butt_firewall.TabIndex = 14;
			this.butt_firewall.Text = "Firewall";
			this.butt_firewall.Click += new System.EventHandler(this.butt_firewall_Click);
		}

		public override void OnLoad() {
			base.OnLoad();
			RefreshClientList();
			this.RefreshPropertyTabControl();
		}
 

		public static ArrayList BuildList( ) {
			ArrayList list = new ArrayList();
			List<NetState> states = NetState.Instances;
 
			for ( int i = 0; i < states.Count; ++i ) {
				Mobile m = states[i].Mobile;
				if ( m != null )
					list.Add( m );
			}
			list.Sort( InternalComparer.Instance );
			return list;
		}

		private class InternalComparer : IComparer {
			public static readonly IComparer Instance = new InternalComparer();

			public InternalComparer() {
			}
 
			public int Compare( object x, object y ) {
				if ( x == null && y == null )
					return 0;
				else if ( x == null )
					return -1;
				else if ( y == null )
					return 1;
 
				Mobile a = x as Mobile;
				Mobile b = y as Mobile;
 
				if ( a == null || b == null )
					throw new ArgumentException();
 
				if ( a.AccessLevel > b.AccessLevel )
					return -1;
				else if ( a.AccessLevel < b.AccessLevel )
					return 1;
				else
					return Insensitive.Compare( a.Name, b.Name );
			}
		}
 
		private void RefreshClientList() {
			if (this.ListBox1.Items.Count > 0)
				this.ListBox1.Items.Clear();

			m_Clients =  BuildList();
			if (m_Clients.Count>0) {
				this.ListBox1.Items.Clear();
				foreach(Mobile xx in m_Clients)
					ListBox1.Items.Add(xx.Name);
			}
			if (ListBox1.Items.Count > 0) {
				ListBox1.SetSelected(0, true);
			} 
			else {
				EmptyClientInfo();
			}
		}
 
		private void EmptyClientInfo() {
			this.addressinfo.Text = "-";
			this.clientinfo.Text = "-";
			this.versioninfo.Text = "-";
			this.accountinfo.Text = "-";
			this.mobileinfo.Text = "-";
			this.locationinfo.Text = "-";
			this.lastlogininfo.Text = "-";
			this.serialinfo.Text = "-";
		}

		private void RefreshPropertyTabControl() {
			this.PropsTab.RefreshProps(this.m_Mobile);
		}
 
		private void ListBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if (ListBox1.Items.Count == 0) {
				EmptyClientInfo();
			}
			else {
				Mobile m = (Mobile)m_Clients[ListBox1.SelectedIndex];

				// had a bug of some kind here. If players are online and then there are none, hitting Refresh would throw an error at line 426 below. I had to do a NetState check even though the Refresh clears the ListBox and the BuildList method should send an empty list to m_Clients in this situation. Regardless, checking for NetState fixes this but if there are no clients online, the program should never have dropped to the "else" section.
				if(m.NetState != null && m != null) {
					m_Mobile = m;
					Account acc = m.Account as Account;
					// Basic Mobile Info
					this.addressinfo.Text = m.NetState.ToString();
					this.clientinfo.Text = m.NetState.Version == null ? "(null)" : m.NetState.Version.ToString();
					this.versioninfo.Text = ((m.NetState.Flags & 0x10) != 0) ? "Samurai Empire" : ((m.NetState.Flags & 0x08) != 0) ? "Age of Shadows" : ((m.NetState.Flags & 0x04) != 0) ? "Blackthorn's Revenge" : ((m.NetState.Flags & 0x02) != 0) ? "Third Dawn" : ((m.NetState.Flags & 0x01) != 0) ? "Renaissance" : "The Second Age";
					this.accountinfo.Text = acc.Username;
					this.mobileinfo.Text = m.Name;
					this.locationinfo.Text = m.Location.X + "-" + m.Location.X + "-" +  m.Map;

					this.lastlogininfo.Text = acc.LastLogin.ToString();

					this.serialinfo.Text = m.Serial.Value.ToString();
					if(m.Alive==true)
						this.healthinfo.Text="Alive";
					else
						this.healthinfo.Text="Dead";

					TimeSpan ctime=DateTime.Now - ((PlayerMobile)m).SessionStart;
					this.currentsessioninfo.Text = ctime.Hours.ToString() + ":" + ctime.Minutes.ToString() + ":" + ctime.Seconds.ToString();

					int igt = ((PlayerMobile)m).GameTime.Hours + (((PlayerMobile)m).GameTime.Days * 24);
					this.ingameinfo.Text = igt.ToString() + " hours";
					DateTime crdate = acc.Created;
					this.createdinfo.Text = crdate.Month.ToString() + "/" + crdate.Day.ToString() + "/" + crdate.Year.ToString();


					// Skills - Crafting
					this.alchemyinfo.Text= m.Skills[SkillName.Alchemy].Value.ToString();
					this.blacksmithinfo.Text= m.Skills[SkillName.Blacksmith].Value.ToString();
					this.cartographyinfo.Text= m.Skills[SkillName.Cartography].Value.ToString();
					this.fletchinginfo.Text= m.Skills[SkillName.Fletching].Value.ToString();
					this.cookinginfo.Text= m.Skills[SkillName.Cooking].Value.ToString();
					this.carpentryinfo.Text= m.Skills[SkillName.Carpentry].Value.ToString();
					this.tinkeringinfo.Text= m.Skills[SkillName.Tinkering].Value.ToString();
					this.tailoringinfo.Text= m.Skills[SkillName.Tailoring].Value.ToString();
					this.inscribeinfo.Text= m.Skills[SkillName.Inscribe].Value.ToString();
					// Skills - Barding
					this.discordanceinfo.Text= m.Skills[SkillName.Discordance].Value.ToString();
					this.musicianshipinfo.Text= m.Skills[SkillName.Musicianship].Value.ToString();
					this.peacemakinginfo.Text= m.Skills[SkillName.Peacemaking].Value.ToString();
					this.provocationinfo.Text= m.Skills[SkillName.Provocation].Value.ToString();
					// Skills - Magical
					this.chivalryinfo.Text= m.Skills[SkillName.Chivalry].Value.ToString();
					this.evalintinfo.Text= m.Skills[SkillName.EvalInt].Value.ToString();
					this.mageryinfo.Text= m.Skills[SkillName.Magery].Value.ToString();
					this.magicresistinfo.Text= m.Skills[SkillName.MagicResist].Value.ToString();
					this.meditationinfo.Text= m.Skills[SkillName.Meditation].Value.ToString();
					this.necromancyinfo.Text= m.Skills[SkillName.Necromancy].Value.ToString();
					this.spiritspeakinfo.Text= m.Skills[SkillName.SpiritSpeak].Value.ToString();
					this.ninjitsuinfo.Text= m.Skills[SkillName.Ninjitsu].Value.ToString();
					this.bushidoinfo.Text= m.Skills[SkillName.Bushido].Value.ToString();
					// Skills - Miscellaneous
					this.campinginfo.Text= m.Skills[SkillName.Camping].Value.ToString();
					this.fishinginfo.Text= m.Skills[SkillName.Fishing].Value.ToString();
					this.focusinfo.Text= m.Skills[SkillName.Focus].Value.ToString();
					this.healinginfo.Text= m.Skills[SkillName.Healing].Value.ToString();
					this.herdinginfo.Text= m.Skills[SkillName.Herding].Value.ToString();
					this.lockpickinginfo.Text= m.Skills[SkillName.Lockpicking].Value.ToString();
					this.lumberjackinginfo.Text= m.Skills[SkillName.Lumberjacking].Value.ToString();
					this.mininginfo.Text= m.Skills[SkillName.Mining].Value.ToString();
					this.snoopinginfo.Text= m.Skills[SkillName.Snooping].Value.ToString();
					this.veterinaryinfo.Text= m.Skills[SkillName.Veterinary].Value.ToString();
					// Skills - Combat
					this.archeryinfo.Text= m.Skills[SkillName.Archery].Value.ToString();
					this.fencinginfo.Text= m.Skills[SkillName.Fencing].Value.ToString();
					this.macinginfo.Text= m.Skills[SkillName.Macing].Value.ToString();
					this.parryinfo.Text= m.Skills[SkillName.Parry].Value.ToString();
					this.swordsinfo.Text= m.Skills[SkillName.Swords].Value.ToString();
					this.tacticsinfo.Text= m.Skills[SkillName.Tactics].Value.ToString();
					this.wrestlinginfo.Text= m.Skills[SkillName.Wrestling].Value.ToString();
					// Skills - Actions
					this.animaltaminginfo.Text= m.Skills[SkillName.AnimalTaming].Value.ToString();
					this.begginginfo.Text= m.Skills[SkillName.Begging].Value.ToString();
					this.detecthiddeninfo.Text= m.Skills[SkillName.DetectHidden].Value.ToString();
					this.hidinginfo.Text= m.Skills[SkillName.Hiding].Value.ToString();
					this.removetrapinfo.Text= m.Skills[SkillName.RemoveTrap].Value.ToString();
					this.poisoninginfo.Text= m.Skills[SkillName.Poisoning].Value.ToString();
					this.stealinginfo.Text= m.Skills[SkillName.Stealing].Value.ToString();
					this.stealthinfo.Text= m.Skills[SkillName.Stealth].Value.ToString();
					this.trackinginfo.Text= m.Skills[SkillName.Tracking].Value.ToString();

					// Skills - Knowledge
					this.anatomyinfo.Text= m.Skills[SkillName.Anatomy].Value.ToString();
					this.animalloreinfo.Text= m.Skills[SkillName.AnimalLore].Value.ToString();
					this.armsloreinfo.Text= m.Skills[SkillName.ArmsLore].Value.ToString();
					this.forensicsinfo.Text= m.Skills[SkillName.Forensics].Value.ToString();
					this.itemidinfo.Text= m.Skills[SkillName.ItemID].Value.ToString();
					this.tasteidinfo.Text= m.Skills[SkillName.TasteID].Value.ToString();

					this.PropsTab.RefreshProps(this.m_Mobile);
				}
			}
		}

		private void SetVal(SkillName sk, String theval) {
			decimal dVal, dVal2;
			int alen;
			string tempst;

			//MessageBox.Show ("Value received is: " + theval, "Received Value",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk); 

			// if null, make it zero
			if(theval=="") {
				theval="0";
			}

			// see if length of value with a decimal point is greater than 3
			alen=theval.IndexOf(".");
			if(alen>-1) {
				tempst=theval.Substring(0,alen);
				if (tempst.Length > 3) {
					MessageBox.Show ("Invalid Value. Portion before decimal point must be 3 or less numbers.", "Bad Value",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk); 
					return;
				}
			}
				// see if length of value without decimal point is greater than 3
			else {
				if(theval.Length > 3) {
					MessageBox.Show ("Invalid Value. Skills are only 3 digits with an optional decimal point and single value following it..", "Bad Value",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk); 
					return;
				}
			}
			// if we make it this far, try to convert to decimal and round up any extra decimal digits
			// if no exceptions, write to pm
			try {
				dVal = System.Convert.ToDecimal(theval);
				dVal2 = decimal.Round(dVal,1);

				//set the skill value
				m_Mobile.Skills[sk].Base = (double)dVal2;
			}
			catch {
				MessageBox.Show ("Invalid Value", "Bad Value",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk); 

			}
		}

		#region skillbutton responses
		//button responses

		private void butt_alchemy_Click(object sender, EventArgs e) {
			SetVal(SkillName.Alchemy,this.alchemyinfo.Text);
		}

		private void butt_blacksmith_Click(object sender, EventArgs e) {
			SetVal(SkillName.Blacksmith,this.blacksmithinfo.Text);
		}
		private void butt_cartography_Click(object sender, EventArgs e) {
			SetVal(SkillName.Cartography,this.cartographyinfo.Text);
		}
		private void butt_carpentry_Click(object sender, EventArgs e) {
			SetVal(SkillName.Carpentry,this.carpentryinfo.Text);
		}
		private void butt_cooking_Click(object sender, EventArgs e) {
			SetVal(SkillName.Cooking,this.cookinginfo.Text);
		}
		private void butt_fletching_Click(object sender, EventArgs e) {
			SetVal(SkillName.Fletching,this.fletchinginfo.Text);
		}
		private void butt_inscribe_Click(object sender, EventArgs e) {
			SetVal(SkillName.Inscribe,this.inscribeinfo.Text);
		}
		private void butt_tailoring_Click(object sender, EventArgs e) {
			SetVal(SkillName.Tailoring,this.tailoringinfo.Text);
		}
		private void butt_tinkering_Click(object sender, EventArgs e) {
			SetVal(SkillName.Tinkering,this.tinkeringinfo.Text);
		}
		private void butt_discordance_Click(object sender, EventArgs e) {
			SetVal(SkillName.Discordance,this.discordanceinfo.Text);
		}
		private void butt_musicianship_Click(object sender, EventArgs e) {
			SetVal(SkillName.Musicianship,this.musicianshipinfo.Text);
		}
		private void butt_peacemaking_Click(object sender, EventArgs e) {
			SetVal(SkillName.Peacemaking,this.peacemakinginfo.Text);
		}
		private void butt_provocation_Click(object sender, EventArgs e) {
			SetVal(SkillName.Provocation,this.provocationinfo.Text);
		}
		private void butt_chivalry_Click(object sender, EventArgs e) {
			SetVal(SkillName.Chivalry,this.chivalryinfo.Text);
		}
		private void butt_evalint_Click(object sender, EventArgs e) {
			SetVal(SkillName.EvalInt,this.evalintinfo.Text);
		}
		private void butt_magery_Click(object sender, EventArgs e) {
			SetVal(SkillName.Magery,this.mageryinfo.Text);
		}
		private void butt_magicresist_Click(object sender, EventArgs e) {
			SetVal(SkillName.MagicResist,this.magicresistinfo.Text);
		}
		private void butt_meditation_Click(object sender, EventArgs e) {
			SetVal(SkillName.Meditation,this.meditationinfo.Text);
		}
		private void butt_necromancy_Click(object sender, EventArgs e) {
			SetVal(SkillName.Necromancy,this.necromancyinfo.Text);
		}
		private void butt_spiritspeak_Click(object sender, EventArgs e) {
			SetVal(SkillName.SpiritSpeak,this.spiritspeakinfo.Text);
		}
		private void butt_ninjitsu_Click(object sender, EventArgs e) {
			SetVal(SkillName.Ninjitsu,this.ninjitsuinfo.Text);
		}
		private void butt_bushido_Click(object sender, EventArgs e) {
			SetVal(SkillName.Bushido,this.bushidoinfo.Text);
		}
		private void butt_camping_Click(object sender, EventArgs e) {
			SetVal(SkillName.Camping,this.campinginfo.Text);
		}
		private void butt_fishing_Click(object sender, EventArgs e) {
			SetVal(SkillName.Fishing,this.fishinginfo.Text);
		}
		private void butt_focus_Click(object sender, EventArgs e) {
			SetVal(SkillName.Focus,this.focusinfo.Text);
		}
		private void butt_healing_Click(object sender, EventArgs e) {
			SetVal(SkillName.Healing,this.healinginfo.Text);
		}
		private void butt_herding_Click(object sender, EventArgs e) {
			SetVal(SkillName.Herding,this.herdinginfo.Text);
		}
		private void butt_lockpicking_Click(object sender, EventArgs e) {
			SetVal(SkillName.Lockpicking,this.lockpickinginfo.Text);
		}
		private void butt_lumberjacking_Click(object sender, EventArgs e) {
			SetVal(SkillName.Lumberjacking,this.lumberjackinginfo.Text);
		}
		private void butt_mining_Click(object sender, EventArgs e) {
			SetVal(SkillName.Mining,this.mininginfo.Text);
		}
		private void butt_snooping_Click(object sender, EventArgs e) {
			SetVal(SkillName.Snooping,this.snoopinginfo.Text);
		}
		private void butt_veterinary_Click(object sender, EventArgs e) {
			SetVal(SkillName.Veterinary,this.veterinaryinfo.Text);
		}
		private void butt_archery_Click(object sender, EventArgs e) {
			SetVal(SkillName.Archery,this.archeryinfo.Text);
		}
		private void butt_fencing_Click(object sender, EventArgs e) {
			SetVal(SkillName.Fencing,this.fencinginfo.Text);
		}
		private void butt_macing_Click(object sender, EventArgs e) {
			SetVal(SkillName.Macing,this.macinginfo.Text);
		}
		private void butt_parry_Click(object sender, EventArgs e) {
			SetVal(SkillName.Parry,this.parryinfo.Text);
		}
		private void butt_swords_Click(object sender, EventArgs e) {
			SetVal(SkillName.Swords,this.swordsinfo.Text);
		}
		private void butt_tactics_Click(object sender, EventArgs e) {
			SetVal(SkillName.Tactics,this.tacticsinfo.Text);
		}
		private void butt_wrestling_Click(object sender, EventArgs e) {
			SetVal(SkillName.Wrestling,this.wrestlinginfo.Text);
		}
		private void butt_animaltaming_Click(object sender, EventArgs e) {
			SetVal(SkillName.AnimalTaming,this.animaltaminginfo.Text);
		}
		private void butt_begging_Click(object sender, EventArgs e) {
			SetVal(SkillName.Begging,this.begginginfo.Text);
		}
		private void butt_detecthidden_Click(object sender, EventArgs e) {
			SetVal(SkillName.DetectHidden,this.detecthiddeninfo.Text);
		}
		private void butt_hiding_Click(object sender, EventArgs e) {
			SetVal(SkillName.Hiding,this.hidinginfo.Text);
		}
		private void butt_removetrap_Click(object sender, EventArgs e) {
			SetVal(SkillName.RemoveTrap,this.removetrapinfo.Text);
		}
		private void butt_poisoning_Click(object sender, EventArgs e) {
			SetVal(SkillName.Poisoning,this.poisoninginfo.Text);
		}
		private void butt_stealing_Click(object sender, EventArgs e) {
			SetVal(SkillName.Stealing,this.stealinginfo.Text);
		}
		private void butt_stealth_Click(object sender, EventArgs e) {
			SetVal(SkillName.Stealth,this.stealthinfo.Text);
		}
		private void butt_tracking_Click(object sender, EventArgs e) {
			SetVal(SkillName.Tracking,this.trackinginfo.Text);
		}
		private void butt_anatomy_Click(object sender, EventArgs e) {
			SetVal(SkillName.Anatomy,this.anatomyinfo.Text);
		}
		private void butt_animallore_Click(object sender, EventArgs e) {
			SetVal(SkillName.AnimalLore,this.animalloreinfo.Text);
		}
		private void butt_armslore_Click(object sender, EventArgs e) {
			SetVal(SkillName.ArmsLore,this.armsloreinfo.Text);
		}
		private void butt_forensics_Click(object sender, EventArgs e) {
			SetVal(SkillName.Forensics,this.forensicsinfo.Text);
		}
		private void butt_itemid_Click(object sender, EventArgs e) {
			SetVal(SkillName.ItemID,this.itemidinfo.Text);
		}
		private void butt_tasteid_Click(object sender, EventArgs e) {
			SetVal(SkillName.TasteID,this.tasteidinfo.Text);
		}
		#endregion skillbutton responses


		private void butt_Refresh_Click(object sender, EventArgs e) {
			this.RefreshClientList();
		}
		private void butt_Disconnect_Click(object sender, EventArgs e) {
			m_Mobile.NetState.Dispose();
			this.RefreshClientList();
		}
		private void butt_Kill_Click(object sender, EventArgs e) {
			m_Mobile.Kill();
			this.healthinfo.Text="Dead";
		}
		private void butt_Resurrect_Click(object sender, EventArgs e) {
			m_Mobile.PlaySound( 0x214 );
			m_Mobile.FixedEffect( 0x376A, 10, 16 );
			m_Mobile.Resurrect();
			this.healthinfo.Text="Alive";
		}

		private void Account_Click(object sender, EventArgs e) {
			if (accountinfo.Text != null && accountinfo.Text.Length > 0) {
				for (int i = 0; i < Core.PluginLoader.LoadedPlugins.Count; i++) {
					if (Core.PluginLoader.LoadedPlugins[i] is AccountPlugin) {
						AccountPlugin acctp = Core.PluginLoader.LoadedPlugins[i] as AccountPlugin;
						if (acctp != null) {
							FirewallPlugin.DeSelectAllFrom(acctp.listBox1, false);
							int idx = acctp.listBox1.Items.IndexOf(this.accountinfo.Text);
							if (idx != -1) {
								acctp.listBox1.SetSelected(idx , true);
								Core.MainForm.TabControl.SelectedTab = Core.MainForm.TabControl.TabPages[Core.MainForm.TabControl.TabPages.IndexOf(acctp)];
								return;
							} else {
								MessageBox.Show(Core.MainForm, "Account not found", "Error");
								return;
							}
						}
					}
				}
				MessageBox.Show(Core.MainForm, "AccountPlugin not loaded", "Error");
			} else {
				MessageBox.Show(Core.MainForm, "No Player selected", "Error");
			}
		}

		private void butt_firewall_Click(object sender, System.EventArgs e) {
			if (this.addressinfo.Text != null && this.addressinfo.Text.Length > 0) {
				for (int i = 0; i < Core.PluginLoader.LoadedPlugins.Count; i++) {
					if (Core.PluginLoader.LoadedPlugins[i] is FirewallPlugin) {
						FirewallPlugin fwp = Core.PluginLoader.LoadedPlugins[i] as FirewallPlugin;
						if (fwp != null) {
							FirewallPlugin.DeSelectAllFrom(fwp.ListBox_Ingame, false);
							int idx = fwp.ListBox_Ingame.Items.IndexOf(this.addressinfo.Text);
							if (idx != -1) {
								Core.MainForm.TabControl.SelectedTab = Core.MainForm.TabControl.TabPages[Core.MainForm.TabControl.TabPages.IndexOf(fwp)];
								fwp.ListBox_Ingame.SetSelected(idx , true);
								return;
							} else {
								MessageBox.Show(Core.MainForm, "IP not found", "Error");
								return;
							}
						}
					}
				}
				MessageBox.Show(Core.MainForm, "FirewallPlugin not loaded", "Error");
			} else {
				MessageBox.Show(Core.MainForm, "No Player selected", "Error");
			}
		} 

		protected override void OnVisibleChanged(EventArgs e) {
			base.OnVisibleChanged (e);

			this.RefreshClientList();
			this.RefreshPropertyTabControl();
		}
	}
}