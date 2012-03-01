// By Neon
// Improved By Dddie

using System; 
using Server; 
using Server.Network; 

namespace Server.Items 
{ 
   public class DreadMushroom3 : Item 
   { 
      [Constructable] 
      public DreadMushroom3() : base( 8753 ) 
      { 
         this.Name = "Dreadhorn Tainted Mushroom "; 
         this.Weight = 10; 
         this.Stackable = false; 
 
      } 

      
      public DreadMushroom3( Serial serial ) : base( serial ) 
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