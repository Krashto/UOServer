using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Chasseur;
using Server.Items;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class ContratResoluSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Contrat Resolu", "An Por Choma",
				SpellCircle.Fifth,
				218,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ContratResoluSpell(Mobile caster, Item scroll)
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

				if (BleedAttack.IsBleeding(m) && (m.Frozen && m.CantWalk && m.Paralyzed) && MarquerSpell.IsActive(m))
				{
					Caster.MoveToWorld(m.Location, m.Map);
					m.Damage(100);

					ExplodeFX.Blood.CreateInstance(Caster, Caster.Map, 5).Send();

					m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					m.PlaySound(508);
				}
				else
				{
					Caster.SendMessage("La cible doit être paralysé et doit saigner et doit avoir été marqué par le sort 'Marquer' avant de pouvoir être touchée par ce sort.");
				}
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private ContratResoluSpell m_Owner;

			public InternalTarget(ContratResoluSpell owner)
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