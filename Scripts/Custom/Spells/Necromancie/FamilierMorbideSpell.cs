using System;
using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class FamilierMorbideSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Familier morbide", "Familier morbide",
				SpellCircle.Fourth,
				203,
				9051,
				Reagent.BatWing,
				Reagent.GraveDust
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FamilierMorbideSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
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
				Caster.CloseGump(typeof(FamilierMorbideGump));
				Caster.SendGump(new FamilierMorbideGump(Caster, m_Entries, this));
			}

			FinishSequence();
		}

		private static readonly FamilierMorbideEntry[] m_Entries = new FamilierMorbideEntry[]
		{
			new FamilierMorbideEntry(typeof(HordeMinionFamiliar), 1060146, 30.0, 30.0), // Horde Minion
            new FamilierMorbideEntry(typeof(ShadowWispFamiliar), 1060142, 50.0, 50.0), // Shadow Wisp
            new FamilierMorbideEntry(typeof(DarkWolfFamiliar), 1060143, 60.0, 60.0), // Dark Wolf
            new FamilierMorbideEntry(typeof(DeathAdder), 1060145, 80.0, 80.0), // Death Adder
            new FamilierMorbideEntry(typeof(VampireBatFamiliar), 1060144, 100.0, 100.0)// Vampire Bat
        };

		public static FamilierMorbideEntry[] Entries => m_Entries;
	}

	public class FamilierMorbideEntry
	{
		private readonly Type m_Type;
		private readonly object m_Name;
		private readonly double m_ReqNecromancy;
		private readonly double m_ReqEvalInt;

		public Type Type => m_Type;
		public object Name => m_Name;
		public double ReqNecromancy => m_ReqNecromancy;
		public double ReqEvalInt => m_ReqEvalInt;

		public FamilierMorbideEntry(Type type, object name, double reqNecromancy, double reqEvalInt)
		{
			m_Type = type;
			m_Name = name;
			m_ReqNecromancy = reqNecromancy;
			m_ReqEvalInt = reqEvalInt;
		}
	}

	public class FamilierMorbideGump : Gump
	{
		private readonly Mobile m_From;
		private readonly FamilierMorbideEntry[] m_Entries;

		private readonly FamilierMorbideSpell m_Spell;

		private const int EnabledColor16 = 0x0F20;
		private const int DisabledColor16 = 0x262A;

		private const int EnabledColor32 = 0x18CD00;
		private const int DisabledColor32 = 0x4A8B52;

		public FamilierMorbideGump(Mobile from, FamilierMorbideEntry[] entries, FamilierMorbideSpell spell)
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

			double necro = from.Skills[SkillName.Necromancy].Value;
			double evalInt = from.Skills[SkillName.EvalInt].Value;

			for (int i = 0; i < entries.Length; ++i)
			{
				object name = entries[i].Name;

				bool enabled = (necro >= entries[i].ReqNecromancy && evalInt >= entries[i].ReqEvalInt);

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
				FamilierMorbideEntry entry = m_Entries[index];

				double necro = m_From.Skills[SkillName.Necromancy].Value;
				double evalInt = m_From.Skills[SkillName.EvalInt].Value;

				BaseCreature check = (BaseCreature)FamilierMorbideSpell.Table[m_From];

				if (check != null && !check.Deleted)
				{
					m_From.SendLocalizedMessage(1061605); // You already have a familiar.
				}
				else if (necro < entry.ReqNecromancy || evalInt < entry.ReqEvalInt)
				{
					// That familiar requires ~1_NECROMANCY~ Necromancy and ~2_SPIRIT~ Spirit Speak.
					m_From.SendLocalizedMessage(1061606, string.Format("{0:F1}\t{1:F1}", entry.ReqNecromancy, entry.ReqEvalInt));

					m_From.CloseGump(typeof(FamilierMorbideGump));
					m_From.SendGump(new FamilierMorbideGump(m_From, FamilierMorbideSpell.Entries, m_Spell));
				}
				else if (entry.Type == null)
				{
					m_From.SendMessage("That familiar has not yet been defined.");

					m_From.CloseGump(typeof(FamilierMorbideGump));
					m_From.SendGump(new FamilierMorbideGump(m_From, FamilierMorbideSpell.Entries, m_Spell));
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
							FamilierMorbideSpell.Table[m_From] = bc;
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