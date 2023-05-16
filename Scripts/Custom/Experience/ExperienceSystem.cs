using System;
using Server.Mobiles;
using Server.Commands;
using Server.Custom;
using Server.Items;
using Server.Custom.Classes;

namespace Server.CustomScripts.Systems.Experience
{
    class NiveauCommande
    {
        public static void Initialize()
        {
            CommandSystem.Register("Exp", AccessLevel.Player, new CommandEventHandler(GetExp_OnCommande));
            CommandSystem.Register("ResetTicks", AccessLevel.Owner, new CommandEventHandler(ResetTicks_OnCommande));
            CommandSystem.Register("ResetAllLevel", AccessLevel.Owner, new CommandEventHandler(ResetAllLevel_OnCommande));
            CommandSystem.Register("ResetAllTicks", AccessLevel.Owner, new CommandEventHandler(ResetAllTicks_OnCommande));
        }

        [Usage("Exp")]
        [Description("Get your exp")]
        public static void GetExp_OnCommande(CommandEventArgs e)
        {
            if (e.Mobile is CustomPlayerMobile)
            {
                CustomPlayerMobile from = (CustomPlayerMobile)e.Mobile;
                from.SendMessage("Vos points d'expérience: " + from.Experience.Exp.ToString());
            }
        }

        [Usage("ResetTicks")]
        [Description("Reset Ticks")]
        public static void ResetTicks_OnCommande(CommandEventArgs e)
        {
            if (e.Mobile is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)e.Mobile;

                ExperienceSystem exp = pm.Experience;
                exp.ResetTicks();
            }
        }

        [Usage("ResetAllLevel")]
        [Description("Reset All Levels")]
        public static void ResetAllLevel_OnCommande(CommandEventArgs e)
        {
            foreach (Mobile m in World.Mobiles.Values)
            {
                CustomPlayerMobile pm = m as CustomPlayerMobile;
                if (pm != null)
                {
                    pm.Experience.Niveau = 0;
                    Experience.CheckEvolve(pm);
                }
            }
        }

        [Usage("ResetAllTicks")]
        [Description("Reset All Ticks")]
        public static void ResetAllTicks_OnCommande(CommandEventArgs e)
        {
            ExperienceSystem.ResetAllTicks();
        }
    }

    [PropertyObject]
    public class ExperienceSystem
    {
		private CustomPlayerMobile m_From;

        public const int ExpGainPerTick = 200;
        public const int MaxExpAllowedByDay = 1000;
		public int MaxExpRetard => ((new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0) - new DateTime(CustomPersistence.Ouverture.Year, CustomPersistence.Ouverture.Month, CustomPersistence.Ouverture.Day, 18, 0, 0)).Days + 1) * MaxExpAllowedByDay;

        [CommandProperty(AccessLevel.GameMaster)]
		public int Exp { get; set; }
		[CommandProperty(AccessLevel.GameMaster)]
		public int Niveau { get; set; }
		[CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextTickExp { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ExpToGainBank { get; set; }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(Exp);
            writer.Write(Niveau);
            writer.Write(NextTickExp);
            writer.Write(ExpToGainBank);
        }

        public ExperienceSystem(CustomPlayerMobile from, GenericReader reader)
        {
			m_From = from;

			int version = reader.ReadInt();

            Exp = reader.ReadInt();
            Niveau = reader.ReadInt();
            NextTickExp = reader.ReadDateTime();
            ExpToGainBank = reader.ReadInt();
        }

        public ExperienceSystem(CustomPlayerMobile from)
        {
			m_From = from;

			NextTickExp = DateTime.Now.AddMinutes(Experience.Interval_Minutes);
            ExpToGainBank = MaxExpAllowedByDay;
        }

        public void ResetTicks()
        {
            ExpToGainBank += MaxExpAllowedByDay;

			if (ExpToGainBank + Exp < MaxExpRetard)
				ExpToGainBank = MaxExpRetard - Exp;

			if (ExpToGainBank + Exp > MaxExpRetard)
			{
				Exp = MaxExpRetard;
				ExpToGainBank = 0;
				Niveau = Experience.GetLevelByExp(m_From);
				m_From.Validate(CustomPlayerMobile.ValidateType.All);
				m_From.Aptitudes.Reset();
			}
		}

        public static void ResetAllTicks()
        {
            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is CustomPlayerMobile)
                    ((CustomPlayerMobile)m).Experience.ResetTicks();
            }
        }

        public void Tick(CustomPlayerMobile pm)
        {
            if (pm == null || pm.Experience != this || NextTickExp >= DateTime.Now)
                return;

            NextTickExp = DateTime.Now.AddMinutes(Experience.Interval_Minutes);

            if (pm.Jail)
            {
                pm.SendMessage("Vous êtes en jail, vous ne gagnez donc pas d'expérience.");
                return;
            }

            if (ExpToGainBank > 0)
            {
                int value = ExpToGainBank > ExpGainPerTick ? ExpGainPerTick : ExpToGainBank;
                ExpToGainBank -= value;
                Exp += value;
            }
        }
    }
}
