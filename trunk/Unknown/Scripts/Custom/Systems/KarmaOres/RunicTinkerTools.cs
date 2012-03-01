using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[Flipable( 0x1EB8, 0x1EB9 )]
	public class RunicTinkerTools : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefTinkering.CraftSystem; } }

		public override int LabelNumber { get { return 1044164; } }

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			if ( !CraftResources.IsStandard( Resource ) )
				list.Add( 1060662, "{0}\t{1}", "Resource"	, CraftResources.GetName( Resource ) );
		}

		[Constructable]
		public RunicTinkerTools( CraftResource resource ) : this( resource, 50 )
		{
		}

		[Constructable]
		public RunicTinkerTools( CraftResource resource, int uses ) : base( resource, uses, 0x1EB8 )
		{
			Name = "Runic Tinker's Tools";
			Weight = 1.0;
			Hue = CraftResources.GetHue( resource );
		}

		public RunicTinkerTools( Serial serial ) : base( serial )
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