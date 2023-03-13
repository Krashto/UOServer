using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class GazEndormant : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Gaz endormant", "Vas An Nox",
				SpellCircle.Fourth,
				215,
				9061,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.MandrakeRoot
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public GazEndormant(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var targets = new ArrayList();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Magery].Value / 50, Aptitude.Roublardise));

					foreach (Mobile m in eable)
						if (Caster.CanBeHarmful(m, false))
							targets.Add(m);

					eable.Free();
				}

				Effects.PlaySound(p, Caster.Map, 0x299);

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						Caster.CanBeHarmful(m);

						var duration = GetDurationForSpell(2, 0.05);

						m.Freeze(duration);
						m.Emote("*S'endort*");
						//BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Sleep, 1080139, 1080140, duration, m));

						m.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
						m.PlaySound(0x1E0);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private GazEndormant m_Owner;

			public InternalTarget(GazEndormant owner)
				: base(12, true, TargetFlags.Beneficial)
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