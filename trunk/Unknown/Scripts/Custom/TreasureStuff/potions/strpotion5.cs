using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class strincreaser1000 : Item
	{
		[Constructable]
		public strincreaser1000 () : base( 0xE28 )
		{
			base.Weight = 10.0;
			Name = "Strength Potion Level 5";
		}

		public strincreaser1000 ( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{

			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{

				if( ( ( from.RawStr + from.RawInt + from.RawDex ) >= from.StatCap ) || from.RawStr >= 1000 )
				{
					from.SendMessage( "You are too strong" );
					return;
				}
				else
				{
					from.RawStr += 1;
					Delete();
				}
			}
			else
			{
				from.SendMessage( "Too far away to drink" );
				return;
			}

		}
	}
}