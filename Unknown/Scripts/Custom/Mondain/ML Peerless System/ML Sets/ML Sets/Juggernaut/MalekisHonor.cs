using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class MalekisHonor : BaseShield
	{
		public override int LabelNumber{ get{ return 1074312; } }
		public override int BasePhysicalResistance{ get{ return 3; } }
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override int AosStrReq{ get{ return 45; } }

		public override int ArmorBase{ get{ return 16; } }

		[Constructable]
		public MalekisHonor() : base( 0x1B74 )
		{
			Weight = 7.0;
		}
		
		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			
			list.Add( 1073491, "2" );
			
			if ( this.Parent is Mobile )
			{
				if ( this.Hue == 0x388 )
				{
					list.Add( 1073492 );
					list.Add( 1072514, "10" );
					list.Add( 1073493, "10" );
					list.Add( 1074323, "35" );
				}
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( this.Hue == 0x0 )
			{
				list.Add( 1072378 );
				list.Add( 1060450, "3" );
				list.Add( 1073493, "10" );
				list.Add( 1073493, "10" );
				list.Add( 1074323, "35" );
			}
		}

		public override bool OnEquip( Mobile from )
		{
			
			Item item = from.FindItemOnLayer( Layer.OneHanded );
			
			if ( item != null && item.GetType() == typeof( EvocaricusSword ) )
			{
				Effects.PlaySound( from.Location, from.Map, 503 );
				from.FixedParticles( 0x376A, 9, 32, 5030, EffectLayer.Waist );

				Hue = 0x388;
				Attributes.BonusStr = 10;
				Attributes.DefendChance = 10;
				ArmorAttributes.SelfRepair = 3;
				EvocaricusSword sword = from.FindItemOnLayer( Layer.OneHanded ) as EvocaricusSword;
				sword.Hue = 0x388;
				sword.Attributes.WeaponSpeed = 35;
				sword.WeaponAttributes.SelfRepair = 3;
						
				from.SendLocalizedMessage( 1072391 );
			}
			this.InvalidateProperties();
			return base.OnEquip( from );							
		}
		
		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile m = ( Mobile )parent;
				Hue = 0x0;
				Attributes.BonusStr = 0;
				Attributes.DefendChance = 0;
				ArmorAttributes.SelfRepair = 0;
				if ( m.FindItemOnLayer( Layer.OneHanded ) is EvocaricusSword )
				{
					EvocaricusSword sword = m.FindItemOnLayer( Layer.OneHanded ) as EvocaricusSword;
					sword.Hue = 0x0;
					sword.Attributes.WeaponSpeed = 0;
					sword.WeaponAttributes.SelfRepair = 0;
				}
				this.InvalidateProperties();
			}
			base.OnRemoved( parent );
		}

		public MalekisHonor( Serial serial ) : base(serial)
		{
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 5.0 )
				Weight = 7.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
