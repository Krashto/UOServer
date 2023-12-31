using System;
using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class PieuxDeGlaceSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Pieux de glace", "[Pieux de glace]",
				SpellCircle.Seventh,
				239,
				9011,
				Reagent.EssenceHydromancie
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Meditation; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public PieuxDeGlaceSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile target)
		{
			if (!Caster.CanSee(target))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(target))
			{
				var targets = new ArrayList();

				var map = target.Map;

				if (map != null)
				{
					var range = (int)(Caster.Skills[CastSkill].Value / 50 + Caster.Skills[DamageSkill].Value / 50);

					IPooledEnumerable eable = map.GetMobilesInRange(target.Location, range);

					foreach (Mobile m in eable)
					{
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
							targets.Add(m);
					}

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var source = target;

						SpellHelper.Turn(source, m);

						Disturb(m);

						SpellHelper.CheckReflect((int)Circle, ref source, ref m);

						double damage = GetNewAosDamage(m, 4, 1, 6, true);

						if (AvatarDuFroidSpell.IsActive(m))
							damage *= 1.2;

						if (CheckResisted(m))
						{
							damage *= 0.75;
							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

						ExplodeFX.Ice.CreateInstance(target.Location, target.Map, 1).Send();
						CustomUtility.ApplySimpleSpellEffect(m, "Pieux de glace", AptitudeColor.Hydromancie, SpellEffectType.Damage);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private PieuxDeGlaceSpell m_Owner;

			public InternalTarget(PieuxDeGlaceSpell owner)
				: base(12, true, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var m = o as Mobile;

				if (m != null)
					m_Owner.Target(m);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
