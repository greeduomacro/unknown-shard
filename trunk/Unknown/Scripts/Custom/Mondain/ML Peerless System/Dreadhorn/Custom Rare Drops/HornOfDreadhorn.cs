
//Written By Milkman Dan 2006
//Property of DemonicRidez.com
using System; 
using Server; 
using Server.Network; 

namespace Server.Items 
{ 
   public class HornOfDreadhorn : Item 
   { 
      [Constructable] 
      public HornOfDreadhorn() : base( 12636 ) 
      { 
         this.Name = "Horn of The Dreadhorn "; 
         this.Weight = 1.0; 
         this.Stackable = false; 
 
      } 

      
      public HornOfDreadhorn( Serial serial ) : base( serial ) 
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