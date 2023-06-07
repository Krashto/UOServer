using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class ToucheAbsorbantSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Touche absorbant", "[Touche absorbant]",
				SpellCircle.Seventh,
				203,
				9031,
				Reagent.EssenceNecromancie
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ToucheAbsorbantSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Corpse c)
		{
			if (CheckSequence())
			{
				if (c != null && c.InBones)
					Caster.SendMessage("Vous ne pouvez pas vous soigner à partir de ce corps.");
				else if (c != null && c.Owner != null)
				{
					var min = 0;
					var max = 0;

					if (c.Owner is CustomPlayerMobile)
					{
						min = 5;
						max = 10;
					}
					else if (c.Owner is BaseCreature)
					{
						min = 20;
						max = 30;
					}

					var toHeal = SpellHelper.AdjustValue(Caster, Utility.RandomMinMax(min, max), Aptitude.Necromancie);
					Caster.Heal((int)toHeal);

					CustomUtility.ApplySimpleSpellEffect(Caster, "Touche absorbant", AptitudeColor.Necromancie, SpellEffectType.Heal);

					c.TurnToBones();
				}
				else
					Caster.SendMessage("Le corps que vous ciblez ne peut être réanimé !");
			}

			FinishSequence();
		}
		public class InternalTarget : Target
		{
			private ToucheAbsorbantSpell m_Owner;

			public InternalTarget(ToucheAbsorbantSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Corpse)
				{
					m_Owner.Target((Corpse)o);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}