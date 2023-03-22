using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Totemique;
using VitaNex.FX;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class ConsommationMortelleSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Aura Exsangue", "Rel Sanct In Ylem",
				SpellCircle.Eighth,
				212,
				9041,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ConsommationMortelleSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(BaseCreature bc)
		{
			if (!Caster.CanSee(bc))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(bc))
			{
				if (bc.ControlMaster == Caster)
				{
					Caster.Hits += Math.Min(25, bc.Hits);
					Caster.Stam += Math.Min(25, bc.Stam);
					Caster.Mana += Math.Min(25, bc.Mana);

					ExplodeFX.BloodRain.CreateInstance(Caster, Caster.Map, 3);
					ExplodeFX.BloodRain.CreateInstance(bc.Location, bc.Map, 3);
					bc.Delete();
				}
				else
				{
					Caster.SendMessage("Vous pouvez seulement absorber vos totems.");
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ConsommationMortelleSpell m_Owner;

			public InternalTarget(ConsommationMortelleSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is BaseCreature)
					m_Owner.Target((BaseCreature)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}