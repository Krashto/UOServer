namespace Server.Custom.Classes
{
	public class ClasseInfo
	{
		public Classe Classe { get; private set; }
		public int Level { get; private set; }
		public ClasseMode ClasseMode { get; private set; }
		public Classe ClasseAvant { get; private set; }
		public CAptitudes[] Aptitudes { get; private set; }
		public CCapacites[] Capacites { get; private set; }
		public CSkills[] Skills { get; private set; }
		public string Nom { get; private set; }
		public ClasseBranche ClasseBranche { get; private set; }
		public bool Active { get; private set; }

		public ClasseInfo(Classe classe, int level, ClasseMode classeMode, Classe classeAvant, CAptitudes[] aptitudes, CCapacites[] capacites, CSkills[] skills, string name, ClasseBranche branche, bool active)
		{
			Classe = classe;
			Level = level;
			ClasseMode = classeMode;
			ClasseAvant = classeAvant;
			Aptitudes = aptitudes;
			Capacites = capacites;
			Skills = skills;
			Nom = name;
			ClasseBranche = branche;
			Active = active;
		}
	}
}
