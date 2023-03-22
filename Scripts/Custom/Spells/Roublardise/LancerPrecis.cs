using Server.Items;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Polymorphie;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class LancerPrecisSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Lancer precis", "[Lancer precis]",
				SpellCircle.Fourth,
				203,
				9031,
				Reagent.NoxCrystal,
				Reagent.SulfurousAsh,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public LancerPrecisSpell(Mobile caster, Item scroll)
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

				m.BoltEffect(0);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				SpellHelper.Damage(this, m, 5, 0, 100, 0, 0, 0);

				if (!InsensibleSpell.IsActive(m))
				{
					m.PlaySound(22);
					m.FixedEffect(0x923, 3, 30);

					BleedAttack.BeginBleed(m, Caster, true);
				}
				else
					Caster.SendMessage("Votre cible est immunisée aux saignements.");
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private LancerPrecisSpell m_Owner;

			public InternalTarget(LancerPrecisSpell owner)
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