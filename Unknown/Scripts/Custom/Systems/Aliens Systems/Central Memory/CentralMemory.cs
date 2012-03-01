using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Server.Gumps;
using Server.Network;


namespace Server.ACC.CM
{
	public class CentralMemory : ACCSystem
	{
		internal static ArrayList m_Types = new ArrayList();
		private  static Hashtable m_Modules = new Hashtable();
		public   static Hashtable Modules{ get{ return m_Modules; } }

		public override string Name(){ return "Central Memory"; }

		public static void Configure()
		{
			ACC.RegisterSystem( "Server.ACC.CM.CentralMemory" );
		}

		public static bool Running
		{
			get{ return ACC.SysEnabled( "Server.ACC.CM.CentralMemory" ); }
		}

		public override void Enable()
		{
			Console.WriteLine( "{0} has just been enabled!", Name() );
		}

		public override void Disable()
		{
			Console.WriteLine( "{0} has just been disabled!", Name() );
		}

		public static void Flush()
		{
			ArrayList RemoveList = new ArrayList();

			foreach( DictionaryEntry de in m_Modules )
			{
				if( ((Serial)de.Key).IsItem )
				{
					Item i = World.FindItem( (Serial)de.Key );
					if( i == null || i.Deleted )
						RemoveList.Add( (Serial)de.Key );
				}
				else if( ((Serial)de.Key).IsMobile )
				{
					Mobile m = World.FindMobile( (Serial)de.Key );
					if( m == null || m.Deleted )
						RemoveList.Add( (Serial)de.Key );
				}

				if( ((ModuleList)de.Value).Count == 0 )
					RemoveList.Add( (Serial)de.Key );
			}

			foreach( Serial s in RemoveList )
			{
				Remove( s );
			}

			RemoveList.Clear();

			Console.Write( "Flushed..." );
		}

		public static bool Contains( Serial ser )
		{
			return m_Modules.ContainsKey( ser );
		}

		public static bool ContainsModule( Serial ser, Type type )
		{
			ModuleList mod = (ModuleList)m_Modules[ser];
			if( mod != null )
				return mod.Contains( type );
			return false;
		}

		public static void Add( Serial ser )
		{
			if( m_Modules.ContainsKey( ser ) )
				return;

			m_Modules.Add( ser, new ModuleList( ser ) );
		}

		public static void Add( Serial ser, ModuleList list )
		{
			m_Modules[ser] = list;
		}

		public static void AddModule( Module mod )
		{
			if( !m_Modules.ContainsKey( mod.Owner ) )
				Add( mod.Owner );

			((ModuleList)m_Modules[ mod.Owner ]).Add( mod );
		}

		public static void AddModule( Serial ser, Type type )
		{
			if( !m_Modules.ContainsKey( ser ) )
				Add( ser );

			((ModuleList)m_Modules[ ser ]).Add( type );
		}

		public static void ChangeModule( Serial ser, Module mod )
		{
			if( !m_Modules.ContainsKey( ser ) )
				Add( ser );

			((ModuleList)m_Modules[ ser ]).Change( mod );
		}

		public static void AppendModule( Serial ser, Module mod, bool negatively )
		{
			if( !m_Modules.ContainsKey( ser ) )
				Add( ser );
			else if( !ContainsModule( ser, mod.GetType() ) )
			{
				AddModule( mod );
				return;
			}
			else
			{
				((ModuleList)m_Modules[ ser ]).Append( mod, negatively );
			}
		}

		public static void Remove( Serial ser )
		{
			m_Modules.Remove( ser );
		}

		public static void RemoveModule( Serial ser, Module mod )
		{
			if( m_Modules.ContainsKey( ser ) )
				((ModuleList)m_Modules[ ser ]).Remove( mod );
		}

		public static void RemoveModule( Serial ser, Type type )
		{
			if( m_Modules.ContainsKey( ser ) )
				((ModuleList)m_Modules[ ser ]).Remove( type );
		}

		public static Module GetModule( Serial ser, Type type )
		{
			if( m_Modules.ContainsKey( ser ) )
				return ((ModuleList)m_Modules[ ser ]).Get( type );

			return null;
		}

		public static ArrayList GetMobiles()
		{
			ArrayList list = new ArrayList();
			foreach( DictionaryEntry de in m_Modules )
			{
				if( ((Serial)de.Key).IsMobile )
				{
					Mobile m = World.FindMobile( (Serial)de.Key );
					if( m != null && !m.Deleted )
						list.Add( m );
				}
			}

			return list;
		}

		public static ArrayList GetItems()
		{
			ArrayList list = new ArrayList();
			foreach( DictionaryEntry de in m_Modules )
			{
				if( ((Serial)de.Key).IsItem )
				{
					Item i = World.FindItem( (Serial)de.Key );
					if( i != null && !i.Deleted )
						list.Add( i );
				}
			}

			return list;
		}

		private object[] Params;
		private ArrayList e_List;
		private ArrayList m_List;
		private Module    m_Module;

		public override void Gump( Mobile from, Gump gump, object[] subParams )
		{
			gump.AddButton( 190, 40, 2445, 2445, 101, GumpButtonType.Reply, 0 );
			gump.AddLabel(  204, 42, 1153, "List Mobiles" );
			gump.AddButton( 310, 40, 2445, 2445, 102, GumpButtonType.Reply, 0 );
			gump.AddLabel(  331, 42, 1153, "List Items" );
			gump.AddButton( 430, 40, 2445, 2445, 103, GumpButtonType.Reply, 0 );
			gump.AddLabel(  450, 42, 1153, "List Types" );
//			gump.AddButton( 190, 70, 2445, 2445, 104, GumpButtonType.Reply, 0 );
//			gump.AddLabel(  208, 72, 1153, "Add Module" );
//			gump.AddButton( 310, 70, 2445, 2445, 105, GumpButtonType.Reply, 0 );
//			gump.AddLabel(  326, 72, 1153, "Edit Module" );
//			gump.AddButton( 430, 70, 2445, 2445, 106, GumpButtonType.Reply, 0 );
//			gump.AddLabel(  439, 72, 1153, "Delete Module" );

			if( subParams == null )
			{
				gump.AddHtml( 215, 15, 300,  25, "<basefont size=7 color=white><center>Central Memory</center></font>", false, false );
				gump.AddHtml( 140, 95, 450, 250, "<basefont color=white><center>Welcome to the Central Memory Admin Gump!</center><br>With this gump, you can see a list of all entries that the CM contains.  You can add new Modules or modify or delete existing Modules.<br><br>Make your selection from the top buttons, either List Mobiles or Items.  This will bring up a list of all Mobiles or Items that the CM is keeping track of.<br><br>You may then select one of the entries to list the Modules that are stored to that entry.  You can then add, modify or remove modules to that entry.</font>", false, false );
				return;
			}

			Params = subParams;

			if( subParams[0] is int && (int)subParams[0] == -2 )
			{//Mobiles
				gump.AddLabel( 120, 95, 1153, "Listing all Mobiles:" );

				e_List = GetMobiles();
				if( e_List == null || e_List.Count == 0 )
					return;

				int p = 0;
				if( subParams.Length == 2 && subParams[1] is int )
					p = (int)subParams[1];

				if( p < 0 )
					p = 0;


				if( p > 0 )
					gump.AddButton( 120, 332, 4014, 4015, 104, GumpButtonType.Reply, 0 );
				if( (p+1)*21 <= e_List.Count )
					gump.AddButton( 540, 332, 4005, 4006, 105, GumpButtonType.Reply, 0 );

				for( int i = p*21, r = 0, c = 0; i < e_List.Count; i++ )
				{
					Mobile m = (Mobile)e_List[i];
					if( m == null )
						continue;
					gump.AddButton( 120+c*155, 125+r*30, 2501, 2501, 1000+i, GumpButtonType.Reply, 0 );
					gump.AddLabel(  130+c*155, 126+r*30, 1153, (m.Name==null?m.Serial.ToString():m.Name) );
				}
			}

			else if( subParams[0] is int && (int)subParams[0] == -3 )
			{//Items
				gump.AddLabel( 120, 95, 1153, "Listing all Items:" );

				e_List = GetItems();
				if( e_List == null || e_List.Count == 0 )
					return;

				int p = 0;
				if( subParams.Length == 2 && subParams[1] is int )
					p = (int)subParams[1];

				if( p < 0 )
					p = 0;

				if( p > 0 )
					gump.AddButton( 120, 332, 4014, 4015, 104, GumpButtonType.Reply, 0 );
				if( (p+1)*21 <= e_List.Count )
					gump.AddButton( 540, 332, 4005, 4006, 105, GumpButtonType.Reply, 0 );

				for( int i = p*21, r = 0, c = 0; i < e_List.Count; i++ )
				{
					Item m = (Item)e_List[i];
					if( m == null )
						continue;
					gump.AddButton( 120+c*155, 125+r*30, 2501, 2501, 1000+i, GumpButtonType.Reply, 0 );
					gump.AddLabel(  130+c*155, 126+r*30, 1153, (m.Name==null?m.Serial.ToString():m.Name) );
				}
			}

			else if( subParams[0] is Serial )
			{//List the Modules for that serial
				Serial s = (Serial)subParams[0];
				if( !m_Modules.Contains( s ) )
				{
					gump.AddLabel( 120, 95, 1153, "This entity no longer exists in the Central Memory!" );
					return;
				}

				ModuleList ml = (ModuleList)m_Modules[s];
				if( ml == null || ml.Count == 0 )
				{
					gump.AddLabel( 120, 95, 1153, "This entity has no Modules!" );
					Remove( s );
					return;
				}

				string name = "";
				if( s.IsMobile )
					name = World.FindMobile( s ).Name;
				else if( s.IsItem )
					name = World.FindItem( s ).Name;

				if( name == null || name.Length == 0 )
					name = s.ToString();

				gump.AddLabel( 120, 95, 1153, String.Format( "Listing all Modules for {0}:", name ) );

				m_List = new ArrayList( ml.Values );
				if( m_List == null || m_List.Count == 0 )
					return;

				int p = 0;
				if( subParams.Length == 3 && subParams[2] is int )
					p = (int)subParams[2];

				if( p < 0 )
					p = 0;
				if( p*21 >= m_List.Count )
					p = m_List.Count-21;

				if( p > 0 )
					gump.AddButton( 120, 332, 4014, 4015, 104, GumpButtonType.Reply, 0 );
				if( (p+1)*21 <= m_List.Count )
					gump.AddButton( 540, 332, 4005, 4006, 105, GumpButtonType.Reply, 0 );

				gump.AddButton( 331, 332, 4008, 4009, 106, GumpButtonType.Reply, 0 );

				for( int i = p*21, r = 0, c = 0; i < m_List.Count; i++ )
				{
					Module m = (Module)m_List[i];
					if( m == null )
						continue;

					gump.AddButton( 120+c*155, 125+r*30, 2501, 2501, 1000+i, GumpButtonType.Reply, 0 );
					gump.AddLabel(  130+c*155, 126+r*30, 1153, (m.Name().Length==0?m.Owner.ToString():m.Name()) );
				}
			}
		}

		public override void Help( Mobile from, Gump gump )
		{
		}

/* ID's
101   = Button	List Mobiles
102   = Button	List Items
103   = Button	List Types
104   = Button	Previous
105   = Button	Next
106   = Button	Back to List
1000+ = Button	Selections
 */
		public override void OnResponse( NetState state, RelayInfo info, object[] subParams )
		{
			if( !Running || info.ButtonID == 0 )
				return;

			//List Mobiles
			if( info.ButtonID == 101 )
				subParams = new object[1]{-2};

			//List Items
			else if( info.ButtonID == 102 )
				subParams = new object[1]{-3};

			else if( info.ButtonID == 104 )
			{//Previous
				if( Params[0] is Serial && Params.Length == 3 && Params[2] is int )
					subParams = new object[3]{Params[0], Params[1], (int)Params[2]-1};
				else if( Params.Length == 2 && Params[1] is int )
					subParams = new object[2]{Params[0], (int)Params[1]-1};
			}

			else if( info.ButtonID == 105 )
			{//Next
				if( Params[0] is Serial && Params.Length == 3 && Params[2] is int )
					subParams = new object[3]{Params[0], Params[1], (int)Params[2]+1};
				else if( Params.Length == 2 && Params[1] is int )
					subParams = new object[2]{Params[0], (int)Params[1]+1};
			}

			else if( info.ButtonID == 106 && Params[0] is Serial )
			{//Back to List
				Serial s = (Serial)Params[0];
				if( s.IsMobile && Params.Length == 2 )
					subParams = new object[2]{-2, Params[1]};
				else if( s.IsItem && Params.Length == 2 )
					subParams = new object[2]{-3, Params[1]};
			}

			//Perform Selection
			else if( info.ButtonID >= 1000 )
			{
				if( subParams[0] is Serial )
				{
					if( info.ButtonID-1000 < 0 || info.ButtonID-1000 >= m_List.Count )
						return;

					if( m_List[info.ButtonID-1000] is Module )
					{
						Module m = m_List[info.ButtonID-1000] as Module;
						if( m == null )
							return;

						m_Module = m;
						Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( SendEMG ), state.Mobile );
					}
				}

				else
				{
					if( info.ButtonID-1000 < 0 || info.ButtonID-1000 >= e_List.Count )
						return;

					if( e_List[info.ButtonID-1000] is Mobile )
					{
						Mobile m = e_List[info.ButtonID-1000] as Mobile;
						if( m == null )
							return;
						subParams = new object[2]{m.Serial, 0};
					}
					else if( e_List[info.ButtonID-1000] is Item )
					{
						Item i = e_List[info.ButtonID-1000] as Item;
						if( i == null )
							return;
						subParams = new object[2]{i.Serial, 0};
					}
				}
			}

			state.Mobile.SendGump( new ACCGump( state.Mobile, this.ToString(), subParams ) );
		}

		private void SendEMG( object state)
		{
			Mobile m = state as Mobile;
			if( m == null || m.Deleted || m_Module == null )
				return;

			m.SendMessage( "Sent EMG for {0}", m_Module.Name() );
			//m.SendGump( new EditModuleGump( m_Module ) );
		}

		public override void Save( GenericWriter idx, GenericWriter tdb, GenericWriter writer )
		{
			Flush();

			ArrayList fullList = new ArrayList();
			foreach( ModuleList ml in m_Modules.Values )
			{
				foreach( Module m in ml.Values )
				{
					fullList.Add( m );
				}
			}

			idx.Write( (int)fullList.Count );
			foreach( Module m in fullList )
			{
				Type t = m.GetType();
				long start = writer.Position;
				idx.Write( (int)m.m_TypeRef );
				idx.Write( (int)m.Owner );
				idx.Write( (long)start );

				m.Serialize( writer );

				idx.Write( (int) (writer.Position - start) );
			}

			tdb.Write( (int)m_Types.Count );
			for( int i = 0; i < m_Types.Count; ++i )
				tdb.Write( ((Type)m_Types[i]).FullName );
		}

		public override void Load( BinaryReader idx, BinaryReader tdb, BinaryFileReader reader )
		{
			object[] ctorArgs = new object[1];
			Type[] ctorTypes = new Type[1]{ typeof( Serial ) };
			ArrayList modules = new ArrayList();
			m_Modules = new Hashtable();

			int count = tdb.ReadInt32();
			ArrayList types = new ArrayList( count );
			for( int i = 0; i < count; ++i )
			{
				string typeName = tdb.ReadString();
				Type t = ScriptCompiler.FindTypeByFullName( typeName );
				if( t == null )
				{
					Console.WriteLine( "Type not found: {0}, remove?", typeName );
					if( Console.ReadLine() == "y" )
					{
						types.Add( null );
						continue;
					}
					throw new Exception( String.Format( "Bad type '{0}'", typeName ) );
				}

				ConstructorInfo ctor = t.GetConstructor( ctorTypes );
				if( ctor != null )
					types.Add( new object[]{ ctor, null } );
				else
					throw new Exception( String.Format( "Type '{0}' does not have a serialization constructor", t ) );
			}

			int moduleCount = idx.ReadInt32();

			for( int i = 0; i < moduleCount; ++i )
			{
				int  typeID = idx.ReadInt32();
				int  serial = idx.ReadInt32();
				long pos    = idx.ReadInt64();
				int  length = idx.ReadInt32();

				object[] objs = (object[])types[typeID];
				if( objs == null )
					continue;

				Module m = null;
				ConstructorInfo ctor = (ConstructorInfo)objs[0];
				string typeName = (string)objs[1];

				try
				{
					ctorArgs[0] = (Serial)serial;
					m = (Module)(ctor.Invoke( ctorArgs ));
				}
				catch
				{
				}

				if( m != null )
				{
					modules.Add( new ModuleEntry( m, typeID, typeName, pos, length ) );
					AddModule( m );
				}
			}

			bool failedModules = false;
			Type failedType = null;
			Exception failed = null;
			int failedTypeID = 0;

			for( int i = 0; i < modules.Count; ++i )
			{
				ModuleEntry entry = (ModuleEntry)modules[i];
				Module m = (Module)entry.Object;

				if( m != null )
				{
					reader.Seek( entry.Position, SeekOrigin.Begin );

					try
					{
						m.Deserialize( reader );

						if( reader.Position != (entry.Position + entry.Length) )
							throw new Exception( String.Format( "Bad serialize on {0}", m.GetType() ) );
					}
					catch( Exception e )
					{
						modules.RemoveAt( i );

						failed = e;
						failedModules = true;
						failedType = m.GetType();
						failedTypeID = entry.TypeID;

						break;
					}
				}
			}

			if( failedModules )
			{
				Console.WriteLine( "An error was encountered while loading a Module of Type: {0}", failedType );
				Console.WriteLine( "Remove this type of Module? (y/n)" );
				if( Console.ReadLine() == "y" )
				{
					for( int i = 0; i < modules.Count; )
					{
						if( ((ModuleEntry)modules[i]).TypeID == failedTypeID )
							modules.RemoveAt( i );
						else
							++i;
					}

					SaveIndex( modules );
				}

				Console.WriteLine( "After pressing return an exception will be thrown and the server will terminate" );
				Console.ReadLine();

				throw new Exception( String.Format( "Load failed (type={0})", failedType ), failed );
			}
		}

		private void SaveIndex( ArrayList list )
		{
			string path = "";
			if( CentralMemory.Running )
			{
				if( !Directory.Exists( "ACC Backups/Central Memory/" ) )
					Directory.CreateDirectory( "ACC Backups/Central Memory/" );
				path = "ACC Backups/Central Memory/Central Memory.idx";
			}
			else
			{
				if( !Directory.Exists( "Saves/ACC/Central Memory/" ) )
					Directory.CreateDirectory( "Saves/ACC/Central Memory/" );
				path = "Saves/ACC/Central Memory/Central Memory.idx";
			}

			using ( FileStream idx = new FileStream( path, FileMode.Create, FileAccess.Write, FileShare.None ) )
			{
				BinaryWriter idxWriter = new BinaryWriter( idx );

				idxWriter.Write( list.Count );
				for( int i = 0; i < list.Count; ++i )
				{
					IEntityMod e = (IEntityMod)list[i];

					idxWriter.Write( e.TypeID );
					idxWriter.Write( e.Serial );
					idxWriter.Write( e.Position );
					idxWriter.Write( e.Length );
				}

				idxWriter.Close();
			}
		}

		private interface IEntityMod
		{
			Serial Serial{ get; }
			int TypeID{ get; }
			long Position{ get; }
			int Length{ get; }
			object Object{ get; }
		}

		private sealed class ModuleEntry : IEntityMod
		{
			private Module m_Module;
			private int m_TypeID;
			private string m_TypeName;
			private long m_Position;
			private int m_Length;

			public object Object{ get{ return m_Module; } }
			public Serial Serial{ get{ return m_Module == null ? Serial.MinusOne : m_Module.Owner; } }
			public int TypeID{ get{ return m_TypeID; } }
			public string TypeName{ get{ return m_TypeName; } }
			public long Position{ get{ return m_Position; } }
			public int Length{ get{ return m_Length; } }

			public ModuleEntry( Module module, int typeID, string typeName, long pos, int length )
			{
				m_Module = module;
				m_TypeID = typeID;
				m_TypeName = typeName;
				m_Position = pos;
				m_Length = length;
			}
		}
	}
}