
//Written By Milkman Dan 2006
//Property of DemonicRidez.com
using System; 
using Server; 
using Server.Network; 

namespace Server.Items 
{ 
   public class HornOfDreadhorn2 : Item 
   { 
      [Constructable] 
      public HornOfDreadhorn2() : base( 12637 ) 
      { 
         this.Name = "Horn of The Dreadhorn "; 
         this.Weight = 1.0; 
         this.Stackable = false; 
 
      } 

      
      public HornOfDreadhorn2( Serial serial ) : base( serial ) 
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