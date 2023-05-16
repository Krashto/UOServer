using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Musique
{
	public class HavreDePaixSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Havre de paix", "[Havre de paix]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceMusique
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public HavreDePaixSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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

					foreach (Mobile m in eable)
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						SpellHelper.Turn(Caster, m);

						m.Combatant = null;
						m.Warmode = false;

						Disarm.DoEffect(Caster, m);

						CustomUtility.ApplySimpleSpellEffect(m, "Havre de paix", AptitudeColor.Musique, SpellEffectType.Malus);

						if (m is BaseCreature && !((BaseCreature)m).BardPacified)
						{
							var duration = TimeSpan.FromSeconds(30.0);
							var bc = (BaseCreature)m;
							bc.Pacify(Caster, DateTime.UtcNow + duration);
						}
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

				m_Timers.Remove(m);
				m_Table.Remove(m);

				CustomUtility.ApplySimpleSpellEffect(m, "Havre de paix", AptitudeColor.Musique, SpellSequenceType.End, SpellEffectType.Malus);
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