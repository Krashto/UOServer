using System;
using System.Collections;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class BrouillardSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Brouillard", "An Lor Xen",
				SpellCircle.Fifth,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.Nightshade,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public BrouillardSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Effects.SendLocationParticles(EffectItem.Create(new Point3D(Caster.X, Caster.Y, Caster.Z + 16), Caster.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
			Caster.PlaySound(0x3C4);

			Caster.Hidden = true;
			Caster.AllowedStealthSteps = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Magery].Value / 2, Aptitude.Aeromancie);
			Caster.SendLocalizedMessage(502730); // You begin to move quietly.

			ExplodeFX.Smoke.CreateInstance(Caster, Caster.Map, 1).Send();

			RemoveTimer(Caster);

			var duration = GetDurationForSpell(30, 2);

			Timer t = new InternalTimer(Caster, duration);
			m_Table[Caster] = t;
			t.Start();

			FinishSequence();
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
	}
}