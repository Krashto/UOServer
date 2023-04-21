using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using System;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class MiracleSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Miracle", "[Miracle]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceDefenseur
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MiracleSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
			Caster.SendMessage("Cibler le corps d'un joueur mort pour le ressuciter");
		}

		public void Target(Corpse c)
		{
			var m = c.Owner;

			if (!Caster.CanSee(c))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (m == Caster)
				Caster.SendLocalizedMessage(501039); // Thou can not resurrect thyself.
			else if (!Caster.InRange(c, 5))
				Caster.SendLocalizedMessage(501042); // Target is not close enough.
			else if (!m.Player)
				Caster.SendLocalizedMessage(501043); // Target is not a being.
			else if (CheckSequence() && m != null)
			{
				var pm = m as CustomPlayerMobile;

				if (pm != null && Caster is CustomPlayerMobile && !pm.Alive)
				{
					SpellHelper.Turn(Caster, pm);

					pm.PlaySound(0x214);
					pm.FixedEffect(0x376A, 10, 16);

					pm.Location = c.Location;
					pm.Frozen = false;
					pm.CantWalk = false;
					pm.Paralyzed = false;

					pm.Direction = c.Direction;
					pm.Animate(21, 5, 1, false, false, 0);

					pm.Resurrect();

					CustomUtility.ApplySimpleSpellEffect(pm, "Miracle", AptitudeColor.Defenseur, SpellEffectType.Heal);

					if (c != null)
					{
						var list = new ArrayList();

						foreach (var item in c.Items)
							list.Add(item);

						foreach (Item item in list)
						{
							if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
								item.Delete();

							if (item is BaseRaceGumps || c.EquipItems.Contains(item))
								if (!m.EquipItem(item))
									m.AddToBackpack(item);
								else
									m.AddToBackpack(item);
						}
					}

					pm.CheckStatTimers();
				}
				else
					Caster.SendMessage("Vous devez cibler le corps d'un joueur mort.");
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MiracleSpell m_Owner;

			public InternalTarget(MiracleSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Corpse)
					m_Owner.Target((Corpse)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}