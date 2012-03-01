/////////////////
///LostSinner///
///////////////
using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "a Benevolent corpse" )] 
	public class TheGuardian : BaseCreature 
	{

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

		[Constructable] 
		public TheGuardian() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Title = "the Guardian";
			Name = ( "Ri~aush" );
			BodyValue = 752;
			Hue = 1157;  

			SetStr( 700, 800 );
			SetDex( 291, 315 );
			SetInt( 600, 720 );

			SetHits( 3520, 3725 );

			SetDamage( 15, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 0, 1 );
			SetResistance( ResistanceType.Fire, 0, 1 );
			SetResistance( ResistanceType.Poison, 0, 1 );
			SetResistance( ResistanceType.Energy, 0, 1 );

			SetSkill( SkillName.EvalInt, 85.0, 100.0 );
			SetSkill( SkillName.Tactics, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.0, 97.5 );
			SetSkill( SkillName.Wrestling, 120.2, 160.0 );
			SetSkill( SkillName.Meditation, 120.0);
			SetSkill( SkillName.Focus, 120.0);
			SetSkill( SkillName.Magery, 110.0, 120.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 55;

            ME me = new ME();
            me.Hue = 1154;
            me.Movable = false;
            AddItem(me);

		}

        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }

		public override void GenerateLoot()
		{
            if (1 > Utility.RandomDouble()) // 1 = 100% = chance to drop 
                switch (Utility.Random(1))
                {
                    case 0: AddToBackpack(new AncientScroll1()); break;
                }
            PackGold(6700);
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.Gems, 5 );
		}

        public TheGuardian(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
        public override void OnDeath(Container c)
        {
            Mobile m = this.FindMostRecentDamager(false);

            if (m is PlayerMobile)
            {
                PlayerMobile pm = m as PlayerMobile;

                Item a = pm.Backpack.FindItemByType(typeof(Marker2));
                if (a != null)
                {
                    pm.AddToBackpack(new GuardianCrest());
                    pm.SendMessage("You've been granted an artifact for your effort.");
                }
                else
                {
                    pm.SendMessage("You have been found undeserving");
                }
            }
            else if (m is BaseCreature)
            {
                BaseCreature bc = m as BaseCreature;

                if (bc.Controlled == true)
                {
                    Item a = bc.ControlMaster.Backpack.FindItemByType(typeof(Marker2));
                    if (a != null)
                    {
                        bc.ControlMaster.AddToBackpack(new GuardianCrest());
                        bc.ControlMaster.SendMessage("You have been granted an artifact for you effort");
                    }
                    else
                    {
                        bc.ControlMaster.SendMessage("You have been found undeserving");
                    }
                }

            }
            base.OnDeath(c);
        }
    }
}
