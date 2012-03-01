using System;
using Server.Items;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.Multis.Deeds;

namespace Server.Engines.Craft
{
	public class DefArchitect : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Carpentry; }
		}

		public override string GumpTitleString
		{
			get { return "<BASEFONT COLOR=#FFFFFF><CENTER>Architecture</CENTER></BASEFONT>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefArchitect();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.50; // 50%
		}

		private DefArchitect() : base( 1, 1, 1.25 )// base( 1, 1, 3.0 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type typeItem )
		{
			if ( tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
				
			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x23D );
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
				return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = -1;
			
			// Comp

			index = AddCraft( typeof( WallSection ), "Components", "wall section", 95.0, 115.0, typeof( Board ), "Board", 100 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );
			AddRes( index, typeof( IronIngot ), "Iron Ingot", 50 );

			index = AddCraft( typeof( FloorSection ), "Components", "floor section", 95.0, 115.0, typeof( Board ), "Board", 100 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );
			AddRes( index, typeof( IronIngot ), "Iron Ingot", 50 );

			index = AddCraft( typeof( RoofSection ), "Components", "roof section", 95.0, 115.0, typeof( Board ), "Board", 100 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );
			AddRes( index, typeof( IronIngot ), "Iron Ingot", 50 );

			index = AddCraft( typeof( DeckSection ), "Components", "deck section", 95.0, 115.0, typeof( Board ), "Board", 100 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );
			AddRes( index, typeof( IronIngot ), "Iron Ingot", 50 );

			index = AddCraft( typeof( SailSection ), "Components", "sail section", 95.0, 115.0, typeof( Cloth ), "Cloth", 100 );
			AddSkill( index, SkillName.Tailoring, 95.0, 115.0 );

			index = AddCraft( typeof( FullWallUnit ), "Components", "full wall unit", 95.0, 115.0, typeof( WallSection ), "Wall Section", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );

			index = AddCraft( typeof( FullFloorUnit ), "Components", "full floor unit", 95.0, 115.0, typeof( FloorSection ), "Floor Section", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );

			index = AddCraft( typeof( FullRoofUnit ), "Components", "full roof unit", 95.0, 115.0, typeof( RoofSection ), "Roof Section", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );

			index = AddCraft( typeof( FullDeckUnit ), "Components", "full deck unit", 95.0, 115.0, typeof( DeckSection ), "Deck Section", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );

			index = AddCraft( typeof( FullSailUnit ), "Components", "full sail unit", 95.0, 115.0, typeof( SailSection ), "Sail Section", 10 );
			AddSkill( index, SkillName.Tailoring, 95.0, 115.0 );

			index = AddCraft( typeof( SupportBeam ), "Components", "support beam", 95.0, 115.0, typeof( Board ), "Board", 75 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );

			index = AddCraft( typeof( FoundationBlock ), "Components", "foundation block", 95.0, 115.0, typeof( Granite ), "Granite", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 115.0 );

			// Residential Structure

			index = AddCraft( typeof( StonePlasterHouseDeed ), "Residential Structure", "stone and plaster house", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( FieldStoneHouseDeed ), "Residential Structure", "field stone house", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( SmallBrickHouseDeed ), "Residential Structure", "small brick house", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( WoodPlasterHouseDeed ), "Residential Structure", "wood and plaster house", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( ThatchedRoofCottageDeed ), "Residential Structure", "thatched roof cottage", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( StoneWorkshopDeed ), "Residential Structure", "small stone workshop", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( MarbleWorkshopDeed ), "Residential Structure", "small marble workshop", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( SmallTowerDeed ), "Residential Structure", "small tower", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( VillaDeed ), "Residential Structure", "two-story villa", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 12 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 12 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 12 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 12 );

			index = AddCraft( typeof( SandstonePatioDeed ), "Residential Structure", "sandstone house with patio", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 11 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 11 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 11 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 11 );

			index = AddCraft( typeof( LogCabinDeed ), "Residential Structure", "two-story log cabin", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 12 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 12 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 12 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 12 );

			index = AddCraft( typeof( BrickHouseDeed ), "Residential Structure", "brick house", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( TwoStoryWoodPlasterHouseDeed ), "Residential Structure", "two-story wood and plaster house", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( TwoStoryStonePlasterHouseDeed ), "Residential Structure", "two-story stone and plaster house", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( LargePatioDeed ), "Residential Structure", "large house with patio", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( LargeMarbleDeed ), "Residential Structure", "marble house with patio", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( TowerDeed ), "Residential Structure", "Tower", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 20 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 20 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 20 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 20 );

			index = AddCraft( typeof( KeepDeed ), "Residential Structure", "small stone keep", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 25 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 25 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 25 );

			index = AddCraft( typeof( CastleDeed ), "Residential Structure", "castle", 90.0, 105.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 90.0, 105.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 30 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 30 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 30 );

			// Civic Structures

			index = AddCraft( typeof( FieldStoneCityHallDeed ), "Civic Structure", "field stone city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( SandstoneCityHallDeed ), "Civic Structure", "sandstone city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( MarbleCityHallDeed ), "Civic Structure", "marble city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( NecroCityHallDeed ), "Civic Structure", "necro city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( AsianCityHallDeed ), "Civic Structure", "asian city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( StoneCityHallDeed ), "Civic Structure", "stone city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( WoodCityHallDeed ), "Civic Structure", "wood city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( PlasterCityHallDeed ), "Civic Structure", "plaster city hall", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 30 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( PlasterCityHealerDeed ), "Civic Structure", "plaster city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( WoodCityHealerDeed ), "Civic Structure", "wood city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( StoneCityHealerDeed ), "Civic Structure", "stone city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( FieldstoneCityHealerDeed ), "Civic Structure", "fieldstone city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( SandstoneCityHealerDeed ), "Civic Structure", "sandstone city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( MarbleCityHealerDeed ), "Civic Structure", "marble city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( NecroCityHealerDeed ), "Civic Structure", "necro city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( AsianCityHealerDeed ), "Civic Structure", "asian city healer", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( WoodCityBankDeed ), "Civic Structure", "wood city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( StoneCityBankDeed ), "Civic Structure", "stone city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( PlasterCityBankDeed ), "Civic Structure", "plaster city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( FieldstoneCityBankDeed ), "Civic Structure", "fieldstone city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( SandstoneCityBankDeed ), "Civic Structure", "sandstone city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( NecroCityBankDeed ), "Civic Structure", "necro city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( MarbleCityBankDeed ), "Civic Structure", "marble city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( AsianCityBankDeed ), "Civic Structure", "asian city bank", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( WoodCityStableDeed ), "Civic Structure", "wood city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( StoneCityStableDeed ), "Civic Structure", "stone city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( PlasterCityStableDeed ), "Civic Structure", "plaster city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( FieldstoneCityStableDeed ), "Civic Structure", "fieldstone city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( SandstoneCityStableDeed ), "Civic Structure", "sandstone city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( NecroCityStableDeed ), "Civic Structure", "necro city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( MarbleCityStableDeed ), "Civic Structure", "marble city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( AsianCityStableDeed ), "Civic Structure", "asian city stable", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( WoodCityTavernDeed ), "Civic Structure", "wood city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( StoneCityTavernDeed ), "Civic Structure", "stone city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( PlasterCityTavernDeed ), "Civic Structure", "plaster city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( FieldstoneCityTavernDeed ), "Civic Structure", "fieldstone city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( SandstoneCityTavernDeed ), "Civic Structure", "sandstone city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( MarbleCityTavernDeed ), "Civic Structure", "marble city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( NecroCityTavernDeed ), "Civic Structure", "necro city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( AsianCityTavernDeed ), "Civic Structure", "asian city tavern", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 25 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( WoodCityMoongateDeed ), "Civic Structure", "wood city moongate", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( StoneCityMoongateDeed ), "Civic Structure", "stone city moongate", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( SandstoneCityMoongateDeed ), "Civic Structure", "sandstone city moongate", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( MarbleCityMoongateDeed ), "Civic Structure", "marble city moongate", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( NecroCityMoongateDeed ), "Civic Structure", "necro city moongate", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( AsianCityMoongateDeed ), "Civic Structure", "asian city moongate", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			// Harvesters
			/*
			index = AddCraft( typeof( AsianCityMoongateDeed ), "Harvesters", "small mineral harvester", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( AsianCityMoongateDeed ), "Harvesters", "small organic harvester", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( AsianCityMoongateDeed ), "Harvesters", "medium mineral harvester", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( AsianCityMoongateDeed ), "Harvesters", "medium organic harvester", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( AsianCityMoongateDeed ), "Harvesters", "large mineral harvester", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( AsianCityMoongateDeed ), "Harvesters", "large organic harvester", 95.0, 106.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 95.0, 106.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );
			*/
			// Parks & Gardens

			index = AddCraft( typeof( SmallCityGardenDeed ), "Parks & Gardens", "small garden", 80.0, 100.0, typeof( FullWallUnit ), "Full Wall Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 100.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 5 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 5 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 5 );

			index = AddCraft( typeof( MediumCityGardenDeed ), "Parks & Gardens", "medium garden", 80.0, 100.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 100.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( LargeCityGardenDeed ), "Parks & Gardens", "large garden", 80.0, 100.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 100.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( SmallCityParkDeed ), "Parks & Gardens", "small park", 80.0, 100.0, typeof( FullWallUnit ), "Full Wall Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 100.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 10 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 10 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 10 );

			index = AddCraft( typeof( MediumCityParkDeed ), "Parks & Gardens", "medium park", 80.0, 100.0, typeof( FullWallUnit ), "Full Wall Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 100.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 15 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 15 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 15 );

			index = AddCraft( typeof( LargeCityParkDeed ), "Parks & Gardens", "large park", 80.0, 100.0, typeof( FullWallUnit ), "Full Wall Unit", 20 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 100.0 );
			AddRes( index, typeof( FullFloorUnit ), "Full Floor Unit", 20 );
			AddRes( index, typeof( FullRoofUnit ), "Full Roof Unit", 20 );
			AddRes( index, typeof( FoundationBlock ), "Foundation Block", 20 );

			// Shipwright

			index = AddCraft( typeof( SmallBoatDeed ), "Shipwright Structures", "small ship", 50.0, 80.0, typeof( FullDeckUnit ), "Full Deck Unit", 5 );
			AddSkill( index, SkillName.Blacksmith, 50.0, 80.0 );
			AddRes( index, typeof( FullSailUnit ), "Full Sail Unit", 5 );
			AddRes( index, typeof( SupportBeam ), "Support Beam", 2 );

			index = AddCraft( typeof( MediumBoatDeed ), "Shipwright Structures", "medium ship", 60.0, 90.0, typeof( FullDeckUnit ), "Full Deck Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 60.0, 90.0 );
			AddRes( index, typeof( FullSailUnit ), "Full Sail Unit", 10 );
			AddRes( index, typeof( SupportBeam ), "Support Beam", 4 );

			index = AddCraft( typeof( LargeBoatDeed ), "Shipwright Structures", "large ship", 70.0, 100.0, typeof( FullDeckUnit ), "Full Deck Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 70.0, 100.0 );
			AddRes( index, typeof( FullSailUnit ), "Full Sail Unit", 15 );
			AddRes( index, typeof( SupportBeam ), "Support Beam", 6 );

			index = AddCraft( typeof( SmallDragonBoatDeed ), "Shipwright Structures", "small dragon ship", 60.0, 90.0, typeof( FullDeckUnit ), "Full Deck Unit", 10 );
			AddSkill( index, SkillName.Blacksmith, 60.0, 90.0 );
			AddRes( index, typeof( FullSailUnit ), "Full Sail Unit", 10 );
			AddRes( index, typeof( SupportBeam ), "Support Beam", 4 );

			index = AddCraft( typeof( MediumDragonBoatDeed ), "Shipwright Structures", "medium dragon ship", 70.0, 100.0, typeof( FullDeckUnit ), "Full Deck Unit", 15 );
			AddSkill( index, SkillName.Blacksmith, 70.0, 100.0 );
			AddRes( index, typeof( FullSailUnit ), "Full Sail Unit", 15 );
			AddRes( index, typeof( SupportBeam ), "Support Beam", 6 );

			index = AddCraft( typeof( LargeDragonBoatDeed ), "Shipwright Structures", "large dragon ship", 80.0, 110.0, typeof( FullDeckUnit ), "Full Deck Unit", 20 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 110.0 );
			AddRes( index, typeof( FullSailUnit ), "Full Sail Unit", 20 );
			AddRes( index, typeof( SupportBeam ), "Support Beam", 8 );

			// Civic Decore

			index = AddCraft( typeof( CityHedge ), "Civic Decore", "hedge", 80.0, 100.0, typeof( FertileDirt ), "Fertile Dirt", 5 );

			index = AddCraft( typeof( CityLampPost ), "Civic Decore", "lamp post", 80.0, 100.0, typeof( IronIngot ), "Iron Ingot", 100 );

			index = AddCraft( typeof( CityTrashCan ), "Civic Decore", "trash barrel", 80.0, 100.0, typeof( Board ), "Board", 100 );
		}
	}
}
