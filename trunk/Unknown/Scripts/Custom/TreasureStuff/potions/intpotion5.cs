using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class intincreaser1000 : Item
	{
		[Constructable]
		public intincreaser1000 () : base( 0x1836 )
		{
			base.Weight = 10.0;
			Name = "Intelligence Potion Level 5";
		}

		public intincreaser1000 ( Serial serial ) : base( serial )
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

				if( ( ( from.RawStr + from.RawInt + from.RawDex ) >= from.StatCap ) || from.RawInt >= 1000 )
				{
					from.SendMessage( "You are too smart" );
					return;
				}
				else
				{
					from.RawInt += 1;
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