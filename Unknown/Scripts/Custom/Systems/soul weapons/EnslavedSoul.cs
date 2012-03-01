using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class EnslavedEntrappedSoul : BaseCreature
	{
		private Mobile m_Target;
		private DateTime m_ExpireTime;

		public override void DisplayPaperdollTo( Mobile to )
		{
		}

		public override Mobile ConstantFocus{ get{ return m_Target; } }
		public override bool NoHouseRestrictions{ get{ return true; } }

		public override double DispelDifficulty{ get{ return 100.0; } }
		public override double DispelFocus{ get{ return 100.0; } }

		public EnslavedEntrappedSoul( Mobile caster, Mobile target, TimeSpan duration ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.18, 0.36 )
		{
			Name = "Enslaved Soul";
			Body = 400;
			m_Target = target;
			m_ExpireTime = DateTime.Now + duration;

			SetStr( 125 );
			SetDex( 125 );
			SetInt( 125 );

			SetHits( 300, 400 );

			SetDamage( 7, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.MagicResist, 150.0 );
			SetSkill( SkillName.Tactics, 150.0 );
			SetSkill( SkillName.Fencing, 150.0 );
			SetSkill( SkillName.DetectHidden, 150.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			SetResistance( ResistanceType.Physical, 50, 90 );
			SetResistance( ResistanceType.Cold, 50, 90 );
			SetResistance( ResistanceType.Fire, 50, 90 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40, 60 );

			Fame = 0;
			Karma = 0;

			VirtualArmor = 60;

			Item shroud = new DeathShroud();
			shroud.Movable = false;
			AddItem( shroud );

			Dagger weapon = new Dagger();
			weapon.Movable = false;
			AddItem( weapon );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public override bool BleedImmune{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override void OnThink()
		{
			if ( !m_Target.Alive || DateTime.Now > m_ExpireTime )
			{
				Kill();
				return;
			}
			else if ( Map != m_Target.Map || !InRange( m_Target, 15 ) )
			{
				Map fromMap = Map;
				Point3D from = Location;

				Map toMap = m_Target.Map;
				Point3D to = m_Target.Location;

				if ( toMap != null && toMap != Map.Internal )
				{
					for ( int i = 0; i < 5; ++i )
					{
						Point3D loc = new Point3D( to.X - 4 + Utility.Random( 9 ), to.Y - 4 + Utility.Random( 9 ), to.Z );

						if ( toMap.CanSpawnMobile( loc ) )
						{
							to = loc;
							break;
						}
						else
						{
							loc.Z = toMap.GetAverageZ( loc.X, loc.Y );

							if ( toMap.CanSpawnMobile( loc ) )
							{
								to = loc;
								break;
							}
						}
					}
				}

				Map = toMap;
				Location = to;

				ProcessDelta();

				Effects.SendLocationParticles( EffectItem.Create( from, fromMap, EffectItem.DefaultDuration ), 0x3728, 1, 13, 37, 7, 5023, 0 );
				FixedParticles( 0x3728, 1, 13, 5023, 37, 7, EffectLayer.Waist );

				PlaySound( 0x37D );
			}

			if ( m_Target.Hidden && InRange( m_Target, 3 ) && DateTime.Now >= this.NextSkillTime && UseSkill( SkillName.DetectHidden ) )
			{
				Target targ = this.Target;
				if ( targ != null ) targ.Invoke( this, this );
			}

			Combatant = m_Target;
			FocusMob = m_Target;

			if ( AIObject != null ) AIObject.Action = ActionType.Combat;

			base.OnThink();
		}

		public override bool OnBeforeDeath()
		{
			Effects.PlaySound( Location, Map, 0x10B );
			Effects.SendLocationParticles( EffectItem.Create( Location, Map, TimeSpan.FromSeconds( 10.0 ) ), 0x37CC, 1, 50, 2101, 7, 9909, 0 );

			Delete();
			return false;
		}

		public EnslavedEntrappedSoul( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
}