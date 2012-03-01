using System; 
using Server.Items; 

namespace Server.Items 
{ 
   public class SashOfTheMagi : BaseArmor
   { 
      public override int PhysicalResistance{ get{ return 2; } } 
                public override int FireResistance{ get{ return 2; } } 
                public override int ColdResistance{ get{ return 2; } } 
                public override int PoisonResistance{ get{ return 2; } } 
                public override int EnergyResistance{ get{ return 2; } } 

      public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

                public override int ArtifactRarity{ get{ return 10; } } 

      [Constructable] 
      public SashOfTheMagi() : base( 0x1541 ) 
      { 
         Weight = 1; 
                        Hue = 0x47e; 
                        Name = "Sash Of The Magi"; 
                        IntRequirement = 50;  
                        Attributes.RegenMana = 2; 
                        Attributes.SpellDamage = 5;
   

      } 

      public SashOfTheMagi( Serial serial ) : base( serial ) 
      { 
      } 
       
      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 
         writer.Write( (int) 0 ); 
      } 
        
      public override void Deserialize(GenericReader reader) 
      { 
         base.Deserialize( reader ); 
         int version = reader.ReadInt(); 
      } 
   } 
}  
 
