/////////////////////////////////
/////                       /////
/////      TGrey[WoLf]      /////
/////                       /////
/////////////////////////////////
using System;
using System.IO;
using System.Text;
using System.Collections;
using Server.Mobiles;
using Server;
using Server.Network;
using Server.Guilds;
using Server.Menus.Questions;
using Server.Menus; 
using Server.Items;

namespace Server.Misc
{
	public class StatusPage : Timer
	{
		public static void Initialize()
		{
			new StatusPage().Start();
		}

		public StatusPage() : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 60.0 ) )
		{
			Priority = TimerPriority.FiveSeconds;
		}

		private static string Encode( string input )
		{
			StringBuilder sb = new StringBuilder( input );

			sb.Replace( "&", "&amp;" );
			sb.Replace( "<", "&lt;" );
			sb.Replace( ">", "&gt;" );
			sb.Replace( "\"", "&quot;" );
			sb.Replace( "'", "&apos;" );

			return sb.ToString();
		}

		protected override void OnTick()
		{
			if ( !Directory.Exists( "web" ) )
				Directory.CreateDirectory( "web" );

			using ( StreamWriter op = new StreamWriter( "web/status.html" ) )
			{
				op.WriteLine( "<html>" );
				op.WriteLine( "   <head>" );
				op.WriteLine( "      <title>Unknown Shard Server Status</title>");
				op.WriteLine( "   </head>" );
				op.WriteLine( "   <body bgProperties=fixed bgcolor=#000340>" );






                             /*   op.WriteLine( "      <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">" ); 
				op.WriteLine( "         </tr>" );
  				op.WriteLine( "      <td width=\"0%\" align=\"left\"> <img src=\"1.gif\">" );
  				op.WriteLine( "      <td width=\"10%\" align=\"left\"> <img src=\"2.gif\">" );
  				op.WriteLine( "      <td width=\"0%\" align=\"right\"> <img src=\"1.gif\">" );
				op.WriteLine( "       </table>" );*/





				op.WriteLine( "      <br>" );
				op.WriteLine( "      <br>" );
				op.WriteLine( "      <table width=\"100%\">" );
				op.WriteLine( "         <tr>" );
				//op.WriteLine( "            <td><font color=\"#808000\">Name</font></td>   <td><font color=\"#808000\">Guild</font></td>  <td><font color=\"#808000\">Title</font></td>  <td bgcolor=\"black\"><font color=\"white\">Sum.Stats</font></td>  <td bgcolor=\"black\"><font color=\"white\">Sum.Skills</font></td>   <td bgcolor=\"black\"><font color=\"white\">Kills</font></td>     <td bgcolor=\"black\"><font color=\"white\">Karma</font></td>  <td bgcolor=\"black\"><font color=\"white\">Fame</font></td>  <td bgcolor=\"black\"><font color=\"white\">Citizen</font></td> <td bgcolor=\"black\"><font color=\"white\">GameTime</font></td>" );
				op.WriteLine( "            <td><font color=\"#808000\">Name</font></td>   <td><font color=\"#808000\">Guild</font></td>  <td><font color=\"#808000\">Title</font></td>  <td><font color=\"#808000\">Sum.Stats</font></td>  <td><font color=\"#808000\">Sum.Skills</font></td>   <td><font color=\"#808000\">Kills</font></td>     <td><font color=\"#808000\">Karma</font></td>  <td><font color=\"#808000\">Fame</font></td>  <td><font color=\"#808000\">GameTime</font></td>" );
				op.WriteLine( "         </tr>" );

				foreach ( NetState state in NetState.Instances )
				{
					Mobile m = state.Mobile;
					if ( m != null )
					{
       						 if ( m.AccessLevel > AccessLevel.Counselor && !m.Hidden)
          					  {
						op.Write( "         <tr><td bgColor=#8e9b44><font color=Blue><b>" );

							op.Write( m.Name );

						op.Write( "</font></td>" );
//////////////////////////////////NAME//////////////////////////////////////////////////////////////////////////


////////////////////////////////GUILD//////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
                                               	Guild g = m.Guild as Guild;

                                                if ( g != null )
                                                {
                                                   op.Write( "[" );
                                                   op.Write( Encode( g.Abbreviation ) );
						   op.Write( "]" );
                                                }
                                                else
                                                {
                                                   op.Write( "" ); 
                                                }
						op.Write( "</font></td>");
///////////////////////////////////GUILD//////////////////////////////////////////////////////////////////////////////

///////////////////////////////////TITLE//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

							string title = m.GuildTitle;

							if ( title != null )
								title = title.Trim();
							else
								title = "";

							if ( title.Length > 0 )
							{
								op.Write( Encode( title ) );
							}
						op.Write( "</font></td>");
/////////////////////////////////////TITLE//////////////////////////////////////////////////////////////////////////////////





/////////////////////////////////////Sum.Stat//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.RawStatTotal);  
 
						op.Write( "</font></td>");

/////////////////////////////////////Sum.Stat//////////////////////////////////////////////////////////////////////////////////




/////////////////////////////////////Sum.Skill//////////////////////////////////////////////////////////////////////////////////

						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.SkillsTotal);  
 
						op.Write( "</font></td>");

/////////////////////////////////////Sum.Skill//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Kills//////////////////////////////////////////////////////////////////////////////////

						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Kills);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Kills//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Karma//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Karma);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Karma//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Fame//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Fame);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Fame//////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////Citizen//////////////////////////////////////////////////////////////////////////////////
						//op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
                                              //  PlayerMobile pm = (PlayerMobile)m;
                                              //  op.Write( pm.Citizen);  
						//op.Write( "</font></td>");
/////////////////////////////////////Citizen//////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////gametime//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
				                PlayerMobile pm_from = (PlayerMobile)m;
                                                op.Write( pm_from.GameTime.Days + ":" + pm_from.GameTime.Hours + ":" + pm_from.GameTime.Minutes);  
						op.Write( "</font></td>");
/////////////////////////////////////gametime//////////////////////////////////////////////////////////////////////////////////
          					  }
                                                else
                                                  {
                                               if (File.Exists("web/"+m.Name+"/"+m.Name+".html") && m.AccessLevel < AccessLevel.Counselor)
                                                  {
						op.Write( "         <tr><td bgColor=#8e9b44><font color=\"black\"><b>" );

							op.Write( "<a href="+m.Name+"/"+m.Name+".html>"+m.Name+"</a>" );

						op.Write( "</font></td>" );
//////////////////////////////////NAME//////////////////////////////////////////////////////////////////////////


////////////////////////////////GUILD//////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
                                               	Guild g = m.Guild as Guild;

                                                if ( g != null )
                                                {
                                                   op.Write( "[" );
                                                   op.Write( Encode( g.Abbreviation ) );
						   op.Write( "]" );
                                                }
                                                else
                                                {
                                                   op.Write( "" ); 
                                                }
						op.Write( "</font></td>");
///////////////////////////////////GUILD//////////////////////////////////////////////////////////////////////////////

///////////////////////////////////TITLE//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

							string title = m.GuildTitle;

							if ( title != null )
								title = title.Trim();
							else
								title = "";

							if ( title.Length > 0 )
							{
								op.Write( Encode( title ) );
							}
						op.Write( "</font></td>");
/////////////////////////////////////TITLE//////////////////////////////////////////////////////////////////////////////////





/////////////////////////////////////Sum.Stat//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.RawStatTotal);  
 
						op.Write( "</font></td>");

/////////////////////////////////////Sum.Stat//////////////////////////////////////////////////////////////////////////////////




/////////////////////////////////////Sum.Skill//////////////////////////////////////////////////////////////////////////////////

						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.SkillsTotal);  
 
						op.Write( "</font></td>");

/////////////////////////////////////Sum.Skill//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Kills//////////////////////////////////////////////////////////////////////////////////

						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Kills);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Kills//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Karma//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Karma);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Karma//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Fame//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Fame);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Fame//////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////Citizen//////////////////////////////////////////////////////////////////////////////////
						//op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
                                             //   PlayerMobile pm = (PlayerMobile)m;
                                              //  op.Write( pm.Citizen);  
						//op.Write( "</font></td>");
/////////////////////////////////////Citizen//////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////gametime//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
				                PlayerMobile pm_from = (PlayerMobile)m;
                                                op.Write( pm_from.GameTime.Days + ":" + pm_from.GameTime.Hours + ":" + pm_from.GameTime.Minutes);  
						op.Write( "</font></td>");
/////////////////////////////////////gametime//////////////////////////////////////////////////////////////////////////////////



					}
                                       else
                                        {
                                           if ( m.AccessLevel < AccessLevel.Counselor )
                                           {
						op.Write( "         <tr><td bgColor=#8e9b44><font color=\"black\"><b>" );

							op.Write( Encode( m.Name ) );

						op.Write( "</font></td>" );
//////////////////////////////////NAME//////////////////////////////////////////////////////////////////////////


////////////////////////////////GUILD//////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
                                               	Guild g = m.Guild as Guild;

                                                if ( g != null )
                                                {
                                                   op.Write( "[" );
                                                   op.Write( Encode( g.Abbreviation ) );
						   op.Write( "]" );
                                                }
                                                else
                                                {
                                                   op.Write( "" ); 
                                                }
						op.Write( "</font></td>");
///////////////////////////////////GUILD//////////////////////////////////////////////////////////////////////////////

///////////////////////////////////TITLE//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

							string title = m.GuildTitle;

							if ( title != null )
								title = title.Trim();
							else
								title = "";

							if ( title.Length > 0 )
							{
								op.Write( Encode( title ) );
							}
						op.Write( "</font></td>");
/////////////////////////////////////TITLE//////////////////////////////////////////////////////////////////////////////////





/////////////////////////////////////Sum.Stat//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.RawStatTotal);  
 
						op.Write( "</font></td>");

/////////////////////////////////////Sum.Stat//////////////////////////////////////////////////////////////////////////////////




/////////////////////////////////////Sum.Skill//////////////////////////////////////////////////////////////////////////////////

						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.SkillsTotal);  
 
						op.Write( "</font></td>");

/////////////////////////////////////Sum.Skill//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Kills//////////////////////////////////////////////////////////////////////////////////

						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Kills);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Kills//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Karma//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Karma);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Karma//////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////Fame//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");

                                                op.Write( m.Fame);  
 
						op.Write( "</font></td>");
/////////////////////////////////////Fame//////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////Citizen//////////////////////////////////////////////////////////////////////////////////
						//op.Write( "<td><h3><font color=\"#8e9b44\"><b>");
                                              //  PlayerMobile pm = (PlayerMobile)m;
                                              //  op.Write( pm.Citizen);  
						//op.Write( "</h3></font></td>");
/////////////////////////////////////Citizen//////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////gametime//////////////////////////////////////////////////////////////////////////////////
						op.Write( "<td bgColor=#8e9b44><font color=\"black\"><b>");
				                PlayerMobile pm_from = (PlayerMobile)m;
                                                op.Write( pm_from.GameTime.Days + ":" + pm_from.GameTime.Hours + ":" + pm_from.GameTime.Minutes);  
						op.Write( "</font></td>");
/////////////////////////////////////gametime//////////////////////////////////////////////////////////////////////////////////

                                         }
                                        }
                                       }
                                      }
				}

				op.WriteLine( "         <tr>" );
				op.WriteLine( "      </table>" );
				op.WriteLine( "   </body>" );
				op.WriteLine( "</html>" );
			}
		}
	}
}