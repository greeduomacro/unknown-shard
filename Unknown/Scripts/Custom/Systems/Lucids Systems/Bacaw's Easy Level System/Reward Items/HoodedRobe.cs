using System;
using Server;
using Server.Items;

namespace Server.Items
{
   [FlipableAttribute( 0x2683, 0x2684 )]
   public class HoodedRobe : BaseOuterTorso
   {
      [Constructable]
      public HoodedRobe() : base( 0x2683 )
      {
         Weight = 5.0;
         Name = "Shroud";
         Layer = Layer.OuterTorso;
      }

      public override void OnDoubleClick( Mobile m )
      {
         if( Parent != m )
         {
            m.SendMessage( "You must be wearing the robe to use it!" );
         }
         else
         {
            if ( ItemID == 0x2683 || ItemID == 0x2684 )
            {
               m.SendMessage( "You lower the hood." );
               m.PlaySound( 0x57 );
               ItemID = 0x1F03;
               m.NameMod = null;
               m.RemoveItem(this);
               m.EquipItem(this);
               /*if( m.Kills >= 5)
               {
               m.Criminal = true;
                }
                if( m.GuildTitle != null)
               {
                  m.DisplayGuildTitle = true;
                }*/
            }
            else if ( ItemID == 0x1F03 || ItemID == 0x1F04 )
            {
               m.SendMessage( "You pull the hood over your head." );
               m.PlaySound( 0x57 );
               ItemID = 0x2683;
               //m.NameMod = "shrouded figure";
               //m.ShowFameTitle = false;
               //m.DisplayGuildTitle = false;
               //m.Criminal = false;
               //m.Title = "a";
               m.RemoveItem(this);
               m.EquipItem(this);

            }
         }
      }

       /*public override bool OnEquip( Mobile from )
      {
         if ( ItemID == 0x2683 )
         {
         from.NameMod = "shrouded figure";
         //from.Title = "a";
         from.DisplayGuildTitle = false;
         from.Criminal = false;
         }
         return base.OnEquip(from);
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
      }*/

      public HoodedRobe( Serial serial ) : base( serial )
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
