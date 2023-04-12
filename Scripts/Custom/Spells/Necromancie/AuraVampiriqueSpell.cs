using System;
using System.Collections.Generic;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class AuraVampiriqueSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Aura vampirique", "[Aura vampirique]",
				SpellCircle.Second,
				203,
				9031,
				Reagent.EssenceNecromancie
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }


		private static readonly Dictionary<Mobile, ExpireTimer> m_Timers = new Dictionary<Mobile, ExpireTimer>();

		public override bool ClearHandsOnCast { get { return false; } }

		public AuraVampiriqueSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				if (IsActive(Caster))
					Deactivate(Caster);

				Caster.PlaySound(0x387);
				Caster.FixedParticles(0x3779, 1, 15, 9905, 32, 2, EffectLayer.Head);
				Caster.FixedParticles(0x37B9, 1, 14, 9502, 32, 5, (EffectLayer)255);
				new SoundEffectTimer(Caster).Start();

				var duration = GetDurationForSpell(15);

				var t = new ExpireTimer(Caster, duration);

				m_Timers[Caster] = t;
				t.Start();

				BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.CurseWeapon, 1060512, 1153780, duration, Caster));
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile attacker)
		{
			return m_Timers.ContainsKey(attacker);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);

				BuffInfo.RemoveBuff(m, BuffIcon.CurseWeapon);


				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		public class ExpireTimer : Timer
		{
			public Mobile Owner { get; private set; }

			public ExpireTimer(Mobile owner, TimeSpan delay) : base(delay)
			{
				Owner = owner;
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				Effects.PlaySound(Owner.Location, Owner.Map, 0xFA);

				if (m_Timers.ContainsKey(Owner))
					m_Timers.Remove(Owner);
			}
		}

		private class SoundEffectTimer : Timer
		{
			private readonly Mobile m_Mobile;

			public SoundEffectTimer(Mobile m)
				: base(TimeSpan.FromSeconds(0.75))
			{
				m_Mobile = m;
				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound(0xFA);
			}
		}
	}
}