using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class LumiereSacreeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Lumiere sacree", "[Lumiere sacree]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceGuerison
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public LumiereSacreeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				if (p is Item)
					p = ((Item)p).GetWorldLocation();

				var bTargets = new ArrayList();
				var hTargets = new ArrayList();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 2 + Caster.Skills[CastSkill].Value / 50, Aptitude.Guerison));

					foreach (Mobile m in eable)
						if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeBeneficial(m, false) && CustomPlayerMobile.IsInEquipe(Caster, m))
							bTargets.Add(m);

					eable.Free();

					eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 2 + Caster.Skills[CastSkill].Value / 50, Aptitude.Guerison));

					foreach (Mobile m in eable)
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(Caster, m))
							hTargets.Add(m);

					eable.Free();
				}

				if (bTargets.Count > 0)
				{
					for (var i = 0; i < bTargets.Count; ++i)
					{
						double toHeal;

						var m = (Mobile)bTargets[i];

						toHeal = Caster.Skills[CastSkill].Value * 0.1 + Caster.Skills[DamageSkill].Value * 0.1;
						toHeal += Utility.Random(1, 5);

						toHeal = SpellHelper.AdjustValue(Caster, toHeal, Aptitude.Guerison);

						if (InquisitionSpell.IsActive(Caster))
							toHeal *= 1.5;

						m.Heal((int)toHeal);

						CustomUtility.ApplySimpleSpellEffect(m, "Lumiere Sacree", AptitudeColor.Guerison, SpellEffectType.Heal);

						m.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
						m.PlaySound(0x1F2);
					}
				}

				if (hTargets.Count > 0)
				{
					for (var i = 0; i < hTargets.Count; ++i)
					{
						var m = (Mobile)hTargets[i];

						SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

						double damage = Utility.RandomMinMax(14, 20);

						damage = SpellHelper.AdjustValue(Caster, damage, Aptitude.Guerison);

						if (CheckResisted(m))
						{
							damage *= 0.75;
							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						damage *= GetDamageScalar(m);

						CustomUtility.ApplySimpleSpellEffect(m, "Lumiere sacree", AptitudeColor.Guerison, SpellEffectType.Damage);

						m.BoltEffect(0);

						SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
					}
				}
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private LumiereSacreeSpell m_Owner;

			public InternalTarget(LumiereSacreeSpell owner)
				: base(12, false, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as IPoint3D;

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