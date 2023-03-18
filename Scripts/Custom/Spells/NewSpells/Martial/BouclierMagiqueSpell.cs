using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Martial
{
	public class BouclierMagiqueSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();

		private static readonly SpellInfo m_Info = new SpellInfo(
			"Bouclier magique", "Bouclier magique",
			SpellCircle.Fifth,
			242,
			9012,
			Reagent.Garlic,
			Reagent.MandrakeRoot,
			Reagent.SpidersSilk);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Martial }; } }
		public override SkillName CastSkill { get { return SkillName.Tactics; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public BouclierMagiqueSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Mobile targ = Caster;

				targ.PlaySound(0x1E9);
				targ.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);

				m_Table[Caster] = Caster;
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}
	}
}
