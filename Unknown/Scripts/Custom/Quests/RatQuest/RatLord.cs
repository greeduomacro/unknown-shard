/*
*   Scripter : RatLord
*   Author : Lord Mashadow // Avalon Team
*   Generator : Avalon Script Creator
*   Created at :  3/5/2009 11:12:21 AM
*   Thank you for using this tool, feel free to visit our web site  www.avalon.gen.tr
*/
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "RatLord" )]
    public class RatLord : BaseCreature
    {
        [Constructable]
        public RatLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            this.Name = "RatLord";
            this.Hue = 1901;
            this.Body = 42;
            this.BaseSoundID = 19;

            this.SetStr( 220 );
            this.SetDex( 180 );
            this.SetInt( 35 );
            this.SetHits( 3080 );
            this.SetDamage( 10, 30 );
            this.SetDamageType( ResistanceType.Physical, 100 );
            this.SetResistance( ResistanceType.Physical, 35 );
            this.SetResistance( ResistanceType.Cold, 10 );
            this.SetResistance( ResistanceType.Fire, 10 );
            this.SetResistance( ResistanceType.Energy, 10 );
            this.SetResistance( ResistanceType.Poison, 35 );
            this.Fame = 2200;
            this.VirtualArmor = 10;

            SetSkill(SkillName.EvalInt, 85.0, 100.0);
            SetSkill(SkillName.Tactics, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 75.0, 97.5);
            SetSkill(SkillName.Wrestling, 100.2, 105.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Focus, 120.0);
            SetSkill(SkillName.Swords, 110.0, 120.0);
        }

        public override bool CanRummageCorpses{ get{ return true; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

            c.DropItem( new Gold(1500));
            c.DropItem( new Bandage(12));
        }

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random(2 ) )
			{
				default:
                case 0: return WeaponAbility.InfectiousStrike;
                case 1: return WeaponAbility.BleedAttack;
            }
        }

        public RatLord( Serial serial ) : base( serial )
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
        }
    }
}