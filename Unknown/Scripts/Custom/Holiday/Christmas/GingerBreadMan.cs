using System;
using Server;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network; 



namespace Server.Items
{

    public class GingerBreadMan : Food
    {

        [Constructable]
        public GingerBreadMan()
            : base(0x1044)
        {
            Weight = 1.0;
            ItemID = Utility.RandomList(0x2BE1, 0x2BE2); 
        }
    /*     //TODO Fix Speech
        public override bool HandlesOnMovement { get { return true; } }
      
        public override void OnMovement(Mobile m, Point3D oldLocation)
        {

            base.OnMovement(m, oldLocation);

            if (!IsChildOf(this))

            if (90> Utility.Random(100))
                return; // Random chance to talk

            if (m.InRange(this, 4))
            {
                switch (Utility.Random(2))
                {
                    case 0: m.SendLocalizedMessage(1077407); break;//Please. No! I have gingerkids!

                    case 1: m.SendLocalizedMessage(1077409); break;//Run, run as fast as you can! You can't catch me! I'm the gingerbread man!
                }                
            }
        }
    */
        public GingerBreadMan (Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); //Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }   
    }
}

