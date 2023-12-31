using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class CompagnonAnimalSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Compagnon animal", "[Compagnon animal]",
				SpellCircle.Fourth,
				239,
				9021,
				Reagent.EssenceChasseur
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CompagnonAnimalSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		private static readonly Hashtable m_Table = new Hashtable();

		public static Hashtable Table => m_Table;

		public override bool CheckCast()
		{
			BaseCreature check = (BaseCreature)m_Table[Caster];

			if (check != null && check.Controlled)
			{
				Caster.SendLocalizedMessage(1061605); // You already have a familiar.
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.CloseGump(typeof(CompagnonAnimalGump));
				Caster.SendGump(new CompagnonAnimalGump(Caster, m_Entries, this));
			}

			FinishSequence();
		}

		private static readonly CompagnonAnimalEntry[] m_Entries = new CompagnonAnimalEntry[]
		{
			new CompagnonAnimalEntry(typeof(Rabbit), "Rabbit", 30.0), //1
			new CompagnonAnimalEntry(typeof(Hind), "Hind", 40.0), //2
			new CompagnonAnimalEntry(typeof(Pig), "Pig", 40.0), //2
			new CompagnonAnimalEntry(typeof(Eagle), "Eagle", 40.0), //2
			new CompagnonAnimalEntry(typeof(GreyWolf), "Grey Wolf", 50.0), //3
			new CompagnonAnimalEntry(typeof(Horse), "Horse", 50.0), //3
			new CompagnonAnimalEntry(typeof(Llama), "Llama", 50.0), //3
			new CompagnonAnimalEntry(typeof(SnowLeopard), "Snow Leopard", 60.0), //4
			new CompagnonAnimalEntry(typeof(Alligator), "Alligator", 60.0), //4
			new CompagnonAnimalEntry(typeof(GrizzlyBear), "Grizzly Bear", 70.0), //5
            new CompagnonAnimalEntry(typeof(Walrus), "Walrus", 70.0), //5
			new CompagnonAnimalEntry(typeof(GiantSerpent), "Giant Serpent", 80.0), //6
            new CompagnonAnimalEntry(typeof(Scorpion), "Scorpion", 80.0), //6
			new CompagnonAnimalEntry(typeof(Gorilla), "Gorilla", 80.0), //6
			new CompagnonAnimalEntry(typeof(PolarBear), "Polar Bear", 90.0), //7
		};

		public static CompagnonAnimalEntry[] Entries => m_Entries;
	}

	public class CompagnonAnimalEntry
	{
		public Type Type { get; private set; }
		public string Name { get; private set; }
		public double ReqTracking { get; private set; }

		public CompagnonAnimalEntry(Type type, string name, double reqTracking)
		{
			Type = type;
			Name = name;
			ReqTracking = reqTracking;
		}
	}

	public class CompagnonAnimalGump : BaseProjectMGump
	{
		private readonly Mobile m_From;
		private readonly CompagnonAnimalEntry[] m_Entries;

		private readonly CompagnonAnimalSpell m_Spell;

		public CompagnonAnimalGump(Mobile from, CompagnonAnimalEntry[] entries, CompagnonAnimalSpell spell) : base("Compagnon animal", 200, 300, false)
		{
			m_From = from;
			m_Entries = entries;
			m_Spell = spell;

			AddPage(0);

			double castSkill = from.Skills[m_Spell.CastSkill].Value;

			for (int i = 0; i < entries.Length; ++i)
			{
				string name = entries[i].Name;

				if (castSkill >= entries[i].ReqTracking)
					AddButton(75, 85 + (i * 20), 9702, 9703, i + 1, GumpButtonType.Reply, 0);

				AddHtmlTexte(100, 83 + (i * 20), 150, 20, name);
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			int index = info.ButtonID - 1;

			if (index >= 0 && index < m_Entries.Length)
			{
				CompagnonAnimalEntry entry = m_Entries[index];

				double necro = m_From.Skills[m_Spell.CastSkill].Value;
				double evalInt = m_From.Skills[m_Spell.DamageSkill].Value;

				BaseCreature check = (BaseCreature)CompagnonAnimalSpell.Table[m_From];

				if (check != null && !check.Deleted)
				{
					m_From.SendMessage("Vous avez d�j� un compagnon."); // You already have a familiar.
				}
				else if (necro < entry.ReqTracking)
				{
					m_From.SendMessage($"Ce compagnon animal requiert {entry.ReqTracking}% de Tracking");

					m_From.CloseGump(typeof(CompagnonAnimalGump));
					m_From.SendGump(new CompagnonAnimalGump(m_From, CompagnonAnimalSpell.Entries, m_Spell));
				}
				else if (entry.Type == null)
				{
					m_From.SendMessage("Ce compagnon animal n'a pas �t� d�fini encore.");

					m_From.CloseGump(typeof(CompagnonAnimalGump));
					m_From.SendGump(new CompagnonAnimalGump(m_From, CompagnonAnimalSpell.Entries, m_Spell));
				}
				else
				{
					try
					{
						BaseCreature bc = (BaseCreature)Activator.CreateInstance(entry.Type);

						if (BaseCreature.Summon(bc, true, m_From, m_From.Location, -1, TimeSpan.FromDays(1.0)))
						{
							m_From.FixedParticles(0x3728, 1, 10, 9910, EffectLayer.Head);
							bc.PlaySound(bc.GetIdleSound());
							CompagnonAnimalSpell.Table[m_From] = bc;
						}
					}
					catch (Exception e)
					{
						Diagnostics.ExceptionLogging.LogException(e);
					}
				}
			}
			else
			{
				m_From.SendMessage("Vous d�cidez de ne pas appeler un compagnon animal");
			}
		}
	}
}
