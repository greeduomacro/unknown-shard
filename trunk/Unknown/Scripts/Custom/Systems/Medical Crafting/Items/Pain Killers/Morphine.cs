using System;
using Server;

namespace Server.Items
{
	public class Morphine : BaseMedicalHealPotion
	{
		public override int MinHeal { get { return (Core.AOS ? 950 : 1000); } }
		public override int MaxHeal { get { return (Core.AOS ? 1200 : 1600); } }
		public override double Delay{ get{ return 0.1; } }

		[Constructable]
		public Morphine() : base( PotionEffect.HealGreater )
		{
      Name = "Morphine";
		}

		public Morphine( Serial serial ) : base( serial )
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