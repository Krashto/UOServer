using System.Collections;
using Server.Custom.Aptitudes;
using Server.Custom.Spells.NewSpells.Geomancie;
using Server.Mobiles;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Pyromancie
{
	public class SupernovaSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Supernova", "[Supernova]",
				SpellCircle.Eighth,
				233,
				9042,
				false,
				Reagent.EssencePyromancie
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public SupernovaSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var targets = new ArrayList();

				var map = Caster.Map;

				if (map != null)
				{
					var range = (int)(1 + Caster.Skills[CastSkill].Value / 25);

					IPooledEnumerable eable = map.GetMobilesInRange(Caster.Location, range);

					ExplodeFX.Fire.CreateInstance(Caster.Location, Caster.Map, range).Send();

					foreach (Mobile m in eable)
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var source = Caster;

						SpellHelper.Turn(source, m);

						Disturb(m);

						SpellHelper.CheckReflect((int)Circle, ref source, ref m);

						double damage = GetNewAosDamage(m, 4, 1, 6, true);

						if (CheckResisted(m))
						{
							damage *= 0.75;

							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

						Caster.DoHarmful(m);

						source.MovingParticles(m, 0x36D4, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);

						CustomUtility.ApplySimpleSpellEffect(m, "Supernova", AptitudeColor.Pyromancie, SpellEffectType.Damage);
					}
				}
			}

			FinishSequence();
		}
	}
}