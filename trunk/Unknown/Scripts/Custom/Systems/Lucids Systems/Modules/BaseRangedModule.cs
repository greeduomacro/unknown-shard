/*[ Lucid Nagual ]--------------------------------------------[ ...:||[ 2007 ]||:.. ]

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
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Commands;
using Server.Enums;
//using Server.Saves;


namespace Server.ACC.CM
{
	public class BaseRangedModule : Module
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GetRanged", AccessLevel.GameMaster, new CommandEventHandler( GetRanged ) );
			//CommandSystem.Register( "MyBOD", AccessLevel.Player, new CommandEventHandler( MyBOD_OnCommand ) );
		}
		
		public override string Name(){ return "BaseRanged Module"; }
		
		public bool m_HasBowString = false;
		
		public Serial m_Serial;
		public BaseRanged m_Ranged;
		
		public BoltType m_BoltType;
		public ArrowType m_ArrowType;
		public StringStrength m_Strength;
		public PoundsPerPull m_PullWeight;
		
		public Serial WeaponSerial { get { return m_Serial; } }
		public BaseRanged RangedWeapon { get { return m_Ranged; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool HasBowString { get{ return m_HasBowString; } set{ m_HasBowString = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public ArrowType ArrowSelection	{ get { return m_ArrowType; } set { m_ArrowType = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public BoltType BoltSelection { get { return m_BoltType; } set { m_BoltType = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public StringStrength StringStrengthSelection { get { return m_Strength; } set { m_Strength = value; } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public PoundsPerPull PullWeightSelection { get { return m_PullWeight; } set { m_PullWeight = value; } }
		
		public BaseRangedModule( Serial serial  ) : base( serial )
		{
			HasBowString = true;
			StringStrengthSelection = StringStrength.VeryWeak;
			PullWeightSelection = PoundsPerPull.Fourty;
		}
		
		private static void GetRanged( CommandEventArgs e )
		{
			BaseRangedModule module = ( BaseRangedModule )CentralMemory.GetModule( e.Mobile.Serial, typeof( BaseRangedModule ) );
			
			if ( module != null || module.m_Ranged != null )
				e.Mobile.Target = new InternalTarget( module, module.m_Ranged );
			
			else
				e.Mobile.SendMessage( "The module or module ranged info does not exist." );
		}
		
		/*		private static void MyBOD_OnCommand( CommandEventArgs e )
		{
			BaseRangedModule bod_mod = ( BaseRangedModule )CentralMemory.GetModule( e.Mobile.Serial, typeof( BaseRangedModule ) );
			
			if( bod_mod == null )
			{
				CentralMemory.AppendModule( e.Mobile.Serial, new BaseRangedModule( e.Mobile.Serial ), true );
				e.Mobile.SendMessage( "Please try again" );
			}
			else
			{
				//Next BOD times.
				e.Mobile.SendMessage( "Time til next smithy BOD:    {0}", bod_mod.m_NextSmithBulkOrder );
				e.Mobile.SendMessage( "Time til next tailor BOD:    {0}", bod_mod.m_NextTailorBulkOrder );
				e.Mobile.SendMessage( "Time til next carpenter BOD: {0}", bod_mod.m_NextCarpenterBulkOrder );
				e.Mobile.SendMessage( "Time til next fletcher BOD:  {0}", bod_mod.m_NextFletcherBulkOrder );
				e.Mobile.SendMessage( "Time til next taming BOD:    {0}", bod_mod.m_NextTamingBulkOrder );
				e.Mobile.SendMessage( "Time til next tinker BOD:    {0}", bod_mod.m_NextTinkerBulkOrder );
				return;
			}
		}*/
		
		/*		public void InvalidateRangedWeapons()
		{
			if( RangedWeapon != null )
				RangedWeapon.InvalidateProperties();
		}*/
		
		public override void Append( Module mod, bool negatively )
		{
		}
		
		//System.Diagnostics.Process.Start("iexplorer.exe");
		
		
		private class InternalTarget : Target
		{
			private BaseRangedModule br_mod;
			private BaseRanged m_Ranged;
			
			public InternalTarget( BaseRangedModule mod, BaseRanged ranged ) : base( 1, false, TargetFlags.None )
			{
				br_mod = mod;
				m_Ranged = ranged;
			}
			
			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is PlayerMobile )
				{
					PlayerMobile pm = ( PlayerMobile )targeted;
					BaseRangedModule module = ( BaseRangedModule )CentralMemory.GetModule( m_Ranged.Serial, typeof( BaseRangedModule ) );
					
					if ( module != null )
						from.SendGump( new PropertiesGump( from, module ) );
					else
					{
						from.SendMessage( "This player does not have a module. A new one has been created." );
						CentralMemory.AppendModule( m_Ranged.Serial, new BaseRangedModule( m_Ranged.Serial ), true );
					}
				}
				else
					from.SendMessage("Can Only Target PLAYERS!");
			}
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
			
			//--<< Version 2 >>---------------------------//
			/*			writer.Write( ( int )DefaultMaxLevel );
			writer.Write( ( int )MaxLevelsCap );
			writer.Write( ( bool )EnableExpCap );
			writer.Write( ( bool )DisplayExpProp );
			writer.Write( ( int )PointsPerLevel );
			writer.Write( ( bool )DoubleArtifactCost );
			writer.Write( ( bool )BlacksmithOnly );
			writer.Write( ( double )BlacksmithSkillRequired );
			writer.Write( ( bool )RewardBlacksmith );
			writer.Write( ( int )BlacksmithRewardAmt );
			writer.Write( ( int )m_Experience );
			writer.Write( ( int )m_Level );
			writer.Write( ( int )m_Points );
			writer.Write( ( int )m_MaxLevel );*/
			//--<< Version 2 >>---------------------------//
			
			//--<< Version 1 >>---------------------------//
			writer.Write( m_Serial );
			writer.Write( m_Ranged );
			//--<< Version 1 >>---------------------------//
			
			//--<< Version 0 >>---------------------------//
			writer.Write( ( bool )m_HasBowString );
			writer.WriteEncodedInt(( int )m_Strength );
			writer.WriteEncodedInt(( int )m_PullWeight );
			writer.WriteEncodedInt(( int )m_ArrowType );
			writer.WriteEncodedInt(( int )m_BoltType );
			//--<< Version 0 >>---------------------------//
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch ( version )
			{
					/*	case 2:
					{
						DefaultMaxLevel = reader.ReadInt();
						MaxLevelsCap = reader.ReadInt();
						EnableExpCap = reader.ReadBool();
						DisplayExpProp = reader.ReadBool();
						PointsPerLevel = reader.ReadInt();
						DoubleArtifactCost = reader.ReadBool();
						BlacksmithOnly = reader.ReadBool();
						BlacksmithSkillRequired = reader.ReadDouble();
						RewardBlacksmith = reader.ReadBool();
						BlacksmithRewardAmt = reader.ReadInt();
						m_Experience = reader.ReadInt();
						m_Level = reader.ReadInt();
						m_Points = reader.ReadInt();
						m_MaxLevel = reader.ReadInt();
						goto case 1;
					}*/
				case 1:
					{
						m_Serial = reader.ReadInt();
						m_Ranged = reader.ReadItem() as BaseRanged;
						goto case 0;
					}
				case 0:
					{
						m_HasBowString = reader.ReadBool();
						m_Strength = ( StringStrength )reader.ReadEncodedInt();
						m_PullWeight = ( PoundsPerPull )reader.ReadEncodedInt();
						m_ArrowType = ( ArrowType )reader.ReadEncodedInt();
						m_BoltType = ( BoltType )reader.ReadEncodedInt();
						break;
					}
			}
		}
	}
}


