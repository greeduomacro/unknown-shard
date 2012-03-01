/////////////////////////////////////////////////
//                                             //
// Created by Manu for                         //
// Splitterwelt.com                            //
// german roleplay freeshard                   //
//                                             //
// may be used and modified as you like, as    //
// long as this header is kept                 //
/////////////////////////////////////////////////
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefMarbleCrafting : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Mining; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefMarbleCrafting();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefMarbleCrafting() : base( 1, 1, 1.25 )// base( 1, 1, 1.5 )
		{
		}

		public override bool RetainsColorFrom( CraftItem item, Type type )
		{
			return true;
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if ( tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !(from is PlayerMobile && ((PlayerMobile)from).Masonry && from.Skills[SkillName.Mining].Base >= 50.0) )
				return 1044633; // You havent learned stonecraft.
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				if ( quality == 0 )
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if ( makersMark && quality == 2 )
					return 1044156; // You create an exceptional quality item and affix your maker's mark.
				else if ( quality == 2 )
					return 1044155; // You create an exceptional quality item.
				else				
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = -1;



			// Other Items
			//AddCraft( typeof( Marble ),				1044294, "raw marble block",	 0.0,   0.0,	typeof( Granite ), 1044514,  1, 1044513 );
			//SetUseSubRes2( index, true );*/

			/* Begin Benches */
			AddCraft( typeof( MarbleBenchSmallSouthAddonDeed ), "Benches", "Small Marble Bench (South)", 80.0, 100.0, typeof( Marble ), "Raw Marble Block", 1, "You need more marble!" );
			AddCraft( typeof( MarbleBenchSmallEastAddonDeed ), "Benches", "Small Marble Bench(East)", 80.0, 100.0, typeof( Marble ), "Raw Marble Block", 1, "You need more marble!" );
			AddCraft( typeof( MarbleBenchMediumSouthAddonDeed ), "Benches", "Medium Marble Bench (South)", 80.0, 105.0, typeof( Marble ), "Raw Marble Block", 2, "You need more marble!" );
			AddCraft( typeof( MarbleBenchMediumEastAddonDeed ), "Benches", "Medium Marble Bench(East)", 80.0, 105.0, typeof( Marble ), "Raw Marble Block", 2, "You need more marble!" );
			AddCraft( typeof( MarbleBenchLongSouthAddonDeed ), "Benches", "Long Marble Bench (South)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 3, "You need more marble!" );
			AddCraft( typeof( MarbleBenchLongEastAddonDeed ), "Benches", "Long Marble Bench (East)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 3, "You need more marble!" );
			/* End Benches */

			/* Begin Statues */
			AddCraft( typeof( LightMarbleDaemonStatueAddonDeed ), "Statues", "Daemon-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleDaemonStatueAddonDeed ), "Statues", "Daemon-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( LightMarbleGargoyleStatueAddonDeed ), "Statues", "Gargoyle-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleGargoyleStatueAddonDeed ), "Statues", "Gargoyle-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( LightMarbleNightmareStatueAddonDeed ), "Statues", "Nightmare-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleNightmareStatueAddonDeed ), "Statues", "Nightmare-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( LightMarbleUnicornStatueAddonDeed ), "Statues", "Unicorn-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleUnicornStatueAddonDeed ), "Statues", "Unicorn-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( LightMarbleRunebeetleStatueAddonDeed ), "Statues", "Runebeetle-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleRunebeetleStatueAddonDeed ), "Statues", "Runebeetle-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( LightMarbleSkeletonwarriorStatueAddonDeed ), "Statues", "Skeletonwarrior-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleSkeletonwarriorStatueAddonDeed ), "Statues", "Skeletonwarrior-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( LightMarbleSnowleopardStatueAddonDeed ), "Statues", "Snowleopard-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleSnowleopardStatueAddonDeed ), "Statues", "Snowleopard-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( LightMarbleWolfStatueAddonDeed ), "Statues", "Wolf-Statue (Bright Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			AddCraft( typeof( DarkMarbleWolfStatueAddonDeed ), "Statues", "Wolf-Statue (Dark Pedestal)", 80.0, 110.0, typeof( Marble ), "Raw Marble Block", 5, "You need more marble!" );
			/* End Statues */

			SetSubRes( typeof( Marble ), "Marble" );

			AddSubRes( typeof( Marble ),			1044525, 00.0, 1044514, 1044526 );
			AddSubRes( typeof( DullCopperMarble ),		1044023, 40.0, 1044514, 1044527 );
			AddSubRes( typeof( ShadowIronMarble ),		1044024, 45.0, 1044514, 1044527 );
			AddSubRes( typeof( CopperMarble ),		1044025, 50.0, 1044514, 1044527 );
			AddSubRes( typeof( BronzeMarble ),		1044026, 55.0, 1044514, 1044527 );
			AddSubRes( typeof( GoldMarble ),		1044027, 60.0, 1044514, 1044527 );
			AddSubRes( typeof( AgapiteMarble ),		1044028, 65.0, 1044514, 1044527 );
			AddSubRes( typeof( VeriteMarble ),		1044029, 70.0, 1044514, 1044527 );
			AddSubRes( typeof( ValoriteMarble ),		1044030, 75.0, 1044514, 1044527 );
			AddSubRes( typeof( SilverMarble ),     		"SILVER", 80.0, 1044527 );
			AddSubRes( typeof( PlatinumMarble ),   		"PLATINUM", 85.0, 1044527 );
			AddSubRes( typeof( MythrilMarble ),    		"MYTHRIL", 90.0, 1044527 );
			AddSubRes( typeof( ObsidianMarble ),   		"OBSIDIAN", 95.0, 1044527 );
			AddSubRes( typeof( JadeMarble ),       		"JADE", 100.0, 1044527 );
			AddSubRes( typeof( MoonstoneMarble ),  		"MOONSTONE", 105.0, 1044527 );
			AddSubRes( typeof( SunstoneMarble ),   		"SUNSTONE", 110.0, 1044527 );
			AddSubRes( typeof( BloodstoneMarble ), 		"BLOODSTONE", 115.0, 1044527 );			

		}
	}
}