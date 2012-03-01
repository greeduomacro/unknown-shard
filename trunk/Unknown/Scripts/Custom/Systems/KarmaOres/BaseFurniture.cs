using System;
using System.Collections;
using System.Text;
using Server.Network;
using Server.Engines.Craft;

namespace Server.Items
{
	public enum FurnitureQuality
	{
		Low,
		Regular,
		Exceptional
	}
	
	public abstract class BaseFurniture : Item, ICraftable
	{
		private Mobile m_Crafter;
		private FurnitureQuality m_Quality;
		private CraftResource m_Resource;
		private bool m_PlayerConstructed;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Crafter
		{
			get{ return m_Crafter; }
			set{ m_Crafter = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public FurnitureQuality Quality
		{
			get{ return m_Quality; }
			set{ m_Quality = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool PlayerConstructed
		{
			get{ return m_PlayerConstructed; }
			set{ m_PlayerConstructed = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get
			{
				return m_Resource;
			}
			set
			{
				if ( m_Resource != value )
				{
					m_Resource = value;
					Hue = CraftResources.GetHue( m_Resource );

					InvalidateProperties();
				}
			}
		}
		
		public BaseFurniture( int itemID ) : base( itemID )
		{
			m_Quality = FurnitureQuality.Regular;
		}

		public BaseFurniture( Serial serial ) : base( serial )
		{
		}
		
		public override void OnSingleClick( Mobile from )
		{
			ArrayList attrs = new ArrayList();
			
			if ( m_Quality == FurnitureQuality.Exceptional )
				attrs.Add( new EquipInfoAttribute( 1018305 - (int)m_Quality ) );

			int number;

			if ( Name == null )
			{
				number = LabelNumber;
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			if ( attrs.Count == 0 && Crafter == null && Name != null )
				return;

			EquipmentInfo eqInfo = new EquipmentInfo( number, m_Crafter, false, (EquipInfoAttribute[])attrs.ToArray( typeof( EquipInfoAttribute ) ) );

			from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			
			if ( m_Crafter != null ) 
				list.Add( 1050043, m_Crafter.Name ); // crafted by ~1_NAME~
				
			if( m_Quality == FurnitureQuality.Exceptional )
				list.Add( 1060636 ); // exceptional
		}				

		private static void SetSaveFlag( ref SaveFlag flags, SaveFlag toSet, bool setIf )
		{
			if ( setIf )
				flags |= toSet;
		}

		private static bool GetSaveFlag( SaveFlag flags, SaveFlag toGet )
		{
			return ( (flags & toGet) != 0 );
		}
		
		[Flags]
		private enum SaveFlag
		{
			None				= 0x00000000,			
			Crafter				= 0x00000001,
			Quality				= 0x00000002,
			Resource			= 0x00000004,
			PlayerConstructed		= 0x00000008
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			SaveFlag flags = SaveFlag.None;
			
			SetSaveFlag( ref flags, SaveFlag.Quality,			m_Quality != FurnitureQuality.Regular );
			SetSaveFlag( ref flags, SaveFlag.Crafter,			m_Crafter != null );
			SetSaveFlag( ref flags, SaveFlag.Resource,			m_Resource != CraftResource.Log );
			SetSaveFlag( ref flags, SaveFlag.PlayerConstructed,		m_PlayerConstructed );
			
			writer.Write( (int) flags );
			
			if ( GetSaveFlag( flags, SaveFlag.Quality ) )
				writer.Write( (int) m_Quality );
				
			if ( GetSaveFlag( flags, SaveFlag.Crafter ) )
				writer.Write( (Mobile) m_Crafter );
				
			if ( GetSaveFlag( flags, SaveFlag.Resource ) )
				writer.Write( (int) m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					SaveFlag flags = (SaveFlag)reader.ReadInt();
					
					if ( GetSaveFlag( flags, SaveFlag.Quality ) )
						m_Quality = (FurnitureQuality)reader.ReadInt();
					else
						m_Quality = FurnitureQuality.Regular;
						
					if ( GetSaveFlag( flags, SaveFlag.Crafter ) )
						m_Crafter = reader.ReadMobile();
						
					if ( GetSaveFlag( flags, SaveFlag.Resource ) )
						m_Resource = (CraftResource)reader.ReadInt();
					else
						m_Resource = CraftResource.Log;
						
					if ( GetSaveFlag( flags, SaveFlag.PlayerConstructed ) )
						m_PlayerConstructed = true;
						
				break;
			}
			
			case 0:
			{
			
				m_Quality = (FurnitureQuality)reader.ReadInt();
				m_Crafter = reader.ReadMobile();
				
				break;
				}
			}
		}
		
		public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (FurnitureQuality)quality;

			if ( makersMark )
				Crafter = from;

			Type resourceType = typeRes;

			if ( resourceType == null )
				resourceType = craftItem.Ressources.GetAt( 0 ).ItemType;

			Resource = CraftResources.GetFromType( resourceType );
			PlayerConstructed = true;

			CraftContext context = craftSystem.GetContext( from );

			if ( context != null && context.DoNotColor )
				Hue = 0;

			return quality;
		}
		
		private string GetNameString()
		{
			string name = this.Name;

			if ( name == null )
				name = String.Format( "#{0}", LabelNumber );

			return name;
		}
		
		public override void AddNameProperty( ObjectPropertyList list )
		{
			string woodType;

			if ( Hue == 0 )
			{
				woodType = "";
			}
			else
			{
				switch ( m_Resource )
				{
					case CraftResource.Pine:			woodType = "pine"; break; 
					case CraftResource.Cedar:			woodType = "cedar"; break; 
					case CraftResource.Cherry:			woodType = "cherry"; break; 
					case CraftResource.Mahogany:			woodType = "mahogany"; break; 					
					case CraftResource.Oak:				woodType = "oak"; break; 					
					default: woodType = ""; break;
				}
			}
			list.Add( 1053099, "{0}\t{1}", woodType, GetNameString() ); // ~1_oretype~ ~2_armortype~
		}
	}
}