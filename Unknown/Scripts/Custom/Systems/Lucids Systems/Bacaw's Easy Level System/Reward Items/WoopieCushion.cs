using System; 
using Server; 
using Server.Items;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.Misc;


namespace Server.Items
{ 
   	public class WoopieCushion : Item
   	{ 

       	[Constructable] 
      	public WoopieCushion() : base( 0x13A4 )
      	{ 
  			Name = "Woopie Cushion";
  			Movable = true;
  			Hue = 23;
  			LootType = LootType.Blessed;
      	} 

		public override void OnDoubleClick( Mobile from )
		{
			if (from.Female == true ) 
            { 
				Effects.PlaySound( from.Location, from.Map, 792);
					switch (Utility.Random( 6 ))
					{
							case 0: from.SendMessage( "Oh gross! Who was that?!?" );break;
							case 1: from.SendMessage( "Who farted?" );break;
							case 2: from.SendMessage( "Did someone light the sulfurous ash?" );break;
							case 3: from.SendMessage( "Did you say something?" );break;
							case 4: from.SendMessage( "Ehem. *cough* *cough*" );break;
							case 5: from.SendMessage( "I think I have to wipe now." );break;
					}
            } 
            else 
            { 
				Effects.PlaySound( from.Location, from.Map, 1064);
					switch (Utility.Random( 6 ))
					{
							case 0: from.SendMessage( "Oh gross! Who was that?!?" );break;
							case 1: from.SendMessage( "Who farted?" );break;
							case 2: from.SendMessage( "Did someone light the sulfurous ash?" );break;
							case 3: from.SendMessage( "Did you say something?" );break;
							case 4: from.SendMessage( "Ehem. *cough* *cough*" );break;
							case 5: from.SendMessage( "I think I have to wipe now." );break;
					}
			}
		}

		public override bool OnMoveOver( Mobile from )
		{
			if (from.Female == true ) 
            { 
				Effects.PlaySound( from.Location, from.Map, 792);
					switch (Utility.Random( 6 ))
					{
							case 0: from.SendMessage( "Oh gross! Who was that?!?" );break;
							case 1: from.SendMessage( "Who farted?" );break;
							case 2: from.SendMessage( "Did someone light the sulfurous ash?" );break;
							case 3: from.SendMessage( "Did you say something?" );break;
							case 4: from.SendMessage( "Ehem. *cough* *cough*" );break;
							case 5: from.SendMessage( "I think I have to wipe now." );break;
					}
            } 
            else 
            { 
				Effects.PlaySound( from.Location, from.Map, 1064);
					switch (Utility.Random( 6 ))
					{
							case 0: from.SendMessage( "Oh gross! Who was that?!?" );break;
							case 1: from.SendMessage( "Who farted?" );break;
							case 2: from.SendMessage( "Did someone light the sulfurous ash?" );break;
							case 3: from.SendMessage( "Did you say something?" );break;
							case 4: from.SendMessage( "Ehem. *cough* *cough*" );break;
							case 5: from.SendMessage( "I think I have to wipe now." );break;
					}
			}
			return true;
		}

		public WoopieCushion( Serial serial ) : base( serial ) 
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
