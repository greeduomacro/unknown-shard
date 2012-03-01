/**************************************
*Script Name: Alpha Command Toolbar   *
*Author: Joeku AKA Demortris          *
*For use with RunUO 2.0               *
*Client Tested with: 5.0.2b           *
*Version: 1.2                         *
*Initial Release: 03/30/06            *
*Revision Date: 06/17/06              *
**************************************/

using System; 
using System.Net; 
using Server; 
using Server.Accounting; 
using Server.Gumps; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network;
using Server.Targeting;
using Server.Targets;
using Server.Commands;
using Server.ContextMenus;
using System.Collections;

namespace Server.Commands
{
	public class ToolbarCmds
	{
		public static void Initialize()
		{
			Register( "Toolbar", AccessLevel.GameMaster, new CommandEventHandler( Toolbar_OnCommand ) );
			Register( "ToolbarEdit", AccessLevel.GameMaster, new CommandEventHandler( ToolbarEdit_OnCommand ) );
		}
		
		public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
			CommandSystem.Register( command, access, handler );
		}
	
		[Usage( "Toolbar" )]
		[Description( "Brings up a customizable toolbar. Use [ToolbarEdit to edit the toolbar." )]
		public static void Toolbar_OnCommand( CommandEventArgs e )
		{
			if( e.Mobile.HasGump( typeof( CommandToolbarEdit)))
			{
				e.Mobile.SendMessage("You're still editing your toolbar.");
				return;
			}

			e.Mobile.CloseGump( typeof( CommandToolbar ) );
			Account A = e.Mobile.Account as Account;
			string TagString = A.GetTag("CommandToolbar");
			if( TagString == null )
			{
				A.SetTag("CommandToolbar", "Props|M Tele|Move|M Delete|Wipe|Who|Add|Normal|true|true");
				TagString = A.GetTag("CommandToolbar");
			}
			string[] split = TagString.Split('|');

			e.Mobile.SendGump( new CommandToolbar(split[0], split[1], split[2], split[3], split[4], split[5], split[6], split[7], split[8], split[9]) );
		}

		public static void ToolbarEdit_OnCommand( CommandEventArgs e )
		{
			if( e.Mobile.HasGump( typeof( CommandToolbarEdit)))
			{
				e.Mobile.SendMessage("You're already editing your toolbar.");
				return;
			}

			e.Mobile.CloseGump( typeof( CommandToolbar ) );
			Account A = e.Mobile.Account as Account;
			string TagString = A.GetTag("CommandToolbar");
			if( TagString == null )
			{
				A.SetTag("CommandToolbar", "Props|M Tele|Move|M Delete|Wipe|Who|Add|Normal|true|true");
				TagString = A.GetTag("CommandToolbar");
			}
			string[] split = TagString.Split('|');

			e.Mobile.SendGump( new CommandToolbarEdit(split[0], split[1], split[2], split[3], split[4], split[5], split[6], split[7], split[8], split[9]) );
		}

		public static void TagToolbar( Mobile from )
		{
			Account A = from.Account as Account;
			string TagString = A.GetTag("CommandToolbar");
			if( TagString == null )
		{
				A.SetTag("CommandToolbar", "Props|M Tele|Move|M Delete|Wipe|Who|Add|Normal|true|true");
				TagString = A.GetTag("CommandToolbar");
			}
			string[] split = TagString.Split('|');

			from.SendGump( new CommandToolbar(split[0], split[1], split[2], split[3], split[4], split[5], split[6], split[7], split[8], split[9]) );	
		}
	}
}

namespace Server.Gumps
{
	public class CommandToolbar : Gump
	{
		private string C1, C2, C3, C4, C5, C6, C7, HideS;
		private bool HideB = false, Adv = false;

		public CommandToolbar( string c1, string c2, string c3, string c4, string c5, string c6, string c7, string hides, string hideb, string adv ) : base( 0, 28 )
		{
			C1 = c1;
			C2 = c2;
			C3 = c3;
			C4 = c4;
			C5 = c5;
			C6 = c6;
			C7 = c7;
			HideS = hides;
			if( hideb == "true" )
				HideB = true;
			if( adv == "true" )
				Adv = true;

			Closable=false;
			Resizable=false;
			
			AddPage(0);
			AddPage(1);
			AddBackground(0, 0, 610, 75, 9270);
			AddButton(63, 35, 9726, 9728, 1, GumpButtonType.Reply, 1);
			AddButton(143, 35, 9720, 9722, 2, GumpButtonType.Reply, 1);
			AddButton(223, 35, 9726, 9728, 3, GumpButtonType.Reply, 1);
			AddButton(303, 35, 9720, 9722, 4, GumpButtonType.Reply, 1);
			AddButton(383, 35, 9726, 9728, 5, GumpButtonType.Reply, 1);
			AddButton(463, 35, 9720, 9722, 6, GumpButtonType.Reply, 1);
			AddButton(543, 35, 9726, 9728, 7, GumpButtonType.Reply, 1);
			AddLabelCropped(40, 15, 70, 20, 2101, C1);
			AddLabelCropped(120, 15, 70, 20, 2108, C2);
			AddLabelCropped(200, 15, 70, 20, 2101, C3);
			AddLabelCropped(280, 15, 70, 20, 2108, C4);
			AddLabelCropped(360, 15, 70, 20, 2101, C5);
			AddLabelCropped(440, 15, 70, 20, 2108, C6);
			AddLabelCropped(520, 15, 70, 20, 2101, C7);
			if( HideB )
			{
				AddBackground(606, 0, 117, 75, 9270);
				AddButton(664, 19, 2642, 2643, 9, GumpButtonType.Reply, 1);
				AddLabel(618, 20, 2101, @"Hide &");
				AddLabel(618, 40, 2101, @"Unhide");
			}
			/*if( Adv )
			{
				if( !HideB )
				{
					AddBackground(606, 0, 165, 75, 9270);
					AddButton(740, 17, 9762, 9763, 10, GumpButtonType.Reply, 1);
					AddLabel(620, 15, 2101, @"Item/Mobile Move");
					AddLabel(620, 40, 2101, @"Creature Control");
					AddButton(740, 43, 9762, 9763, 11, GumpButtonType.Reply, 1);
				}
				else
				{
					AddBackground(719, 0, 155, 75, 9270);
					AddButton(843, 17, 9762, 9763, 10, GumpButtonType.Reply, 1);
					AddLabel(731, 15, 2101, @"Item/Mobile Move");
					AddLabel(731, 40, 2101, @"Creature Control");
					AddButton(843, 43, 9762, 9763, 11, GumpButtonType.Reply, 1);
				}
			}*/
			AddButton(13, 13, 22053, 22055, 8, GumpButtonType.Page, 2);
			AddPage(2);
			AddBackground(0, 0, 45, 75, 9270);
			AddButton(13, 13, 22056, 22058, 9, GumpButtonType.Page, 1);
		}

		public override void OnResponse( NetState state, RelayInfo info )
        { 
			Mobile from = state.Mobile;
			string prefix = CommandSystem.Prefix;
			IPoint3D p = from.Location as IPoint3D;

			if ( from.AccessLevel < AccessLevel.Counselor )
			{
				from.SendMessage( 2102, "Only staff members can use this." );
				return;
			}

			switch ( info.ButtonID ) 
           	{ 
				case 1:
				{
					from.SendMessage( 2102, "{0}{1}", prefix, C1 );
					CommandSystem.Handle( from, String.Format( "{0}{1}", prefix, C1 ) );
					ToolbarCmds.TagToolbar( from );
                	break;
				} 
				
				case 2:
				{
					from.SendMessage( 2109, "{0}{1}", prefix, C2 );
					CommandSystem.Handle( from, String.Format( "{0}{1}", prefix, C2 ) );
					ToolbarCmds.TagToolbar( from );
					break;
				}

				case 3:
				{
					from.SendMessage( 2102, "{0}{1}", prefix, C3 );
					CommandSystem.Handle( from, String.Format( "{0}{1}", prefix, C3 ) );
					ToolbarCmds.TagToolbar( from );
					break;
				}

				case 4:
				{
					from.SendMessage( 2109, "{0}{1}", prefix, C4 );
					CommandSystem.Handle( from, String.Format( "{0}{1}", prefix, C4 ) );
					ToolbarCmds.TagToolbar( from );
					break;
				}

				case 5:
				{
					from.SendMessage( 2102, "{0}{1}", prefix, C5 );
					CommandSystem.Handle( from, String.Format( "{0}{1}", prefix, C5 ) );
					ToolbarCmds.TagToolbar( from );
					break;
				}
				
				case 6:
				{
					from.SendMessage( 2109, "{0}{1}", prefix, C6 );
					CommandSystem.Handle( from, String.Format( "{0}{1}", prefix, C6 ) );
					ToolbarCmds.TagToolbar( from );
               		break;
				}

				case 7:
				{
					from.SendMessage( 2102, "{0}{1}", prefix, C7 );
					CommandSystem.Handle( from, String.Format( "{0}{1}", prefix, C7 ) );
					ToolbarCmds.TagToolbar( from );
               		break;
				}
				
				case 9:
				{
					//if ( HideType == "Normal" )
					//{
						Effects.SendLocationEffect( new Point3D( from.X + 1, from.Y, from.Z + 4 ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X + 1, from.Y, from.Z ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X + 1, from.Y, from.Z - 4 ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X, from.Y + 1, from.Z + 4 ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X, from.Y + 1, from.Z ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X, from.Y + 1, from.Z - 4 ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X + 1, from.Y + 1, from.Z + 11 ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X + 1, from.Y + 1, from.Z + 7 ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X + 1, from.Y + 1, from.Z + 3 ), from.Map, 0x3728, 13 );
						Effects.SendLocationEffect( new Point3D( from.X + 1, from.Y + 1, from.Z - 1 ), from.Map, 0x3728, 13 );
						from.PlaySound( 0x228 );
						if ( !from.Hidden )
							from.Hidden = true;
						else
							from.Hidden = false;
					//}

					ToolbarCmds.TagToolbar( from );
					break;
				}
				/*case 10:
				{
					if( (from.HasGump( typeof( ItemMove ))) || (from.HasGump( typeof( MobileMove))))
					{
						from.SendMessage("You must close all Item/Mobile movers before you do this!");
					}
					else
					{
						from.Target = new ItemMobileMoveTarget( this );
						from.SendMessage("Select an item/mobile.");
					}

					from.SendGump( new CommandToolbar( item ) );
					break;
				}
				case 11:
				{
					if( from.HasGump( typeof( CreatureControl )))
					{
						from.SendMessage("You must close all Creature Controls before you do this!");
					}
					else
					{
						from.Target = new ControlTarget( this );
						from.SendMessage("Select a creature.");
					}

					from.SendGump( new CommandToolbar( item ) );
					break;
				}*/
			}
		}
	}

	public class CommandToolbarEdit : Gump
	{
		private string C1, C2, C3, C4, C5, C6, C7, HideS;
		private bool HideB = false, Adv = false;

		public CommandToolbarEdit( string c1, string c2, string c3, string c4, string c5, string c6, string c7, string hides, string hideb, string adv ) : base( 150, 150 )
		{
			C1 = c1;
			C2 = c2;
			C3 = c3;
			C4 = c4;
			C5 = c5;
			C6 = c6;
			C7 = c7;
			HideS = hides;
			if( hideb == "true" )
				HideB = true;
			if( adv == "true" )
				Adv = true;

			Closable=false;
			Disposable=false;
			Dragable=true;
			Resizable=false;

			AddPage(0);

			AddPage(1);

			AddBackground(0, 0, 675, 535, 9270);
			AddLabel(226, 40, 2101, @"Command Toolbar Edit Menu");

			AddLabel(60, 90, 2101, @"Command 1:");
			AddBackground(145, 83, 462, 33, 2620);
			AddTextEntry(153, 90, 445, 20, 2101, 1, C1 );
			AddLabel(60, 130, 2108, @"Command 2:");
			AddBackground(145, 123, 462, 33, 2620);
			AddTextEntry(153, 130, 445, 20, 2108, 2, C2 );
			AddLabel(60, 170, 2101, @"Command 3:");
			AddBackground(145, 163, 462, 33, 2620);
			AddTextEntry(153, 170, 445, 20, 2101, 3, C3 );
			AddLabel(60, 210, 2108, @"Command 4:");
			AddBackground(145, 203, 462, 33, 2620);
			AddTextEntry(153, 210, 445, 20, 2108, 4, C4 );
			AddLabel(60, 250, 2101, @"Command 5:");
			AddBackground(145, 243, 462, 33, 2620);
			AddTextEntry(153, 250, 445, 20, 2101, 5, C5 );
			AddLabel(60, 290, 2108, @"Command 6:");
			AddBackground(145, 283, 462, 33, 2620);
			AddTextEntry(153, 290, 445, 20, 2108, 6, C6 );
			AddLabel(60, 330, 2101, @"Command 7:");
			AddBackground(145, 323, 462, 33, 2620);
			AddTextEntry(153, 330, 445, 20, 2101, 7, C7 );

			AddLabel(148, 373, 2101, @"Hide Toolbar Enabled:");
			AddButton(287, 369, (HideB ? 2153 : 2151), (HideB ? 2151 : 2153), 11, GumpButtonType.Reply, 1);
			//AddLabel(148, 403, 2101, @"Adv. Toolbar Enabled:");

			AddLabel(406, 373, 2101, @"Hide Type");
			AddBackground(367, 399, 143, 26, 9350);
			AddLabel(374, 403, 0, HideS);
			//AddButton(511, 403, 5601, 5605, 13, GumpButtonType.Page, 2);

			AddHtml(0, 443, 675, 30, @"<center>Created by Joeku AKA Demortris</center>", false, false);

			AddButton(165, 480, 246, 244, 8, GumpButtonType.Reply, 1);
			AddButton(300, 480, 239, 240, 9, GumpButtonType.Reply, 1);
			AddButton(435, 480, 243, 241, 10, GumpButtonType.Reply, 1);
		}

		public override void OnResponse( NetState state, RelayInfo info )
        	{ 
			Mobile from = state.Mobile;

			if ( from.AccessLevel < AccessLevel.Counselor )
				from.SendMessage( 2102, "Only staff members can use this." );
			else
			{
				switch ( info.ButtonID ) 
				{
					case 8:
					{
						CommandToolbarEdit gump = new CommandToolbarEdit( "Props", "M Tele", "Move", "M Delete", "Wipe", "Who", "Add", "Normal", "true", "true" );
							/*gump.AddTextEntry(153, 90, 445, 20, 2101, 1, @"Props" );
							gump.AddTextEntry(153, 130, 445, 20, 2101, 2, @"M Tele" );
							gump.AddTextEntry(153, 170, 445, 20, 2101, 3, @"Move" );
							gump.AddTextEntry(153, 210, 445, 20, 2101, 4, @"M Delete" );
							gump.AddTextEntry(153, 250, 445, 20, 2101, 5, @"Wipe" );
							gump.AddTextEntry(153, 290, 445, 20, 2101, 6, @"Who" );
							gump.AddTextEntry(153, 330, 445, 20, 2101, 7, @"Add" );
							gump.HideB = true;
							gump.Adv = true;
							gump.HideS = "Normal";
							gump.AddButton(287, 399, 2153, 2151, 12, GumpButtonType.Reply, 1);
							gump.AddLabel(374, 403, 0, gump.HideType);

							gump.AddPage(2);

							gump.AddBackground(0, 0, 273, 545, 9270);
							gump.AddLabel(75, 39, 2101, @"Hide Type Edit Menu");

							gump.AddBackground(64, 83, 131, 26, 9350);
							gump.AddLabel(72, 87, 0, @"Normal Hide");
							gump.AddButton(196, 87, 5601, 5605, 14, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 123, 131, 26, 9350);
							gump.AddLabel(72, 127, 0, @"Blood Oath Hide");
							gump.AddButton(196, 127, 5601, 5605, 15, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 163, 131, 26, 9350);
							gump.AddLabel(72, 167, 0, @"Divine Male Hide");
							gump.AddButton(196, 167, 5601, 5605, 16, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 203, 131, 26, 9350);
							gump.AddLabel(72, 207, 0, @"Divine Female Hide");
							gump.AddButton(196, 207, 5601, 5605, 17, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 243, 131, 26, 9350);
							gump.AddLabel(72, 247, 0, @"Explosion Hide");
							gump.AddButton(196, 247, 5601, 5605, 18, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 283, 131, 26, 9350);
							gump.AddLabel(72, 287, 0, @"Fire Hide");
							gump.AddButton(196, 287, 5601, 5605, 19, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 323, 131, 26, 9350);
							gump.AddLabel(72, 327, 0, @"Noble Hide");
							gump.AddButton(196, 327, 5601, 5605, 20, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 363, 131, 26, 9350);
							gump.AddLabel(72, 367, 0, @"Poison Hide");
							gump.AddButton(196, 367, 5601, 5605, 21, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 403, 131, 26, 9350);
							gump.AddLabel(72, 407, 0, @"Shiney Hide");
							gump.AddButton(196, 407, 5601, 5605, 22, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 443, 131, 26, 9350);
							gump.AddLabel(72, 447, 0, @"Thunder Hide");
							gump.AddButton(196, 447, 5601, 5605, 23, GumpButtonType.Reply, 2);
							gump.AddBackground(64, 483, 131, 26, 9350);
							gump.AddLabel(72, 487, 0, @"Wither Hide");
							gump.AddButton(196, 487, 5601, 5605, 24, GumpButtonType.Reply, 2);*/
						from.SendGump( gump );
						from.SendMessage( 2102, "Settings have been changed to default." );

						break;
					}

					case 9:
					{
						TextRelay t1 = info.GetTextEntry( 1 );
						C1 = t1.Text.Replace("|", "");
						TextRelay t2 = info.GetTextEntry( 2 );
						C2 = t2.Text.Replace("|", "");
						TextRelay t3 = info.GetTextEntry( 3 );
						C3 = t3.Text.Replace("|", "");
						TextRelay t4 = info.GetTextEntry( 4 );
						C4 = t4.Text.Replace("|", "");
						TextRelay t5 = info.GetTextEntry( 5 );
						C5 = t5.Text.Replace("|", "");
						TextRelay t6 = info.GetTextEntry( 6 );
						C6 = t6.Text.Replace("|", "");
						TextRelay t7 = info.GetTextEntry( 7 );
						C7 = t7.Text.Replace("|", "");

						if( C1 != null && C2 != null && C3 != null && C4 != null && C5 != null && C6 != null && C7 != null )
						{
							Account A = from.Account as Account;
							A.RemoveTag("CommandToolbar");
							string ADV = "false", HIDEB = "false";
							if( Adv )
								ADV = "true";
							if( HideB )
								HIDEB = "true";
							A.SetTag("CommandToolbar", C1+"|"+C2+"|"+C3+"|"+C4+"|"+C5+"|"+C6+"|"+C7+"|"+HideS+"|"+HIDEB+"|"+ADV );
							from.SendMessage( 2102, "Your new settings have been successfully applied." );
							if( from.HasGump( typeof( CommandToolbar )))
							{
								from.CloseGump( typeof( CommandToolbar ) );
								ToolbarCmds.TagToolbar( from );
							}
						}
						else
							from.SendMessage( 2102, "One of your text entries is invalid. Please try again." );

						break;
					}
					case 11:
					{
						TextRelay t1 = info.GetTextEntry( 1 );
						C1 = t1.Text.Replace("|", "");
						TextRelay t2 = info.GetTextEntry( 2 );
						C2 = t2.Text.Replace("|", "");
						TextRelay t3 = info.GetTextEntry( 3 );
						C3 = t3.Text.Replace("|", "");
						TextRelay t4 = info.GetTextEntry( 4 );
						C4 = t4.Text.Replace("|", "");
						TextRelay t5 = info.GetTextEntry( 5 );
						C5 = t5.Text.Replace("|", "");
						TextRelay t6 = info.GetTextEntry( 6 );
						C6 = t6.Text.Replace("|", "");
						TextRelay t7 = info.GetTextEntry( 7 );
						C7 = t7.Text.Replace("|", "");

						string ADV = "false", HIDEB = "false";
						if( Adv )
							ADV = "true";
						if( !HideB )
							HIDEB = "true";
						from.SendGump( new CommandToolbarEdit( C1, C2, C3, C4, C5, C6, C7, HideS, HIDEB, ADV ));

						break;
					}
				}
			}
		}
	}
}
