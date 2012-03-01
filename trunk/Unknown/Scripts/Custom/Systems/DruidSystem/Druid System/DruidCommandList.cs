using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Druid;


namespace Server.Commands
{
	public class CastDruidSpells
	{
		public static void Initialize()
		{
			CommandSystem.Prefix = "[";

			CommandSystem.Register( "SummonFirefly", AccessLevel.Player, new CommandEventHandler( SummonFirefly_OnCommand ) );

			CommandSystem.Register( "HollowReed", AccessLevel.Player, new CommandEventHandler( HollowReed_OnCommand ) );

			CommandSystem.Register( "PackOfBeasts", AccessLevel.Player, new CommandEventHandler( PackOfBeasts_OnCommand ) );

			CommandSystem.Register( "SpringOfLife", AccessLevel.Player, new CommandEventHandler( SpringOfLife_OnCommand ) );

			CommandSystem.Register( "GraspingRoots", AccessLevel.Player, new CommandEventHandler( GraspingRoots_OnCommand ) );

			CommandSystem.Register( "BlendWithForest", AccessLevel.Player, new CommandEventHandler( BlendWithForest_OnCommand ) );

			CommandSystem.Register( "SwarmOfInsects", AccessLevel.Player, new CommandEventHandler( SwarmOfInsects_OnCommand ) );

			CommandSystem.Register( "VolcanicEruption", AccessLevel.Player, new CommandEventHandler( VolcanicEruption_OnCommand ) );

			CommandSystem.Register( "SummonTreefellow", AccessLevel.Player, new CommandEventHandler( SummonTreefellow_OnCommand ) );

			CommandSystem.Register( "StoneCircle", AccessLevel.Player, new CommandEventHandler( StoneCircle_OnCommand ) );

			CommandSystem.Register( "EnchantedGrove", AccessLevel.Player, new CommandEventHandler( EnchantedGrove_OnCommand ) );

			CommandSystem.Register( "LureStone", AccessLevel.Player, new CommandEventHandler( LureStone_OnCommand ) );

			CommandSystem.Register( "NaturesPassage", AccessLevel.Player, new CommandEventHandler( NaturesPassage_OnCommand ) );

			CommandSystem.Register( "MushroomGateway", AccessLevel.Player, new CommandEventHandler( MushroomGateway_OnCommand ) );

			CommandSystem.Register( "RestorativeSoil", AccessLevel.Player, new CommandEventHandler( RestorativeSoil_OnCommand ) );

			CommandSystem.Register( "ShieldOfEarth", AccessLevel.Player, new CommandEventHandler( ShieldOfEarth_OnCommand ) );

		}

        public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
			Server.Commands.CommandSystem.Register( command, access, handler );
		}

		public static bool HasSpell( Mobile from, int spellID )
		{
			Spellbook book = Spellbook.Find( from, spellID );

			return ( book != null && book.HasSpell( spellID ) );
		}

		[Usage( "SummonFirefly" )]
		[Description( "Casts SummonFirefly spell." )]
		public static void SummonFirefly_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 301 ) )
					{
					new FireflySpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}
		[Usage( "HollowReed" )]
		[Description( "Casts HollowReed spell." )]
		public static void HollowReed_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
			
         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 302 ) )
					{
					new HollowReedSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "PackOfBeasts" )]
		[Description( "Casts PackOfBeasts spell." )]
		public static void PackOfBeasts_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 303 ) )
					{
					new PackOfBeastSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "SpringOfLife" )]
		[Description( "Casts SpringOfLife spell." )]
		public static void SpringOfLife_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 304 ) )
					{
					new SpringOfLifeSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "GraspingRoots" )]
		[Description( "Casts GraspingRoots spell." )]
		public static void GraspingRoots_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 305 ) )
					{
					new GraspingRootsSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "BlendWithForest" )]
		[Description( "Casts BlendWithForest spell." )]
		public static void BlendWithForest_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 306 ) )
					{
					new  BlendWithForestSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "SwarmOfInsects" )]
		[Description( "Casts SwarmOfInsects spell." )]
		public static void SwarmOfInsects_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 307 ) )
					{
					new SwarmOfInsectsSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "VolcanicEruption" )]
		[Description( "Casts VolcanicEruption spell." )]
		public static void VolcanicEruption_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 308 ) )
					{
					new VolcanicEruptionSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "SummonTreefellow" )]
		[Description( "Casts SummonTreefellow spell." )]
		public static void SummonTreefellow_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 309 ) )
					{
					new TreefellowSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "StoneCircle" )]
		[Description( "Casts StoneCircle spell." )]
		public static void StoneCircle_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 310 ) )
					{
					new StoneCircleSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "EnchantedGrove" )]
		[Description( "Casts EnchantedGrove spell." )]
		public static void EnchantedGrove_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 311 ) )
					{
					new EnchantedGroveSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "LureStone" )]
		[Description( "Casts LureStone spell." )]
		public static void LureStone_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 312 ) )
					{
					new LureStoneSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "NaturesPassage" )]
		[Description( "Casts NaturesPassage spell." )]
		public static void NaturesPassage_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 313 ) )
					{
					new NaturesPassageSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "MushroomGateway" )]
		[Description( "Casts MushroomGateway spell." )]
		public static void MushroomGateway_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 314 ) )
					{
					new MushroomGatewaySpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}

		[Usage( "RestorativeSoil" )]
		[Description( "Casts RestorativeSoil spell." )]
		public static void RestorativeSoil_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 315 ) )
					{
					new RestorativeSoilSpell( e.Mobile, null ).Cast(); 
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 			

		}
		[Usage( "ShieldOfEarth" )]
		[Description( "Casts ShieldOfEarth spell." )]
		public static void ShieldOfEarth_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

         			if ( !Multis.DesignContext.Check( e.Mobile ) )
            				return; // They are customizing

				if ( HasSpell( from, 316 ) )
					{

					new ShieldOfEarthSpell( e.Mobile, null ).Cast();
					}
				else
					{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					} 

		}
	}
}
