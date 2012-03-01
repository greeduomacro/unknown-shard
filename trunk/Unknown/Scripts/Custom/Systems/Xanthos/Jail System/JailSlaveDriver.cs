#region AuthorHeader
//
//	Jail version 2.0, by Xanthos
//
//  Based on original code and concept by Sirens Song
//  (ie, Matron de Winter) 2004 and Grim Reaper.  Thanks to
//	Thundar for his ideas and testing.
//
#endregion AuthorHeader
using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.JailSystem
{
	[CorpseName( "corpse of some guy" )]
	public class JailSlaveDriver : BaseCreature
	{
		private DateTime m_NextSpeakTime; // To prevent spam

		private static string[] m_Phrases = new string[] // Things to say while greeting
		{
			"Get to work mining that " + JailConfig.JailRockName + " !",
			"You will never leave here unless you work!",
			"Bring me " + JailConfig.JailRockName + " or you'll pay for it!",
			"You want to go home don't you?",
			"Dont even think of using that hammer as a weapon!",
			"I'll teach you the meaning of the word respsect!",
			"What we have here... is a failure to communicate!",
			"Quiet or Papa spank!",
		};

		public override bool AlwaysAttackable{ get{ return false; }}

		[Constructable]
		public JailSlaveDriver() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.15, 0.9 )
		{
			Body = 0x190;
			AddItem( new PlateChest() );
			AddItem( new PlateArms() );
			AddItem( new PlateGloves() );
			AddItem( new PlateLegs() );
			Hue = Utility.RandomSkinHue();
			Name = NameList.RandomName( "male" );
			Title = "the Jail Guard";

			SetStr( 70, 100 );
			SetDex( 55, 90 );
			SetInt( 25, 35 );
			SetDamage( 11, 25 );

			SetHits ( 90, 125 );

			Halberd weapon = new Halberd();
			weapon.Movable = false;
			AddItem( weapon );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 5, 20 );
			SetResistance( ResistanceType.Energy, 5, 20 );

			SetSkill( SkillName.Anatomy, 90.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Fencing, 80.0 );
			SetSkill( SkillName.Tactics, 90.0 );

			m_NextSpeakTime = DateTime.Now + ( TimeSpan.FromSeconds( 6 ) );

			Fame = 1000;
			Karma = -1000;
		}

		public JailSlaveDriver( Serial serial ) : base( serial )
		{
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is JailRock)
			{
				PlayerMobile player = from as PlayerMobile;

				if ( null != player )
				{
					JailHammer hammer = player.FindItemOnLayer( Layer.OneHanded ) as JailHammer;

					if ( null == hammer )
					{
						Say( "How nice of you to volunteer {0}; get busy mining {1}!", player.Name, JailConfig.JailRockName );
						Jail.JailThem( player, Jail.JailOption.None );
					}
					else
					{
						if ( ( hammer.UsesRemaining -= dropped.Amount ) <= 0 )
							Jail.FreeThem( player );
						else
							this.Say( hammer.UsesRemaining + " to go, Keep working scoundrel!" );
					}
				}
				return true;
			}
			else
				Say( "I dont want that junk! Get me some {0}!", JailConfig.JailRockName );

			return false;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( 0 < DateTime.Compare( DateTime.Now, m_NextSpeakTime ) && m.InRange( this, 3 ) )
			{
				PlayerMobile player = m as PlayerMobile;

				if ( null != player )
				{
					if ( player.AccessLevel < JailConfig.JailImmuneLevel )
					{
						m_NextSpeakTime = DateTime.Now + ( TimeSpan.FromSeconds( 10 ) );
						Move( GetDirectionTo( m.Location ) );
						Say( m_Phrases[Utility.Random( m_Phrases.Length )] );

						if ( null == ( player.FindItemOnLayer( Layer.OneHanded ) as JailHammer ) && InLOS( player ) )
						{
							Say( "Don't just stand around {0}, make yourself useful!", player.Name );
							Jail.JailThem( player, Jail.JailOption.None );
						}
					}
				}
			}
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
