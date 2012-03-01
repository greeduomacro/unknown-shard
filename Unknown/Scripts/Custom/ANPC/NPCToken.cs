using System; 
using Server; 
using Server.Gumps; 
using Server.Network; 
using Server.Menus; 
using Server.Menus.Questions; 

namespace Server.Items 
{ 
   public class NPCToken : Item 
   { 
      [Constructable] 
      public NPCToken() : base( 0x193F ) 
      { 
         Hue = 37; 
         Movable = true; 
         Name = "NPC Token";
		 LootType = LootType.Blessed; 
      } 

      public NPCToken( Serial serial ) : base( serial ) 
      { 
      } 

      public override void OnDoubleClick( Mobile from )
	  { 
         from.SendGump( new NPCContractGump( from ) ); 
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