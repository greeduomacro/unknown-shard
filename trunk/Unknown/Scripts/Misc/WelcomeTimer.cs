using System;
using Server.Network;

namespace Server.Misc
{
	/// <summary>
	/// This timer spouts some welcome messages to a user at a set interval. It is used on character creation and login.
	/// </summary>
	public class WelcomeTimer : Timer
	{
		private Mobile m_Mobile;
		private int m_State, m_Count;

		private static string[] m_Messages = ( TestCenter.Enabled ?
			new string[]
				{
                    "oink"
				} :
			new string[]
				{	//Yes, this message is a pathetic message, It's suggested that you change it.
					"Welcome to Unknown Shard, aka Server.  I am the Owner Darky.",
                    "Use help menu or [help as needed"
				} );

		public WelcomeTimer( Mobile m ) : this( m, m_Messages.Length )
		{
		}

		public WelcomeTimer( Mobile m, int count ) : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 10.0 ) )
		{
			m_Mobile = m;
			m_Count = count;
		}

		protected override void OnTick()
		{
			if ( m_State < m_Count )
				m_Mobile.SendMessage( 0x44, m_Messages[m_State++] );

			if ( m_State == m_Count )
				Stop();
		}
	}
}