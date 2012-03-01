//Created with Script Creator By Marak & Rockstar
//Oh, and Kevin E. was here :P
using System;
using Server.Network;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Engines.CannedEvil;;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server

namespace Server.Mobiles
{
[CorpseName("Corpse of OrcCheifton")]
public class OrcCheifton:OrchishLord
{

      private static bool m_Talked;
          string[]OrcCheiftonSay = new string[]
          {
"I see a penis lover like yourself dare challenges the order of the Orc!",
"Thine pain will be felt by thine deepest love.",
"I shall always remember the ease of killing you.",
};

[Constructable]
public OrcCheifton() : base()
{

Name = "OrcCheifton";
Hue = 51;
SetStr (100) ;
SetDex (100) ;
SetInt (100) ;

SetDamage (10, 20) ;

SetDamageType( ResistanceType.Physical,100) ;


SetResistance( ResistanceType.Physical,20) ;
SetResistance( ResistanceType.Cold,5) ;
SetResistance( ResistanceType.Fire,20) ;
SetResistance( ResistanceType.Energy,20) ;
SetResistance( ResistanceType.Poison,20) ;

Fame = 300;
Karma = -3000;

VirtualArmor = 10;

ControlSlots = 5;



}

          public override bool AlwaysMurderer{ get{ return true; } }
          public override bool CanRummageCorpses{ get{ return true; } }


		public OrcCheifton( Serial serial ) : base( serial )
		{
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
            public override void OnMovement( Mobile m, Point3D oldLocation )
            {

                 if( m_Talked == false )
                 {
                      if ( m.InRange( this, 3 ) && m is PlayerMobile)
                       {

                             m_Talked = true;
                             SayRandom(OrcCheiftonSay, this );
                             this.Move( GetDirectionTo( m.Location ) );
                             SpamTimer t = new SpamTimer();
                             t.Start();
                        }
                   }
              }

              private class SpamTimer : Timer
              {
                   public SpamTimer() : base( TimeSpan.FromSeconds( 12 ) )
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
	        public override bool OnBeforeDeath()	
	        {	
	            	
		
	            if (!NoKillAwards)	
	            {	
		
	                Map map = this.Map;	
		
	                if (map != null)	
	                {	
	                    for (int x = -12; x <= 12; ++x)	
	                    {	
	                        for (int y = -12; y <= 12; ++y)	
	                        {	
	                            double dist = Math.Sqrt(x * x + y * y);	
		
	                            if (dist <= 12)	
	                                new GoodiesTimer(map, X + x, Y + y).Start();	
	                        }	
	                    }	
	                }	
	            }	
		
	            return base.OnBeforeDeath();	
	        }	
		
		
	        public override void OnDeath(Container c)	
	        {	
	            if (Map == Map.Felucca)	
	            {	
	                //TODO: Confirm SE change or AoS one too?	
	                List<DamageStore> rights = BaseCreature.GetLootingRights(this.DamageEntries, this.HitsMax);	
	                List<Mobile> toGive = new List<Mobile>();	
		
	                for (int i = rights.Count - 1; i >= 0; --i)	
	                {	
	                    DamageStore ds = rights[i];	
		
	                    if (ds.m_HasRight)	
	                        toGive.Add(ds.m_Mobile);	
	                }	
		
	            }	
		
	            base.OnDeath(c);	
	        }	
		
		
	        private class GoodiesTimer : Timer	
	        {	
	            private Map m_Map;	
	            private int m_X, m_Y;	
		
	            public GoodiesTimer(Map map, int x, int y)	
	                : base(TimeSpan.FromSeconds(Utility.RandomDouble() * 10.0))	
	            {	
	                m_Map = map;	
	                m_X = x;	
	                m_Y = y;	
	            }	
		
	            protected override void OnTick()	
	            {	
	                int z = m_Map.GetAverageZ(m_X, m_Y);	
	                bool canFit = m_Map.CanFit(m_X, m_Y, z, 6, false, false);	
		
	                for (int i = -3; !canFit && i <= 3; ++i)	
	                {	
	                    canFit = m_Map.CanFit(m_X, m_Y, z + i, 6, false, false);	
		
	                    if (canFit)	
	                        z += i;	
	                }	
		
	                if (!canFit)	
	                    return;	
		
	                Gold g = new Gold(6, 2000);	
		
	                g.MoveToWorld(new Point3D(m_X, m_Y, z), m_Map);	
		
	                if (0.5 >= Utility.RandomDouble())	
	                {	
	                    switch (Utility.Random(3))	
	                    {	
	                        case 0: // Fire column	
	                            {	
	                                Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x3709, 10, 30, 5052);	
	                                Effects.PlaySound(g, g.Map, 0x208);	
		
	                                break;	
	                            }	
	                        case 1: // Explosion	
	                            {	
	                                Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x36BD, 20, 10, 5044);	
	                                Effects.PlaySound(g, g.Map, 0x307);	
		
	                                break;	
	                            }	
	                        case 2: // Ball of fire	
	                            {	
	                                Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x36FE, 10, 10, 5052);	
		
	                                break;	
	                            }	
	                    }	
	                }	
	            }	
	        }	
	}
}
