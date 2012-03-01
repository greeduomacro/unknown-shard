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
       )      Advanced Archery         )
      /~      Version [2].0.1        _/
    _/_______________________________/
 -=(_)_______________________________)=-
 */
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;


namespace Server.Items
{
	[FlipableAttribute( 0x2D1F, 0x2D2B )]
	public class MagicalShortbow : BaseRanged
	{
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType { get { return GetArrowSelected(); } }
		public override Item Ammo { get { return AmmoArrowSelected(); } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override int AosSpeed{ get{ return 38; } }

		public override int OldStrengthReq{ get{ return 45; } }
		public override int OldMinDamage{ get{ return 14; } }
		public override int OldMaxDamage{ get{ return 16; } }
		public override int OldSpeed{ get{ return 38; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 40; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }
		
		[Constructable]
		public MagicalShortbow() : base( 0x2D1F )
		{
			Weight = 10.0;
			Layer = Layer.TwoHanded;
		}	

		public MagicalShortbow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(( int )0 ); // version
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
			if (Weight == 7.0)
				Weight = 6.0;

			if (version == 0)
				version = 1;
		}
	}
}
