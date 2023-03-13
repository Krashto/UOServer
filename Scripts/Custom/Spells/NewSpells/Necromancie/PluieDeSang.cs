using System.Collections;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class PluieAcideSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Pluie Acide", "Kal Nox Corp Grav",
				SpellCircle.Seventh,
				236,
				9011,
				Reagent.Nightshade,
				Reagent.NoxCrystal,
				Reagent.Bloodmoss
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public PluieAcideSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var map = Caster.Map;

				var targets = new ArrayList();

				if (map != null)
				{
					var range = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 5, Aptitude.Necromancie);

					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(Caster.Location), range);

					ExplodeFX.BloodRain.CreateInstance(Caster, Caster.Map, range);

					foreach (Mobile m in eable)
						if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m != Caster && Caster.InLOS(m))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];
						BleedAttack.BeginBleed(m, Caster, true);
						InfectionSpell.ToogleCurse(this, Caster, m);
					}
			}

			FinishSequence();
		}
	}
}