using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class ConsecrationSpell : ReligiousSpell
    {
        public static Hashtable m_ConsecrationTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Agglomération", "Sowi Toki",
                SpellCircle.Fifth,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 6; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

        public ConsecrationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                double val = (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 300;

                int valeur = (int)(m.HitsMax * (val / 4));

                if (valeur > 40)
                    valeur = 40;

                if (m is BaseCreature)
                    valeur *= 3;

                valeur += Utility.Random(0, 5);

                AOS.Damage(m, Caster, valeur, 100, 0, 0, 0, 0);

                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(488);
            }

            FinishSequence();
        }

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_ConsecrationTable.Remove(m);

                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(488);
            }
        }

        public class ConsecrationTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public ConsecrationTimer(Mobile target, DateTime end) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && m_ConsecrationTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    m_ConsecrationTable.Remove(m_target);
                    m_Timers.Remove(m_target);

                    m_target.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(488);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private ConsecrationSpell m_Owner;

            public InternalTarget(ConsecrationSpell owner) : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (!(o is Mobile))
                    from.SendMessage("Vous devez cibler une créature ou un joueur!");
                else if (o == from)
                    from.SendMessage("Vous ne pouvez pas vous cibler vous-même!");
                else
                    m_Owner.Target((Mobile)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}