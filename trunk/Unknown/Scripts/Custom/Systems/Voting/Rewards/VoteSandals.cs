using System; 
using Server; 

namespace Server.Items
{ 
	public class VoteSandals : Sandals
	{
		[Constructable]
		public VoteSandals()
		{
			Name = "I Voted!";
			Hue = 0xB;

			Attributes.BonusDex = 10;
			Attributes.BonusStr = 10;
			Attributes.BonusInt = 10;
			Attributes.BonusMana = 10;
			Attributes.BonusHits = 10;

			Resistances.Physical = 20;
			Resistances.Fire = 20;
			Resistances.Cold = 20;
			Resistances.Poison = 20;
			Resistances.Energy = 20;

			Attributes.CastSpeed = 4;
			Attributes.CastRecovery = 6;
		}

		public VoteSandals( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
} 