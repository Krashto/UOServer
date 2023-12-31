using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;
using Server.Custom.Spells.NewSpells.Polymorphie;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class ContaminationSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Contamination", "[Contamination]",
				SpellCircle.Third,
				203,
				9051,
				Reagent.EssenceGeomancie
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ContaminationSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				Disturb(m);

				var total = SpellHelper.AdjustValue(Caster, Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value, Aptitude.Geomancie);

				Poison p;

				if (total > 140)
					p = Poison.Greater;
				else if (total > 100)
					p = Poison.Regular;
				else
					p = Poison.Lesser;

				if (!InsensibleSpell.IsActive(m))
				{
					m.ApplyPoison(Caster, p);
					ExplodeFX.Poison.CreateInstance(m, m.Map, 0).Send();
					CustomUtility.ApplySimpleSpellEffect(m, "Contamination", AptitudeColor.Geomancie, SpellEffectType.Damage);
				}

				m.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
				m.PlaySound(0x474);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ContaminationSpell m_Owner;

			public InternalTarget(ContaminationSpell owner) 
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