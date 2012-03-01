//Written By Milkman Dan 2006
//Property of DemonicRidez.com
using System; 
using Server; 
using Server.Network; 

namespace Server.Items 
{ 
   public class DreadMushroom4 : Item 
   { 
      [Constructable] 
      public DreadMushroom4() : base( 8752 ) 
      { 
         this.Name = "Dreadhorn Tainted Mushroom "; 
         this.Weight = 10; 
         this.Stackable = false; 
 
      } 

      
      public DreadMushroom4( Serial serial ) : base( serial ) 
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