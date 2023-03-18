using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.SkillHandlers;
using Server.Items;
using System.Collections;
using System;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class DesorienterSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Désorienter", "Désorienter",
				SpellCircle.Second,
				203,
				9041,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public DesorienterSpell(Mobile caster, Item scroll)
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

				ArrayList mods = new ArrayList();

				double discord = Caster.Skills[SkillName.Discordance].Value;

				var effect = (int)Math.Max(-28.0, (discord / -4.0));

				if (BaseInstrument.GetBaseDifficulty(m) >= 160.0)
				{
					effect /= 2;
				}

				var scalar = (double)effect / 100;

				mods.Add(new ResistanceMod(ResistanceType.Physical, effect));
				mods.Add(new ResistanceMod(ResistanceType.Fire, effect));
				mods.Add(new ResistanceMod(ResistanceType.Cold, effect));
				mods.Add(new ResistanceMod(ResistanceType.Poison, effect));
				mods.Add(new ResistanceMod(ResistanceType.Energy, effect));

				for (int j = 0; j < m.Skills.Length; ++j)
				{
					if (m.Skills[j].Value > 0)
						mods.Add(new DefaultSkillMod((SkillName)j, true, m.Skills[j].Value * scalar));
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private DesorienterSpell m_Owner;

			public InternalTarget(DesorienterSpell owner)
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