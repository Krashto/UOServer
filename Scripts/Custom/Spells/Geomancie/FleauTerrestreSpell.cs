using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Items;
using Server.Mobiles;
using VitaNex.FX;

namespace Server.Spells
{
	public class FleauTerrestreSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Fléau terrestre", "Kal Nox Corp Grav",
				SpellCircle.Seventh,
				236,
				9011,
				Reagent.Nightshade,
				Reagent.NoxCrystal,
				Reagent.Bloodmoss
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FleauTerrestreSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Map map = Caster.Map;

				ArrayList targets = new ArrayList();

				if (map != null)
				{
					var range = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 5, Aptitude.Geomancie);

					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(Caster.Location), range);

					ExplodeFX.Poison.CreateInstance(Caster, Caster.Map, range).Send();

					foreach (Mobile m in eable)
					{
						if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && m != Caster && Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (int i = 0; i < targets.Count; ++i)
					{
						Mobile m = (Mobile)targets[i];

						if (!InsensibleSpell.IsActive(m))
						{
							double damage = GetNewAosDamage(m, 5, 1, 2, false);

							if (CheckResisted(m))
							{
								damage *= 0.75;

								m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
							}
							SpellHelper.Damage(this, m, damage, 100, 0, 0, 0, 0);

							MortalStrike.BeginWound(m, TimeSpan.FromSeconds(6.0));

							Poison p = Poison.Deadly;
							m.ApplyPoison(Caster, p);
							m.PlaySound(0x474);
							ExplodeFX.Poison.CreateInstance(m, m.Map, 0).Send();
						}
					}
				}
			}

			FinishSequence();
		}
	}
}