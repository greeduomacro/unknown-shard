
using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class wSherif : BaseVendor
	{
	
    private static bool m_Talked; // flag to prevent spam 

      string[] kfcsay = new string[] // things to say while greating 
      { 
         "Help me catch the criminals running lose, I can pay you for your troubles!",
};
		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public wSherif() : base( "Sherif" )
		{
			SetSkill( SkillName.Camping, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 45.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBwSherif() );
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

      private class SpamTimer : Timer 
      { 
         public SpamTimer() : base( TimeSpan.FromSeconds( 8 ) ) 
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

		public wSherif( Serial serial ) : base( serial )
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
	}
}