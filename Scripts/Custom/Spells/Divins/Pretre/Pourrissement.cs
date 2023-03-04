using System;
using System.Collections;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Custom.Aptitudes;

namespace Server.Custom.Spells.Divins.Pretre
{
	public class PourrissementSpell : ReligiousSpell
	{
		public static Hashtable m_Timers = new Hashtable();
		public static Hashtable m_PourrissementTable = new Hashtable();
		public static Hashtable m_PourrissementRegistry = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Pourrissement", "Thur Ghua Desu",
				SpellCircle.Eighth,
				212,
				9041
			);

		public override int RequiredAptitudeValue { get { return 11; } }
		public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

		public PourrissementSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (Caster is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)Caster;

				if (Religion.GetGodGroupName(pm) != CiliasGroups.Xuan)
				{
					pm.SendMessage("Vous devez prier un des dieux de Xuan pour pouvoir utiliser ce sort.");
					FinishSequence();
					return;
				}
			}

			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return false; } }

		public void Target(Corpse corpse)
		{
			if (corpse.PourrissementSpellDone)
				Caster.SendMessage("Ce sort a déjà été utilisé sur ce corps.");

			if (!Caster.CanSee(corpse))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (!(corpse is Corpse))
				Caster.SendMessage("Vous devez cibler un cadavre.");
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, corpse);

				DoEffect(Caster);

				corpse.PourrissementSpellDone = true;
				corpse.Hue = 0x455;

				if (!corpse.Name.Contains(" [Pourri]"))
					corpse.Name = corpse.Name + " [Pourri]";
			}

			FinishSequence();
		}

		public static void DoEffect(Mobile caster)
		{
			var m_target = new ArrayList();

			var map = caster.Map;

			if (map != null)
				foreach (var m in caster.GetMobilesInRange((int)SpellHelper.AdjustValue(caster, 1 + caster.Skills[SkillName.Magery].Value / 15, NAptitude.MagieAncestrale)))
					if (caster != m && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false) && (!Core.AOS || caster.InLOS(m)))
						m_target.Add(m);

			for (var i = 0; i < m_target.Count; ++i)
			{
				var targ = (Mobile)m_target[i];

				if (caster.CanSee(targ))
				{
					caster.DoHarmful(targ);

					targ.Freeze(TimeSpan.FromSeconds(0.25));

					double damage = new PourrissementSpell(caster, null).GetNewAosDamage(targ, 15, 4, 5, true);

					damage = (int)SpellHelper.AdjustValue(caster, damage, NAptitude.MagieAncestrale);

					AOS.Damage(targ, caster, (int)damage, 100, 0, 0, 0, 0);

					targ.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);

					targ.FixedParticles(14000, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					targ.PlaySound(1099);

				}
			}
		}

		public void Target(BaseCreature creature)
		{
			if (!Caster.CanSee(creature))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (!(creature is BaseCreature))
				Caster.SendMessage("Vous devez cibler une creature vivante.");
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, creature);

				StopTimer(creature);

				var duration = GetDurationForSpell(0.5);

				m_PourrissementTable[creature] = -1;
				m_PourrissementRegistry[creature] = Caster;

				Timer t = new PourrissementTimer(creature, DateTime.Now + duration);
				m_Timers[creature] = t;
				t.Start();
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private PourrissementSpell m_Owner;

			public InternalTarget(PourrissementSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Corpse)
					m_Owner.Target((Corpse)o);
				else if (o is BaseCreature)
					m_Owner.Target((BaseCreature)o);
				else
					from.SendMessage("Vous devez cibler un cadavre ou une créature vivante.");
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}

		public void StopTimer(Mobile m)
		{
			var t = (Timer)m_Timers[m];

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_PourrissementTable.Remove(m);
				m_PourrissementRegistry.Remove(m);

				m.FixedParticles(14120, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(484);
			}
		}

		public class PourrissementTimer : Timer
		{
			private Mobile m_target;
			private DateTime endtime;

			public PourrissementTimer(Mobile target, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_target = target;
				endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= endtime && m_PourrissementTable.Contains(m_target) || m_target == null || m_target.Deleted || !m_target.Alive)
				{
					m_PourrissementTable.Remove(m_target);
					m_PourrissementRegistry.Remove(m_target);
					m_Timers.Remove(m_target);

					m_target.FixedParticles(14120, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					m_target.PlaySound(484);

					Stop();
				}
			}
		}
	}
}