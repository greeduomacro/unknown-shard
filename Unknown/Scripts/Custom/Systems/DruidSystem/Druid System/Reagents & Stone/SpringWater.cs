using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class SpringWater : BaseReagent, ICommodity
   {
      string ICommodity.Description
      {
         get
         {
            return String.Format( "{0} spring water", Amount );
         }
      }

      [Constructable]
      public SpringWater() : this( 1 )
      {
      }

      [Constructable]
      public SpringWater( int amount ) : base( 0xE24, amount )
      {
         Hue = 0x47F;
         Name = "spring water";
      }

      public SpringWater( Serial serial ) : base( serial )
      {
      }

     /* public override Item Dupe( int amount )
      {
         return base.Dupe( new SpringWater( amount ), amount );
      }*/

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
