using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using Server.Custom.Spells.Musique;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Musique
{
	public class DefiSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Defi", "[Defi]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceMusique
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public DefiSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalFirstTarget(this);
		}

		private static Hashtable m_Table = new Hashtable();
		public void FirstTarget(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (!(m is BaseCreature bc))
				Caster.SendMessage("Votre première cible doit être une créature.");
			else if (CheckSequence())
			{
				var source = Caster;
				SpellHelper.Turn(source, m);

				if (bc.Level >= 11)
					Caster.SendMessage("Vous ne pouvez pas calmer un mini boss ou un boss.");
				else
				{
					m_Table[Caster] = bc;
					Caster.Target = new InternalSecondTarget(this);
				}

				CustomUtility.ApplySimpleSpellEffect(m, "Defi", AptitudeColor.Musique, SpellEffectType.Malus);
			}

			FinishSequence();
		}

		public void SecondTarget(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else
			{
				var bc1 = m_Table[Caster] as BaseCreature;

				if (bc1 != null)
				{
					m_Table.Remove(Caster);

					double diff;
					double music;

					if (m is BaseCreature bc2)
					{
						diff = MusicSpellHelper.GetBaseDifficulty(bc2) - 5.0;
						music = Caster.Skills[SkillName.Musicianship].Value;
					}
					else if (m is CustomPlayerMobile pm)
					{
						diff = pm.Skills[SkillName.MagicResist].Value - 5.0;
						music = Caster.Skills[SkillName.Musicianship].Value;
					}
					else
					{
						diff = 100;
						music = 0;
					}

					if (music > 80.0)
						diff -= (music - 80.0) * 0.5;

					if ((Caster.CanBeHarmful(m, true, false, true) && Caster.CanBeHarmful(m, true, false, true)))
					{
						if (!Caster.CheckTargetSkill(SkillName.Musicianship, m, diff - 25.0, diff + 25.0))
						{
							Caster.SendLocalizedMessage(501599); // Your music fails to incite enough anger.
							MusicSpellHelper.PlayInstrumentBadly(Caster);
						}
						else
						{
							Caster.SendLocalizedMessage(501602); // Your music succeeds, as you start a fight.
							MusicSpellHelper.PlayInstrumentWell(Caster);
							bc1.Provoke(Caster, m, true);
							CustomUtility.ApplySimpleSpellEffect(m, "Defi", AptitudeColor.Musique, SpellEffectType.Malus);
						}
					}
				}
			}

			FinishSequence();
		}

		private class InternalFirstTarget : Target
		{
			private DefiSpell m_Owner;

			public InternalFirstTarget(DefiSpell owner)
				: base(12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.FirstTarget((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}

		private class InternalSecondTarget : Target
		{
			private DefiSpell m_Owner;

			public InternalSecondTarget(DefiSpell owner)
				: base(12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.SecondTarget((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}