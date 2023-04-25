using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Musique
{
	public class RevelationDiscordanteSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Revelation discordante", "[Revelation discordante]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceMusique
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public RevelationDiscordanteSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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

						m.RevealingAction();

						ArrayList mods = new ArrayList();

						double discord = Caster.Skills[SkillName.Discordance].Value;

						var effect = (int)Math.Max(-28.0, (discord / -4.0));

						if (BaseInstrument.GetBaseDifficulty(m) >= 160.0)
						{
							effect /= 2;
						}

						var scalar = (double)effect / 100;

						mods.Add(new ResistanceMod(ResistanceType.Physical, effect));
						mods.Add(new ResistanceMod(ResistanceType.Fire, effect));
						mods.Add(new ResistanceMod(ResistanceType.Cold, effect));
						mods.Add(new ResistanceMod(ResistanceType.Poison, effect));
						mods.Add(new ResistanceMod(ResistanceType.Energy, effect));

						for (int j = 0; j < m.Skills.Length; ++j)
						{
							if (m.Skills[j].Value > 0)
								mods.Add(new DefaultSkillMod((SkillName)j, true, m.Skills[j].Value * scalar));
						}

						m.UpdateResistances();

						CustomUtility.ApplySimpleSpellEffect(m, "Revelation discordante", AptitudeColor.Musique, SpellEffectType.Malus);
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

			var t = (Timer)m_Timers[m];
			var mod = (ResistanceMod)m_Table[m];

			if (t != null && mod != null)
			{
				t.Stop();

				m_Timers.Remove(m);
				m_Table.Remove(m);

				m.RemoveResistanceMod(mod);

				m.UpdateResistances();

				CustomUtility.ApplySimpleSpellEffect(m, "Revelation discordante", AptitudeColor.Musique, SpellSequenceType.End, SpellEffectType.Malus);
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