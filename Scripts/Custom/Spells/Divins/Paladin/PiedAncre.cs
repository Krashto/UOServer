using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class PiedAncreSpell : ReligiousSpell
    {
        public static Hashtable m_PiedAncreTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Pied Ancré", "Tyros Sowi",
                SpellCircle.First,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 2; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public PiedAncreSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(0.4);

                m_PiedAncreTable[Caster] = (int)(5 + ((base.Caster.Skills[base.CastSkill].Value + base.Caster.Skills[base.DamageSkill].Value) / 10)); //5 à 25%

                Timer t = new PiedAncreTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14154, 10, 20, 5013, 2063, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(487);
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
                m_PiedAncreTable.Remove(m);

                m.FixedParticles(14154, 10, 20, 5013, 2063, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(487);
            }
        }

        public class PiedAncreTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public PiedAncreTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && PiedAncreSpell.m_PiedAncreTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    m_PiedAncreTable.Remove(m_target);
                    m_Timers.Remove(m_target);

                    m_target.FixedParticles(14154, 10, 20, 5013, 2063, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(487);

                    Stop();
                }
            }
        }
    }
}