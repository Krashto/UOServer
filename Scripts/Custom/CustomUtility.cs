using System;
using System.Collections.Generic;
using System.Linq;
using Server.Items;
using System.Reflection;
using Server.Mobiles;
using Discord;

namespace Server.Custom
{
	public enum MessageColor
	{
		Purple = 17,
		Pink = 28,
		Orange = 43,
		Yellow = 53,
		Green = 67,
		Cyan = 82,
		Blue = 92,
		Red = 137,
		White = 1153
	}
	public enum AptitudeColor
	{
		Aeromancie = 2093,
		Chasseur = 2173,
		Defenseur = 2297,
		Geomancie = 2708,
		Guerison = 1999,
		Hydromancie = 2083,
		Martial = 1935,
		Musique = 1486,
		Necromancie = 2174,
		Polymorphie = 2661,
		Pyromancie = 2737,
		Roublardise = 2818,
		Totemique = 2767
	}

	public enum SpellEffectType
	{
		Bonus,
		Malus,
		Damage,
		Heal,
		Move,
		Taunt,
		Summon
	}

	public enum SpellSequenceType
	{
		None,
		Start,
		End,
	}

	public class CustomUtility
	{
		public static bool IsInOpenWorldRegion(Point3D location)
		{
			return location.X > 0 && location.X < 2160 && location.Y > 0 && location.Y < 2125;
		}
		public static bool IsInDungeonRegion(Point3D location)
		{
			return !IsInOpenWorldRegion(location);
		}

		public static void IsTeleportingInDungeonRegion(Mobile from, Point3D newLocation)
		{
			if (from.AccessLevel > AccessLevel.Player)
				return;

			if (!IsInDungeonRegion(from.Location) && IsInDungeonRegion(newLocation) && from is CustomPlayerMobile pm)
			{
				if (pm.Mounted && pm.Mount is BaseMount mount)
				{
					mount.Rider = null;
					mount.Internalize();
					mount.SetControlMaster(null);
					mount.Poison = null;
					mount.Hits = mount.HitsMax;
					mount.ControlOrder = OrderType.Stay;
					mount.IsStabled = true;

					pm.StoredCreatureWhenEnteringInDungeon = mount;
					pm.SendMessage("Votre monture a été téléporté en dehors du donjon. Vous la retrouverez en sortant.");
				}
			}
		}
		public static void IsTeleportingOutOfDungeonRegion(Mobile from, Point3D newLocation)
		{
			if (from.AccessLevel > AccessLevel.Player)
				return;

			if (IsInDungeonRegion(from.Location) && !IsInDungeonRegion(newLocation) && from is CustomPlayerMobile pm)
			{
				if (!pm.Mounted && pm.Mount == null && pm.StoredCreatureWhenEnteringInDungeon is BaseMount mount)
				{
					mount.SetControlMaster(pm);
					mount.IsStabled = false;
					mount.Poison = null;
					mount.Hits = mount.HitsMax;
					mount.MoveToWorld(pm.Location, pm.Map);
					mount.ControlOrder = OrderType.Follow;
					if (pm.Alive)
						mount.Rider = pm;

					pm.StoredCreatureWhenEnteringInDungeon = null;
					pm.SendMessage("Vous retrouvez votre monture.");
				}
			}
		}

		public static void ApplySimpleSpellEffect(Mobile from, string spellName, AptitudeColor aptColor, SpellEffectType effect = SpellEffectType.Bonus)
		{
			ApplySimpleSpellEffect(from, spellName, TimeSpan.Zero, aptColor, SpellSequenceType.None, effect);
		}

		public static void ApplySimpleSpellEffect(Mobile from, string spellName, AptitudeColor aptColor, SpellSequenceType sequence, SpellEffectType effect = SpellEffectType.Bonus)
		{
			ApplySimpleSpellEffect(from, spellName, TimeSpan.Zero, aptColor, sequence, effect);
		}

		public static void ApplySimpleSpellEffect(Mobile from, string spellName, TimeSpan duration, AptitudeColor aptColor, SpellEffectType effect = SpellEffectType.Bonus)
		{
			ApplySimpleSpellEffect(from, spellName, duration, aptColor, SpellSequenceType.Start, effect);
		}

		public static void ApplySimpleSpellEffect(Mobile from, string spellName, TimeSpan duration, AptitudeColor aptColor, SpellSequenceType sequence, SpellEffectType effect = SpellEffectType.Bonus)
		{
			string effectTypeMessage;
			MessageColor messageHue;

			switch (effect)
			{
				default: { effectTypeMessage = ""; messageHue = MessageColor.White; break; }
				case SpellEffectType.Bonus:
					{
						effectTypeMessage = "[BONUS] ";

						switch (sequence)
						{
							default:
							case SpellSequenceType.Start: { messageHue = MessageColor.Green; break; }
							case SpellSequenceType.End: { messageHue = MessageColor.White; break; }
						}
						break;
					}
				case SpellEffectType.Malus:
					{
						effectTypeMessage = "[MALUS] ";

						switch (sequence)
						{
							default:
							case SpellSequenceType.Start: { messageHue = MessageColor.Purple; break; }
							case SpellSequenceType.End: { messageHue = MessageColor.White; break; }
						}
						break;
					}
				case SpellEffectType.Damage:
					{
						effectTypeMessage = "[DÉGÂTS] ";

						switch (sequence)
						{
							default:
							case SpellSequenceType.Start: { messageHue = MessageColor.Red; break; }
							case SpellSequenceType.End: { messageHue = MessageColor.White; break; }
						}
						break;
					}
				case SpellEffectType.Heal:
					{
						effectTypeMessage = "[SOINS] ";

						switch (sequence)
						{
							default:
							case SpellSequenceType.Start: { messageHue = MessageColor.Yellow; break; }
							case SpellSequenceType.End: { messageHue = MessageColor.White; break; }
						}
						break;
					}
				case SpellEffectType.Move:
					{
						effectTypeMessage = "[MOUVEMENT] ";

						switch (sequence)
						{
							default:
							case SpellSequenceType.Start: { messageHue = MessageColor.Blue; break; }
							case SpellSequenceType.End: { messageHue = MessageColor.White; break; }
						}
						break;
					}
				case SpellEffectType.Taunt:
					{
						effectTypeMessage = "[TAUNT] ";

						switch (sequence)
						{
							default:
							case SpellSequenceType.Start: { messageHue = MessageColor.Orange; break; }
							case SpellSequenceType.End: { messageHue = MessageColor.White; break; }
						}
						break;
					}
				case SpellEffectType.Summon:
					{
						effectTypeMessage = "[INVOCATION] ";

						switch (sequence)
						{
							default:
							case SpellSequenceType.Start: { messageHue = MessageColor.Orange; break; }
							case SpellSequenceType.End: { messageHue = MessageColor.White; break; }
						}
						break;
					}
			}

			switch (sequence)
			{
				case SpellSequenceType.None:
					{
						from.SendMessage((int)messageHue, $"{effectTypeMessage}Le sort '{spellName}' prend son effet sur vous.");
						break;
					}
				case SpellSequenceType.Start:
					{
						if (duration != TimeSpan.Zero)
							from.SendMessage((int)messageHue, $"{effectTypeMessage}[DÉBUT]: Le sort '{spellName}' prend son effet sur vous pendant {duration.TotalSeconds} seconde{(duration.TotalSeconds > 1 ? "s" : "")}.");
						else
							from.SendMessage((int)messageHue, $"{effectTypeMessage}[DÉBUT]: Le sort '{spellName}' prend son effet sur vous.");
						break;
					}
				case SpellSequenceType.End: from.SendMessage((int)messageHue, $"{effectTypeMessage}[FIN]: Le sort '{spellName}' prend fin."); break;
			}

			from.FixedParticles(14217, 10, 20, 5013, (int)aptColor, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
		}

		public static string GetDescription(Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			return attribute == null ? value.ToString() : attribute.Description;
		}

		public static Item GetRandomItemByBaseType(Type baseType)
		{
			var itemList = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(domainAssembly => domainAssembly.GetTypes())
				.Where(type => baseType.IsAssignableFrom(type) && /*type != baseType && */!type.IsAbstract/* && type.IsValueType && type.GetConstructor(Type.EmptyTypes) != null*/)
				.ToArray();

			var rnd = Utility.Random(0, itemList.Length - 1);
			Item item = null;
			try { item = Activator.CreateInstance(itemList[rnd]) as Item; }
			catch { return null; }
			return item;
		}
		public static Item GetRandomItemFromList(List<Type> itemList)
		{
			var rnd = Utility.Random(0, itemList.Count - 1);
			Item item = null;
			try { item = Activator.CreateInstance(itemList[rnd]) as Item; }
			catch { return null; }
			return item;
		}

		public static int GetItemAmountInBank(Mobile m, Type type)
		{
			var goldPiles = GetItemPilesInBank(m, type);
			return goldPiles.Sum(f => f.Amount);
		}

		public static Item[] GetItemPilesInBank(Mobile m, Type type)
		{
			var bankBox = m.BankBox;
			return bankBox.FindItemsByType(type);
		}

		public static bool ConsumeItemInBank(Mobile m, Type type, int amount)
		{
			var piles = GetItemPilesInBank(m, type);
			var qty = GetItemAmountInBank(m, type);

			if (piles == null || qty < amount)
			{
				var item = (Item)Activator.CreateInstance(type);
				if (!string.IsNullOrEmpty(item.Name))
					m.SendMessage($"Vous n'avez pas la quantité suffisante de {item.Name} dans votre coffre de banque.");
				else
					m.SendMessage($"Vous n'avez pas la quantité suffisante de {item.GetType().Name} dans votre coffre de banque.");
				item.Delete();
				return false;
			}

			int index = piles.Length - 1;
			while (amount > 0 && index >= 0)
			{
				var item = piles[index];

				if (item.Amount > amount)
				{
					item.Amount -= amount;
					amount = 0;
				}
				else
				{
					amount -= item.Amount;
					item.Delete();
				}

				index--;
			}

			return amount <= 0;
		}

		public static int GetFollowersCount(Mobile caster)
		{
			if (caster == null || !(caster is CustomPlayerMobile pm))
				return 0;

			return pm.AllFollowers.Count;
		}

		public static void SpawnMobsOnDamage(BaseCreature master, Mobile target, Type spawnType, int max)
		{
			Map map = target.Map;

			if (map == null)
				return;

			int aids = master.GetTeamSize(10);

			if (aids < max)
			{
				var spawn = Activator.CreateInstance(spawnType) as BaseCreature;

				if (spawn == null)
					return;

				spawn.Team = master.Team;
				spawn.SummonMaster = master;

				Point3D loc = target.Location;
				bool validLocation = false;

				for (int j = 0; !validLocation && j < 10; ++j)
				{
					int x = target.X + Utility.Random(3) - 1;
					int y = target.Y + Utility.Random(3) - 1;
					int z = map.GetAverageZ(x, y);

					if (validLocation = map.CanFit(x, y, target.Z, 16, false, false))
						loc = new Point3D(x, y, target.Z);
					else if (validLocation = map.CanFit(x, y, z, 16, false, false))
						loc = new Point3D(x, y, z);
				}

				spawn.MoveToWorld(loc, map);

				spawn.Combatant = target;
			}
		}

		public static bool IsMobileUndead(Mobile m)
		{
			return m is BoneKnight || m is DreamWraith || m is Lich || m is PatchworkSkeleton || m is SkeletalMage
				|| m is SkeletalMount || m is Skeleton || m is Spectre || m is Wight
				|| m is AncientLich || m is BoneDemon || m is LadyMelisande || m is LichLord || m is Nightmare
				|| m is Serado || m is SkeletalDragon || m is SkeletalLich
				|| m is Ghoul || m is HeadlessOne || m is Mummy || m is RestlessSoul || m is SpectralArmour 
				|| m is VampireBat || m is WailingBanshee || m is Zombie 
				|| m is FleshGolem || m is GoreFiend || m is LadyOfTheSnow || m is MasterTheophilus || m is PrimevalLich 
				|| m is RottingCorpse || m is ShadowKnight || m is Succubus;
		}
	}
}
