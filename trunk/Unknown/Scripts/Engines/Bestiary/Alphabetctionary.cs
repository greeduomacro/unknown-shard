using System;
using System.Text;
using System.Collections.Generic;

namespace Server.Bestiary
{
	//-------------------------------------------------------------------------------
	// Alphabet hybrid with Dictionary
	//-------------------------------------------------------------------------------
	public class Alphabetctionary<T> : IEnumerable<T>, IDictionary<char, T>
	{
		internal class AlphabetEnumerator : IEnumerator<T>
		{
			private Alphabetctionary<T> m_InternalItems;
			private int m_Current;

			public AlphabetEnumerator( Alphabetctionary<T> items )
			{
				m_Current = -1;
				m_InternalItems = items;
			}

			#region IEnumerator<T> Members

			public T Current
			{
				get { return m_InternalItems.m_Items[ m_Current ]; }
			}

			#endregion

			#region IDisposable Members

			public void Dispose()
			{ }

			#endregion

			#region IEnumerator Members

			object System.Collections.IEnumerator.Current
			{
				get { return m_InternalItems.m_Items[ m_Current ]; }
			}

			public bool MoveNext()
			{
				if( ( m_Current + 1 ) < m_InternalItems.m_Items.Length )
				{
					m_Current++;
					return true;
				}

				return false;
			}

			public void Reset()
			{
				m_Current = -1;
			}

			#endregion
		}

		    private T[] m_Items;

		public static char[] m_Alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
		private static List<char> m_KeyCollection = new List<char>( m_Alphabet );

		public Alphabetctionary()
		{
			m_Items = new T[ m_Alphabet.Length ];
		}

		public void Initialize()
		{
			for(int i=0; i< m_Items.Length; ++i)
			{
				m_Items[i] = Activator.CreateInstance<T>();
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder( 0x100 );

			for( int i = 0; i < m_Alphabet.Length; i++ )
			{
				sb.AppendFormat( "[\"{0}\"] => \n{{\n\t{1}\n}}\n", m_Alphabet[ i ], this[ i ].ToString() );
			}

			return sb.ToString();
		}

		public T this[ string c ]
		{
			get
			{
				return this[c[0]];
			}
			set
			{
				this[c[0]] = value;
			}
		}

		public T this[ char c ]
		{
			get
			{
				int index = (int)( char.ToLower( c ) ) - 97;

				if( index < 0 || index >= m_Alphabet.Length )
					throw new ArgumentOutOfRangeException( " Argument must be alphabet character. " );

				return m_Items[ index ];
			}
			set
			{
				int index = (int)( char.ToLower( c ) ) - 97;

				if( index < 0 || index >= m_Alphabet.Length )
					throw new ArgumentOutOfRangeException( " Argument must be alphabet character. " );

				m_Items[ index ] = value;
			}
		}

		public T this[ int c ]
		{
			get
			{
				int index = c;

				if( index < 0 || index >= m_Alphabet.Length )
					throw new ArgumentOutOfRangeException( " Argument must be alphabet character. " );

				return m_Items[ index ];
			}
			set
			{
				int index = c;

				if( index < 0 || index >= m_Alphabet.Length )
					throw new ArgumentOutOfRangeException( " Argument must be alphabet character. " );

				m_Items[ index ] = value;
			}
		}

		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator()
		{
			return new AlphabetEnumerator( this );
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return m_Items.GetEnumerator();
		}

		#endregion

		#region IDictionary<char,T> Members

		public void Add( char key, T value )
		{
			this[ key ] = value;
		}

		public bool ContainsKey( char key )
		{
			return this[ key ] != null;
		}

		public ICollection<char> Keys
		{
			get { return m_KeyCollection; }
		}

		public bool Remove( char key )
		{
			throw new Exception( "The operation is not suppported." );
		}

		public bool TryGetValue( char key, out T value )
		{
			T val = this[ key ];
			value = val;

			if( val == null )
				return false;

			return true;
		}

		public ICollection<T> Values
		{
			get { return new List<T>( m_Items ); }
		}

		#endregion

		#region ICollection<KeyValuePair<char,T>> Members

		void ICollection<KeyValuePair<char, T>>.Add( KeyValuePair<char, T> item )
		{
			this[ item.Key ] = item.Value;
		}

		void ICollection<KeyValuePair<char, T>>.Clear()
		{
			for( int i = 0; i < m_Items.Length; i++ )
			{
				m_Items[ i ] = default( T );
			}
		}

		bool ICollection<KeyValuePair<char, T>>.Contains( KeyValuePair<char, T> item )
		{
			if( this[ item.Key ].Equals( item.Value ) )
				return true;

			return false;
		}

		void ICollection<KeyValuePair<char, T>>.CopyTo( KeyValuePair<char, T>[] array, int arrayIndex )
		{
			for( int i = arrayIndex; i < m_Items.Length; i++ )
			{
				array[ i - arrayIndex ] = new KeyValuePair<char, T>( m_Alphabet[ i ], m_Items[ i ] );
			}
		}

		int ICollection<KeyValuePair<char, T>>.Count
		{
			get { return m_Items.Length; }
		}

		bool ICollection<KeyValuePair<char, T>>.IsReadOnly
		{
			get { return false; }
		}

		bool ICollection<KeyValuePair<char, T>>.Remove( KeyValuePair<char, T> item )
		{
			if( this[ item.Key ].Equals( item.Value ) )
			{
				this[ item.Key ] = default( T );
				return true;
			}

			return false;
		}

		#endregion

		#region IEnumerable<KeyValuePair<char,T>> Members

		IEnumerator<KeyValuePair<char, T>> IEnumerable<KeyValuePair<char, T>>.GetEnumerator()
		{
			KeyValuePair<char, T>[] buffer = new KeyValuePair<char, T>[ m_Alphabet.Length ];

			for( int i = 0; i < m_Alphabet.Length; i++ )
			{
				buffer[ i ] = new KeyValuePair<char, T>( m_Alphabet[ i ], m_Items[ i ] );
			}

			return (IEnumerator<KeyValuePair<char, T>>)buffer.GetEnumerator();
		}

		#endregion
	}
}