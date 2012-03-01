/*
    _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2006 /
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
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Targeting;
using System.Collections;
using Server.Enums;
using Server.ACC.CM;
using Server.LucidNagual;


namespace Server.Items
{
	public abstract class BaseRanged : BaseMeleeWeapon
	{
		//--<<Advanced Archery Edit>>---------------------[Start 1/4]
		//SkillModule edit.
		private BaseRangedModule m_BaseRangedModule;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public BaseRangedModule BaseRangedModule
		{
			get
			{
				BaseRangedModule existingModule = ( BaseRangedModule )CentralMemory.GetModule( this.Serial, typeof( BaseRangedModule ) );
				
				if ( existingModule == null )
				{
					BaseRangedModule module = new BaseRangedModule( this.Serial );
					CentralMemory.AppendModule( this.Serial, module, true );
					
					return ( m_BaseRangedModule = module as BaseRangedModule );
				}
				else
				{
					if ( m_BaseRangedModule != null )
						return m_BaseRangedModule;
					
					return ( m_BaseRangedModule = existingModule as BaseRangedModule );
				}
			}
		}
		//SkillModule edit.
		
		public static int PlayerFreezeTimer = 2; 
		public static int NPCFreezeTimer = 2; 		
		
		private bool m_IsLevelable;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public ArrowType ArrowSelection	{ get { return m_BaseRangedModule.ArrowSelection; } set { m_BaseRangedModule.ArrowSelection = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public BoltType BoltSelection { get { return m_BaseRangedModule.BoltSelection; } set { m_BaseRangedModule.BoltSelection = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public StringStrength StringStrengthSelection { get { return m_BaseRangedModule.StringStrengthSelection; } set { m_BaseRangedModule.StringStrengthSelection = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public PoundsPerPull PullWeightSelection { get { return m_BaseRangedModule.PullWeightSelection; } set { m_BaseRangedModule.PullWeightSelection = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool HasBowString { get{ return m_BaseRangedModule.HasBowString; } set{ m_BaseRangedModule.HasBowString = value; } }		
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsLevelable { get{ return m_IsLevelable; } set{ m_IsLevelable = value; } }		
				
		
		private static Mobile m_Mobile;
		private static BaseRanged BRanged;
		
		public static TimeSpan StringWarningDelay = TimeSpan.FromSeconds( 10.0 );
		public static DateTime m_NextStringWarning;
		public static TimeSpan AmmoWarningDelay = TimeSpan.FromSeconds( 10.0 );
		public static DateTime m_NextAmmoWarning;
		//--<<Advanced Archery Edit>>---------------------[End 1/4]
		
		public abstract int EffectID{ get; }
		public abstract Type AmmoType{ get; }
		public abstract Item Ammo{ get; }
		
		public override int DefHitSound{ get{ return 0x234; } }
		public override int DefMissSound{ get{ return 0x238; } }
		
		public override SkillName DefSkill{ get{ return SkillName.Archery; } }
		public override WeaponType DefType{ get{ return WeaponType.Ranged; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootXBow; } }
		
		public override SkillName AccuracySkill{ get{ return SkillName.Archery; } }
		
		public BaseRanged( int itemID ) : base( itemID )
		{
		}
		
		public BaseRanged( Serial serial ) : base( serial )
		{
			BRanged = this;
		}
		
		public static void Initialize()
		{
			Mobile from = m_Mobile;
			//Mobile m = (Mobile)parent;
			//BaseWeapon weapon = m.Weapon as BaseWeapon;
		}
		
		public override TimeSpan OnSwing( Mobile attacker, Mobile defender )
		{
			WeaponAbility a = WeaponAbility.GetCurrentAbility( attacker );
			
			// Make sure we've been standing still for .25/.5/1 second depending on Era
			if ( DateTime.Now > ( attacker.LastMoveTime + TimeSpan.FromSeconds( Core.SE ? 0.25 : (Core.AOS ? 0.5 : 1.0) )) || (Core.AOS && WeaponAbility.GetCurrentAbility( attacker ) is MovingShot) )
			{
				bool canSwing = true;
				
				if ( Core.AOS )
				{
					canSwing = ( !attacker.Paralyzed && !attacker.Frozen );
					
					if ( canSwing )
					{
						Spell sp = attacker.Spell as Spell;
						
						canSwing = ( sp == null || !sp.IsCasting || !sp.BlocksMovement );
					}
				}
				
				if ( canSwing && attacker.HarmfulCheck( defender ) )
				{
					attacker.DisruptiveAction();
					attacker.Send( new Swing( 0, attacker, defender ) );
					
					if ( OnFired( attacker, defender ) )
					{
						if ( CheckHit( attacker, defender ) )
							OnHit( attacker, defender );
						else
							OnMiss( attacker, defender );
					}
				}
				
				attacker.RevealingAction();
				
				return GetDelay( attacker );
			}
			else
			{
				attacker.RevealingAction();
				
				return TimeSpan.FromSeconds( 0.25 );
			}
		}
		
		public override void OnHit( Mobile attacker, Mobile defender )
		{
			//--<<Advanced Archery Edit>>---------------------[Start 2/4]
			if ( attacker == null || defender == null )
				return;
			
			MoreBaseRanged.CustomAmmoCheck( attacker, defender, AmmoType );
			
			if ( Ammo == null )
				attacker.SendMessage( "You are out of arrows, or may have to choose a different type of arrow by double clicking the bow." );
			//--<<Advanced Archery Edit>>---------------------[End 2/4]
			
			if ( attacker.Player && !defender.Player && ( defender.Body.IsAnimal || defender.Body.IsMonster ) && 0.4 >= Utility.RandomDouble() )
				defender.AddToBackpack( Ammo );
			
			base.OnHit( attacker, defender );
		}
		
		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			if ( attacker.Player && 0.4 >= Utility.RandomDouble() )
				Ammo.MoveToWorld( new Point3D( defender.X + Utility.RandomMinMax( -1, 1 ), defender.Y + Utility.RandomMinMax( -1, 1 ), defender.Z ), defender.Map );
			
			base.OnMiss( attacker, defender );
		}
		
		public virtual bool OnFired( Mobile attacker, Mobile defender )
		{
			//--<<Advanced Archery Edit>>---------------------[Start 3/4]
			PlayerMobile a_pm = attacker as PlayerMobile;
			Container pack = attacker.Backpack;
			BaseQuiver quiver = attacker.FindItemOnLayer( Layer.MiddleTorso ) as BaseQuiver;
			BaseRangedModule module = this.BaseRangedModule;

			if ( !module.HasBowString )
			{
				if ( DateTime.Now >= m_NextStringWarning )
				{
					m_NextStringWarning = DateTime.Now + StringWarningDelay;
					attacker.SendMessage( "You need a string to use this bow. See a local fletcher to apply the string." );
					return false;
				}
				else
					return false;
			}
			
			if ( Ammo == null )
			{
				if ( DateTime.Now >= m_NextAmmoWarning )
				{
					m_NextAmmoWarning = DateTime.Now + AmmoWarningDelay;
					attacker.SendMessage( "You are out of ammo." );
					return false;
				}
				else
					return false;
			}
			
			if( attacker.Player && quiver != null && quiver.LowerAmmoCost > Utility.Random( 100 ) )
			{
				attacker.MovingEffect( defender, EffectID, 18, 1, false, false );
				return true;
			}
			
			if( attacker.Player &&
			   ( quiver == null || !quiver.ConsumeTotal( AmmoType, 1 ) ) &&
			   (   pack == null ||   !pack.ConsumeTotal( AmmoType, 1 ) ) )
				return false;
			
			attacker.MovingEffect( defender, EffectID, 18, 1, false, false );
			return true;
			//--<<Advanced Archery Edit>>---------------------[End 3/4]
		}
		
		//--<<Advanced Archery Edit>>---------------------[Start 4/4]
		public override void OnDoubleClick( Mobile from )
		{
			BaseRangedModule module = this.BaseRangedModule;
			
			if ( IsChildOf( from.Backpack ) || Parent == from )
			{
				if ( module.HasBowString )
				{
					if ( this is Bow || this is CompositeBow || this is ElvenCompositeLongbow ||
					    this is MagicalShortbow || this is Yumi )
					{
						from.SendMessage( "Please choose which type of arrows you wish to use." );
						from.Target = new BowTarget( this );
					}
					
					if ( this is Crossbow || this is HeavyCrossbow || this is RepeatingCrossbow )
					{
						from.SendMessage( "Please choose which type of bolts you wish to use." );
						from.Target = new CrossbowTarget( this );
					}
				}
				else
				{
					from.SendMessage( "You must string your bow. Please select a bow stringer." );
					from.Target = new StringerTarget( this );
				}
			}
			
			else
				return;
		}
		
		/*public override void OnDelete()
		{
			BaseRangedModule module = this.BaseRangedModule;
			
			if ( module != null )
				module.Delete();
			
			base.OnDelete();
		}*/
		
		public override bool OnEquip( Mobile from )
		{
			m_Mobile = from;
			
			return true;
		}
		
		public override bool CanEquip( Mobile from )
		{
			BaseRangedModule module = this.BaseRangedModule;

			if ( from != null && !module.HasBowString )
			{
				from.SendMessage( "You cannot use that without a string." );
				return false;
			}
			
			base.CanEquip( from );
			
			return true;
		}
		
		public virtual Item AmmoArrowSelected()
		{
			BaseRangedModule module = this.BaseRangedModule;
			
			switch ( module.m_ArrowType )
			{
				case ArrowType.Normal:
					return new Arrow();
				case ArrowType.Poison:
					return new PoisonArrow();
				case ArrowType.Explosive:
					return new ExplosiveArrow();
				case ArrowType.ArmorPiercing:
					return new ArmorPiercingArrow();
				case ArrowType.Freeze:
					return new FreezeArrow();
				case ArrowType.Lightning:
					return new LightningArrow();
					
				default:
					return new Arrow();
			}
		}
		
		public virtual Type GetArrowSelected()
		{
			BaseRangedModule module = this.BaseRangedModule;
			
			switch ( module.m_ArrowType )
			{
				case ArrowType.Normal:
					return typeof( Arrow );
				case ArrowType.Poison:
					return typeof( PoisonArrow );
				case ArrowType.Explosive:
					return typeof( ExplosiveArrow );
				case ArrowType.ArmorPiercing:
					return typeof( ArmorPiercingArrow );
				case ArrowType.Freeze:
					return typeof( FreezeArrow );
				case ArrowType.Lightning:
					return typeof( LightningArrow );
					
				default:
					return typeof( Arrow );
			}
		}
		
		public virtual Item AmmoBoltSelected()
		{
			BaseRangedModule module = this.BaseRangedModule;
			
			switch ( module.m_BoltType )
			{
				case BoltType.Normal:
					return new Bolt();
				case BoltType.Poison:
					return new PoisonBolt();
				case BoltType.Explosive:
					return new ExplosiveBolt();
				case BoltType.ArmorPiercing:
					return new ArmorPiercingBolt();
				case BoltType.Freeze:
					return new FreezeBolt();
				case BoltType.Lightning:
					return new LightningBolt();
					
				default:
					return new Bolt();
			}
		}
		
		public virtual Type GetBoltSelected()
		{
			BaseRangedModule module = this.BaseRangedModule;
			
			switch ( module.m_BoltType )
			{
				case BoltType.Normal:
					return typeof( Bolt );
				case BoltType.Poison:
					return typeof( PoisonBolt );
				case BoltType.Explosive:
					return typeof( ExplosiveBolt );
				case BoltType.ArmorPiercing:
					return typeof( ArmorPiercingBolt );
				case BoltType.Freeze:
					return typeof( FreezeBolt );
				case BoltType.Lightning:
					return typeof( LightningBolt );
					
				default:
					return typeof( Bolt );
			}
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties(list);
			
			BaseRangedModule module = this.BaseRangedModule;
			
			if ( module != null )
			{
				ArrayList strings = new ArrayList();
				
				strings.Add( ( "---------------" ) );
				
				if ( this is Bow || this is CompositeBow || this is ElvenCompositeLongbow ||
				    this is MagicalShortbow || this is Yumi )
				{
					strings.Add( ( "Quiver Using: " + module.m_ArrowType ) );
				}
				
				if ( this is Crossbow || this is HeavyCrossbow || this is RepeatingCrossbow )
				{
					strings.Add( ( "Quiver Using: " + module.m_BoltType ) );
				}
				
				strings.Add( ( "lbs per Pull: " + module.m_PullWeight ) );
				strings.Add( ( "String Str: "  + module.m_Strength ) );
				
				string toAdd = "";
				int amount = strings.Count;
				int current = 1;
				
				foreach ( string str in strings )
				{
					toAdd += str;
					
					if ( current != amount )
						toAdd += "\n";
					
					++current;
				}
				
				if ( toAdd != "" )
					list.Add( 1070722, toAdd );
			}
			else
			{
				return;
			}
		}
		//--<<Advanced Archery Edit>>---------------------[End 4/4]
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 2 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 2:
				case 1:
					{
						break;
					}
				case 0:
					{
						/*m_EffectID =*/ reader.ReadInt();
						break;
					}
			}
			
			if ( version < 2 )
			{
				WeaponAttributes.MageWeapon = 0;
				WeaponAttributes.UseBestSkill = 0;
			}
		}
	}
}
