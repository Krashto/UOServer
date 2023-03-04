using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class PurificationSpell : ReligiousSpell
    {
        public static Hashtable m_PurificationTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Purification", "Perth Otil",
                SpellCircle.Fourth,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 8; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public PurificationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(0.4);

                m_PurificationTable[Caster] = (int)(Utility.Random(0, 10) + ((base.Caster.Skills[base.CastSkill].Value + base.Caster.Skills[base.DamageSkill].Value) / 20));

                Timer t = new PurificationTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14270, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(506);
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
                m_PurificationTable.Remove(m);

                m.FixedParticles(14270, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(506);
            }
        }

        public class PurificationTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public PurificationTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && m_PurificationTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    m_PurificationTable.Remove(m_target);
                    m_Timers.Remove(m_target);

                    m_target.FixedParticles(14270, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(506);

                    Stop();
                }
            }
        }
    }
}