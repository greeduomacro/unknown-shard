using System;
using Server;

namespace Server.Items
{
	public class Oxycontin : BaseMedicalHealPotion
	{
		public override int MinHeal { get { return (Core.AOS ? 550 : 600); } }
		public override int MaxHeal { get { return (Core.AOS ? 850 : 900); } }
		public override double Delay{ get{ return 0.5; } }

		[Constructable]
		public Oxycontin() : base( PotionEffect.HealGreater )
		{
      Name = "Oxycontin";
		}

		public Oxycontin( Serial serial ) : base( serial )
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