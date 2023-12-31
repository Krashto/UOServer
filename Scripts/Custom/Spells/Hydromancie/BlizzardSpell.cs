using System;
using System.Collections;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Network;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class BlizzardSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Blizzard", "[Blizzard]",
				SpellCircle.Fifth,
				233,
				9012,
				Reagent.EssenceHydromancie
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Meditation; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public BlizzardSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override bool DelayedDamage { get { return !Core.AOS; } }

		public override void OnCast()
		{
			var m_target = new ArrayList();

			if (SpellHelper.CheckTown(Caster, Caster) && CheckSequence())
			{
				m_target.Clear();

				var map = Caster.Map;

				var range = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 30, Aptitude.Hydromancie);

				ExplodeFX.Snow.CreateInstance(Caster, Caster.Map, range).Send();

				if (map != null)
					foreach (var m in Caster.GetMobilesInRange(range))
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(Caster, m))
							m_target.Add(m);

				for (var i = 0; i < m_target.Count; ++i)
				{
					var m = (Mobile)m_target[i];

					if (Caster.CanSee(m))
					{
						Timer t = new InternalTimer(this, m);
						m_Timers[m] = t;
						t.Start();

						if (!IndomptableSpell.IsActive(m))
						{
							m.SendSpeedControl(SpeedControlType.WalkSpeed);

							Disturb(m);

							double damage = GetNewAosDamage(null, 3, 2, 3, true);

							if (AvatarDuFroidSpell.IsActive(m))
								damage *= 1.2;

							Caster.DoHarmful(m);

							SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);

							CustomUtility.ApplySimpleSpellEffect(m, "Blizzard", AptitudeColor.Hydromancie, SpellEffectType.Malus);

							m.BoltEffect(0);
						}
					}
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				CustomUtility.ApplySimpleSpellEffect(m, "Blizzard", AptitudeColor.Hydromancie, SpellSequenceType.End, SpellEffectType.Malus);
			}
		}

		private class InternalTimer : Timer
		{
			private BlizzardSpell m_Owner;
			private readonly Mobile m_Mobile;
			private int m_Count;
			private readonly int m_MaxCount;

			public InternalTimer(BlizzardSpell owner, Mobile m) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2.0))
			{
				m_Owner = owner;
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;

				m_MaxCount = 5;
			}

			protected override void OnTick()
			{
				if (!m_Mobile.Alive || m_Mobile.Deleted || ++m_Count == m_MaxCount)
				{
					m_Owner.Deactivate(m_Mobile);
					Stop();
				}
				else
				{
					ExplodeFX.Snow.CreateInstance(m_Mobile, m_Mobile.Map, 1).Send();

					var stamReduction = 10.0;

					if (AvatarDuFroidSpell.IsActive(m_Mobile))
						stamReduction *= 1.2;

					m_Mobile.Stam -= (int)stamReduction;
					m_Mobile.Hits -= 1;
				}
			}
		}
	}
}