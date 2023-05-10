using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using System;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class RugissementSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Rugissement", "[Rugissement]",
				SpellCircle.Second,
				203,
				9031,
				Reagent.EssenceChasseur
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public override TimeSpan CastDelayBase => TimeSpan.Zero;
		public override double CastDelayFastScalar => 0;
		public override double CastDelaySecondsPerTick => 1;
		public override TimeSpan CastDelayMinimum => TimeSpan.Zero;

		public override int CastRecoveryBase => 0;
		public override int CastRecoveryFastScalar => 0;
		public override int CastRecoveryPerSecond => 1;
		public override int CastRecoveryMinimum => 0;

		public RugissementSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				if (CompagnonAnimalSpell.Table.Contains(Caster))
				{
					var bc = CompagnonAnimalSpell.Table[Caster] as BaseCreature;

					if (bc != null)
					{
						var targets = bc.GetMobilesInRange(5);

						foreach (var targ in targets)
						{
							if (CustomPlayerMobile.IsInEquipe(Caster, targ))
								continue;

							if (targ is BaseCreature creature && creature.Controlled && CustomPlayerMobile.IsInEquipe(Caster, creature.ControlMaster))
								continue;

							targ.Combatant = bc;
							targ.Emote($"*Est provoqué{(targ.Female ? "e" : "")} par {Caster.Name}*");
							if (Caster is CustomPlayerMobile pm)
							{
								targ.Stam -= Math.Min(2 * pm.Aptitudes[Aptitude.Chasseur], targ.Stam);
								targ.Mana -= Math.Min(2 * pm.Aptitudes[Aptitude.Chasseur], targ.Mana);
							}
							CustomUtility.ApplySimpleSpellEffect(targ, "Rugissement", AptitudeColor.Chasseur, SpellEffectType.Taunt);
							bc.Combatant = targ;
							bc.Emote($"*Provoque {targ.Name}*");
						}
					}
				}
				else
					Caster.SendMessage("Vous n'avez pas de compagnon avec vous.");
			}

			FinishSequence();
		}
	}
}