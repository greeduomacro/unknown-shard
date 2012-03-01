//Written by Lord Dalamar
using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using Server.Multis;
using Server.Mobiles;


namespace Server.Items
{

	public class MinaxCrystal : Item
	{
		[Constructable]
		public MinaxCrystal() : this( null )
		{
		}

		[Constructable]
		public MinaxCrystal ( string name ) : base ( 0x1F1C )
		{
			Name = "Crystal of Lady Minax";
			LootType = LootType.Blessed;
			Hue = 1172;
		}

		public MinaxCrystal ( Serial serial ) : base ( serial )
		{
		}

      		
		public override void OnDoubleClick( Mobile m )

		{
			Item d = m.Backpack.FindItemByType( typeof(SigilofMinax) );
			if ( d != null )
			{	
				Item c = m.Backpack.FindItemByType( typeof(SigilofLloth) );
				if ( c != null )
				{
					Item n = m.Backpack.FindItemByType( typeof(SigilofGoat) );
					if ( n != null )
					{
						Item p = m.Backpack.FindItemByType( typeof(SigilofTreefolk) );
						if ( p != null )
						{
							m.AddToBackpack( new BraceletofMinax() );
							d.Delete();
							c.Delete();
							n.Delete();
							p.Delete();
							m.SendMessage( "The four Sigils of the Minaxian Minions and Minax herself have been United!" );
						}
					}
					else
					{
						m.SendMessage( "You Are Missing Something..." );
					}
				}
			}
			
		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}