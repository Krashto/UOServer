using Server.Custom.Aptitudes;
using Server.Mobiles;
using Server.Spells;
using System;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class AuraElectrisanteSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Aura Electrisante", "[Aura Electrisante]",
				SpellCircle.Eighth,
				236,
				9011,
				Reagent.EssenceAeromancie
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AuraElectrisanteSpell(Mobile caster, Item scroll)
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

						if (IsActive(m))
							Deactivate(m);

						var duration = GetDurationForSpell(15, 3);

						var value = SpellHelper.AdjustValue(Caster, (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 5, Aptitude.Aeromancie);

						ResistanceMod mod = new ResistanceMod(ResistanceType.Energy, (int)value);
						m_Table[m] = mod;
						m.AddResistanceMod(mod);
						m.UpdateResistances();

						CustomUtility.ApplySimpleSpellEffect(m, "Aura électrisante", duration, AptitudeColor.Aeromancie);

						Timer t = new InternalTimer(m, DateTime.Now + duration);
						m_Timers[m] = t;
						t.Start();
					}
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;
			var mod = m_Table[m] as ResistanceMod;

			if (t != null && mod != null)
			{
				t.Stop();

				m.RemoveResistanceMod(mod);

				m.UpdateResistances();

				m_Timers.Remove(m);
				m_Table.Remove(m);
				CustomUtility.ApplySimpleSpellEffect(m, "Aura électrisante", AptitudeColor.Aeromancie, SpellSequenceType.End);

				m.FixedParticles(14217, 10, 20, 5013, 2093, 0, EffectLayer.Waist); //ID, speed, dura, effect, hue, render, layer
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
	}
}