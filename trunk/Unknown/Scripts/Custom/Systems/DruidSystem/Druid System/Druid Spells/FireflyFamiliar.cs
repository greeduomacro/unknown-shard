using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Network;
 
namespace Server.Mobiles
{
	[CorpseName( "a firefly corpse" )]
	public class FireflyFamiliar : BaseFamiliar
	{
	public override double DispelDifficulty{ get{ return 75.0; } }
 
		public FireflyFamiliar()
		{
			Name = "a firefly";
			Body = 495;
			Hue = 0x0;
			BaseSoundID = 466;
 
			SetStr( 5 );
			SetDex( 6 );
			SetInt( 10 );
 
			SetHits( 10 );
			SetStam( 10 );
			SetMana( 0 );
 
			SetDamage( 1, 2 );
 
			SetDamageType( ResistanceType.Fire, 100 );
 
			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Fire, 75, 99 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 0, 3 );
 
			SetSkill( SkillName.Wrestling, 10, 11 );
			SetSkill( SkillName.Tactics, 10 );
 
			AddItem( new LightSource() );
			AddItem( new LightSource() );
 
			ControlSlots = 1;
		}
 
		private DateTime m_NextRestore;
 
		public override void OnThink()
		{
			base.OnThink();
 
			if ( DateTime.Now < m_NextRestore )
				return;
 
			m_NextRestore = DateTime.Now + TimeSpan.FromSeconds( 2.0 );
 
			Mobile caster = ControlMaster;
 
			if ( caster == null )
				caster = SummonMaster;
 
			if ( caster != null )
				++caster.Stam;
		}
 
		public FireflyFamiliar( Serial serial ) : base( serial )
		{
		}
 
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
 
			writer.Write( (int) 0 );
		}
 
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
 
			int version = reader.ReadInt();
		}
	}
}
