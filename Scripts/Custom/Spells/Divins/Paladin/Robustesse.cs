using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class RobustesseSpell : ReligiousSpell
    {
        public static Hashtable m_RobustesseTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Robutesse", "Lagu Kano Toki",
                SpellCircle.Second,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 3; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public RobustesseSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(0.4);

                m_RobustesseTable[Caster] = (int)(10 + ((base.Caster.Skills[base.CastSkill].Value + base.Caster.Skills[base.DamageSkill].Value) / 4)); //10 à 110

                Timer t = new RobustesseTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.CheckStatTimers();

                Caster.Hits -= 1;
                Caster.Stam -= 1;

                Caster.FixedParticles(14186, 10, 20, 5013, 0, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(494);
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
                m_RobustesseTable.Remove(m);

                m.CheckStatTimers();
 
                m.Hits -= 1;
                m.Stam -= 1;

                m.FixedParticles(14186, 10, 20, 5013, 0, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(494);
            }
        }

        public class RobustesseTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public RobustesseTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && m_RobustesseTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    m_RobustesseTable.Remove(m_target);
                    m_Timers.Remove(m_target);

                    m_target.CheckStatTimers();

                    m_target.Hits -= 1;
                    m_target.Stam -= 1;

                    m_target.FixedParticles(14186, 10, 20, 5013, 0, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(494);

                    Stop();
                }
            }
        }
    }
}