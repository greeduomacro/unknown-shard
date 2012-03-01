#region AuthorHeader
//
//	SpellCrafting version 3.0, by Xanthos and TheOutkastDev
//
//  Based on original ideas and code by TheOutkastDev
//
#endregion AuthorHeader
using System;
using System.Collections;
using Server;
using Server.Mobiles;

namespace Server.SpellCrafting.Mobiles
{
	public class SpellCrafter : BaseVendor
	{
		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public SpellCrafter() : base( "the spellcrafter" )
		{
			SetSkill( SkillName.Alchemy, 90.0, 100.0 );
			SetSkill( SkillName.Inscribe, 90.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBSpellCraft() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			int hue = Utility.RandomNeutralHue();
			AddItem( new Server.Items.Robe( hue ) );
			AddItem( new Server.Items.WizardsHat( hue ) );
		}

		public SpellCrafter( Serial serial ) : base( serial )
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