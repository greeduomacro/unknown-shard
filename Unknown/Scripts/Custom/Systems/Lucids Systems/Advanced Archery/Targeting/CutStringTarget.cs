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
	public class CutStringTarget : Target
	{
		public CutStringTarget( Mobile from ) : base( 1, false, TargetFlags.None )
		{
		}
		
		protected override void OnTarget( Mobile from, object targeted )
		{
			Console.WriteLine( "Code making it to OnTarget." );
			
			if ( targeted is Item && targeted is BaseRanged )
			{
				Console.WriteLine( "Code making it to BaseStringer check." );
				BaseRanged ranged = targeted as BaseRanged;
				BaseRangedModule module = ranged.BaseRangedModule;
				
				if ( module.HasBowString )
				{
					MoreBaseRanged.CutString( from, ranged );
				}
				else
					from.SendMessage( "This bow is not strung. Using scissors on it is a waste of time." );
			}
			else
			{
				from.SendMessage( "That is not a bow." );
			}
		}
	}
}
