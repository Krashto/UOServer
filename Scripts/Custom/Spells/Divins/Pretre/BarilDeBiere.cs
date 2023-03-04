using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Items;
using Server.Custom.Aptitudes;

namespace Server.Custom.Spells.Divins.Pretre
{
	public class BarilDeBiereSpell : ReligiousSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"BarilDeBiere", "Gebo Sowi Fehu",
				SpellCircle.Third,
				212,
				9041
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

		public BarilDeBiereSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (Caster is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)Caster;

				if (Religion.GetGodGroupName(pm) != CiliasGroups.Zhel)
				{
					pm.SendMessage("Vous devez prier un des dieux de Zhel pour pouvoir utiliser ce sort.");
					FinishSequence();
					return;
				}
			}

			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return false; } }

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var ItemID = 3703;
				var name = "Baril de Bière";
				var hue = 0;

				var type = TotemType.BarilDeBiere;
				var delete = DateTime.Now + GetDurationForSpell(0.5);
				var range = 1 + (int)(Caster.Skills[CastSkill].Value / 10);
				var bonus = 0.05 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 800);//5 à 30%

				var effectid = 14154;
				var effectspeed = 10;
				var effectduration = 20;
				var layer = EffectLayer.Waist;
				var soundid = 48;

				var totem = new Totem(ItemID, name, hue, range, type, delete, Caster, bonus, effectid, effectspeed, effectduration, layer, soundid);

				if (totem != null)
				{
					totem.MoveToWorld(new Point3D(p), Caster.Map);
					totem.FixedParticles(effectid, effectspeed, effectduration, 5005, hue, 0, layer);
					totem.PlaySound(soundid);

					new TotemDeGuerisonTimer(totem).Start();
				}
			}

			FinishSequence();
		}

		public class TotemDeGuerisonTimer : Timer
		{
			private Totem m_BaseTotem;

			public TotemDeGuerisonTimer(Totem totem)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(5))
			{
				m_BaseTotem = totem;
			}

			protected override void OnTick()
			{
				if (m_BaseTotem == null || m_BaseTotem.Deleted || m_BaseTotem.Caster == null || m_BaseTotem.Caster.Deleted || !m_BaseTotem.Caster.Alive)
				{
					Stop();
					m_BaseTotem.Delete();
					return;
				}

				foreach (var m in m_BaseTotem.GetMobilesInRange(1 + (int)(m_BaseTotem.Caster.Skills[SkillName.SpiritSpeak].Base / 5)))
					if (m != null && m.Alive && m.CanSee(m_BaseTotem))
					{
						var toHeal = 5 + (int)(m_BaseTotem.Caster.Skills[SkillName.SpiritSpeak].Base / 5);
						m.Hits += toHeal;
						m.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
						m.PlaySound(0x1F2);
					}
			}
		}

		private class InternalTarget : Target
		{
			private BarilDeBiereSpell m_Owner;

			public InternalTarget(BarilDeBiereSpell owner)
				: base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D)
					m_Owner.Target((IPoint3D)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}