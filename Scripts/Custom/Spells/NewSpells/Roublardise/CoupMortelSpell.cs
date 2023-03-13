using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class CoupMortelSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Coup mortel", "Vas An Ort",
				SpellCircle.Sixth,
				263,
				9002,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CoupMortelSpell(Mobile caster, Item scroll)
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
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				if (m.Hits <= m.HitsMax * 0.2)
				{
					ExplodeFX.Blood.CreateInstance(m, m.Map, 5);
					m.Kill();
				}
				else
					Caster.SendMessage("La cible doit avoir moins de 20% de sa vie pour être exécutée.");
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private CoupMortelSpell m_Owner;

			public InternalTarget(CoupMortelSpell owner)
				: base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as Mobile;

				if (p != null)
					m_Owner.Target(p);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}