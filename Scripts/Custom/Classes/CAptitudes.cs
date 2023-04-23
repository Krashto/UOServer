using Server.Custom.Aptitudes;

namespace Server.Custom.Classes
{
	public class CAptitudes
	{
		private Aptitude m_Aptitude;
		private int m_Value;

		public Aptitude Aptitude { get { return m_Aptitude; } }
		public int Value { get { return m_Value; } }

		public CAptitudes(Aptitude aptitude, int value)
		{
			m_Aptitude = aptitude;
			m_Value = value;
		}
	}
}
