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


namespace Server.Enums
{
	public enum MobileAccess
	{
		Player,  //Player is default.
		Subscriber,
		Counsler,
		GameMaster,
		Seer,
		Designer,
		Adminstrator,
		Owner
	}
	
	public enum CustomSkillLock : byte
	{
		Up = 0,
		Down = 1,
		Locked = 2
	}
	
	public enum CustomSkillName
	{
		Cleric = 0,
		Druid = 1,
		Bard = 2,
		Ranger = 3,
		Rogue = 4,
		Nomad = 5,
		Farmer = 6,
		Laborer = 7,
		Crafter = 8,
		BeastMaster = 9,
		Hunter = 10,
		Cannibal = 11,
		Villian = 12,
		Brujo = 13,
		Jester = 14
	}
	
	public enum PlayerRaces
	{
		Human,  //Human is default.
		Drow,
		Angel,
		Elf,
		Vampire,
		Gargoyle,	//replace dwarf
		Dwarf,		//remove
		Orc,
		Elk,
		Demon
	}
	
	public enum PlayerClasses
	{
		None,      //None is default.
		Nomad,
		Cleric,
		Druid,
		Bard,
		Ranger,
		Rogue,
		Farmer,
		Laborer,
		Crafter,
		Paladin,
		Mage,
		Necromancer,
		Ninja,
		Samurai,
		Arcanist,
		Tamer,
		Jester
	}
	
	public enum GateAccess
	{
		None,      //None is default.
		Nomad,
		Cleric,
		Druid,
		Bard,
		Ranger,
		Rogue,
		Farmer,
		Laborer,
		Crafter,
		Paladin,
		Mage,
		Necromancer,
		Ninja,
		Samurai,
		Arcanist,
		Tamer
	}
	
	public enum PlayerTribes
	{
		Lowland,
		Highland,
		Swampland,
		Woodland,
		SandDweller,
		CaveDweller,
		Aquatic,
		Cannibal
	}
	
	public enum PlayerRanks
	{
		Civilian,
		Scholar,
		General,
		WarMonger,
		Hero,
		Monarch,
		Leader
	}
	
	public enum PlayerAlignment
	{
		None,
		ChaoticGood,
		ChaoticNeutral,
		ChaoticEvil,
		NeutralGood,
		TrueNeutral,
		NeutralEvil,
		LawfulGood,
		LawfulNeutral,
		LawfulEvil
	}
	
	public enum PlayerReligion
	{
		None,  //None is default.
		Atheist,
		Holylight,
		Saddist,
		Mythology
	}
	
	public enum PlayerDeity
	{
		None   //None is default.
	}
	
	public enum PlayerBloodType
	{
		//Human
		TypeOPositive,    //38.25 %
		TypeONegative,    //6.75 %
		TypeAPositive,    //34.00 %
		TypeANegative,    //6.00 %
		TypeBPositive,    //8.50 %
		TypeBNegative,    //1.50 %
		TypeABPositive,   //4.25 %
		TypeABNegative,   //0.75 %
		//Human
		
		//NonHuman
		TypeElf,
		TypeHalfling,
		TypeAngel,
		TypeFairy,
		TypeOrc,
		TypeCentaur,
		TypeDeamon,
		TypeLizard,
		TypeGargoyle,
		TypeVampire,
		TypeWerewolf
	}
	
	public enum PlayerSickness
	{
		None,
		Headache,
		Cold,
		Flu,
		Virus,
		Plague,
		Disease
	}
	
	public enum PlayerVirus
	{
		None
	}
	
	public enum MaritalStatus
	{
		Single,
		Married,
		Separated,
		Divorced,
		Widowed
	}
	
	public enum TypeOfMarriage
	{
		OppositeSex,
		SameSex,
		Celestial
	}
	
	public enum ArrowType
	{
		Normal,
		Poison,
		Explosive,
		ArmorPiercing,
		Freeze,
		Lightning
	}
	
	public enum BoltType
	{
		Normal,
		Poison,
		Explosive,
		ArmorPiercing,
		Freeze,
		Lightning
	}
	
	//--<<Bow Stringer Edit>>---------------------[Start]
	public enum StringType
	{
		LinenThread,
		Cotton,
		Silk,
		HorseHair,
		Hemp,
		AngelHair
	}
	
	public enum PoundsPerPull
	{
		Zero = 0,
		Fourty = 40,
		Sixty = 60,
		Eighty = 80,
		Hundred = 100
	}
	
	public enum StringStrength
	{
		NoString = 0,
		VeryWeak = 1,
		Weak = 2,
		Sturdy = 3,
		Strong = 4,
		Dependable = 5,
		Indestructable = 6
	}
	//--<<Bow Stringer Edit>>---------------------[End]
	
	/*GD13_HS_Start_1*/
	public enum HuntMode
	{
		None,
		Easy,
		Hard,
		Extreme,
		God
	}
	
	public enum HuntRank
	{
		None,
		Squire,
		Guardsman,
		Hunter,
		Stalker,
		Slayer,
		General,
		Elite,
		Master,
		GrandMaster,
		Elder,
		Legend,
		Diety,
		God
	}
	
	public enum HuntReward
	{
		None,
		Squire,
		Guardsman,
		Hunter,
		Stalker,
		Slayer,
		General,
		Elite,
		Master,
		GrandMaster,
		Elder,
		Legend,
		Diety,
		God
	}
	/*GD13_HS_End_1*/
	
	public enum CCSpawns
	{
		Felucca,
		Trammel,
		Tokuno
	}
	
	public enum TeamType
	{
		None = 0,
		FreeForAll = 1,
		BlueTeam = 2,
		RedTeam = 3,
		GreenTeam = 4,
		PurpleTeam = 5
	}
}
