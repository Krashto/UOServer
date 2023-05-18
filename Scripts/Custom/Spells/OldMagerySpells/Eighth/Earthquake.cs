using System;

namespace Server.Spells.Eighth
{
    public class EarthquakeSpell : MagerySpell
    {
        //public override DamageType SpellDamageType => DamageType.SpellAOE;

        private static readonly SpellInfo m_Info = new SpellInfo(
            "Earthquake", "In Vas Por",
			SpellCircle.Eighth,
            233,
			9012,
            false,
            Reagent.Bloodmoss,
            Reagent.Ginseng,
            Reagent.MandrakeRoot,
            Reagent.SulfurousAsh);

        public EarthquakeSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Eighth;
        public override bool DelayedDamage => false;
        public override void OnCast()
        {
            if (SpellHelper.CheckTown(Caster, Caster) && CheckSequence())
            {
                foreach (Mobile m in Caster.FindMobilesInRange(Caster.Map, 1 + (int)(Caster.Skills[SkillName.Magery].Value / 15.0)))
                {
                    int damage = m.Hits / 2;

                    if (m == null || !m.Player)
                        damage = Math.Max(Math.Min(damage, 100), 15);
                    damage += Utility.RandomMinMax(0, 15);

                    Caster.DoHarmful(m);
                    SpellHelper.Damage(this, m, damage, 100, 0, 0, 0, 0);
                }
            }

            FinishSequence();
        }
    }
}
