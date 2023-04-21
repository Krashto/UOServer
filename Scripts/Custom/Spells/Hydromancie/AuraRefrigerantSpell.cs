using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using System;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class AuraRefrigeranteSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Aura refregirante", "[Aura refregirante]",
				SpellCircle.Seventh,
				209,
				9022,
				Reagent.EssenceHydromancie
			);

		public override int RequiredAptitudeValue { get { return 8; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Meditation; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AuraRefrigeranteSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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

				var targets = new ArrayList();

				targets.Add(Caster);

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 2 + Caster.Skills[CastSkill].Value / 50, Aptitude.Hydromancie));

					foreach (Mobile m in eable)
					{
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeBeneficial(m, false) && CustomPlayerMobile.IsInEquipe(Caster, m))
							targets.Add(m);
					}

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						Timer t = new InternalTimer(Caster, m);
						t.Start();

						CustomUtility.ApplySimpleSpellEffect(Caster, "Aura refregirante", AptitudeColor.Hydromancie, SpellEffectType.Heal);
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private AuraRefrigeranteSpell m_Owner;

			public InternalTarget(AuraRefrigeranteSpell owner)
				: base(12, true, TargetFlags.Beneficial)
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

		public class InternalTimer : Timer
		{
			private Mobile m_From;
			private Mobile m_Mobile;
			private int m_Count;
			private readonly int m_MaxCount;
			public InternalTimer(Mobile from, Mobile m) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_From = from;
				m_Mobile = m;

				Priority = TimerPriority.OneSecond;
				m_MaxCount = 5;
			}

			protected override void OnTick()
			{
				if (m_Count >= m_MaxCount || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Stop();
				}
				else
				{
					double toHeal = Math.Max(1, Utility.RandomMinMax(10 + m_Count, (10 + m_Count) * 2));

					if (AvatarDuFroidSpell.IsActive(m_From))
						toHeal *= 1.5;

					m_Mobile.Heal((int)toHeal);

					CustomUtility.ApplySimpleSpellEffect(m_Mobile, "Aura refregirante", AptitudeColor.Hydromancie, SpellEffectType.Heal);

					if (++m_Count >= m_MaxCount)
					{
						CustomUtility.ApplySimpleSpellEffect(m_Mobile, "Aura refregirante", AptitudeColor.Hydromancie, SpellSequenceType.End);
						Stop();
					}
				}
			}
		}
	}
}