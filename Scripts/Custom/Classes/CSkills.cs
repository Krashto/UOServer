namespace Server.Custom.Classes
{
	public class CSkills
	{
		private SkillName m_SkillName;
		private double m_Value;

		public SkillName SkillName { get { return m_SkillName; } }
		public double Value { get { return m_Value; } }

		public CSkills(SkillName skillName, double value)
		{
			m_SkillName = skillName;
			m_Value = value;
		}
	}
}
