using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class SoifDeSangSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Soif de sang", "Bal Corp Hur Xen",
				SpellCircle.Second,
				212,
				9041,
				Reagent.BlackPearl,
				Reagent.Bloodmoss,
				Reagent.Garlic
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public SoifDeSangSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
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
				var source = Caster;

				SpellHelper.Turn(source, m);

				Disturb(m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				m.PlaySound(22);
				m.FixedEffect(0x923, 3, 30);

				BleedAttack.BeginBleed(m, Caster, true);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private SoifDeSangSpell m_Owner;

			public InternalTarget(SoifDeSangSpell owner)
				: base(12, false, TargetFlags.Harmful)
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