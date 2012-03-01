/*  _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2005 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \     lucidnagual@gmail.com     \
    \_     ===================      \
     \   -Admin of "The Conjuring"-  \
      \_     ===================     ~\
       )       Ultimate Quiver         )
      /~      Version [1].0.0        _/
    _/_______________________________/
 -=(_)_______________________________)=-
 */
using System;

namespace Server.Items
{
	[Flipable( 0x2FB7, 0x3171 )]
	public class ElvenQuiver : BaseQuiver
	{
		public override int MaxWeight{ get{ return 250; } }

		[Constructable]
		public ElvenQuiver() : base( 0x2FB7 )
		{
			Name = "Elven Quiver";

			Attributes.DefendChance = 5; //Defense Chance 15%
			Attributes.WeaponDamage = 10; //Weapon Damage 15%

			LowerAmmoCost = 10; //Lower Ammo Cost Mod

			SkillBonuses.SetValues( 0, SkillName.Archery, 3.0 ); /*= Utility.Random( 0,4 );*/
		}

		public override bool OnEquip( Mobile from )
		{
			Name = from.Name + "'s Quiver";

			return base.OnEquip(from);
		}

		public override void OnRemoved( object parent )
		{
			base.OnRemoved(parent);

			Name = "Elven Quiver";

			return;
		}


		public ElvenQuiver( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( Layer != Layer.MiddleTorso )
				Layer = Layer.MiddleTorso;
		}
	}
}

