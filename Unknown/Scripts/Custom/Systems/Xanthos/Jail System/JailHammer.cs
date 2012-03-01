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
using Server.Mobiles;
using Server.Targeting;
using Server.Items;

namespace Xanthos.JailSystem
{
	public class JailHammer : BaseWeapon, IUsesRemaining
	{
		private int m_Rock;
		private int m_Difficulty;
		private AccessLevel m_PlayerAccessLevel;

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_Rock; }
			set { m_Rock = value; InvalidateProperties(); }
		}

		public bool ShowUsesRemaining{ get{ return true; } set{} }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Difficulty
		{
			get{ return m_Difficulty; }
			set{ m_Difficulty = value; InvalidateProperties(); }
		}

		public AccessLevel PlayerAccessLevel
		{
			get{ return m_PlayerAccessLevel; }
			set{ m_PlayerAccessLevel = value; }
		}

		[Constructable]
		public JailHammer() : base( 0x143D )
		{
			Name = JailConfig.JailRockName + " Mining Hammer";
			Movable = false;
			Difficulty = JailConfig.HammerDifficulty;
			UsesRemaining = JailConfig.UsesRemaining;
			Hue = 1175;
			Layer = Layer.OneHanded;
			Weight = 3.0;
			Attributes.SpellChanneling = 1;
			Attributes.Luck = -10000;
			PlayerAccessLevel = AccessLevel.Player;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Target = new RockTarget( this );
			from.SendMessage( "Where do you wish to mine?" );
		}

		public JailHammer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
			writer.Write( (int)PlayerAccessLevel );
			writer.Write( (int)m_Rock );
			writer.Write( (int)m_Difficulty );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
					PlayerAccessLevel = (AccessLevel)reader.ReadInt();
					goto case 0;
				case 0:
					m_Rock = reader.ReadInt();
					m_Difficulty = reader.ReadInt();
					break;
			}
		}

		private class RockTarget : Target
		{
			private Item m_Item;

			public RockTarget( Item item ) : base( 3, true, TargetFlags.None )
			{
				m_Item = item;
			}

			protected override void OnTarget( Mobile from, object to )
			{
				LandTarget toLand = to as LandTarget;
				StaticTarget toStatic = to as StaticTarget;

				if ((null != toLand && toLand.Name == JailConfig.WhatToMine) ||
					(null != toStatic && toStatic.Name == JailConfig.WhatToMine ))
				{
					from.Animate( 9, 1, 1, true, false, 0 );
					from.PlaySound( 0x145 );
					JailHammer hammer = from.FindItemOnLayer( Layer.OneHanded ) as JailHammer;

					if ( null != hammer )
					{
						if ( Utility.RandomMinMax( 0, 101 ) >= hammer.Difficulty )
						{
							from.SendMessage( "The {0} crumbles under your hammer.", JailConfig.WhatToMine );
							from.AddToBackpack( new JailRock() );
						}
						else
							from.SendMessage( "You did not swing hard enough." );
					}
				}
				else if ( to is PlayerMobile )
				{
					from.Animate( 9, 1, 1, true, false, 0 );
					from.PlaySound( 0x145 );

					PlayerMobile toPlayer = to as PlayerMobile;

					if ( toPlayer == from )
						from.Say( "Ouch, I hit myself with my hammer!" );
					else
					{
						from.SendMessage( "You hit " + toPlayer.Name + " with your hammer!" );
						toPlayer.SendMessage( from.Name + " has hit you with a hammer!" );
						toPlayer.Say( "Ouch" );

						JailHammer hammer = from.FindItemOnLayer( Layer.OneHanded ) as JailHammer;
						if ( null != hammer )
						{
							hammer.UsesRemaining++;
						}
					}
				}
				else if ( to is Mobile )
				{
					Mobile toMobile = to as JailSlaveDriver;

					if ( null != toMobile )
					{
						from.Animate( 9, 1, 1, true, false, 0 );
						from.PlaySound( 0x145 );
						toMobile.Say( "How dare you!, You\'ll pay with your life!" );
						from.Criminal = true;
						toMobile.Combatant = from;
					}
					else
						from.SendMessage( "You dont think they would like that very much." );
				}
				else
					from.SendMessage( "You should try breaking up some {0} with your hammer!", JailConfig.WhatToMine );
			}
		}
	}
}