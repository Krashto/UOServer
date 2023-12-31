using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class ArmureOsSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Armure d'os", "[Armure d'os]",
				SpellCircle.Seventh,
				203,
				9031,
				Reagent.EssenceNecromancie
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ArmureOsSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (Caster == m || !(m is CustomPlayerMobile || m is BaseCreature)) // only CustomPlayerMobile and BaseCreature implement blood oath checking
				Caster.SendLocalizedMessage(1060508); // You can't curse that.
			else if (m_OathTable.Contains(Caster))
				Caster.SendLocalizedMessage(1061607); // You are already bonded in a Blood Oath.
			else if (m_OathTable.Contains(m))
				if (m.Player)
					Caster.SendLocalizedMessage(1061608); // That player is already bonded in a Blood Oath.
				else
					Caster.SendLocalizedMessage(1061609); // That creature is already bonded in a Blood Oath.
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				Disturb(m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				/* Temporarily creates a dark pact between the caster and the target.
				 * Any damage dealt by the target to the caster is increased, but the target receives the same amount of damage.
				 * The effect lasts for ((Spirit Speak skill level - target's Resist Magic skill level) / 80 ) + 8 seconds.
				 * 
				 * NOTE: The above algorithm must be fixed point, it should be:
				 * ((ss-rm)/8)+8
				 */

				m_OathTable[Caster] = Caster;
				m_OathTable[m] = Caster;

				var duration = GetDurationForSpell(3);

				CustomUtility.ApplySimpleSpellEffect(Caster, "Armure d'os", duration, AptitudeColor.Necromancie, SpellEffectType.Bonus);
				ExplodeFX.Bone.CreateInstance(Caster, Caster.Map, 1).Send();

				CustomUtility.ApplySimpleSpellEffect(m, "Armure d'os", duration, AptitudeColor.Necromancie, SpellEffectType.Malus);
				ExplodeFX.Bone.CreateInstance(m, m.Map, 1).Send();


				new ExpireTimer(Caster, m, duration).Start();
			}

			FinishSequence();
		}

		public static Hashtable m_OathTable = new Hashtable();

		public static Mobile GetBloodOath(Mobile m)
		{
			if (m == null)
				return null;

			var oath = (Mobile)m_OathTable[m];

			if (oath == m)
				oath = null;

			return oath;
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Caster;
			private Mobile m_Target;
			private DateTime m_End;

			public ExpireTimer(Mobile caster, Mobile target, TimeSpan delay) : base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.0))
			{
				m_Caster = caster;
				m_Target = target;
				m_End = DateTime.Now + delay;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (m_Caster != null)
					ExplodeFX.Bone.CreateInstance(m_Caster, m_Caster.Map, 1).Send();

				if (m_Target != null)
					ExplodeFX.Bone.CreateInstance(m_Target, m_Target.Map, 1).Send();

				if (m_Caster.Deleted || m_Target.Deleted || !m_Caster.Alive || !m_Target.Alive || DateTime.Now >= m_End)
				{
					CustomUtility.ApplySimpleSpellEffect(m_Caster, "Armure d'os", AptitudeColor.Necromancie, SpellSequenceType.End);
					CustomUtility.ApplySimpleSpellEffect(m_Target, "Armure d'os", AptitudeColor.Necromancie, SpellSequenceType.End);

					m_OathTable.Remove(m_Caster);
					m_OathTable.Remove(m_Target);

					Stop();
				}
			}
		}

		private class InternalTarget : Target
		{
			private ArmureOsSpell m_Owner;

			public InternalTarget(ArmureOsSpell owner)
				: base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.Target((Mobile)o);
				else
					from.SendLocalizedMessage(1060508); // You can't curse that.
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}