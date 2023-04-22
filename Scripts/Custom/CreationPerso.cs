#region References
using System;
using Server.Mobiles;
using System.Reflection;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.Accounting;
using Server.Custom.Classes;
using System.Linq;


#endregion

namespace Server
{
    [Parsable]
    public class CreationPerso
    {
        private BaseRace m_Race;
        private int m_Hue;
        private bool m_female;
		private string m_Name;

		private int m_Str = 25;
		private int m_Dex = 25;
		private int m_Int = 25;
		private int m_Const = 25;
		private int m_Endur = 25;
		private int m_Sag = 25;

		private CustomPlayerMobile m_Player;

		private Reroll m_Reroll;

		private AppearanceEnum m_Appearance = (AppearanceEnum)(-1);
		private GrandeurEnum m_Grandeur = (GrandeurEnum)(-1);
		private CorpulenceEnum m_Grosseur = (CorpulenceEnum)(-1);

		public BaseRace Race
        {
            get => m_Race;
            set
            {
                if (m_Race != value)
                    ChangeRace();
                m_Race = value;
            }
        }

		public int Str
		{
			get => m_Str;
			set
			{
				if (value + m_Dex + m_Int + m_Const + m_Endur + m_Sag > Attributs.MaxStats)
					m_Str = Attributs.MaxStats - (m_Dex + m_Int + m_Const + m_Endur + m_Sag);
				else if (value < Attributs.MinStat)
					m_Str = Attributs.MinStat;
				else if (value > Attributs.MaxStat)
					m_Str = Attributs.MaxStat;
				else
					m_Str = value;
			}
		}

		public int Dex
		{
			get => m_Dex;
			set
			{
				if (value + m_Str + m_Int + m_Const + m_Endur + m_Sag > Attributs.MaxStats)
					m_Dex = Attributs.MaxStats - (m_Str + m_Int + m_Const + m_Endur + m_Sag);
				else if (value < Attributs.MinStat)
					m_Dex = Attributs.MinStat;
				else if (value > Attributs.MaxStat)
					m_Dex = Attributs.MaxStat;
				else
					m_Dex = value;
			}
		}

		public int Int
		{
			get => m_Int;
			set
			{
				if (value + m_Str + m_Dex + m_Const + m_Endur + m_Sag > Attributs.MaxStats)
					m_Int = Attributs.MaxStats - (m_Str + m_Dex + m_Const + m_Endur + m_Sag);
				else if (value < Attributs.MinStat)
					m_Int = Attributs.MinStat;
				else if (value > Attributs.MaxStat)
					m_Int = Attributs.MaxStat;
				else
					m_Int = value;
			}
		}

		public int Const
		{
			get => m_Const;
			set
			{
				if (value + m_Str + m_Dex + m_Int + m_Endur + m_Sag > Attributs.MaxStats)
					m_Const = Attributs.MaxStats - (m_Str + m_Dex + m_Int + m_Endur + m_Sag);
				else if (value < Attributs.MinStat)
					m_Const = Attributs.MinStat;
				else if (value > Attributs.MaxStat)
					m_Const = Attributs.MaxStat;
				else
					m_Const = value;
			}
		}

		public int Endur
		{
			get => m_Endur;
			set
			{
				if (value + m_Str + m_Dex + m_Int + m_Const + m_Sag > Attributs.MaxStats)
					m_Endur = Attributs.MaxStats - (m_Str + m_Dex + m_Int + m_Const + m_Sag);
				else if (value < Attributs.MinStat)
					m_Endur = Attributs.MinStat;
				else if (value > Attributs.MaxStat)
					m_Endur = Attributs.MaxStat;
				else
					m_Endur = value;
			}
		}

		public int Sag
		{
			get => m_Sag;
			set
			{
				if (value + m_Str + m_Dex + m_Int + m_Const + m_Endur > Attributs.MaxStats)
					m_Sag = Attributs.MaxStats - (m_Str + m_Dex + m_Int + m_Const + m_Endur);
				else if (value < Attributs.MinStat)
					m_Sag = Attributs.MinStat;
				else if (value > Attributs.MaxStat)
					m_Sag = Attributs.MaxStat;
				else
					m_Sag = value;
			}
		}

		public string Name { get => m_Name; set => m_Name = value; }
		public int Hue { get => m_Hue; set => m_Hue = value; }
		public AppearanceEnum Appearance { get => m_Appearance; set => m_Appearance = value; }
		public GrandeurEnum Grandeur { get => m_Grandeur; set => m_Grandeur = value; }
		public CorpulenceEnum Grosseur { get => m_Grosseur; set => m_Grosseur = value; }

		public bool Female
        {
            get => m_female;
            set
            {
                if (m_female != value)
                    ChangeSexe();

                m_female = value;
            }
       }

		public Reroll Reroll { get => m_Reroll; set => m_Reroll = value; }

		public CreationPerso(CustomPlayerMobile player)
        {
			m_female = player.Female;
			m_Name = player.Name;
			m_Player = player;

			foreach(var skill in m_Player.Skills)
			{
				skill.Base = 0;
				skill.Cap = 50;
				skill.SetLockNoRelay(SkillLock.Locked);
			}

			m_Player.Aptitudes.Reset();
			m_Player.Classe = Classe.Aucune;
			m_Player.Race.RemoveRace(m_Player);
		}
    
        public void ChangeRace()
        {
            m_Hue = -1;
			m_Appearance = (AppearanceEnum)(-1);
			m_Grandeur = (GrandeurEnum)(-1);
			m_Grosseur = (CorpulenceEnum)(-1);
		}

        public void ChangeSexe()
        {
            
        }

		public bool InfoGeneral()
		{
			if (m_Appearance == (AppearanceEnum)(-1) || m_Grandeur == (GrandeurEnum)(-1) || m_Grosseur == (CorpulenceEnum)(-1))
				return false;
			else if (Name.Length < 3)
				return false;
			else
				return true;
		}

		public bool CheckStats()
		{
			if (m_Str + m_Dex + m_Int + m_Const + m_Endur + m_Sag == Attributs.MaxStats)
				return true;

			return false;
		}

		public bool CheckSkills()
		{
			return m_Player.Skills.Sum(x => x.Value) == 150;
		}

		public string GetApparence()
		{
			if (m_Appearance != (AppearanceEnum)(-1))
			{
				var type = typeof(AppearanceEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Appearance.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return String.Empty;
		}

		public string GetGrosseur()
		{
			if (Grosseur != (CorpulenceEnum)(-1))
			{
				var type = typeof(CorpulenceEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Grosseur.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return String.Empty;
		}

		public string GetGrandeur()
		{
			if (Grandeur != (GrandeurEnum)(-1))
			{
				var type = typeof(GrandeurEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Grandeur.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return String.Empty;
		}

		public int GetPointsRestants()
		{
			return Attributs.MaxStats - (m_Str + m_Dex + m_Int + m_Const + m_Endur + m_Sag);
		}

		public void Validate()
        {
			m_Player.BaseFemale = m_female;
			m_Player.BaseRace = m_Race;
			m_Player.Race.RemoveRace(m_Player);
			Race.AddRace(m_Player, m_Hue);
			m_Player.Name = m_Name;
			m_Player.Beaute = m_Appearance;
			m_Player.Grandeur = m_Grandeur;
			m_Player.Grosseur = m_Grosseur;
			m_Player.BaseHue = m_Hue;

			m_Player.InitStats(m_Str, m_Dex, m_Int);
			m_Player.Attributs[Attribut.Constitution] = m_Const;
			m_Player.Attributs[Attribut.Endurance] = m_Endur;
			m_Player.Attributs[Attribut.Sagesse] = m_Sag;

			m_Player.Classe = Classe.Aucune;

			foreach (var skill in m_Player.Skills)
			{
				skill.Cap = 50;
				skill.SetLockNoRelay(SkillLock.Locked);
			}

			m_Player.AddToBackpack(new Gold(1000));

			m_Player.MoveToWorld(new Point3D(1069, 1410, -1), Map.Felucca);
			m_Player.Blessed = false;

			Robe robe = new Robe();
			m_Player.AddItem(robe);
		}
    }
}
