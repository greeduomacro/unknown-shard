using System;
using Server;
using Server.Items;

namespace Server.Items
{
   	[FlipableAttribute( 0x170d, 0x170e )]
	public class RogueSandals : BaseShoes
	{ 
		private SkillMod m_SkillMod0; 
		private SkillMod m_SkillMod1; 
		private SkillMod m_SkillMod2; 
                		private SkillMod m_SkillMod3;
		private StatMod m_StatMod0; 
		
		[Constructable] 
		public RogueSandals() : base( 0x170d, 0x170e  )
		{ 
			Name = "Sandals Of The Rogue";
			Hue = 1153; 
			DefineMods();
		} 

		private void DefineMods()
		{
			m_SkillMod0 = new DefaultSkillMod( SkillName.Stealth, true, 20 ); 
			m_SkillMod1 = new DefaultSkillMod( SkillName.Hiding, true, 20 ); 
			m_SkillMod2 = new DefaultSkillMod( SkillName.Stealing, true, 20 );
                        		m_SkillMod3 = new DefaultSkillMod( SkillName.Fencing, true, 20 );  
			m_StatMod0 = new StatMod( StatType.Dex, "RogueSandals", 15, TimeSpan.Zero ); 
		}

		private void SetMods( Mobile wearer )
		{			
			wearer.AddSkillMod( m_SkillMod0 ); 
			wearer.AddSkillMod( m_SkillMod1 ); 
			wearer.AddSkillMod( m_SkillMod2 ); 
                        wearer.AddSkillMod( m_SkillMod3 );
			wearer.AddStatMod( m_StatMod0 ); 
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
				m.RemoveStatMod( "RogueSandals" ); 

				if ( m.Hits > m.HitsMax )
					m.Hits = m.HitsMax; 

				if ( m_SkillMod0 != null ) 
					m_SkillMod0.Remove(); 

				if ( m_SkillMod1 != null ) 
					m_SkillMod1.Remove(); 

				if ( m_SkillMod2 != null ) 
					m_SkillMod2.Remove();
 
                                if ( m_SkillMod3 != null ) 
					m_SkillMod3.Remove();
			} 
		} 

		public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, Name ); 
		} 

		public RogueSandals( Serial serial ) : base( serial ) 
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
