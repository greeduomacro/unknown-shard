/////////////////////////////
//////  LostSinner  /////////
/////////////////////////////

using System;
namespace Server.Items
{
    public class MerlinsEarrings : BaseEarrings
    {
        public override int ArtifactRarity { get { return 75; } }

        [Constructable]
        public MerlinsEarrings() : base(0x1F07)
            
        {
            LootType = LootType.Blessed;
            Name = "Merlin's Earrings";
            Hue = 1150;
            Attributes.WeaponDamage = 15;
            Attributes.WeaponSpeed = 15;
            Attributes.ReflectPhysical = 15;
            Attributes.CastSpeed = 2;
            Attributes.CastRecovery = 3;
            Attributes.RegenMana = 5;
            Attributes.RegenHits = 5;
            Attributes.BonusHits = 25;
        }

        public MerlinsEarrings(Serial serial)
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