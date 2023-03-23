using System;
using System.Collections;
using Server.Targeting;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class VortexSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Vortex", "[Vortex]",
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
				var duration = GetDurationForSpell(3);

				var endtime = DateTime.Now + duration;

				Effects.SendLocationEffect(new Point3D(p), Caster.Map, 0x37CC, (int)(Caster.Skills[CastSkill].Value * 1.5));

				m_Timer = new VortexTimer(Caster, this, endtime, p);
				m_Timer.Start();
			}

			FinishSequence();
		}

		private class VortexTimer : Timer
		{
			private Mobile m_Caster;
			private DateTime m_EndTime;
			private VortexSpell m_Owner;
			private IPoint3D m_Loc;

			public VortexTimer(Mobile caster, VortexSpell owner, DateTime endtime, IPoint3D p) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
			{
				m_Caster = caster;
				m_Owner = owner;
				m_EndTime = endtime;
				m_Loc = p;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_EndTime)
					Stop();
				else if (!m_Caster.Alive)
					Stop();
				else
				{
					if (m_Loc is Item)
						m_Loc = ((Item)m_Loc).GetWorldLocation();

					var targets = new ArrayList();

					var map = m_Caster.Map;

					if (map != null)
					{
						var range = (int)SpellHelper.AdjustValue(m_Caster, 1 + m_Caster.Skills[m_Owner.CastSkill].Base / 25, Aptitude.Aeromancie);

						IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(m_Loc), range);

						ExplodeFX.Air.CreateInstance(m_Loc, m_Caster.Map, range).Send();

						foreach (Mobile m in eable)
							if (m_Caster != m && SpellHelper.ValidIndirectTarget(m_Caster, m, true) && m_Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
								targets.Add(m);

						eable.Free();
					}

					if (targets.Count > 0)
					{
						m_Caster.PlaySound(0x29);

						for (var i = 0; i < targets.Count; ++i)
						{
							var m = (Mobile)targets[i];

							double chance = 60;

							if (chance > Utility.Random(0, 100))
							{
								Disturb(m);

								double damage = new VortexSpell(m_Caster, null).GetNewAosDamage(null, 6, 4, 6, true);

								damage = (int)SpellHelper.AdjustValue(m_Caster, damage, Aptitude.Aeromancie);

								m_Caster.DoHarmful(m);

								AOS.Damage(m, m_Caster, (int)damage, 0, 0, 0, 0, 100);

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