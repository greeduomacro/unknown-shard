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
	public class StringerTarget : Target
	{
		private BaseRanged it_Ranged;
		
		public StringerTarget( BaseRanged ranged ) : base( 1, false, TargetFlags.None )
		{
			it_Ranged = ranged;
		}
		
		protected override void OnTarget( Mobile from, object targeted )
		{
			if ( LucidNagual.DataCenter.DebugAdvancedArchery )
				Console.WriteLine( "Code making it to OnTarget." );
			
			BaseRanged rang = it_Ranged as BaseRanged;
			BaseRangedModule module = rang.BaseRangedModule;
			
			if ( targeted is Item && targeted is BaseStringer )
			{
				if ( LucidNagual.DataCenter.DebugAdvancedArchery )
					Console.WriteLine( "Code making it to BaseStringer check." );
				
				Item item = ( Item )targeted;
				
				if ( item == null )
					from.SendMessage( "You have decided to not apply the string." );
				
				string errorMsg = "This bow already contains a string.";
				
				if ( MoreBaseRanged.CheckForString( from, errorMsg, rang ) == false )
					return;
				
				if ( LucidNagual.DataCenter.DebugAdvancedArchery )
					Console.WriteLine( "Code making it passed string check." );
				
				double fletching = from.Skills[ SkillName.Fletching ].Base;
				
				if ( fletching > 100 )
				{
					if ( LucidNagual.DataCenter.DebugAdvancedArchery )
						Console.WriteLine( "AA Check: Code making it passed gm fletching check." );
					
					if ( item.GetType() == typeof( LinenThreadStringer ) )
					{
						Conjunction( module, 1, 0 );
						CheckSkill( from, rang, module );
						module.HasBowString = true;
						item.Delete();
						rang.InvalidateProperties();
					}
					
					if ( item.GetType() == typeof( CottonStringer ) )
					{
						Conjunction( module, 2, 0 );
						CheckSkill( from, rang, module );
						module.HasBowString = true;
						item.Delete();
						rang.InvalidateProperties();
					}
					
					if ( item.GetType() == typeof( SilkStringer ) )
					{
						Conjunction( module, 3, 0 );
						CheckSkill( from, rang, module );
						module.HasBowString = true;
						item.Delete();
						rang.InvalidateProperties();
					}
					
					if ( item.GetType() == typeof( HorseHairStringer ) )
					{
						Conjunction( module, 4, 0 );
						CheckSkill( from, rang, module );
						module.HasBowString = true;
						item.Delete();
						rang.InvalidateProperties();
					}
					
					if ( item.GetType() == typeof( HempStringer ) )
					{
						Conjunction( module, 5, 0 );
						CheckSkill( from, rang, module );
						module.HasBowString = true;
						item.Delete();
						rang.InvalidateProperties();
					}
					
					if ( item.GetType() == typeof( AngelHairStringer ) )
					{
						Conjunction( module, 6, 0 );
						CheckSkill( from, rang, module );
						module.HasBowString = true;
						item.Delete();
						rang.InvalidateProperties();
					}
				}
				
				if ( fletching < 100 )
				{
					from.SendMessage( "Only a grandmaster bowcrafter can modify this weapon." );
					return;
				}
				
				if ( LucidNagual.DataCenter.DebugAdvancedArchery )
					Console.WriteLine( "Code making it passed modification check." );
			}
			else
			{
				from.SendMessage( "You can only target a bow stringer." );
			}
		}
		
		public static void CheckSkill( Mobile from, BaseRanged rang, BaseRangedModule module )
		{
			double fletching = from.Skills[ SkillName.Fletching ].Base;

			if ( LucidNagual.DataCenter.DebugAdvancedArchery )
				Console.WriteLine( "AA Check: Fletching over 100." );
			
			int skillCode;
			
			if ( fletching > 100.0 && fletching < 105.0 )
				Conjunction( module, 0, 1 );

			else if ( fletching > 104.9 && fletching < 112 )
				Conjunction( module, 0, 2 );

			else if ( fletching > 111.9 && fletching < 119.9 )
				Conjunction( module, 0, 3 );

			else if ( fletching > 119.9 )
				Conjunction( module, 0, 4 );
			
			else
				return;
		}
		
		public static void Conjunction( BaseRangedModule module, int str, int lbs )
		{
			if ( LucidNagual.DataCenter.DebugAdvancedArchery )
				Console.WriteLine( "AA Check: Code making it passed the conjunction." );
			
			SetPounds( module, lbs );
			SetStrength( module, str );
		}
		
		public static void SetPounds( BaseRangedModule module, int code )
		{
			if ( LucidNagual.DataCenter.DebugAdvancedArchery )
				Console.WriteLine( "AA Check: Code making it passed set pounds." );
			
			if ( code == 1 )
				module.PullWeightSelection = PoundsPerPull.Fourty;
			
			else if ( code == 2 )
				module.PullWeightSelection = PoundsPerPull.Sixty;
			
			else if ( code == 3 )
				module.PullWeightSelection = PoundsPerPull.Eighty;
			
			else if ( code == 4 )
				module.PullWeightSelection = PoundsPerPull.Hundred;
			
			else
				return;
		}
		
		public static void SetStrength( BaseRangedModule module, int code )
		{
			if ( LucidNagual.DataCenter.DebugAdvancedArchery )
				Console.WriteLine( "AA Check: Code making it passed set strength." );
			
			if ( code == 1 )
				module.m_Strength = StringStrength.VeryWeak;
			
			else if ( code == 2 )
				module.m_Strength = StringStrength.Weak;
			
			else if ( code == 3 )
				module.m_Strength = StringStrength.Sturdy;
			
			else if ( code == 4 )
				module.m_Strength = StringStrength.Strong;
			
			else if ( code == 5 )
				module.m_Strength = StringStrength.Dependable;
			
			else if ( code == 6 )
				module.m_Strength = StringStrength.Indestructable;
			
			else
				return;
		}
	}
}


