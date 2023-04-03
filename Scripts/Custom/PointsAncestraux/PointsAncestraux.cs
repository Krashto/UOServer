using System.Collections.Generic;
using Server.Mobiles;

namespace Server.Custom.PointsAncestraux
{
	public enum PointsAncestrauxBonusType
	{
		SkillTactics,
		SkillAnatomy,
		SkillEvalInt,
	}

	public class PointsAncestrauxBonusEntry
	{
		public PointsAncestrauxBonusType Type { get; set; }
		public string Name { get; set; }

		public PointsAncestrauxBonusEntry(PointsAncestrauxBonusType type)
		{
			Type = type;
			Name = PointsAncestraux.GetNameByType(type);
		}
		public PointsAncestrauxBonusEntry(PointsAncestrauxBonusType type, string name)
		{
			Type = type;
			Name = name;
		}

		public PointsAncestrauxBonusEntry(GenericReader reader)
		{
			int version = reader.ReadInt();

			Type = (PointsAncestrauxBonusType)reader.ReadInt();
			Name = reader.ReadString();
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write((int)0); // version;

			//Version 0
			writer.Write((int)Type);
			writer.Write(Name);
		}
	}

	public class PointsAncestraux
	{
		private CustomPlayerMobile m_Owner;
		public List<PointsAncestrauxBonusEntry> ActiveBonus;

		#region Props
		[CommandProperty(AccessLevel.GameMaster)]
		public int Bank { get; set; }
		#endregion

		public void AddPoints(int value)
		{
			Bank += value;
		}

		public bool RemovePoints(int value)
		{
			if (Bank > value)
			{
				m_Owner.SendMessage("Vous n'avez pas suffisament de points pour ça.");
				return false;
			}

			Bank -= value;
			return true;
		}

		public void RemovePointsNoCheck(int value)
		{
			Bank -= value;
			if (Bank < 0)
				Bank = 0;
		}
		public void Reset()
		{
			Bank = 0;
			ActiveBonus = new List<PointsAncestrauxBonusEntry>();
		}

		public static double GetBonusValue(PointsAncestrauxBonusType type)
		{
			switch (type)
			{
				case PointsAncestrauxBonusType.SkillTactics: return 5.0;
				case PointsAncestrauxBonusType.SkillAnatomy: return 5.0;
				case PointsAncestrauxBonusType.SkillEvalInt: return 5.0;
			}

			return 0;
		}

		public static string GetNameByType(PointsAncestrauxBonusType type)
		{
			switch (type)
			{
				case PointsAncestrauxBonusType.SkillTactics: return "Bonus de Tactics";
				case PointsAncestrauxBonusType.SkillAnatomy: return "Bonus d'Anatomy";
				case PointsAncestrauxBonusType.SkillEvalInt: return "Bonus d'Eval Intel";
			}

			return "Unknown";
		}

		public bool ActivateBonus(PointsAncestrauxBonusType type)
		{
			var entry = new PointsAncestrauxBonusEntry(type);

			if (ActiveBonus.Contains(entry))
			{
				m_Owner.SendMessage("Ce bonus est déjà activé.");
				return false;
			}

			ActiveBonus.Add(entry);
			return true;
		}

		public bool DeactivateBonus(PointsAncestrauxBonusType type)
		{
			var entry = new PointsAncestrauxBonusEntry(type);

			if (!ActiveBonus.Contains(entry))
			{
				m_Owner.SendMessage("Ce bonus n'est pas actif.");
				return false;
			}

			ActiveBonus.Remove(entry);
			return true;
		}

		public PointsAncestraux(CustomPlayerMobile owner)
		{
			m_Owner = owner;
			Reset();
		}

		public PointsAncestraux(CustomPlayerMobile owner, GenericReader reader)
		{
			m_Owner = owner;

			int version = reader.ReadInt();

			Bank = reader.ReadInt();

			var count = reader.ReadInt();

			ActiveBonus = new List<PointsAncestrauxBonusEntry>();

			for (int i = 0; i < count; i++)
				ActiveBonus.Add(new PointsAncestrauxBonusEntry(reader));
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write((int)0); // version;

			//Version 0
			writer.Write(Bank);
			writer.Write(ActiveBonus.Count);

			foreach (var bonus in ActiveBonus)
				bonus.Serialize(writer);
		}
	}
}
