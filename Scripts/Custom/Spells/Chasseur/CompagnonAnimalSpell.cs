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
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
				Reagent.BlackPearl
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

			if (check != null && !check.Deleted)
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
			new CompagnonAnimalEntry(typeof(Rabbit), "Rabbit", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Hind), "Hind", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Pig), "Pig", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Gorilla), "Gorilla", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Eagle), "Eagle", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(GreyWolf), "Grey Wolf", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(SnowLeopard), "Snow Leopard", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Alligator), "Alligator", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Horse), "Horse", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Llama), "Llama", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(GiantSerpent), "Giant Serpent", 40.0, 40.0),
            new CompagnonAnimalEntry(typeof(Scorpion), "Scorpion", 40.0, 40.0),
            new CompagnonAnimalEntry(typeof(Walrus), "Walrus", 60.0, 60.0),
			new CompagnonAnimalEntry(typeof(PolarBear), "Polar Bear", 60.0, 60.0),
			new CompagnonAnimalEntry(typeof(GrizzlyBear), "Grizzly Bear", 60.0, 60.0),
        };

		public static CompagnonAnimalEntry[] Entries => m_Entries;
	}

	public class CompagnonAnimalEntry
	{
		private readonly Type m_Type;
		private readonly string m_Name;
		private readonly double m_ReqNecromancy;
		private readonly double m_ReqEvalInt;

		public Type Type => m_Type;
		public string Name => m_Name;
		public double ReqTracking => m_ReqNecromancy;
		public double ReqEvalInt => m_ReqEvalInt;

		public CompagnonAnimalEntry(Type type, string name, double reqTracking, double reqEvalInt)
		{
			m_Type = type;
			m_Name = name;
			m_ReqNecromancy = reqTracking;
			m_ReqEvalInt = reqEvalInt;
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
			double damageSkill = from.Skills[m_Spell.DamageSkill].Value;

			for (int i = 0; i < entries.Length; ++i)
			{
				string name = entries[i].Name;

				bool enabled = (castSkill >= entries[i].ReqTracking && damageSkill >= entries[i].ReqEvalInt);

				if (enabled)
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
					m_From.SendMessage("Vous avez déjà un compagnon."); // You already have a familiar.
				}
				else if (necro < entry.ReqTracking || evalInt < entry.ReqEvalInt)
				{
					m_From.SendMessage($"Ce compagnon animal requiert {entry.ReqTracking}% de Tracking et {entry.ReqEvalInt}% d'Evaluating Intelligence");

					m_From.CloseGump(typeof(CompagnonAnimalGump));
					m_From.SendGump(new CompagnonAnimalGump(m_From, CompagnonAnimalSpell.Entries, m_Spell));
				}
				else if (entry.Type == null)
				{
					m_From.SendMessage("Ce compagnon animal n'a pas été défini encore.");

					m_From.CloseGump(typeof(CompagnonAnimalGump));
					m_From.SendGump(new CompagnonAnimalGump(m_From, CompagnonAnimalSpell.Entries, m_Spell));
				}
				else
				{
					try
					{
						BaseCreature bc = (BaseCreature)Activator.CreateInstance(entry.Type);

						if (BaseCreature.Summon(bc, m_From, m_From.Location, -1, TimeSpan.FromDays(1.0)))
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
				m_From.SendMessage("Vous décidez de ne pas appeler un compagnon animal");
			}
		}
	}
}
