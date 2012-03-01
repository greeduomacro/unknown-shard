/*********************************************************************************/
/*                PBEquipment.cs | PBGameItem.cs | PBPlayerStorage.cs            */
/*            PBScoreBoard.cs | PBScoreGump.cs | PBGMGump.cs | PBTimer.cs        */
/*                             Created by A_Li_N                                 */
/*         Credits:                                                              */
/*                      Original Idea + Some Code - Clarke76                     */
/*                      Some Ideas + Code - Lucid Nagual                         */
/*********************************************************************************/

using Server;
using System;
using System.Collections;
using Server.Mobiles;

namespace Server.Games.PaintBall
{
	public class PBScoreBoard : Item
	{
		public PBGameItem m_PBGI;
		public int Team1, Team2, Team3, Team4;

		[Constructable]
		public PBScoreBoard( PBGameItem pbgi ) : base( 0x1e5e )
		{
			Movable = true;
			m_PBGI = pbgi;
			Name = "Paintball Scoreboard";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( m_PBGI == null )
				Delete();
			else
			{
				from.CloseGump( typeof( PBScoreGump ) );
				from.SendGump( new PBScoreGump( m_PBGI ) );
			}
		}

		public PBScoreBoard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			if( m_PBGI != null )
				writer.Write( m_PBGI );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					m_PBGI = reader.ReadItem() as PBGameItem;
					break;
				}
			}
		}
	}
}
