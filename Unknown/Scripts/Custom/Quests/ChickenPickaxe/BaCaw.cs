/*
*   Scripter : Ba Caw
*   Author : Lord Mashadow // Avalon Team
*   Generator : Avalon Script Creator
*   Created at :  3/26/2009 2:26:01 AM
*   Thank you for using this tool, feel free to visit our web site  www.avalon.gen.tr
*/
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "Ba Caw" )]
    public class BaCaw : BaseCreature
    {
        [Constructable]
        public BaCaw() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            this.Name = "Ba Caw";
            this.Hue = 1939;
            this.Body = 30;
            this.BaseSoundID = 110;

            this.SetStr( 300 );
            this.SetDex( 300 );
            this.SetInt( 300 );
            this.SetHits( 11800 );
            this.SetDamage( 10, 20 );
            this.SetDamageType( ResistanceType.Physical, 100 );
            this.SetResistance( ResistanceType.Physical, 30 );
            this.SetResistance( ResistanceType.Cold, 30 );
            this.SetResistance( ResistanceType.Fire, 30 );
            this.SetResistance( ResistanceType.Energy, 30 );
            this.SetResistance( ResistanceType.Poison, 30 );
            this.Fame = 1200;
            this.VirtualArmor = 30;
        }

        public override bool AlwaysMurderer{ get{ return true; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

            c.DropItem( new Gold(2500));
        }

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random(3 ) )
			{
				default:
                case 0: return WeaponAbility.BleedAttack;
            }
        }

        public BaCaw( Serial serial ) : base( serial )
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