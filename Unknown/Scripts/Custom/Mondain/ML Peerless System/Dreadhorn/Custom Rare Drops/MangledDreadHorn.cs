//Written By Milkman Dan 2006
//Property of DemonicRidez.com

using System; 
using Server; 
using Server.Network; 

namespace Server.Items 
{ 
   public class MangledDreadHorn : Item 
   { 
      [Constructable] 
      public MangledDreadHorn() : base( 12630 ) 
      { 
         this.Name = "Mangled Head of Dreadhorn "; 
         this.Weight = 10; 
         this.Stackable = true; 
 
      } 

      
      public MangledDreadHorn( Serial serial ) : base( serial ) 
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