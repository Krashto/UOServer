using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using System;
using Server.Custom.Spells.Musique;
using Server.Engines.Quests;

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

		public override int RequiredAptitudeValue { get { return 4; } }
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

				if (m is BaseCreature bc)
				{
					if (bc.BardPacified)
						Caster.SendMessage("Vous ne pouvez pas calmer une créature déjà calmée.");
					else if (bc.Level >= 11)
						Caster.SendMessage("Vous ne pouvez pas calmer un mini boss ou un boss.");
					else
					{
						double diff = MusicSpellHelper.GetBaseDifficulty(bc) - 10.0;
						double music = Caster.Skills[SkillName.Musicianship].Value;

						if (music > 80.0)
						{
							diff -= (music - 80.0) * 0.5;
						}

						if (!Caster.CheckTargetSkill(SkillName.Musicianship, bc, diff - 25.0, diff + 25.0))
						{
							Caster.SendLocalizedMessage(1049531); // You attempt to calm your target, but fail.
							MusicSpellHelper.PlayInstrumentBadly(Caster);
						}
						else
						{
							MusicSpellHelper.PlayInstrumentWell(Caster);

							Caster.SendLocalizedMessage(1049532); // You play hypnotic music, calming your target.

							double seconds = 100 - (diff / 1.5);

							if (seconds > 120)
							{
								seconds = 120;
							}
							else if (seconds < 10)
							{
								seconds = 10;
							}

							bc.Pacify(Caster, DateTime.UtcNow + TimeSpan.FromSeconds(seconds));
						}
					}
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