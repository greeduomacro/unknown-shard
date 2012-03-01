using System;
using Server.Misc;

namespace Server.Items
{
 
	public class OdinPants : BasePants
	{
        private SkillMod m_SkillMod0;
        private SkillMod m_SkillMod1;
     		
		[Constructable]
		public OdinPants() : this( 0 )
		{
		}

		[Constructable]
		public OdinPants( int hue ) : base( 0x1539, hue )
		{
			Name = "Odin's Pants";
			Hue = 1;

			DefineMods();
		} 

		private void DefineMods()
		{
            m_SkillMod0 = new DefaultSkillMod(SkillName.ArmsLore, true, 5);
            m_SkillMod1 = new DefaultSkillMod(SkillName.Anatomy, true, 5);
           
        }

		private void SetMods( Mobile wearer )
		{
            wearer.AddSkillMod(m_SkillMod0);
            wearer.AddSkillMod(m_SkillMod1);

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
				m.RemoveStatMod( "OdinPants" );

                if (m_SkillMod0 != null)
                    m_SkillMod0.Remove();

                if (m_SkillMod1 != null)
                    m_SkillMod1.Remove();


			} 
		} 

		public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, Name ); 
		}

        public OdinPants(Serial serial): base(serial) 
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