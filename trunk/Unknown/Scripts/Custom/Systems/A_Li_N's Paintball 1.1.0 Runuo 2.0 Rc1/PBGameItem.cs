/*********************************************************************************/
/*                PBEquipment.cs | PBGameItem.cs | PBPlayerStorage.cs            */
/*            PBScoreBoard.cs | PBScoreGump.cs | PBGMGump.cs | PBTimer.cs        */
/*                             Created by A_Li_N                                 */
/*         Credits:                                                              */
/*                      Original Idea + Some Code - Clarke76                     */
/*                      Some Ideas + Code - Lucid Nagual                         */
/*********************************************************************************/

using System;
using System.IO;
using System.Collections;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Games.PaintBall
{
	public class PBGameItem : Item
	{
		public bool			m_Active;
		public int			m_Team1, m_Team2, m_Team3, m_Team4;
		public ArrayList	m_WinnersPrizes;

		private int			m_Teams = 2;
		private int			m_CurrentTeam = 0;
		private Point3D		m_Team1Dest;
		private Point3D		m_Team2Dest;
		private Point3D		m_Team3Dest;
		private Point3D		m_Team4Dest;

		private Point3D		m_Exit1Dest;
		private Point3D		m_Exit2Dest;
		private Point3D		m_Exit3Dest;
		private Point3D		m_Exit4Dest;

		private Map				m_MapDest;
		private ArrayList		m_Players;
		private PBScoreBoard	m_PBScoreBoard;
		private PBTimer			m_Timer;


		[CommandProperty( AccessLevel.GameMaster )]
		public bool Active
		{
			get { return m_Active; }
			set { m_Active = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Teams
		{
			get { return m_Teams; }
			set { m_Teams = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Team1Dest
		{
			get { return m_Team1Dest; }
			set { m_Team1Dest = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Team2Dest
		{
			get { return m_Team2Dest; }
			set { m_Team2Dest = value; }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Team3Dest
		{
			get { return m_Team3Dest; }
			set { m_Team3Dest = value; }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Team4Dest
		{
			get { return m_Team4Dest; }
			set { m_Team4Dest = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Exit1Dest
		{
			get { return m_Exit1Dest; }
			set { m_Exit1Dest = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Exit2Dest
		{
			get { return m_Exit2Dest; }
			set { m_Exit2Dest = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Exit3Dest
		{
			get { return m_Exit3Dest; }
			set { m_Exit3Dest = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Exit4Dest
		{
			get { return m_Exit4Dest; }
			set { m_Exit4Dest = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Map MapDest
		{
			get { return m_MapDest; }
			set { m_MapDest = value; }
		}

		public ArrayList Players{ get{ return m_Players; } }
		public PBScoreBoard SB{ get{ return m_PBScoreBoard; } }
		public PBTimer GameTimer{ get{ return m_Timer; } set{ m_Timer = value; } }


		[Constructable]
		public PBGameItem() : base( 0xED4 )
		{
			Movable = false;
			Name = "PaintBall Game";

			m_Active = false;
			m_Team1 = m_Team2 = m_Team3 = m_Team4 = 0;
			m_Team1Dest = m_Team2Dest = m_Team3Dest = m_Team4Dest = m_Exit1Dest = m_Exit2Dest = m_Exit3Dest = m_Exit4Dest = this.Location;
			m_MapDest = this.Map;
			m_Players = new ArrayList();
			m_WinnersPrizes = new ArrayList();
			m_Timer = new PBTimer( this );

			m_PBScoreBoard = new PBScoreBoard( this );
			m_PBScoreBoard.MoveToWorld( this.Location, this.Map );
		}

		public override void OnMapChange()
		{
			if( Deleted )
				return;
			m_MapDest = m_PBScoreBoard.Map = Map;
		}

		public override void OnLocationChange( Point3D oldLoc )
		{
			if( Deleted )
				return;
			if( !Active )
				m_Team1Dest = m_Team2Dest = m_Team3Dest = m_Team4Dest = m_Exit1Dest = m_Exit2Dest = m_Exit3Dest = m_Exit4Dest = m_PBScoreBoard.Location = Location;
		}


		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_Active == true )
				list.Add( 1060742 );//active

			if ( m_Active == false )
				list.Add( 1060743 );//inactive
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( m_Active == true )
				LabelTo( from, 1060742 );
			if ( m_Active == false )
				LabelTo( from, 1060743 );
		}

		public override void OnAfterDelete()
		{
			EndGame();
			if( m_PBScoreBoard != null )
				m_PBScoreBoard.Delete();
			if( m_Timer != null )
				m_Timer.Stop();

			base.OnAfterDelete();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( from.AccessLevel >= AccessLevel.Counselor )
				from.SendGump( new PBGMGump( this ) );

			else if( this.m_Active )
				from.SendMessage( "The game has already started" );

			else if( from is Mobile && from.AccessLevel == AccessLevel.Player )
			{
				if( !from.InRange( GetWorldLocation(), 3 ) )
					from.SendLocalizedMessage( 500446 );
				else if( CheckAlreadyPlayer( from ) )
					from.SendMessage( "You are already on a team" );
				else
				{
					Players.Add( from );

					ArrayList ItemsToMove = new ArrayList();
					Backpack itemsPack = new Backpack();
					itemsPack.Hue = 1;
					itemsPack.Name = "Items from PaintBallGame";
					BankBox bankBox = from.BankBox;

					foreach( Item item in from.Items )
						if( item.Layer != Layer.Bank && item.Layer != Layer.Hair && item.Layer != Layer.FacialHair && item.Layer != Layer.Mount && item.Layer != Layer.Backpack )
						ItemsToMove.Add( item );
					foreach( Item item in from.Backpack.Items )
						ItemsToMove.Add( item );

					foreach( Item item in ItemsToMove )
						itemsPack.AddItem( item );

					bankBox.AddItem( itemsPack );

					bankBox.AddItem( new PBPlayerStorage( from ) );

					AddToTeam( from );
				}
			}
			else
				from.SendMessage( "You could not access that item for some reason.  Please page a GM." );
		}

		private bool CheckAlreadyPlayer( Mobile player )
		{
			for( int i = 0; i < m_Players.Count; i++ )
				if( player == m_Players[i] as Mobile )
					return true;
			return false;
		}

		private void AddToTeam( Mobile player )
		{
			player.Str = player.Dex = player.Int = 100;
			player.Fame = player.Karma = 0;
			player.Kills = 10;

			for( int i = 0; i < PowerScroll.Skills.Length; i++ )
				player.Skills[PowerScroll.Skills[i]].Base = 0;

			player.Skills[SkillName.Archery].Base = 100;
			player.Skills[SkillName.Tactics].Base = 100;
			player.Skills[SkillName.Meditation].Base = 100;
			player.Skills[SkillName.Focus].Base = 100;

			EquipItems( player, GetTeamHue() );
		}

		private int GetTeamHue()
		{
			m_CurrentTeam ++;
			switch( m_Teams )
			{
				case 2:
				{
					switch( m_CurrentTeam )
					{
						case 1:	return 3;
						case 2:	return 38;
						default: m_CurrentTeam = 1; return 3;
					}
				}
				case 3:
				{
					switch( m_CurrentTeam )
					{
						case 1:	return 3;
						case 2:	return 38;
						case 3:	return 68;
						default:	m_CurrentTeam = 1; return 3;
					}
				}
				case 4:
				{
					switch( m_CurrentTeam )
					{
						case 1:	return 3;
						case 2:	return 38;
						case 3:	return 68;
						case 4:	return 53;
						default:	m_CurrentTeam = 1; return 3;
					}
				}
			}

			return 0;
		}

		private void EquipItems( Mobile Player, int TeamHue )
		{
			Player.SendMessage( "Equiping Team Items" );
			Player.AddItem( new PBArmor( TeamHue, 5136, Layer.Arms ) );
			Player.AddItem( new PBArmor( TeamHue, 5137, Layer.Pants ) );
			Player.AddItem( new PBArmor( TeamHue, 5138, Layer.Helm ) );
			Player.AddItem( new PBArmor( TeamHue, 5139, Layer.Neck ) );
			Player.AddItem( new PBArmor( TeamHue, 5140, Layer.Gloves ) );
			Player.AddItem( new PBArmor( TeamHue, 5141, Layer.InnerTorso ) );
			Player.AddItem( new PBWeapon( TeamHue, this ) );
			Cloak cloak = new Cloak( TeamHue );
			cloak.Movable = false;
			Player.AddItem( cloak );
			Player.AddToBackpack( new PaintBall( TeamHue, 200 ) );

			switch( TeamHue )
			{
				case 3:  {Player.MoveToWorld( Team1Dest, MapDest );	m_Team1+=1;	break;}
				case 38: {Player.MoveToWorld( Team2Dest, MapDest );	m_Team2+=1;	break;}
				case 68: {Player.MoveToWorld( Team3Dest, MapDest );	m_Team3+=1;	break;}
				case 53: {Player.MoveToWorld( Team4Dest, MapDest );	m_Team4+=1;	break;}
				default: {Player.MoveToWorld( Team1Dest, MapDest );	m_Team1+=1;	break;}
			}

			Player.Frozen = true;
		}

		public void KillPlayer( Mobile player )
		{
			player.SendMessage( "You have been Painted!" );
			player.Warmode = false;
			int team = -1;

			if( player.FindItemOnLayer( Layer.Cloak ) != null )
				team = player.FindItemOnLayer( Layer.Cloak ).Hue;

			else if( player.FindItemOnLayer( Layer.TwoHanded ) != null )
			{
				team = player.FindItemOnLayer( Layer.TwoHanded ).Hue;
				player.FindItemOnLayer( Layer.TwoHanded ).Delete();
				Cloak cloak = new Cloak( team );
				cloak.Movable = false;
				player.AddItem( cloak );
			}

			bool Decrement = true;
			foreach( Item i in player.Backpack.Items )
				if( i is Squash )
					Decrement = false;

			if( Decrement )
			{
				Squash squash = new Squash();
				squash.Visible = false;
				player.AddToBackpack( squash );
			}

			switch( team )
			{
				case 3:  { player.MoveToWorld( Exit1Dest, MapDest );	if( Decrement )m_Team1 -= 1;	break; }
				case 38: { player.MoveToWorld( Exit2Dest, MapDest );	if( Decrement )m_Team2 -= 1;	break; }
				case 68: { player.MoveToWorld( Exit3Dest, MapDest );	if( Decrement )m_Team3 -= 1;	break; }
				case 53: { player.MoveToWorld( Exit4Dest, MapDest );	if( Decrement )m_Team4 -= 1;	break; }
				default: break;
			}
		}

		public void EndGame()
		{
			this.Active = false;
			if( m_Team1 > 0 )
				World.Broadcast( 0x22, true, "Team 1 has won in Paintball!" );
			if( m_Team2 > 0 )
				World.Broadcast( 0x22, true, "Team 2 has won in Paintball!" );
			if( m_Team3 > 0 )
				World.Broadcast( 0x22, true, "Team 3 has won in Paintball!" );
			if( m_Team4 > 0 )
				World.Broadcast( 0x22, true, "Team 4 has won in Paintball!" );

			foreach( Mobile pm in m_Players )
			{
				pm.SendMessage( "The game has ended." );

				pm.Hidden = true;
				pm.Warmode = false;
				pm.Frozen = false;

				GivePrizes( pm );

				ArrayList toDelete = new ArrayList();
				foreach( Item item in pm.Items )
					if( item is PBArmor || item is PBWeapon || item is PaintBall || item is Cloak )
						toDelete.Add( item );

				foreach( Item item in pm.Backpack.Items )
					if( item is PBArmor || item is PBWeapon || item is PaintBall || item is Cloak )
						toDelete.Add( item );

				foreach( Item item in toDelete )
					item.Delete();
			}
			m_Players.Clear();

			m_WinnersPrizes.Clear();

			m_Team1 = m_Team2 = m_Team3 = m_Team4 = 0;

			if( m_Timer != null )
				m_Timer.Stop();
		}

		public void GivePrizes( Mobile pm )
		{
			bool GivePrize = false;
			int team = -1;
			if( pm.FindItemOnLayer( Layer.Cloak ) != null )
				team = pm.FindItemOnLayer( Layer.Cloak ).Hue;

			if( team == -1 )
			{
				pm.SendMessage( "You have no team cloak.  Please ask the GM about this!" );
				return;
			}
			switch( team )
			{
				case 3:	{ pm.MoveToWorld( Exit1Dest, MapDest );	if( m_Team1 > 0 ) GivePrize = true;	break; }
				case 38:	{ pm.MoveToWorld( Exit2Dest, MapDest );	if( m_Team2 > 0 ) GivePrize = true;	break; }
				case 68:	{ pm.MoveToWorld( Exit3Dest, MapDest );	if( m_Team3 > 0 ) GivePrize = true;	break; }
				case 53:	{ pm.MoveToWorld( Exit4Dest, MapDest );	if( m_Team4 > 0 ) GivePrize = true;	break; }
				default: break;
			}

			if( GivePrize )
			{
				pm.SendMessage( "Your team won!  Here is your prize." );
				if( m_WinnersPrizes == null || m_WinnersPrizes.Count == 0 )
				{
					pm.SendMessage( "The GM did not set an automatic prize.  Please ask them if they are planning on giving one out!" );
					return;
				}
				Bag winnersBag = new Bag();
				Item toGive;
				for( int i = 0; i < m_WinnersPrizes.Count; i++ )
				{
					if( m_WinnersPrizes[i] is BankCheck )
					{
						int bcWorth = ((BankCheck)m_WinnersPrizes[i]).Worth;
						toGive = new BankCheck( bcWorth );
					}
					else
					{
						toGive = (Item)Activator.CreateInstance( m_WinnersPrizes[i].GetType() );
						toGive.Amount = ((Item)m_WinnersPrizes[i]).Amount;
					}
					winnersBag.AddItem( toGive );
				}
				pm.AddToBackpack( winnersBag );
			}
			else
				pm.SendMessage( "Your team did not win this game.  Try again next time!" );
		}
		public PBGameItem( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );// version

			writer.Write( (Point3D)m_Exit2Dest );
			writer.Write( (Point3D)m_Exit3Dest );
			writer.Write( (Point3D)m_Exit4Dest );

			writer.WriteMobileList( m_Players );
			writer.Write( (bool)m_Active );
			writer.Write( (int)m_Team1 );
			writer.Write( (int)m_Team2 );
			writer.Write( (int)m_Team3 );
			writer.Write( (int)m_Team4 );
			writer.Write( (Map)m_MapDest );
			writer.Write( (Point3D)m_Team1Dest );
			writer.Write( (Point3D)m_Team2Dest );
			writer.Write( (Point3D)m_Team3Dest );
			writer.Write( (Point3D)m_Team4Dest );
			writer.Write( (Point3D)m_Exit1Dest );
			writer.Write( (int)m_Teams );

			writer.Write( m_PBScoreBoard );

			writer.Write( (int)m_WinnersPrizes.Count );
			for( int i = 0; i < m_WinnersPrizes.Count; i++ )
				writer.Write( (Item)m_WinnersPrizes[i] );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					m_Exit2Dest = reader.ReadPoint3D();
					m_Exit3Dest = reader.ReadPoint3D();
					m_Exit4Dest = reader.ReadPoint3D();

					m_Players = new ArrayList();
					m_WinnersPrizes = new ArrayList();

					m_Players = reader.ReadMobileList();
					m_Active = reader.ReadBool();
					m_Team1 = reader.ReadInt();
					m_Team2 = reader.ReadInt();
					m_Team3 = reader.ReadInt();
					m_Team4 = reader.ReadInt();
					m_MapDest = reader.ReadMap();
					m_Team1Dest = reader.ReadPoint3D();
					m_Team2Dest = reader.ReadPoint3D();
					m_Team3Dest = reader.ReadPoint3D();
					m_Team4Dest = reader.ReadPoint3D();
					m_Exit1Dest = reader.ReadPoint3D();
					m_Teams = reader.ReadInt();

					m_PBScoreBoard = reader.ReadItem() as PBScoreBoard;

					int count = reader.ReadInt();
					for( int i = 0; i < count; i++ )
						m_WinnersPrizes.Add( reader.ReadItem() );

					m_Active = false;
					m_Timer = new PBTimer( this );
					break;
				}
			}
		}
	}
}
