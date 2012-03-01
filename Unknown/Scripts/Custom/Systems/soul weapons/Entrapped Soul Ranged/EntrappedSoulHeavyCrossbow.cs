using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class EntrappedSoulHeavyCrossbow : HeavyCrossbow
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		private int m_Charges;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set
			{
				if ( value > this.MaxCharges ) m_Charges = this.MaxCharges;
				else if ( value <= 0 ) m_Charges = 0;
				else m_Charges = value;
				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int MaxCharges{ get{ return 2; } }

		[Constructable]
		public EntrappedSoulHeavyCrossbow()
		{
			Name = "Entrapped Soul Heavy Crossbow";
			Attributes.SpellChanneling = 1;
			Hue = 2972;
			Charges = Utility.RandomMinMax(0,2);
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			if ( this.Charges >= 1 && Utility.RandomDouble() <= .25 )
			{
				Map map = this.Map;
				if ( map == null || map == Map.Internal ) return;
				TimeSpan duration = TimeSpan.FromMinutes( 5 );
				EnslavedEntrappedSoul minion = new EnslavedEntrappedSoul( attacker, defender, duration );
				minion.MoveToWorld( defender.Location, defender.Map );
				attacker.Say( "Those I kill become my slaves!" );
				minion.Combatant = defender;
				this.Charges -= 1;
				attacker.Karma -= 25;
			}
			base.OnHit( attacker, defender, damageBonus );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( 1060741, m_Charges.ToString() );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( !this.IsChildOf( from.Backpack ) ) { from.SendMessage( "This must be in your backpack to use" ); }
			else { from.Target = new EntrappedSoulTarget( this ); }
		}

		private class EntrappedSoulTarget : Target
		{
			private EntrappedSoulHeavyCrossbow i_Std;
			private int m_Charges;
			public EntrappedSoulTarget( EntrappedSoulHeavyCrossbow std ) : base( -1, false, TargetFlags.None ) { i_Std = std; }
			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( !(targeted is Item) ) { from.SendMessage("You can only target heads"); return; }
				if ( i_Std.Deleted ) return;
				Item item = (Item)targeted;
				if ( item is Head )
				{
					if( i_Std.Charges >= 2 ) { from.SendMessage( "There is only room for two Entrapped Souls" ); }
					else
					{
						i_Std.Charges = i_Std.Charges + 1;
						item.Delete();
						from.Karma -= 25;
						from.SendMessage( "The weapon draws the Soul from this head and stores it" );
					}
				}
				else from.SendMessage( "The weapon draws Souls only from heads of the fallen" );
			}
		}

		public EntrappedSoulHeavyCrossbow( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); writer.Write( (int) m_Charges ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); m_Charges = reader.ReadInt(); }
	}
}