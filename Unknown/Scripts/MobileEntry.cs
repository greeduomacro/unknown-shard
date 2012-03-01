//#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Server.Mobiles;
using Server.Items;

using Ultima;
namespace Server.Bestiary
{
	public enum MetadataToken
	{
		String		= 0x07000000,

		MemberRef	= 0x0A000000,
		MethodRef	= 0x06000000,
		
		Method		= MemberRef | MethodRef
	};

	public delegate void MethodHandler( MobileEntry m, int paramCount );

	public sealed class MobileEntry
	{
		#region [Static]
		private static Bitmap m_BorderImage			= new Bitmap( "Data/Bestiary/layer_top.png" );
		private static Bitmap m_Background			= new Bitmap( "Data/Bestiary/layer_bottom.jpg" );
		private static Bitmap m_WaterMark			= new Bitmap( "Data/Bestiary/watermark.png" );
		private static EncoderParameters m_EncoderParameter = new EncoderParameters();
		private static StringList m_Cliloc			= new StringList( "enu" );
		private static ImageCodecInfo m_Encoder;
		private static Dictionary<string, string> m_Templates = new Dictionary<string, string>();

		internal static ImageAttributes imgAttrs = new ImageAttributes();
		
		internal static float[][] alphaBlendMatrix = new float[][] {
				new float[] { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f },	// Red		100%
				new float[] { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f },	// Green	100%
				new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f },	// Blue		100%
				new float[] { 0.0f, 0.0f, 0.0f, .075f, 0.0f },	// Alpha	7.5%
				new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f }	// Gamma	100%
			};

		private static Dictionary<string, MethodHandler> m_Handlers = new Dictionary<string, MethodHandler>();
		private static MethodHandler m_BlankHandler = delegate( MobileEntry m, int paramCount )	{/*supress the unregistered handler message in debug mode, TODO!*/};

		// gets the hue to be applied from a datafile, from Pandora's Box
		public static Hue GetHue( int index )
		{
			string huesFile = Core.FindDataFile( "hues.mul" );

			if( ( huesFile == null ) || !File.Exists( huesFile ) )
			{
				return null;
			}

			Hue hue = null;

			using( FileStream stream = new FileStream( huesFile, FileMode.Open, FileAccess.Read, FileShare.Read ) )
			{
				BinaryReader reader = new BinaryReader( stream );

				int offset = index / 8;
				int remainder = index % 8;
				int range = ( offset * 0x2c4 ) + ( remainder * 0x58 );

				if( ( range + 0x58 ) < stream.Length )
				{
					stream.Seek( (long)range, SeekOrigin.Begin );
					hue = new Hue( index, reader );
				}
			}
			return hue;
		}
		
		static MobileEntry()
		{
			#region [Method handlers]
			m_Handlers[ "set_Body" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_BodyId = m.Pop<int>();
					};

			m_Handlers[ "SetStr" ] =
					delegate( MobileEntry m, int paramCount )
					{
						if( paramCount == 2 )
						{
							m.m_Str[ 0 ] = m.Pop<int>();
							m.m_Str[ 1 ] = m.Pop<int>();
						}
						else
						{
							m.m_Str[ 0 ] = m.m_Str[ 1 ] = m.Pop<int>();
						}
					};

			m_Handlers[ "SetDex" ] =
					delegate( MobileEntry m, int paramCount )
					{
						if( paramCount == 2 )
						{
							m.m_Dex[ 0 ] = m.Pop<int>();
							m.m_Dex[ 1 ] = m.Pop<int>();
						}
						else
						{
							m.m_Dex[ 0 ] = m.m_Dex[ 1 ] = m.Pop<int>();
						}
					};

			m_Handlers[ "SetInt" ] =
					delegate( MobileEntry m, int paramCount )
					{
						if( paramCount == 2 )
						{
							m.m_Int[ 0 ] = m.Pop<int>();
							m.m_Int[ 1 ] = m.Pop<int>();
						}
						else
						{
							m.m_Int[ 0 ] = m.m_Int[ 1 ] = m.Pop<int>();
						}
					};

			m_Handlers[ "SetDamageType" ] =
					delegate( MobileEntry m, int paramCount )
					{
						int value = m.Pop<int>();
						int type = m.Pop<int>();

						switch( type )
						{
							case 0:
								m.m_DamagePhysical = value;
								break;
							case 1:
								m.m_DamageFire = value;
								break;
							case 2:
								m.m_DamageCold = value;
								break;
							case 3:
								m.m_DamagePoison = value;
								break;
							case 4:
								m.m_DamageEnergy = value;
								break;
							default:
								break;
						}
					};

			m_Handlers[ "SetResistance" ] =
					delegate( MobileEntry m, int paramCount )
					{
						int max = m.Pop<int>();
						int min = max;

						if( paramCount == 3 )
						{
							min = m.Pop<int>();
						}

						int type = m.Pop<int>();

						switch( type )
						{
							case 0:
								m.m_Physical = new int[] { min, max };
								break;
							case 1:
								m.m_Fire = new int[] { min, max };
								break;
							case 2:
								m.m_Cold = new int[] { min, max };
								break;
							case 3:
								m.m_Poison = new int[] { min, max };
								break;
							case 4:
								m.m_Energy = new int[] { min, max };
								break;
							default:
								break;
						}
					};

			m_Handlers[ "SetSkill" ] =
					delegate( MobileEntry m, int paramCount )
					{
						double max = m.Pop<double>();
						double min = max;

						if( paramCount == 3 )
						{
							min = m.Pop<double>();
						}

						int type = m.Pop<int>();

						m.m_Skills[ type ] = new double[] { min, max };
					};
				
			m_Handlers[ "set_Fame" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_Fame = m.Pop<int>(  );
					};

			m_Handlers[ "set_VirtualArmor" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_VirtualArmor = m.Pop<int>(  );
					};

			m_Handlers[ "set_Title" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_Title = m.Pop<string>(  );
					};

			m_Handlers[ "set_Karma" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_Karma = m.Pop<int>(  );
					};

			m_Handlers[ "SetDamage" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_Damage[1] = m.Pop<int>(  );
						m.m_Damage[0] = m.Pop<int>();
					};

			m_Handlers[ "set_Hue" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_Hue = m.Pop<int>(  );						
					};

			m_Handlers[ "Utility::RandomDouble" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_Stack.Push( Utility.RandomDouble() );						
					};

			m_Handlers[ "Utility::RandomMinMax" ] =
					delegate( MobileEntry m, int paramCount )
					{
						if( paramCount == 2 )
						{
							m.m_Stack.Push( Utility.RandomMinMax( m.Pop<int>(), m.Pop<int>() ) );
						}						
					};

			m_Handlers[ "Utility::Random" ] =
					delegate( MobileEntry m, int paramCount )
					{
						if( paramCount == 1 )
						{
							m.m_Stack.Push( Utility.Random( m.Pop<int>() ) );
						}
						else if ( paramCount == 2 )
						{
							m.m_Stack.Push( Utility.Random( m.Pop<int>(), m.Pop<int>() ) );
						}
					};

			m_Handlers[ "Utility::RandomBool" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_Stack.Push( Utility.RandomBool() );
					};

			m_Handlers[ "set_MinTameSkill" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_MinToTame = m.Pop<double>();
					};

			m_Handlers[ "set_ControlSlots" ] =
					delegate( MobileEntry m, int paramCount )
					{
						m.m_ControlSlots = m.Pop<int>();
					};

			m_Handlers[ "BaseCreature::.ctor" ] =
					delegate( MobileEntry m, int paramCount )
					{
						double max = m.Pop<double>();
						double min = m.Pop<double>();

						int skip = m.Pop<int>();
						int rangePerception = m.Pop<int>();
						int fightMode = m.Pop<int>();

						m.m_Mode = ( (AIType)m.Pop<int>() ).ToString().Remove( 0, 3 );
					};

			m_Handlers[ "BaseMount::.ctor" ] =
					delegate( MobileEntry m, int paramCount )
					{
						double max = m.Pop<double>();
						double min = m.Pop<double>();

						int skip = m.Pop<int>();
						int rangePerception = m.Pop<int>();
						int fightMode = m.Pop<int>();

						m.m_Mode = ( (AIType)m.Pop<int>() ).ToString().Remove( 0, 3 );
						m.Pop<int>();
						m.m_BodyId = m.Pop<int>();
						m.Pop<string>();// name
					};

			m_Handlers[ "Container::DropItem" ] = m_BlankHandler;
			m_Handlers[ "Utility::RandomList" ] = m_BlankHandler;
			m_Handlers[ "set_Tamable" ] = m_BlankHandler;
			m_Handlers[ "SetHits" ] = m_BlankHandler;
			m_Handlers[ "AddItem" ] = m_BlankHandler;
			m_Handlers[ "set_SpeechHue" ] = m_BlankHandler;
			m_Handlers[ "set_Female" ] = m_BlankHandler;
			m_Handlers[ "Utility::AssignRandomHair" ] = m_BlankHandler;
			m_Handlers[ "Utility::RandomNeutralHue" ] = m_BlankHandler;
			m_Handlers[ "Utility::RandomSkinHue" ] = m_BlankHandler;
			m_Handlers[ "set_BaseSoundID" ] = m_BlankHandler;
			m_Handlers[ "SetMana" ] = m_BlankHandler;
			m_Handlers[ "set_Name" ] = m_BlankHandler;
			m_Handlers[ "PackItem" ] = m_BlankHandler;
			m_Handlers[ "PackArmor" ] = m_BlankHandler;
			m_Handlers[ "PackWeapon" ] = m_BlankHandler;
			m_Handlers[ "Body::op_Implicit" ] = m_BlankHandler;
			m_Handlers[ "Seed::RandomBonsaiSeed" ] = m_BlankHandler;
			#endregion

			ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

			// find the JPEG encoder.
			foreach( ImageCodecInfo encoder in encoders )
			{
				if( encoder.FormatDescription == "JPEG" )
				{
					m_Encoder = encoder;
					break;
				}
			}

			m_EncoderParameter.Param[ 0 ] = new EncoderParameter( System.Drawing.Imaging.Encoder.Quality, new long[ 1 ] { 0x46 } );
			imgAttrs.SetColorMatrix( new ColorMatrix( alphaBlendMatrix ), ColorMatrixFlag.Default, ColorAdjustType.Bitmap );

			m_Templates.Add( "tableTop", /*"/*<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n" +
													"<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"en\">\n" +
													"	<head>\n" +
													"		<title> Twilight-Zone :: Bestiary </title>\n" +
													"		<link rel=\"stylesheet\" type=\"text/css\" href=\"../style.css\" />\n" +
													"		<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n" +
													"	</head>\n" +
													"	<body bgcolor=\"#000000\">\n" +*/
													"		<center>\n" +
													"			<img src=\"../images/{0}.jpg\" border=\"0\" alt=\"{0}\" />\n" +
													"			<br />\n" +
													"			<br />\n" +
													"			<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"mobileEntry\">\n" );
			m_Templates.Add( "nameHeader", "				<tr>\n" +
													"					<td bgcolor=\"#cccccc\" colspan=\"2\" align=\"center\" style=\"padding: 2px; color: #000\">\n" +
													"						<b>{0}</b>\n" +
													"					</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "strenghtOneArg", "				<tr>\n" +
													"					<th>Strength: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "strenghtTwoArgs", "				<tr>\n" +
													"					<th>Strength: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "dexterityOneArg", "				<tr>\n" +
													"					<th>Dexterity: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "dexterityTwoArgs", "				<tr>\n" +
													"					<th>Dexterity: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "intelligenceOneArg", "				<tr>\n" +
													"					<th>Intelligence: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "intelligenceTwoArgs", "				<tr>\n" +
													"					<th>Intelligence: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "damageTypesHeader", "				<tr>\n" +
													"					<th valign=\"top\">Damage types: </th>\n" +
													"					<td>\n" );
			m_Templates.Add( "resistancesHeader", "				<tr>\n" +
													"					<th valign=\"top\">Resistances: </th>\n" +
													"					<td>\n" );
			m_Templates.Add( "damagePhysical", "						<div style=\"border: 1px solid #555; background-image: url('../physical.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damageFire", "						<div style=\"border: 1px solid #555; background-image: url('../fire.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damageCold", "						<div style=\"border: 1px solid #555; background-image: url('../cold.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damagePoison", "						<div style=\"border: 1px solid #555; background-image: url('../poison.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damageEnergy", "						<div style=\"border: 1px solid #555; background-image: url('../energy.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "endRow", "						<br />\n" +
													"					</td>\n" +
													"				</tr>" );
			m_Templates.Add( "minMaxDmgOneArg", "				<tr>\n" +
													"					<th>Damage: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "minMaxDmgTwoArgs", "				<tr>\n" +
													"					<th>Damage: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "mode", "				<tr>\n" +
													"					<th>Mode: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "fame", "				<tr>\n" +
													"					<th>Fame: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "karma", "				<tr>\n" +
													"					<th>Karma: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "slayer", "				<tr>\n" +
													"					<th>Slayer: </th>\n" +
													"					<td>\n" +
													"						<span style=\"color: #990000\">\n" +
													"							{0}\n" +
													"						</span>\n" +
													"					</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "armour", "				<tr>\n" +
													"					<th>Armour: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "minToTame", "				<tr>\n" +
										"					<th>Minimal taming: </th>\n" +
										"					<td>{0:F1}</td>\n" +
										"				</tr>\n" );
			m_Templates.Add( "slots", "				<tr>\n" +
										"					<th>Control slots: </th>\n" +
										"					<td>{0}</td>\n" +
										"				</tr>\n" );
			m_Templates.Add( "immunity", "				<tr>\n" +
							"					<th>Poison immunity: </th>\n" +
							"					<td>{0}</td>\n" +
							"				</tr>\n" );
			m_Templates.Add( "barding", "				<tr>\n" +
							"					<th>Barding: </th>\n" +
							"					<td>{0}</td>\n" +
							"				</tr>\n" );
			m_Templates.Add( "skillsHeader", "				<tr>\n" +
													"					<th>Skills: </th>\n" +
													"					<td>\n" );
			m_Templates.Add( "skillRow", "						<b>{0}</b>: {1}<br />\n" );
			m_Templates.Add( "tableFooter", "</table>\n");
												/*	"	</body>\n" +
													"</html>" );*/
		}
		#endregion

		#region [Fields]
		private Module m_Module;
		private Type m_MasterType;
		private int[] m_Str = new int[ 2 ];
		private int[] m_Dex = new int[ 2 ];
		private int[] m_Int = new int[ 2 ];
		private int[] m_Damage = new int[ 2 ];
		private int[] m_Physical = new int[ 2 ];
		private int[] m_Fire = new int[ 2 ];
		private int[] m_Cold = new int[ 2 ];
		private int[] m_Poison = new int[ 2 ];
		private int[] m_Energy = new int[ 2 ];
		private int m_DamagePhysical;
		private int m_DamageFire;
		private int m_DamageCold;
		private int m_DamagePoison;
		private int m_DamageEnergy;
		private int m_BodyId;
		private int m_Hue;
		private int m_Fame;
		private int m_Karma;
		private int m_VirtualArmor;
		private int m_ControlSlots;
		private int m_Barding;
		private double m_Difficulty;
		private double m_MinToTame;
		private string m_Title;
		private string m_Mode;
		private string m_Name;
		private string m_PrevLink, m_NextLink;
		private Poison m_Immunity;
		private SlayerEntry m_Slayer;
		private Stack m_Stack = new Stack();
		private Dictionary<int, double[]> m_Skills = new Dictionary<int, double[]>();
		#endregion

		#region [Properties]
		public string Name { get { return m_Name; } set { m_Name = value; } }
		
		public string PrevLink { get { return m_PrevLink; } set { m_PrevLink = value; } }
		public string NextLink { get { return m_NextLink; } set { m_NextLink = value; } }
		
		public Type MasterType { get { return m_MasterType; } set { m_MasterType = value; } }
		
		// returns the final html code
		public string Html
		{
			get
			{
				StringBuilder sb = new StringBuilder( 0x2000 );

				#region [Header]
				sb.AppendFormat( m_Templates[ "tableTop" ], m_MasterType.Name );
				sb.AppendFormat( m_Templates[ "nameHeader" ], m_Name );
				#endregion

				#region [Stats output]
				if( m_Str[ 0 ] != m_Str[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "strenghtTwoArgs" ], m_Str[ 1 ], m_Str[ 0 ] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "strenghtOneArg" ], m_Str[ 0 ] );
				}

				if( m_Dex[ 0 ] != m_Dex[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "dexterityTwoArgs" ], m_Dex[ 1 ], m_Dex[ 0 ] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "dexterityOneArg" ], m_Dex[ 0 ] );
				}

				if( m_Int[ 0 ] != m_Int[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "intelligenceTwoArgs" ], m_Int[ 1 ], m_Int[ 0 ] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "intelligenceOneArg" ], m_Int[ 0 ] );
				}
				#endregion

				#region [Damage Types]
				sb.Append( m_Templates[ "damageTypesHeader" ] );
				if( m_DamagePhysical != 0 )
					sb.AppendFormat( m_Templates[ "damagePhysical" ], m_DamagePhysical );
				if( m_DamageFire != 0 )
					sb.AppendFormat( m_Templates[ "damageFire" ], m_DamageFire );
				if( m_DamageCold != 0 )
					sb.AppendFormat( m_Templates[ "damageCold" ], m_DamageCold );
				if( m_DamagePoison != 0 )
					sb.AppendFormat( m_Templates[ "damagePoison" ], m_DamagePoison );
				if( m_DamageEnergy != 0 )
					sb.AppendFormat( m_Templates[ "damageEnergy" ], m_DamageEnergy );
				sb.Append( m_Templates[ "endRow" ] );
				#endregion

				#region [Resistances]
				sb.Append( m_Templates[ "resistancesHeader" ] );
				if( m_Physical[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damagePhysical" ], m_Physical[ 0 ] );
				if( m_Fire[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damageFire" ], m_Fire[ 0 ] );
				if( m_Cold[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damageCold" ], m_Cold[ 0 ] );
				if( m_Poison[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damagePoison" ], m_Poison[ 0 ] );
				if( m_Energy[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damageEnergy" ], m_Energy[ 0 ] );
				sb.Append( m_Templates[ "endRow" ] );
				#endregion

				#region [Some stuff]
				if( m_Damage[ 0 ] != m_Damage[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "minMaxDmgTwoArgs" ], m_Damage[ 0 ], m_Damage[1] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "minMaxDmgOneArg" ], m_Damage[1] );
				}

				sb.AppendFormat( m_Templates[ "mode" ], m_Mode );
				sb.AppendFormat( m_Templates[ "fame" ], m_Fame );
				sb.AppendFormat( m_Templates[ "karma" ], m_Karma );
				sb.AppendFormat( m_Templates[ "armour" ], m_VirtualArmor );

				if( m_Slayer != null )
				{
					sb.AppendFormat( m_Templates[ "slayer" ], m_Cliloc.Table[ m_Slayer.Title ] );
				}

				if( m_ControlSlots > 0 )
				{
					sb.AppendFormat( m_Templates[ "minToTame" ], m_MinToTame );
					sb.AppendFormat( m_Templates[ "slots" ], m_ControlSlots );
				}

				if( m_Immunity != null )
				{
					sb.AppendFormat( m_Templates[ "immunity" ], m_Immunity.ToString() );
				}

				StringBuilder bard = new StringBuilder( 0x400 );

				if( ( m_Barding & 4 ) != 0 )
				{
					bard.Append( "<b>Bard Immune</b><br />\n" );
				}
				else
				{
					bard.AppendFormat( "<b>Difficulty:</b> {0:F1}<br />\n", m_Difficulty );

					if( ( m_Barding & 1 ) != 0 )
					{
						bard.Append( "<b>Unprovokable</b><br />\n" );
					}

					if( ( m_Barding & 2 ) != 0 )
					{
						bard.Append( "<b>Uncalmable</b><br />\n" );
					}
				}

				sb.AppendFormat( m_Templates[ "barding" ], bard.ToString() );

				#endregion

				#region [Skills]
				sb.Append( m_Templates[ "skillsHeader" ] );
				List<int> keys = new List<int>( m_Skills.Keys );

				for( int i = 0; i < 5 && i < m_Skills.Count; i++ )
				{
					double[] skillVal = m_Skills[ keys[ i ] ];
					string skStrVal = "";

					if( skillVal[ 0 ] == skillVal[ 1 ] )
					{
						skStrVal = string.Format( "{0:F1}", skillVal[ 0 ] );
					}
					else
					{
						skStrVal = string.Format( "{0:F1} - {1:F1}", skillVal[ 0 ], skillVal[ 1 ] );
					}

					sb.AppendFormat( m_Templates[ "skillRow" ], SkillInfo.Table[ keys[ i ] ].Name, skStrVal );
				}
				sb.Append( m_Templates[ "endRow" ] );
				#endregion

				#region [Footer]
				sb.Append( m_Templates[ "tableFooter" ] );
				#endregion
			
				if( m_PrevLink != null )
				{
					sb.AppendFormat( "<span style=\"padding: 3px;border: 1px solid #555; background-color: #333; margin: 2px;\">{0}</span>", m_PrevLink );
				}
				
				if ( m_NextLink != null )
				{
                    sb.AppendFormat("&nbsp;&nbsp;&nbsp;<span style=\"padding: 3px;border: 1px solid #555; background-color: #333; margin: 2px;\">{0}</span>", m_NextLink);
				}
				
				sb.Append("</center><br /><br ?>");

				return sb.ToString();
			}
		}
		
		// Consider the entry being empty if it does have all of the following -zero-: bodyId, str, int or dex.
		public bool GuessEmpty
		{
			get
			{
				return ( 
					m_BodyId == 0 &&
					m_Str[1] == 0 && 
					m_Int[1] == 0 && 
					m_Dex[1] == 0 
				);
			}
		}
		#endregion

		public MobileEntry( Type type )
		{
			m_MasterType = type;
			m_Module = type.Module;
			m_Name = Bestiary.TypeRegistry[ m_MasterType ].Name;
			m_Slayer = this.SlayerGroup();

			ConstructorInfo ctor = this.HandleSpecialType( type );

			this.AnalyseILCode( ctor.GetMethodBody().GetILAsByteArray() );

			#region [Additional data]
			{
				BaseCreature bc = (BaseCreature)Activator.CreateInstance( type );
				if( bc.Unprovokable )
				{
					m_Barding |= 0x1;
				}
				if( bc.Uncalmable)
				{
					m_Barding |= 0x2;
				}
				if( bc.BardImmune )
				{
					m_Barding |= 0x4;
				}
				m_Immunity = bc.PoisonImmune;
				m_Difficulty = Items.BaseInstrument.GetBaseDifficulty( bc );
				bc.Delete();
			}
			#endregion

			if( m_BodyId != 0 )
			{
				GenerateImage();
			}
		}
		
		//----------------------------------------------------------------------------------------------------------------------
		// Predict that the last 0 or 1 pushed onto the stack being the value to be returned.  Returns false on error. Naughty me!
		//----------------------------------------------------------------------------------------------------------------------
		public bool GetBooleanValue( string methodName )
		{
			MethodInfo method = m_MasterType.GetMethod( methodName );
			
			if( method != null )
			{
				byte[] methodData = method.GetMethodBody().GetILAsByteArray();
				
				BinaryReader codeReader = new BinaryReader(
				   new MemoryStream( methodData )
			   	);
			   	
			   	bool lastCode = false;

				while( codeReader.PeekChar() >= 0 )
				{
					OpCode op = OPCodeCache.Hit( codeReader.ReadByte() );
					
					if ( op == OpCodes.Ldc_I4_1 )
					{
						lastCode = true;
					}
					else if ( op == OpCodes.Ldc_I4_0 )
					{
						lastCode = false;
					}
				}
				
				return lastCode;		
			}
			
			return false;
		}
		
		// some ctors may need extra care.
		private ConstructorInfo HandleSpecialType( Type type )
		{
			ConstructorInfo ctor = null;

			if( typeof( BaseMount ).IsAssignableFrom( type ) )
			{
				ctor = type.GetConstructor( new Type[] { typeof( string ) } );
			}

			return ( ctor ?? type.GetConstructor( Type.EmptyTypes ) );
		}

		// heart and soul, yay!
		private void AnalyseILCode( byte[] code )
		{
			BinaryReader codeReader = new BinaryReader(
				   new MemoryStream( code )
			   );

			while( codeReader.PeekChar() >= 0 )
			{
				OpCode op = OPCodeCache.Hit( codeReader.ReadByte() );

				if( op == OpCodes.Ldc_I4 )
				{
					m_Stack.Push( codeReader.ReadInt32() );
				}
				else if( op == OpCodes.Ldc_R8 )
				{
					m_Stack.Push( codeReader.ReadDouble() );
				}
				else if( op == OpCodes.Ldc_R4 )
				{
					m_Stack.Push( codeReader.ReadSingle() );
				}
				else if( op.Value > 0x15 && op.Value < 0x1F )
				{
					m_Stack.Push( op.Value - 0x16 );
				}
				else if( op == OpCodes.Ldc_I4_M1 )
				{
					m_Stack.Push( -1 );
				}
				else if( op == OpCodes.Ldc_I4_S )
				{
					m_Stack.Push( (int)codeReader.ReadByte() );
				}
				else if( op == OpCodes.Ldstr )
				{
					int stringDescriptor = codeReader.ReadInt32();

					if( MatchMetadata( stringDescriptor, MetadataToken.String ) ) // sanity check, am I really a string?
					{
						m_Stack.Push( m_Module.ResolveString( stringDescriptor ) );
					}
					else
					{
						m_Stack.Push( "(error - string value couldn't be resolved.)" );
					}
				}
				else if( op == OpCodes.Call || op == OpCodes.Callvirt )
				{
					int methodDescriptor = codeReader.ReadInt32();

					if( MatchMetadata( methodDescriptor, MetadataToken.Method ) ) // sanity check, am I really a method?
					{
						MethodBase mb = m_Module.ResolveMethod( methodDescriptor );

						if( (mb.DeclaringType.IsSubclassOf( typeof( Mobile ) ) || mb.DeclaringType == typeof( Mobile )) && !mb.IsConstructor )
						{
							Dispatch( mb.Name, mb.GetParameters().Length );
						}
						else
						{
							Dispatch( mb.Name, mb.DeclaringType.Name, mb.GetParameters().Length );
						}
					}
				}
				else
				{
					// all opcodes that push something onto the stack have been taken care of.
					// now we have to check whether the given opcode has an operand or not.
					// if so, we'll skip appropriate amount of bytes.
					
					OperandType operandType = op.OperandType;

					switch( operandType )
					{
						case OperandType.InlineNone:
							{
							}
							break;
						case OperandType.InlineR:
						case OperandType.InlineI8:
							{
								codeReader.ReadInt64();
							}
							break;
						case OperandType.InlineSwitch:
							{
								int switchBranches = codeReader.ReadInt32();

								while( switchBranches-- > 0 )
								{
									codeReader.ReadInt32();
								}
							}
							break;
						case OperandType.ShortInlineR:
						case OperandType.InlineType:
						case OperandType.InlineTok:
						case OperandType.InlineString:
						case OperandType.InlineSig:
						case OperandType.InlineMethod:
						case OperandType.InlineI:
						case OperandType.InlineField:
						case OperandType.InlineBrTarget:
							{
								codeReader.ReadInt32();
							}
							break;
						case OperandType.InlineVar:
							{
								codeReader.ReadInt16();
							}
							break;
						case OperandType.ShortInlineVar:
						case OperandType.ShortInlineI:
						case OperandType.ShortInlineBrTarget:
							{
								codeReader.ReadByte();
							}
							break;
					}
				}
			}
		}

		//----------------------------------------------------------------------------------
		// Pops the value of predicted type <T> outta the stack.
		// otherwise returns a default value.
		//----------------------------------------------------------------------------------
		private T Pop<T>()
		{
			if( m_Stack.Count > 0 )
			{
				object pop = m_Stack.Pop();

				if( pop is T )
				{
					return (T)pop;
				}				
			}

			return default( T );
		}

		// am I really what I'm expected to be, huh?
		private bool MatchMetadata( int descriptor, MetadataToken token )
		{
			return ( descriptor & (int)token ) != 0;
		}

		private SlayerEntry SlayerGroup()
		{
			foreach( SlayerGroup group in Server.Items.SlayerGroup.Groups )
			{
				if( Array.IndexOf<Type>( group.Super.Types, m_MasterType ) != -1 )
				{
					return group.Super;
				}

				foreach( SlayerEntry entry in group.Entries )
				{
					if( Array.IndexOf<Type>( entry.Types, m_MasterType ) != -1 )
					{
						return entry;
					}
				}
			}

			return null;
		}

		// dispatcher!
        private void Dispatch( string methodName, string typeName, int paramCount )
        {
            if (string.IsNullOrEmpty(typeName))
            {
                Dispatch(methodName, paramCount);
            }
            else
            {
				if( typeName != "TimeSpan" ||
					typeName != "DateTime" ||
					typeName != "Map"	   ||
					typeName != "NameList" ||
					typeName != "Loot" ) // ignore several types
				{
					Dispatch( string.Concat( typeName, "::", methodName ), paramCount );
				}
            }
        }

		// switch witch, sandwich .. am I nuts?
		private void Dispatch( string methodName, int paramCount )
		{
			MethodHandler handler;

			if( m_Handlers.TryGetValue( methodName, out handler ) )
			{
				handler( this, paramCount );
			}
			else
			{
#if DEBUG
				Console.WriteLine("Unregistered handler for method: {0} !", methodName);
#endif
			}		
		}

		private void GenerateImage()
		{
			Frame[] animFrames = Animations.GetAnimation( m_BodyId, 0, 1, ( m_Hue - 1 ), false );
			
			Bitmap bmp = null;
			
			if( Bestiary.UseFixes )
			{
				string fixPath = Path.Combine("Bestiary/fixes", m_MasterType.Name + ".jpg");
				
				if( File.Exists(fixPath) )
				{
					bmp = new Bitmap( fixPath );
				}
			}

            if (animFrames != null || bmp != null)
            {
                using (Bitmap mobImage = new Bitmap(bmp ?? animFrames[0].Bitmap))
                {
                    using (Bitmap result = new Bitmap(m_BorderImage.Width, m_BorderImage.Height))
                    {
                        using (Bitmap title = ASCIIText.DrawText(3, m_Name, 0x3B2))
                        {
                            using (Graphics gr = Graphics.FromImage(result))
                            {
                                using (Bitmap tz = ASCIIText.DrawText(3, " - The Retelling - Bestiary -", 1260))
                                {
                                    using (SolidBrush blackBrush = new SolidBrush(Color.FromArgb(60, 1, 1, 1)))
                                    {
                                        if (m_Hue > 0)
                                        {
                                            Hue hue = GetHue(m_Hue - 1);

                                            if (hue != null)
                                            {
												// explicitely apply the hue, GetAnimation method doesn't work for few bodyIds.
                                                hue.ApplyTo(mobImage, false);
                                            }
                                        }

                                        GraphicsUnit unit = GraphicsUnit.Pixel;
                                        RectangleF rect = mobImage.GetBounds(ref unit);
                                        int trX = (214 - (mobImage.Width >> 1));
                                        int trY = (170 - (mobImage.Height >> 1));
                                        int brX = (int)(trX + rect.Width);
                                        int brY = (int)(trY + rect.Height);

										string customBg = Bestiary.TypeRegistry[m_MasterType].Background;
										
										if( !string.IsNullOrEmpty(customBg) )
										{
											using( Bitmap cBg = new Bitmap(customBg) )
											{
												gr.DrawImage(cBg, 0.0f, 0.0f);	
											}
										}
										else
										{									
                                        	gr.DrawImage(m_Background, 0.0f, 0.0f);
                                        }
                                        
                                        gr.FillRectangle(blackBrush, new Rectangle(22, 22, 385, 30));
                                        gr.DrawImage(
                                            m_WaterMark,
                                            new Rectangle(0, 0, m_BorderImage.Width, m_BorderImage.Height),
                                            0,
                                            0,
                                            m_BorderImage.Width,
                                            m_BorderImage.Height,
                                            GraphicsUnit.Pixel,
                                            imgAttrs
                                        );
                                        gr.DrawImage(title, ((brX + trX) >> 1) - (title.Width >> 1), trY - 5 - title.Height);
                                        gr.DrawImage(mobImage, trX, trY);
                                        gr.DrawImage(m_BorderImage, 0, 0, m_BorderImage.Width, m_BorderImage.Height);
                                        gr.DrawImage(tz, 100, 25);

                                        result.Save(Path.Combine("./Bestiary/images/", m_MasterType.Name + ".jpg"), m_Encoder, m_EncoderParameter);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Couldn't acquire animation frames for bodyID: {0}, {1}", m_BodyId, m_Name);
            }
		}
	};
}
