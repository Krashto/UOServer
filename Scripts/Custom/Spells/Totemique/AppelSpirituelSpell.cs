using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class AppelSpirituelSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Appel Spirituel", "[Appel Spirituel]",
				SpellCircle.Fifth,
				203,
				9031,
				Reagent.EssenceTotemique
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AppelSpirituelSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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
				ExplodeFX.Smoke.CreateInstance(m, m.Map, 0).Send();
				m.MoveToWorld(new Point3D(1120, 1407, 0), Map.Felucca);
				ExplodeFX.Smoke.CreateInstance(m, m.Map, 0).Send();
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private AppelSpirituelSpell m_Owner;

			public InternalTarget(AppelSpirituelSpell owner)
				: base(12, false, TargetFlags.Beneficial)
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