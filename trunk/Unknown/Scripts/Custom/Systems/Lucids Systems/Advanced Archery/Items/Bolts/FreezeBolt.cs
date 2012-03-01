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
	public class FreezeBolt : Bolt, ICommodity
	{
		public static readonly TimeSpan PlayerFreezeDuration = TimeSpan.FromSeconds( 3.0 ); 
		public static readonly TimeSpan NPCFreezeDuration = TimeSpan.FromSeconds( 6.0 );

		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} freeze bolt" : "{0} freeze bolts", Amount );
			}
		}

		[Constructable]
		public FreezeBolt() : this( 1 )
		{
		}

		[Constructable]
		public FreezeBolt( int amount ) : base( 0x1BFB )
		{
			Name = "Freeze Bolt";
			Hue = 88;
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
		}

		public FreezeBolt( Serial serial ) : base( serial )
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
