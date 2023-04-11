namespace Server
{
  public enum GrandeurEnum
  {
        [AppearanceAttribute("Aucun", "Aucune")]
        None,
        [AppearanceAttribute("Très petit", "Très petite")]
        TresPetit,
        [AppearanceAttribute("Petit", "Petite")]
        Petit,
        [AppearanceAttribute("Plutôt petit", "Plutôt petite")]
        PlutotPetit,
        [AppearanceAttribute("Moyen", "Moyenne")]
        Moyen,
        [AppearanceAttribute("Plutôt grand", "Plutôt grande")]
        PlutotGrand,
        [AppearanceAttribute("Grand", "Grande")]
        Grand,
        [AppearanceAttribute("Très grand", "Très grande")]
        TresGrand,
        [AppearanceAttribute("Colossal", "Colossale")]
        Colossale
    }
}
