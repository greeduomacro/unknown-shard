#region AuthorHeader
//
//	Jail version 2.0, by Xanthos
//
//  Based on original code and concept by Sirens Song
//  (ie, Matron de Winter) 2004 and Grim Reaper.  Thanks to
//	Thundar for his ideas and testing.
//
#endregion AuthorHeader
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;

namespace Xanthos.JailSystem
{
	public class Jail
	{
		internal static bool s_LoggingEnabled = true;
		private static Hashtable m_JailWords;
		private static volatile JailQueue s_JailProcessingQueue;
		private static volatile JailQueue s_KickProcessingQueue;

		private const double kSecondsTillKick = 3;
		private const double kSecondsTillJail = 1.3;
		
		public static void Initialize()
		{
			ArrayList wordList = new ArrayList();
			try
			{
				using ( StreamReader sr = new StreamReader( JailConfig.JailWordFile ) ) 
				{
					String line;
					while (( line = sr.ReadLine() ) != null ) 
					{
						line = line.Trim();
						if ( line != "" )
							wordList.Add( line );
					}
				}

				if ( wordList.Count > 0 )
				{
					m_JailWords = new Hashtable( wordList.Count, StringComparer.OrdinalIgnoreCase );

					for ( int i = 0; i < wordList.Count; ++i )
					{
						m_JailWords[ wordList[ i ] ] = wordList[ i ];
					}
				}
			}
			catch ( Exception e )
			{
				World.Broadcast( 0, true, "Jail: error reading jail words file {0}.", JailConfig.JailWordFile );
				World.Broadcast( 0, true, e.Message );
			}

			CommandHandlers.Register( "Jail", AccessLevel.GameMaster, new CommandEventHandler( Jail_OnCommand ) );
			CommandHandlers.Register( "UnJail", AccessLevel.GameMaster, new CommandEventHandler( UnJail_OnCommand ) );
			CommandHandlers.Register( "AddJailWord", AccessLevel.GameMaster, new CommandEventHandler( AddJailWord_OnCommand ) );
			CommandHandlers.Register( "DeleteJailWord", AccessLevel.GameMaster, new CommandEventHandler( DeleteJailWord_OnCommand ) );
			CommandHandlers.Register( "ListJailWords", AccessLevel.GameMaster, new CommandEventHandler( ListJailWords_OnCommand ) );
			EventSink.Speech += new SpeechEventHandler( EventSink_Speech );

			s_JailProcessingQueue = new JailQueue();
			s_KickProcessingQueue = new JailQueue();
		}

		//
		// Call this from your chat system command handler to have public 
		// chat monitored.
		// For instance, to add monitoring to Knives chat 2.0
		// Search for:
		// string text = Filter( e.Mobile, e.ArgString );
		// and insert this line directly after it (uncommented):
		// Xanthos.SpeechCop.Jail.CheckChatSpeech( e.Mobile, text );	// <- xanthos Jail speech change this line only
		//
		public static void CheckChatSpeech( Mobile mobile, string speech )
		{
			PlayerMobile player = mobile as PlayerMobile;

			if ( JailConfig.JailWordsEnabled && null != player && CheckSpeech( speech ) )
			{
				JailLog.WriteString( "CheckChatSpeech: jailing player " + player.Name + " for speech " + speech );
				JailThem( player, Jail.JailOption.None );
			}
		}

		//
		// This handler monitors local speech for use of the above words.
		//
		public static void EventSink_Speech( SpeechEventArgs args )
		{
			PlayerMobile player = args.Mobile as PlayerMobile;

			if ( JailConfig.JailWordsEnabled && null != player && CheckSpeech( args.Speech ) )
			{
				JailLog.WriteString( "EventSink_Speech: jailing player " + player.Name + " for speech " + args.Speech );
				JailThem( player, Jail.JailOption.None );
			}
		}

		public enum JailOption
		{
			None,
			Squelch,
			Kick,
			PublicBan,
			Ban,
		}

		private static JailOption GetOptions( CommandEventArgs e )
		{
			JailOption option = JailOption.None;

			if ( 1 <= e.Length )
			{
				string str = e.GetString( 0 ).ToLower();

				if ( str.Equals( "-s" ) )
					option = JailOption.Squelch;
			}
			return option;
		}


		[Usage( "Jail" )]
		[Description( "Jails a targeted Player." )]
		private static void Jail_OnCommand( CommandEventArgs e )
		{
			JailOption option = GetOptions( e );

			e.Mobile.Target = new JailTarget( option );
			e.Mobile.SendMessage( "Whom do you wish to Jail?" );
		}

		[Usage( "UnJail" )]
		[Description( "UnJails a targeted Player." )]
		private static void UnJail_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Target = new UnJailTarget();
			e.Mobile.SendMessage( "Whom do you wish to release from jail?" );
		}

		[Usage( "AddJailWord" )]
		[Description( "Adds a word to the bad words list." )]
		private static void AddJailWord_OnCommand( CommandEventArgs e )
		{
			try
			{
				string[] args = e.Arguments;

				if ( args.Length > 0 && null != args[ 0 ] )
				{
					m_JailWords.Add( args[ 0 ], args[ 0 ] );
					WriteJailWordsList( e.Mobile );
				}
			}
			catch ( Exception exc )
			{
				e.Mobile.SendMessage( "Exception raised adding a word " + exc.Message );
			}
		}

		[Usage( "DeleteJailWord" )]
		[Description( "Deletes a word from the bad words list." )]
		private static void DeleteJailWord_OnCommand( CommandEventArgs e )
		{
			try
			{
				string[] args = e.Arguments;

				if ( args.Length > 0 && null != args[ 0 ] )
				{
					m_JailWords.Remove( args[ 0 ] );
					WriteJailWordsList( e.Mobile );
				}
			}
			catch ( Exception exc )
			{
				e.Mobile.SendMessage( "Exception raised deleting a word " + exc.Message );
			}
		}

		[Usage( "ListJailWords" )]
		[Description( "Displays the bad words list." )]
		private static void ListJailWords_OnCommand( CommandEventArgs e )
		{
			foreach ( DictionaryEntry d in m_JailWords )
			{
				e.Mobile.SendMessage( d.Key.ToString() );
			}
		}

		private static void WriteJailWordsList( Mobile from )
		{
			try
			{
				using ( StreamWriter sw = new StreamWriter( JailConfig.JailWordFile ) ) 
				{
					foreach ( DictionaryEntry d in m_JailWords )
					{
						sw.WriteLine( d.Key.ToString() );
					}
				}
				from.SendMessage( "Jail word list written to disk." );
			}
			catch ( Exception e )
			{
				from.SendMessage( "Exception raised writing bad words file " + e.Message );
			}
		}

		private static bool CheckSpeech( string speech )
		{
			if ( null != m_JailWords )
			{
				try
				{
					string[] saidWords = speech.Split( ' ' );

					foreach ( string said in saidWords )
					{
						if ( m_JailWords.ContainsKey( said ) )
						{
							JailLog.WriteString( "CheckSpeech: match on " + said );
							return true;
						}
					}
				}
				catch {}
			}
			return false;
		}

		private class JailTarget : Target
		{
			JailOption m_Option;

			public JailTarget( JailOption option ) : base( -1, true, TargetFlags.None )
			{
				m_Option = option;
			}

			protected override void OnTarget( Mobile from, object targ )
			{
				PlayerMobile player = targ as PlayerMobile;

				if ( null == player )
					from.SendMessage( "You can only Jail Players." );
				else
				{
					JailLog.WriteString( "JailTarget: jailing player " + from.Name );
					JailThem( player, m_Option );
				}
			}
		}

		public static void KickPlayerInQueue()
		{
			PlayerMobile player = s_KickProcessingQueue.Dequeue() as PlayerMobile;

			if ( null != player )
			{
				NetState ns = player.NetState;

				if ( ns != null )
					ns.Dispose();
			}
		}

		public static void JailThem( PlayerMobile player, JailOption option )
		{
			if ( null == player || player.AccessLevel >= JailConfig.JailImmuneLevel )
				return;

			if ( JailOption.Squelch == option )
				player.Squelched = true;

			foreach ( Item item in player.Items )
			{
				if ( item is JailHammer )	// Jailed while jailed gets them another load of rock to mine
				{
					if ( 0 > ( ((JailHammer)item).UsesRemaining += JailConfig.UsesRemaining ) )	// handle integer overflow
						((JailHammer)item).UsesRemaining *= -1;

					Banker.Withdraw( player, JailConfig.FineAmount );
					player.SendMessage( "Your remaining sentence has been increased!" );
					player.SendMessage( "You have been fined {0} gold and are being kicked!", JailConfig.FineAmount );
					
					// This gives a nice little delay for the message to be read
					s_KickProcessingQueue.Enqueue( player );
					player.Squelched = true;
					Server.Timer.DelayCall( TimeSpan.FromSeconds( kSecondsTillKick ), new Server.TimerCallback( KickPlayerInQueue ) );
					return;
				}
			}

			// If mounted, dismount them and stable mount
			if ( player.Mounted )
			{
				if ( player.Mount is EtherealMount )
				{
					EtherealMount pet = player.Mount as EtherealMount;
					pet.Internalize();
					pet.Rider = null;
				}
				else if ( player.Mount is BaseMount )
				{
					BaseMount pet = player.Mount as BaseMount;
					pet.Rider = null;
					Jail.StablePet( player, pet );
				}
			}

			// Stable all other pets
			foreach ( Mobile mobile in World.Mobiles.Values )
			{
				if ( mobile is BaseCreature )
				{
					BaseCreature bc = mobile as BaseCreature;

					if ( null != bc && (bc.Controlled && bc.ControlMaster == player) || (bc.Summoned && bc.SummonMaster == player) )
						Jail.StablePet( player, bc );
				}
			}

			// Move all items to a bag and move that to the bank
			Container backpack = player.Backpack;
			Backpack bag = new Backpack(); bag.Hue = JailConfig.RobeHue;
			ArrayList equipedItems = new ArrayList( player.Items );

			foreach ( Item item in equipedItems )
			{
				if ( item.Layer == Layer.Bank || item.Layer == Layer.Backpack || item.Layer == Layer.Hair || item.Layer == Layer.FacialHair || item is DeathShroud )
					continue;
				bag.DropItem( item );
			}

			ArrayList backpackItems = new ArrayList( backpack.Items );
			foreach ( Item item in backpackItems )
			{
				if ( item is JailRock )
					item.Delete();
				else if ( item.Movable )	// Non movable pack items must remain (i.e. skill balls)
					bag.DropItem( item );
			}

			// Remember their access level and make them a player
			JailHammer hammer = new JailHammer();
			hammer.PlayerAccessLevel = player.AccessLevel;
			player.AccessLevel = AccessLevel.Player;

			// Bank the bag of belongings, give them a hammer and welcome them
			player.BankBox.DropItem( bag );
			player.AddItem( hammer );

			// Explosively move player to jail
			player.BoltEffect( 0 );
			player.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Waist );
			player.PlaySound( 0x307 );
			player.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
			player.PlaySound( 0x225 );

			// This gives a nice little delay for the effect to complete
			s_JailProcessingQueue.Enqueue( player );
			Server.Timer.DelayCall( TimeSpan.FromSeconds( kSecondsTillJail ), new Server.TimerCallback( JailPlayerInQueue ) );
		}

		private static void JailPlayerInQueue()
		{
			try
			{
				PlayerMobile player = s_JailProcessingQueue.Dequeue() as PlayerMobile;

				if ( null != player )
				{
					Boots boots = new JailBoots( player.Name );
					boots.MoveToWorld( player.Location, player.Map );
					player.MoveToWorld( JailConfig.JailLocation, JailConfig.JailMap );
					Item robe = new Robe(); robe.Hue = JailConfig.RobeHue; robe.Name = JailConfig.RobeTitle; player.AddItem( robe );
					player.SendMessage( "You have been JAILED!" );

					if ( 0 < JailConfig.FineAmount )
					{
						if ( !Banker.Withdraw( player, JailConfig.FineAmount ) )
						{
							JailHammer hammer = player.FindItemOnLayer( Layer.OneHanded ) as JailHammer;

							if ( null != hammer )
							{
								hammer.UsesRemaining *= 2;
								player.SendMessage( "You could not afford the fine so your sentence has been doubled!" );
							}
						}
						else
							player.SendMessage( "You have been fined {0} gold!", JailConfig.FineAmount );
					}
				}
			}
			catch { }
		}

		public static void StablePet( PlayerMobile player, BaseCreature pet )
		{
			if ( null == player || null == pet )
				return;

			pet.Internalize();
			pet.ControlTarget = null;
			pet.ControlOrder = OrderType.Stay;
			pet.SetControlMaster( null );
			pet.SummonMaster = null;
			pet.IsStabled = true;
			player.Stabled.Add( pet );
			player.SendMessage( "Your pet has been stabled" );
		}

		private class UnJailTarget : Target
		{
			public UnJailTarget() : base( -1, true, TargetFlags.None ) {}

			protected override void OnTarget( Mobile from, object targ )
			{
				PlayerMobile player = targ as PlayerMobile;

				if ( null == player )
					from.SendMessage( "You may only unjail players." );
				else
				{
					from.SendMessage( "You free the player." );
					FreeThem( player );
				}
			}
		}

		public static void FreeThem( PlayerMobile player )
		{
			if ( null == player )
				return;

			// Take away any JailRock
			// No need to recurse containers since all their items were removed when jailed
			RemoveRockFromList( new ArrayList( player.Items ) ); 
			RemoveRockFromList( new ArrayList( player.Backpack.Items ) ); 

			// Restore their access level
			JailHammer hammer = player.FindItemOnLayer( Layer.OneHanded ) as JailHammer;

			if ( null != hammer )
			{
				player.AccessLevel = hammer.PlayerAccessLevel;
				hammer.Delete();
			}

			if ( player.Kills >= 5 )
				player.MoveToWorld( JailConfig.FreeMurdererLocation, JailConfig.FreeMurdererMap );
			else
				player.MoveToWorld( JailConfig.FreeLocation, JailConfig.FreeMap );
			player.SendMessage( "You have been released from Jail!" );
		}

		private static void RemoveRockFromList( ArrayList list )
		{
			if ( null == list )
				return;

			foreach ( Item item in list )
			{
				if ( item is JailRock )	// Be sure no jail rock leaves the jail.
					item.Delete();
			}
		}

		//
		// Thread safe wrapper around the Queue class
		//
		internal class JailQueue : Queue
		{
			public override object Dequeue()
			{
				object obj;

				lock ( SyncRoot )
					obj = base.Dequeue();
				return obj;
			}

			public override void Enqueue( object obj )
			{
				lock ( SyncRoot )
					base.Enqueue( obj );
			}
		}
	}

	public class JailLog
	{
		private static StreamWriter m_Writer;
		private static bool m_Enabled = false;

		public static void Initialize()
		{
			if ( Jail.s_LoggingEnabled )
			{
				// Create the log writer
				try
				{
					string folder = Path.Combine( Core.BaseDirectory, @"Logs\Jail" );

					if ( !Directory.Exists( folder ) )
						Directory.CreateDirectory( folder );

					string name = string.Format( "{0}.txt", DateTime.Now.ToLongDateString() );
					string file = Path.Combine( folder, name );

					m_Writer = new StreamWriter( file, true );
					m_Writer.AutoFlush = true;

					m_Writer.WriteLine( "###############################" );
					m_Writer.WriteLine( "# {0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString() );
					m_Writer.WriteLine();

					m_Enabled = true;
				}
				catch ( Exception err )
				{
					Console.WriteLine( "Couldn't initialize Jail system log. Reason:" );
					Console.WriteLine( err.ToString() );
					m_Enabled = false;
				}
			}
		}

		public static void WriteString( string entry )
		{
			if ( !Jail.s_LoggingEnabled )
				return;

			if ( !m_Enabled || m_Writer == null )
				return;

			try
			{
				m_Writer.WriteLine( "# {0}", entry );
			}
			catch { }
		}
	}
}