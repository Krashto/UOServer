using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class AuraEvasiveSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Aura Evasive", "Flam Sanct",
				SpellCircle.Eighth,
				236,
				9011,
				Reagent.Garlic,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AuraEvasiveSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			var value = 10 + Caster.Skills[SkillName.Magery].Value / 3 + Caster.Skills[SkillName.EvalInt].Value / 3;

			value = SpellHelper.AdjustValue(Caster, value, Aptitude.Aeromancie);

			if (value < 0)
				value = 1;
			else if (value > 100)
				value = 100;

			var map = Caster.Map;

			var targets = new ArrayList();

			targets.Add(Caster);

			if (map != null)
			{
				IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(Caster.Location), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Magery].Value / 20, Aptitude.Aeromancie));

				foreach (Mobile m in eable)
					if (Caster.CanBeBeneficial(m, false))
						targets.Add(m);

				eable.Free();
			}

			if (targets.Count > 0)
			{
				for (var i = 0; i < targets.Count; ++i)
				{
					var m = (Mobile)targets[i];

					m.MeleeDamageAbsorb = (int)value;
					m.MagicDamageAbsorb = (int)value;

					m.FixedParticles(0x376A, 9, 32, 5008, EffectLayer.Waist);
					m.PlaySound(0x1F2);
				}

				Caster.PlaySound(163);
			}

			FinishSequence();
		}
	}
}