#region References
using System;
using Server.Mobiles;
using System.Reflection;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.Accounting;
using Server.Custom.Classes;


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
		private StatutSocialEnum m_Statut = StatutSocialEnum.Peregrin;

		private int m_Str = 25;
		private int m_Dex = 25;
		private int m_Int = 25;

		private CustomPlayerMobile m_Player;

		private Reroll m_Reroll;

		private AppearanceEnum m_Appearance = (AppearanceEnum)(-1);
		private GrandeurEnum m_Grandeur = (GrandeurEnum)(-1);
		private CorpulenceEnum m_Grosseur = (CorpulenceEnum)(-1);
		private Classe m_Classe = (Classe)(-1);
		private Classe m_Metier = (Classe)(-1);

		public BaseRace Race
        {
            get => m_Race;
            set
            {
                if (m_Race != value)
                {
                    ChangeRace();
                }
                m_Race = value;
            }
             
        }

		public int Str
		{
			get => m_Str;
			set
			{
				if (value + m_Dex + m_Int > 225)
					m_Str = 225 - m_Dex - m_Int;
				else if (value < 25)
					m_Str = 25;
				else if (value > 100)
					m_Str = 100;
				else
					m_Str = value;
			}
		}

		public int Dex
		{
			get => m_Dex;
			set
			{
				if (m_Str + value + m_Int > 225)
					m_Dex = 225 - m_Str - m_Int;
				else if (value < 25)
					m_Dex = 25;
				else if (value > 100)
					m_Dex = 100;
				else
					m_Dex = value;
			}
		}

		public int Int
		{
			get => m_Int;
			set
			{
				if (m_Str + m_Dex + value > 225)
					m_Int = 225 - m_Str - m_Dex;
				else if (value < 25)
					m_Int = 25;
				else if (value > 100)
					m_Int = 100;
				else
					m_Int = value;
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

		public void ChangeClasse()
		{		
			m_Metier = (Classe)(-1);
		}

		public void ChangeMetier()
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

		public bool Statistique()
		{
			if (m_Int + m_Dex + m_Str == 225)
				return true;

			return false;
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
			return (225 - m_Str - m_Dex - m_Int);
		}

		public void Valide()
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

			m_Player.Classe = Classe.Aucune;

			m_Player.AddToBackpack(new Gold(5000));

			m_Player.MoveToWorld(new Point3D(1183, 3725, 37), Map.Felucca);
			m_Player.Blessed = false;
			Robe robe = new Robe();

			m_Player.AddItem(robe);
		}
    }
}
