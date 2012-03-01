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
	public class BowTarget : Target
	{
		private BaseRanged it_Ranged;
		
		public BowTarget( BaseRanged ranged ) : base( 1, false, TargetFlags.None )
		{
			it_Ranged = ranged;
		}
		
		protected override void OnTarget( Mobile from, object targeted )
		{
			Console.WriteLine( "Code making it to OnTarget." );
			BaseRanged rang = it_Ranged as BaseRanged;
			BaseRangedModule module = rang.BaseRangedModule;
			
			if ( targeted is Item && targeted is Arrow )
			{
				Console.WriteLine( "Code making it to arrow check." );
				Item item = ( Item )targeted;
				
				string errorMsg = "You cannot arm a bow that does not have a string.";
				
				if ( !module.HasBowString )
				{
					from.SendMessage( "{0}", errorMsg );
					return;
				}
				
				if ( item.GetType() == typeof( Arrow ) )
				{
					module.ArrowSelection = ArrowType.Normal;
					rang.InvalidateProperties();
				}
				
				if ( item.GetType() == typeof( PoisonArrow ) )
				{
					module.ArrowSelection = ArrowType.Poison;
					rang.InvalidateProperties();
				}
				
				if ( item.GetType() == typeof( ExplosiveArrow ) )
				{
					module.ArrowSelection = ArrowType.Explosive;
					rang.InvalidateProperties();
				}
				
				if ( item.GetType() == typeof( ArmorPiercingArrow ) )
				{
					module.ArrowSelection = ArrowType.ArmorPiercing;
					rang.InvalidateProperties();
				}
				
				if ( item.GetType() == typeof( FreezeArrow ) )
				{
					module.ArrowSelection = ArrowType.Freeze;
					rang.InvalidateProperties();
				}
				
				if ( item.GetType() == typeof( LightningArrow ) )
				{
					module.ArrowSelection = ArrowType.Lightning;
					rang.InvalidateProperties();
				}
			}
			else
			{
				from.SendMessage( "You can only target an arrow." );
			}
		}
	}
}
