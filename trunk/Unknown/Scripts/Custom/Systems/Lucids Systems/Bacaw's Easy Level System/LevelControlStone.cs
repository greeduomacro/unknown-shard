////////////////////////////  ///////////////////////
//// Created by Andyboi  //  // and Lucid Nagual ////
//////////////////////////  /////////////////////////
////   DO NOT REMOVE   //  // Easy Level System  ////
////   THIS HEADER!!  //  //   Version [2].0.1   ////
///////////////////////  ////////////////////////////
using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.LevelSystem;


namespace Server.LevelSystem
{
	public class LevelControlStone : Item
	{
		//Adjustable settings
		private static bool m_EnableLevelSystem;    //Activate Level System.
		private static bool m_AllowSPRewardSystem;  //Activates Skill Point rewards.
		private static bool m_AllowEXPRewardSystem; //Activates Expereience Token rewards.
		//Adjustable settings
		
		//Not Adjustable
		private static bool m_AllowSkillPts;        //Leave at this setting for now.
		private static bool m_AllowAging;           //Leave at this setting for now.
		private static bool m_AllowExp;             //Leave at this setting for now.
		private static bool LCSSpawn = false;
		private static bool m_Generated;
		private static string m_ServerName;
		private static LevelControlStone m_Static_LCStone;
		//Not Adjustable
		
		private ArrayList m_LevelKeepers = new ArrayList();
		public ArrayList LevelKeepers{ get{ return m_LevelKeepers; } set{ m_LevelKeepers = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static bool Generated{ get{ return m_Generated; } set{ m_Generated = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static bool EnableLevelSystem{ get{ return m_EnableLevelSystem; } set{ m_EnableLevelSystem = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static bool AllowSkillPts{ get{ return m_AllowSkillPts; } set{ m_AllowSkillPts = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static bool AllowAging{ get{ return m_AllowAging; } set{ m_AllowAging = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static bool AllowExp{ get{ return m_AllowExp; } set{ m_AllowExp = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static bool AllowSPRewardSystem{ get{ return m_AllowSPRewardSystem; } set{ m_AllowSPRewardSystem = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static bool AllowEXPRewardSystem{ get{ return m_AllowEXPRewardSystem; } set{ m_AllowEXPRewardSystem = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public static LevelControlStone Static_LCStone{ get{ return m_Static_LCStone; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public static string ServerName{ get{ return m_ServerName; } set{ m_ServerName = value; } }
		
		[Constructable]
		public LevelControlStone() : base( 0xEDC )
		{
			Name = "Level System Control Stone ( DO NOT DELETE )";
			Hue = 1175;
			Visible = false;
			Movable = false;
			m_EnableLevelSystem = true;
			m_AllowSkillPts = true;
			m_AllowAging = true;
			m_AllowExp = true;
			m_AllowSPRewardSystem = true;
			m_AllowEXPRewardSystem = true;
			m_ServerName = "My";
			m_Static_LCStone = this;
		}
		
		public LevelControlStone( Serial serial ) : base( serial )
		{
		}
		
		public static void Initialize()
		{
			if ( m_Static_LCStone == null )
				GenLCS();
			else
				return;
		}
		
		public static void GenLCS()
		{
			if ( !LCSSpawn )
			{
				LCSSpawn = true;
				LevelControlStone fel_lcs = new LevelControlStone();
				fel_lcs.MoveToWorld( new Point3D(1501,1584,10), Map.Felucca );
			}
			
			else
				return;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if ( from.AccessLevel > AccessLevel.Seer )
			{
				from.CloseGump( typeof( LevelControlStoneGump  ) );
				from.SendGump( new LevelControlStoneGump() );
			}
			else
				this.Visible = false;
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write( (bool)LCSSpawn );
			writer.Write( (bool)m_Generated );
			writer.Write( (bool)m_EnableLevelSystem );
			writer.Write( (bool)m_AllowSkillPts );
			writer.Write( (bool)m_AllowAging );
			writer.Write( (bool)m_AllowExp );
			writer.WriteItemList( m_LevelKeepers );
			writer.Write( (bool)m_AllowSPRewardSystem );
			writer.Write( (bool)m_AllowEXPRewardSystem );
			writer.Write( (string) m_ServerName );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			LCSSpawn = reader.ReadBool();
			m_Generated = reader.ReadBool();
			m_EnableLevelSystem = reader.ReadBool();
			m_AllowSkillPts = reader.ReadBool();
			m_AllowAging = reader.ReadBool();
			m_AllowExp = reader.ReadBool();
			m_LevelKeepers = reader.ReadItemList();
			m_AllowSPRewardSystem = reader.ReadBool();
			m_AllowEXPRewardSystem = reader.ReadBool();
			m_ServerName = reader.ReadString();
		}
	}
}
