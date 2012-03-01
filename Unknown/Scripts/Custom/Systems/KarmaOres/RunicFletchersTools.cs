using System; 
using Server; 
using Server.Engines.Craft; 

namespace Server.Items 
{ 
	[FlipableAttribute( 0x1022, 0x1023 )] 
	public class RunicFletchersTools : BaseRunicTool 
	{ 
		public override CraftSystem CraftSystem{ get{ return DefBowFletching.CraftSystem; } } 

		public override int LabelNumber 
		{ 
			get 
			{ 
				int index = CraftResources.GetIndex( Resource ); 

				if ( index >= 301 && index <= 311 ) 
					return 1042598 + index; 

				return 1044166;
			} 
		} 

		public override void AddNameProperties( ObjectPropertyList list ) 
		{ 
			base.AddNameProperties( list ); 

			int index = CraftResources.GetIndex( Resource ); 

			if ( index >= 301 && index <= 311 ) 
				return; 

			if ( !CraftResources.IsStandard( Resource ) ) 
			{ 
				int num = CraftResources.GetLocalizationNumber( Resource ); 

				if ( num > 0 ) 
					list.Add( num ); 
				else 
					list.Add( CraftResources.GetName( Resource ) ); 
			} 
		} 

		[Constructable] 
		public RunicFletchersTools( CraftResource resource ) : base( resource, 0x1022 ) 
		{ 
			Weight = 2.0;
			Hue = CraftResources.GetHue( resource );
		} 

		[Constructable] 
		public RunicFletchersTools( CraftResource resource, int uses ) : base( resource, uses, 0x1022 ) 
		{ 
			Weight = 2.0;
			Hue = CraftResources.GetHue( resource );
		} 

		public RunicFletchersTools( Serial serial ) : base( serial ) 
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