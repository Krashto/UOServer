using System.Collections.Generic;
using Server.Custom.Aptitudes;
using Server.Custom.Items.SouvenirsAncestraux.Souvenirs;
using Server.Items;

namespace Server.Custom.SouvenirsAncestraux
{
	public class NewSetSystem
	{
		public interface INewSetItem
		{
			int SetHue { get; set; }
			SetAptitudeType SetAptitudeType { get; set; }
		}

		public static int CalculatePieceCount(INewSetItem addedSetItem, Mobile to, SetAptitudeType type)
		{
			int count = 0;

			for (int i = 0; i < to.Items.Count; i++)
			{
				if (to.Items[i] is INewSetItem setItem)
				{
					if (setItem.SetAptitudeType == type)
						count++;
				}
			}

			//if (addedSetItem != null)
			//	count++;

			return count;
		}

		public static SetAptitudeType GetSetTypeByAptitude(Aptitude apt)
		{
			var type = (SetAptitudeType)(-1);

			switch (apt)
			{
				case Aptitude.Martial:		type = SetAptitudeType.Martial;		break;
				case Aptitude.Chasseur:		type = SetAptitudeType.Chasseur;	break;
				case Aptitude.Roublardise:	type = SetAptitudeType.Roublardise; break;
				case Aptitude.Polymorphie:	type = SetAptitudeType.Polymorphie; break;
				case Aptitude.Totemique:	type = SetAptitudeType.Totemique;	break;
				case Aptitude.Musique:		type = SetAptitudeType.Musique;		break;
				case Aptitude.Hydromancie:	type = SetAptitudeType.Hydromancie; break;
				case Aptitude.Pyromancie:	type = SetAptitudeType.Pyromancie;	break;
				case Aptitude.Geomancie:	type = SetAptitudeType.Geomancie;	break;
				case Aptitude.Aeromancie:	type = SetAptitudeType.Aeromancie;	break;
				case Aptitude.Necromancie:	type = SetAptitudeType.Necromancie; break;
				case Aptitude.Defenseur:	type = SetAptitudeType.Defenseur;	break;
				case Aptitude.Guerison:		type = SetAptitudeType.Guerison;	break;
			}

			return type;
		}

		public static Aptitude GetAptitudeBySetType(SetAptitudeType type)
		{
			var apt = (Aptitude)(-1);

			switch (type)
			{
				case SetAptitudeType.Martial:		apt = Aptitude.Martial;		break;
				case SetAptitudeType.Chasseur:		apt = Aptitude.Chasseur;	break;
				case SetAptitudeType.Roublardise:	apt = Aptitude.Roublardise;	break;
				case SetAptitudeType.Polymorphie:	apt = Aptitude.Polymorphie;	break;
				case SetAptitudeType.Totemique:		apt = Aptitude.Totemique;	break;
				case SetAptitudeType.Musique:		apt = Aptitude.Musique;		break;
				case SetAptitudeType.Hydromancie:	apt = Aptitude.Hydromancie;	break;
				case SetAptitudeType.Pyromancie:	apt = Aptitude.Pyromancie;	break;
				case SetAptitudeType.Geomancie:		apt = Aptitude.Geomancie;	break;
				case SetAptitudeType.Aeromancie:	apt = Aptitude.Aeromancie;	break;
				case SetAptitudeType.Necromancie:	apt = Aptitude.Necromancie;	break;
				case SetAptitudeType.Defenseur:		apt = Aptitude.Defenseur;	break;
				case SetAptitudeType.Guerison:		apt = Aptitude.Guerison;	break;
			}

			return apt;
		}

		public static int GetSetBonus(INewSetItem setItem, Mobile to, Aptitude apt)
		{
			var type = GetSetTypeByAptitude(apt);

			if (type == (SetAptitudeType)(-1))
				return 0;

			var count = CalculatePieceCount(setItem, to, type);

			if (count >= 6)
				return 3;
			else if (count >= 4)
				return 2;
			else if (count >= 2)
				return 1;

			return 0;
		}

		public static void InvalidateEquipedArmorProperties(Mobile to, INewSetItem setItem)
		{
			if (setItem is BaseArmor armor)
				armor.InvalidateProperties();

			if (to != null && to.Items != null)
			{
				for (int i = 0; i < to.Items.Count; i++)
				{
					if (to.Items[i] is INewSetItem equipedSetItem)
					{
						if (equipedSetItem is BaseArmor equipedArmor)
							equipedArmor.InvalidateProperties();
					}
				}
			}
		}

		public static List<string> GetBonusMessageList(INewSetItem setItem, Mobile to, SetAptitudeType type)
		{
			var list = new List<string>();

			var apt = GetAptitudeBySetType(type);

			var bonus = 0;
			
			if (to != null)
				bonus = GetSetBonus(setItem, to, apt);

			if (bonus == 3)
			{
				list.Add($"<BASEFONT COLOR=#808080>2 items de set: {apt} +1</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#808080>4 items de set: {apt} +2</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#FFFFFF>6 items de set: {apt} +3</BASEFONT>");
			}
			else if (bonus == 2)
			{
				list.Add($"<BASEFONT COLOR=#808080>2 items de set: {apt} +1</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#FFFFFF>4 items de set: {apt} +2</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#808080>6 items de set: {apt} +3</BASEFONT>");
			}
			else if (bonus == 1)
			{
				list.Add($"<BASEFONT COLOR=#FFFFFF>2 items de set: {apt} +1</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#808080>4 items de set: {apt} +2</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#808080>6 items de set: {apt} +3</BASEFONT>");
			}
			else
			{
				list.Add($"<BASEFONT COLOR=#808080>2 items de set: {apt} +1</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#808080>4 items de set: {apt} +2</BASEFONT>");
				list.Add($"<BASEFONT COLOR=#808080>6 items de set: {apt} +3</BASEFONT>");
			}

			return list;
		}
	}
}
