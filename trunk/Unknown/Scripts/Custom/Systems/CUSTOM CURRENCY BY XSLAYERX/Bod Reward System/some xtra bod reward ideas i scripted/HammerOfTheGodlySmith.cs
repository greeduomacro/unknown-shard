//Please Leave Credit XSlayerX aka XLacaestX
using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x13E4, 0x13E3 )]
	public class HammerOfTheGodlySmith : BaseTool
    {
        private SkillMod m_SkillMod0;
        private SkillMod m_SkillMod2;
        
        public override CraftSystem CraftSystem{ get{ return DefBlacksmithy.CraftSystem; } }

		[Constructable]
		public HammerOfTheGodlySmith() : base( 0x13E3 )
		{
			Weight = 8.0;
            Name = "Hammer Of The Godly Smith";
            Hue = 0x489;
			Layer = Layer.OneHanded;

            DefineMods();
		} 

		private void DefineMods()
		{
            m_SkillMod0 = new DefaultSkillMod(SkillName.Blacksmith, true, 15);
            m_SkillMod2 = new DefaultSkillMod(SkillName.Mining, true, 15);
          
		}
		
        [Constructable]
		public HammerOfTheGodlySmith  ( int uses ) : base( uses, 500 )

        
		{
			Weight = 8.0;
            Layer = Layer.OneHanded;
		}

        public HammerOfTheGodlySmith(Serial serial)
            : base(serial)
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