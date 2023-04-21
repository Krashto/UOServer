using System;
using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class AuraDeBrouillardSpell : Spell
	{
		public static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Aura de brouillard", "[Aura de brouillard]",
				SpellCircle.Fifth,
				206,
				9002,
				Reagent.EssenceAeromancie
			);

		public override int RequiredAptitudeValue { get { return 8; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AuraDeBrouillardSpell(Mobile caster, Item scroll)
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

				var range = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 20, Aptitude.Aeromancie);

				IPooledEnumerable eable = Caster.Map.GetMobilesInRange(new Point3D(Caster.Location), range);

				ToogleInvisibility(this, Caster, Caster);

				foreach (Mobile target in eable)
				{
					if (Caster.CanBeBeneficial(target, false) && CustomPlayerMobile.IsInEquipe(Caster, target))
						ToogleInvisibility(this, Caster, target);
				}

				eable.Free();
			}

			FinishSequence();
		}

		public static void ToogleInvisibility(Spell spell, Mobile caster, Mobile m)
		{
			if (IsActive(m))
				Deactivate(m);

			var duration = spell.GetDurationForSpell(30, 2);

			Timer t = new InternalTimer(m, DateTime.Now + duration);
			m_Timers[m] = t;
			t.Start();

			ExplodeFX.Smoke.CreateInstance(m, m.Map, 1).Send();

			m.Hidden = true;
			m.AllowedStealthSteps = (int)SpellHelper.AdjustValue(caster, 1 + caster.Skills[spell.CastSkill].Value / 2, Aptitude.Aeromancie);

			CustomUtility.ApplySimpleSpellEffect(m, "Aura de brouillard", duration, AptitudeColor.Aeromancie);
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers[m] != null;
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = (Timer)m_Timers[m];

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m.RevealingAction();
				CustomUtility.ApplySimpleSpellEffect(m, "Aura de brouillard", AptitudeColor.Aeromancie, SpellSequenceType.End);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_EndTime;

			public InternalTimer(Mobile m, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Mobile = m;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}

		public class InternalTarget : Target
		{
			private AuraDeBrouillardSpell m_Owner;

			public InternalTarget(AuraDeBrouillardSpell owner)
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