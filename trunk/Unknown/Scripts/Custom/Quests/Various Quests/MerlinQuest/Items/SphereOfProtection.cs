
//////////////////////////
//Created by LostSinner//
////////////////////////
using System;
using Server.Items;

namespace Server.Items 
{
    public class SphereOfProtection : Item
    {

        [Constructable]
        public SphereOfProtection()
         
        {
            Weight = 1.0;
            Name = "Sphere of Protection";
            ItemID = 3699;
            Hue = 1153;
        }

        public SphereOfProtection(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
} 