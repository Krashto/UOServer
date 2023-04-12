using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class MentorSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Mentor", "[Mentor]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceDefenseur
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MentorSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (IsActive(Caster))
			{
				Caster.SendMessage("Ce sort est déjà actif");
			}
			else if (CheckSequence())
			{
				var value = 0;

				if (Caster is CustomPlayerMobile pm)
					value += pm.Aptitudes.Defenseur * 10;

				m_Table[Caster] = value;
			}

			FinishSequence();
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			if (m_Table.ContainsKey(m))
				m_Table.Remove(m);
		}

		public static int GetValue(Mobile m)
		{
			return m_Table.ContainsKey(m) ? (int)m_Table[m] : 0;
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		private class InternalTarget : Target
		{
			private MentorSpell m_Owner;

			public InternalTarget(MentorSpell owner)
				: base(12, false, TargetFlags.Beneficial)
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