// A Tunneling Ferret
// scripted by evilfreak
// Ver 1.0





using Server;
using System;
using System.IO;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "a ferret corpse" )]
	public class FerretsFarm : BaseCreature
	{
		
		[Constructable]
		public FerretsFarm() : base( AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			Name = "a ferret";
			Body = 279;
			
			SetStr( 400 );
			SetDex( 1000 );
			SetInt( 1000 );

			SetHits( 3500 );
			SetStam( 800 );
			SetMana( 0 );

			SetDamage( 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.MagicResist, 200.0 );
			SetSkill( SkillName.Tactics, 75.0 );
			SetSkill( SkillName.Wrestling, 95.0 );

			Fame = 1000;
			Karma = -2500;

			VirtualArmor = 70;
			

			

			DelayBeginTunnel();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich, 2 );
		}
//begin tunnel
		public class FerretTunnel : Item
		{

			
			public FerretTunnel() : base( 0x913 )
			{
				Movable = false;
				Hue = 1;
				Name = "a ferret tunnel";

				Timer.DelayCall( TimeSpan.FromSeconds( 40.0 ), new TimerCallback( Delete ) );
			

			}
			
			

			public override void OnDoubleClick( Mobile m )	
			{	
				
				m.SendMessage( "You jump into the ferret tunnel!!" );
				m.X= 5184;
				m.Y= 1171;
				m.Z= 0;
			}

			public FerretTunnel( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize(writer);

				writer.Write( (int) 0 );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				Delete();
			}
		}

		public virtual void DelayBeginTunnel()
		{
//here is the line to edit the time before it tunnels off  TimeSpan.FromMinutes( minutes here)
			Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerCallback( BeginTunnel ) );
		}

		public virtual void BeginTunnel()
		{
			if ( Deleted )
				return;

			new FerretTunnel().MoveToWorld( Location, Map );

			Frozen = true;
			Say( "* The ferret kicks loose dirt everywhere!! *" );
			PlaySound( 0x247 );
			PlaySound( 0x247 );
			

			Timer.DelayCall( TimeSpan.FromSeconds( 3.0 ), new TimerCallback( Delete ) );
		}
//end of tunnel

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 1; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }

		public FerretsFarm( Serial serial ) : base( serial )
		{
		}

		public override int GetAttackSound()
		{
			return 0xC9;
		}

		public override int GetHurtSound()
		{
			return 0xCA;
		}

		public override int GetDeathSound()
		{
			return 0xCB;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			DelayBeginTunnel();//edit this out for tamable
		}
	}
}