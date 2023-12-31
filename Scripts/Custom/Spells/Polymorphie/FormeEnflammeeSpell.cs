using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using VitaNex.FX;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class FormeEnflammeeSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Forme enflammee", "[Forme enflammee]",
				SpellCircle.Sixth,
				269,
				9050,
				Reagent.EssencePolymorphie
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Polymorphie }; } }
		public override SkillName CastSkill { get { return SkillName.Anatomy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FormeEnflammeeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				Deactivate(Caster);
			else
				BaseTransformationSpell.DeactivateAllTransformation(Caster);

			if (CheckSequence())
			{
				var duration = GetDurationForSpell(30, 2);

				Caster.BodyMod = 15;
				Caster.HueMod = 0;

				Timer t = new InternalTimer(Caster, this, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Forme enflammee", duration, AptitudeColor.Polymorphie);
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);

				m.BodyMod = 0;
				m.HueMod = -1;

				CustomUtility.ApplySimpleSpellEffect(m, "Forme enflammee", AptitudeColor.Polymorphie, SpellSequenceType.End);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Caster;
			FormeEnflammeeSpell m_Owner;
			private DateTime m_EndTime;

			public InternalTimer(Mobile from, FormeEnflammeeSpell owner, DateTime endTime)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Caster = from;
				m_Owner = owner;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				var targets = new ArrayList();

				var map = m_Caster.Map;

				if (m_Caster.Mana < 2)
				{
					m_Caster.SendMessage("Votre forme ne fait plus effet, car vous n'avez plus suffisamment de mana.");
					return;
				}

				m_Caster.Mana -= 2;

				if (map != null)
				{
					var range = 2;

					IPooledEnumerable eable = map.GetMobilesInRange(m_Caster.Location, range);

					ExplodeFX.Fire.CreateInstance(m_Caster, m_Caster.Map, range).Send();

					foreach (Mobile m in eable)
						if (m_Caster != m && SpellHelper.ValidIndirectTarget(m_Caster, m) && m_Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var source = m_Caster;

						SpellHelper.Turn(source, m);

						Disturb(m);

						double damage = m_Owner.GetNewAosDamage(m, 6, 1, 5, true);

						if (m_Owner.CheckResisted(m))
						{
							damage *= 0.75;
							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						source.MovingParticles(m, 0x36D4, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);
						source.PlaySound(0x44B);

						SpellHelper.Damage(m_Owner, m, damage, 0, 100, 0, 0, 0);
					}
				}

				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Caster) || m_Caster == null || m_Caster.Deleted || !m_Caster.Alive)
				{
					Deactivate(m_Caster);
					Stop();
				}
			}
		}
	}
}