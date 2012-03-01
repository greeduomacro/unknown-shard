using System;

namespace Server.Items
{

	public class StatTalisman : BaseJewel
	{
		[Constructable]
		public StatTalisman() : base( GetRandomID(), Layer.Talisman )
		{
			Weight = 1.0;
		}

		public StatTalisman( Serial serial ) : base( serial )
		{
		}

		private static int[] m_ItemID = new int[] { 0x2F58, 0x2F59, 0x2F5A, 0x2F5B };
		
		public static int GetRandomID()
		{
			return m_ItemID[ Utility.Random( m_ItemID.Length ) ];
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
