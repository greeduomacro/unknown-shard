using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class Cartographer : BaseVendor
	{
		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Cartographer() : base( "the cartographer" )
		{
			SetSkill( SkillName.Cartography, 90.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBMapmaker() );
			m_SBInfos.Add( new Cartographer() );
		}

		public override void InitOutfit()
		{
			AddItem( new Server.Items.Tunic( Utility.RandomBlueHue() ) );
			AddItem( new Server.Items.Boots() );
			AddItem( new Server.Items.Cloak( Utility.RandomGreenHue() ) );
			AddItem( new Server.Items.TricorneHat( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.LongPants( Utility.RandomBlueHue() ) );
		}

		public Cartographer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}