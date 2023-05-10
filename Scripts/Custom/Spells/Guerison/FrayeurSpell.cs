using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using Discord;
using Server.Mobiles;
using System;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class FrayeurSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Frayeur", "[Frayeur]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceGuerison
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FrayeurSpell(Mobile caster, Item scroll)
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
				SpellHelper.Turn(Caster, m);

				m.Emote("*A terriblement peur*");

				m.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
				m.PlaySound(0x1E0);

				Disarm.DoEffect(Caster, m);

				Disturb(m);

				var source = Caster;

				SpellHelper.CheckReflect((int)Circle, ref source, ref m);

				double damage = GetNewAosDamage(m, 6, 1, 2, false);

				if (CheckResisted(m))
				{
					damage *= 0.75;

					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				if (Caster is CustomPlayerMobile pm)
				{
					m.Stam -= Math.Min(2 * pm.Aptitudes[Aptitude.Guerison], m.Stam);
					m.Mana -= Math.Min(2 * pm.Aptitudes[Aptitude.Guerison], m.Mana);
				}

				SpellHelper.Damage(this, m, damage, 100, 0, 0, 0, 0);

				CustomUtility.ApplySimpleSpellEffect(m, "Frayeur", AptitudeColor.Guerison, SpellEffectType.Damage);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private FrayeurSpell m_Owner;

			public InternalTarget(FrayeurSpell owner)
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