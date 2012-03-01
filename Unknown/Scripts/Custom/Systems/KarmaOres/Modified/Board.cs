using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseBoards : Item, ICommodity
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
				return String.Format( Amount == 1 ? "{0} Board" : "{0} Boards", Amount );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

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
					m_Resource = (CraftResource)reader.ReadInt();
					break;
				}
				case 0:
				{
					OreInfo info = new OreInfo( reader.ReadInt(), reader.ReadInt(), reader.ReadString() );

					m_Resource = CraftResources.GetFromOreInfo( info );
					break;
				}
			}
		}

		public BaseBoards( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseBoards( CraftResource resource, int amount ) : base( 0x1BD7 )
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseBoards( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1027128 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1027127 ); // board
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( !CraftResources.IsStandard( m_Resource ) )
			{
				int num = CraftResources.GetLocalizationNumber( m_Resource );

				if ( num > 0 )
					list.Add( num );
				else
					list.Add( CraftResources.GetName( m_Resource ) );
			}
		}
	}

	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class Board : BaseBoards
	{
		[Constructable]
		public Board() : this( 1 )
		{
		}

		[Constructable]
		public Board( int amount ) : base( CraftResource.Log, amount )
		{
		}

		public Board( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class PineBoard : BaseBoards
	{
		[Constructable]
		public PineBoard() : this( 1 )
		{
		}

		[Constructable]
		public PineBoard( int amount ) : base( CraftResource.Pine, amount )
		{
		}

		public PineBoard( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class CedarBoard : BaseBoards
	{
		[Constructable]
		public CedarBoard() : this( 1 )
		{
		}

		[Constructable]
		public CedarBoard( int amount ) : base( CraftResource.Cedar, amount )
		{
		}

		public CedarBoard( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class CherryBoard : BaseBoards
	{
		[Constructable]
		public CherryBoard() : this( 1 )
		{
		}

		[Constructable]
		public CherryBoard( int amount ) : base( CraftResource.Cherry, amount )
		{
		}

		public CherryBoard( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class MahoganyBoard : BaseBoards
	{
		[Constructable]
		public MahoganyBoard() : this( 1 )
		{
		}

		[Constructable]
		public MahoganyBoard( int amount ) : base( CraftResource.Mahogany, amount )
		{
		}

		public MahoganyBoard( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class OakBoard : BaseBoards
	{
		[Constructable]
		public OakBoard() : this( 1 )
		{
		}

		[Constructable]
		public OakBoard( int amount ) : base( CraftResource.Oak, amount )
		{
		}

		public OakBoard( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class AshBoard : BaseBoards
	{
		[Constructable]
		public AshBoard() : this( 1 )
		{
		}

		[Constructable]
		public AshBoard( int amount ) : base( CraftResource.Ash, amount )
		{
		}

		public AshBoard( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class YewBoard : BaseBoards
	{
		[Constructable]
		public YewBoard() : this( 1 )
		{
		}

		[Constructable]
		public YewBoard( int amount ) : base( CraftResource.Yew, amount )
		{
		}

		public YewBoard( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class HeartwoodBoard : BaseBoards
	{
		[Constructable]
		public HeartwoodBoard() : this( 1 )
		{
		}

		[Constructable]
		public HeartwoodBoard( int amount ) : base( CraftResource.Heartwood, amount )
		{
		}

		public HeartwoodBoard( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class BloodwoodBoard : BaseBoards
	{
		[Constructable]
		public BloodwoodBoard() : this( 1 )
		{
		}

		[Constructable]
		public BloodwoodBoard( int amount ) : base( CraftResource.Bloodwood, amount )
		{
		}

		public BloodwoodBoard( Serial serial ) : base( serial )
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
	
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class FrostwoodBoard : BaseBoards
	{
		[Constructable]
		public FrostwoodBoard() : this( 1 )
		{
		}

		[Constructable]
		public FrostwoodBoard( int amount ) : base( CraftResource.Frostwood, amount )
		{
		}

		public FrostwoodBoard( Serial serial ) : base( serial )
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