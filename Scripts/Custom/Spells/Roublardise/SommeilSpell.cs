using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class SommeilSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Sommeil", "[Sommeil]",
				SpellCircle.Eighth,
				203,
				9031,
				Reagent.EssenceRoublardise
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public SommeilSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return false; } }

		public void Target(Mobile m)
		{
			if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				Disturb(m);

				m.FixedParticles(0x37C4, 1, 8, 9916, 39, 3, EffectLayer.Head);
				m.FixedParticles(0x37C4, 1, 8, 9502, 39, 4, EffectLayer.Head);
				m.PlaySound(0x210);

				var duration = GetDurationForSpell(6, 2);

				m.Freeze(duration);
				m.Combatant = null;
				m.Warmode = false;
				m.Emote("*S'endort*");

				CustomUtility.ApplySimpleSpellEffect(m, "Sommeil", AptitudeColor.Roublardise, SpellEffectType.Malus);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private SommeilSpell m_Owner;

			public InternalTarget(SommeilSpell owner)
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