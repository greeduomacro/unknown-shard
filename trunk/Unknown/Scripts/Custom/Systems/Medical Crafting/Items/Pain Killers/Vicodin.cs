using System;
using Server;

namespace Server.Items
{
	public class Vicodin : BaseMedicalHealPotion
	{
		public override int MinHeal { get { return (Core.AOS ? 250 : 300); } }
		public override int MaxHeal { get { return (Core.AOS ? 350 : 500); } }
		public override double Delay{ get{ return 1.0; } }

		[Constructable]
		public Vicodin() : base( PotionEffect.HealGreater )
		{
      Name = "Vicodin";
		}

		public Vicodin( Serial serial ) : base( serial )
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