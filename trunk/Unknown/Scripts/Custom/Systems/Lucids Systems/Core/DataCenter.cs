/*
    _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2007 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \    lucidnagual@charter.net    \
    \_     ===================      \
     \   -Owner of "The Conjuring"-  \
      \_     ===================     ~\
       )      Lucid's Mega Pack        )
      /~    The Mother Load v1.1     _/
    _/_______________________________/
 -=(_)_______________________________)=-

 */
using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.ACC.CM;
using Server.Commands;
using Server.Enums;
using Server.Messages;
using System.Collections;
using System.Collections.Generic;


namespace Server.LucidNagual
{
	public class DataCenter
	{
		public static bool EnableAllSystems = false;
		
		public static bool DebugAdvancedArchery = false;		
		
		//All Spells
		public static bool EnableClassSystem = true;	//Enables restrictive spell system.
		public static bool EnableRaceSystem = true;		//Enables player races.
		public static bool SetRestrictions = true;
		public static bool SetSkinHues = true;
		public static bool SetGiveBooks = true;
		public static bool SetFreeSkills = true;
		public static bool FelSpawn  = false;			//Is a control center spawned in Felucca?
		public static bool TramSpawn = false;			//Is a control center spawned in Trammel?
		public static bool TokSpawn  = false;			//Is a control center spawned in Tokuno?
		public static bool FelTrainer  = false;			//Is a magics trainer spawned in Feucca?
		public static bool TramTrainer = false;			//Is a magics trainer spawned in Trammel?
		public static bool TokTrainer  = false;			//Is a magics trainer spawned in Tokuno?
		public static bool SpawnMagicTrainers = true;	//Is it ok to spawn the magic trainers?
		//All Spells
		
		//Easy Level System
		public static bool EnableLevelSystem = true;
		public static bool EnableExpTokens = true;
		public static bool EnableSkillPoints = true;	//Enables Easy Level System's skill point rewards.
		//Easy Level System
		
		//Mega Pack Customs
		public static bool EnableAllSpells = true;			//Lucid Nagual & X-Sirsly-X
		public static bool EnableAdvancedArchery = true;	//Lucid Nagual & Rift
		public static bool EnableCustomBODs = true;			//Lucid Nagual & HotBird
		public static bool EnableOWLTR = true;				//Daat99 
		public static bool EnableUOWedding = true;			//DarkSatan
		public static bool EnablePlayerLevelSystem = true;	//Bacaw
		public static bool EnableWeaponLevelSystem = true;	//Dracana
		public static bool EnableToolbar = true;			//Joeku
		public static bool EnableHelpMenu = true;			//Joeku
		public static bool EnableFSTaming = true;			//RoninGT
		public static bool EnableHunting = true;			//GoldDraco13
		//Mega Pack Customs
		
		public static bool EnableNameProperties = true;		//Enables playermobiles name properties.

		public DataCenter()
		{
		}
		
		public virtual void Serialize( GenericWriter writer )
		{
			writer.Write( ( int )0 ); // version
			
			//Version 0 [start]
			writer.Write( ( bool )EnableNameProperties );
			writer.Write( ( bool )EnableAllSystems );
			writer.Write( ( bool )EnableClassSystem );
			writer.Write( ( bool )EnableRaceSystem );
			writer.Write( ( bool )EnableSkillPoints );
			writer.Write( ( bool )EnableAdvancedArchery );
			writer.Write( ( bool )EnableCustomBODs );
			writer.Write( ( bool )EnableAllSpells );
			writer.Write( ( bool )EnableOWLTR );
			writer.Write( ( bool )EnableUOWedding );
			writer.Write( ( bool )EnablePlayerLevelSystem );
			writer.Write( ( bool )EnableWeaponLevelSystem );
			writer.Write( ( bool )EnableToolbar );
			writer.Write( ( bool )EnableHelpMenu );
			writer.Write( ( bool )EnableFSTaming );
			writer.Write( ( bool )EnableHunting );
			writer.Write( ( bool )SpawnMagicTrainers );
			
			writer.Write( ( bool )TramSpawn );
			writer.Write( ( bool )FelSpawn );
			writer.Write( ( bool )TokSpawn );
			writer.Write( ( bool )TramTrainer );
			writer.Write( ( bool )FelTrainer );
			writer.Write( ( bool )TokTrainer );
			writer.Write( ( bool )SetFreeSkills );
			writer.Write( ( bool )SetGiveBooks );
			writer.Write( ( bool )SetRestrictions );
			writer.Write( ( bool )SetSkinHues );
			//Version 0 [end]
		}
		
		public virtual void Deserialize( GenericReader reader )
		{
			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 0:
					{
						//Version 0 [start]
						EnableNameProperties = reader.ReadBool();
						EnableAllSystems = reader.ReadBool();
						EnableClassSystem = reader.ReadBool();
						EnableRaceSystem = reader.ReadBool();
						EnableSkillPoints = reader.ReadBool();
						EnableAdvancedArchery = reader.ReadBool();
						EnableCustomBODs = reader.ReadBool();
						EnableAllSpells = reader.ReadBool();
						EnableOWLTR = reader.ReadBool();
						EnableUOWedding = reader.ReadBool();
						EnablePlayerLevelSystem = reader.ReadBool();
						EnableWeaponLevelSystem = reader.ReadBool();
						EnableToolbar = reader.ReadBool();
						EnableHelpMenu = reader.ReadBool();
						EnableFSTaming = reader.ReadBool();
						EnableHunting = reader.ReadBool();
						SpawnMagicTrainers = reader.ReadBool();
						
						TramSpawn = reader.ReadBool();
						FelSpawn = reader.ReadBool();
						TokSpawn = reader.ReadBool();
						TramTrainer = reader.ReadBool();
						FelTrainer = reader.ReadBool();
						TokTrainer = reader.ReadBool();
						SetFreeSkills = reader.ReadBool();
						SetGiveBooks = reader.ReadBool();
						SetRestrictions = reader.ReadBool();
						SetSkinHues = reader.ReadBool();
						//Version 0 [end]
						break;
					}
			}
		}
	}
}
