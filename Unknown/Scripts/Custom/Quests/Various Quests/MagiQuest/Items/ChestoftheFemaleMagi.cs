using System;
using Server;

namespace Server.Items
{
	public class ChestoftheFemaleMagi: FemalePlateChest
	{
		public override int ArtifactRarity{ get{ return 146; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public ChestoftheFemaleMagi()
		{
			Hue = 1153;
                        Name = "Chest Of The Female Magi";
			Attributes.Luck = 200;
			Attributes.DefendChance = 5;
			Attributes.LowerRegCost = 50;
         Attributes.BonusMana = 5;
         Attributes.BonusHits = 5;
			Attributes.RegenMana = 1;
                        Attributes.LowerManaCost = 5;
			ArmorAttributes.MageArmor = 1;
         Attributes.CastSpeed = 1;
         Attributes.SpellDamage = 15;
         Attributes.CastRecovery = 1;
                        FireBonus = 5;
			ColdBonus = 5;
                        PoisonBonus = 5;
                        PhysicalBonus = 5;
                        EnergyBonus = 5;

		}

		public ChestoftheFemaleMagi( Serial serial ) : base( serial )
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