using System.Collections;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class FleauTerrestreSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Fléau terrestre", "Kal Nox Corp Grav",
				SpellCircle.Seventh,
				236,
				9011,
				Reagent.Nightshade,
				Reagent.NoxCrystal,
				Reagent.Bloodmoss
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FleauTerrestreSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Map map = Caster.Map;

				ArrayList targets = new ArrayList();

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(Caster.Location), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 5, Aptitude.Necromancie));

					foreach (Mobile m in eable)
					{
						if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m != Caster && Caster.InLOS(m))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (int i = 0; i < targets.Count; ++i)
					{
						Mobile m = (Mobile)targets[i];

						ApplyPoisonTo(m);
						m.PlaySound(0x474);
					}
				}
			}

			FinishSequence();
		}

		public void ApplyPoisonTo(Mobile m)
		{
			if (Caster == null)
				return;

			Poison p = Poison.Deadly;

			m.ApplyPoison(Caster, p);
		}
	}
}