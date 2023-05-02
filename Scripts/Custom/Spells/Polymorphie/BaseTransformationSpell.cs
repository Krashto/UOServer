namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class BaseTransformationSpell
	{
		public static void DeactivateAllTransformation(Mobile from)
		{
			if (FormeCristallineSpell.IsActive(from))
				FormeCristallineSpell.Deactivate(from);
			if (FormeCycloniqueSpell.IsActive(from))
				FormeCycloniqueSpell.Deactivate(from);
			if (FormeElectrisanteSpell.IsActive(from))
				FormeElectrisanteSpell.Deactivate(from);
			if (FormeEmpoisonneeSpell.IsActive(from))
				FormeEmpoisonneeSpell.Deactivate(from);
			if (FormeEnflammeeSpell.IsActive(from))
				FormeEnflammeeSpell.Deactivate(from);
			if (FormeEnsanglanteeSpell.IsActive(from))
				FormeEnsanglanteeSpell.Deactivate(from);
			if (FormeGivranteSpell.IsActive(from))
				FormeGivranteSpell.Deactivate(from);
			if (FormeLiquideSpell.IsActive(from))
				FormeLiquideSpell.Deactivate(from);
			if (FormeMetalliqueSpell.IsActive(from))
				FormeMetalliqueSpell.Deactivate(from);
			if (FormeTerrestreSpell.IsActive(from))
				FormeTerrestreSpell.Deactivate(from);
		}
	}
}
