using Server.Custom.Classes;
using Server.Mobiles;
using Server.Network;
using System;

namespace Server.CustomScripts.Systems.Experience
{
    public class Experience
    {
        public static int Interval_Minutes = 10;
        private static TimeSpan m_IntervalXp = TimeSpan.FromMinutes(Interval_Minutes);

        public static DateTime LastReset = DateTime.Now;
        public static int MaxLevel = 50;

        public static void Initialize()
        {
            new XPTimer().Start();
        }

        public class XPTimer : Timer
        {
            public XPTimer() : base(m_IntervalXp, m_IntervalXp)
            {
                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                foreach (NetState state in NetState.Instances)
                {
                    Mobile m = state.Mobile;

                    if (m != null && m is CustomPlayerMobile)
                    {
                        var pm = (CustomPlayerMobile)m;

                        if (pm.Experience.Niveau < MaxLevel)
                        {
                            pm.Experience.Tick(pm);
                            CheckEvolve(pm);
							Classes.SetBaseAndCapSkills(pm, pm.Experience.Niveau);
						}
					}
                }
            }
        }

        public static int GetLevelByExp(Mobile from)
        {
            int level = MaxLevel;

            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = from as CustomPlayerMobile;

                ExperienceSystem exp = pm.Experience;

                for (int i = 0; (i >= 0) && (GetRequiredExpByLevel(i) > exp.Exp); i--)
                    level = i;
            }
            return level;
        }

        public static int GetRequiredExpByLevel(int level)
        {
            return level * 1000;
        }

        public static int GetNeededXP(ExperienceSystem exp)
        {
            if (exp == null)
                return 1000;

            return GetRequiredExpByLevel(exp.Niveau + 1);
        }

        public static double GetNeededHourByLevel(int niveau)
        {
            return GetRequiredExpByLevel(niveau) / ExperienceSystem.ExpGainPerTick * Interval_Minutes / 60.0;
        }

        public static void CheckEvolve(Mobile from)
        {
            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)from;

                ExperienceSystem exp = pm.Experience;

                int currentXP = exp.Exp;

                int neededXP = GetNeededXP(pm.Experience);

                if (exp.Niveau < MaxLevel)
                {
                    while (currentXP >= neededXP)
                    {
                        exp.Niveau++;
                        pm.SendMessage("Vous gagnez un niveau !");
                        pm.SendMessage("Vous êtes maintenant niveau " + exp.Niveau);

						currentXP = exp.Exp;
                        neededXP = GetNeededXP(pm.Experience);
                    }
                }

                if (exp.Niveau > MaxLevel)
                    exp.Niveau = MaxLevel;
            }
        }
    }
}
