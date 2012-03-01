////////////////////
// Shepherd Script//
//    by Liacs    //
//  Version 1.0   //
////////////////////

using System;
using Server.Mobiles;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a dog's corpse")]
    public class ShepherdsDog : BaseCreature
    {
        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

        private Shepherd m_shepherd;

        [CommandProperty(AccessLevel.GameMaster)]
        public Shepherd ShepherdA
        {
            get { return m_shepherd; }
            set { m_shepherd = value; }
        }

        [Constructable]
        public ShepherdsDog()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "a sheep dog";
            Body = 0xD9;
            Hue = Utility.RandomAnimalHue();
            BaseSoundID = 0x85;

            SetStr(27, 37);
            SetDex(28, 43);
            SetInt(29, 37);

            SetHits(17, 22);
            SetMana(0);

            SetDamage(4, 7);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 10, 15);

            SetSkill(SkillName.MagicResist, 22.1, 47.0);
            SetSkill(SkillName.Tactics, 19.2, 31.0);
            SetSkill(SkillName.Wrestling, 19.2, 31.0);

            Fame = 600;
            Karma = 0;

            VirtualArmor = 12;

            Tamable = false;
        }

        public override void OnCombatantChange()
        {
            if (Combatant != null && Combatant.Alive && m_shepherd != null && m_shepherd.Combatant == null)
            {
                m_shepherd.Combatant = Combatant;
                m_shepherd.Say("Hey, my dog! Leave it alone!");
            }
        }

        public ShepherdsDog(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
            writer.Write(m_shepherd);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_shepherd = (Shepherd)reader.ReadMobile();
        }
    }
}