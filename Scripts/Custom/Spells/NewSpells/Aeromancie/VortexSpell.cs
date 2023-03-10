using System;
using System.Collections;
using Server.Targeting;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class VortexSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Vortex", "Vas Hur Corp Por",
				SpellCircle.Eighth,
				233,
				9042,
				false,
				Reagent.Nightshade,
				Reagent.Garlic,
				Reagent.Bloodmoss
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public VortexSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return true; } }

		private Timer m_Timer;

		public void Target(IPoint3D o)
		{
			var p = o;

			if (o is Mobile)
				p = ((Mobile)o).Location;

			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (SpellHelper.CheckTown(p, Caster) && CheckSequence())
			{
				var duration = GetDurationForSpellvortex(0.02);

				var endtime = DateTime.Now + duration;

				Effects.SendLocationEffect(new Point3D(p), Caster.Map, 0x37CC, (int)(Caster.Skills[SkillName.Magery].Value * 1.5));

				m_Timer = new VortexTimer(Caster, endtime, p, m_Timer, this);
				m_Timer.Start();
			}

			FinishSequence();
		}

		private class VortexTimer : Timer
		{
			private Mobile m_caster;
			private DateTime ending;
			private IPoint3D loc;
			private Timer m_Timer;
			private Spell m_Spell;

			public VortexTimer(Mobile caster, DateTime endtime, IPoint3D p, Timer timer, Spell spell) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
			{
				m_caster = caster;
				ending = endtime;
				loc = p;
				m_Timer = timer;
				m_Spell = spell;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= ending)
					Stop();
				else if (!m_caster.Alive)
					Stop();
				else
				{
					if (loc is Item)
						loc = ((Item)loc).GetWorldLocation();

					var targets = new ArrayList();

					var map = m_caster.Map;

					if (map != null)
					{
						IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(loc), (int)SpellHelper.AdjustValue(m_caster, 1 + m_caster.Skills[SkillName.Magery].Base / 25, Aptitude.Aeromancie));

						foreach (Mobile m in eable)
							if (m_caster != m && SpellHelper.ValidIndirectTarget(m_caster, m, true) && m_caster.CanBeHarmful(m, false) && m_caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_caster, m))
								targets.Add(m);

						eable.Free();
					}

					if (targets.Count > 0)
					{
						m_caster.PlaySound(0x29);

						for (var i = 0; i < targets.Count; ++i)
						{
							var m = (Mobile)targets[i];

							double chance = 60;

							if (chance > Utility.Random(0, 100))
							{
								Disturb(m);

								double damage = new VortexSpell(m_caster, null).GetNewAosDamage(null, 6, 4, 6, true);

								damage = (int)SpellHelper.AdjustValue(m_caster, damage, Aptitude.Aeromancie);

								m_caster.DoHarmful(m);

								AOS.Damage(m, m_caster, (int)damage, 0, 0, 0, 0, 100);

								m.BoltEffect(0);
							}
						}
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private VortexSpell m_Owner;

			public InternalTarget(VortexSpell owner) : base(12, true, TargetFlags.Harmful)
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