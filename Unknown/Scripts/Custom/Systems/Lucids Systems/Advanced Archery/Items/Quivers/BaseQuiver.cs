/*  _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2005 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \     lucidnagual@gmail.com     \
    \_     ===================      \
     \   -Admin of "The Conjuring"-  \
      \_     ===================     ~\
       )       Ultimate Quiver         )
      /~      Version [1].0.0        _/
    _/_______________________________/
 -=(_)_______________________________)=-
 */
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Engines.Craft;


namespace Server.Items
{
	public class BaseQuiver : BaseContainer, IDyable, ICraftable
	{
		public override int DefaultGumpID{ get{ return 65; } }
		public override int DefaultDropSound{ get{ return 0x48; } }
		public override int MaxWeight{ get{ return 250; } }
		public override int DefaultMaxWeight{ get{ return 250; } }
		
		private int m_LowerAmmoCost;
		private Mobile m_Owner;
		private AosAttributes m_AosAttributes;
		private AosSkillBonuses m_AosSkillBonuses;
		private Mobile m_Crafter;
		
		internal TotalType m_type;
		internal int m_delta;
		internal bool m_ContainsBow = false;
		internal double ReducedPercentage = 0.7;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public AosAttributes Attributes	{ get{ return m_AosAttributes; } set{} }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public AosSkillBonuses SkillBonuses	{ get{ return m_AosSkillBonuses; } set{} }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Crafter {	get{ return m_Crafter; } set{ m_Crafter = value;
				InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int LowerAmmoCost { get{ return m_LowerAmmoCost; } set{ m_LowerAmmoCost = value;
				InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool ContainsBow { get{ return m_ContainsBow; } set{ m_ContainsBow = value;
				InvalidateProperties(); } }
		
		public BaseQuiver( int itemID ) : base( itemID )
		{
			Name = "Quiver";
			Weight = 0.0;
			Layer = Layer.MiddleTorso;
			m_AosAttributes = new AosAttributes( this );
			m_AosSkillBonuses = new AosSkillBonuses( this );
		}
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			return base.OnDragDrop( from, dropped );
			
			if ( from == null || dropped == null )
				return false;
			
			if ( dropped is BaseRanged && !m_ContainsBow )
			{
				m_ContainsBow = true;
				from.SendSound( GetDroppedSound( dropped ), GetWorldLocation() );
				
				DropItem( dropped );
				UpdateTotal( dropped, m_type, 0 );
			}
			else if ( dropped is BaseRanged && m_ContainsBow )
			{
				from.SendMessage( "The quiver can only hold one bow!" );
				return false;
			}
			else if ( dropped is Arrow || dropped is Bolt )
			{
				from.SendSound( GetDroppedSound( dropped ), GetWorldLocation() );
				
				DropItem( dropped );
				UpdateTotal( dropped, m_type, 0 );
			}
			else if ( dropped is BaseTub )
			{
				from.SendSound( GetDroppedSound( dropped ), GetWorldLocation() );
				
				DropItem( dropped );
				UpdateTotal( dropped, m_type, 0 );
			}
			else
			{
				from.SendMessage( "That is not an arrow, bolt, bow, or dip tub!" );
				return false;
			}
		}
		
		public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
		{
				return base.OnDragDropInto( from, item, p );
			
			if ( from == null || item == null )
				return false;
			
			if ( item is BaseRanged && !m_ContainsBow )
			{
				m_ContainsBow = true;
				from.SendSound( GetDroppedSound( item ), GetWorldLocation() );
				
				DropItem( item );
				UpdateTotal( item, m_type, 0 );
			}
			else if ( item is BaseRanged && m_ContainsBow )
			{
				from.SendMessage( "The quiver can only hold one bow!" );
				return false;
			}
			else if ( item is Arrow || item is Bolt )
			{
				from.SendSound( GetDroppedSound( item ), GetWorldLocation() );
				
				DropItem( item );
				UpdateTotal( item, m_type, 0 );
			}
			else if ( item is BaseTub )
			{
				from.SendSound( GetDroppedSound( item ), GetWorldLocation() );
				
				DropItem( item );
				UpdateTotal( item, m_type, 0 );
			}
			else
			{
				from.SendMessage( "That is not an arrow, bolt, bow, or dip tub!" );
				return false;
			}
		}
		
		public override bool TryDropItem( Mobile from, Item dropped, bool sendFullMessage )
		{
				return base.TryDropItem( from, dropped, sendFullMessage );
			
			if ( from == null || dropped == null )
				return false;
			
			if ( dropped is BaseRanged && !m_ContainsBow )
			{
				m_ContainsBow = true;
				from.SendSound( GetDroppedSound( dropped ), GetWorldLocation() );
				
				DropItem( dropped );
				UpdateTotal( dropped, m_type, 0 );
			}
			else if ( dropped is BaseRanged && m_ContainsBow )
			{
				from.SendMessage( "The quiver can only hold one bow!" );
				return false;
			}
			else if ( dropped is Arrow || dropped is Bolt )
			{
				from.SendSound( GetDroppedSound( dropped ), GetWorldLocation() );
				
				DropItem( dropped );
				UpdateTotal( dropped, m_type, 0 );
			}
			else if ( dropped is BaseTub )
			{
				from.SendSound( GetDroppedSound( dropped ), GetWorldLocation() );
				
				DropItem( dropped );
				UpdateTotal( dropped, m_type, 0 );
			}
			else
			{
				from.SendMessage( "That is not an arrow, bolt, bow, or dip tub!" );
				return false;
			}
		}
		
		public override void OnItemRemoved( Item item )
		{
			base.OnItemRemoved( item );
			
			if ( item == null ) { return; }
			
			if ( item is BaseRanged )
				m_ContainsBow = false;
			
			UpdateTotals();
		}
		
		public override void UpdateTotal( Item sender, TotalType type, int delta )
		{
			base.UpdateTotal( sender, type, delta );
			
			if( type == TotalType.Weight )
			{
				if ( Parent is Item )
					( Parent as Item ).UpdateTotal( sender, type, ( int )( delta * ReducedPercentage ) ); //* -1 );
				
				else if ( Parent is Mobile )
					( Parent as Mobile ).UpdateTotal( sender, type, ( int )( delta * ReducedPercentage ) ); //* -1 );
			}
		}
		
		public override int GetTotal( TotalType type )
		{
			return base.GetTotal( type );
			
			if( type == TotalType.Weight )
				return ( int )( base.GetTotal( type )*( ReducedPercentage ));
		}
		
		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;
			
			Hue = sender.DyedHue;
			
			return true;
		}
		
		public override bool OnEquip( Mobile from )
		{
			return base.OnEquip( from );
			
			if ( Core.AOS )
				m_AosSkillBonuses.AddTo( from );
		}
		
		public override void OnRemoved( object parent )
		{
			if ( Core.AOS )
				m_AosSkillBonuses.Remove();
			
			return;
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			m_AosSkillBonuses.GetProperties( list );
			int prop;
			
			if ( m_Crafter != null )
				list.Add( 1050043, m_Crafter.Name ); // crafted by ~1_NAME~
			
			if ( (prop = m_AosAttributes.DefendChance) != 0 )
				list.Add( 1060408, prop.ToString() ); //Defend Chance ~1_val~%
			
			if ( (prop = m_AosAttributes.WeaponDamage) != 0 )
				list.Add( 1060401, prop.ToString() ); //Weapon Damage ~1_val~
			
			if ( (prop = LowerAmmoCost) != 0 )
				list.Add( 1075208, prop.ToString() ); //Lower Ammo Cost ~1_PERCENTAGE~%
			
			if ( (prop = ( int )ReducedPercentage) != 0 )
				list.Add( 1072210, prop.ToString() ); //Weight reduction ~1_PERCENTAGE~%
			
			//Notation: 1060847 Custom String
		}
		
		public override void OnSingleClick( Mobile from )
		{
			this.LabelTo( from, Name );
		}
		
		public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			this.Hue = resHue;
			
			int skillfletch = (int)(from.Skills.Fletching.Value);
			int skilltailor = (int)(from.Skills.Tailoring.Value);
			int skillarch = (int)(from.Skills.Archery.Value);
			
			int skillave = (int)((skillfletch +skilltailor + skillarch) / 3);
			
			if ( skillave >= 100)
			{
				this.Crafter = from;
				
				int tempval = (int)(((skillave) /10) +1);
				if (tempval >= 20) tempval = 20;
				Attributes.WeaponDamage = Utility.RandomMinMax( 0, tempval );
				tempval = (int)(tempval /2);
				Attributes.DefendChance = Utility.RandomMinMax( 0, tempval );
				
				tempval = (int)(((skillfletch * 2) /10) +1);
				if (tempval >= 40) tempval = 40;
				LowerAmmoCost = Utility.RandomMinMax( tempval, (tempval * 2) );
				
				tempval = (int)(((skillarch - 80) /10) +1);
				if (tempval >= 10) tempval = 10;
				SkillBonuses.SetValues( 0, SkillName.Archery, (Utility.RandomMinMax( 0, tempval )) );
				
				tempval = (int)(((skilltailor - 80) /10) +1);
				if (tempval >= 10) tempval = 10;
				SkillBonuses.SetValues( 1, SkillName.Tactics, (Utility.RandomMinMax( 0, tempval )) );
			}
			return 1;
		}
		
		public BaseQuiver( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 2 ); // version
			
			writer.Write( ( bool ) m_ContainsBow ); //Version 2
			
			writer.Write( (int) m_LowerAmmoCost ); //Version 1
			
			writer.Write( m_Crafter );
			m_AosAttributes.Serialize( writer );
			m_AosSkillBonuses.Serialize( writer );
			writer.Write( (Mobile) m_Owner );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 2:
					{
						m_ContainsBow = reader.ReadBool();
						goto case 1;
					}
				case 1:
					{
						m_LowerAmmoCost = reader.ReadInt();
						goto case 0;
					}
				case 0:
					{
						m_Crafter = reader.ReadMobile();
						m_AosAttributes = new AosAttributes( this, reader );
						m_AosSkillBonuses = new AosSkillBonuses( this, reader );
						m_Owner = (Mobile) reader.ReadMobile();
						break;
					}
			}
		}
	}
}
