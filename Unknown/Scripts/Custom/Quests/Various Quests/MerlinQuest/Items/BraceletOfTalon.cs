
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server;

namespace Server.Items
{
	public class BraceletOfTalon : GoldBracelet
	{

        private StatMod m_StatMod90;

		[Constructable]
		public BraceletOfTalon()
		{
			Hue = 37;
			Name = "Bracelet Of Talon";
		}

        public BraceletOfTalon(Serial serial)
            : base(serial)
		{
		}

        public override void OnAdded(object parent)
        {
            if (parent is Mobile)
            {
                Mobile from = (Mobile)parent;

                m_StatMod90 = new StatMod(StatType.Int, "MOD90", -1000, TimeSpan.Zero);
                from.AddStatMod(m_StatMod90);
            }
            base.OnAdded(parent);
        }

        public override void OnRemoved(object parent)
        {
            if (parent is Mobile)
            {
                Mobile from = (Mobile)parent;

                Item x = from.Backpack.FindItemByType(typeof(Marker2));
                if (x != null)
                {
                    BaseWeapon weapon = from.Weapon as BaseWeapon;

                    from.RemoveStatMod("MOD90");
                }
                else
                {
                    from.SendMessage("You'll never remove the curse untill you have used merlins staff!");
                }
            }
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