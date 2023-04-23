using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class GazEndormantSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Gaz endormant", "[Gaz endormant]",
				SpellCircle.Fourth,
				215,
				9061,
				Reagent.EssenceRoublardise
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public GazEndormantSpell(Mobile caster, Item scroll)
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
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 50, Aptitude.Roublardise));

					foreach (Mobile m in eable)
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
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
						m.Combatant = null;
						m.Warmode = false;
						m.Emote("*S'endort*");

						CustomUtility.ApplySimpleSpellEffect(m, "Gaz endormant", AptitudeColor.Roublardise, SpellEffectType.Malus);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private GazEndormantSpell m_Owner;

			public InternalTarget(GazEndormantSpell owner)
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