using System;
using Server;

namespace Server.Items
{
	public class Demerol : BaseMedicalHealPotion
	{
		public override int MinHeal { get { return (Core.AOS ? 130 : 160); } }
		public override int MaxHeal { get { return (Core.AOS ? 160 : 200); } }
		public override double Delay{ get{ return (Core.AOS ? 1.0 : 1.5); } }

		[Constructable]
		public Demerol() : base( PotionEffect.Heal )
		{
      Name = "Demerol";
		}

		public Demerol( Serial serial ) : base( serial )
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