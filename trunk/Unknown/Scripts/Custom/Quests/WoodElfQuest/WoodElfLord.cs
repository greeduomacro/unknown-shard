/*
*   Scripter : WoofElf Lord
*   Author : Lord Mashadow // Avalon Team
*   Generator : Avalon Script Creator
*   Created at :  3/8/2009 5:40:30 PM
*   Thank you for using this tool, feel free to visit our web site  www.avalon.gen.tr
*/
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "WoodElf Lord" )]
    public class WoodElfLord : BaseCreature
    {
        [Constructable]
        public WoodElfLord() : base( AIType.AI_Predator, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            this.Name = "WoodElf Lord";
            this.Hue = 1941;
            this.Body = 606;

            this.SetStr( 160 );
            this.SetDex( 160 );
            this.SetInt( 100 );
            this.SetHits( 3600, 6500 );
            this.SetDamage( 30, 50 );
            this.SetDamageType( ResistanceType.Physical, 100 );
            this.SetResistance( ResistanceType.Physical, 25 );
            this.SetResistance( ResistanceType.Cold, 25 );
            this.SetResistance( ResistanceType.Fire, 25 );
            this.SetResistance( ResistanceType.Energy, 25 );
            this.SetResistance( ResistanceType.Poison, 25 );
            this.Fame = 1200;

			SetSkill( SkillName.MagicResist, 25.0, 47.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 15.0, 37.5 );
        }

        public override bool AlwaysMurderer{ get{ return true; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Fish; } }

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

            c.DropItem( new Gold(1000));
        }

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random(3 ) )
			{
				default:
                case 0: return WeaponAbility.BleedAttack;
                case 1: return WeaponAbility.ParalyzingBlow;
            }
        }

        public WoodElfLord( Serial serial ) : base( serial )
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