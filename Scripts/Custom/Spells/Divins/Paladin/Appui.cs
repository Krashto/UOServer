using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class AppuiSpell : ReligiousSpell
    {
        public static Hashtable m_AppuiTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Appui", "Ansu Algi",
                SpellCircle.Seventh,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 11; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public AppuiSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(0.4);

                m_AppuiTable[Caster] = Caster;//3% par tile, 36% à 1 tile.

                Timer t = new AppuiTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14186, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(513);
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
                m_AppuiTable.Remove(m);

                m.FixedParticles(14186, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(513);
            }
        }

        public class AppuiTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public AppuiTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && AppuiSpell.m_AppuiTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    AppuiSpell.m_AppuiTable.Remove(m_target);
                    AppuiSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14186, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(513);

                    Stop();
                }
            }
        }
    }
}