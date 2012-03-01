 /*
    _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2006 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \     lucidnagual@gmail.com     \
    \_     ===================      \
     \   -Admin of "The Conjuring"-  \
      \_     ===================     ~\
       )       Advanced Archery        )
      /~    Version [3].0 & Above    _/
    _/_______________________________/
 -=(_)_______________________________)=-

 */

using System;


namespace Server.Items
{
	public class ArmorPiercingBolt : Bolt, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} armorpiercing bolt" : "{0} armorpiercing bolts", Amount );
			}
		}

		[Constructable]
		public ArmorPiercingBolt() : this( 1 )
		{
		}

		[Constructable]
		public ArmorPiercingBolt( int amount ) : base( 0x1BFB )
		{
			Name = "Armor Piercing Bolt";
			Hue = 1153;
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
		}

		public ArmorPiercingBolt( Serial serial ) : base( serial )
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
		}
	}
}
