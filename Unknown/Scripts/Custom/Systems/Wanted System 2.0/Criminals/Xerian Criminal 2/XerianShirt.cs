using System;
using Server.Misc;

namespace Server.Items
{
	[FlipableAttribute( 0x1541, 0x1542 )] 
	public class Xerianshirt : BaseShirt 
	{
        private SkillMod m_SkillMod0;
        private SkillMod m_SkillMod1;
     		
		[Constructable]
		public Xerianshirt() : this( 0 )
		{
		}

		[Constructable]
		public Xerianshirt( int hue ) : base( 0x1EFD, hue )
		{
			Name = "Xerian's Shirt";
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
				m.RemoveStatMod( "Xerianshirt" );

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

        public Xerianshirt(Serial serial): base(serial) 
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
