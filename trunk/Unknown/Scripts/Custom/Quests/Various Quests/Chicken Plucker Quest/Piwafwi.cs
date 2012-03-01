using System;

namespace Server.Items
{
	public class Piwafwi : BaseArmor
	{
		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 155; } }
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }

		[Constructable]
		public Piwafwi() :  base( 0x1515 )
		{
			Name = "piwafwi";
			Weight = 5.0;
			Attributes.ReflectPhysical = 5; 
			PhysicalBonus = 10; 
			Hue = 422;
		}

		public Piwafwi( Serial serial ) : base( serial )
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
	

