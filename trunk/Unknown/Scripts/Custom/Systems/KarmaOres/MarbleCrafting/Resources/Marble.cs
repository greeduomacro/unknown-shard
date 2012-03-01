/////////////////////////////////////////////////
//                                             //
// Created by Manu for                         //
// Splitterwelt.com                            //
// german roleplay freeshard                   //
//                                             //
// may be used and modified as you like, as    //
// long as this header is kept                 //
/////////////////////////////////////////////////
// Modified by Karmageddon to go with resources
// Redone for less coding and to create BaseMarble
// So that multiple marble are selectable on crafting menu

using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseMarble : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}
		
		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} {1} raw marble block", Amount, CraftResources.GetName( m_Resource ).ToLower() );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Resource = (CraftResource)reader.ReadInt();
					break;
				}
			}
		}

		public BaseMarble( CraftResource resource ) : base( 0x00DF )
		{			
			Weight = 10.0;
			Hue = CraftResources.GetHue( resource );
			m_Resource = resource;
		}

		public BaseMarble( Serial serial ) : base( serial )
		{
		}
		
		private string GetNameString()
		{
			string name = this.Name;

			if ( name == null )
				name = String.Format( "raw marble block" );

			return name;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			string oreType;

			if ( Hue == 0 )
			{
				oreType = "";
			}
			else
			{
				switch ( m_Resource )
				{
					case CraftResource.DullCopper:			oreType = "dull copper"; break; 
					case CraftResource.ShadowIron:			oreType = "shadow iron"; break; 
					case CraftResource.Copper:			oreType = "copper"; break; 
					case CraftResource.Bronze:			oreType = "bronze"; break; 					
					case CraftResource.Gold:			oreType = "gold"; break;
					case CraftResource.Agapite:			oreType = "agapite"; break;
					case CraftResource.Verite:			oreType = "verite"; break;
					case CraftResource.Valorite:			oreType = "valorite"; break;
					case CraftResource.Silver:			oreType = "silver"; break;
					case CraftResource.Platinum:			oreType = "platinum"; break;
					case CraftResource.Mythril:			oreType = "mythril"; break;
					case CraftResource.Obsidian:			oreType = "obsidian"; break;
					case CraftResource.Jade:			oreType = "jade"; break;
					case CraftResource.Moonstone:			oreType = "moonstone"; break;
					case CraftResource.Sunstone:			oreType = "sunstone"; break;
					case CraftResource.Bloodstone:			oreType = "bloodstone"; break; 					
					default: oreType = ""; break;
				}
			}
			list.Add( 1053099, "{0}\t{1}", oreType, GetNameString() ); // ~1_oretype~ ~2_armortype~
		}

	}

	public class Marble : BaseMarble
	{
		[Constructable]
		public Marble() : base( CraftResource.Iron )
		{
		}

		public Marble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class DullCopperMarble : BaseMarble
	{
		[Constructable]
		public DullCopperMarble() : base( CraftResource.DullCopper )
		{
		}

		public DullCopperMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class ShadowIronMarble : BaseMarble
	{
		[Constructable]
		public ShadowIronMarble() : base( CraftResource.ShadowIron )
		{
		}

		public ShadowIronMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class CopperMarble : BaseMarble
	{
		[Constructable]
		public CopperMarble() : base( CraftResource.Copper )
		{
		}

		public CopperMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class BronzeMarble : BaseMarble
	{
		[Constructable]
		public BronzeMarble() : base( CraftResource.Bronze )
		{
		}

		public BronzeMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class GoldMarble : BaseMarble
	{
		[Constructable]
		public GoldMarble() : base( CraftResource.Gold )
		{
		}

		public GoldMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class AgapiteMarble : BaseMarble
	{
		[Constructable]
		public AgapiteMarble() : base( CraftResource.Agapite )
		{
		}

		public AgapiteMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class VeriteMarble : BaseMarble
	{
		[Constructable]
		public VeriteMarble() : base( CraftResource.Verite )
		{
		}

		public VeriteMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class ValoriteMarble : BaseMarble
	{
		[Constructable]
		public ValoriteMarble() : base( CraftResource.Valorite )
		{
		}

		public ValoriteMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	
	public class SilverMarble : BaseMarble
	{
		[Constructable]
		public SilverMarble() : base( CraftResource.Silver )
		{
		}

		public SilverMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	
	public class PlatinumMarble : BaseMarble
	{
		[Constructable]
		public PlatinumMarble() : base( CraftResource.Platinum )
		{
		}

		public PlatinumMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	
		public class MythrilMarble : BaseMarble
	{
		[Constructable]
		public MythrilMarble() : base( CraftResource.Mythril )
		{
		}

		public MythrilMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	
	public class ObsidianMarble : BaseMarble
	{
		[Constructable]
		public ObsidianMarble() : base( CraftResource.Obsidian )
		{
		}

		public ObsidianMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class JadeMarble : BaseMarble
	{
		[Constructable]
		public JadeMarble() : base( CraftResource.Jade )
		{
		}

		public JadeMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class MoonstoneMarble : BaseMarble
	{
		[Constructable]
		public MoonstoneMarble() : base( CraftResource.Moonstone )
		{
		}

		public MoonstoneMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SunstoneMarble : BaseMarble
	{
		[Constructable]
		public SunstoneMarble() : base( CraftResource.Sunstone )
		{
		}

		public SunstoneMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class BloodstoneMarble : BaseMarble
	{
		[Constructable]
		public BloodstoneMarble() : base( CraftResource.Bloodstone )
		{
		}

		public BloodstoneMarble( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}