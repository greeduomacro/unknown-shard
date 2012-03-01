using System;
using Server;

namespace Server.Spells.Druid
{
   public abstract class DruidicSpell : Spell
   {
      public abstract double CastDelay{ get; }
      public abstract double RequiredSkill{ get; }
      public abstract int RequiredMana{ get; }

      public override SkillName CastSkill{ get{ return SkillName.AnimalLore; } }
      public override SkillName DamageSkill{ get{ return SkillName.AnimalTaming; } }

      public override bool ClearHandsOnCast{ get{ return false; } }

      public DruidicSpell( Mobile caster, Item scroll, SpellInfo info ) : base( caster, scroll, info )
      {
      }

      public override void GetCastSkills( out double min, out double max )
      {
         min = RequiredSkill;
         max = RequiredSkill + 30.0;
      }

      public override int GetMana()
      {
         return RequiredMana;
      }

      public override TimeSpan GetCastDelay()
      {
         return TimeSpan.FromSeconds( CastDelay );
      }
   }
}
