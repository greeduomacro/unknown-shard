using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class RezzingVet : BaseVendor
	{
        private DateTime m_NextResurrect;
        private static TimeSpan ResurrectDelay = TimeSpan.FromSeconds(2.0);

		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public RezzingVet() : base( "the vet" )
		{
			SetSkill( SkillName.AnimalLore, 85.0, 100.0 );
			SetSkill( SkillName.Veterinary, 90.0, 100.0 );
		}

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            BaseCreature petPatient = m as BaseCreature;

            if (petPatient != null && petPatient.IsBonded && !petPatient.Frozen
                && DateTime.Now >= m_NextResurrect && InRange(petPatient, 4)
                && InLOS(petPatient))
            {
                if (petPatient.IsDeadPet)
                {
                    m_NextResurrect = DateTime.Now + ResurrectDelay;

                    if (petPatient.Map == null || !petPatient.Map.CanFit(m.Location, 16, false, false))
                    {
                        //m.SendLocalizedMessage(502391); // Thou can not be resurrected there!
                    }
                    else
                    {
                        OfferResurrection(petPatient);
                    }
                }
            }
        }

        public virtual void OfferResurrection(BaseCreature petPatient)
        {
            if (petPatient != null && petPatient.IsDeadPet)
            {
                Mobile master = petPatient.ControlMaster;

                if (master != null && master.InRange(petPatient, 3))
                {
                    //healerNumber = 503255; // You are able to resurrect the creature.

                    master.CloseGump(typeof(PetResurrectGump));
                    master.SendGump(new PetResurrectGump(this, petPatient));
                }
                else
                {

                    List<Mobile> friends = petPatient.Friends;

                    for (int i = 0; friends != null && i < friends.Count; ++i)
                    {
                        Mobile friend = friends[i];

                        if (friend.InRange(petPatient, 3))
                        {
                            //healerNumber = 503255; // You are able to resurrect the creature.

                            friend.CloseGump(typeof(PetResurrectGump));
                            friend.SendGump(new PetResurrectGump(this, petPatient));

                            break;
                        }
                    }

                    //if (!found)
                        //healerNumber = 1049670; // The pet's owner must be nearby to attempt resurrection.
                }
            }

        }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBVeterinarian() );
		}

        public RezzingVet(Serial serial) : base(serial)
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