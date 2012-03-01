using System;
using System.IO;
using System.Collections;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using System.Xml;
// -- TMSS 4.0 -- CORE FILES --
//Computer meus nefandus est.
//version: 3.0
namespace Server.TMSS
{
	//generates and reads .tms files.
	public class SaveSettings
	{
		#region SaveSettings
		public static void SaveSkillSettings()
		{
			if (!Directory.Exists("TMSS"))
				Directory.CreateDirectory("TMSS");

			string FileName = "skillsave.tms";

			string path = @"TMSS/" + FileName;

			DateTime start = DateTime.Now;

			Console.Write(" - //4// - Saving TMSS Settings...");
			if (File.Exists(path))
				File.Delete(path);

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.IndentChars = "	";
			XmlWriter writer = XmlWriter.Create(path, settings);
			try
			{
				//Must I tell you not to mess with this?

				#region Variables

				writer.WriteStartElement("TMSS_Save");
				SaveSettings.WriteElement( "IsSharded", SkillSettings.IsSharded, 0, writer );
				SaveSettings.WriteElement( "HasRun", SkillSettings.HasRun, 0, writer );

				SaveSettings.WriteElement( "ShardName", SkillSettings.ShardName, 1, writer );
				SaveSettings.WriteElement( "NotYoursMessage", SkillSettings.NotYoursMessage, 1, writer );
				SaveSettings.WriteElement( "HowToUseMessage", SkillSettings.HowToUseMessage, 1, writer );
				SaveSettings.WriteElement( "NoTicketMessage", SkillSettings.NoTicketMessage, 1, writer );
				SaveSettings.WriteElement( "Shard", SkillSettings.Shard, 1, writer );
				SaveSettings.WriteElement( "NoShard", SkillSettings.NoShard, 1, writer );

				SaveSettings.WriteElement( "SkillHue", SkillSettings.SkillHue, 2, writer );
				SaveSettings.WriteElement( "StatHue", SkillSettings.StatHue, 2, writer );
				SaveSettings.WriteElement( "CenterHue", SkillSettings.CenterHue, 2, writer );
				
				SaveSettings.WriteElement( "CCSkinName", SkillSettings.CCSkinName, 1, writer );
				SaveSettings.WriteElement( "CCProfileName", SkillSettings.CCProfileName, 1, writer );
				SaveSettings.WriteElement( "ControlSkinName", SkillSettings.ControlSkinName, 1, writer );

				SaveSettings.WriteElement( "GumpControlLevel", (int)SkillSettings.GumpControlLevel, 2, writer );
				SaveSettings.WriteElement("AdminControlLevel", (int)SkillSettings.AdminAccessLevel, 2, writer);
				writer.WriteEndElement();

				#endregion

				writer.Close();
				Console.WriteLine("done.");
				TimeSpan end = DateTime.Now - start;
			}
			catch (Exception err)
			{
				Console.WriteLine("failed. Exception: " + err);
				writer.Close();
			}
		}
		internal static void WriteElement(string elename, object elevalue, int eletype, XmlWriter writer )
		{
			switch (eletype)
			{
					//bool
				case 0:
					writer.WriteStartElement(elename);
					writer.WriteValue( (bool)elevalue );
					writer.WriteEndElement();
					break;
					//string
				case 1:
					writer.WriteStartElement(elename);
					writer.WriteValue((string)elevalue);
					writer.WriteEndElement();
					break;
					//int
				case 2:
					writer.WriteStartElement(elename);
					writer.WriteValue((int)elevalue);
					writer.WriteEndElement();
					break;
			}
		}
		#endregion

		#region LoadSettings
		public static bool LoadSkillSettings( )
		{			
			if( !Directory.Exists("TMSS"))
			{
                SkillSettings.DoTell("Save directory does not exist. It will be created.");
				return false;
			}
				
			string FileName = "skillsave.tms";

			string path = @"TMSS/"+FileName;
			DateTime start = DateTime.Now;
			if( !File.Exists( path ) )
			{
				return false;
			}
			Console.Write(" - //4// - SkillSettings: Loading...");
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			XmlReader reader = XmlReader.Create(path, settings);
			try
			{				
				//Or this!
				reader.ReadStartElement("TMSS_Save");
				#region VariablesLoad				
						SkillSettings.IsSharded = reader.ReadElementContentAsBoolean();
						SkillSettings.HasRun = reader.ReadElementContentAsBoolean();

						SkillSettings.ShardName = reader.ReadElementContentAsString();
						SkillSettings.NotYoursMessage = reader.ReadElementContentAsString();
						SkillSettings.HowToUseMessage = reader.ReadElementContentAsString();
						SkillSettings.NoTicketMessage = reader.ReadElementContentAsString();
						SkillSettings.Shard = reader.ReadElementContentAsString();
						SkillSettings.NoShard = reader.ReadElementContentAsString();

						SkillSettings.SkillHue = reader.ReadElementContentAsInt();
						SkillSettings.StatHue = reader.ReadElementContentAsInt();
						SkillSettings.CenterHue = reader.ReadElementContentAsInt();
						
						SkillSettings.CCSkinName = reader.ReadElementContentAsString();
						SkillSettings.CCProfileName = reader.ReadElementContentAsString();
						SkillSettings.ControlSkinName = reader.ReadElementContentAsString();
						
						SkillSettings.GumpControlLevel = getLevelByInt( reader.ReadElementContentAsInt() );
						SkillSettings.AdminAccessLevel = getLevelByInt(reader.ReadElementContentAsInt());
				#endregion

				reader.Close();
				TimeSpan now = DateTime.Now - start;
				Console.WriteLine("done ({0:F1} seconds)", (DateTime.Now - start).TotalSeconds);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine("failed. Exception: " + e);
				reader.Close();
				return false;
			}			
		}
		#endregion

		private static AccessLevel getLevelByInt(int lvl)
		{
			switch (lvl)
			{
				case 0:
					return AccessLevel.Counselor;
				case 1:
					return AccessLevel.GameMaster;
				case 2:
					return AccessLevel.Developer;
				case 3:
					return AccessLevel.Seer;
				case 4:
					return AccessLevel.Administrator;
				case 5:
					return AccessLevel.Owner;
				default:
					return AccessLevel.GameMaster;
			}
		}
	}
}