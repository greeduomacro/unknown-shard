using System;
using System.Collections;
using System.Reflection.Emit;
using System.Reflection;
using System.Collections.Generic;

namespace Server.Bestiary
{
	public static class OPCodeCache
	{
		private static Dictionary<int, OpCode> m_InternalStorage = new Dictionary<int, OpCode>();

		static OPCodeCache()
		{
			foreach( FieldInfo fi in typeof( OpCodes ).GetFields() )
			{
				OpCode oc = (OpCode)fi.GetValue( null );
				Add( (int)oc.Value, oc );
			}
		}

		private static void Add( int code, OpCode opCode )
		{
			m_InternalStorage.Add( code, opCode );
		}

		public static OpCode Hit( int code )
		{
			return ( m_InternalStorage[ code ] );
		}
	};
}
