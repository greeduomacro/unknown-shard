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
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.ACC.CM;
using Server.Enums;
using Server.LucidNagual;
using System.Collections;
//using Server.LevelSystem;


namespace Server.LucidNagual
{
	public class MoreBaseRanged
	{
		public static readonly TimeSpan PlayerFreezeDuration = TimeSpan.FromSeconds( BaseRanged.PlayerFreezeTimer );
		public static readonly TimeSpan NPCFreezeDuration = TimeSpan.FromSeconds( BaseRanged.NPCFreezeTimer );
		
		public static void CustomAmmoCheck( Mobile attacker, Mobile defender, Type AmmoType )
		{
			double archery = attacker.Skills[ SkillName.Archery ].Value;
			double dice = Utility.RandomDouble();
			
			//Poison ammo.
			if ( AmmoType == typeof( PoisonArrow ) || AmmoType == typeof( PoisonArrow ) )
			{
				if( archery >= 120 )
				{
					if ( 0.20 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 4 );

					if ( 0.40 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 3 );
					
					if ( 0.70 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 2 );
				}
				
				else if( archery >= 100 )
				{
					if ( 0.10 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 4 );

					if ( 0.30 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 3 );
					
					if ( 0.60 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 2 );
				}
				
				else if( archery >= 70 )
				{
					if ( 0.10 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 3 );
					
					if ( 0.30 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 2 );
					
					if ( 0.60 > Utility.RandomDouble() )
						DoPoisonEffect( defender, 1 );
				}
				
				else if( archery >= 50 )
				{
					switch ( Utility.Random( 2 ) )
					{
							case 0: DoPoisonEffect( defender, 2 ); break;
							case 1: DoPoisonEffect( defender, 1 ); break;
					}
				}
				
				if( archery < 50 )
					DoPoisonEffect( defender, 1 );
			}
			
			//Explosive ammo.
			if ( AmmoType == typeof( ExplosiveArrow ) || AmmoType == typeof( ExplosiveBolt ) )
			{
				if( archery >= 120 )
					DoExplosiveEffect( attacker, defender, 20, 80 );
				
				if( archery >= 60 )
					DoExplosiveEffect( attacker, defender, 10, 40 );
				
				if( attacker.Skills[SkillName.Archery].Value < 60 )
					DoExplosiveEffect( attacker, defender, 5, 20 );
			}
			
			//Piercing ammo.
			if ( AmmoType == typeof( ArmorPiercingArrow ) || AmmoType == typeof( ArmorPiercingBolt ) )
			{
				if( archery >= 120 )
					DoPiercingEffect( attacker, defender, 20, 80 );
				
				if( attacker.Skills[SkillName.Archery].Value >= 60 )
					DoPiercingEffect( attacker, defender, 10, 40 );
				
				if( attacker.Skills[SkillName.Archery].Value < 60 )
					DoPiercingEffect( attacker, defender, 5, 20 );
			}

			//Freeze ammo.
			if ( AmmoType == typeof( FreezeArrow ) || AmmoType == typeof( FreezeBolt ) )
			{
				if( archery >= 120 )
					DoFreezeEffect( attacker, defender, 20, 80 );
				
				if( archery >= 60 )
					DoFreezeEffect( attacker, defender, 10, 40 );
				
				if( archery < 60 )
					DoFreezeEffect( attacker, defender, 5, 20 );
			}

			//Lightning ammo.
			if ( AmmoType == typeof( LightningArrow ) || AmmoType == typeof( LightningBolt ) )
			{
				if( archery >= 120 )
					DoLightningEffect( attacker, defender, 20, 80 );
				
				if( archery >= 60 )
					DoLightningEffect( attacker, defender, 10, 40 );
				
				if( archery < 60 )
					DoLightningEffect( attacker, defender, 5, 20 );
			}
		}
		
		public static void DoPoisonEffect( Mobile defender, int code )
		{
			defender.FixedParticles( 0x3728, 200, 25, 69, EffectLayer.Waist );
			
			if ( code == 1 ) //Lesser.
				defender.ApplyPoison( defender, Poison.Lesser );
			
			if ( code == 2 ) //Regular.
				defender.ApplyPoison( defender, Poison.Regular );
			
			if ( code == 3 ) //Greater.
				defender.ApplyPoison( defender, Poison.Greater );
			
			if ( code == 4 ) //Deadly.
				defender.ApplyPoison( defender, Poison.Deadly );
		}
		
		public static void DoExplosiveEffect( Mobile attacker, Mobile defender, int min, int max )
		{
			defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Waist );
			defender.PlaySound( 0x307 );
			attacker.DoHarmful( defender );
			AOS.Damage( defender, attacker, Utility.RandomMinMax( min, max ), 0, 100, 0, 0, 0 );
		}
		
		public static void DoPiercingEffect( Mobile attacker, Mobile defender, int min, int max )
		{
			defender.FixedParticles( 0x3728, 200, 25, 9942, EffectLayer.Waist );
			defender.PlaySound( 0x56 );
			attacker.DoHarmful( defender );
			AOS.Damage( defender, attacker, Utility.RandomMinMax( min, max ), 100, 0, 0, 0, 0 );
		}
		
		public static void DoFreezeEffect( Mobile attacker, Mobile defender, int min, int max )
		{
			defender.PlaySound( 0x204 );
			defender.Freeze( defender.Player ? PlayerFreezeDuration : NPCFreezeDuration );
			defender.FixedEffect( 0x376A, 9, 32 );
			attacker.DoHarmful( defender );
			AOS.Damage( defender, attacker, Utility.RandomMinMax( min, max ), 0, 0, 100, 0, 0 );
		}
		
		public static void DoLightningEffect( Mobile attacker, Mobile defender, int min, int max )
		{
			defender.PlaySound( 1471 );
			defender.BoltEffect( 1153 );
			attacker.DoHarmful( defender );
			AOS.Damage( defender, attacker, Utility.RandomMinMax( min, max ), 0, 0, 0, 0, 100 );
		}
		
		public virtual void DoDamage( Mobile attacker, Mobile defender, int min, int max )
		{
			attacker.DoHarmful( defender );
			AOS.Damage( defender, attacker, Utility.RandomMinMax( min, max ), 100, 0, 0, 0, 0 );
		}
		
		public virtual bool CheckStringDamage( Mobile attacker, Mobile defender, BaseRanged ranged )
		{
			BaseRangedModule module = ranged.BaseRangedModule;

			if ( module.HasBowString )
			{
				if ( module.StringStrengthSelection == StringStrength.VeryWeak )
				{
					if ( .05 > Utility.Random( 100 ) )
					{
						BonusDamage( attacker, defender, ranged );
						return true;
					}
					if ( .10 > Utility.Random( 1000 ) ) //1 in a 100 chances of breaking.
					{
						module.HasBowString = false;
						module.StringStrengthSelection = StringStrength.NoString;
						attacker.SendMessage( "Your string just broke." );
					}
					return true;
				}
				else if ( module.StringStrengthSelection == StringStrength.Weak )
				{
					if ( .10 > Utility.Random( 100 ) )
					{
						BonusDamage( attacker, defender, ranged );
						return true;
					}
					if ( .09 > Utility.Random( 1000 ) ) //1 in a 110 chances of breaking.
					{
						module.HasBowString = false;
						module.StringStrengthSelection = StringStrength.NoString;
						attacker.SendMessage( "Your string just broke." );
					}
					return true;
				}
				else if ( module.StringStrengthSelection == StringStrength.Sturdy )
				{
					if ( .15 > Utility.Random( 100 ) )
					{
						BonusDamage( attacker, defender, ranged );
						return true;
					}
					if ( .08 > Utility.Random( 1000 ) ) //1 in a 125 chances of breaking.
					{
						module.HasBowString = false;
						module.StringStrengthSelection = StringStrength.NoString;
						attacker.SendMessage( "Your string just broke." );
					}
					return true;
				}
				else if ( module.StringStrengthSelection == StringStrength.Strong )
				{
					if ( .20 > Utility.Random( 100 ) )
					{
						BonusDamage( attacker, defender, ranged );
						return true;
					}
					if ( .05 > Utility.Random( 1000 ) ) //1 in a 200 chances of breaking.
					{
						module.HasBowString = false;
						module.StringStrengthSelection = StringStrength.NoString;
						attacker.SendMessage( "Your string just broke." );
					}
				}
				else if ( module.StringStrengthSelection == StringStrength.Dependable )
				{
					if ( .25 > Utility.Random( 100 ) )
					{
						BonusDamage( attacker, defender, ranged );
						return true;
					}
					if ( .03 > Utility.Random( 1000 ) ) //1 in a 333 chances of breaking.
					{
						module.HasBowString = false;
						module.StringStrengthSelection = StringStrength.NoString;
						attacker.SendMessage( "Your string just broke." );
					}
					return true;
				}
				else if ( module.StringStrengthSelection == StringStrength.Indestructable )
				{
					if ( .33 > Utility.Random( 100 ) )
					{
						BonusDamage( attacker, defender, ranged );
						return true;
					}
					//No chance of breaking.
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
			
			return false;
		}
		
		public virtual bool BonusDamage( Mobile attacker, Mobile defender, BaseRanged ranged )
		{
			BaseRangedModule module = ranged.BaseRangedModule;

			attacker.SendMessage( "" );
			attacker.SendMessage( 0x35, "** Bonus Hit **" );
			attacker.SendMessage( "" );
			attacker.SendMessage( 0x35, "The strength of your bow and your immpecable skill have given you a perfect hit." );
			attacker.SendMessage( "" );
			
			defender.Say( "* Ouch, that hurt! *" );
			defender.PlaySound( 315 );
			
			if ( module.HasBowString )
			{
				if ( module.m_PullWeight == PoundsPerPull.Fourty )
				{
					attacker.DoHarmful( defender );
					AOS.Damage( defender, attacker, Utility.RandomMinMax( 2, 5 ), 100, 0, 0, 0, 0 );
					return true;
				}
				else if ( module.m_PullWeight == PoundsPerPull.Sixty )
				{
					attacker.DoHarmful( defender );
					AOS.Damage( defender, attacker, Utility.RandomMinMax( 6, 10 ), 100, 0, 0, 0, 0 );
					return true;
				}
				else if ( module.m_PullWeight == PoundsPerPull.Eighty )
				{
					attacker.DoHarmful( defender );
					AOS.Damage( defender, attacker, Utility.RandomMinMax( 11, 15 ), 100, 0, 0, 0, 0 );
					return true;
				}
				else if ( module.m_PullWeight == PoundsPerPull.Hundred )
				{
					attacker.DoHarmful( defender );
					AOS.Damage( defender, attacker, Utility.RandomMinMax( 16, 20 ), 100, 0, 0, 0, 0 );
					return true;
				}
				else
				{
					return false;
				}
			}
			else
				return true;
		}
		
		public virtual void CheckStringCondition( Mobile from, BaseRanged ranged )
		{
			BaseRangedModule module = ranged.BaseRangedModule;
			
			if ( module.HasBowString && module.StringStrengthSelection == StringStrength.NoString )
			{
				module.HasBowString = false;
			}
			
			if ( !module.HasBowString )
			{
				if ( module.StringStrengthSelection == StringStrength.NoString )
				{
					module.HasBowString = false;
					//from.SendMessage( "You need a string to use this bow. See a local fletcher to apply the string." );
				}
				else
				{
					module.StringStrengthSelection = StringStrength.NoString;
				}
			}
		}
		
		public static bool CheckForString( Mobile from, string errorMsg, BaseRanged ranged )
		{
			BaseRangedModule module = ranged.BaseRangedModule;

			if ( !module.HasBowString )
			{
				return true;
			}
			else
			{
				if ( module.HasBowString && module.StringStrengthSelection == StringStrength.NoString )
				{
					from.SendMessage( "" );
					from.SendMessage( 33, "--------------------" );
					from.SendMessage( "" );
					from.SendMessage( 33, "The bow has an internal error and is now being fixed..." );
					from.SendMessage( "" );
					from.SendMessage( 33, "--------------------" );
					from.SendMessage( "" );
					module.HasBowString = false;
					return true;
				}
				else
				{
					from.SendMessage( "{0}", errorMsg );
					return false;
				}
			}
		}
		
		public static void CutString( Mobile from, BaseRanged ranged )
		{
			BaseRangedModule module = ranged.BaseRangedModule;
			
			module.StringStrengthSelection = StringStrength.NoString;
			module.PullWeightSelection = PoundsPerPull.Zero;
			module.HasBowString = false;
			
			from.PlaySound( 0x248 );
			from.SendMessage( "You have just removed the string from your bow." );
			
			ranged.InvalidateProperties();
		}
		
		public virtual void CheckStringError( Mobile from, BaseRanged ranged )
		{
			BaseRangedModule module = ranged.BaseRangedModule;
			
			if ( module.HasBowString && module.StringStrengthSelection == StringStrength.NoString )
			{
				from.SendMessage( "The bow has an internal error. The bow is now being fixed..." );
				module.HasBowString = false;
			}
		}
	}
}


