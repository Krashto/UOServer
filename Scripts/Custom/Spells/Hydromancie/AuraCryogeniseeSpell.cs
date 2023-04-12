using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class AuraCryogeniseeSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Aura cryogenisee", "[Aura cryogenisee]",
				SpellCircle.First,
				224,
				9011,
				Reagent.EssenceHydromancie
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Meditation; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AuraCryogeniseeSpell(Mobile caster, Item scroll)
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
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeBeneficial(m, false) && CustomPlayerMobile.IsInEquipe(Caster, m))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						if (IsActive(m))
							Deactivate(m);

						var duration = GetDurationForSpell(15);

						var value = (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10;

						ResistanceMod mod = new ResistanceMod(ResistanceType.Cold, (int)value);
						m_Table[m] = mod;
						m.AddResistanceMod(mod);

						Timer t = new InternalTimer(m, DateTime.Now + duration);
						m_Timers[m] = t;
						t.Start();

						Caster.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
						Caster.PlaySound(0x28E);
					}
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile attacker)
		{
			return m_Table.ContainsKey(attacker);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = (Timer)m_Timers[m];
			var mod = (ResistanceMod)m_Table[m];

			if (t != null && mod != null)
			{
				t.Stop();

				m.RemoveResistanceMod(mod);

				m_Timers.Remove(m);
				m_Table.Remove(m);

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
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