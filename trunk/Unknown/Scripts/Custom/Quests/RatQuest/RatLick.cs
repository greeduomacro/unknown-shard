/*
*   Scripter : RatLick
*   Author : Lord Mashadow // Avalon Team
*   Generator : Avalon Script Creator
*   Created at :  3/5/2009 10:39:00 AM
*   Thank you for using this tool, feel free to visit our web site  www.avalon.gen.tr
*/
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "RatLick" )]
    public class RatLick : BaseCreature
    {
        [Constructable]
        public RatLick() : base( AIType.AI_Melee, FightMode.Closest, 3, 1, 0.2, 0.4 )
        {
            this.Name = "RatLick";
            this.Hue = 2945;
            this.Body = 251;
            this.BaseSoundID = 166;

            this.SetStr( 150 );
            this.SetDex( 100 );
            this.SetInt( 40 );
            this.SetHits( 1850 );
            this.SetDamage( 7, 14 );
            this.SetDamageType( ResistanceType.Physical, 100 );
            this.SetResistance( ResistanceType.Physical, 25 );
            this.SetResistance( ResistanceType.Cold, 10 );
            this.SetResistance( ResistanceType.Fire, 10 );
            this.SetResistance( ResistanceType.Energy, 10 );
            this.SetResistance( ResistanceType.Poison, 10 );
            this.Fame = 2000;

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

            c.DropItem( new Gold(1000));
            c.DropItem( new Bandage(5));
        }

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random(3 ) )
			{
				default:
                case 0: return WeaponAbility.InfectiousStrike;
            }
        }

        public RatLick( Serial serial ) : base( serial )
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