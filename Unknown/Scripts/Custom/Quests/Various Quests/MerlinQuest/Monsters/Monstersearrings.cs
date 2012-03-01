/////////////////////////////
//////  LostSinner  /////////
/////////////////////////////

using System;
namespace Server.Items
{
    public class ME : BaseEarrings
    {
        public override int ArtifactRarity { get { return 75; } }

        [Constructable]
        public ME() : base(0x1F07)
            
        {
            LootType = LootType.Blessed;
            Hue = 1150;
            Attributes.WeaponDamage = 15;
            Attributes.WeaponSpeed = 15;
            Attributes.ReflectPhysical = 15;
            Attributes.CastSpeed = 12;
            Attributes.CastRecovery = 13;
            Attributes.RegenMana = 5;
            Attributes.RegenHits = 5;
            Attributes.BonusHits = 25;
        }

        public ME(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}