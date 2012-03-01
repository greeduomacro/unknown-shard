//Written by Lord Dalamar
using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class BraceletofMinax : SilverBracelet
   {
	
       

      [Constructable]
      public BraceletofMinax()
      {
         Weight = 5.0;
         Name = "Bracelet of Minax";
         Layer = Layer.Bracelet;
         Hue = 1172;
	 Attributes.BonusHits = 15;
	 Attributes.RegenHits = 5;
	 Attributes.BonusStam = 5;
	 Attributes.RegenStam = 5;
	 Attributes.WeaponDamage = 25;
      }

	  public override void OnDoubleClick( Mobile m )

	  {
         if( Parent != m )
         {
            m.SendMessage( "You must be wearing the Bracelet to use it!" );
		 }

		 else
	      {
			if ( m.Mounted )
			{
				m.SendMessage( "You can't activate this while riding." );
			
				}

		 else
		 {
			if ( m.Body == 400 )
			{
               m.SendMessage( "You feel yourself changing." );
               m.PlaySound( 357 );
		   m.Body = 40;
               m.BodyMod = 0x0;
               m.Hue =1172;
               Attributes.BonusStr = 50;
               Attributes.BonusInt = 50;
               Attributes.BonusDex = 50;
               m.NameMod = "Minion of Minax";
               m.RemoveItem(this);
               m.EquipItem(this);
               if( m.Kills >= 5)
               {
               m.Criminal = true;
                }
                if( m.GuildTitle != null)
               {
                  m.DisplayGuildTitle = true;
                }
			}


            else if ( m.Body == 40 )
            {
			   m.SendMessage( "You feel yourself changing." );
               m.PlaySound( 357 );
			   m.Body = 400;
               m.BodyMod = 0x0;
               m.Hue = 33780;
               Attributes.BonusStr = 0;
               Attributes.BonusInt = 0;
               Attributes.BonusDex = 0;
               m.NameMod = null;
               m.DisplayGuildTitle = false;
               m.Criminal = false;
               m.RemoveItem(this);
               m.EquipItem(this);
            }
            else if ( m.Body == 401 )
            {
               m.SendMessage( "You feel yourself changing." );
               m.PlaySound( 1200 );
		   m.Body = 149;	
               m.BodyMod = 0x0;
               m.Hue = 1172;
               Attributes.BonusStr = 50;
               Attributes.BonusInt = 50;
               Attributes.BonusDex = 50;
               m.NameMod = "Minion of Minax";
               m.DisplayGuildTitle = false;
               m.Criminal = false;
               m.RemoveItem(this);
               m.EquipItem(this);
            }
            else if ( m.Body == 149 )
            {
               m.SendMessage( "You feel yourself changing." );
               m.PlaySound( 1200 );
               m.Body = 401;
               m.BodyMod = 0x0;
               m.Hue = 33780;
               m.Hits = m.HitsMax ;
               m.Mana = m.ManaMax ;
               m.Stam = m.StamMax ;
               m.NameMod = null;
               m.DisplayGuildTitle = false;
               m.Criminal = false;
               m.RemoveItem(this);
               m.EquipItem(this);
            }

         }
      }
    }

      public override void OnRemoved( Object o )
	  {

      if( o is Mobile )
      {
          ((Mobile)o).NameMod = null;
      }
      if( o is Mobile && ((Mobile)o).Kills >= 5)
               {
               ((Mobile)o).Criminal = true;
                }
      if( o is Mobile && ((Mobile)o).GuildTitle != null )
               {
          ((Mobile)o).DisplayGuildTitle = true;
                }
      base.OnRemoved( o );
      }

      public BraceletofMinax( Serial serial ) : base( serial )
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
