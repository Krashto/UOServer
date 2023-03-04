using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class HautePrecisionSpell : ReligiousSpell
    {
        public static Hashtable m_HautePrecisionTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Haute Précision", "Ansu Sowi",
                SpellCircle.First,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 4; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public HautePrecisionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(0.4);

                m_HautePrecisionTable[Caster] = 0.02 + ((base.Caster.Skills[base.CastSkill].Value + base.Caster.Skills[base.DamageSkill].Value) / 4000); //2 à 7% par joueur.

                Timer t = new HautePrecisionTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14154, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(501);
            }

            FinishSequence();
        }

        public override bool DelayedDamage { get { return false; } }

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_HautePrecisionTable.Remove(m);

                m.FixedParticles(14154, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(501);
            }
        }

        public class HautePrecisionTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public HautePrecisionTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && m_HautePrecisionTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    m_HautePrecisionTable.Remove(m_target);
                    m_Timers.Remove(m_target);

                    m_target.FixedParticles(14154, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(501);

                    Stop();
                }
            }
        }
    }
}