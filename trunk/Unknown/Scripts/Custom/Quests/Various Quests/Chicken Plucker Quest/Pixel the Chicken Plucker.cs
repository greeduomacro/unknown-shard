using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	[CorpseName( "the corpse of the distraught Chicken Plucker" )]
	public class ChickenPlucker : BaseCreature
	{

	private static bool m_Talked;

        string[] kfcsay = new string[]
      { 
		 "You will need to kill me to get in my backpack you fool",
		 "You shall never get the prize from me",
		 "Try and Try but you will die",
		 "Now return to the crazy old farmer and tell him of your death",
		 "The prize is mine you weak fool",
		 "Now my chickens will peck you to death",
		 
      }; 
	 
	 
		[Constructable] 
		public ChickenPlucker() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			SetStr( 2205, 3245 );
			SetDex( 781, 995 );
			SetInt( 2361, 4475 );
			
			SetHits( 8650, 10000 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 50, 70 );
			SetDamageType( ResistanceType.Fire, 50, 70 );
			SetDamageType( ResistanceType.Energy, 50, 70 );
			SetDamageType( ResistanceType.Poison, 50, 70 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			
			SetSkill( SkillName.Wrestling, 90, 120 );
			SetSkill( SkillName.Tactics, 90, 120 );
			SetSkill( SkillName.Healing, 120, 150 );
			SetSkill( SkillName.SpiritSpeak, 120, 150 );
			SetSkill( SkillName.Anatomy, 90, 120 );
			SetSkill( SkillName.Magery, 90, 120 );
			SetSkill( SkillName.MagicResist, 90, 120 );
			SetSkill( SkillName.Meditation, 90, 120 );
			SetSkill( SkillName.DetectHidden, 20000, 30000 );
			
			Fame = 5000;
			Karma = -5000;
 			
			Name = "Pixel";
			Title = "The Chicken Plucking Thief";
			Body = 0x190; 

			SpeechHue = Utility.RandomDyedHue(); 

			Hue = Utility.RandomSkinHue(); 

						
			LeatherChest chest = new LeatherChest(); 
			chest.Hue = 2492; 
			AddItem( chest ); 
			LeatherArms arms = new LeatherArms(); 
			arms.Hue = 2492; 
			AddItem( arms ); 
			LeatherGloves gloves = new LeatherGloves(); 
			gloves.Hue = 2492; 
			AddItem( gloves ); 
			LeatherGorget gorget = new LeatherGorget(); 
			gorget.Hue = 2492; 
			AddItem( gorget ); 
			LeatherLegs legs = new LeatherLegs(); 
			legs.Hue = 2492; 
			AddItem( legs ); 
			
			
			
			PackGold( 2420, 3690 );
			
			if( Utility.Random( 50 ) < 50 ) 
			switch ( Utility.Random( 50 ))
			{ 
        		case 0:	PackItem( new FighterCloak() );
        		break;
        		case 1: PackItem( new DruidCloak() );
        		break;
        		case 2: PackItem( new Piwafwi() );
        		break;
        		case 3: PackItem( new RogueCloak() );
        		break;
        		case 4: PackItem( new RogueSandals() );
        		break;
        		case 5: PackItem( new MasterSandals() );
        		break;
        		
		}

	} 

		public override void OnMovement( Mobile m, Point3D oldLocation ) 
               			{                                                    
         		if( m_Talked == false ) 
         		{ 
            			if ( m.InRange( this, 4 ) ) 
            			{                
               				m_Talked = true; 
               				SayRandom( kfcsay, this ); 
               				this.Move( GetDirectionTo( m.Location ) ); 
                  				// Start timer to prevent spam 
               				SpamTimer t = new SpamTimer(); 
               				t.Start(); 
            			} 
		 			}
	  			}		

		public ChickenPlucker( Serial serial ) : base( serial )
		{
		}

		private class SpamTimer : Timer 
      		{ 
         		public SpamTimer() : base( TimeSpan.FromSeconds( 3 ) ) 
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
		
		public override bool AlwaysMurderer{ get{ return true; } }

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