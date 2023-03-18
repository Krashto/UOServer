using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class MentorSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Mentor", "Mentor",
				SpellCircle.Second,
				203,
				9041,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.SulfurousAsh
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

		public static void Desactivate(Mobile m)
		{
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
	}
}