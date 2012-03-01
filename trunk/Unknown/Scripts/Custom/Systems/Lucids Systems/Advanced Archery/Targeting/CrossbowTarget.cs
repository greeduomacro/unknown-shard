using System;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using System.Collections;
using Server.Enums;
using Server.ACC.CM;
using Server.LucidNagual;


namespace Server.Targeting
{
	public class CrossbowTarget : Target
	{
		private BaseRanged it_Ranged;
		
		public CrossbowTarget( BaseRanged ranged ) : base( 1, false, TargetFlags.None )
		{
			it_Ranged = ranged;
		}
		
		protected override void OnTarget( Mobile from, object targeted )
		{
			Console.WriteLine( "Code making it to OnTarget." );
			BaseRanged rang = it_Ranged as BaseRanged;
			BaseRangedModule module = rang.BaseRangedModule;
			
			if ( targeted is Item && targeted is Bolt )
			{
				Console.WriteLine( "Code making it to bolt check." );
				Item item = ( Item )targeted;
				
				string errorMsg = "You cannot arm a crossbow that does not have a string.";
				
				if ( !module.HasBowString )
				{
					from.SendMessage( "{0}", errorMsg );
					return;
				}
				
				if ( item.GetType() == typeof( Bolt ) )
				{
					module.BoltSelection = BoltType.Normal;
					rang.InvalidateProperties();
				}
				
				if ( item.GetType() == typeof( PoisonBolt ) )
				{
					module.BoltSelection = BoltType.Poison;
					rang.InvalidateProperties();
				}	
				
				if ( item.GetType() == typeof( ExplosiveBolt ) )
				{
					module.BoltSelection = BoltType.Explosive;
					rang.InvalidateProperties();
				}		
				
				if ( item.GetType() == typeof( ArmorPiercingBolt ) )
				{
					module.BoltSelection = BoltType.ArmorPiercing;
					rang.InvalidateProperties();
				}		
				
				if ( item.GetType() == typeof( FreezeBolt ) )
				{
					module.BoltSelection = BoltType.Freeze;
					rang.InvalidateProperties();
				}	
				
				if ( item.GetType() == typeof( LightningBolt ) )
				{
					module.BoltSelection = BoltType.Lightning;
					rang.InvalidateProperties();
				}					
			}
			else
			{
				from.SendMessage( "You can only target a bolt." );
			}
		}
	}
}
