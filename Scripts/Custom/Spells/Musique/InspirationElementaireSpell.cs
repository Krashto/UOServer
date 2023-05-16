using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Musique
{
	public class InspirationElementaireSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();
		private static Hashtable m_Mod = new Hashtable();
		private static Hashtable m_Weapon = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Inspiration Elementaire", "[Inspiration Elementaire]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceMusique
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public InspirationElementaireSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(CustomPlayerMobile pm)
		{
			if (!Caster.CanSee(pm))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (IsActive(pm))
				Deactivate(pm);
			else if (CheckBSequence(pm))
			{
				var source = Caster;

				SpellHelper.Turn(source, pm);

				if (pm.Weapon != null && !(pm.Weapon is Fists) && pm.Weapon is BaseWeapon weap)
				{
					var duration = GetDurationForSpell(30);

					Timer t = new InternalTimer(pm, DateTime.Now + duration);
					m_Timers[pm] = t;
					t.Start();

					var rnd = Utility.Random(0, 4);
					var mod = string.Empty;

					switch (rnd)
					{
						default:
						case 0: { mod = "HitFireball"; weap.WeaponAttributes.HitFireball = 30; break; }
						case 1: { mod = "HitLightning"; weap.WeaponAttributes.HitLightning = 30; break; }
						case 2: { mod = "HitHarm"; weap.WeaponAttributes.HitHarm = 30; break; }
						case 3: { mod = "HitMagicArrow"; weap.WeaponAttributes.HitMagicArrow = 30; break; }
						case 4: { mod = "HitDispel"; weap.WeaponAttributes.HitDispel = 30; break; }
					}

					m_Mod[pm] = mod;
					m_Weapon[pm] = weap;

					CustomUtility.ApplySimpleSpellEffect(pm, "Inspiration Elementaire", duration, AptitudeColor.Musique);
				}
				else
					Caster.SendMessage("Votre cible doit avoir une arme en main pour que l'effet s'applique.");
			}

			FinishSequence();
		}


		public static bool IsActive(Mobile m)
		{
			return m_Weapon.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;
			var mod = m_Mod[m] as string;
			var weap = m_Weapon[m] as BaseWeapon;

			if (t != null && mod != null && weap != null)
			{
				t.Stop();

				weap.WeaponAttributes.HitFireball = 0;
				weap.WeaponAttributes.HitLightning = 0;
				weap.WeaponAttributes.HitHarm = 0;
				weap.WeaponAttributes.HitMagicArrow = 0;
				weap.WeaponAttributes.HitDispel = 0;

				m_Timers.Remove(m);
				m_Mod.Remove(m);
				m_Weapon.Remove(m);

				CustomUtility.ApplySimpleSpellEffect(m, "Inspiration Elementaire", AptitudeColor.Musique, SpellEffectType.Bonus);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_EndTime;

			public InternalTimer(Mobile m, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Mobile = m;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}

		private class InternalTarget : Target
		{
			private InspirationElementaireSpell m_Owner;

			public InternalTarget(InspirationElementaireSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is CustomPlayerMobile)
					m_Owner.Target((CustomPlayerMobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}