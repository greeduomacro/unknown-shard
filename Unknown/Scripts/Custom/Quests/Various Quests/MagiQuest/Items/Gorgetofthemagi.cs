using System;
using Server;

namespace Server.Items
{
	public class Gorgetofthemagi: PlateGorget
	{
		public override int ArtifactRarity{ get{ return 146; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public Gorgetofthemagi()
		{
			Hue = 1153; 
                        Name = "Gorget Of The Magi";
                        Attributes.LowerManaCost = 5;
                        Attributes.BonusInt = 5;
         Attributes.BonusHits = 5;
         Attributes.BonusMana = 5;
			Attributes.RegenMana = 2;
			Attributes.BonusDex = 5;
			Attributes.RegenHits = 2;
			Attributes.RegenStam = 5;
         Attributes.CastSpeed = 1;
         Attributes.SpellDamage = 15;
         Attributes.CastRecovery = 1;
			FireBonus = 5;
			ColdBonus = 5;
                        PoisonBonus = 5;
                        PhysicalBonus = 5;
                        EnergyBonus = 5;
		}

		public Gorgetofthemagi( Serial serial ) : base( serial )
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