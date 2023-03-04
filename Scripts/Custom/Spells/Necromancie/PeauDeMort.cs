using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class PeauDeMortSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Peau De Mort", "In Agle Corp Ylem",
				SpellCircle.Fourth,
				203,
				9051,
				Reagent.BatWing,
				Reagent.GraveDust
            );

        public override int RequiredAptitudeValue { get { return 3; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Necromancie }; } }

        public override SkillName CastSkill { get { return SkillName.Magery; } }
        public override SkillName DamageSkill { get { return SkillName.Forensics; } }

        public PeauDeMortSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
        }

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

        public void Target(Mobile m)
        {
            if (CheckBSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                ExpireTimer timer = (ExpireTimer)m_Table[m];

                if (timer != null)
                    timer.DoExpire();
                else
                    m.SendLocalizedMessage(1061689); // Your skin turns dry and corpselike.

                m.FixedParticles(0x373A, 1, 15, 9913, 67, 7, EffectLayer.Head);
                m.PlaySound(0x1BB);

                double ss = Caster.Skills[CastSkill].Value;
                double mr = Caster.Skills[DamageSkill].Value;

                double value = 3 + 10 * ((ss + mr) / 225);//5 � 18

                value = SpellHelper.AdjustValue(Caster, value, NAptitude.Necromancie);

                TimeSpan duration = GetDurationForSpell(0.5);

                timer = new ExpireTimer(m, (int)value, duration);
                timer.Start();

                m_Table[m] = timer;
            }

            FinishSequence();
        }

		public static int GetResistMalus(Mobile m)
		{
			ExpireTimer t = (ExpireTimer)m_Table[m];

			if (t == null)
				return 0;

			return t.Value;
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool RemoveCurse( Mobile m )
		{
			ExpireTimer t = (ExpireTimer)m_Table[m];

			if ( t == null )
				return false;

			m.SendLocalizedMessage( 1061688 ); // Your skin returns to normal.
			t.DoExpire();
			return true;
		}

		private class ExpireTimer : Timer
		{
			public int Value { get { return m_Value; } }

			private Mobile m_Mobile;
			private int m_Value;

			public ExpireTimer( Mobile m, int value, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
                m_Value = value;

                Priority = TimerPriority.OneSecond;
			}

			public void DoExpire()
            {
				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( 1061688 ); // Your skin returns to normal.
				DoExpire();
			}
		}

		public static bool IsUnderEffects(Mobile defender)
		{
			return m_Table.ContainsKey(defender);
		}

		private class InternalTarget : Target
		{
            private PeauDeMortSpell m_Owner;

            public InternalTarget(PeauDeMortSpell owner)
                : base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}