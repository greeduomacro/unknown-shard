using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Druid
{
   public class HollowReedSpell : DruidicSpell
   {
      private static SpellInfo m_Info = new SpellInfo(
            "Hollow Reed", "En Crur Aeta Sec En Ess ",
            SpellCircle.Second,
            203,
            9061,
            false,
            Reagent.Bloodmoss,
            Reagent.MandrakeRoot,
            Reagent.Nightshade
         );

      public override double CastDelay{ get{ return 1.0; } }
      public override double RequiredSkill{ get{ return 30.0; } }
      public override int RequiredMana{ get{ return 30; } }

      public HollowReedSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
      {
      }

      public override void OnCast()
      {
         Caster.Target = new InternalTarget( this );
      }

      public void Target( Mobile m )
      {
         if ( !Caster.CanSee( m ) )
         {
            Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
         }
         else if ( CheckBSequence( m ) )
         {
            SpellHelper.Turn( Caster, m );
            SpellHelper.AddStatBonus( Caster, m, StatType.Str );
            SpellHelper.AddStatBonus( Caster, m, StatType.Dex );

            m.PlaySound( 0x15 );
            m.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );

         }

         FinishSequence();
      }

      private class InternalTarget : Target
      {
         private HollowReedSpell m_Owner;

         public InternalTarget( HollowReedSpell owner ) : base( 12, false, TargetFlags.Beneficial )
         {
            m_Owner = owner;
         }

         protected override void OnTarget( Mobile from, object o )
         {
            if ( o is Mobile )
            {
               m_Owner.Target( (Mobile)o );
            }
         }

         protected override void OnTargetFinish( Mobile from )
         {
            m_Owner.FinishSequence();
         }
      }
   }
}
