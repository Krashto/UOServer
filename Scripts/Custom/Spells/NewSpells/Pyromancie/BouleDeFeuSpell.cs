using Server.Items;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class BouleDeFeuSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Boule de feu", "Vas Flam",
				SpellCircle.Fourth,
				203,
				9031,
				Reagent.NoxCrystal,
				Reagent.SulfurousAsh,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public BouleDeFeuSpell(Mobile caster, Item scroll)
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

				m.PlaySound(22);
				m.FixedEffect(0x923, 3, 30);

				SpellHelper.CheckReflect((int)Circle, ref source, ref m);

				double damage = GetNewAosDamage(m, 6, 1, 2, false);

				if (CheckResisted(m))
				{
					damage *= 0.75;

					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				source.MovingParticles(m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
				source.PlaySound(0x15E);

				SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

				if (Utility.RandomDouble() < 0.25)
					BleedAttack.BeginBleed(m, Caster, true);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private BouleDeFeuSpell m_Owner;

			public InternalTarget(BouleDeFeuSpell owner)
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