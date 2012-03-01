//Written by Lord Dalamar
using System;
using Server;

namespace Server.Items
{
	public class GlovesMinax : LeatherGloves
	{	
		public override int ArtifactRarity{ get{ return 15; } }

		public override int InitMinHits{ get{ return 500; } }
		public override int InitMaxHits{ get{ return 500; } }
		
		[Constructable]
		public GlovesMinax()
		{
			Weight = 2.0;
					Name = "Gloves of Lady Minax";
			Hue = 1172;
			Attributes.CastRecovery = 5;
			Attributes.CastSpeed = 4;
				
			PhysicalBonus = 15;
			FireBonus = 15;
			ColdBonus = 15;
			PoisonBonus = 15;
			EnergyBonus = 15;
			
			LootType = LootType.Blessed;
	
		}

		public GlovesMinax( Serial serial ) : base( serial )
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