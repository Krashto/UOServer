using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class ExplosionDeRocheSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Explosion De Roche", "Roc Kal Des Ylem",
				SpellCircle.Eighth,
				233,
				9042,
				false,
				Reagent.SulfurousAsh,
				Reagent.SulfurousAsh,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ExplosionDeRocheSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return true; } }

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				if (p is Item)
					p = ((Item)p).GetWorldLocation();

				var targets = new ArrayList();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)(1 + Caster.Skills[CastSkill].Value / 25));

					foreach (Mobile m in eable)
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					Effects.PlaySound(p, Caster.Map, 0x160);

					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var source = Caster;

						SpellHelper.Turn(source, m);

						Disturb(m);

						SpellHelper.CheckReflect((int)Circle, ref source, ref m);

						var scalar = 1.0;

						if (AuraFortifianteSpell.IsActive(Caster))
						{
							scalar += 0.5;
							AuraFortifianteSpell.StopTimer(Caster);
						}

						if (FortifieSpell.IsActive(Caster))
						{
							scalar += 0.5;
							FortifieSpell.StopTimer(Caster);
						}

						double damage = GetNewAosDamage(m, (int)(4 * scalar), 1, 6, true);

						if (CheckResisted(m))
						{
							damage *= 0.75;

							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						source.MovingParticles(m, 0x36D4, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);
						source.PlaySound(0x44B);

						SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ExplosionDeRocheSpell m_Owner;

			public InternalTarget(ExplosionDeRocheSpell owner)
				: base(12, true, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as IPoint3D;

				if (p != null)
					m_Owner.Target(p);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}