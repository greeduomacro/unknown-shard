//Please Leave Credit XSlayerX aka XLacaestX
using System;
using Server.Misc;

namespace Server.Items
{
    [FlipableAttribute(0x2B04, 0x2B05)] 
	public class CloakOfTheGodlyTailor: Cloak 
	{

        private SkillMod m_SkillMod6;
	
		
		[Constructable]
        public CloakOfTheGodlyTailor(): base(0x309)
		{ 
			Name = "The Cloak of the Godly Tailor[+ 20 tailor]";
			
           

			DefineMods();
		} 

		private void DefineMods()
		{

            m_SkillMod6 = new DefaultSkillMod(SkillName.Tailoring, true, 20);
            
		}

		private void SetMods( Mobile wearer )
		{
	
	wearer.AddSkillMod(m_SkillMod6);
	;
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
				m.RemoveStatMod( "CloakOfTheGodlyTailor" );

                if (m.Hits > m.HitsMax)
                    m.Hits = m.HitsMax;


                  if (m_SkillMod6 != null)
                    m_SkillMod6.Remove();


			} 
		} 

		public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, Name ); 
		}

        public CloakOfTheGodlyTailor(Serial serial): base(serial) 
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
