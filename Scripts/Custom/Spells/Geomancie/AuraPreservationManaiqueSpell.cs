using Server.Custom.Aptitudes;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using System;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class AuraPreservationManaiqueSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
			"Aura Préservation Manaique", "[Aura Préservation Manaique]",
			SpellCircle.Second,
			212,
			9061,
			Reagent.EssenceGeomancie
		);

		public override int RequiredAptitudeValue { get { return 8; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AuraPreservationManaiqueSpell(Mobile caster, Item scroll)
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
					IPooledEnumerable eable = map.GetMobilesInRange(Caster.Location, (int)(1 + Caster.Skills[CastSkill].Value / 25));

					targets.Add(Caster);

					foreach (Mobile m in eable)
					{
						if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeBeneficial(m, false))
						{
							targets.Add(m);
						}
					}

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						if (IsActive(m))
							Deactivate(m);

						var duration = GetDurationForSpell(15, 3);

						Timer t = new InternalTimer(m, DateTime.Now + duration);
						m_Timers[m] = t;
						t.Start();

						CustomUtility.ApplySimpleSpellEffect(m, "Aura préservation manaique", duration, AptitudeColor.Geomancie);
					}
				}
			}

			FinishSequence();
		}

		public static int GetValue(Mobile m)
		{
			return m_Timers.ContainsKey(m) ? 20 : 0;
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);

				if (m is PlayerMobile player)
				{
					// Retirer l'effet de 20% sur l'arme en main
					Item oneHandedWeapon = player.FindItemOnLayer(Layer.OneHanded);
					if (oneHandedWeapon != null && oneHandedWeapon is BaseWeapon && oneHandedWeapon.Layer == Layer.OneHanded)
					{
						ApplyWeaponEffect((BaseWeapon)oneHandedWeapon, 0);
					}

					// Retirer l'effet de 20% sur l'arme à deux mains
					Item twoHandedWeapon = player.FindItemOnLayer(Layer.TwoHanded);
					if (twoHandedWeapon != null && twoHandedWeapon is BaseWeapon && twoHandedWeapon.Layer == Layer.TwoHanded)
					{
						ApplyWeaponEffect((BaseWeapon)twoHandedWeapon, 0);
					}

					// Retirer l'effet de 20% sur le spellbook en main
					Item spellbook = player.FindItemOnLayer(Layer.OneHanded);
					if (spellbook != null && spellbook is NewSpellbook && spellbook.Layer == Layer.OneHanded)
					{
						((NewSpellbook)spellbook).Attributes.LowerManaCost = 0;
					}

					// Retirer l'effet des items dans le backpack
					var backpack = player.Backpack;
					if (backpack != null)
					{
						var items = backpack.FindItemsByType<BaseWeapon>(true);
						foreach (var item in items)
						{
							ApplyWeaponEffect(item, 0);
						}

						var spellbooks = backpack.FindItemsByType<NewSpellbook>(true);
						foreach (var item in spellbooks)
						{
							item.Attributes.LowerManaCost = 0;
						}
					}
				}

				CustomUtility.ApplySimpleSpellEffect(m, "Aura préservation manaique", AptitudeColor.Geomancie, SpellSequenceType.End);
			}
		}

		private static void ApplyWeaponEffect(BaseWeapon weapon, int manaCostReduction)
		{
			if (weapon != null)
			{
				weapon.Attributes.LowerManaCost = manaCostReduction;
				weapon.InvalidateProperties();
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_EndTime;

			public InternalTimer(Mobile m, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
			{
				m_Mobile = m;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
					return;
				}

				if (m_Mobile is PlayerMobile player)
				{
					// Retirer l'effet de 20% sur l'arme en main
					Item oneHandedWeapon = player.FindItemOnLayer(Layer.OneHanded);
					if (oneHandedWeapon != null && oneHandedWeapon is BaseWeapon && oneHandedWeapon.Layer == Layer.OneHanded)
					{
						if (IsActive(m_Mobile))
						{
							ApplyWeaponEffect((BaseWeapon)oneHandedWeapon, 20);
						}
						else
						{
							ApplyWeaponEffect((BaseWeapon)oneHandedWeapon, 0);
						}
					}

					// Retirer l'effet de 20% sur l'arme à deux mains
					Item twoHandedWeapon = player.FindItemOnLayer(Layer.TwoHanded);
					if (twoHandedWeapon != null && twoHandedWeapon is BaseWeapon && twoHandedWeapon.Layer == Layer.TwoHanded)
					{
						if (IsActive(m_Mobile))
						{
							ApplyWeaponEffect((BaseWeapon)twoHandedWeapon, 20);
						}
						else
						{
							ApplyWeaponEffect((BaseWeapon)twoHandedWeapon, 0);
						}
					}

					// Retirer l'effet de 20% sur le spellbook en main
					NewSpellbook spellbook = (NewSpellbook)player.FindItemOnLayer(Layer.OneHanded);
					if (spellbook != null && spellbook is NewSpellbook && spellbook.Layer == Layer.OneHanded)
					{
						if (IsActive(m_Mobile))
						{
							spellbook.Attributes.LowerManaCost = 20;
						}
						else
						{
							spellbook.Attributes.LowerManaCost = 0;
						}
					}

					// Retirer l'effet des items dans le backpack
					var backpack = player.Backpack;
					if (backpack != null)
					{
						var items = backpack.FindItemsByType<BaseWeapon>(true);
						foreach (var item in items)
						{
							if (IsActive(m_Mobile))
							{
								ApplyWeaponEffect(item, 20);
							}
							else
							{
								ApplyWeaponEffect(item, 0);
							}
						}

						var spellbooks = backpack.FindItemsByType<NewSpellbook>(true);
						foreach (var item in spellbooks)
						{
							if (IsActive(m_Mobile))
							{
								item.Attributes.LowerManaCost = 20;
							}
							else
							{
								item.Attributes.LowerManaCost = 0;
							}
						}
					}
				}

				if (DateTime.Now >= m_EndTime)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}
	}
}
