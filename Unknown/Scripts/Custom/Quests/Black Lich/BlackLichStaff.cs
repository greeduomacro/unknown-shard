using System;
using Server;

namespace Server.Items
{
	public class BlackLichStaff : BlackStaff
	{
		public override int ArtifactRarity{ get{ return 8; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public BlackLichStaff()
		{
            Name = "The Black Lich Staff";
			WeaponAttributes.MageWeapon = -5;
            Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = 1;
			Attributes.WeaponDamage = 50;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
		{
			phys = fire = cold = pois = 0;
			nrgy = 100;
		}

		public BlackLichStaff( Serial serial ) : base( serial )
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

			if ( WeaponAttributes.MageWeapon == 0 )
				WeaponAttributes.MageWeapon = 30;

			if ( ItemID == 0xDF1 )
				ItemID = 0xDF0;
		}
	}
}