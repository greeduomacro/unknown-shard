using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using System.IO;
using System.Xml;

namespace Server.Bestiary
{
	public static class Bestiary
	{
		/// <summary>
		/// Maps typeof mobile to its BeastInfo
		/// </summary>
		public static Dictionary<Type, BeastInfo> TypeRegistry = new Dictionary<Type, BeastInfo> ();

		/// <summary>
		/// Set to your shard's name
		/// </summary>
		public const string ShardName = "Name";	

		/// <summary>
		/// Heart and soul of the system, first it analyzes all mobiles and then generates a webpage 
		/// from the result.
		/// </summary>
		public static void Generate()
		{
			Alphabetctionary<List<MobileEntry>> entries = new Alphabetctionary<List<MobileEntry>>();
			List<MobileEntry>           all             = new List<MobileEntry>();

			entries.Initialize();

			foreach( Type type in TypeRegistry.Keys )
			{
				MobileEntry entry = new MobileEntry( type );

				if( !entry.GuessEmpty ) // TODO: log empty types so they can be excluded from the config file.
				{					
					entries[TypeRegistry[type].Name].Add( entry );					
				}
			}
			
			// this can't be done in the loop up there 'cause we need :all: to be sorted
			foreach( List<MobileEntry> var in entries )
			{
				all.AddRange( var );	
			}
			
			using( StreamWriter writer = new StreamWriter( Path.Combine( "./Bestiary/", "index.html" ) ) )
			{		
				int 	index = 0;
				char letter = 'a';

				foreach( List<MobileEntry> var in entries )
				{
                    if (var.Count != 0)
					{				
						writer.WriteLine( "<font size=\"4\">{0}</font> ({1} {2})", letter++, var.Count, (var.Count == 1 ? "mobile" : "mobiles") );
						writer.WriteLine( "	<div style=\"padding-left: 15px\">" );
						
						foreach( MobileEntry entry in var )
						{
							writer.WriteLine( "		<a href=\"./content/mobile.{0}.html\">{1}</a><br />", entry.MasterType.Name, entry.Name );
							
							if ( index != 0 && all.Count != 1 )
							{
								entry.PrevLink = string.Format( "		<a href=\"mobile.{0}.html\" style=\"font-weight: bold; font-size: 11px; color: #ccc\">&lt; {1}</a>", all[ index - 1 ].MasterType.Name, all[ index - 1 ].Name );
							}
							
							if ( ( index + 1) != all.Count )
							{
								entry.NextLink = string.Format( "		<a href=\"mobile.{0}.html\" style=\"font-weight: bold; font-size: 11px; color: #ccc\">{1} &gt;</a>", all[ index + 1 ].MasterType.Name, all[ index + 1 ].Name );
							}
							
							using( StreamWriter entryWriter = new StreamWriter( Path.Combine( "./Bestiary/content/", string.Format( "mobile.{0}.html", entry.MasterType.Name ) ) ) )	
							{ 
								entryWriter.Write( entry.Html );
							}
							
							++index;
						}
						
						writer.WriteLine( "	</div>" );
						writer.WriteLine( "	<hr noshade />" );
					}
				}
			}		
			// all mobiles, unless they're empty, have been indexed. Our job's done!
		}
		
		/// <summary>
		/// Should we use the bitmap fix system for inconsistent bodyIds?
		/// </summary>
		public static bool UseFixes;

		/// <summary>
		/// Read the XML config file.
		/// </summary>
		public static void ReadXMLList()
		{
			string filePath = Path.Combine( "Data/Bestiary", "data.xml" );

			if( !File.Exists( filePath ) )
				return;

			XmlDocument doc = new XmlDocument();
			doc.Load( filePath );

			XmlElement root = doc[ "mobiles" ];
			
			UseFixes = bool.Parse( Utility.GetAttribute( root, "useFixes",  "false") );

			foreach( XmlElement mobile in root.GetElementsByTagName( "mobile" ) )
			{
				string typeName = Utility.GetAttribute( mobile, "type", null );
				Type t = Type.GetType( typeName );
				
				if( t == null )
				{
					Console.WriteLine("Mobile type: {0} doesn't exist. Skipping.", typeName);
					continue;
				}
				
				string name = Utility.GetAttribute( mobile, "name", "empty" );
				string background = Utility.GetAttribute( mobile, "background", null );
		
				TypeRegistry.Add( t, new BeastInfo( name, background ) );
			}
		}

		/// <summary>
		/// Server invoked method; reads config file and then generates all the shiny stuff.
		/// </summary>
		public static void Initialize()
		{
			ReadXMLList();
			Generate();
		}
	}
}