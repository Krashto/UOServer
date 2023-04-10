using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class AbsorbationSonoreSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Absorbation sonore", "[Absorbation sonore]",
				SpellCircle.First,
				212,
				9061,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AbsorbationSonoreSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && !CustomPlayerMobile.IsInEquipe(Caster, m))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var value = (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10;

						var manaSteal = (int)Math.Min(value, 100 / targets.Count);

						Caster.Mana += Math.Min(manaSteal, Caster.ManaMax - Caster.Mana);
						m.Mana -= Math.Min(manaSteal, m.Mana);

						Caster.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
						Caster.PlaySound(0x28E);
					}
				}
			}

			FinishSequence();
		}
	}
}