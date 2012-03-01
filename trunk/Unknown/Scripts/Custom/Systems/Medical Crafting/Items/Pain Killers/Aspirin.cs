using System;
using Server;

namespace Server.Items
{
	public class Aspirin : BaseMedicalHealPotion
	{
		public override int MinHeal { get { return (Core.AOS ? 60 : 30); } }
		public override int MaxHeal { get { return (Core.AOS ? 80 : 100); } }
		public override double Delay{ get{ return (Core.AOS ? 5.0 : 8.0); } }

		[Constructable]
		public Aspirin() : base( PotionEffect.HealLesser )
		{
      Name = "Aspirin";
		}

		public Aspirin( Serial serial ) : base( serial )
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