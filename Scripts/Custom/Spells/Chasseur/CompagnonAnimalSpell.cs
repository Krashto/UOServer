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
			new CompagnonAnimalEntry(typeof(GreyWolf), "GreyWolf", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(SnowLeopard), "Snow Leopard", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Alligator), "Alligator", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Horse), "Horse", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(Llama), "Llama", 30.0, 30.0),
			new CompagnonAnimalEntry(typeof(GiantSerpent), "Giant Serpent", 30.0, 30.0),
            new CompagnonAnimalEntry(typeof(Scorpion), "Scorpion", 60.0, 60.0),
            new CompagnonAnimalEntry(typeof(Walrus), "Walrus", 80.0, 80.0),
			new CompagnonAnimalEntry(typeof(PolarBear), "Polar Bear", 100.0, 100.0),
			new CompagnonAnimalEntry(typeof(GrizzlyBear), "Grizzly Bear", 100.0, 100.0),
        };

		public static CompagnonAnimalEntry[] Entries => m_Entries;
	}

	public class CompagnonAnimalEntry
	{
		private readonly Type m_Type;
		private readonly object m_Name;
		private readonly double m_ReqNecromancy;
		private readonly double m_ReqEvalInt;

		public Type Type => m_Type;
		public object Name => m_Name;
		public double ReqNecromancy => m_ReqNecromancy;
		public double ReqEvalInt => m_ReqEvalInt;

		public CompagnonAnimalEntry(Type type, object name, double reqNecromancy, double reqEvalInt)
		{
			m_Type = type;
			m_Name = name;
			m_ReqNecromancy = reqNecromancy;
			m_ReqEvalInt = reqEvalInt;
		}
	}

	public class CompagnonAnimalGump : Gump
	{
		private readonly Mobile m_From;
		private readonly CompagnonAnimalEntry[] m_Entries;

		private readonly CompagnonAnimalSpell m_Spell;

		private const int EnabledColor16 = 0x0F20;
		private const int DisabledColor16 = 0x262A;

		private const int EnabledColor32 = 0x18CD00;
		private const int DisabledColor32 = 0x4A8B52;

		public CompagnonAnimalGump(Mobile from, CompagnonAnimalEntry[] entries, CompagnonAnimalSpell spell)
			: base(200, 100)
		{
			m_From = from;
			m_Entries = entries;
			m_Spell = spell;

			AddPage(0);

			AddBackground(10, 10, 250, 178, 9270);
			AddAlphaRegion(20, 20, 230, 158);

			AddImage(220, 20, 10464);
			AddImage(220, 72, 10464);
			AddImage(220, 124, 10464);

			AddItem(188, 16, 6883);
			AddItem(198, 168, 6881);
			AddItem(8, 15, 6882);
			AddItem(2, 168, 6880);

			AddHtmlLocalized(30, 26, 200, 20, 1060147, EnabledColor16, false, false); // Chose thy familiar...

			double castSkill = from.Skills[m_Spell.CastSkill].Value;
			double damageSkill = from.Skills[m_Spell.DamageSkill].Value;

			for (int i = 0; i < entries.Length; ++i)
			{
				object name = entries[i].Name;

				bool enabled = (castSkill >= entries[i].ReqNecromancy && damageSkill >= entries[i].ReqEvalInt);

				AddButton(27, 53 + (i * 21), 9702, 9703, i + 1, GumpButtonType.Reply, 0);

				if (name is int)
					AddHtmlLocalized(50, 51 + (i * 21), 150, 20, (int)name, enabled ? EnabledColor16 : DisabledColor16, false, false);
				else if (name is string)
					AddHtml(50, 51 + (i * 21), 150, 20, string.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", enabled ? EnabledColor32 : DisabledColor32, name), false, false);
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
					m_From.SendLocalizedMessage(1061605); // You already have a familiar.
				}
				else if (necro < entry.ReqNecromancy || evalInt < entry.ReqEvalInt)
				{
					// That familiar requires ~1_NECROMANCY~ Necromancy and ~2_SPIRIT~ Spirit Speak.
					m_From.SendLocalizedMessage(1061606, string.Format("{0:F1}\t{1:F1}", entry.ReqNecromancy, entry.ReqEvalInt));

					m_From.CloseGump(typeof(CompagnonAnimalGump));
					m_From.SendGump(new CompagnonAnimalGump(m_From, CompagnonAnimalSpell.Entries, m_Spell));
				}
				else if (entry.Type == null)
				{
					m_From.SendMessage("That familiar has not yet been defined.");

					m_From.CloseGump(typeof(CompagnonAnimalGump));
					m_From.SendGump(new CompagnonAnimalGump(m_From, CompagnonAnimalSpell.Entries, m_Spell));
				}
				else
				{
					try
					{
						BaseCreature bc = (BaseCreature)Activator.CreateInstance(entry.Type);

						bc.Skills.MagicResist = m_From.Skills.MagicResist;

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
				m_From.SendLocalizedMessage(1061825); // You decide not to summon a familiar.
			}
		}
	}
}
