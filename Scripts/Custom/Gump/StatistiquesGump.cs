using System;
using System.Collections.Generic;
using Server.Accounting;
using Server.Mobiles;
using System.Linq;
using Server.Gumps;
using Server.Items;
using Server.Custom.Races;
using Server.Misc;

namespace Server.Gumps
{
	public enum StatistiqueGumpPage
	{
		PointageGlobalRace,
		PointageActifsRace,
		RepartitionRaces,
		RepartitionGold,
		RepartitionLegendaryItems,
		RepartitionEpicItems,
	}

	public class StatistiquesGump : Gump
	{
		private CustomPlayerMobile m_From;
		private StatistiquesStone m_Stone;
		private StatistiqueGumpPage m_Page;

		private const int LabelColorWhite = 0xFFFFFF;
		private const int LabelColorBlack = 0x000000;
		private const int SelectedColor = 0x8080FF;

		private const int LabelHue = 0x480;
		private const int GreenHue = 0x40;
		private const int RedHue = 0x20;

		public void AddPageButton(int x, int y, int buttonID, string text, StatistiqueGumpPage page, params StatistiqueGumpPage[] subPages)
		{
			bool isSelection = (m_Page == page);

			for (int i = 0; !isSelection && i < subPages.Length; ++i)
				isSelection = (m_Page == subPages[i]);

			AddSelectedButton(x, y, buttonID, text, isSelection);
		}

		public void AddSelectedButton(int x, int y, int buttonID, string text, bool isSelection)
		{
			AddButton(x, y - 1, isSelection ? 4006 : 4005, 4007, buttonID, GumpButtonType.Reply, 0);
			AddHtml(x + 35, y, 200, 20, Color(text, isSelection ? SelectedColor : LabelColorWhite), false, false);
		}

		public void AddButtonLabeled(int x, int y, int buttonID, string text)
		{
			AddButton(x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
			AddHtml(x + 35, y, 240, 20, Color(text, LabelColorWhite), false, false);
		}

		public string Center(string text)
		{
			return String.Format("<CENTER>{0}</CENTER>", text);
		}

		public string Color(string text, int color)
		{
			return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
		}

		public void AddBlackAlpha(int x, int y, int width, int height)
		{
			AddImageTiled(x, y, width, height, 2624);
			AddAlphaRegion(x, y, width, height);
		}

		public int GetButtonID(int type, int index)
		{
			return 1 + (index * 100) + type;
		}

		public class PlayerStats
		{
			public Race Race { get; set; }
			public List<CustomPlayerMobile> AllPlayers { get; set; }

			public List<CustomPlayerMobile> Players
			{
				get
				{
					var list = new List<CustomPlayerMobile>();
					try
					{
						list = AllPlayers.Where(x => x.Account.AccessLevel == AccessLevel.Player).ToList();

						if (ActifsOnly)
							list = list.Where(x => x.Account != null && ((Account)x.Account).LastLogin != null &&
												 ((Account)x.Account).LastLogin > DateTime.Now - TimeSpan.FromDays(14)).ToList();
					}
					catch { return list; }

					return list;
				}
			}


			public double? NiveauMoyen
			{
				get
				{
					var ave = 0.0;
					try { ave = Players.Average(x => x.Experience.Niveau); } catch { return 0.0; }
					return ave;
				}
			}

			public double? NiveauMax
			{
				get
				{
					var max = 0.0;
					try { max = Players.Max(x => x.Experience.Niveau); } catch { return 0.0; }
					return max;
				}
			}

			public int? NombrePlayer
			{
				get
				{
					var max = 0;
					try { max = Players.Count; } catch { return 0; }
					return max;
				}
			}

			public double? PlayerActifDeuxSemaines
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Account != null && ((Account)x.Account).LastLogin != null && ((Account)x.Account).LastLogin > DateTime.Now - TimeSpan.FromDays(14)); }
					catch { return 0.0; }
					return actifs;
				}
			}

			public double? PlayerActifUneSemaine
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Account != null && ((Account)x.Account).LastLogin != null && ((Account)x.Account).LastLogin > DateTime.Now - TimeSpan.FromDays(7)); }
					catch { return 0.0; }
					return actifs;
				}
			}

			public double? PlayerTotalHours
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Sum(x => x.GameTime.TotalHours); } catch { return 0.0; }
					return actifs;
				}
			}

			public double? DemiElfeCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(DemiElfe)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? DemiOrcCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(DemiOrc)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? DrakosCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(Drakos)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? ElfeDesBoisCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(ElfeDesBois)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? ElfeSombreCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(ElfeSombre)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? HautElfeCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(HautElfe)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? MontagnardCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(Montagnard)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? NainCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(Nain)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? NomadeCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(Nomade)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? PeekosCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(Peekos)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? PetitGensCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(PetitGens)); } catch { return 0.0; }
					return actifs;
				}
			}
			public double? RiverainCount
			{
				get
				{
					var actifs = 0.0;
					try { actifs = Players.Count(x => x.Race.GetType() == typeof(Riverain)); } catch { return 0.0; }
					return actifs;
				}
			}

			public int? PlayerTotal
			{
				get
				{
					var actifs = 0;
					try { actifs = Players.Count; } catch { return 0; }
					return actifs;
				}
			}

			public bool ActifsOnly { get; private set; }

			private StatistiquesStone m_Stone { get; set; }

			public PlayerStats(StatistiquesStone stone, bool actifsOnly)
			{
				AllPlayers = new List<CustomPlayerMobile>();

				m_Stone = stone;
				ActifsOnly = actifsOnly;
			}
		}

		public List<PlayerStats> GetPlayerStats(bool actifsOnly = false)
		{
			var stats = new List<PlayerStats>();

			foreach (Race race in Race.AllRaces)
			{
				stats.Add(new PlayerStats(m_Stone, actifsOnly) { Race = race });
			}

			var mobiles = new List<Mobile>(World.Mobiles.Values);

			for (int i = mobiles.Count - 1; i >= 0; i--)
			{
				if (!(mobiles[i] is CustomPlayerMobile) || mobiles[i].Account == null || mobiles[i].Account.AccessLevel > AccessLevel.Player)
					mobiles.RemoveAt(i);
			}

			var groups = mobiles.GroupBy(g => g is CustomPlayerMobile ? ((CustomPlayerMobile)g).Race : Race.Human);

			foreach (var group in groups)
			{
				var key = group.Key;

				foreach (var groupedItem in group)
				{
					var pm = groupedItem as CustomPlayerMobile;

					if (pm == null)
						continue;

					var pointage = stats[pm.Race.RaceID];

					pointage.AllPlayers.Add(pm);
				}
			}
			return stats;
		}

		public StatistiquesGump(CustomPlayerMobile from, StatistiquesStone stone, StatistiqueGumpPage pageType) : base(50, 40)
		{
			from.CloseGump(typeof(StatistiquesGump));

			m_From = from;
			m_Stone = stone;
			m_Page = pageType;

			AddPage(0);

			AddBackground(0, 0, 520, 740, 5054);
			AddBlackAlpha(10, 10, 500, 100);
			AddBlackAlpha(10, 120, 500, 610);

			var x = 12;
			var y = 20;
			var line = 0;
			var space = 20;
			var column = 0;
			var columnSpace = 150;

			AddPageButton(x + columnSpace * column, y + space * line++, GetButtonID(1, (int)StatistiqueGumpPage.PointageGlobalRace), "Pointage (Global)", StatistiqueGumpPage.PointageGlobalRace);
			AddPageButton(x + columnSpace * column, y + space * line++, GetButtonID(1, (int)StatistiqueGumpPage.PointageActifsRace), "Pointage (Actifs)", StatistiqueGumpPage.PointageActifsRace);
			AddPageButton(x + columnSpace * column, y + space * line++, GetButtonID(1, (int)StatistiqueGumpPage.RepartitionRaces), "Races", StatistiqueGumpPage.RepartitionRaces);
			AddPageButton(x + columnSpace * column, y + space * line++, GetButtonID(1, (int)StatistiqueGumpPage.RepartitionGold), "Or", StatistiqueGumpPage.RepartitionGold);
			line = 0; column++;
			AddPageButton(x + columnSpace * column, y + space * line++, GetButtonID(1, (int)StatistiqueGumpPage.RepartitionEpicItems), "Items épiques", StatistiqueGumpPage.RepartitionEpicItems);
			AddPageButton(x + columnSpace * column, y + space * line++, GetButtonID(1, (int)StatistiqueGumpPage.RepartitionLegendaryItems), "Items légendaires", StatistiqueGumpPage.RepartitionLegendaryItems);

			column = 0;

			switch (pageType)
			{
				case StatistiqueGumpPage.PointageActifsRace:
					{
						x = 12;
						y = 120;
						line = 0;
						space = 20;
						column = 0;
						columnSpace = 75;

						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Race");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Niv. moy.");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Niv. max");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Actifs(2s)");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Actifs(1s)");

						x = 12;
						y = 140;
						line = 0;

						var stats = GetPlayerStats(true);

						foreach (var pointage in stats)
						{
							column = 0;

							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, pointage.Race.ToString());
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, string.Format("{0}", (int)pointage.NiveauMoyen));
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, string.Format("{0}", (int)pointage.NiveauMax));
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, string.Format("{0}/{1}", pointage.PlayerActifDeuxSemaines, pointage.PlayerTotal));
							AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, string.Format("{0}/{1}", pointage.PlayerActifUneSemaine, pointage.PlayerTotal));
						}
						break;
					}
				case StatistiqueGumpPage.PointageGlobalRace:
					{
						x = 12;
						y = 120;
						line = 0;
						space = 20;
						column = 0;
						columnSpace = 75;

						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Race");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Niv. moy.");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Niv. max");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Actifs(2s)");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Actifs(1s)");

						x = 12;
						y = 140;
						line = 0;

						var stats = GetPlayerStats();

						foreach (var pointage in stats)
						{
							column = 0;

							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, pointage.Race.ToString());
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, string.Format("{0}", (int)pointage.NiveauMoyen));
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, string.Format("{0}", (int)pointage.NiveauMax));
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, string.Format("{0}/{1}", pointage.PlayerActifDeuxSemaines, pointage.PlayerTotal));
							AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, string.Format("{0}/{1}", pointage.PlayerActifUneSemaine, pointage.PlayerTotal));
						}

						line++;
						column = 0;

						AddLabelCropped(x + columnSpace * column, y + space * line++, columnSpace, 20, LabelHue, "MPV");

						columnSpace = 75;
						column = 0;

						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, "Race");
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Nom");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Account");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, "Niveau");

						var mpv = new List<CustomPlayerMobile>();

						for (int i = 100; i > 0; i--)
						{
							foreach (var pointage in stats)
							{
								foreach (var player in pointage.Players)
								{
									if (player.Experience.Niveau == i)
										mpv.Add(player);

									if (mpv.Count >= 14)
										break;
								}

								if (mpv.Count >= 14)
									break;
							}

							if (mpv.Count >= 14)
								break;
						}

						foreach (var m in mpv.OrderByDescending(s => s.Experience.Niveau))
						{
							column = 0;

							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, m.Race.ToString());
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, m.Name);
							column++;
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, m.Account.ToString());
							column++;
							AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, m.Experience.Niveau.ToString());
						}

						break;
					}
				case StatistiqueGumpPage.RepartitionRaces:
					{
						x = 12;
						y = 120;
						line = 0;
						space = 20;
						column = 0;
						columnSpace = 75;

						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Race");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Actifs(2s)");
						AddLabelCropped(x + columnSpace * column++, y, columnSpace, 20, LabelHue, "Actifs(1s)");

						x = 12;
						y = 140;
						line = 0;

						var stats = GetPlayerStats();

						foreach (var pointage in stats)
						{
							column = 0;

							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, pointage.Race.ToString());
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, string.Format("{0}/{1}", pointage.PlayerActifDeuxSemaines, pointage.PlayerTotal));
							AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, string.Format("{0}/{1}", pointage.PlayerActifUneSemaine, pointage.PlayerTotal));
						}
						break;
					}
				case StatistiqueGumpPage.RepartitionGold:
					{
						x = 12;
						y = 120;
						line = 0;
						space = 20;
						column = 0;
						columnSpace = 75;

						AddLabelCropped(x + columnSpace * column, y + space * line++, columnSpace, 20, LabelHue, "MPV");

						columnSpace = 75;
						column = 0;

						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Nom");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Account");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, "Or");
						AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, "Race");

						var mpv = new Dictionary<CustomPlayerMobile, int>();

						var stats = GetPlayerStats();

						foreach (var pointage in stats)
						{
							foreach (var player in pointage.Players)
							{
								var gold = player.BankBox.FindItemsByType(typeof(Gold)).OfType<Gold>().ToList();

								var sum = gold.Sum(f => f.Amount);

								var check = player.BankBox.FindItemsByType(typeof(BankCheck)).OfType<BankCheck>().ToList();

								sum += check.Sum(f => f.Worth);

								mpv.Add(player, sum);
							}
						}

						var sortedDict = mpv.OrderByDescending(f => f.Value);

						var count = 0;

						foreach (var element in sortedDict)
							count++;

						if (count > 28)
							count = 28;

						for (int i = 0; i < count; i++)
						{
							column = 0;

							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, sortedDict.ElementAt(i).Key.Name);
							column++;
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, sortedDict.ElementAt(i).Key.Account.Username);
							column++;
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, sortedDict.ElementAt(i).Value.ToString());
							AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, sortedDict.ElementAt(i).Key.Race.ToString());
						}

						break;
					}
				case StatistiqueGumpPage.RepartitionEpicItems:
					{
						x = 12;
						y = 120;
						line = 0;
						space = 20;
						column = 0;
						columnSpace = 75;

						AddLabelCropped(x + columnSpace * column, y + space * line++, columnSpace, 20, LabelHue, "MPV");

						columnSpace = 75;
						column = 0;

						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Nom");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, "Account");
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Type");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, "Ressource");

						var mpv = new Dictionary<IQuality, CustomPlayerMobile>();

						var stats = GetPlayerStats();

						foreach (var pointage in stats)
						{
							foreach (var player in pointage.Players)
							{
								var weapons = player.BankBox.FindItemsByType(typeof(BaseWeapon)).OfType<BaseWeapon>().ToList();

								foreach (var weapon in weapons)
								{
									if (weapon.Quality == ItemQuality.Epic && !mpv.ContainsKey(weapon))
										mpv.Add(weapon, player);
								}

								foreach (var item in player.Items)
								{
									if (item is BaseWeapon weapon && weapon.Quality == ItemQuality.Epic && !mpv.ContainsKey(weapon))
										mpv.Add(weapon, player);
								}

								var armors = player.BankBox.FindItemsByType(typeof(BaseArmor)).OfType<BaseArmor>().ToList();

								foreach (var armor in armors)
								{
									if (armor.Quality == ItemQuality.Epic && !mpv.ContainsKey(armor))
										mpv.Add(armor, player);
								}

								foreach (var item in player.Items)
								{
									if (item is BaseArmor armor && armor.Quality == ItemQuality.Epic && !mpv.ContainsKey(armor))
										mpv.Add(armor, player);
								}
							}
						}

						var sortedDict = mpv.OrderByDescending(f => f.Key.Quality);

						var count = 0;

						foreach (var element in sortedDict)
							count++;

						if (count > 28)
							count = 28;

						for (int i = 0; i < count; i++)
						{
							column = 0;

							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, sortedDict.ElementAt(i).Value.Name);
							column++;
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, sortedDict.ElementAt(i).Value.Account.Username);

							var weapon = sortedDict.ElementAt(i).Key as BaseWeapon;

							if (weapon != null)
							{
								AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, weapon.GetType().Name.ToString());
								column++;
								AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, weapon.Resource.ToString());
							}

							var armor = sortedDict.ElementAt(i).Key as BaseArmor;

							if (armor != null)
							{
								AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, armor.GetType().Name.ToString());
								column++;
								AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, armor.Resource.ToString());
							}
						}

						break;
					}
				case StatistiqueGumpPage.RepartitionLegendaryItems:
					{
						x = 12;
						y = 120;
						line = 0;
						space = 20;
						column = 0;
						columnSpace = 75;

						AddLabelCropped(x + columnSpace * column, y + space * line++, columnSpace, 20, LabelHue, "MPV");

						columnSpace = 75;
						column = 0;

						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Nom");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, "Account");
						AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, "Type");
						column++;
						AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, "Ressource");

						var mpv = new Dictionary<IQuality, CustomPlayerMobile>();

						var stats = GetPlayerStats();

						foreach (var pointage in stats)
						{
							foreach (var player in pointage.Players)
							{
								var weapons = player.BankBox.FindItemsByType(typeof(BaseWeapon)).OfType<BaseWeapon>().ToList();

								foreach (var weapon in weapons)
								{
									if (weapon.Quality == ItemQuality.Legendary)
										mpv.Add(weapon, player);
								}

								foreach (var item in player.Items)
								{
									if (item is BaseWeapon weapon && weapon.Quality == ItemQuality.Legendary)
										mpv.Add(weapon, player);
								}

								var armors = player.BankBox.FindItemsByType(typeof(BaseArmor)).OfType<BaseArmor>().ToList();

								foreach (var armor in armors)
								{
									if (armor.Quality == ItemQuality.Legendary)
										mpv.Add(armor, player);
								}

								foreach (var item in player.Items)
								{
									if (item is BaseArmor armor && armor.Quality == ItemQuality.Legendary)
										mpv.Add(armor, player);
								}
							}
						}

						var sortedDict = mpv.OrderByDescending(f => f.Key.Quality);

						var count = 0;

						foreach (var element in sortedDict)
							count++;

						if (count > 28)
							count = 28;

						for (int i = 0; i < count; i++)
						{
							column = 0;

							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, sortedDict.ElementAt(i).Value.Name);
							column++;
							AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace, 20, LabelHue, sortedDict.ElementAt(i).Value.Account.Username);

							var weapon = sortedDict.ElementAt(i).Key as BaseWeapon;

							if (weapon != null)
							{
								AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, weapon.GetType().Name.ToString());
								column++;
								AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, weapon.Resource.ToString());
							}

							var armor = sortedDict.ElementAt(i).Key as BaseArmor;

							if (armor != null)
							{
								AddLabelCropped(x + columnSpace * column++, y + space * line, columnSpace * 2, 20, LabelHue, armor.GetType().Name.ToString());
								column++;
								AddLabelCropped(x + columnSpace * column++, y + space * line++, columnSpace, 20, LabelHue, armor.Resource.ToString());
							}
						}

						break;
					}
			}
		}

		public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
		{
			int val = info.ButtonID - 1;

			if (val < 0)
				return;

			if (m_From.AccessLevel < AccessLevel.GameMaster)
				return;

			int type = val % 100;
			int index = val / 100;

			switch (type)
			{
				case 1:
					{
						m_From.SendGump(new StatistiquesGump(m_From, m_Stone, (StatistiqueGumpPage)index));
						break;
					}
			}
		}
	}
}

namespace Server.Items
{
	public class StatistiquesStone : Item
	{
		[Constructable]
		public StatistiquesStone() : base(0xED4)
		{
			Movable = false;
			Name = "Statistiques";
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from.AccessLevel < AccessLevel.Administrator)
				return;

			from.SendGump(new StatistiquesGump((CustomPlayerMobile)from, this, StatistiqueGumpPage.PointageActifsRace));
		}

		public StatistiquesStone(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}