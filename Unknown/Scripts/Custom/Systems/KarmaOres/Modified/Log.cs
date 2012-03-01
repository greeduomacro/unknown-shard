using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseLog : Item, ICommodity
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
				return String.Format( Amount == 1 ? "{0} Log" : "{0} Logs", Amount );
			}
		}
		
		public abstract BaseLog GetLogs();

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

		public BaseLog( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseLog( CraftResource resource, int amount ) : base( 0x1BDD )
		{
			Stackable = true;
			Weight = 3.0;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );			
			m_Resource = resource;
		}

		public BaseLog( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1027134 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1027133 ); // log
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

	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class Log : BaseLog
	{
		[Constructable]
		public Log() : this( 1 )
		{
		}

		[Constructable]
		public Log( int amount ) : base( CraftResource.Log, amount )
		{
		}

		public Log( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new Log();
        	}
        }


	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class PineLog : BaseLog
	{
		[Constructable]
		public PineLog() : this( 1 )
		{
		}

		[Constructable]
		public PineLog( int amount ) : base( CraftResource.Pine, amount )
		{
		}

		public PineLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new PineLog();
        	}

	}

	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class CedarLog : BaseLog
	{
		[Constructable]
		public CedarLog() : this( 1 )
		{
		}

		[Constructable]
		public CedarLog( int amount ) : base( CraftResource.Cedar, amount )
		{
		}

		public CedarLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new CedarLog();
        	}

	}

	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class CherryLog : BaseLog
	{
		[Constructable]
		public CherryLog() : this( 1 )
		{
		}

		[Constructable]
		public CherryLog( int amount ) : base( CraftResource.Cherry, amount )
		{
		}

		public CherryLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new CherryLog();
        	}

	}
	
	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class MahoganyLog : BaseLog
	{
		[Constructable]
		public MahoganyLog() : this( 1 )
		{
		}

		[Constructable]
		public MahoganyLog( int amount ) : base( CraftResource.Mahogany, amount )
		{
		}

		public MahoganyLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new MahoganyLog();
        	}

	}
	
	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class OakLog : BaseLog
	{
		[Constructable]
		public OakLog() : this( 1 )
		{
		}

		[Constructable]
		public OakLog( int amount ) : base( CraftResource.Oak, amount )
		{
		}

		public OakLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new OakLog();
        	}		
	}
	
	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class AshLog : BaseLog
	{
		[Constructable]
		public AshLog() : this( 1 )
		{
		}

		[Constructable]
		public AshLog( int amount ) : base( CraftResource.Ash, amount )
		{
		}

		public AshLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new AshLog();
        	}		
	}
	
	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class YewLog : BaseLog
	{
		[Constructable]
		public YewLog() : this( 1 )
		{
		}

		[Constructable]
		public YewLog( int amount ) : base( CraftResource.Yew, amount )
		{
		}

		public YewLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new YewLog();
        	}		
	}
	
	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class HeartwoodLog : BaseLog
	{
		[Constructable]
		public HeartwoodLog() : this( 1 )
		{
		}

		[Constructable]
		public HeartwoodLog( int amount ) : base( CraftResource.Heartwood, amount )
		{
		}

		public HeartwoodLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new HeartwoodLog();
        	}		
	}
	
	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class BloodwoodLog : BaseLog
	{
		[Constructable]
		public BloodwoodLog() : this( 1 )
		{
		}

		[Constructable]
		public BloodwoodLog( int amount ) : base( CraftResource.Bloodwood, amount )
		{
		}

		public BloodwoodLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        	{
            		return new BloodwoodLog();
        	}		
	}
	
	//[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class FrostwoodLog : BaseLog
	{
		[Constructable]
		public FrostwoodLog() : this( 1 )
		{
		}

		[Constructable]
		public FrostwoodLog( int amount ) : base( CraftResource.Frostwood, amount )
		{
		}

		public FrostwoodLog( Serial serial ) : base( serial )
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
		
		public override BaseLog GetLogs()
        		{
            		return new FrostwoodLog();
        		}		
	}
}
