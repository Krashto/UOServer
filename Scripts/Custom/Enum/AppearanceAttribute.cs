using System;

namespace Server
{
	public class AppearanceAttribute : Attribute
	{
		public string MaleAdjective { get; set; }
		public string FemaleAdjective { get; set; }

		public AppearanceAttribute(string maleAdjective, string femaleAdjective)
		{
			MaleAdjective = maleAdjective;
			FemaleAdjective = femaleAdjective;
		}
	}
}
