using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class BerseckSpell : ReligiousSpell
    {
        public static Hashtable m_BerseckTable = new Hashtable();
        public static Hashtable m_BerseckRegistry = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Berseck", "Marc Reta Fehu",
                SpellCircle.Fourth,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 7; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public BerseckSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(0.3);

                m_BerseckTable[Caster] = 0.05 + (double)((base.Caster.Skills[base.CastSkill].Value + base.Caster.Skills[base.DamageSkill].Value) / 4000); //5 à 10% par coup
                m_BerseckRegistry[Caster] = (double)0;

                Timer t = new BerseckTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14201, 10, 15, 5013, 1720, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(480);
            }

            FinishSequence();
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else 

            FinishSequence();
        }

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_BerseckTable.Remove(m);
                m_BerseckRegistry.Remove(m);

                m.FixedParticles(14201, 10, 15, 5013, 1720, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(480);
            }
        }

        public class BerseckTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public BerseckTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && m_BerseckTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    m_BerseckTable.Remove(m_target);
                    m_Timers.Remove(m_target);
                    m_BerseckRegistry.Remove(m_target);

                    m_target.FixedParticles(14201, 10, 15, 5013, 1720, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(480);

                    Stop();
                }
            }
        }
    }
}