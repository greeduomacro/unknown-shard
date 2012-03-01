using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Druid
{
   public class SwarmOfInsectsSpell : DruidicSpell
   {
      private static SpellInfo m_Info = new SpellInfo(
            "Swarm Of Insects", "Ess Ohm En Sec Tia",
            SpellCircle.Seventh,
            263,
            9032,
            false,
            Reagent.Garlic,
            Reagent.Nightshade,
            Reagent.DestroyingAngel
         );

      public override double CastDelay{ get{ return 2.0; } }
      public override double RequiredSkill{ get{ return 85.0; } }
      public override int RequiredMana{ get{ return 70; } }

      public SwarmOfInsectsSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
      {
      }

      public override void OnCast()
      {
         Caster.Target = new InternalTarget( this );
      }

      public void Target( Mobile m )
      {
         if ( CheckHSequence( m ) )
         {
            SpellHelper.Turn( Caster, m );

            SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

            CheckResisted( m ); // Check magic resist for skill, but do not use return value

            m.FixedParticles( 0x91B, 1, 240, 9916, 0, 3, EffectLayer.Head );
            m.PlaySound( 0x1E5 );

            double damage = ((Caster.Skills[CastSkill].Value - m.Skills[SkillName.AnimalLore].Value) / 10) + 30;

            if ( damage < 1 )
               damage = 1;

            if ( m_Table.Contains( m ) )
               damage /= 10;
            else
               new InternalTimer( m, damage * 0.5 ).Start();

            SpellHelper.Damage( this, m, damage );
         }

         FinishSequence();
      }

      private static Hashtable m_Table = new Hashtable();

      private class InternalTimer : Timer
      {
         private Mobile m_Mobile;
         private int m_ToRestore;

         public InternalTimer( Mobile m, double toRestore ) : base( TimeSpan.FromSeconds( 20.0 ) )
         {
            Priority = TimerPriority.OneSecond;

            m_Mobile = m;
            m_ToRestore = (int)toRestore;

            m_Table[m] = this;
         }

         protected override void OnTick()
         {
            m_Table.Remove( m_Mobile );

            if ( m_Mobile.Alive )
               m_Mobile.Hits += m_ToRestore;
         }
      }

      private class InternalTarget : Target
      {
         private SwarmOfInsectsSpell m_Owner;

         public InternalTarget( SwarmOfInsectsSpell owner ) : base( 12, false, TargetFlags.Harmful )
         {
            m_Owner = owner;
         }

         protected override void OnTarget( Mobile from, object o )
         {
            if ( o is Mobile )
               m_Owner.Target( (Mobile) o );
         }

         protected override void OnTargetFinish( Mobile from )
         {
            m_Owner.FinishSequence();
         }
      }
   }
}
