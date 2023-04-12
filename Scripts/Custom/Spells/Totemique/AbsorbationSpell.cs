using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Targeting;
using System;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Totemique
{
    public class AbsorbationSpell : Spell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
				"Absorbation mmmmmmmh", "[Absorbation mmmmmmmh]",
				SpellCircle.Eighth,
				269,
				9070,
				Reagent.EssenceTotemique
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }
		
		public AbsorbationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(BaseTotem totem)
		{
			if (!Caster.CanSee(totem))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(totem))
			{
				if (totem.ControlMaster == Caster)
				{
					Caster.Hits += Math.Min(25, totem.Hits);
					Caster.Stam += Math.Min(25, totem.Stam);
					Caster.Mana += Math.Min(25, totem.Mana);

					ExplodeFX.BloodRain.CreateInstance(Caster, Caster.Map, 3);
					ExplodeFX.BloodRain.CreateInstance(totem.Location, totem.Map, 3);
					totem.Delete();
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
			private AbsorbationSpell m_Owner;

			public InternalTarget(AbsorbationSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is BaseTotem)
					m_Owner.Target((BaseTotem)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
