using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class VoileSpell : ReligiousSpell
    {
        public static Hashtable m_VoileTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Voile", "Mann Berk",
                SpellCircle.Fourth,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 10; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public VoileSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(2);

                m_VoileTable[Caster] = (int)(5 + ((base.Caster.Skills[base.CastSkill].Value + base.Caster.Skills[base.DamageSkill].Value) / 5));

                Timer t = new VoileTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14170, 10, 15, 5013, 211, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(493);
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
                m_VoileTable.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 211, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(493);
            }
        }

        public class VoileTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public VoileTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && m_VoileTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    m_VoileTable.Remove(m_target);
                    m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 211, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(493);

                    Stop();
                }
            }
        }
    }
}