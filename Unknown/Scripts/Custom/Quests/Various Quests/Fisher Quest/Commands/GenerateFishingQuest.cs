using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Commands;

namespace Server
{
	public class GenerateFishingQuest
	{
		public GenerateFishingQuest()
		{
		}

		public static void Initialize()
		{
			CommandSystem.Register( "GenFishingQuest", AccessLevel.Administrator, new CommandEventHandler( GenerateFishingQuest_OnCommand ) );
		}

		[Usage( "GenFishingQuest" )]
		[Description( "Generates Fishing Quest" )]
		public static void GenerateFishingQuest_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Generation in progress..." );

			GenSpawners.CreateSpawners();

			e.Mobile.SendMessage( "The Fishing Quest generation is now complete" );
		}

		public class GenSpawners
		{

			private const bool TotalRespawn = true;
			private static TimeSpan MinTime = TimeSpan.FromMinutes( 3 );
			private static TimeSpan MaxTime = TimeSpan.FromMinutes( 5 );

			public GenSpawners()
			{
			}

			private static Queue m_ToDelete = new Queue();

			public static void ClearSpawners( int x, int y, int z, Map map )
			{
				IPooledEnumerable eable = map.GetItemsInRange( new Point3D( x, y, z ), 0 );

				foreach ( Item item in eable )
				{
					if ( item is Spawner && item.Z == z )
						m_ToDelete.Enqueue( item );
				}

				eable.Free();

				while ( m_ToDelete.Count > 0 )
					((Item)m_ToDelete.Dequeue()).Delete();
			}

			public static void CreateSpawners()
			{
				PlaceSpawns( 1483, 1669, 0, "FQLegendaryFisher" );
				PlaceSpawns( 1457, 2432, 0, "FQSerpentine" );
			}

			public static void PlaceSpawns( int x, int y, int z, string types )
			{

				switch ( types )
				{
					case "FQLegendaryFisher":
						MakeSpawner( "FQLegendaryFisher", x, y, z, Map.Trammel, true );
						MinTime = TimeSpan.FromMinutes( 3 );
						MaxTime = TimeSpan.FromMinutes( 5 );
						break;
					case "FQSerpentine":
						MakeSpawner( "FQSerpentine", x, y, z, Map.Trammel, true );
						MinTime = TimeSpan.FromMinutes( 3 );
						MaxTime = TimeSpan.FromMinutes( 5 );
						break;
					default:
						break;
				}
			}

			private static void MakeSpawner( string types, int x, int y, int z, Map map, bool start )
			{
				ClearSpawners( x, y, z, map );

				Spawner sp = new Spawner( types );

				sp.Count = 1;

				sp.Running = true;
				sp.HomeRange = 5;
				sp.MinDelay = MinTime;
				sp.MaxDelay = MaxTime;

				sp.MoveToWorld( new Point3D( x, y, z ), map );

			}
		}
	}
}
