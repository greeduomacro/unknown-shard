using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class PetrafiedWood : BaseReagent, ICommodity
   {
      string ICommodity.Description
      {
         get
         {
            return String.Format( "{0} petrified wood", Amount );
         }
      }

      [Constructable]
      public PetrafiedWood() : this( 1 )
      {
      }

      [Constructable]
      public PetrafiedWood( int amount ) : base( 0x97A, amount )
      {
         Hue = 0x46C;
         Name = "petrified wood";
      }

      public PetrafiedWood( Serial serial ) : base( serial )
      {
      }

      /*public override Item Dupe( int amount )
      {
         return base.Dupe( new PetrafiedWood( amount ), amount );
      }*/

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 1 ); // version
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();
      		if (version==0)
      		this.ItemID=3984;
      }
   }
}
