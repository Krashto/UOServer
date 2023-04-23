using Server.Custom.Capacites;

namespace Server.Custom.Classes
{
	public class CCapacites
	{
		private Capacite m_Capacite;
		private int m_Value;

		public Capacite Capacite { get { return m_Capacite; } }
		public int Value { get { return m_Value; } }

		public CCapacites(Capacite capacite, int value)
		{
			m_Capacite = capacite;
			m_Value = value;
		}
	}
}
