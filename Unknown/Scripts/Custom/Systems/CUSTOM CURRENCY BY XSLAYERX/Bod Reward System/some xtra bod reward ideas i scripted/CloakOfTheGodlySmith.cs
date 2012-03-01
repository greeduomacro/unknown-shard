//Please Leave Credit XSlayerX aka XLacaestX
using System;
using Server.Misc;

namespace Server.Items
{
	[FlipableAttribute( 0x1515, 0x1530 )] 
	public class CloakOfTheGodlySmith: Cloak 
	{
	private SkillMod m_SkillMod0;
	private SkillMod m_SkillMod1;
	private SkillMod m_SkillMod2;
	private SkillMod m_SkillMod3;
	private SkillMod m_SkillMod4;
	private SkillMod m_SkillMod5;
	private SkillMod m_SkillMod6;
	private SkillMod m_SkillMod7;
		
		[Constructable] 
		public CloakOfTheGodlySmith() : base( 0x309 ) 
		{ 
			Name = "The Cloak of the Godly Smith";
            Hue = 0x489;

			DefineMods();
		} 

		private void DefineMods()
		{
            m_SkillMod0 = new DefaultSkillMod(SkillName.Blacksmith, true, 15);
            m_SkillMod2 = new DefaultSkillMod(SkillName.Mining, true, 15);
          
		}

		private void SetMods( Mobile wearer )
		{
	wearer.AddSkillMod(m_SkillMod0);
	wearer.AddSkillMod(m_SkillMod1);
	wearer.AddSkillMod(m_SkillMod2);
	wearer.AddSkillMod(m_SkillMod3);
	wearer.AddSkillMod(m_SkillMod4);
	wearer.AddSkillMod(m_SkillMod5);
	wearer.AddSkillMod(m_SkillMod6);
	wearer.AddSkillMod(m_SkillMod7);
		}

		public override bool OnEquip( Mobile from ) 
		{ 
			SetMods( from );
			return true;  
		} 

		public override void OnRemoved( object parent ) 
		{ 
			if ( parent is Mobile ) 
			{ 
				Mobile m = (Mobile)parent;
				m.RemoveStatMod( "Cloak Of The Godly Smith" );

                if (m.Hits > m.HitsMax)
                    m.Hits = m.HitsMax;

                if (m_SkillMod0 != null)
                    m_SkillMod0.Remove();

	if (m_SkillMod1 != null)
	    m_SkillMod1.Remove();

	if (m_SkillMod2 != null)
	    m_SkillMod2.Remove();

	if (m_SkillMod3 != null)
	    m_SkillMod3.Remove();

	if (m_SkillMod4 != null)
	    m_SkillMod4.Remove();

	if (m_SkillMod5 != null)
	    m_SkillMod5.Remove();

                if (m_SkillMod6 != null)
                    m_SkillMod6.Remove();

                if (m_SkillMod7 != null)
                    m_SkillMod7.Remove(); 

			} 
		} 

		public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, Name ); 
		}

        public CloakOfTheGodlySmith(Serial serial): base(serial) 
		{ 
			DefineMods();
			
			if ( Parent != null && this.Parent is Mobile ) 
				SetMods( (Mobile)Parent );
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		} 
	} 
} 
