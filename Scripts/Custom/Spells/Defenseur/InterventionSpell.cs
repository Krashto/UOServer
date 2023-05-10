using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class InterventionSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Intervention", "[Intervention]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceDefenseur
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public InterventionSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);

		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void Desactive(Mobile m)
		{
			if (m == null)
				return;

			var mob = m_Table[m] as Mobile;

			if (mob != null)
			{
				m_Table.Remove(m);
				CustomUtility.ApplySimpleSpellEffect(m, "Intervention", AptitudeColor.Defenseur, SpellSequenceType.End);
			}
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckBSequence(m))
			{
				var source = Caster;

				SpellHelper.Turn(source, m);

				m_Table[Caster] = Caster;
				CustomUtility.ApplySimpleSpellEffect(m, "Intervention", AptitudeColor.Defenseur, SpellEffectType.Bonus);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private InterventionSpell m_Owner;

			public InternalTarget(InterventionSpell owner)
				: base(9, false, TargetFlags.Beneficial)
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