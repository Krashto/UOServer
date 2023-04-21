using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using System;

namespace Server.Custom.Spells.NewSpells.Musique
{
	public class CalmeToiSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Calme toi!", "[Calme toi!]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceMusique
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CalmeToiSpell(Mobile caster, Item scroll)
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

				CustomUtility.ApplySimpleSpellEffect(m, "Calme toi!", AptitudeColor.Musique, SpellEffectType.Malus);
				m.Combatant = null;
				m.Warmode = false;

				if (m is BaseCreature && !((BaseCreature)m).BardPacified)
				{
					var duration = TimeSpan.FromSeconds(30.0);
					var bc = (BaseCreature)m;
					bc.Pacify(Caster, DateTime.UtcNow + duration);
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private CalmeToiSpell m_Owner;

			public InternalTarget(CalmeToiSpell owner)
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