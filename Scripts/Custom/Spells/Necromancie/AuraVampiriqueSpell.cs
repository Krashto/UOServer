using System;
using System.Collections;
using System.Collections.Generic;
using Server.Custom.Aptitudes;
using Server.Mobiles;
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

		public override int RequiredAptitudeValue { get { return 8; } }
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
				var targets = new ArrayList();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(Caster.Location, (int)(1 + Caster.Skills[CastSkill].Value / 25));

					targets.Add(Caster);

					foreach (Mobile m in eable)
					{
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeBeneficial(m, false) && CustomPlayerMobile.IsInEquipe(Caster, m))
							targets.Add(m);
					}

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						if (IsActive(Caster))
							Deactivate(Caster);

						new SoundEffectTimer(Caster).Start();

						var duration = GetDurationForSpell(15, 3);

						var t = new ExpireTimer(Caster, duration);

						m_Timers[Caster] = t;
						t.Start();

						BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.CurseWeapon, 1060512, 1153780, duration, Caster));

						CustomUtility.ApplySimpleSpellEffect(Caster, "Aura vampirique", duration, AptitudeColor.Necromancie);
					}
				}
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

				CustomUtility.ApplySimpleSpellEffect(m, "Aura vampirique", AptitudeColor.Necromancie, SpellSequenceType.End);
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