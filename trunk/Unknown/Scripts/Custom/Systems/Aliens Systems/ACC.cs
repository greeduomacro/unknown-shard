using System;
using System.IO;
using System.Collections;
using Server;

namespace Server.ACC
{
	public class ACC
	{
		public static void Initialize()
		{
			EventSink.WorldSave += new WorldSaveEventHandler( Save );
			Load();
		}

		private static Hashtable m_RegSystems = new Hashtable();
		public  static Hashtable RegisteredSystems{ get{ return m_RegSystems; } }

		public static void RegisterSystem( string system )
		{
			if( m_RegSystems.ContainsKey( system ) )
				return;

			Type t = Type.GetType( system );
			if( t == null )
			{
				Console.WriteLine( "Invalid System String: " + system );
				return;
			}

			ACCSystem sys = (ACCSystem)Activator.CreateInstance( t );
			if( sys != null )
			{
				m_RegSystems.Add( system, true );
				Console.WriteLine( "ACC Registered: " + system );
			}
		}

		public static bool SysEnabled( string system )
		{
			return m_RegSystems.ContainsKey( system ) && (bool)m_RegSystems[system];
		}

		public static void DisableSystem( string system )
		{
			if( m_RegSystems.ContainsKey( system ) )
			{
				Type t = ScriptCompiler.FindTypeByFullName( system );
				if( t != null )
				{
					if( !Directory.Exists( "ACC Backups" ) )
						Directory.CreateDirectory( "ACC Backups" );

					ACCSystem sys = (ACCSystem)Activator.CreateInstance( t );
					if( sys != null )
					{
						sys.StartSave( "ACC Backups/" );
						sys.Disable();
					}
					m_RegSystems[system] = false;
				}
			}
			else
				Console.WriteLine( "Invalid System - {0} - Cannot disable.", system );
		}

		public static void EnableSystem( string system )
		{
			if( m_RegSystems.ContainsKey( system ) )
			{
				Type t = ScriptCompiler.FindTypeByFullName( system );
				if( t != null )
				{
					if( !Directory.Exists( "ACC Backups" ) )
						Directory.CreateDirectory( "ACC Backups" );

					ACCSystem sys = (ACCSystem)Activator.CreateInstance( t );
					if( sys != null )
					{
						sys.StartLoad( "ACC Backups/" );
						sys.Enable();
					}
					m_RegSystems[system] = true;
				}
			}
			else
				Console.WriteLine( "Invalid System - {0} - Cannot enable.", system );
		}

		public static void Save( WorldSaveEventArgs args )
		{
			if( !Directory.Exists( "Saves/ACC" ) )
				Directory.CreateDirectory( "Saves/ACC" );

			string filename = "acc.sav";
			string path =@"Saves/ACC/";
			string pathNfile = path+filename;
			DateTime start = DateTime.Now;

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine( "----------" );
			Console.WriteLine( "Saving ACC..." );

			try
			{
				using( FileStream m_FileStream = new FileStream( pathNfile, FileMode.OpenOrCreate, FileAccess.Write ) )
				{
					BinaryFileWriter writer = new BinaryFileWriter( m_FileStream, true );

					writer.Write( (int) m_RegSystems.Count );
					foreach( DictionaryEntry de in m_RegSystems )
					{
						Type t = ScriptCompiler.FindTypeByFullName( (string)de.Key );
						if( t != null )
						{
							writer.Write( (string)de.Key );
							writer.Write( (bool)de.Value );

							if( (bool)m_RegSystems[(string)de.Key] )
							{
								ACCSystem system = (ACCSystem)Activator.CreateInstance( t );
								if( system != null )
									system.StartSave( path );
							}
						}

					}

					writer.Close();
					m_FileStream.Close();
				}

				Console.WriteLine( "Done in {0:F1} seconds.", (DateTime.Now-start).TotalSeconds );
				Console.WriteLine( "----------" );
				Console.WriteLine();
			}
			catch( Exception err )
			{
				Console.WriteLine( "Failed. Exception: "+err );
			}
		}

		public static void Load()
		{
			if( !Directory.Exists( "Saves/ACC" ) )
				return;

			string filename = "acc.sav";
			string path = @"Saves/ACC/";
			string pathNfile = path+filename;
			DateTime start = DateTime.Now;

			Console.WriteLine();
			Console.WriteLine( "----------" );
			Console.WriteLine( "Loading ACC..." );

			try
			{
				using( FileStream m_FileStream = new FileStream( pathNfile, FileMode.Open, FileAccess.Read ) )
				{
					BinaryReader m_BinaryReader = new BinaryReader( m_FileStream );
					BinaryFileReader reader = new BinaryFileReader( m_BinaryReader );

					if( m_RegSystems == null )
						m_RegSystems = new Hashtable();

					int Count = reader.ReadInt();
					for( int i = 0; i < Count; i++ )
					{
						string system = reader.ReadString();
						Type t = ScriptCompiler.FindTypeByFullName( system );
						bool enabled = reader.ReadBool();

						if( t != null )
						{
							m_RegSystems[system] = enabled;

							if( (bool)m_RegSystems[system] )
							{
								ACCSystem sys = (ACCSystem)Activator.CreateInstance( t );
								if( sys != null )
									sys.StartLoad( path );
							}
						}
					}

					reader.Close();
					m_FileStream.Close();
				}

				Console.WriteLine( "Done in {0:F1} seconds.", (DateTime.Now-start).TotalSeconds );
				Console.WriteLine( "----------" );
				Console.WriteLine();
			}
			catch( Exception e )
			{
				Console.WriteLine( "Failed. Exception: "+e );
			}
		}
	}
}