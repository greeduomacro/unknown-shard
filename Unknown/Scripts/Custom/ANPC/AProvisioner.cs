using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class AProvisioner : BaseVendor
	{
		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public AProvisioner() : base( "The Provisioner" )
		{
		    CantWalk = true;
		
			SetSkill( SkillName.Camping, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 45.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBProvisioner() );
		}

		public AProvisioner( Serial serial ) : base( serial )
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