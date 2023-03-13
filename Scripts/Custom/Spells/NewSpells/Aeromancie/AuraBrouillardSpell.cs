using System;
using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class AuraBrouillardSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Aura de brouillard", "An Lor Xen",
				SpellCircle.Fifth,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.Nightshade,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 8; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AuraBrouillardSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				var range = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Magery].Value / 20, Aptitude.Aeromancie);

				IPooledEnumerable eable = Caster.Map.GetMobilesInRange(new Point3D(Caster.Location), range);

				ToogleInvisibility(this, Caster, Caster);

				foreach (Mobile target in eable)
				{
					if (Caster.CanBeBeneficial(target, false))
						ToogleInvisibility(this, Caster, target);
				}
			}

			FinishSequence();
		}

		public static void ToogleInvisibility(Spell spell, Mobile caster, Mobile m)
		{
			ExplodeFX.Smoke.CreateInstance(m, m.Map, 1);

			m.Hidden = true;
			m.AllowedStealthSteps = (int)SpellHelper.AdjustValue(caster, 1 + caster.Skills[SkillName.Magery].Value / 2, Aptitude.Aeromancie);
			m.SendLocalizedMessage(502730); // You begin to move quietly.

			RemoveTimer(m);

			var duration = spell.GetDurationForSpell(30, 1);

			Timer t = new InternalTimer(m, duration);
			m_Table[m] = t;
			t.Start();
		}

		public static Hashtable m_Table = new Hashtable();

		public static bool HasTimer(Mobile m)
		{
			return m_Table[m] != null;
		}

		public static void RemoveTimer(Mobile m)
		{
			var t = (Timer)m_Table[m];

			if (t != null)
			{
				t.Stop();
				m_Table.Remove(m);
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer(Mobile m, TimeSpan duration) : base(duration)
			{
				Priority = TimerPriority.TwoFiftyMS;
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				m_Mobile.RevealingAction();
				RemoveTimer(m_Mobile);
			}
		}

		public class InternalTarget : Target
		{
			private AuraBrouillardSpell m_Owner;

			public InternalTarget(AuraBrouillardSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.Target((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}