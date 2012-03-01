using System;
using System.Collections;
using Server;
using Server.Misc;
using Server.Mobiles;
using Server.Gumps;
using Server.ContextMenus;
using Server.Network;
using Server.Targeting;
using Server.Regions;
using Server.Accounting;

namespace Server.Mobiles
{
[CorpseName( "a Gryphon corpse" )]
	public class Gryphon : BaseMount
	{
		[Constructable]
		public Gryphon() : this( "a Gryphon" )
		{
		}
		[Constructable]
		public Gryphon( string name ) : base( name, 276, 0x3e90, AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x4FB;
				
			SetStr( 1200, 1410 );
			SetDex( 170, 270 );
			SetInt( 300, 325 );

			SetHits( 900, 1100 );

			SetDamage( 125, 181 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 100, 120 );
			SetResistance( ResistanceType.Fire, 70, 90 );
			SetResistance( ResistanceType.Cold, 150, 250 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 75.0, 80.0 );
			SetSkill( SkillName.MagicResist, 85.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.Wrestling, 100.0, 120.0 );
            SetSkill( SkillName.Magery, 100.0, 120.0 );
            SetSkill( SkillName.Meditation, 100.0, 120.0 );

			Fame = 5000;
			Karma = -5000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 90.9;
			
		PackGem(); 
         	PackGem(); 
		PackGem(); 
         	PackGem();  
         	PackGold( 1500, 1900 ); 
         	PackMagicItems( 1, 5 ); 
		}
		public override int GetAngerSound()
		{
			return 0x4FF;
		}

		public override int GetIdleSound()
		{
			return 0x4FE;
		}

		public override int GetAttackSound()
		{
			return 0x4FD;
		}

		public override int GetHurtSound()
		{
			return 0x500;
		}

		public override int GetDeathSound()
		{
			return 0x4FC;

		 
					}
		public override int Meat{ get{ return 16; } }
		public override int Hides{ get{ return 60; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		
		public Gryphon( Serial serial ) : base( serial )
		{
		}

		 public override void OnDoubleClick( Mobile from )
	   	{
		   	if ( IsDeadPet )
			return; 

		   	if ( from.IsBodyMod && !from.Body.IsHuman )
		   	{
			   	if ( Core.AOS ) // You cannot ride a mount in your current form.
				PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 1062061, from.NetState );
			   else
				from.SendLocalizedMessage( 1061628 ); // You can't do that while polymorphed.
				return;
		   	}
			if ( !from.CanBeginAction( typeof( BaseMount ) ) )
		   	{
			   	from.SendLocalizedMessage( 1040024 ); // You are still too dazed from being knocked off your mount to ride!
			   	return;
		   	}
			if ( from.Mounted )
		   	{
			   	from.SendLocalizedMessage( 1005583 ); // Please dismount first.
			   	return;
		   	}
			if ( from.Female ? !AllowFemaleRider : !AllowMaleRider )
		   	{
			   	OnDisallowedRider( from );
			   	return;
		   	}
			if ( !Multis.DesignContext.Check( from ) )
			return;
		   
			if ( from.InRange( this, 1 ) )
		   	{
			   	if( ((Mobile)from).Skills[SkillName.AnimalTaming].Value >= 100.0 )
			   	{
				   	from.SendGump(new Gryphongump( from , 0) );
			   	}
				if ( ( Controlled && ControlMaster == from ) || ( Summoned && SummonMaster == from) || from.AccessLevel >= AccessLevel.GameMaster )
			   	{
				  	Rider = from;
			   	}
			   	else if ( !Controlled && !Summoned )
			   	{
				   	from.SendLocalizedMessage( 501263 ); // That mount does not look broken! You would have to tame it to ride it.
			   	}
			   	else
			   	{
				   	from.SendLocalizedMessage( 501264 ); // This isn't your mount; it refuses to let you ride.
			   	}
		   	}
		   	else
		   	{
			   	from.SendLocalizedMessage( 500206 ); // That is too far away to ride.
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
