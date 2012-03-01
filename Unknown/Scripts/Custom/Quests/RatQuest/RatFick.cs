/*
*   Scripter : RatFick
*   Author : Lord Mashadow // Avalon Team
*   Generator : Avalon Script Creator
*   Created at :  3/5/2009 11:05:53 AM
*   Thank you for using this tool, feel free to visit our web site  www.avalon.gen.tr
*/
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "RatFick" )]
    public class RatFick : BaseCreature
    {
        [Constructable]
        public RatFick() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            this.Name = "RatFick";
            this.Hue = 2116;
            this.Body = 215;
            this.BaseSoundID = 107;

            this.SetStr( 78 );
            this.SetDex( 90 );
            this.SetInt( 10 );
            this.SetHits( 1250 );
            this.SetDamage( 6, 12 );
            this.SetDamageType( ResistanceType.Physical, 100 );
            this.SetResistance( ResistanceType.Physical, 25 );
            this.SetResistance( ResistanceType.Cold, 10 );
            this.SetResistance( ResistanceType.Fire, 10 );
            this.SetResistance( ResistanceType.Energy, 10 );
            this.SetResistance( ResistanceType.Poison, 25 );
            this.Fame = 100;

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

            c.DropItem( new Gold(22));
        }

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random(3 ) )
			{
				default:
                case 0: return WeaponAbility.InfectiousStrike;
            }
        }

        public RatFick( Serial serial ) : base( serial )
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