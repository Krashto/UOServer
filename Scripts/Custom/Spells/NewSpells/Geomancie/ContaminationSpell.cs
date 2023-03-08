using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class ContaminationSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Contamination", "In Nox",
				SpellCircle.Third,
				203,
				9051,
				Reagent.Nightshade,
				Reagent.SulfurousAsh,
				Reagent.NoxCrystal
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ContaminationSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				Disturb(m);

				int level;

				var total = Caster.Skills[SkillName.Magery].Value + Caster.Skills[SkillName.Poisoning].Value;

				if (total >= 200.0 && 3 > Utility.Random(10))
					level = 3;
				else if (total > 140.0)
					level = 2;
				else
					level = 1;

				if (level > 1 && CheckResisted(m))
				{
					level = 1;
					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				m.ApplyPoison(Caster, Poison.GetPoison(level));

				m.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
				m.PlaySound(0x474);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ContaminationSpell m_Owner;

			public InternalTarget(ContaminationSpell owner) : base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.Target((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}