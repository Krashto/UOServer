using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class CerveauGeleSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Cerveau gelé", "Vas Aqua",
				SpellCircle.Fifth,
				203,
				9041,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.Ginseng
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CerveauGeleSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return true; } }

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(m))
			{
				var source = Caster;

				SpellHelper.Turn(source, m);

				Disturb(m);

				if (m.Hits > m.HitsMax / 2 && (CageDeGlaceSpell.IsActive(m) || BlizzardSpell.IsActive(m) || ExplosionDeGlaceSpell.IsActive(m)))
					m.Damage(m.Hits - m.HitsMax / 2);

				source.MovingParticles(m, 0x36D4, 7, 0, false, true, 1941, 0, 9502, 4019, 0x160, 0);
				source.PlaySound(282);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private CerveauGeleSpell m_Owner;

			public InternalTarget(CerveauGeleSpell owner)
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