using System;
using Server;


namespace Server.Items
{
	[Flipable( 0x1053, 0x1054 )]
	public class BaseGear : Item
	{
		public BaseGear() : this( 1 )
		{
		}
		
		public BaseGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}
		
		public BaseGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class SilverGear : BaseGear
	{
		[Constructable]
		public SilverGear() : this( 1 )
		{
		}
		
		[Constructable]
		public SilverGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Silver Gear";
		}
		
		public SilverGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class OrcSlayingGear : BaseGear
	{
		[Constructable]
		public OrcSlayingGear() : this( 1 )
		{
		}
		
		[Constructable]
		public OrcSlayingGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Orc Slaying Gear";
		}
		
		public OrcSlayingGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class TrollSlaughterGear : BaseGear
	{
		[Constructable]
		public TrollSlaughterGear() : this( 1 )
		{
		}
		
		[Constructable]
		public TrollSlaughterGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Troll Slaughter Gear";
		}
		
		public TrollSlaughterGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class OgreTrashinGear : BaseGear
	{
		[Constructable]
		public OgreTrashinGear() : this( 1 )
		{
		}
		
		[Constructable]
		public OgreTrashinGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Ogre Trashin Gear";
		}
		
		public OgreTrashinGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class RepondGear : BaseGear
	{
		[Constructable]
		public RepondGear() : this( 1 )
		{
		}
		
		[Constructable]
		public RepondGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Repond Gear";
		}
		
		public RepondGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class DragonSlayingGear : BaseGear
	{
		[Constructable]
		public DragonSlayingGear() : this( 1 )
		{
		}
		
		[Constructable]
		public DragonSlayingGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Dragon Slaying Gear";
		}
		
		public DragonSlayingGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class TerathanGear : BaseGear
	{
		[Constructable]
		public TerathanGear() : this( 1 )
		{
		}
		
		[Constructable]
		public TerathanGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Terathan Gear";
		}
		
		public TerathanGear( Serial serial ) : base( serial )
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

	[Flipable( 0x1053, 0x1054 )]
	public class SnakesBaneGear : BaseGear
	{
		[Constructable]
		public SnakesBaneGear() : this( 1 )
		{
		}
		
		[Constructable]
		public SnakesBaneGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Snakes Bane Gear";
		}
		
		public SnakesBaneGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class LizardmanSlaughterGear : BaseGear
	{
		[Constructable]
		public LizardmanSlaughterGear() : this( 1 )
		{
		}
		
		[Constructable]
		public LizardmanSlaughterGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Lizardman Slaughter Gear";
		}
		
		public LizardmanSlaughterGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class ReptilianDeathGear : BaseGear
	{
		[Constructable]
		public ReptilianDeathGear() : this( 1 )
		{
		}
		
		[Constructable]
		public ReptilianDeathGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Reptilian Death Gear";
		}
		
		public ReptilianDeathGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class DaemonDismissalGear : BaseGear
	{
		[Constructable]
		public DaemonDismissalGear() : this( 1 )
		{
		}
		
		[Constructable]
		public DaemonDismissalGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Daemon Dismissal Gear";
		}
		
		public DaemonDismissalGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class GargoylesFoeGear : BaseGear
	{
		[Constructable]
		public GargoylesFoeGear() : this( 1 )
		{
		}
		
		[Constructable]
		public GargoylesFoeGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Gargoyles Foe Gear";
		}
		
		public GargoylesFoeGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class BalronDamnationGear : BaseGear
	{
		[Constructable]
		public BalronDamnationGear() : this( 1 )
		{
		}
		
		[Constructable]
		public BalronDamnationGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Balron Damnation Gear";
		}
		
		public BalronDamnationGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class ExorcismGear : BaseGear
	{
		[Constructable]
		public ExorcismGear() : this( 1 )
		{
		}
		
		[Constructable]
		public ExorcismGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Exorcism Gear";
		}
		
		public ExorcismGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class OphidianGear : BaseGear
	{
		[Constructable]
		public OphidianGear() : this( 1 )
		{
		}
		
		[Constructable]
		public OphidianGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Ophidian Gear";
		}
		
		public OphidianGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class SpidersDeathGear : BaseGear
	{
		[Constructable]
		public SpidersDeathGear() : this( 1 )
		{
		}
		
		[Constructable]
		public SpidersDeathGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "SpidersDeath Gear";
		}
		
		public SpidersDeathGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class ScorpionsBaneGear : BaseGear
	{
		[Constructable]
		public ScorpionsBaneGear() : this( 1 )
		{
		}
		
		[Constructable]
		public ScorpionsBaneGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "SpidersDeath Gear";
		}
		
		public ScorpionsBaneGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class ArachnidDoomGear : BaseGear
	{
		[Constructable]
		public ArachnidDoomGear() : this( 1 )
		{
		}
		
		[Constructable]
		public ArachnidDoomGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Arachnid Doom Gear";
		}
		
		public ArachnidDoomGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class FlameDousingGear : BaseGear
	{
		[Constructable]
		public FlameDousingGear() : this( 1 )
		{
		}
		
		[Constructable]
		public FlameDousingGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Flame Dousing Gear";
		}
		
		public FlameDousingGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class WaterDissipationGear : BaseGear
	{
		[Constructable]
		public WaterDissipationGear() : this( 1 )
		{
		}
		
		[Constructable]
		public WaterDissipationGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Water Dissipation Gear";
		}
		
		public WaterDissipationGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class VacuumGear : BaseGear
	{
		[Constructable]
		public VacuumGear() : this( 1 )
		{
		}
		
		[Constructable]
		public VacuumGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Vacuum Gear";
		}
		
		public VacuumGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class ElementalHealthGear : BaseGear
	{
		[Constructable]
		public ElementalHealthGear() : this( 1 )
		{
		}
		
		[Constructable]
		public ElementalHealthGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Elemental Health Gear";
		}
		
		public ElementalHealthGear( Serial serial ) : base( serial )
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

	[Flipable( 0x1053, 0x1054 )]
	public class EarthShatterGear : BaseGear
	{
		[Constructable]
		public EarthShatterGear() : this( 1 )
		{
		}
		
		[Constructable]
		public EarthShatterGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Earth Shatter Gear";
		}
		
		public EarthShatterGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class BloodDrinkingGear : BaseGear
	{
		[Constructable]
		public BloodDrinkingGear() : this( 1 )
		{
		}
		
		[Constructable]
		public BloodDrinkingGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Blood Drinking Gear";
		}
		
		public BloodDrinkingGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class SummerWindGear : BaseGear
	{
		[Constructable]
		public SummerWindGear() : this( 1 )
		{
		}
		
		[Constructable]
		public SummerWindGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Summer Wind Gear";
		}
		
		public SummerWindGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class ElementalBanGear : BaseGear
	{
		[Constructable]
		public ElementalBanGear() : this( 1 )
		{
		}
		
		[Constructable]
		public ElementalBanGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Elemental Ban Gear";
		}
		
		public ElementalBanGear( Serial serial ) : base( serial )
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
	
	[Flipable( 0x1053, 0x1054 )]
	public class FeyGear : BaseGear
	{
		[Constructable]
		public FeyGear() : this( 1 )
		{
		}
		
		[Constructable]
		public FeyGear( int amount ) : base( 0x1053 )
		{
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			Name = "Fey Gear";
		}
		
		public FeyGear( Serial serial ) : base( serial )
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

