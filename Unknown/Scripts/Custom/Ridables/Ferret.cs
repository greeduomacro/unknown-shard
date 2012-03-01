// Ver 1.0 scripted by evilfreak
// This could not have been done with out the original. thanks evilfreak.
// 
//  Mods can make A Tunneling Ferret
//
// look for edits throughout script for making these untamable or adjusting time on tunneling for untameable
// These cute little boogers steal from those they fight. They have backpacks for you to access the goods easily.
// They also will pick things up as they follow you. they sure are chatty. 
// Ver 2.0 Scripted by chocomog




using Server.ContextMenus;
using System.Collections;
using System.Collections.Generic;
using System;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
		[CorpseName( "a ferret corpse" )]
	public class DomesticFerret : BaseCreature
	{
	   		private static bool m_Talked;

		string[] kfcsay = new string[]
		{
		
		"dook dook",
		"Shhhht!!",
		"*Scratches at a stone on the ground*",
		"*Quickly darts back wiggling its fuzzie little butt*",
		"*looks around for a fish steak*",
		"*tries to climb up your leg*",
		"*Sinks their teeth into your toe*",
		"Dook!!",
		"*Scratches*",
		"*Scratches ear*",
		"Dook dook, dook dook dook.",
		"*scratches back of their neck flipping and rolling over*",
		"Dook.. Dook dook PSSSshhht Shhtt!!",
		"*Grabs something with their front paws scraping it under their chest*",
		"*Looks for some thing sparkly*",
		"*Scratches*",
		"*Stands on their hind feet stretching their nose in the air to sniff for cookies*",
		"*looks for a sleeping spot*",
		"*Yawns*",
		"*Sneezes*",
		"*Does the infamous fuzzie war dance*",
		"*steals your sandals*",
		"*Looks for a plant to dig up*"

		};		
	

		[Constructable]
		public DomesticFerret() : base( AIType.AI_Thief, FightMode.None, 10, 1, 0.1, 0.2 )
		{
			Name = "a Domesticated Ferret";
			Body = 279;
			
			SetStr( 25 );
			SetDex( 50 );
			SetInt( 75 );

			SetHits( 50 );
			SetStam( 50 );
			SetMana( 0 );

			SetDamage( 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Tactics, 75.0 );
			SetSkill( SkillName.Wrestling, 95.0 );
			SetSkill( SkillName.DetectHidden, 65.0, 88.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
			SetSkill( SkillName.Stealing, 95.0 );
			SetSkill( SkillName.ArmsLore, 80.0, 90.0 );

			Fame = 500;
			Karma = -500;

			VirtualArmor = 25;
//#################################
			Tamable = true;	    //#
			ControlSlots = 2;   //#<------take out edits if you want them tamable then remove tunnel
			MinTameSkill = 10.6;//#
//#################################

			Container pack = Backpack;

			if ( pack != null )
				pack.Delete();

			pack = new StrongBackpack();
			pack.Movable = false;

			AddItem( pack );
		}
		private DateTime m_NextPickup;

		public override void OnThink()
		{
			base.OnThink();

			if ( DateTime.Now < m_NextPickup )
				return;

			m_NextPickup = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 3, 6 ) );

			Container pack = this.Backpack;

			if ( pack == null )
				return;

			ArrayList list = new ArrayList();

			foreach ( Item item in this.GetItemsInRange( 2 ) )
			{
				if ( item.Movable && item.Stackable )
					list.Add( item );
			}

			int pickedUp = 0;

			for ( int i = 0; i < list.Count; ++i )
			{
				Item item = (Item)list[i];

				if ( !pack.CheckHold( this, item, false, true ) )
					return;

				bool rejected;
				LRReason reject;

				NextActionTime = DateTime.Now;

				Lift( item, item.Amount, out rejected, out reject );

				if ( rejected )
					continue;

				Drop( this, Point3D.Zero );

				if ( ++pickedUp == 3 )
					break;
			}
		}
			

//	DelayBeginTunnel();//<---##	UNomment if you want Tunneling  on
						//######	NOTE: If Tunneling  on and tameable they will tunnel away from owner.
						//###### Todo make Tunneling  only happen upon release and owner abandon.
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish ; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Gems );
			AddLoot( LootPack.Gems );
			AddLoot( LootPack.Gems );
			AddLoot( LootPack.Gems );
		}
//#########################################################         Begin tunnel
		public class FerretTunnel : Item
		{
			public FerretTunnel() : base( 0x913 )
			{
				Movable = false;
				Hue = 1;
				Name = "a hole made by a domestic ferret";

				Timer.DelayCall( TimeSpan.FromSeconds( 40.0 ), new TimerCallback( Delete ) );
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
//######### Here is the line to edit the time before it tunnels away  TimeSpan.FromMinutes( minutes here)
//######### Comment if tunneling is desired. See NOTE above!!

//			Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerCallback( BeginTunnel ) );
		}

		public virtual void BeginTunnel()
		{
			if ( Deleted )
				return;

			new FerretTunnel().MoveToWorld( Location, Map );

			Frozen = true;
			Say( "* The domestic ferret kicks dirt everywhere!! *" );
			PlaySound( 0x247 );
			PlaySound( 0x247 );
			

			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( Delete ) );
		}
//########################  end of tunnel

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 1; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } } // TODO: Immune to poison?
		
		public DomesticFerret( Serial serial ) : base( serial )
		{
		}

				#region Pack Animal Methods
		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			PackAnimal.CombineBackpacks( this );

			return true;
		}

		public override DeathMoveResult GetInventoryMoveResultFor( Item item )
		{
			return DeathMoveResult.MoveToCorpse;
		}

		public override bool IsSnoop( Mobile from )
		{
			if ( PackAnimal.CheckAccess( this, from ) )
				return false;

			return base.IsSnoop( from );
		}

		public override bool OnDragDrop( Mobile from, Item item )
		{
			if ( CheckFeed( from, item ) )
				return true;

			if ( PackAnimal.CheckAccess( this, from ) )
			{
				AddToBackpack( item );
				return true;
			}

			return base.OnDragDrop( from, item );
		}

		public override bool CheckNonlocalDrop( Mobile from, Item item, Item target )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override bool CheckNonlocalLift( Mobile from, Item item )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			PackAnimal.GetContextMenuEntries( this, from, list );
		}
		#endregion
		
		
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
		
		       		public override void OnMovement( Mobile m, Point3D oldLocation ) 
               {                                                    
         		if( m_Talked == false ) 
        		 { 
          		 	 if ( m.InRange( this, 1 ) ) 
          			  {                
          				m_Talked = true; 
              				SayRandom( kfcsay, this ); 
				this.Move( GetDirectionTo( m.Location ) ); 
				SpamTimer t = new SpamTimer(); 
				t.Start(); 
            			} 
		} 
	} 

	private class SpamTimer : Timer 
	{ 
//################################ Comment here for time between speach " TimeSpan.FromSeconds( 90 ) "
//################################ 90 being the seconds between talking, less means more speach.
		public SpamTimer() : base( TimeSpan.FromSeconds( 90 ) ) 
		{ 
			Priority = TimerPriority.OneSecond; 
		} 

		protected override void OnTick() 
		{ 
		m_Talked = false; 
		} 
	} 

	private static void SayRandom( string[] say, Mobile m ) 
	{ 
		m.Say( say[Utility.Random( say.Length )] ); 
	}

        private static int GetRandomHue()
        {
            switch ( Utility.Random( 6 ) )
            {
                default:
                case 0: return 0;
                case 1: return Utility.RandomBlueHue();
                case 2: return Utility.RandomGreenHue();
                case 3: return Utility.RandomRedHue();
                case 4: return Utility.RandomYellowHue();
                case 5: return Utility.RandomNeutralHue();
            }
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

			//DelayBeginTunnel();         //################### Edit this out for tamable
		}
	}
}
