using System.Collections;
using Server.Custom.Aptitudes;
using Server.Mobiles;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class ExplosionDeRochesSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Explosion De Roches", "[Explosion De Roches]",
				SpellCircle.Eighth,
				233,
				9042,
				Reagent.EssenceGeomancie
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ExplosionDeRochesSpell(Mobile caster, Item scroll)
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
					var range = (int)(1 + Caster.Skills[CastSkill].Value / 25);

					IPooledEnumerable eable = map.GetMobilesInRange(Caster.Location, range);

					ExplodeFX.Earth.CreateInstance(Caster.Location, Caster.Map, range).Send();

					foreach (Mobile m in eable)
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
							targets.Add(m);

					eable.Free();
				}

				var scalar = 1.0;

				if (AuraFortifianteSpell.IsActive(Caster))
				{
					scalar += 1.0;
					AuraFortifianteSpell.Deactivate(Caster);
				}

				if (FortifieSpell.IsActive(Caster))
				{
					scalar += 1.0;
					FortifieSpell.Deactivate(Caster);
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var source = Caster;

						SpellHelper.Turn(source, m);

						Disturb(m);

						SpellHelper.CheckReflect((int)Circle, ref source, ref m);

						double damage = GetNewAosDamage(m, (int)(4 * scalar), (int)(1 * scalar), (int)(2 * scalar), false);

						if (CheckResisted(m))
						{
							damage *= 0.75;

							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

						source.MovingParticles(m, 0x11B6, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);

						CustomUtility.ApplySimpleSpellEffect(m, "Explosion De Roches", AptitudeColor.Geomancie, SpellEffectType.Damage);
					}
				}
			}

			FinishSequence();
		}
	}
}