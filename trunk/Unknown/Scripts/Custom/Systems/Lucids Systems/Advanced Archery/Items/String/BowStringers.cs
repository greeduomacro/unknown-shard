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
	public class BaseStringer : Item
	{
		public BaseStringer( int itemID ) : base( itemID )
		{
			Weight = 1.0;
		}
		
		public BaseStringer( Serial serial ) : base( serial )
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
			
			if ( Weight == 3.0 )
				Weight = 5.0;
		}
	}
	
	public class HorseHairStringer : BaseStringer
	{
		[Constructable]
		public HorseHairStringer() : base( 0x2DD7 )
		{
			Name = "Horse Hair [Stringer]";
			Hue = 443;
		}
		
		[Constructable]
		public HorseHairStringer( Serial serial ) : base( serial )
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
			
			if ( Weight == 0.0 )
				Weight = 1.0;
		}
	}
	
	public class AngelHairStringer : BaseStringer
	{
		[Constructable]
		public AngelHairStringer() : base( 0x2DD7 )
		{
			Name = "Angel Hair [Stringer]";
			Hue = 1174;
		}
		
		public AngelHairStringer( Serial serial ) : base( serial )
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
			
			if ( Weight == 0.0 )
				Weight = 1.0;
		}
	}
	
	public class LinenThreadStringer : BaseStringer
	{
		[Constructable]
		public LinenThreadStringer() : base( 0x2DD7 )
		{
			Name = "Linen Thread [Stringer]";
		}
		
		public LinenThreadStringer( Serial serial ) : base( serial )
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
			
			if ( Weight == 0.0 )
				Weight = 1.0;
		}
	}
	
	public class SilkStringer : BaseStringer
	{
		[Constructable]
		public SilkStringer() : base( 0x2DD7 )
		{
			Name = "Silk [Stringer]";
			Hue = 618;
		}
		
		public SilkStringer( Serial serial ) : base( serial )
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
			
			if ( Weight == 0.0 )
				Weight = 1.0;
		}
	}
	
	public class CottonStringer : BaseStringer
	{
		[Constructable]
		public CottonStringer() : base( 0x2DD7 )
		{
			Name = "Cotton [Stringer]";
			Hue = 655;
		}
		
		public CottonStringer( Serial serial ) : base( serial )
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
			
			if ( Weight == 0.0 )
				Weight = 1.0;
		}
	}
	
	public class HempStringer : BaseStringer
	{
		[Constructable]
		public HempStringer() : base( 0x2DD7 )
		{
			Name = "Hemp [Stringer]";
			Hue = 49;
		}
		
		public HempStringer( Serial serial ) : base( serial )
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
			
			if ( Weight == 0.0 )
				Weight = 1.0;
		}
	}
}
