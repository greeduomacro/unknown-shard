using System;
using Server;
using System.Collections;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using Server.LucidNagual;


namespace Server.Items
{
	public class FletchersScissors : Item
	{
		[Constructable]
		public FletchersScissors() : base( 0xDFC )
		{
			Name = "Fletcher's Scissors";
			Hue = 1153;
		}

		public override void OnDoubleClick(Mobile from)
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
				return;
			}
			else
			{
				double fletching = from.Skills[ SkillName.Fletching ].Base;
				
				if ( fletching > 30.0 )
				{
					from.Target = new CutStringTarget( from );
				}
				else
					from.SendMessage( "Only fletchers, with 30.0 skill points or higher, are allowed to use this instrument." );
			}
		}
		
		public FletchersScissors( Serial serial ) : base( serial )
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
