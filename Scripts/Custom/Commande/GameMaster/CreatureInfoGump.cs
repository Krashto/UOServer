using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Server.CustomScripts.Gumps
{
	public class CreatureTome
	{
		public static void Initialize()
		{
			CommandSystem.Register("Creatures", AccessLevel.Player, new CommandEventHandler(GetAllBaseCreature_OnCommand));
		}

		[Usage("Creatures")]
		[Description("Ouvrir la fiche des créatures")]
		public static void GetAllBaseCreature_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new CreaturesGump(e.Mobile, "", 0, GetCreaturesList(), null));
		}

		public static string GetName(BaseCreature creature)
		{
			if (string.IsNullOrEmpty(creature.Name))
				return creature.GetType().ToString();

			return creature.Name;
		}

		public static List<CreatureInfo> GetCreaturesList()
		{
			var searchResults = ReflectiveEnumerator.GetEnumerableOfType<BaseCreature>();

			var infos = new List<CreatureInfo>();

			for (int i = searchResults.Count - 1; i >= 0; i--)
			{
				if (searchResults[i] is BaseVendor || searchResults[i] is BaseHire)
				{
					searchResults[i].Delete();
					continue;
				}

				var info = new CreatureInfo()
				{
					Name = string.IsNullOrEmpty(searchResults[i].Name) ? searchResults[i].GetType().ToString() : searchResults[i].Name,
					Level = searchResults[i].HitsMax / 100,
					HitsMax = searchResults[i].HitsMax,
					DamageMin = searchResults[i].DamageMin,
					DamageMax = searchResults[i].DamageMax,
					PhysicalDamage = searchResults[i].PhysicalDamage,
					FireDamage = searchResults[i].FireDamage,
					ColdDamage = searchResults[i].ColdDamage,
					PoisonDamage = searchResults[i].PoisonDamage,
					EnergyDamage = searchResults[i].EnergyDamage,
					Tamable = searchResults[i].Tamable,
					MinTameSkill = searchResults[i].MinTameSkill,
					ControlSlots = searchResults[i].ControlSlots,
					PhysicalResistance = searchResults[i].PhysicalResistance,
					FireResistance = searchResults[i].FireResistance,
					ColdResistance = searchResults[i].ColdResistance,
					PoisonResistance = searchResults[i].PoisonResistance,
					EnergyResistance = searchResults[i].EnergyResistance
				};

				infos.Add(info);
				searchResults[i].Delete();
			}

			searchResults.Free(true);

			return infos;
		}

		public class CreatureInfo
		{
			public string Name { get; set; }
			public int Level { get; set; }
			public int HitsMax { get; set; }
			public int DamageMin { get; set; }
			public int DamageMax { get; set; }
			public int PhysicalDamage { get; set; }
			public int FireDamage { get; set; }
			public int ColdDamage { get; set; }
			public int PoisonDamage { get; set; }
			public int EnergyDamage { get; set; }
			public bool Tamable { get; set; }
			public double MinTameSkill { get; set; }
			public int ControlSlots { get; set; }
			public int PhysicalResistance { get; set; }
			public int FireResistance { get; set; }
			public int ColdResistance { get; set; }
			public int PoisonResistance { get; set; }
			public int EnergyResistance { get; set; }

			public CreatureInfo()
			{

			}
		}
		public static class ReflectiveEnumerator
		{
			static ReflectiveEnumerator() { }

			public static List<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
			{
				List<T> objects = new List<T>();
				foreach (Type type in
					Assembly.GetAssembly(typeof(T)).GetTypes()
					.Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
				{
					try { objects.Add((T)Activator.CreateInstance(type, constructorArgs)); }
					catch { }
				}
				objects.Sort();
				return objects;
			}
		}

		public class CreaturesGump : Gump
		{
			private string m_SearchString;
			private List<CreatureInfo> m_SearchResults;
			private int m_Page;
			private int m_ObjectPerPage = 33;
			private string m_OrderBy;

			private const int Black = 0x000000;
			private const int White = 0xFFFFFF;
			private const int Red = 0xFF0000;
			private const int Green = 0x00FF00;
			private const int Gris = 0x999999;

			private static string Color(string text, int color)
			{
				return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</COLOR>", color, text);
			}

			private static string Center(string text)
			{
				return String.Format("<CENTER>{0}</CENTER>", text);
			}

			private List<string> m_ListOrderBy = new List<string>() { "Level", "Name", "Tamable" };

			public CreaturesGump(Mobile from, string searchString, int page, List<CreatureInfo> searchResults, string orderBy) : base(50, 50)
			{
				m_SearchString = searchString;
				m_SearchResults = searchResults;
				m_OrderBy = orderBy;
				m_Page = page;

				if (string.IsNullOrEmpty(m_OrderBy))
					m_OrderBy = m_ListOrderBy[0];

				switch (m_OrderBy)
				{
					case "Level": { m_SearchResults = m_SearchResults.OrderByDescending(f => f.Level).ToList(); break; }
					case "Name": { m_SearchResults = m_SearchResults.OrderBy(f => f.GetType()).ToList(); break; }
					case "Tamable": { m_SearchResults = m_SearchResults.OrderByDescending(f => f.MinTameSkill).ToList(); break; }
				}

				from.CloseGump(typeof(CreaturesGump));

				AddPage(0);

				var width = 1000;
				var height = 750;

				AddBackground(0, 0, width, height, 5054);

				AddImageTiled(10, 10, width - 20, 20, 2624);
				AddAlphaRegion(10, 10, width - 20, 20);

				AddAlphaRegion(42, 12, 182, 16);

				AddImageTiled(10, 40, width - 20, height - 80, 2624);
				AddAlphaRegion(10, 40, width - 20, height - 80);

				int x = 24;
				int y = 10;
				int space = 20;
				int column = 0;
				int columnSpace = 75;

				AddHtml(x, y, 200, 20, Center(Color("Names", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Levels", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Hits Max", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Damage", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Phys. D/R", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Fire D/R", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Cold D/R", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Poison D/R", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Energy D/R", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("% Taming", White)), false, false);
				AddHtml(x + 200 + column++ * columnSpace, y, columnSpace, space, Center(Color("Slots", White)), false, false);

				column = 0;
				y = 40;

				if (m_SearchResults.Count > 0)
				{
					for (int i = (m_Page * m_ObjectPerPage); i < ((m_Page + 1) * m_ObjectPerPage) && i < m_SearchResults.Count; ++i)
					{
						int index = i % m_ObjectPerPage;

						AddHtml(x, y + (index * space), 200, space, Center(Color(m_SearchResults[i].Name, White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].Level.ToString(), White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].HitsMax.ToString(), White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].DamageMin.ToString() + "-" + m_SearchResults[i].DamageMax.ToString(), White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].PhysicalDamage.ToString() + "-" + m_SearchResults[i].PhysicalResistance.ToString(), White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].FireDamage.ToString() + "/" + m_SearchResults[i].FireResistance.ToString(), White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].ColdDamage.ToString() + "/" + m_SearchResults[i].ColdResistance.ToString(), White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].PoisonDamage.ToString() + "/" + m_SearchResults[i].PoisonResistance.ToString(), White)), false, false);
						AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].EnergyDamage.ToString() + "/" + m_SearchResults[i].EnergyResistance.ToString(), White)), false, false);
						if (m_SearchResults[i].Tamable)
						{
							AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].MinTameSkill.ToString(), White)), false, false);
							AddHtml(x + 200 + column++ * columnSpace, y + (index * space), columnSpace, space, Center(Color(m_SearchResults[i].ControlSlots.ToString(), White)), false, false);
						}
						column = 0;
					}
				}
				else
				{
					AddLabel(15, 44, 0x480, "No results to display.");
				}

				AddImageTiled(10, height - 30, width - 20, 20, 2624);
				AddAlphaRegion(10, height - 30, width - 20, 20);

				if (m_Page > 0)
					AddButton(10, height - 31, 4014, 4016, 2, GumpButtonType.Reply, 0);
				else
					AddImage(10, height - 31, 4014);

				AddHtmlLocalized(44, height - 30, 170, 20, 1061028, m_Page > 0 ? 0x7FFF : 0x5EF7, false, false); // Previous page

				if (((m_Page + 1) * m_ObjectPerPage) < m_SearchResults.Count)
					AddButton(210, height - 31, 4005, 4007, 3, GumpButtonType.Reply, 0);
				else
					AddImage(210, height - 31, 4005);

				AddHtmlLocalized(244, height - 30, 170, 20, 1061027, ((m_Page + 1) * 10) < m_SearchResults.Count ? 0x7FFF : 0x5EF7, false, false); // Next page

				AddImageTiled(491, height - 29, 184, 18, 0xBBC);
				AddImageTiled(492, height - 29, 182, 16, 2624);
				AddButton(460, height - 30, 4011, 4013, 1, GumpButtonType.Reply, 0);
				AddTextEntry(494, height - 30, 180, 20, 0x480, 0, m_SearchString);
				AddHtmlLocalized(410, height - 30, 100, 20, 3010005, 0x7FFF, false, false);

				AddHtml(775, height - 30, 170, 20, Color("Order By:", White), false, false);
				AddButton(850, height - 30, 5537, 5538, 4, GumpButtonType.Reply, 0);
				AddHtml(875, height - 30, 75, 20, Center(Color(m_OrderBy, White)), false, false);
				AddButton(950, height - 30, 5540, 5541, 5, GumpButtonType.Reply, 0);
			}

			private static Type typeofItem = typeof(Item), typeofMobile = typeof(Mobile);

			private static void Match(string match, Type[] types, List<Type> results)
			{
				if (match.Length == 0)
					return;

				match = match.ToLower();

				for (int i = 0; i < types.Length; ++i)
				{
					Type t = types[i];

					if ((typeofMobile.IsAssignableFrom(t) || typeofItem.IsAssignableFrom(t)) && t.Name.ToLower().IndexOf(match) >= 0 && !results.Contains(t))
					{
						ConstructorInfo[] ctors = t.GetConstructors();

						for (int j = 0; j < ctors.Length; ++j)
						{
							if (ctors[j].GetParameters().Length == 0 && ctors[j].IsDefined(typeof(ConstructableAttribute), false))
							{
								results.Add(t);
								break;
							}
						}
					}
				}
			}

			public static List<Type> Match(string match)
			{
				List<Type> results = new List<Type>();
				Type[] types;

				Assembly[] asms = ScriptCompiler.Assemblies;

				for (int i = 0; i < asms.Length; ++i)
				{
					types = ScriptCompiler.GetTypeCache(asms[i]).Types;
					Match(match, types, results);
				}

				types = ScriptCompiler.GetTypeCache(Core.Assembly).Types;
				Match(match, types, results);

				results.Sort(new TypeNameComparer());

				return results;
			}

			private class TypeNameComparer : IComparer<Type>
			{
				public int Compare(Type x, Type y)
				{
					return x.Name.CompareTo(y.Name);
				}
			}

			public override void OnResponse(NetState sender, RelayInfo info)
			{
				Mobile from = sender.Mobile;

				switch (info.ButtonID)
				{
					case 1: // Search
						{
							TextRelay te = info.GetTextEntry(0);
							string match = (te == null ? "" : te.Text.Trim());

							m_SearchResults = GetCreaturesList();

							if (!string.IsNullOrEmpty(match))
							{
								for (int i = m_SearchResults.Count - 1; i >= 0; i--)
								{
									if (!m_SearchResults[i].GetType().ToString().Contains(match))
										m_SearchResults.RemoveAt(i);
								}
							}

							from.SendGump(new CreaturesGump(from, match, 0, m_SearchResults, m_OrderBy));

							break;
						}
					case 2: // Previous page
						{
							if (m_Page > 0)
								from.SendGump(new CreaturesGump(from, m_SearchString, m_Page - 1, m_SearchResults, m_OrderBy));

							break;
						}
					case 3: // Next page
						{
							if ((m_Page + 1) * m_ObjectPerPage < m_SearchResults.Count)
								from.SendGump(new CreaturesGump(from, m_SearchString, m_Page + 1, m_SearchResults, m_OrderBy));

							break;
						}
					case 4:
						{
							int index = m_ListOrderBy.FindIndex(a => a == m_OrderBy) - 1;

							if (index < 0)
								m_OrderBy = m_ListOrderBy[m_ListOrderBy.Count - 1];
							else
								m_OrderBy = m_ListOrderBy[index];

							from.SendGump(new CreaturesGump(from, m_SearchString, 0, m_SearchResults, m_OrderBy));

							break;
						}
					case 5:
						{
							int index = m_ListOrderBy.FindIndex(a => a == m_OrderBy) + 1;

							if (index > m_ListOrderBy.Count - 1)
								m_OrderBy = m_ListOrderBy[0];
							else
								m_OrderBy = m_ListOrderBy[index];

							from.SendGump(new CreaturesGump(from, m_SearchString, 0, m_SearchResults, m_OrderBy));

							break;
						}
				}
			}
		}
	}
}
