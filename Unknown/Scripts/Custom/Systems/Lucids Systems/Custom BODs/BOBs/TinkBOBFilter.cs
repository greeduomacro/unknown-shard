/*
 * Created by SharpDevelop.
 * User: Roger
 * Date: 02/21/2006
 * Time: 11:19 PM
 *
 */

using System;

namespace Server.Engines.BulkOrders
{
	public class TinkBOBFilter
	{
		private int m_Type;
		private int m_Quantity;
		
		public bool IsDefault
		{
			get{ return ( m_Type == 0 && m_Quantity == 0 ); }
		}
		
		public void Clear()
		{
			m_Type = 0;
			m_Quantity = 0;
		}
		
		public int Type
		{
			get{ return m_Type; }
			set{ m_Type = value; }
		}
		
		public int Quantity
		{
			get{ return m_Quantity; }
			set{ m_Quantity = value; }
		}
		
		public TinkBOBFilter()
		{
		}
		
		public TinkBOBFilter( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();
			
			switch ( version )
			{
				case 1:
					{
						m_Type = reader.ReadEncodedInt();
						m_Quantity = reader.ReadEncodedInt();
						
						break;
					}
			}
		}
		
		public void Serialize( GenericWriter writer )
		{
			if ( IsDefault )
			{
				writer.WriteEncodedInt( 0 ); // version
			}
			else
			{
				writer.WriteEncodedInt( 1 ); // version
				
				writer.WriteEncodedInt( m_Type );
				writer.WriteEncodedInt( m_Quantity );
			}
		}
	}
}
